using Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using System.Xml.Serialization;
using System.IO;
using log4net;
using System.Reflection;
using DataModel;

namespace DataAccessService.Services
{
    public class FileManagerService : IFileManager
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private const string pathWithEnv = @"%USERPROFILE%\AppData\Local\DataAccessService\Database.xml";

        public bool CreateXmlFileIfNotExists()
        {
            var result = false;

            var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);
            var exists = File.Exists(filePath);

            if (!exists)
            {
                var purePath = Path.GetDirectoryName(filePath);
                Directory.CreateDirectory(purePath);

                FileStream file = File.Create(filePath);
                result = true;
            }

            return result;
        }
        public bool DeleteRow(int id)
        {
            var result = false;

            if (id > 0)
            {
                try
                {
                    var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);

                    var tmpObject = new PersonsList();
                    tmpObject.PersonList = new List<PersonEntity>();

                    XmlSerializer serializer = new XmlSerializer(typeof(PersonsList));
                    FileStream file = File.Open(filePath, FileMode.Open);

                    if (file.Length > 0)
                    {
                        PersonsList deserialized = (PersonsList)serializer.Deserialize(file);
                        tmpObject.PersonList.AddRange(deserialized.PersonList);
                        var objectToDelete = tmpObject.PersonList.FirstOrDefault(s => s.Id == id);

                        if (objectToDelete != null)
                        {
                            tmpObject.PersonList.Remove(objectToDelete);
                        }
                    }

                    file.SetLength(0);
                    serializer.Serialize(file, tmpObject);
                    file.Close();

                    result = true;
                }
                catch (Exception ex)
                {
                    Logger.ErrorFormat("Error while [bool DeleteRow(int id)]. Error: {0}", ex);
                }
            }

            return result;
        }

        public bool StoreData(PersonEntity item)
        {
            var result = false;

            try
            {
                var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);

                var tmpObject = new PersonsList();
                tmpObject.PersonList = new List<PersonEntity>();

                XmlSerializer serializer = new XmlSerializer(typeof(PersonsList));
                FileStream file = File.Open(filePath, FileMode.Open);

                if (file.Length > 0)
                {
                    PersonsList deserialized = (PersonsList)serializer.Deserialize(file);
                    tmpObject.PersonList.AddRange(deserialized.PersonList);
                    item.Id = tmpObject.PersonList.Max(s => s.Id) + 1;
                    tmpObject.PersonList.Add(item);
                }
                else
                {
                    item.Id = 1;
                    tmpObject.PersonList.Add(item);
                }

                file.SetLength(0);
                serializer.Serialize(file, tmpObject);
                file.Close();

                result = true;
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("Error while [bool StoreData(PersonEntity item)]. Error: {0}", ex);
            }

            return result;
        }

        public List<PersonEntity> GetAllPersons()
        {
            var result = new List<PersonEntity>();

            try
            {
                var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);

                var tmpObject = new PersonsList();
                tmpObject.PersonList = new List<PersonEntity>();

                XmlSerializer serializer = new XmlSerializer(typeof(PersonsList));
                FileStream file = File.Open(filePath, FileMode.Open);

                if (file.Length > 0)
                {
                    PersonsList deserialized = (PersonsList)serializer.Deserialize(file);
                    tmpObject.PersonList.AddRange(deserialized.PersonList);
                    result = tmpObject.PersonList;
                }

                file.Close();
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("Error while [List<PersonEntity> GetAllPersons()]. Error: {0}", ex);
            }

            return result;
        }

        public bool UpdatePerson(PersonEntity item)
        {
            var result = false;

            try
            {
                var filePath = Environment.ExpandEnvironmentVariables(pathWithEnv);

                var tmpObject = new PersonsList();
                tmpObject.PersonList = new List<PersonEntity>();

                XmlSerializer serializer = new XmlSerializer(typeof(PersonsList));
                FileStream file = File.Open(filePath, FileMode.Open);

                if (file.Length > 0)
                {
                    PersonsList deserialized = (PersonsList)serializer.Deserialize(file);
                    tmpObject.PersonList.AddRange(deserialized.PersonList);

                    var objToDelete = tmpObject.PersonList.FirstOrDefault(s => s.Id == item.Id);
                    if (objToDelete != null)
                    {
                        tmpObject.PersonList.Remove(objToDelete);
                        tmpObject.PersonList.Add(item);
                    }
                }

                file.SetLength(0);
                serializer.Serialize(file, tmpObject);
                file.Close();

                result = true;
            }
            catch (Exception ex)
            {
                Logger.ErrorFormat("Error while [bool UpdatePerson(PersonEntity item)]. Error: {0}", ex);
            }

            return result;
        }
    }
}
