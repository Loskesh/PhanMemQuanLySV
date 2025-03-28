using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP1
{
    public class LecturerRepository : Repository<Lecturer>
    {
        public event EventHandler<DataChangeEventArgs> DataChanged;

        public LecturerRepository() : base("lecturers.dat")
        {
        }

        public Lecturer GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            foreach (Lecturer lecturer in items)
            {
                if (lecturer.Id == id)
                {
                    return lecturer;
                }
            }

            return null;
        }

        public Lecturer GetByLecturerId(string lecturerId)
        {
            if (string.IsNullOrEmpty(lecturerId))
            {
                return null;
            }

            foreach (Lecturer lecturer in items)
            {
                if (lecturer.LecturerId == lecturerId)
                {
                    return lecturer;
                }
            }

            return null;
        }

        public List<Lecturer> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return new List<Lecturer>(items);
            }

            keyword = keyword.ToLower();
            List<Lecturer> result = new List<Lecturer>();
            foreach (Lecturer lecturer in items)
            {
                if (lecturer.Id.ToLower().Contains(keyword) ||
                    lecturer.LecturerId.ToLower().Contains(keyword) ||
                    lecturer.FullName.ToLower().Contains(keyword) ||
                    lecturer.Department.ToLower().Contains(keyword) ||
                    lecturer.Position.ToLower().Contains(keyword) ||
                    lecturer.Specialization.ToLower().Contains(keyword))
                {
                    result.Add(lecturer);
                }
            }

            return result;
        }

        public List<Lecturer> GetByDepartment(string department)
        {
            if (string.IsNullOrEmpty(department))
            {
                return new List<Lecturer>();
            }

            List<Lecturer> result = new List<Lecturer>();
            foreach (Lecturer lecturer in items)
            {
                if (lecturer.Department == department)
                {
                    result.Add(lecturer);
                }
            }

            return result;
        }

        public List<Lecturer> GetByPosition(string position)
        {
            if (string.IsNullOrEmpty(position))
            {
                return new List<Lecturer>();
            }

            List<Lecturer> result = new List<Lecturer>();
            foreach (Lecturer lecturer in items)
            {
                if (lecturer.Position == position)
                {
                    result.Add(lecturer);
                }
            }

            return result;
        }

        public List<Lecturer> GetBySpecialization(string specialization)
        {
            if (string.IsNullOrEmpty(specialization))
            {
                return new List<Lecturer>();
            }

            List<Lecturer> result = new List<Lecturer>();
            foreach (Lecturer lecturer in items)
            {
                if (lecturer.Specialization == specialization)
                {
                    result.Add(lecturer);
                }
            }

            return result;
        }

        public bool Exists(string lecturerId)
        {
            return GetByLecturerId(lecturerId) != null;
        }

        protected override void OnDataChanged(DataChangeEventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }
    }
}
