using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessaccess;
using helper;
using System.Configuration;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Sep27Exercises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Course 2.Student 3.examcard");
            int m = Convert.ToInt32(Console.ReadLine());
            he_course pi = new he_course();
            he_student plo=new he_student();
            he_exam ploo = new he_exam();
            switch (m) {
                
                case 1:
                    Console.WriteLine("1.Insert 2.Update 3.Delete 4.Find 5.Showall");
                    int k = Convert.ToInt32(Console.ReadLine());
                    switch (k) {
                        case 1:
            bal_course po = new bal_course();
                    Console.WriteLine("Enter course id");
                    po.courseid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter course name");
                    po.cname = Console.ReadLine();
                    Console.WriteLine("Enter dept id");
                    po.deptid = Console.ReadLine();
                    Console.WriteLine("Enter duration");
                    po.duration = Convert.ToInt32(Console.ReadLine());
                  
                    bool s = pi.insertingcourse(po);
                    if (s)
                    {
                        Console.WriteLine("Inserted successfully");

                    }
                    else
                    {
                        Console.WriteLine("Not done");
                    }
                    Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter the course no you want to update");
                            int ki=Convert.ToInt32(Console.ReadLine());
                            bal_course poi = new bal_course();
                            Console.WriteLine("Enter new course id");
                            poi.courseid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter course name");
                            poi.cname = Console.ReadLine();
                            Console.WriteLine("Enter dept id");
                            poi.deptid = Console.ReadLine();
                            Console.WriteLine("Enter duration");
                            poi.duration = Convert.ToInt32(Console.ReadLine());
                            bool si = pi.updatecourse(ki,poi);
                            if (si)
                            {
                                Console.WriteLine("Updated successfully");

                            }
                            else
                            {
                                Console.WriteLine("Not done");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter course no you want to delete");
                            int moi = Convert.ToInt32(Console.ReadLine());
                            bool sii = pi.deletecourse(moi);
                            if (sii)
                            {
                                Console.WriteLine("deleted successfully");

                            }
                            else
                            {
                                Console.WriteLine("Not done");
                            }
                            break;
                        case 4:
                            bal_course pl = new bal_course();
                            Console.WriteLine("Enter course no you want to find");
                            int moii = Convert.ToInt32(Console.ReadLine());
                            pl = pi.findcourse(moii);
                            if (pl!=null) {
                                Console.WriteLine(pl.courseid + " " + pl.cname + " " + pl.deptid + " " + pl.duration); 
                            }
                            else
                            {
                                Console.WriteLine("not found");
                            }
                            break;
                        case 5:
                            List<bal_course> ps=new List<bal_course>();
                            ps = pi.Show();
                            foreach(var item in ps)
                            {
                                Console.WriteLine(item.courseid + " " + item.cname + " " + item.deptid + " " + item.duration);
                            }
                            break;


            }
            break;
                case 2:
                    Console.WriteLine("1.Add 2.Update 3.Delete 4.Find 5.ShowAll");
                    int hj = Convert.ToInt32(Console.ReadLine());
                    switch (hj)
                    {
                        case 1:
                            bal_student pu = new bal_student();
                            Console.WriteLine("Enter the student id");
                            pu.studentid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the student name");
                            pu.studname = Console.ReadLine();
                            Console.WriteLine("Enter the course id");
                            pu.crsid = Convert.ToInt32(Console.ReadLine());
                            bool ko = plo.insertstud(pu);
                            if (ko)
                            {
                                Console.WriteLine("Inserted successfully");
                            }
                            else
                            {
                                Console.WriteLine("Not done");
                            }

                            break;
                        case 2:
                            Console.WriteLine("Enter the student number you want to update");
                            int jo = Convert.ToInt32(Console.ReadLine());
                            bal_student pu1 = new bal_student();
                            Console.WriteLine("Enter the student id");
                            pu1.studentid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the student name");
                            pu1.studname = Console.ReadLine();
                            Console.WriteLine("Enter the course id");
                            pu1.crsid = Convert.ToInt32(Console.ReadLine());
                            bool ko1 = plo.updatestud(jo,pu1);
                            if (ko1)
                            {
                                Console.WriteLine("Updated successfully");
                            }
                            else
                            {
                                Console.WriteLine("Not done");
                            }

                            break;
                        case 3:
                            Console.WriteLine("Enter the student number you want to delete");
                            int pli = Convert.ToInt32(Console.ReadLine());
                            bool kit = plo.deletestud(pli);
                            if (kit)
                            {
                                Console.WriteLine("Deleted successfully");
                            }
                            else
                            {
                                Console.WriteLine("Not done");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Enter the student number you want to delete");
                            int pli1 = Convert.ToInt32(Console.ReadLine());
                            bal_student pk = new bal_student();
                            pk = plo.findstud(pli1);
                            if (pk != null)
                            {
                                Console.WriteLine(pk.studentid + " " + pk.studname + " " + pk.crsid);
                            }
                            else
                            {
                                Console.WriteLine("Not Done");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Enter student list");
                            List<bal_student> hi = new List<bal_student>();
                            hi = plo.Show();
                            foreach(var item in hi)
                            {
                                Console.WriteLine(item.studentid + " " + item.studname + " " + item.crsid);
                            }
                            break;

                    }
                    break;
                case 3:
                    Console.WriteLine("1.Add 2.ShowAll");
                    int jk=Convert.ToInt32(Console.ReadLine());
                    if (jk == 1)
                    {
                        bal_exam poq = new bal_exam();
                        Console.WriteLine("Enter exam id");
                        poq.examid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter stud id");
                        poq.sid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter course id");
                        poq.crsid = Convert.ToInt32(Console.ReadLine());
                        if (poq.crsid == 1)
                        {
                            poq.marks = consolidatechemistry();
                        }
                        else if (poq.crsid == 2)
                        {
                            poq.marks = consolidatephysics();
                        }
                        bool s2 = ploo.insert(poq);
                        if (s2)
                        {
                            Console.WriteLine("Inserted Successfully");
                        }
                        else
                        {
                            Console.WriteLine("Not done");
                        }
                    }
                    else if (jk == 2)
                    {
                        List<bal_exam> l = new List<bal_exam>();
                        l = ploo.Show();
                        foreach(var item in l)
                        {
                            Console.WriteLine(item.examid + " " + item.sid + " " + item.crsid + " " + item.marks);
                        }

                    }
                    break;
        }
            Console.ReadLine();
        }
        public static int consolidatechemistry()
        {
            int marks = 0;
            Console.WriteLine("What is symbol of gold");
            string mk = Console.ReadLine();
            if (mk == "Au")
            {
                marks += 50;
            }
            Console.WriteLine("What is symbol of Silver");
            string km = Console.ReadLine();
            if (km == "Ag")
            {
                marks += 50;
            }
            return marks;

        }
        public static int consolidatephysics()
        {
            int marks = 0;
            Console.WriteLine("What is SIunit of mass");
            string mk = Console.ReadLine();
            if (mk == "kg")
            {
                marks += 50;
            }
            Console.WriteLine("What is SIunit of Force");
            string km = Console.ReadLine();
            if (km == "N" || km=="newton")
            {
                marks += 50;
            }
            return marks;

        }
    }
}
