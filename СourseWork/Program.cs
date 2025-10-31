namespace СourseWork
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}