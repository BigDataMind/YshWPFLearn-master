﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _01AssemblyResources
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void cmdPlay_Click(object sender, RoutedEventArgs e)
        {
            img.Source = new BitmapImage(new Uri("Images/Winter.jpg",UriKind.Relative));
            //img.Source = new BitmapImage(new Uri("pack://application:,,,/images/winter.jpg"));
            Sound.Stop();
            Sound.Play();
        }
    }
}
