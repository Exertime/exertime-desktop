using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teset2
{
    public class ProcessCount
    {
        private Int32 _TotalSecond;
        public Int32 TotalSecond
        {
            get { return _TotalSecond; }
            set { _TotalSecond = value; }
        }

        
        public ProcessCount(Int32 totalSecond)
        {
            this._TotalSecond = totalSecond;
        }

      
        public bool ProcessCountDown()
        {
            if (_TotalSecond == 0)
                return false;
            else
            {
                _TotalSecond--;
                return true;
            }
        }

       
        public string GetMinute()
        {
            return String.Format("{0:D2}", (_TotalSecond % 3600) / 60);
        }

      
        public string GetSecond()
        {
            return String.Format("{0:D2}", _TotalSecond % 60);
        }

    }
}
