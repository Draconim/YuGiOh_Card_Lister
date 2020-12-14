using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOhCardLister.Models.Other;
using YuGiOhCardLister.Models.Enums;

namespace YuGiOhCardLister.Models.Records
{
    class Varazs:Kartya
    {
        private VarazsTipus varazsTipus;

        public VarazsTipus VarazsTipus
        {
            get { return varazsTipus; }
            set { varazsTipus = value; }
        }

    }
}
