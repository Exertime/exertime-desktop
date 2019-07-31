using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teset2
{
    class ExerciseList
    {
        public int caption { get; set; }
        public int img { get; set; }
        public int video { get; set; }

        public override string ToString()
        {
            return caption + " " + img + " " + video;
        }
    }
}
