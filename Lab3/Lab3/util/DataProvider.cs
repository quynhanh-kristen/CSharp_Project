using Lab3.dto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab3.util
{
    class DataProvider
    {
        private static string filename = @"..\studentlist.txt";        
        private static int numOfField = 8;

        public DataProvider()
        {            
        }

        public static List<Student> ReadStudentList()
        {
            StreamReader sw = null;
            List<Student> studentList = new List<Student>();
            try
            {
                sw = new StreamReader(filename);
                while(!sw.EndOfStream)
                {
                    Student tmpStudent = null;
                    string[] tmpInfor = sw.ReadLine().Split(";") ; 
                    
                    if(tmpInfor.Length == numOfField)
                    {
                        //Fullname;DOB;gender;national;phone;address; Qualification; Salary
                        string id = tmpInfor[0];
                        string fullname = tmpInfor[1];
                        string dob = tmpInfor[2];
                        string gender = tmpInfor[3];
                        string national = tmpInfor[4];
                        string phone = tmpInfor[5];
                        string address = tmpInfor[6];
                        string major = tmpInfor[7];
                        tmpStudent = new Student(id,fullname, dob, gender, national, phone, address, major);
                        studentList.Add(tmpStudent);
                    }
                }

            }
            catch (Exception e)
            {                
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
            return studentList;
        }

        public static  bool WriteStudentInfor(List<Student> studentList)
        {
            StreamWriter sw = null;
            bool result = false;
            try
            {
                sw = new StreamWriter(filename);
                foreach (Student s in studentList)
                    {
                        string infor = s.GetId() + ";" + s.GetFullname() + ";" + s.GetDob() + ";" + s.GetGender() + ";" + s.GetNational() + ";" + s.GetPhone() + ";"
                        + s.GetAddress() + ";" + s.GetMajor();
                        sw.WriteLine(infor);
                    }
                             
                result = true;
            }catch(Exception e) {
                MessageBox.Show("Can not save student infor into the List");
            }
            finally
            {
                if (sw != null) 
                    sw.Close();
            }
            return result;
        }

        public void CheckFile()
        {
            MessageBox.Show(Path.GetFullPath(filename));
        }


    }
}
