using ForumMVC.BLL.Interfaces;
using ForumMVC.BLL.Service;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumMVC.Web.Infrastructure
{
    public class MyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRecordService>().To<RecordService>();
        }
    }
}