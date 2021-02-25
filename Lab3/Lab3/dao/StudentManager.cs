using Lab3.dto;
using Lab3.util;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.dao
{
    class StudentManager
    {
        List<Student> studentList = null;
        
        public List<Student> GetStudentList()
        {
            return studentList;
        }
        public StudentManager()
        {
            studentList = new List<Student>();
            
        }

        public List<Student> LoadData()
        {            
            studentList = DataProvider.ReadStudentList();
            return studentList;
        }

        public bool AddNewStudents(List<Student> tmpList)
        {
            if (tmpList == null)
                return false;
            if(studentList.Count == 0)
            {
                LoadData();
            }
            
            foreach(Student s in tmpList)
            {
                studentList.Add(s);
            }

            return DataProvider.WriteStudentInfor(studentList);
        }

        public bool DeleteStudent(string id)
        {
            if (FindStudent(id))
            {
                foreach (Student s in studentList)
                {
                    if (s.GetId().Equals(id))
                    {
                        studentList.Remove(s);
                        return DataProvider.WriteStudentInfor(studentList);
                    }
                }
            }
            return false;
        }

        public bool FindStudent(string id)
        {
            if(studentList != null)
            {
                foreach(Student s in studentList)
                {
                    if (s.GetId().Equals(id))
                        return true;
                }
            }
            return false;
        }

        public bool UpdateStudentInfor(string id, List<Student> list)
        {
            if (list == null)
                return false;
            if (DeleteStudent(id))
            {
                return AddNewStudents(list);
            }
            return false; 
        }
         
    }
}
