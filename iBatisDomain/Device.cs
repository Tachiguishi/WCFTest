using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iBatisDomain
{
    public class Device
    {
        /// <summary>
        /// 设备标识
        /// </summary>
        public string EquID { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string EquName { get; set; }

        /// <summary>
        /// 设备类别，图形标识
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 设备符号，图纸中编号
        /// </summary>
        public string EquLabel { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        public string EquType { get; set; }

        /// <summary>
        /// 所在柜体编号
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// 传感器所在区域
        /// </summary>
        public string EquArea{get;set;}

        /// <summary>
        /// 文档ID
        /// </summary>
        // public string DocID { get; set; }

        /// <summary>
        /// 所在图档编号
        /// </summary>
        public string DocNO { get; set; }

        /// <summary>
        /// 文档名
        /// </summary>
        public string DocName { get; set; }

        /// <summary>
        /// 保存路径
        /// </summary>
        public string DocPath { get; set; }

        /// <summary>
        /// 页数
        /// </summary>
        public int RealPage { get; set; }

        /// <summary>
        /// 所在回路编号
        /// </summary>
        public string CircuitNO { get; set; }
    }
}
