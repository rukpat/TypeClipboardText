namespace TypeClipboardText
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {

            // Get the name of your executable file
            string processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

            // Check if another process with the same name exists
            if (System.Diagnostics.Process.GetProcessesByName(processName).Length > 1)
            {
                MessageBox.Show($"Another instance of the application ({processName}) is already running.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Exit the current instance
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}