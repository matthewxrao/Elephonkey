using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephonkey.Models
{
    public class Answer
    {
        public string Text { get; set; }
        public int DemocraticPoints { get; set; }
        public int RepublicanPoints { get; set; }
        public int LibertarianPoints { get; set; }
        public int GreenPoints { get; set; }
        public int OtherPoints { get; set; }
    }
}
