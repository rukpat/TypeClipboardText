namespace TypeClipboardText
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            toolStripMenuInstructClipboardDisabled = new ToolStripMenuItem();
            toolStripClipboardText = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuInstructWindowsDisabled = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemShowWindow = new ToolStripMenuItem();
            menuExit = new ToolStripMenuItem();
            label1 = new Label();
            textClipboard = new TextBox();
            labelClipboardLength = new Label();
            label3 = new Label();
            label2 = new Label();
            listLog = new ListBox();
            buttonCopyLogs = new Button();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Send as keypress clipboard text to the active window";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuInstructClipboardDisabled, toolStripClipboardText, toolStripSeparator1, toolStripMenuInstructWindowsDisabled, toolStripSeparator2, toolStripMenuItemShowWindow, menuExit });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(363, 165);
            contextMenuStrip.Text = "Keypress";
            contextMenuStrip.Opening += contextMenuStrip_Opening;
            contextMenuStrip.ItemClicked += contextMenuStrip_ItemClicked;
            // 
            // toolStripMenuInstructClipboardDisabled
            // 
            toolStripMenuInstructClipboardDisabled.BackColor = SystemColors.InactiveCaption;
            toolStripMenuInstructClipboardDisabled.Enabled = false;
            toolStripMenuInstructClipboardDisabled.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripMenuInstructClipboardDisabled.Image = Properties.Resources._9104219_warning_danger_attention_caution_alert_icon1;
            toolStripMenuInstructClipboardDisabled.Name = "toolStripMenuInstructClipboardDisabled";
            toolStripMenuInstructClipboardDisabled.Size = new Size(362, 26);
            toolStripMenuInstructClipboardDisabled.Text = "1. Clipboard Text (edit if required):";
            // 
            // toolStripClipboardText
            // 
            toolStripClipboardText.BackColor = Color.MistyRose;
            toolStripClipboardText.BorderStyle = BorderStyle.FixedSingle;
            toolStripClipboardText.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            toolStripClipboardText.MaxLength = 10;
            toolStripClipboardText.Name = "toolStripClipboardText";
            toolStripClipboardText.Size = new Size(300, 21);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(359, 6);
            // 
            // toolStripMenuInstructWindowsDisabled
            // 
            toolStripMenuInstructWindowsDisabled.BackColor = SystemColors.InactiveCaption;
            toolStripMenuInstructWindowsDisabled.Enabled = false;
            toolStripMenuInstructWindowsDisabled.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripMenuInstructWindowsDisabled.Image = Properties.Resources._211615_down_c_arrow_icon;
            toolStripMenuInstructWindowsDisabled.Name = "toolStripMenuInstructWindowsDisabled";
            toolStripMenuInstructWindowsDisabled.Size = new Size(362, 26);
            toolStripMenuInstructWindowsDisabled.Text = "2. Select Window to send as keypress:";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(359, 6);
            // 
            // toolStripMenuItemShowWindow
            // 
            toolStripMenuItemShowWindow.Image = Properties.Resources._9042799_open_in_window_icon;
            toolStripMenuItemShowWindow.Name = "toolStripMenuItemShowWindow";
            toolStripMenuItemShowWindow.RightToLeftAutoMirrorImage = true;
            toolStripMenuItemShowWindow.Size = new Size(362, 26);
            toolStripMenuItemShowWindow.Text = "&Show Window";
            toolStripMenuItemShowWindow.Click += toolStripMenuItemShowWindow_Click;
            // 
            // menuExit
            // 
            menuExit.Image = Properties.Resources._4879885_close_cross_delete_remove_icon;
            menuExit.Name = "menuExit";
            menuExit.Size = new Size(362, 26);
            menuExit.Text = "&Quit Application";
            menuExit.Click += menuExit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 1;
            label1.Text = "Clipboard Text:";
            // 
            // textClipboard
            // 
            textClipboard.Location = new Point(12, 27);
            textClipboard.MinimumSize = new Size(50, 50);
            textClipboard.Multiline = true;
            textClipboard.Name = "textClipboard";
            textClipboard.ReadOnly = true;
            textClipboard.ScrollBars = ScrollBars.Vertical;
            textClipboard.Size = new Size(882, 112);
            textClipboard.TabIndex = 2;
            // 
            // labelClipboardLength
            // 
            labelClipboardLength.AutoSize = true;
            labelClipboardLength.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClipboardLength.ImageAlign = ContentAlignment.TopLeft;
            labelClipboardLength.Location = new Point(219, 9);
            labelClipboardLength.Name = "labelClipboardLength";
            labelClipboardLength.Size = new Size(14, 15);
            labelClipboardLength.TabIndex = 3;
            labelClipboardLength.Text = "0";
            labelClipboardLength.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(164, 9);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 4;
            label3.Text = "Length:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 155);
            label2.Name = "label2";
            label2.Size = new Size(30, 15);
            label2.TabIndex = 5;
            label2.Text = "Log:";
            // 
            // listLog
            // 
            listLog.BackColor = SystemColors.Control;
            listLog.FormattingEnabled = true;
            listLog.ItemHeight = 15;
            listLog.Location = new Point(12, 174);
            listLog.Name = "listLog";
            listLog.Size = new Size(882, 289);
            listLog.TabIndex = 6;
            // 
            // buttonCopyLogs
            // 
            buttonCopyLogs.Location = new Point(819, 147);
            buttonCopyLogs.Name = "buttonCopyLogs";
            buttonCopyLogs.Size = new Size(75, 23);
            buttonCopyLogs.TabIndex = 7;
            buttonCopyLogs.Text = "&Copy Logs";
            buttonCopyLogs.UseVisualStyleBackColor = true;
            buttonCopyLogs.Click += buttonCopyLogs_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(908, 476);
            Controls.Add(buttonCopyLogs);
            Controls.Add(listLog);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(labelClipboardLength);
            Controls.Add(textClipboard);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "TypeClipboardText";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Shown += Form1_Shown;
            contextMenuStrip.ResumeLayout(false);
            contextMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem menuExit;
        private Label label1;
        private TextBox textClipboard;
        private Label labelClipboardLength;
        private Label label3;
        private ToolStripTextBox toolStripClipboardText;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuInstructClipboardDisabled;
        private ToolStripMenuItem toolStripMenuInstructWindowsDisabled;
        private Label label2;
        private ListBox listLog;
        private Button buttonCopyLogs;
        private ToolStripMenuItem toolStripMenuItemShowWindow;
    }
}
