using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHub.Model.ApiDoc.Item
{
    /// <summary>
    /// api模块
    /// </summary>
    class ApiModule
    {
        public long Id { get; set; }
        public long Sub_id { get; set; }//所在api版本id
        public long Create_user { get; set; }//创建人id
        public long Up_id { get; set; }//上级模块id
        public string Module_name { get; set; }//模块名称
        public string Create_time { get; set; }//创建时间
        public string Description { get; set; }//模块描述
    }
}
