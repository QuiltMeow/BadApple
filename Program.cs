using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BadApple
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Process currentProcess = Process.GetCurrentProcess();
            string processName = currentProcess.ProcessName;
            if (Process.GetProcessesByName(processName).Length > 1)
            {
                MessageBox.Show("已偵測到其他程式個體正在執行", "資訊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.Run(new BadApple());
        }
    }
}