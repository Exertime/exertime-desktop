using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EXAMPLE
{
    class exerciesList
    {
        public int id { get; set; }
        public string type { get; set; }
        public string caption { get; set; }
        public int status{ get; set; }
        public float kj { get; set; }
        public string calculation { get; set; }
        public string img { get; set; }
        [NotMapped]
        public string video { get; set; }

        public override string ToString()
        {
            //As part of step 2.3.2 and 2.3.4 in Week 9 tutorial, have modified this to display the work times and if the employee is currently busy

            return id + " " + caption + " " + kj + " " + calculation + " " + img + " " + video;
        }

  
    }
}
