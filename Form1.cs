using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections;
using TextCopy;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using System.ComponentModel;

namespace TypeClipboardText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            UpdateTextFromClipboard();
        }


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowEnabled(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        const string DEFAULT_TYPE_TEXT = "<Enter Text>";

        private object lockObject = new object();  // For thread synchronization

        private ArrayList activeWindowsList = new ArrayList(); // List of active windows for the menu

        private (IntPtr Handle, string Title) getFirstActiveWindow()
        {
            for (int i = 0; i < activeWindowsList.Count; i++)
            {
#pragma warning disable CS8605 // Unboxing a possibly null value.
                var (hWnd, title) = ((IntPtr, string))activeWindowsList[i];
#pragma warning restore CS8605 // Unboxing a possibly null value.

                if (!(title.Contains("TypeClipboardText") || title.Contains("PopupHost")))
                {
                    return (hWnd, title);
                }
            }
            return (IntPtr.Zero, "");
        }

        private void UpdateActiveWindowsList() // enum the callback to fill activeWindowsList ArrayList
        {
            activeWindowsList.Clear(); // Clear before enumeration
            EnumWindows(EnumWindowsCallback, IntPtr.Zero);
        }

        private void UpdateContextMenuWithActiveWindowsList()
        {
            int SEPERATOR_START = 4;
            int SEPERATOR_END = contextMenuStrip.Items.Count - 2;  //End - 2 Seperator and Exit

            UpdateActiveWindowsList(); // enum the callback to fill activeWindowsList ArrayList

            // Clear existing windows title menu items after the 4th item so it does not keep adding 
            for (int i = SEPERATOR_END - 1; i >= SEPERATOR_START; i--)
                contextMenuStrip.Items.RemoveAt(i);

            // Add active windows as menu items, starting from the 5th position
            for (int i = 0; i < activeWindowsList.Count; i++)
            {
#pragma warning disable CS8605 // Unboxing a possibly null value.
                var (hWnd, title) = ((IntPtr, string))activeWindowsList[i];
#pragma warning restore CS8605 // Unboxing a possibly null value.

                ToolStripMenuItem item = new ToolStripMenuItem($"{hWnd}: {title} ");
                item.Tag = hWnd; // Store the hWnd in the Tag property for later use append "A" for Auto
                contextMenuStrip.Items.Insert(SEPERATOR_START + i, item);
            }
        }

        private bool EnumWindowsCallback(IntPtr hWnd, IntPtr lParam)
        {
            // Filter out non-visible windows:
            if (IsWindowVisible(hWnd) && IsWindowEnabled(hWnd))
            {
                int size = GetWindowTextLength(hWnd);
                if (size++ > 0)
                {
                    StringBuilder sb = new(size);  // Windows Title
                    GetWindowText(hWnd, sb, size);

                    lock (lockObject) // Synchronize access to runningWindowsList
                    {
                        // Store a tuple of hWnd and title in the ArrayList
                        activeWindowsList.Add((hWnd, sb.ToString()));
                    }
                }
            }
            return true;
        }

        private string UpdateTextFromClipboard()
        {
            string clipboardText = ClipboardService.GetText() ?? string.Empty;

            if (!string.IsNullOrEmpty(clipboardText))
            {
                //Update window with Clipboard text
                textClipboard.Text = clipboardText;
                labelClipboardLength.Text = clipboardText.Length.ToString();
                // Update the menu text box with clipboard text
                toolStripClipboardText.Text = clipboardText;
            }
            else
            {
                toolStripClipboardText.Text = DEFAULT_TYPE_TEXT;
            }

            return clipboardText;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public uint type;
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        private void TypeFromClipboard()
        {
            string keypressText = UpdateTextFromClipboard();

            if (!string.IsNullOrEmpty(keypressText))
            {
                var inputs = keypressText.Select(c => new INPUT
                {
                    type = 1, // INPUT_KEYBOARD Keyboard input
                    wVk = 0,
                    wScan = (ushort)c,
                    dwFlags = 0,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }).ToArray();

                try
                {
                    Thread.Sleep(100);
                    uint result = SendInput((uint)inputs.Length, inputs, Marshal.SizeOf<INPUT>());
                    Thread.Sleep(100);
                    if (result != (uint)inputs.Length) // Check for expected result
                    {
                        int errorCode = Marshal.GetLastWin32Error();
                        if (errorCode != 0) // Handle explicit errors
                        {
                            string errorMessage = new Win32Exception(errorCode).Message;
                            LogMessage($"SendInput failed with error code {errorCode}: {errorMessage}");
                            // MessageBox.Show($"Error typing clipboard text: {errorMessage}", "TypeClipboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else // If errorCode is 0, but result is not expected
                        {
                            LogMessage($"SendInput returned {result} (expected {inputs.Length}), but GetLastError returned 0 (no error). Investigation needed.");
                        }
                    }
                    else
                    {
                        LogMessage($"TypeFromClipboard sent '{keypressText}' as keypress"); // Log success only if all keys were sent
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error typing clipboard text: {ex.Message}", "TypeClipboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Clipboard does not have any text!\r\n Right-click the application in system tray and enter text OR copy text to the Clipboard {keypressText}", "TypeClipboardText", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            LogMessage($"TypeFromClipboard sent '{keypressText}' as keypress");
        }
        private void LogMessage(string message)
        {
            // Create a formatted log entry
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

            // Add to the listbox on the UI thread
            if (InvokeRequired)
            {
                Invoke(new Action(() => listLog.Items.Add(logEntry)));
            }
            else
            {
                listLog.Items.Add(logEntry);
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Dispose(true);
            Application.Exit();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Get the last active window
            UpdateActiveWindowsList();

            // find first active window that is not .this application
            var (hWnd, title) = getFirstActiveWindow();
            LogMessage($"notifyIcon_MouseDoubleClick first active window: hWnd={hWnd} title={title}");
            // bring the window to the foreground
            if (hWnd != IntPtr.Zero)
                SetForegroundWindow(hWnd);

            // send key stroke 
            TypeFromClipboard();
        }

        private void menuTypeClipboardText_Click(object sender, EventArgs e)
        {
            // TypeFromClipboard(sender, e);
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpdateTextFromClipboard();
            UpdateContextMenuWithActiveWindowsList();

        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Exclude clicks on separators and the "Active Windows" menu item itself
            if (e.ClickedItem is ToolStripSeparator || e.ClickedItem.Name == "menuExit")
                return;
            try
            {
                // Get the hWnd from the clicked item's Tag
                IntPtr hWnd = (IntPtr)e.ClickedItem.Tag;

                LogMessage($"contextMenuStrip_ItemClicked window selected: hWnd={hWnd} title={e.ClickedItem.Text}");

                // Activate the window (bring it to the foreground)
                if (hWnd != IntPtr.Zero)
                    SetForegroundWindow(hWnd);
                TypeFromClipboard();
            }
            catch
            {
                //Ignore errors
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CopyLogMessagesToClipboard()
        {
            // Get all log messages from the listbox
            string logText = string.Join(Environment.NewLine, listLog.Items.Cast<string>()); // Join lines with newlines

            if (!string.IsNullOrEmpty(logText))
            {
                // Copy to clipboard (using TextCopy library)
                ClipboardService.SetText(logText);

                // Notify the user (optional)
                MessageBox.Show("Log messages copied to clipboard.", "TypeClipboardText", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Notify if there are no messages to copy
                MessageBox.Show("No log messages to copy.", "TypeClipboardText", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCopyLogs_Click(object sender, EventArgs e)
        {
            CopyLogMessagesToClipboard();
            UpdateTextFromClipboard();
        }
    }
}
