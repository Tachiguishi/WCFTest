using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;

namespace iBatisDomain
{
    public class iPersonDao
    {
        public IList<iPerson> GetList()
        {
            ISqlMapper mapper = Mapper.Instance();
            IList<iPerson> ListPerson = mapper.QueryForList<iPerson>("Ibatis.SelectAllPerson", null);  //这个"SelectAllPerson"就是xml映射文件的Id
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
