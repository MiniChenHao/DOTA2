using Autofac;
using DOTA2.DAL;
using DOTA2.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTA2.DALContainer
{
    /// <summary>
    /// IOC容器
    /// </summary>
    public class Container
    {
        public static IContainer container = null;

        /// <summary>
        /// 获取IDal的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("IOC实例化出错！" + ex.Message);
            }
            return container.Resolve<T>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //格式:builder.RegisterType<xxxx>().As<xxxx>().InstancePerLifetimeScope();
            builder.RegisterType<HeroDAL>().As<IHeroDAL>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
