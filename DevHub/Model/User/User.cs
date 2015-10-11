using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevHub.Model.User
{
    /// <summary>
    /// 用户
    /// </summary>
    class User
    {
        public long Id { set; get; }
        public string Username { get; set; }//登录名
        public string Email { get; set; }//邮箱
        public string Mobile { get; set; }//手机
        public string Avatar_url { get; set; }//头像
        public string Full_name { get; set; }//全名


    }
}
