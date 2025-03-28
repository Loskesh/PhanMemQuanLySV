using System;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp quản lý khóa học
    /// </summary>
    public class CourseRepository : Repository<Course>
    {
        // Constructors
        public CourseRepository() : base("courses.dat")
        {
        }

        // Methods
        public Course GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            foreach (Course course in items)
            {
                if (course.Id == id)
                {
                    return course;
                }
            }

            return null;
        }

        public Course GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return null;
            }

            foreach (Course course in items)
            {
                if (course.Code == code)
                {
                    return course;
                }
            }

            return null;
        }

        public List<Course> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return new List<Course>();
            }

            List<Course> result = new List<Course>();
            foreach (Course course in items)
            {
                if (course.Name.Contains(name))
                {
                    result.Add(course);
                }
            }

            return result;
        }

        public List<Course> GetByDepartment(Department department)
        {
            if (department == null)
            {
                return new List<Course>();
            }

            List<Course> result = new List<Course>();
            foreach (Course course in items)
            {
                if (course.Department != null && course.Department.Id == department.Id)
                {
                    result.Add(course);
                }
            }

            return result;
        }

        public List<Course> GetByLecturer(Lecturer lecturer)
        {
            if (lecturer == null)
            {
                return new List<Course>();
            }

            List<Course> result = new List<Course>();
            foreach (Course course in items)
            {
                foreach (Lecturer l in course.Lecturers)
                {
                    if (l.Id == lecturer.Id)
                    {
                        result.Add(course);
                        break;
                    }
                }
            }

            return result;
        }

        public List<Course> GetByCredits(int credits)
        {
            List<Course> result = new List<Course>();
            foreach (Course course in items)
            {
                if (course.Credits == credits)
                {
                    result.Add(course);
                }
            }

            return result;
        }

        public List<Course> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return new List<Course>(items);
            }

            keyword = keyword.ToLower();
            List<Course> result = new List<Course>();
            foreach (Course course in items)
            {
                if (course.Id.ToLower().Contains(keyword) ||
                    course.Name.ToLower().Contains(keyword) ||
                    course.Code.ToLower().Contains(keyword) ||
                    course.Description.ToLower().Contains(keyword))
                {
                    result.Add(course);
                }
            }

            return result;
        }

        public bool Exists(string code)
        {
            return GetByCode(code) != null;
        }
    }
}