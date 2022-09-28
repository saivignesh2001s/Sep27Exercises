using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businessaccess
{
    public class bal_course
    {
        public int courseid
        {
            get;
            set;
        }
        public string cname
        {
            get;
            set;
        }
        public string deptid
        {
            get;
            set;
        }
        public int duration
        {
            get;
            set;
        }
    }
    public class bal_student
    {
        public int studentid
        {
            get;
            set;
        }
        public string studname
        {
            get;
            set;
        }
        public int crsid
        {
            get;
            set;
        }

    }
    public class bal_exam
    {
        public int examid
        {
            get;
            set;
        }
        public int crsid
        {
            get;
            set;
        }
        public int sid
        {
            get;
            set;
        }
        public int marks
        {
            get;
            set;
        }
    }

}
