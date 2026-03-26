using System;
using System.Windows.Forms;

namespace TypeClipboardText
{
    public partial class AutoConfirmDialog : Form
    {
        private System.Windows.Forms.Timer timer;
        private int elapsed;
        private readonly int timeoutMs;
        public DialogResult AutoResult { get; private set; } = DialogResult.None;

        public AutoConfirmDialog(string message, string title, int timeoutMilliseconds = 3000)
        {
            InitializeComponent();
            labelMessage.Text = message;
            this.Text = title;
            timeoutMs = timeoutMilliseconds;
            progressBar.Maximum = timeoutMs;
            progressBar.Value = timeoutMs;
            timer = new System.Windows.Forms.Timer { Interval = 50 };
            timer.Tick += Timer_Tick;
        }

        private void AutoConfirmDialog_Load(object sender, EventArgs e)
        {
            elapsed = 0;
            progressBar.Value = timeoutMs;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsed += timer.Interval;
            if (elapsed > timeoutMs)
            {
                timer.Stop();
                AutoResult = DialogResult.Yes;
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                progressBar.Value = progressBar.Maximum - elapsed;
                labelProgress.Text = progressBar.Value.ToString() + " of " + progressBar.Maximum.ToString();
            }
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            timer.Stop();
            AutoResult = DialogResult.Yes;
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            timer.Stop();
            AutoResult = DialogResult.No;
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void AutoConfirmDialog_MouseMove(object sender, MouseEventArgs e)
        {
            timer.Stop();
        }

        private void AutoConfirmDialog_MouseLeave(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
