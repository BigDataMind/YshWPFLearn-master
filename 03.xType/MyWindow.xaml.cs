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
using System.Windows.Shapes;

namespace _03.xType
{
	/// <summary>
	/// MyWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MyWindow : Window
	{
		public MyWindow()
		{
			InitializeComponent();
		}
	}

	public class MyButton :Button
	{
		public Type UserWindowType { get; set; }

		protected override void OnClick()
		{
			base.OnClick();
			Window win = Activator.CreateInstance(this.UserWindowType) as Window;
			if (win != null)
			{
				win.ShowDialog();
			}
		}
	}
}
