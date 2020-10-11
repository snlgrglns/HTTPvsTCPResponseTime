using FirstFloor.ModernUI.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Models
{
    class TimerViewModel : NotifyPropertyChanged, IDataErrorInfo
    {
        private string loop_no;
        private string message;

        public string LoopNo
        {
            get { return this.loop_no; }
            set
            {
                if (this.loop_no != value)
                {
                    this.loop_no = value;
                    OnPropertyChanged("LoopNo");
                }
            }
        }
        public string Message
        {
            get { return this.message; }
            set
            {
                if (this.message != value)
                {
                    this.message = value;
                    OnPropertyChanged("Message");
                }
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "LoopNo")
                {
                    return string.IsNullOrEmpty(this.loop_no) ? "Loop is required" : null;
                }
                if (columnName == "Message")
                {
                    return string.IsNullOrEmpty(this.message) ? "Message is required" : null;
                }
                return null;
            }
        }
    }
}
