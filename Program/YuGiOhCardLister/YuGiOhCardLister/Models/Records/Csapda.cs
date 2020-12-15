using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOhCardLister.Models.Other;
using YuGiOhCardLister.Models.Enums;

namespace YuGiOhCardLister.Models.Records
{
    class Csapda:Kartya
    {
        private string csapdaTipus;

        public string CsapdaTipus
        {
            get { return csapdaTipus; }
            set { csapdaTipus = value; }
        }

    }
}
