using Infrastructure.Interfaces.Configuration;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataViewer.Configuration
{
    public class ConfigurationContainer : IConfiguration
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static ConfigurationContainer _instance;

        public static ConfigurationContainer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationContainer();
                }
                return _instance;
            }
        }

        public string Url { get; private set; }

        public ConfigurationContainer()
        {
            try
            {
                Initialize();
            }
            catch (Exception)
            {
                throw new Exception("Error while reading configuration! Please check *.config file.");
            }
        }

        private void Initialize()
        {
            Url = ConfigurationManager.AppSettings["Url"];      
        }
    }
}
