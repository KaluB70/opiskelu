using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentti_02
{
    class JobChangedEventArgs : EventArgs
    {
        //EventArgs JobChanged tapahtumalle
        public Job Job { get; set; }
    }
}
