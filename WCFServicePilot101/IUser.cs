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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IUser”。
    [ServiceContract(Namespace="")]
    public interface IUser
    {
        [OperationContract]
        [WebGet]
        // [WebInvoke]
        Person GetOnePerson();

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
    }
}
