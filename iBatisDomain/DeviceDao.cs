using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using System.Collections;

namespace iBatisDomain
{
    public class DeviceDao
    {
        public IList<Device> GetList(Device equ)
        {
            ISqlMapper mapper = Mapper.Instance();
            Hashtable hash = new Hashtable();
            hash.Add("EquID", equ.EquID);
            IList<Device> ListDevice = mapper.QueryForList<Device>("iDevice.query", hash);  //这个"SelectAllPerson"就是xml映射文件的Id
            return ListDevice;
        }
    }
}
