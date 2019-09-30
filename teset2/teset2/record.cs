using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teset2
{
  
    class record
    {
        private const int p = 45;

        public int count = 0;

        public int id;


        public delegate void Delegate();
        public event Delegate pumpup;
        public void hostage(int time)
        {
            count = count + time;
            if(count >= p)
            {
                Window3 w3 = new Window3();
                w3.id = id;
                w3.Show();
                pumpup();

                count = 0;
            }
        }
    }
}
