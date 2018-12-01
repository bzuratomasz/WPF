using DataContract.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace DataContract.ServiceContracts
{
    [ServiceContract]
    public interface IDataManager
    {
        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        List<PersonEntityDTO> GetAllPersons();

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        bool AddPerson(PersonEntityDTO person);

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        bool UpdatePerson(PersonEntityDTO person);

        [WebGet(ResponseFormat = WebMessageFormat.Xml)]
        [OperationContract]
        bool DeletePerson(int id);
    }
}
