using NadaTech.Data;
using NadaTech.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NadaTech
{
    internal static class Program
    {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public static IntPtr handle = IntPtr.Zero;

		public static int UserId;
        public static int UserGroupId;
        public static UserMaster UserMaster;
        public static LocationMaster locationMaster;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
