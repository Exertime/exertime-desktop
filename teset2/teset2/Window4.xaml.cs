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
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

namespace teset2
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window//, INotifyPropertyChanged
    {
      

        public double max;
        public double value;
        public Window4()
        {
            
            InitializeComponent();
        
            Thread mThread = new Thread(ThreadProcess);
   
            mThread.Start();
            Topmost=true;
            this.Top = 0;
            this.Left = (SystemParameters.WorkArea.Width - this.Width)/2;


        }


        private delegate void SetprogressBarHandle(int vaule);

        private void SetprogressBar(int vaule)
        {
            if (this.Dispatcher.Thread != System.Threading.Thread.CurrentThread)
            {
                this.Dispatcher.Invoke(new SetprogressBarHandle(this.SetprogressBar), vaule);
            }
            else
            {
                progressBar1.Value =vaule;

            }



        }

        public void ThreadProcess(object obj)
        {
            int i = 0;
            while (i <= max)
            {

                i++;
                SetprogressBar(i);
                Thread.Sleep(1000);
            }
            this.Dispatcher.Invoke(
                            new Action(
                                delegate
                                {
                                    this.IsEnabled = true;
                                    this.Close();
                                }));
            





        }




    }
}





