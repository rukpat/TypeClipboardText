namespace TypeClipboardText
{
    partial class AutoConfirmDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonNo;

        /// <summary>
        /// Clean up any resources being used.
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

        private void InitializeComponent()
        {
            labelMessage = new Label();
            progressBar = new ProgressBar();
            buttonYes = new Button();
            buttonNo = new Button();
            labelProgress = new Label();
            labelCloseMsg = new Label();
            SuspendLayout();
            // 
            // labelMessage
            // 
            labelMessage.AutoSize = true;
            labelMessage.Location = new Point(12, 9);
            labelMessage.MaximumSize = new Size(360, 0);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(53, 15);
            labelMessage.TabIndex = 0;
            labelMessage.Text = "Message";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(12, 98);
            progressBar.Maximum = 3000;
            progressBar.Name = "progressBar";
            progressBar.RightToLeft = RightToLeft.Yes;
            progressBar.RightToLeftLayout = true;
            progressBar.Size = new Size(357, 23);
            progressBar.TabIndex = 1;
            progressBar.Value = 1000;
            // 
            // buttonYes
            // 
            buttonYes.Location = new Point(202, 146);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new Size(75, 23);
            buttonYes.TabIndex = 2;
            buttonYes.Text = "Yes";
            buttonYes.UseVisualStyleBackColor = true;
            buttonYes.Click += buttonYes_Click;
            // 
            // buttonNo
            // 
            buttonNo.Location = new Point(294, 146);
            buttonNo.Name = "buttonNo";
            buttonNo.Size = new Size(75, 23);
            buttonNo.TabIndex = 3;
            buttonNo.Text = "No";
            buttonNo.UseVisualStyleBackColor = true;
            buttonNo.Click += buttonNo_Click;
            buttonNo.Enter += buttonNo_Click;
            // 
            // labelProgress
            // 
            labelProgress.AutoSize = true;
            labelProgress.Location = new Point(12, 124);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(38, 15);
            labelProgress.TabIndex = 4;
            labelProgress.Text = "Timer";
            // 
            // labelCloseMsg
            // 
            labelCloseMsg.Location = new Point(12, 139);
            labelCloseMsg.Name = "labelCloseMsg";
            labelCloseMsg.Size = new Size(132, 33);
            labelCloseMsg.TabIndex = 5;
            labelCloseMsg.Text = "Move the Mouse over the window to STOP!";
            // 
            // AutoConfirmDialog
            // 
            AcceptButton = buttonYes;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonNo;
            ClientSize = new Size(383, 181);
            Controls.Add(labelCloseMsg);
            Controls.Add(labelProgress);
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(progressBar);
            Controls.Add(labelMessage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AutoConfirmDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Auto Confirm";
            Load += AutoConfirmDialog_Load;
            MouseLeave += AutoConfirmDialog_MouseLeave;
            MouseMove += AutoConfirmDialog_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelProgress;
        private Label labelCloseMsg;
    }
}
