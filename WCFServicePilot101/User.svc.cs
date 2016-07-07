using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using iBatisDomain;
using IBatisNet.DataMapper;

namespace WCFServicePilot101
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class User : IUser
    {
        public string ShowName(string name)
        {
            string wcfName = string.Format("WCF服务，显示姓名：{0}", name);
            return wcfName;
        }

        public IList<iPerson> GetPerson(string name)
        {
            iPersonDao dao = new iPersonDao();
            iPerson person = new iPerson();
            person = null;
            IList<iPerson> ListPerson = dao.GetPerson(person);
            return ListPerson;
        }

        public List<Person> GetPersons(int id, string name)
        {
            return new List<Person>(){new Person{ID = 1, Name = "Nux"},
                   new Person{ID = 2, Name = "Furiosa"}};
        }

        public IList<iPerson> GetPersonWithIBatis()
        {
            //iPersonDao dao = new iPersonDao();
            IList<iPerson> ListPerson = null;// dao.GetPerson();
            return ListPerson;
        }

        public IList<Device> getDevice(string equID)
        {
            Device equ = new Device();
            equ.EquID = equID;
            DeviceDao dao = new DeviceDao();
            IList<Device> ListDevice = dao.GetList(equ);
            return ListDevice;
        }
    }
}
