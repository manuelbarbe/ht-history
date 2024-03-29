﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace HtHistory
{
    static class Program
    {
        static SplashScreen _splashScreen;

        static void ShowSplash()
        {
            Application.Run(_splashScreen);
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.SetCompatibleTextRenderingDefault(false);

            _splashScreen = new SplashScreen();
            Thread thread = new Thread(Program.ShowSplash) { IsBackground = true, ApartmentState = ApartmentState.STA };
            thread.Start();
            Thread.Sleep(2000);
            _splashScreen.BeginInvoke((Action) (() => _splashScreen.Close()) );
			
			//TODO: this is crappy
			if (Utils.IsRunningOnMono())
			{
				System.Net.ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };
			}
				
            Application.Run(new Form1());
        }
    }
}
