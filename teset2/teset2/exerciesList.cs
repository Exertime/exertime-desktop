using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teset2
{
    class exerciesList
    {

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

            return img;
        }
    }
}
