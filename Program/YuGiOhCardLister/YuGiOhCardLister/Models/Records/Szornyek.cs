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
        private int level;

        public int Level
        {
            get { return level; }
            set {
                if (value < 1 || value > 12)
                    throw new Exception("Hiba! A szintnek 1 és 12 között kell lennie.");
                level = value;
            }
        }
        private Attributum attribute;

        public Attributum Attribute
        {
            get { return attribute; }
            set { attribute = value; }
        }

        private MonsterCardType monsterCardType;

        public MonsterCardType MonsterCardType
        {
            get { return monsterCardType; }
            set { monsterCardType = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private int attack;

        public int Attack
        {
            get { return attack; }
            set {
                if (value < 0 || value > 10000)
                    throw new Exception("Hiba! A támadó értéknek 0 és 10000 között kell lennie!");
                    attack = value;
            }
        }
        private int defense;

        public int Defense
        {
            get { return defense; }
            set {
                if (value < 0 || value > 10000)
                    throw new Exception("Hiba! A védekező értéknek 0 és 10000 között kell lennie!");
                defense = value;
            }
        }

        private byte linkLevel;

        public byte LinkLevel
        {
            get { return linkLevel; }
            set {
                if (value < 0 || value > 4)
                    throw new Exception("Hiba! A link szintnek 1 és 4 között kell lennie!");
                linkLevel = value;
            }
        }

        //Tekintetbe véve, hogy csak a Link szörnyeknek kéne külön alosztály, 
        //ezért ezt elkerülve egy sima Szörny alosztály kerül létrehozásra.
        //A szörny típusát majd legördülő box-ban lehet kiválasztani.Ha a felhasználó "Link" szörnyet választ, 
        //a szint és a védekező érték textboxa le lesz tiltva, és engedélyezve lesz a Link szint kiválaszthatása.
    }
}
