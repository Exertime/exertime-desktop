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
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Data;

namespace teset2
{

    /// <summary>
    /// Interaction logic for UserAll.xaml
    /// </summary>
    public partial class UserAll : UserControl
    {



        public delegate void Delegate();
        public event Delegate exercise1,exercise2;

        private List<exerciesList> IMG;
      

        public UserAll()
        {
            InitializeComponent();

            IMG = DataAccess.picture();

            MediaCall();
        }
        public void MediaCall()
        {


            int n = 0;
            foreach (exerciesList e in IMG)
            {


                Image newImage = new Image();
                BitmapImage src = new BitmapImage();
                src.BeginInit();
                var filename = e;
                src.UriSource = new Uri(@"..\resources\" + filename, UriKind.Relative);
                src.EndInit();
                newImage.Source = src;
                newImage.Height = 150;
                newImage.Width = 250;
                newImage.Stretch = Stretch.Fill;

                newImage.HorizontalAlignment = HorizontalAlignment.Left;
                newImage.VerticalAlignment = VerticalAlignment.Top;

                StackPanel stackPnl = new StackPanel();
                stackPnl.Orientation = Orientation.Horizontal;
                stackPnl.Children.Add(newImage);  //put newImage into stack panel
                Button btn = new Button();        // Create button
                                                  /*여기부분은 int n을 이용해서 이름을 바꾸는곳인데, db에서 id를 뽈아 온다음에 밑에 있는 버튼 이벤트에서 db구문 select from tt where id 를 이용해서 동영상을 뽑아온다
                                                   * 그리고 그다음엔 Videopage()를 불러와서 다음 interface로 넘어간후 그 동영상이 재생이 된다.*/
                btn.Name = "btn_" + e.id.ToString();  //Put name on each button
                //btn.Uid = e.caption;
                n += 1;    // as many as the number of data in database




                btn.Content = stackPnl;   //Put image into button

                btn.Click += new RoutedEventHandler(doCall);  //for button event

                //btn.Background = new SolidColorBrush(Color.FromArgb(255, 0, 80, 80)); //original
                //btn.Background = new SolidColorBrush(Color.FromRgb(0, 154, 228)); //blue
                btn.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255)); //white


                btn.HorizontalAlignment = HorizontalAlignment.Left;
                btn.VerticalAlignment = VerticalAlignment.Top;
                btn.Margin = new Thickness(10);
                btn.Height = 150;
                btn.Width = 250;
                wp_img.Children.Add(btn);  //Put buttons into Wrap panel

            }
        }





  
        public string id;
        public string type;
        private void doCall(object sender, RoutedEventArgs e)
        {

            Button btn = (sender as Button);
            string strId = null;

            if (btn != null)
            {
                strId = btn.Name.Substring((btn.Name.IndexOf('_') + 1), btn.Name.Length - (btn.Name.IndexOf('_') + 1));
                //  strId = btn.Name;
                //IMG = DataAccess.Load(Int32.Parse(strId));
                id = strId;
                MessageBox.Show(id);

                List<exerciesList> CAP;
            
                    CAP = DataAccess.Load(Int32.Parse(id));
                    foreach (exerciesList exList in CAP)
                    {
                        var exercise = exList.calculation;
                    if(exercise == "Timed")
                    {
                      
                        exercise1();

                    }
                    else
                    {
                        
                        exercise2();
                    }
                    type = exercise;
                }

              
       
                

            }

        }
        public void easy()
        {
            IMG = DataAccess.FilterMode("Easy");
            MediaCall();

        }

        public void moderate()
        {
            IMG = DataAccess.FilterMode("Moderate");
            MediaCall();

        }

        public void challenge()
        {
            IMG = DataAccess.FilterMode("Challenge");
            MediaCall();

        }

        public void all()
        {
            IMG = DataAccess.picture();
            MediaCall();

        }

    }
}

