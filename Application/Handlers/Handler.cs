using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WorkTask.AppServices.Handlers
{
    public abstract class Handler<T>
    {
        protected string ReadFile(string path) 
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}");

            return File.ReadAllText(path);
        }

        public abstract Task ProcessFileAsync(string filePath);
        protected abstract void ValidateData(ICollection<T> items);
        
    }
}
