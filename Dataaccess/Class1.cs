using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businessaccess;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace Dataaccess
{
    public class dal_course
    {
        DataSet ds = null;
        SqlDataAdapter adapt = null;
        SqlConnection cn = null;
        public dal_course()
        {
            ds = new DataSet();
            cn = new SqlConnection(ConfigurationManager.ConnectionStrings["iims1"].ConnectionString);
        }
        private DataTable connect()
        {
            adapt = new SqlDataAdapter("Select * from COURSE", cn);
            adapt.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            adapt.Fill(ds, "course");
            DataTable dt = ds.Tables["course"];
            return dt;
        }
        public bool insertcourse(bal_course p)
        {
            DataTable dt = connect();
            DataRow dh = ds.Tables["course"].NewRow();
            dh["COURSEID"] = p.courseid;
            dh["COURSENAME"] = p.cname;
            dh["DEPTID"] = p.deptid;
            dh["DURATION"] = p.duration;
            ds.Tables["course"].Rows.Add(dh);// disconnected mode- inthe dataset

            SqlCommandBuilder bldr = new SqlCommandBuilder(adapt);
            int i = adapt.Update(ds.Tables["course"]);//record added to the (original)database table
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            return status;


        }
        public bool updatecourse(int no, bal_course p)
        {
            DataTable dt = connect();
            DataRow dh = ds.Tables["course"].Rows.Find(no);
            dh["COURSEID"] = p.courseid;
            dh["COURSENAME"] = p.cname;
            dh["DEPTID"] = p.deptid;
            dh["DURATION"] = p.duration;


            SqlCommandBuilder bldr = new SqlCommandBuilder(adapt);
            int i = adapt.Update(ds.Tables["course"]);//record added to the (original)database table
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            return status;


        }
        public bool DeleteCourse(int courseid)
        {

            DataTable dt_empdata = connect();
            DataRow drow = ds.Tables["course"].Rows.Find(courseid);
            drow.Delete();

            SqlCommandBuilder bldr = new SqlCommandBuilder(adapt);
            int i = adapt.Update(ds.Tables["course"]);
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            return status;
        }
        public bal_course FindCourse(int courseid)
        {

            DataTable dt_empdata = connect();
            DataRow drow = ds.Tables["course"].Rows.Find(courseid);
            bal_course p = new bal_course();
            p.courseid = Convert.ToInt32(drow["courseid"]);
            p.cname = drow[1].ToString();
            p.deptid = drow[2].ToString();
            p.duration = Convert.ToInt32(drow[3]);




            return p;
        }
        public List<bal_course> Showall()
        {
            List<bal_course> pll = new List<bal_course>();
            DataTable dt_empdata = connect();
            for (int i = 0; i < ds.Tables["course"].Rows.Count; i++)
            {
                DataRow dh = dt_empdata.Rows[i];
                bal_course pll2 = new bal_course();
                pll2.courseid = Convert.ToInt32(dh[0]);
                pll2.cname = dh[1].ToString();
                pll2.deptid = dh[2].ToString();
                pll2.duration = Convert.ToInt32(dh[3]);
                pll.Add(pll2);


            }
            return pll;
        }
    }
    public class dal_student
    {
        DataSet ds = null;
        SqlDataAdapter da1 = null;
        SqlConnection cn1 = null;
        public dal_student()
        {
            ds = new DataSet();
            cn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["iims1"].ConnectionString);

        }
        private DataTable connect1()
        {
            da1 = new SqlDataAdapter("Select * from student", cn1);
            da1.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da1.Fill(ds, "student");
            DataTable dt = ds.Tables["student"];
            return dt;
        }
        public bool insertstudent(bal_student s)
        {
            DataTable dt = connect1();
            DataRow dr = ds.Tables["student"].NewRow();
            dr["stuid"] = s.studentid;
            dr["studname"] = s.studname;
            dr["crsid"] = s.crsid;
            ds.Tables["student"].Rows.Add(dr);
            SqlCommandBuilder bldr = new SqlCommandBuilder(da1);
            int i = da1.Update(ds.Tables["student"]);
            bool status = false;
            if (i == 1)
            {
                status = true;
            }
            return status;
        }
        public bool updatestudent(int no, bal_student pk)
        {
            DataTable dt = connect1();
            DataRow dr = ds.Tables["student"].Rows.Find(no);
            dr["stuid"] = pk.studentid;
            dr["studname"] = pk.studname;
            dr["crsid"] = pk.crsid;
            SqlCommandBuilder bldr = new SqlCommandBuilder(da1);
            int s = da1.Update(ds.Tables["student"]);
            bool status = false;
            if (s == 1)
            {
                status = true;
            }
            return true;
        }
        public bool Deletestudent(int no)
        {
            DataTable dt = connect1();
            DataRow dr = ds.Tables["student"].Rows.Find(no);
            dr.Delete();
            SqlCommandBuilder bldr = new SqlCommandBuilder(da1);
            int s = da1.Update(ds.Tables["student"]);
            bool status = false;
            if (s == 1)
            {
                status = true;
            }
            return true;

        }
        public bal_student FindStudent(int no)
        {
            DataTable dt = connect1();
            DataRow dr = ds.Tables["student"].Rows.Find(no);
            bal_student po = new bal_student();
            po.studentid = Convert.ToInt32(dr[0]);
            po.studname = dr[1].ToString();
            po.crsid = Convert.ToInt32(dr[2]);
            return po;
        }
        public List<bal_student> Showall()
        {
            DataTable dt = connect1();
            List<bal_student> studlist = new List<bal_student>();
            for (int i = 0; i < ds.Tables["student"].Rows.Count; i++)
            {
                DataRow dl = ds.Tables["student"].Rows[i];
                bal_student stud = new bal_student();
                stud.studentid = Convert.ToInt32(dl[0]);
                stud.studname = dl[1].ToString();
                stud.crsid = Convert.ToInt32(dl[2]);
                studlist.Add(stud);

            }
            return studlist;
        }
    }
    public class dal_exam{
        DataSet ds = null;
        SqlConnection conn = null;
        SqlDataAdapter da2 = null;
        public dal_exam()
        {
            ds = new DataSet();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["iims1"].ConnectionString);

        }
        private DataTable connect2()
        {
            da2 = new SqlDataAdapter("Select * from exam", conn);
            da2.Fill(ds, "exams");
            DataTable dt = ds.Tables["exams"];
            return dt;
        }
        public bool insertexam(bal_exam p)
        {
            DataTable dt = connect2();
            DataRow dr = ds.Tables["exams"].NewRow();
            dr["examid"] = p.examid;
            dr["studid"] = p.sid;
            dr["crsid"] = p.crsid;
            dr["marks"] = p.marks;
            ds.Tables["exams"].Rows.Add(dr);
            SqlCommandBuilder bldr= new SqlCommandBuilder(da2);
            int kl = da2.Update(ds.Tables["exams"]);
            if (kl == 1)
            {
                return true;

            }
            else
            {

                return false;
            }

        }
        public List<bal_exam> Showall()
        {
            DataTable dt = connect2();
            List<bal_exam> list = new List<bal_exam>();
            for (int i = 0; i < ds.Tables["exams"].Rows.Count; i++)
            {
               
                bal_exam kl = new bal_exam();
                DataRow dth = ds.Tables["exams"].Rows[i];
                kl.examid = Convert.ToInt32(dth[0]);
                kl.sid = Convert.ToInt32(dth[2]);
                kl.crsid = Convert.ToInt32(dth[1]);
                kl.marks= Convert.ToInt32(dth[3]);
                list.Add(kl);
            }
            return list;
        }
        }
}
