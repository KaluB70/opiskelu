using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentti_02
{
    class Mediator
    {
        //Mediaattori (rakenne)
        static private Mediator instance = new Mediator();
        static public Mediator Instance => instance;

        private Mediator()
        {
        }

        //Tapahtuma
        public event EventHandler<JobChangedEventArgs> JobChanged;

        //Metodi, jossa tarkistetaan JobChanged tapahtuman arvoa ja sen olemassaoloa
        //Jos sisältää arvon -> suoritetaan JobChanged:n mahdolliset tapahtumakäsittelijät parametrien mukaan
        public void OnJobChanged (object sender, Job job)
        {
            var jobChangeDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            jobChangeDelegate?.Invoke(sender, new JobChangedEventArgs { Job = job });

        }
    }
}
