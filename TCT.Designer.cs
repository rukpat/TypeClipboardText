namespace TypeClipboardText
{
    partial class TCT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCT));
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            toolStripMenuInstructClipboardDisabled = new ToolStripMenuItem();
            toolStripClipboardText = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuInstructWindowsDisabled = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItemShowWindow = new ToolStripMenuItem();
            menuExit = new ToolStripMenuItem();
            labelClipText = new Label();
            textClipboard = new TextBox();
            labelClipboardLength = new Label();
            labelClipLen = new Label();
            labelLog = new Label();
            labelExclude = new Label();
            textExclude = new TextBox();
            buttonAddExclude = new Button();
            buttonRemoveExclude = new Button();
            listExclude = new ListBox();
            listLog = new ListBox();
            buttonCopyLogs = new Button();
            checkEnableLogging = new CheckBox();
            buttonClearLogs = new Button();
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Send as keypress, the clipboard text to the active/selected window. Double-Click for auto send or Right-Click for Menu";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuInstructClipboardDisabled, toolStripClipboardText, toolStripSeparator1, toolStripMenuInstructWindowsDisabled, toolStripSeparator2, toolStripMenuItemShowWindow, menuExit });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(363, 143);
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
            toolStripClipboardText.MaxLength = 100;
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
            // labelClipText
            // 
            labelClipText.AutoSize = true;
            labelClipText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClipText.Location = new Point(12, 9);
            labelClipText.Name = "labelClipText";
            labelClipText.Size = new Size(90, 15);
            labelClipText.TabIndex = 1;
            labelClipText.Text = "Clipboard Text:";
            // 
            // textClipboard
            // 
            textClipboard.Location = new Point(12, 27);
            textClipboard.MinimumSize = new Size(50, 50);
            textClipboard.Multiline = true;
            textClipboard.Name = "textClipboard";
            textClipboard.ReadOnly = true;
            textClipboard.ScrollBars = ScrollBars.Vertical;
            textClipboard.Size = new Size(638, 57);
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
            // labelClipLen
            // 
            labelClipLen.AutoSize = true;
            labelClipLen.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelClipLen.Location = new Point(164, 9);
            labelClipLen.Name = "labelClipLen";
            labelClipLen.Size = new Size(49, 15);
            labelClipLen.TabIndex = 4;
            labelClipLen.Text = "Length:";
            // 
            // labelLog
            // 
            labelLog.AutoSize = true;
            labelLog.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelLog.Location = new Point(11, 301);
            labelLog.Name = "labelLog";
            labelLog.Size = new Size(30, 15);
            labelLog.TabIndex = 5;
            labelLog.Text = "Log:";
            // 
            // labelExclude
            // 
            labelExclude.AutoSize = true;
            labelExclude.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelExclude.Location = new Point(12, 115);
            labelExclude.Name = "labelExclude";
            labelExclude.Size = new Size(310, 15);
            labelExclude.TabIndex = 10;
            labelExclude.Text = "Window names to be excluded in the right-click menu:";
            // 
            // textExclude
            // 
            textExclude.Location = new Point(335, 133);
            textExclude.Name = "textExclude";
            textExclude.PlaceholderText = "Enter exclude word/phrase";
            textExclude.Size = new Size(177, 23);
            textExclude.TabIndex = 12;
            textExclude.TextChanged += textExclude_TextChanged;
            // 
            // buttonAddExclude
            // 
            buttonAddExclude.Location = new Point(518, 133);
            buttonAddExclude.Name = "buttonAddExclude";
            buttonAddExclude.Size = new Size(63, 23);
            buttonAddExclude.TabIndex = 13;
            buttonAddExclude.Text = "&Add";
            buttonAddExclude.UseVisualStyleBackColor = true;
            buttonAddExclude.Click += buttonAddExclude_Click;
            // 
            // buttonRemoveExclude
            // 
            buttonRemoveExclude.Location = new Point(587, 133);
            buttonRemoveExclude.Name = "buttonRemoveExclude";
            buttonRemoveExclude.Size = new Size(63, 23);
            buttonRemoveExclude.TabIndex = 14;
            buttonRemoveExclude.Text = "&Remove";
            buttonRemoveExclude.UseVisualStyleBackColor = true;
            buttonRemoveExclude.Click += buttonRemoveExclude_Click;
            // 
            // listExclude
            // 
            listExclude.BackColor = SystemColors.Control;
            listExclude.FormattingEnabled = true;
            listExclude.ItemHeight = 15;
            listExclude.Location = new Point(12, 133);
            listExclude.Name = "listExclude";
            listExclude.Size = new Size(317, 154);
            listExclude.TabIndex = 11;
            listExclude.SelectedIndexChanged += listExclude_SelectedIndexChanged;
            // 
            // listLog
            // 
            listLog.BackColor = SystemColors.Control;
            listLog.FormattingEnabled = true;
            listLog.ItemHeight = 15;
            listLog.Location = new Point(12, 319);
            listLog.Name = "listLog";
            listLog.Size = new Size(638, 154);
            listLog.TabIndex = 6;
            // 
            // buttonCopyLogs
            // 
            buttonCopyLogs.Location = new Point(494, 290);
            buttonCopyLogs.Name = "buttonCopyLogs";
            buttonCopyLogs.Size = new Size(75, 23);
            buttonCopyLogs.TabIndex = 7;
            buttonCopyLogs.Text = "&Copy Logs";
            buttonCopyLogs.UseVisualStyleBackColor = true;
            buttonCopyLogs.Click += buttonCopyLogs_Click;
            // 
            // checkEnableLogging
            // 
            checkEnableLogging.AutoSize = true;
            checkEnableLogging.Location = new Point(380, 294);
            checkEnableLogging.Name = "checkEnableLogging";
            checkEnableLogging.Size = new Size(108, 19);
            checkEnableLogging.TabIndex = 8;
            checkEnableLogging.Text = "Enable Logging";
            checkEnableLogging.UseVisualStyleBackColor = true;
            checkEnableLogging.CheckedChanged += checkEnableLogging_CheckedChanged;
            // 
            // buttonClearLogs
            // 
            buttonClearLogs.Location = new Point(575, 290);
            buttonClearLogs.Name = "buttonClearLogs";
            buttonClearLogs.Size = new Size(75, 23);
            buttonClearLogs.TabIndex = 9;
            buttonClearLogs.Text = "&Clear Logs";
            buttonClearLogs.UseVisualStyleBackColor = true;
            buttonClearLogs.Click += buttonClearLogs_Click;
            // 
            // TCT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(662, 483);
            Controls.Add(buttonCopyLogs);
            Controls.Add(buttonClearLogs);
            Controls.Add(checkEnableLogging);
            Controls.Add(listExclude);
            Controls.Add(textExclude);
            Controls.Add(buttonAddExclude);
            Controls.Add(buttonRemoveExclude);
            Controls.Add(listLog);
            Controls.Add(labelExclude);
            Controls.Add(labelLog);
            Controls.Add(labelClipLen);
            Controls.Add(labelClipboardLength);
            Controls.Add(textClipboard);
            Controls.Add(labelClipText);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TCT";
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
        private Label labelClipText;
        private TextBox textClipboard;
        private Label labelClipboardLength;
        private Label labelClipLen;
        private ToolStripTextBox toolStripClipboardText;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem toolStripMenuInstructClipboardDisabled;
        private ToolStripMenuItem toolStripMenuInstructWindowsDisabled;
        private Label labelLog;
        private ListBox listLog;
        private Button buttonCopyLogs;
        private CheckBox checkEnableLogging;
        private Button buttonClearLogs;
        private Label labelExclude;
        private TextBox textExclude;
        private Button buttonAddExclude;
        private Button buttonRemoveExclude;
        private ListBox listExclude;
        private ToolStripMenuItem toolStripMenuItemShowWindow;
    }
}
