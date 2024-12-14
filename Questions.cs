using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamApplication
{
    internal class Questions
    {
        public int que_id {  get; set; }
        public string q_title { get; set; }
        public string q_opA { get; set; }
        public string q_opB { get; set; }
        public string q_opC { get; set; }
        public string q_opD { get; set; }
        public string q_correctOption { get; set; }

        public string q_correctData { get; set; }

        public int ad_id_fk { get; set; }
        public int ex_id_fk { get; set; }


    }
}
