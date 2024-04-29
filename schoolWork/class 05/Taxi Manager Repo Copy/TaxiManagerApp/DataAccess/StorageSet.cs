using Models;
using Newtonsoft.Json;

namespace DataAccess
{
    public class StorageSet<T> : IStorageSet<T> where T : BaseEntity
    {
        public List<T> Items { get; set; } = new List<T>();

        public void Add(T entity)
        {
            var items = ReadItems();
            if(entity.Id != 0)
            {
                throw new Exception("For adding new item, the Id needs to be set to 0");
            }

            if (items.Any())
            {
                int max = Items.Max(x => x.Id);
                entity.Id = max + 1;
            }
            else
            {
                entity.Id = 1;
            }

            items.Add(entity);
            SaveItems(items);
        }

        public List<T> GetAll()
        {
            return Items;
        }

        public T GetById(int id)
        {
            var items = ReadItems();
            T item = items.FirstOrDefault(x => x.Id == id);

            if(item == null)
            {
                throw new KeyNotFoundException($"Entity with Id = {id} does not exit");
            }
            return item;
        }

        public void Update(T entity)
        {
            var items = ReadItems();
            T item = items.FirstOrDefault(x => x.Id == entity.Id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Entity with Id = {entity.Id} does not exit");
            }

            int index = items.IndexOf(item);

            items[index] = entity;
            SaveItems(items);
        }

        public void Delete(T entity)
        {
            Delete(entity.Id);
        }

        public void Delete(int id)
        {
            var items = ReadItems();
            T item = items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Entity with Id = {id} does not exit");
            }

            items.Remove(item);

            SaveItems(items);
        }

        private List<T> ReadItems()
        {
            string folderPath = $@"..\..\..\Data";
            string fileName = $"{typeof(T).Name}s.json";
            string filePath = $@"{folderPath}\{fileName}";
            var result = new List<T>();

            if (!Directory.Exists(folderPath))
            {
                return new List<T>();
            }

            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            try
            {
                using(var sr = new StreamReader(filePath))
                {
                    string data = sr.ReadToEnd();

                    result = JsonConvert.DeserializeObject<List<T>>(data) ?? new List<T>(); 
                    // If the left side of the condition returned null then it would assign the empty list to the variable,
                    // otherwise it would assign the result from the left side  

                    //result = JsonConvert.DeserializeObject<List<T>>(data) == null
                    //    ? new List<T>() : JsonConvert.DeserializeObject<List<T>>(data);
                }
            }
            catch(Exception ex)
            {
                return result;
            }

            return result;
        }

        private void SaveItems(List<T> items)
        {
            string folderPath = $@"..\..\..\Data";
            string fileName = $"{typeof(T).Name}s.json";
            string filePath = $@"{folderPath}\{fileName}";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            string content = JsonConvert.SerializeObject(items);

            using(var sw = new StreamWriter(filePath))
            {
                sw.WriteLine(content);
            }

        }
    }
}


