using DOTA2.IBLL;
using DOTA2.IDAL;
using DOTA2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTA2.BLL
{
    public partial class HeroService : BaseService<Hero>, IHeroService
    {
        private IHeroDAL HeroDAL = DALContainer.Container.Resolve<IHeroDAL>();

        public override void SetDal()
        {
            Dal = HeroDAL;
        }
    }
}
