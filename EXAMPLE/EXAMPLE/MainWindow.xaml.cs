using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
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


namespace EXAMPLE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<exerciesList> eeee;
        private List<exerciesList> IMG;
      //  private List<exerciesList> vid;
        
        //  private string VideoPath;
        public MainWindow()
        {
            InitializeComponent();
       

            ///////Option 1. Call data - It will be the main code for our application(Check exerciesList.cs and DataAccess.cs)

            eeee = DataAccess.fill_listbox();
            foreach (exerciesList e in eeee)
            {
                LV.ItemsSource = eeee;  
                // LV.Items.Add(e);
                  // e.dd = DataAccess.Load(e.id);     
            }

       

            ///////////////////displaying picture////////////////////
            IMG = DataAccess.picture();
           // int n = 0;
            this.MediaCall();
 
        }
        public void MediaCall()
        {
            int n = 0;
            foreach (exerciesList e in IMG)
            {

                //LB.Items.Add(e);
                Image newImage = new Image();
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                var filename = e;
                src.UriSource = new Uri(@"..\resources\" + filename, UriKind.Relative);
                src.EndInit();
                newImage.Source = src;
                newImage.Height = 50;
                newImage.Width = 100;
                newImage.Stretch = Stretch.Uniform;

                newImage.HorizontalAlignment = HorizontalAlignment.Left;
                newImage.VerticalAlignment = VerticalAlignment.Top;

                StackPanel stackPnl = new StackPanel();
                stackPnl.Orientation = Orientation.Horizontal;
                stackPnl.Children.Add(newImage);  //put newImage into stack panel
                Button btn = new Button();        // Create button
                /*여기부분은 int n을 이용해서 이름을 바꾸는곳인데, db에서 id를 뽈아 온다음에 밑에 있는 버튼 이벤트에서 db구문 select from tt where id 를 이용해서 동영상을 뽑아온다
                 * 그리고 그다음엔 Videopage()를 불러와서 다음 interface로 넘어간후 그 동영상이 재생이 된다.*/
                btn.Name = "btn_" + e.id.ToString();  //Put name on each button
                n += 1;    // as many as the number of data in database

                btn.Content = stackPnl;   //Put image into button
                btn.Click += new RoutedEventHandler(doCall);  //for button event
                btn.Background = new SolidColorBrush(Color.FromArgb(255, 0, 80, 80));

                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.VerticalAlignment = VerticalAlignment.Top;
                btn.Margin = new Thickness(10);

                Label ExerciseName = new Label();
                ExerciseName.Content = e.caption;
                ExerciseName.Margin = new Thickness(10);

                wp_img.Children.Add(btn);  //Put buttons into Wrap panel
                wp_img.Children.Add(ExerciseName);
            }

        }
        //Related to button event
        private void doCall(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            string strId = null;

            if (btn != null)
            {
                strId = btn.Name.Substring((btn.Name.IndexOf('_') + 1), btn.Name.Length - (btn.Name.IndexOf('_') + 1));
              //  strId = btn.Name;
                IMG = DataAccess.Load(Int32.Parse(strId));
               
                // Play Videos
                foreach (exerciesList exList in IMG)
                {
                   // MessageBox.Show(exList.video);
                    var filename1 = exList.video;
                    mediavid.Source = new Uri(@".\resources\" + filename1, UriKind.Relative);
                    mediavid.Close();
                    mediavid.Play();
                }
            
            }
        }
   

        public void VideoPage()
        {
            MessageBox.Show("Go to Video page");
        }

                     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
      

        }
        private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            wp_img.Children.Clear();
            IMG = DataAccess.FilterMode("Easy");
            MediaCall();
            MD.Children.Clear();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            wp_img.Children.Clear();
            IMG = DataAccess.FilterMode("Challenge");
            MediaCall();
            MD.Children.Clear();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            wp_img.Children.Clear();
            IMG = DataAccess.FilterMode("Moderate");
            MediaCall();
            MD.Children.Clear();
        }
    }
}
