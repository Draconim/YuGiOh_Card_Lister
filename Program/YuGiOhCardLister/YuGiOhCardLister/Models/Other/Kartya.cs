﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOhCardLister.Models.Enums;

namespace YuGiOhCardLister.Models.Other
{
    class Kartya
    {
        private string azonosito;

        public string Azonosito
        {
            get { return azonosito; }
            set { azonosito = value; }
        }

        private string nev;

        public string Nev
        {
            get { return nev; }
            set { nev = value; }
        }

        private string leiras;

        public string Leiras
        {
            get { return leiras; }
            set { leiras = value; }
        }

        private string rarity;

        public string Rarity
        {
            get { return rarity; }
            set { rarity = value; }
        }

        private string quantity;

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}
