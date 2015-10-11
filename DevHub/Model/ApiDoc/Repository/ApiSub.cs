using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHub.Model.ApiDoc.Repository
{
    class ApiSub
    {
        public long Id { get; set; }
        public long Repository_id { get; set; }//
        public long Create_user { get; set; }//创建人id
        public string Title { get; set; }//版本名称
        public string Version { get; set; }//版本号
        public string Description { get; set; }//版本描述
        public string Base_path { get; set; }//版本路径
        public string Create_time { get; set; }//创建时间
    }
}
