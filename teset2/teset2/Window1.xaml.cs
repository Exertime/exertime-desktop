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
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Navigation;
using System.Windows.Threading;
namespace teset2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int Choice;
        private DispatcherTimer timer;
        public Window1()
        {
            InitializeComponent();
            
            Topmost = true;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timer_Tick;
            this.Left = SystemParameters.WorkArea.Width - this.Width;
            this.EndTop = SystemParameters.WorkArea.Height - this.Height;
            this.Top = SystemParameters.WorkArea.Height;
            timer.Start();
        }
        
        public double EndTop { get; set; }

        void timer_Tick(object sender, EventArgs e)
        {
            while (this.Top > EndTop)
            {
                this.Top -= 1;
            }
        }

    
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();

            if (cmb.SelectedIndex == 0)
            {
                Choice = 5000;
                Window4 w4 = new Window4();
                w4.max = 5;
                w4.progressBar1.Maximum = 5;
           
                w4.Show();
            }
            else if (cmb.SelectedIndex == 1)
            {
                Choice = 10000;
                Window4 w4 = new Window4();
                w4.max = 10;
                w4.progressBar1.Maximum = 10;
                w4.Show();
            }
            else if (cmb.SelectedIndex == 2)
            {
                Choice = 15000;
                Window4 w4 = new Window4();
                w4.max = 15;
                w4.progressBar1.Maximum = 15;
                w4.Show();
            }
            else if (cmb.SelectedIndex == 3)
            {
                Choice = 20000;
                Window4 w4 = new Window4();
                w4.max = 20;
                w4.progressBar1.Maximum = 20;
                w4.Show();
            }
            Thread t = new Thread(new ThreadStart(() =>
        {
            Thread.Sleep(Choice);
            Window1 w1 = new Window1();
      
            w1.Show();
            System.Windows.Threading.Dispatcher.Run(); // for solving STA problem..
        }));
         
            t.SetApartmentState(ApartmentState.STA);  // for solving STA problem..
            t.IsBackground = true;
            t.Start();

        }

        public delegate void Delegate();
     //   public event Delegate window;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

           this.Close();
            Window3 w3 = new Window3();
            w3.Show();
            //window();
        }
    }
}
        
    

