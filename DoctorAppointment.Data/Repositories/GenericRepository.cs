using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Data.Models;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<T> where T : Auditable
    {
        protected readonly string Path;
        protected JsonTable<T> Table;

        protected GenericRepository(string path)
        {
            Path = path;
            Load();
        }

        private void Load()
        {
            if (!File.Exists(Path))
            {
                Table = new JsonTable<T>();
                Save();
            }
            else
            {
                Table = JsonConvert.DeserializeObject<JsonTable<T>>(File.ReadAllText(Path))
                        ?? new JsonTable<T>();
            }
        }

        protected void Save()
        {
            File.WriteAllText(
                Path,
                JsonConvert.SerializeObject(Table, Formatting.Indented));
        }

        public IEnumerable<T> GetAll() => Table.Items;

        public T? GetById(int id) =>
            Table.Items.FirstOrDefault(x => x.Id == id);

        public T Create(T item)
        {
            item.Id = ++Table.LastId;
            item.CreatedAt = DateTime.Now;

            Table.Items.Add(item);
            Save();
            return item;
        }

        public bool Delete(int id)
        {
            var obj = GetById(id);
            if (obj == null) return false;

            Table.Items.Remove(obj);
            Save();
            return true;
        }

        public T Update(int id, T source)
        {
            var index = Table.Items.FindIndex(x => x.Id == id);
            if (index == -1)
                throw new Exception($"Item {id} not found");

            source.Id = id;
            source.UpdatedAt = DateTime.Now;

            Table.Items[index] = source;
            Save();
            return source;
        }

        public abstract void ShowInfo(T obj);
    }

}
