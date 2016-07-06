using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;

namespace iBatisDomain
{
    public class iPersonDao
    {
        public IList<iPerson> GetPerson(iPerson person)
        {
            ISqlMapper mapper = Mapper.Instance();
            IList<iPerson> ListPerson = mapper.QueryForList<iPerson>("PersonSQL.query2", person);
            return ListPerson;
        }

        public void AddPerson(iPerson person)
        {
            ISqlMapper mapper = Mapper.Instance();
            mapper.Insert("Ibatis.InsertPerson", person);
            //return i;
        }
    }
}
