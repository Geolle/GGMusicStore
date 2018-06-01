using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(GGMusicStore.Startup))]
namespace GGMusicStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

    /// <summary>
    /// 启动应用程序并预热
    /// </summary>
    public class Starter
    {

        /// <summary>
        /// 启动
        /// </summary>
        public static void Start()
        {

            var containerBuilder = new ContainerBuilder();
            IEnumerable<string> files = Directory.EnumerateFiles(HttpRuntime.BinDirectory, "Core.dll");
            files = files.Union(Directory.EnumerateFiles(HttpRuntime.BinDirectory, "GGMusicStore.dll"));

            Assembly[] assemblies = files.Select(n => Assembly.Load(AssemblyName.GetAssemblyName(n))).ToArray();


            //批量注入所有的Service,注意如果需要根据接口和实现进行特殊处理的service需要进行排除或者放到批量注入的下面
            containerBuilder.RegisterAssemblyTypes(assemblies).Where(t => t.Name.EndsWith("Service")).AsSelf().AsImplementedInterfaces().SingleInstance().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);


            //注入Controller
            containerBuilder.RegisterControllers(assemblies).PropertiesAutowired();

            IContainer container = containerBuilder.Build();
            //将Autofac容器中的实例注册到mvc自带DI容器中（这样才获取到每请求缓存的实例）
            DependencyResolver.SetResolver(new Autofac.Integration.Mvc.AutofacDependencyResolver(container));
            //DIContainer.RegisterContainer(container);

        }
    }
}
