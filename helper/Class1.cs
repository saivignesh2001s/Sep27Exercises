using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataaccess;
using Businessaccess;
namespace helper
{
    public class he_course
    {
        dal_course ji = null;
        public he_course()
        {
            ji=new dal_course();
        }
        public bool insertingcourse(bal_course p)
        {
           return ji.insertcourse(p);
        }
        public bool updatecourse(int no,bal_course p)
        {
            return ji.updatecourse(no,p);
        }
        public bool deletecourse(int no)
        {
            return ji.DeleteCourse(no);
        }
        public bal_course findcourse(int no)
        {
            return ji.FindCourse(no);
        }
        public List<bal_course> Show()
        {
            return ji.Showall();
        }
    }
    public class he_student
    {

        dal_student fg=null;
        public he_student()
        {
            fg=new dal_student();
        }
        public bool insertstud(bal_student po)
        {
            return fg.insertstudent(po);
        }
        public bool updatestud(int no,bal_student po)
        {
            return fg.updatestudent(no, po);
        }
        public bool deletestud(int no)
        {
            return fg.Deletestudent(no);
        }
        public bal_student findstud(int no)
        {
            return fg.FindStudent(no);
        }
        public List<bal_student> Show()
        {
            return fg.Showall();
        }

    }
    public class he_exam
    {
        dal_exam fg1 = null;
        public he_exam()
        {
            fg1 = new dal_exam();
        }
        public bool insert(bal_exam p){
            return fg1.insertexam(p);
            }
        public List<bal_exam> Show()
        {
            return fg1.Showall();
        }
    }
}
