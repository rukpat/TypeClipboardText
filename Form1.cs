using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using TextCopy;
using Interop.UIAutomationClient;


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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "GetClassLong")]
        static extern uint GetClassLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetClassLongPtr")]
        static extern IntPtr GetClassLongPtr64(IntPtr hWnd, int nIndex);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr LoadIcon(IntPtr hInstance, IntPtr lpIconName);

        const string DEFAULT_TYPE_TEXT = "<Enter Text>";

        private object lockObject = new object();  // For thread synchronization

        private ArrayList activeWindowsList = new ArrayList(); // List of active windows for the menu
        private Dictionary<IntPtr, Icon> windowIcons = new Dictionary<IntPtr, Icon>();  // for getting the icons of the windows

        private (IntPtr Handle, string Title) getFirstActiveWindow()
        {
            for (int i = 0; i < activeWindowsList.Count; i++)
            {

                var (hWnd, title, icon) = ((IntPtr, string, Icon))activeWindowsList[i];

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
                var (hWnd, title, icon) = ((IntPtr, string, Icon))activeWindowsList[i];

                ToolStripMenuItem item = new ToolStripMenuItem($"{title}");
                item.Tag = hWnd; // Store the hWnd in the Tag property for later use append "A" for Auto

                if (icon != null) // Set the icon for the menu item
                {
                    item.Image = icon.ToBitmap();
                }

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

                    // Get the window's icon
                    Icon icon = GetWindowIcon(hWnd);
                    lock (lockObject)
                    {
                        // Store a tuple of hWnd, title and Icon in the ArrayList
                        activeWindowsList.Add((hWnd, sb.ToString(), icon)); 
                        windowIcons[hWnd] = icon; // Store icon in the dictionary
                    }
                }
            }
            return true;
        }

        private Icon GetWindowIcon(IntPtr hWnd)
        {
            IntPtr hIcon = SendMessage(hWnd, 0x0080/*WM_GETICON*/, 2/*ICON_SMALL2*/, 0);
            if (hIcon == IntPtr.Zero)
                hIcon = GetClassLongPtr(hWnd, -14/*GCL_HICONSM*/);
            if (hIcon == IntPtr.Zero)
                hIcon = LoadIcon(IntPtr.Zero, (IntPtr)0x7F00/*IDI_APPLICATION*/);
            if (hIcon != IntPtr.Zero)
                return Icon.FromHandle(hIcon);
            else
                return null;
        }

        // This static method will return long for both 32 bit and 64 bit architecture
        static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
                return GetClassLongPtr64(hWnd, nIndex);
            else
                return new IntPtr(GetClassLongPtr32(hWnd, nIndex));
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

        private void TypeFromClipboard(IntPtr hWnd)
        {
            const int MAX_TEXT_LENGTH = 50;
            string keypressText = UpdateTextFromClipboard();

            //string clipboardText = ClipboardService.GetText() ?? string.Empty;

            if (!string.IsNullOrEmpty(keypressText))
            {

                // Check if text exceeds the maximum length
                if (keypressText.Length > MAX_TEXT_LENGTH)
                {
                    DialogResult result = MessageBox.Show(
                        $"The Clipboard text is {keypressText.Length} characters long.\r\n\r\nThis will cause a long wait and might cause issues if you interrupt.\r\n\r\n\r\n Do you want to proceed?",
                        "Warning: Long Clipboard Text",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (result == DialogResult.No)
                    {
                        LogMessage("User canceled typing due to long clipboard text.");
                        return; // Exit the function if the user cancels
                    }
                }


                try
                {

                    IUIAutomation automation = new CUIAutomation(); // Create UIAutomation instance
                    IUIAutomationElement targetWindow = automation.ElementFromHandle(hWnd);

                    // Set focus to the window itself (just in case)
                    targetWindow.SetFocus();

                    //Wait for a bit
                    System.Threading.Thread.Sleep(500);


                    // Use the SendKeys method to send the clipboard text
                    // Escape special characters for SendKeys
                    /*keypressText = keypressText  // Error causing nexting of replacements
                        .Replace("+", "{+}")
                        .Replace("^", "{^}")
                        .Replace("%", "{%}")
                        .Replace("~", "{~}")
                        .Replace("(", "{(}")
                        .Replace(")", "{)}")
                        .Replace("{", "{{}")
                        .Replace("}", "{}}")
                        .Replace("[", "{[]}")
                        .Replace("]", "{[]}");
                    */
                    keypressText = Regex.Replace(keypressText, @"([+\^%~(){}[\]])", "{$1}");

                    LogMessage($"SendKeys will send: '{keypressText}'");
                    System.Windows.Forms.SendKeys.SendWait(keypressText);
                    LogMessage($"SentKeys sent: '{keypressText}'");
                }
                catch (Exception ex)
                {
                    LogMessage($"Error typing clipboard text using UIAutomation: {ex.Message}");
                    MessageBox.Show($"Error typing clipboard text: {ex.Message}", "TypeClipboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"Clipboard does not have any text!\r\n Right-click the application in system tray and enter text OR copy text to the Clipboard {keypressText}", "TypeClipboardText", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
            UpdateContextMenuWithActiveWindowsList();

            // find first active window that is not .this application
            var (hWnd, title) = getFirstActiveWindow();
            LogMessage($"notifyIcon_MouseDoubleClick first active window: hWnd={hWnd} title={title}");
            // bring the window to the foreground
            if (hWnd != IntPtr.Zero)
            {
                SetForegroundWindow(hWnd);
                // send key stroke 
                TypeFromClipboard(hWnd);
            }
        }

        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            toolStripClipboardText.Size = new Size(100, 21);

            UpdateTextFromClipboard();
            UpdateContextMenuWithActiveWindowsList();

            // Set width of toolStripClipboardText to match contextMenuStrip
            toolStripClipboardText.Size = new Size(contextMenuStrip.Width, 21); // contextMenuStrip.Width;
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
                {
                    SetForegroundWindow(hWnd);
                    // send key stroke
                    TypeFromClipboard(hWnd);
                }
            }
            catch
            {
                //Ignore errors
            }

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
