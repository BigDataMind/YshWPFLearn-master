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

namespace _07._3DataTemplate控件
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            //访问业务逻辑数据
            TextBox tb = e.OriginalSource as TextBox;  //获取事件发起的源头
            ContentPresenter cp = tb.TemplatedParent as ContentPresenter; //获取模板目标
            Student stu = cp.Content as Student; //获取业务逻辑数据
            this.listViewStudent.SelectedItem = stu;  //设置ListView的选择项

            //访问界面元素
            ListViewItem lvi = this.listViewStudent.
                ItemContainerGenerator.ContainerFromItem(stu) as ListViewItem;
            CheckBox chb = this.FindVisualChild<CheckBox>(lvi);
            MessageBox.Show(chb.Name);

        }

        private ChildType FindVisualChild<ChildType>(DependencyObject obj)
            where ChildType : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null & child is ChildType)
                {
                    return child as ChildType;
                }
                else
                {
                    ChildType childOfChild = FindVisualChild<ChildType>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return null;
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public bool HasJob { get; set; }
    }
}
