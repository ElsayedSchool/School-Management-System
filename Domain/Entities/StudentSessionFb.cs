using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentSessionFb
    {
        public int FbId { get; set; }
        
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        
        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
        
        public int Rate { get; set; }
        public string Comment { get; set; }


    }
}
