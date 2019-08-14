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
        //private BackgroundWorker _bgworker = new BackgroundWorker();

        //private int _workerState;
        //public int WorkerState
        //{
        //    get { return _workerState; }
        //    set
        //    {
        //        _workerState = value;
        //        if (PropertyChanged != null)
        //            PropertyChanged(this, new PropertyChangedEventArgs("WorkerState"));
        //    }
        //}

        // public int value;

        public double max;
        public double value;
        public Window4()
        {
            
            InitializeComponent();
            //        this.SetValue(10);
            //    }

            //    private void SetValue(int count)
            //    {
            //        for (int i = 0; i < count; i++)
            //        {
            //            beginImport(i);
            //        }
            //        //this.Close();
            //    }
            //    private delegate void UpdateProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);
            //    private void beginImport(int i)
            //    {
            //        progressBar1.Maximum = 100;
            //        progressBar1.Value = 0;
            //        UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(progressBar1.SetValue);
            //        Thread thread = new Thread(new ThreadStart(() =>
            //        {
            //            Dispatcher.Invoke(updatePbDelegate, System.Windows.Threading.DispatcherPriority.Background, new object[] { System.Windows.Controls.ProgressBar.ValueProperty, Convert.ToDouble(i + 1) });
            //            Thread.Sleep(100);
            //        }));
            //        thread.Start();
            //    }
            //}
            Thread mThread = new Thread(ThreadProcess);
            //progressBar1.Maximum = max;
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





