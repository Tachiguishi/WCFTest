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
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“User”
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class User : IUser
    {
        public string ShowName(string name)
        {
            string wcfName = string.Format("WCF服务，显示姓名：{0}", name);
            return wcfName;
        }

        public Person GetOnePerson()
        {
            return new Person {ID = 1, Name = "goDie"};
        }

        public List<Person> GetPersons(int id, string name)
        {
            return new List<Person>(){new Person{ID = 1, Name = "Nux"},
                   new Person{ID = 2, Name = "Furiosa"}};
        }

        public IList<iPerson> GetPersonWithIBatis()
        {
            iPersonDao dao = new iPersonDao();
            IList<iPerson> ListPerson = dao.GetList();
            return ListPerson;
        }
    }
}
