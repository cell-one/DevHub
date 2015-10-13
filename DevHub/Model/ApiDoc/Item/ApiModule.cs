using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<ApiItem> ApiItems { get; set; } //api子项集合


        public ObservableCollection<ApiModule> getApiModule(int size)
        {
            ObservableCollection<ApiModule> apiModules = new ObservableCollection<ApiModule>();

            for (int i = 0; i < size; i++)
            {
                ApiModule apiModule = new ApiModule{ Module_name = "aaa" , Create_time="2015-05-9" , Description = "asdasdasdasdasd"};

                ObservableCollection<ApiItem> apiItems = new ObservableCollection<ApiItem>();
                ApiItem apiItem = new ApiItem { Summary = "asdasd" , CreateTime = "2013-5-5" , Path = "/users"};

                apiItems.Add(apiItem);
                apiItems.Add(apiItem);
                apiItems.Add(apiItem);
                apiItems.Add(apiItem);
                apiItems.Add(apiItem);

                apiModule.ApiItems = apiItems;
                apiModules.Add(apiModule);
            }

            return apiModules;
        }
    }
}
