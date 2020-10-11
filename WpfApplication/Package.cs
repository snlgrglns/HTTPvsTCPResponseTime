
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication
{
    class Package
    {
        public string Message { get; set; }

        public Package()
        {
            Message = "";
        }

        public Package(string msg)
        {
            Message = msg;
        }
    }
}
