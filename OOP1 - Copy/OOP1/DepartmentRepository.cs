using System;
using System.Collections.Generic;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp quản lý khoa/ngành học
    /// </summary>
    public class DepartmentRepository : Repository<Department>
    {
        // Constructors
        public DepartmentRepository() : base("departments.dat")
        {
        }

        // Methods
        public Department GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            foreach (Department department in items)
            {
                if (department.Id == id)
                {
                    return department;
                }
            }

            return null;
        }

        public Department GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return null;
            }

            foreach (Department department in items)
            {
                if (department.Name == name)
                {
                    return department;
                }
            }

            return null;
        }

        public Department GetByShortName(string shortName)
        {
            if (string.IsNullOrEmpty(shortName))
            {
                return null;
            }

            foreach (Department department in items)
            {
                if (department.ShortName == shortName)
                {
                    return department;
                }
            }

            return null;
        }

        public List<Department> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return new List<Department>(items);
            }

            keyword = keyword.ToLower();
            List<Department> result = new List<Department>();
            foreach (Department department in items)
            {
                if (department.Id.ToLower().Contains(keyword) ||
                    department.Name.ToLower().Contains(keyword) ||
                    department.ShortName.ToLower().Contains(keyword) ||
                    department.Description.ToLower().Contains(keyword) ||
                    department.Location.ToLower().Contains(keyword))
                {
                    result.Add(department);
                }
            }

            return result;
        }

        public bool Exists(string id)
        {
            return GetById(id) != null;
        }
    }
}