using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using iBatisDomain;

namespace WCFServicePilot101
{
    [ServiceContract(Namespace="")]
    public interface IUser
    {
        [OperationContract]
        // [WebGet]
        [WebInvoke(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        IList<iPerson> GetPerson(string name);

        [OperationContract]
        [WebGet]
        // [WebInvoke]
        List<Person> GetPersons(int id, string name);
        
        [OperationContract]
        [WebGet]
        // [WebInvoke]
        string ShowName(string name);

        [OperationContract]
        [WebGet]
        IList<iPerson> GetPersonWithIBatis();

        [OperationContract]
        [WebGet]
        IList<Device> getDevice(string equID);
    }
}
