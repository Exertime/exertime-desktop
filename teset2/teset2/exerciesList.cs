﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teset2
{
    class exerciesList
    {
        //public int caption { get; set; }
        //public int img { get; set; }
        //public int video { get; set; }

        //public override string ToString()
        //{
        //    return caption + " " + img + " " + video;
        //}
        public int id { get; set; }
        public string type { get; set; }
        public string caption { get; set; }
        public int status { get; set; }
        public float kj { get; set; }
        public string calculation { get; set; }
        public string img { get; set; }
        
        public string video { get; set; }

        public override string ToString()
        {
            //As part of step 2.3.2 and 2.3.4 in Week 9 tutorial, have modified this to display the work times and if the employee is currently busy

            return img;
        }
    }
}