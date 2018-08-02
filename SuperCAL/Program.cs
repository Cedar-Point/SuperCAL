using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCAL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            bool prePass = true;
            try
            {
                McrsCalSrvc.Service.Status.ToString();
            }
            catch (InvalidOperationException e)
            {
                Application.Run(new Error(e.Message + "\n\nTry and install Micros CAL next time maybe?"));
                prePass = false;
            }
            if(prePass)
            {
                Application.Run(new Main());
            }
        }
    }
}
