using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Electric
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                bool isAppRunning = false;
                System.Threading.Mutex mutex = new System.Threading.Mutex(
                    true,
                    System.Diagnostics.Process.GetCurrentProcess().ProcessName,
                    out isAppRunning);

                if (!isAppRunning)
                {
                    //MessageBox.Show("本程序已经在运行了，请不要重复运行！");
                    Environment.Exit(1);
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    frm_login frm = new frm_login();
                    if (DialogResult.OK == frm.ShowDialog())
                    {
                        Application.Run(new frm_Main());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Application.Run(new frm_login());
        }
    }
}
