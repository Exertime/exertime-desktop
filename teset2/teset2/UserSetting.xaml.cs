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

namespace teset2
{
    /// <summary>
    /// Interaction logic for UserSetting.xaml
    /// </summary>
    public partial class UserSetting : UserControl
    {
        List<userPreferenceList> box = new List<userPreferenceList>();

        public UserSetting()
        {
            InitializeComponent();
            
            boxShow();
        }

        private void boxShow()
        {
            box = DataAccess.setting();
            foreach (userPreferenceList u in box)
            {
                username.Text = u.username;
                givenname.Text = u.givenname;
                surname.Text = u.surname;
                preferredname.Text = u.preferredname;
                email.Text = u.email;
                dob.Text = u.DOB;
                gender.Text = u.gender;
                jobtitle.Text = u.jobtitle;
                caloriegoal.Text = u.caloriegoal.ToString();

            }
        }

        private void save_click(object sender, RoutedEventArgs e)
        {
            DataAccess.upDate(username.Text, givenname.Text, surname.Text, preferredname.Text, email.Text, dob.Text, gender.Text, jobtitle.Text, Int32.Parse(caloriegoal.Text));
            boxShow();
        }
    }
}
