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

namespace teset2
{
    /// <summary>
    /// Interaction logic for UserStatistics.xaml
    /// </summary>
    public partial class UserStatistics : UserControl
    {

        public delegate void ExitDelegate();
        public event ExitDelegate exitEvent;


        //private void AppearButton()
        //{
        //    exitEvent();
        //}

        public UserStatistics()
        {
            InitializeComponent();

        }

        private void Exit(object sender, RoutedEventArgs e)
        {

            exitEvent();


        }

        //private void exit()
        //{

        //    exitEvent();


        //}

    }
}