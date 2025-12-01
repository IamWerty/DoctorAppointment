using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Models;
using MyDoctorAppointment.Domain.Entities;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<T> where T : Auditable
    {
        protected readonly string JsonPath;
        protected readonly string XmlPath;

        protected JsonTable<T> JsonTable;
        protected XmlTable<T> XmlTable;

        protected GenericRepository(string jsonPath, string xmlPath)
        {
            JsonPath = jsonPath;
            XmlPath = xmlPath;

            LoadJson();
            LoadXml();
            SyncXmlIfEmpty();
        }

        //LOAD JSON
        private void LoadJson()
        {
            if (!File.Exists(JsonPath))
            {
                JsonTable = new JsonTable<T>();
                SaveJson();
            }
            else
            {
                JsonTable = JsonConvert.DeserializeObject<JsonTable<T>>(File.ReadAllText(JsonPath)) ?? new JsonTable<T>();
            }
        }

        //LOAD XML
        private void LoadXml()
        {
            if (!File.Exists(XmlPath) || new FileInfo(XmlPath).Length == 0)
            {
                XmlTable = new XmlTable<T>();
                SaveXml();
                return;
            }

            try
            {
                var serializer = new XmlSerializer(typeof(XmlTable<T>));
                using var reader = new StreamReader(XmlPath);
                XmlTable = (XmlTable<T>)serializer.Deserialize(reader);
            }
            catch
            {
                XmlTable = new XmlTable<T>();
                SaveXml();
            }
        }


        //SYNC
        private void SyncXmlIfEmpty()
        {
            if (XmlTable.Items.Count == 0 && JsonTable.Items.Count > 0)
            {
                XmlTable.LastId = JsonTable.LastId;
                XmlTable.Items = new List<T>(JsonTable.Items);
                SaveXml();
            }
        }

        //SAVE JSON
        protected void SaveJson()
        {
            File.WriteAllText(
                JsonPath,
                JsonConvert.SerializeObject(JsonTable, Formatting.Indented));
        }

        //SAVE XML
        protected void SaveXml()
        {
            var serializer = new XmlSerializer(typeof(XmlTable<T>));

            using var writer = new StreamWriter(XmlPath);
            serializer.Serialize(writer, XmlTable);
        }

        public IEnumerable<T> GetAll() => JsonTable.Items;

        public T? GetById(int id) =>
            JsonTable.Items.FirstOrDefault(x => x.Id == id);

        public T Create(T item)
        {
            // JSON
            item.Id = ++JsonTable.LastId;
            item.CreatedAt = DateTime.Now;
            JsonTable.Items.Add(item);

            // XML
            XmlTable.LastId = JsonTable.LastId;
            XmlTable.Items.Add(item);

            SaveJson();
            SaveXml();
            return item;
        }

        public bool Delete(int id)
        {
            var obj = GetById(id);
            if (obj == null) return false;

            // JSON
            JsonTable.Items.Remove(obj);

            // XML
            var xmlObj = XmlTable.Items.FirstOrDefault(x => x.Id == id);
            if (xmlObj != null)
                XmlTable.Items.Remove(xmlObj);

            SaveJson();
            SaveXml();
            return true;
        }

        public T Update(int id, T source)
        {
            var index = JsonTable.Items.FindIndex(x => x.Id == id);
            if (index == -1)
                throw new Exception($"Item {id} not found");

            // JSON
            source.Id = id;
            source.UpdatedAt = DateTime.Now;
            JsonTable.Items[index] = source;

            // XML
            var xmlIndex = XmlTable.Items.FindIndex(x => x.Id == id);
            if (xmlIndex != -1)
                XmlTable.Items[xmlIndex] = source;

            SaveJson();
            SaveXml();
            return source;
        }

        public abstract void ShowInfo(T obj);
    }
}
