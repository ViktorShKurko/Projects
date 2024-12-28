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

        /// <summary>
        /// Процесс загрузки данных в базу.
        /// </summary>
        /// <param name="filePath">Путь к файлу с данными</param>
        /// <returns></returns>
        public abstract Task ProcessFileAsync(string filePath);


        /// <summary>
        /// Валидация полученных данных.
        /// </summary>
        /// <param name="items"></param>
        protected abstract void ValidateData(ICollection<T> items);
        
    }
}
