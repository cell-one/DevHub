using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHub.Model.ApiDoc.Item
{
    /// <summary>
    /// api接口
    /// </summary>
    class ApiItem
    {
        public long Id { get; set; }
        public long SubId { get; set; }//所在api版本id
        public long Create_user { get; set; }//创建人id
        public long Module_id { get; set; }//模块id
        public string Summary { get; set; }//api描述总结
        public string Path { get; set; }//资源路径
        public string Type { get; set; }//访问类型(get,post,put,delete)
        public string Content_type { get; set; }//请求内容类型
        public string Description { get; set; }//api描述
        public string Tags { get; set; }//api标记
        public string CreateTime { get; set; }//创建时间
    }
}
