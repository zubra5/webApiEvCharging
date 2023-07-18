using Data.Interfaces.Configuration;
using Newtonsoft.Json;

namespace Data
{
    public abstract class BaseFileRepository<T>
    {
        private readonly IFileRepositoryConfig _fileRepositoryConfig;

        public BaseFileRepository(IFileRepositoryConfig fileRepositoryConfig)
        {
            _fileRepositoryConfig = fileRepositoryConfig;
        }
        protected string GetPath()
        {
            var appDomain = AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            return Path.Combine(basePath, _fileRepositoryConfig.FolderName, _fileRepositoryConfig.FileName);
        }

        protected IEnumerable<T> ReadFile()
        {
            var pathToFile = GetPath();
            using (StreamReader r = new StreamReader(pathToFile))
            {
                string json = r.ReadToEnd();
                var result = JsonConvert.DeserializeObject<List<T>>(json);
                result ??= new List<T>();
                return result;
            }
        }

        protected void Append(T item)
        {
            var pathToFile = GetPath();

            var jsonData = File.ReadAllText(pathToFile);
            var items = JsonConvert.DeserializeObject<List<T>>(jsonData)
                                  ?? new List<T>();
            items.Add(item);
            jsonData = JsonConvert.SerializeObject(items);
            File.WriteAllText(pathToFile, jsonData);
        }

        protected void Update(T item, Predicate<T> predicate)
        {
            var pathToFile = GetPath();

            var jsonData = File.ReadAllText(pathToFile);
            var items = JsonConvert.DeserializeObject<List<T>>(jsonData)
                                  ?? new List<T>();
            var cntRemoveItems =items.RemoveAll(predicate);
            if(cntRemoveItems>0){
                items.Add(item);
            }
            jsonData = JsonConvert.SerializeObject(items);
            File.WriteAllText(pathToFile, jsonData);
        }
    }
}
