using Autofac;
using DOTA2.BLL;
using DOTA2.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTA2.BLLContainer
{
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 获取 IDal 的实例化对象
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
                throw new System.Exception("IOC实例化出错！" + ex.Message);
            }

            return container.Resolve<T>();
        }

        public static void Initialise()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //格式:builder.RegisterType<xxxx>().As<xxxx>().InstancePerLifetimeScope();
            builder.RegisterType<HeroService>().As<IHeroService>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
