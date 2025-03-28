using System;
using System.Collections.Generic;
using System.Diagnostics;
using OOP1;

namespace OOP1
{
    /// <summary>
    /// Lớp generic cung cấp các phương thức quản lý đối tượng
    /// </summary>
    /// <typeparam name="T">Kiểu đối tượng quản lý</typeparam>
    public class Repository<T> where T : class, IStorable, IValidatable, new()
    {
        // Fields
        protected List<T> items;
        protected string filename;
        protected FileManager fileManager;

        // Events
        public event EventHandler<DataChangeEventArgs> DataChanged;

        // Constructors
        public Repository(string filename)
        {
            this.items = new List<T>();
            this.filename = filename;
            this.fileManager = FileManager.Instance;
            LoadData();
        }

        // Properties
        public List<T> Items
        {
            get { return items; }
        }

        // Methods
        public virtual void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "Item cannot be null.");
            }

            if (!item.IsValid())
            {
                throw new ArgumentException(item.GetValidationMessage());
            }

            items.Add(item);
            SaveData();
            OnDataChanged(new DataChangeEventArgs("add", typeof(T).Name));
        }

        public virtual void Update(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "Item cannot be null.");
            }

            if (!item.IsValid())
            {
                throw new ArgumentException(item.GetValidationMessage());
            }

            SaveData();
            OnDataChanged(new DataChangeEventArgs("update", typeof(T).Name));
        }

        public virtual void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "Item cannot be null.");
            }

            items.Remove(item);
            SaveData();
            OnDataChanged(new DataChangeEventArgs("remove", typeof(T).Name));
        }

        public virtual void Clear()
        {
            items.Clear();
            SaveData();
            OnDataChanged(new DataChangeEventArgs("clear", typeof(T).Name));
        }

        public virtual int Count()
        {
            return items.Count;
        }

        protected virtual void LoadData()
        {
            try
            {
                items = fileManager.Deserialize<List<T>>(filename);
                if (items == null)
                {
                    items = new List<T>();
                }
                Console.WriteLine($"Data loaded successfully from {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                items = new List<T>();
            }
        }

        public virtual void SaveData()
        {
            try
            {
                Console.WriteLine($"Saving {items.Count} items for {typeof(T).Name} to {filename}");
                fileManager.Serialize(items, filename);
                Console.WriteLine($"Successfully saved data for {typeof(T).Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data for {typeof(T).Name}: {ex.Message}");
                Debug.WriteLine(ex.StackTrace);
                throw;
            }
        }


        protected virtual void OnDataChanged(DataChangeEventArgs e)
        {
            DataChanged?.Invoke(this, e);
        }
    }
}
