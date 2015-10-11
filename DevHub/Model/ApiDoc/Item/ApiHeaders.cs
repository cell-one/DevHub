using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHub.Model.ApiDoc.Item
{
    /// <summary>
    /// api响应头部信息
    /// </summary>
    class ApiHeaders
    {
        public long Id { get; set; }
        public long Item { get; set; }//item_id
        public long Create_user { get; set; }//创建人id
        public string Header { get; set; }//请求头
        public string Value { get; set; }//请求头值
        public string Create_time { get; set; }//创建时间
    }
}
