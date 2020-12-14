using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOhCardLister.Models.Other;
using YuGiOhCardLister.Models.Enums;

namespace YuGiOhCardLister.Models.Records
{
    class Szornyek:Kartya
    {
        private string monsterCardType;

        public string MonsterCardType
        {
            get { return monsterCardType; }
            set { monsterCardType = value; }
        }

        private string level;

        public string Level
        {
            get { return level; }
            set {
                //if (int.Parse(value) < 1 || int.Parse(value) > 12)
                //    throw new Exception("Hiba! A szintnek 1 és 12 között kell lennie.");
                level = value;
            }
        }
        private string attribute;

        public string Attribute
        {
            get { return attribute; }
            set { attribute = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string attack;

        public string Attack
        {
            get { return attack; }
            set {
                //if (int.Parse(value) < 0 || int.Parse(value) > 10000)
                //    throw new Exception("Hiba! A támadó értéknek 0 és 10000 között kell lennie!");
                    attack = value;
            }
        }
        private string defense;

        public string Defense
        {
            get { return defense; }
            set {
                //if (int.Parse(value) < 0 || int.Parse(value) > 10000)
                //    throw new Exception("Hiba! A védekező értéknek 0 és 10000 között kell lennie!");
                defense = value;
            }
        }

        private string linkLevel;

        public string LinkLevel
        {
            get { return linkLevel; }
            set {
                //if (int.Parse(value) < 0 || int.Parse(value) > 4)
                //    throw new Exception("Hiba! A link szintnek 1 és 4 között kell lennie!");
                linkLevel = value;
            }
        }


    }
}
