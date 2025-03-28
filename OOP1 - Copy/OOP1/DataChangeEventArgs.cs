using System;

namespace OOP1
{
    /// <summary>
    /// Lớp chứa thông tin cho sự kiện thay đổi dữ liệu
    /// </summary>
    public class DataChangeEventArgs : EventArgs
    {
        // Properties
        private string action;
        private string entityType;
        private object entity;

        // Constructors
        public DataChangeEventArgs(string action, string entityType)
        {
            this.action = action;
            this.entityType = entityType;
        }

        public DataChangeEventArgs(string action, string entityType, object entity)
        {
            this.action = action;
            this.entityType = entityType;
            this.entity = entity;
        }

        // Getters
        public string Action
        {
            get { return action; }
        }

        public string EntityType
        {
            get { return entityType; }
        }

        public object Entity
        {
            get { return entity; }
        }
    }
}