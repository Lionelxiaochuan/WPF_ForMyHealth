using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace WPF_ForMyHealth
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //系统托盘
        private NotifyIcon notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon();
        }


        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //系统托盘
            notifyIcon.Icon = new System.Drawing.Icon("Resource/icon.ico");
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            MenuItem exitItem = new MenuItem("退出");
            MenuItem settingItem = new MenuItem("设置");

            exitItem.Click += ExitItem_Click;

            MenuItem[] items = new MenuItem[] { exitItem, settingItem };

            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(items);

        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            //Window_Closed(sender, e);
            App.Current.MainWindow.Close();
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
        }

        //private void Window_Closed(object sender, EventArgs e)
        //{
        //    //判断 sender 是谁？  如果是window？则hide 如果是notify则close
        //    if (sender.Equals(notifyIcon))
        //    {
        //        this.Close();
        //    }
        //    else if (sender.Equals(this))
        //    {
        //        this.Hide();
        //    }
        //}

        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Hide();
        //}

        protected override void OnClosed(EventArgs e)
        {
            //base.OnClosed(e);
            this.Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }


        //private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    if (sender.Equals(this))
        //    {
        //        this.Hide();
        //    }
        //}
    }
}
