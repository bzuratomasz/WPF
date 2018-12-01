using DataViewer.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using DataViewer.Configuration;
using System.ServiceModel;
using DataContract.ServiceContracts;
using AutoMapper;
using DataContract.DataContracts;

namespace DataViewer.Services
{
    public class ServiceModel : IServiceModel
    {

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly BasicHttpBinding _myBinding = new BasicHttpBinding();
        private readonly EndpointAddress _myEndpoint;
        private readonly ChannelFactory<IDataManager> myChannelFactory;
        private IDataManager _dataManager = null;

        public ServiceModel()
        {
            var endPoint = ConfigurationContainer.Instance.Url;

            if (endPoint != null)
            {
                _myEndpoint = new EndpointAddress(ConfigurationContainer.Instance.Url);
                myChannelFactory = new ChannelFactory<IDataManager>(_myBinding, _myEndpoint);
            }
        }

        public List<PersonEntity> GetAllPersons()
        {
            var result = new List<PersonEntity>();
            try
            {
                if (myChannelFactory != null)
                {
                    _dataManager = myChannelFactory.CreateChannel();
                    result = Mapper.Map<List<PersonEntity>>(_dataManager.GetAllPersons());
                    ((ICommunicationObject)_dataManager).Close();
                }
            }
            catch
            {
                if (_dataManager != null)
                {
                    ((ICommunicationObject)_dataManager).Abort();
                }
            }

            return result;
        }

        public bool AddPerson(PersonEntity person)
        {
            var result = false;
            try
            {
                if (myChannelFactory != null)
                {
                    _dataManager = myChannelFactory.CreateChannel();
                    result = _dataManager.AddPerson(Mapper.Map<PersonEntityDTO>(person));
                    ((ICommunicationObject)_dataManager).Close();
                }
            }
            catch
            {
                if (_dataManager != null)
                {
                    ((ICommunicationObject)_dataManager).Abort();
                }
            }

            return result;
        }

        public bool UpdatePerson(PersonEntity person)
        {
            var result = false;
            try
            {
                if (myChannelFactory != null)
                {
                    _dataManager = myChannelFactory.CreateChannel();
                    result = _dataManager.UpdatePerson(Mapper.Map<PersonEntityDTO>(person));
                    ((ICommunicationObject)_dataManager).Close();
                }
            }
            catch
            {
                if (_dataManager != null)
                {
                    ((ICommunicationObject)_dataManager).Abort();
                }
            }

            return result;
        }

        public bool DeletePerson(int id)
        {
            var result = false;
            try
            {
                if (myChannelFactory != null)
                {
                    _dataManager = myChannelFactory.CreateChannel();
                    result = _dataManager.DeletePerson(id);
                    ((ICommunicationObject)_dataManager).Close();
                }
            }
            catch
            {
                if (_dataManager != null)
                {
                    ((ICommunicationObject)_dataManager).Abort();
                }
            }

            return result;
        }
    }
}
