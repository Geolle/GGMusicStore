﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Core.Data;
using System.Data.Entity;

namespace GGMusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ////模型改变时创建新的数据库
            //System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<MusicStoreEntities>());
            //导入样本数据
            //System.Data.Entity.Database.SetInitializer(new SampleData());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Starter.Start();

        }
    }
}
