using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHub.Model.ApiDoc.Repository
{
    class ApiRepository
    {
        public long Id { get; set; }
        public long Create_user { get; set; }//创建人id
        public string Title { get; set; }//项目名称
        public string Host { get; set; }//主机名字
        public string Schemes { get; set; }//请求方案(http or https)
        public string Description { get; set; }//项目描述
        public string Version { get; set; }//项目版本号
        public string Create_time { get; set; }//创建时间
    }
}
