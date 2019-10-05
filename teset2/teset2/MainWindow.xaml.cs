using System;
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
using System.Timers;
using System.Threading;
using System.Windows.Forms;

namespace teset2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
           
            icon();

        }
        NotifyIcon notifyIcon = null;

        public void icon()
        {
             this.notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon("logo1.ico");
            notifyIcon.Visible = true;

            notifyIcon.MouseDoubleClick += OnNotifyIconDoubleClick;


            if (id != 0)
            {
                System.Windows.Forms.MenuItem m1 = new System.Windows.Forms.MenuItem("Run");
                m1.Click += m1_Click;
                System.Windows.Forms.MenuItem m2 = new System.Windows.Forms.MenuItem("Exit");
                m2.Click += m2_Click;
                System.Windows.Forms.MenuItem m3 = new System.Windows.Forms.MenuItem("Logout");
                m3.Click += m3_Click;
                System.Windows.Forms.MenuItem[] m = new System.Windows.Forms.MenuItem[] { m1, m3,m2 };
                this.notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(m);
            }
            else
            {
               
                System.Windows.Forms.MenuItem m2 = new System.Windows.Forms.MenuItem("Exit");
                m2.Click += m2_Click;
                System.Windows.Forms.MenuItem m4 = new System.Windows.Forms.MenuItem("Login");
                m4.Click += m3_Click;
                System.Windows.Forms.MenuItem[] m = new System.Windows.Forms.MenuItem[] { m4,m2 };
                this.notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(m);

            }
        }

        private void m1_Click(object sender, EventArgs e)
        {
            if (DataAccess.login(UserTextBox.Text, PwdTextBox.Text) != 0)
            {
                Window2 w2 = new Window2();
                // MessageBox.Show(DataAccess.login(UserTextBox.Text, PwdTextBox.Text).ToString());
                w2.id = DataAccess.login(UserTextBox.Text, PwdTextBox.Text);
                w2.Show();
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                this.Visibility = Visibility.Visible;
            }
        }

        private void m3_Click(object sender, EventArgs e)
        {
            this.id = 0;
            this.Visibility = Visibility.Visible;
        }
        private void m2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            if (DataAccess.login(UserTextBox.Text, PwdTextBox.Text) != 0)
            {
                Window2 w2 = new Window2();
                // MessageBox.Show(DataAccess.login(UserTextBox.Text, PwdTextBox.Text).ToString());
                w2.id = DataAccess.login(UserTextBox.Text, PwdTextBox.Text);
                w2.Show();
                this.Visibility = Visibility.Hidden;
            }

        }



        private const int p = 45;

        public int count = 0;

        public int id = 0;


        //public delegate void Delegate();
        //public event Delegate pumpup;
        public void hostage(int time)
        {
            count = count + time;
            if (count >= p)
            {
                Window3 w3 = new Window3();
                w3.id = id;
                w3.Show();
                //pumpup();

                count = 0;
            }
        }

        //private void win3()
        //     {
        //         Window3 w3 = new Window3();
        //         w3.window += new Window3.Delegate(restart);
        //         w3.Show();
        //     }

        //private void restart()
        //{
        //    Thread t = new Thread(new ThreadStart(() =>
        //    {

        //        Thread.Sleep(5000);
        //        Window1 w1 = new Window1();
        //        w1.window += new Window1.Delegate(win3);
        //        w1.WindowStartupLocation = WindowStartupLocation.Manual;


        //        w1.Show();
        //        System.Windows.Threading.Dispatcher.Run(); // for solving STA problem..
        //    }));
        //    t.SetApartmentState(ApartmentState.STA);  // for solving STA problem..
        //    t.IsBackground = true;
        //    t.Start();
        //}

        private void btnlogin_Click(object sender,RoutedEventArgs e)
        {

            if (DataAccess.login(UserTextBox.Text, PwdTextBox.Text) != 0)
            {
                Window2 w2 = new Window2();
               // MessageBox.Show(DataAccess.login(UserTextBox.Text, PwdTextBox.Text).ToString());
                w2.id = DataAccess.login(UserTextBox.Text, PwdTextBox.Text);
                id = DataAccess.login(UserTextBox.Text, PwdTextBox.Text);
                w2.Show();
                this.notifyIcon.Visible = false;
                icon();
                this.Visibility = Visibility.Hidden;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.Visibility = Visibility.Hidden;

        }


    }
}
