using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHub.Model.ApiDoc.Item
{
    /// <summary>
    /// api请求参数信息
    /// </summary>
    class ApiParameters
    {
        public long Id { get; set; }
        public long Item { get; set; }//item_id
        public long Create_user { get; set; }//创建人id
        public string Name { get; set; }//参数名
        public string Body { get; set; }//文本类型的数据格式当type为raw时才有
        public string Located_in { get; set; }//作用位置（值为path-param,url-param,entity-body-param）
        public string Type { get; set; }//参数类型（包含raw）
        public string Required { get; set; }//是否必填
        public string Description { get; set; }//参数描述信息
    }
}
