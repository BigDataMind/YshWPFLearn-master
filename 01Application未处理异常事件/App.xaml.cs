﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _01Application未处理异常事件
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private bool unsavedData;

        public bool UnsavedData
        {
            get { return unsavedData; }
            set { unsavedData = value; }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            unsavedData = true;
        }

        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);
            if (UnsavedData)
            {
                e.Cancel = true;
                MessageBox.Show("The application attempted to be closed as a result of " +
                    e.ReasonSessionEnding.ToString()+". This is not allowed,as you have unsaved data.");
            }
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled " + e.Exception.GetType().ToString() +
                " exception was caught and ignored.");
            e.Handled = true;
        }
    }
}
