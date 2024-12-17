namespace PL
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
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //// Tạo instance của Form Login
            //SignIn loginForm = new SignIn();

            //// Hiển thị Form Login
            //if (loginForm.ShowDialog() == DialogResult.OK) // Đăng nhập thành công
            //{
            //    Application.Run(new Main()); 
            //}
            //else
            //{
            //    // Thoát ứng dụng nếu không đăng nhập
            //    Application.Exit();
            //}
            SignIn loginForm = new SignIn();
            loginForm.ShowDialog();

        }
    }
}