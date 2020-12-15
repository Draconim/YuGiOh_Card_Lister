using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOhCardLister.Models.Records;
using YuGiOhCardLister.Models.Enums;
using YuGiOhCardLister.Models.Other;
using Oracle.ManagedDataAccess.Client;

namespace YuGiOhCardLister.Models.Manager
{
    class SzornyekTabla:adatbKapcsolat
    {

        public List<Szornyek> Select()
        {
            List<Szornyek> records = new List<Szornyek>();



            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM szornyek";
            

            

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Szornyek szorny = new Szornyek();
                szorny.Azonosito = reader["azonosito"].ToString();
                szorny.Nev = reader["nev"].ToString();
                szorny.Leiras = reader["leiras"].ToString();
                szorny.MonsterCardType = reader["monster_card_type"].ToString();
                szorny.Level = reader["monster_level"].ToString();
                szorny.Attribute = reader["monster_attribute"].ToString();
                szorny.Type = reader["monster_type"].ToString();
                szorny.Attack = reader["attack"].ToString();
                szorny.Defense = reader["defense"].ToString();
                szorny.LinkLevel = reader["link_level"].ToString();
                szorny.Rarity = reader["rarity"].ToString(); ;
                szorny.Quantity = reader["quantity"].ToString();
                records.Add(szorny);
            }
            command.Connection.Close();

            return records;
        }
        public List<Szornyek> keresSelect(string nev, string azonosito)
        {
            OracleCommand command = new OracleCommand();
            List<Szornyek> records = new List<Szornyek>();
            OracleDataReader reader;
            if (nev != null)
            {

                command.Connection = openConnection();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM szornyek WHERE nev LIKE '%" + nev + "%'";
                reader = command.ExecuteReader();
            }
            else
            {

                command.Connection = openConnection();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM szornyek WHERE azonosito='" + azonosito + "'";
                reader = command.ExecuteReader();
            }
            //OracleParameter nevP = new OracleParameter()
            //{
            //    DbType = System.Data.DbType.String,
            //    ParameterName = ":nev",
            //    Direction = System.Data.ParameterDirection.Input,
            //    Value = nev
            //};
            //command.Parameters.Add(nevP);

            //paraméter hozzáadásával nem dob vissza egy sort sem

            while (reader.Read())
            {
                Szornyek szorny = new Szornyek();
                szorny.Azonosito = reader["azonosito"].ToString();
                szorny.Nev = reader["nev"].ToString();
                szorny.Leiras = reader["leiras"].ToString();
                szorny.MonsterCardType = reader["monster_card_type"].ToString();
                szorny.Level = reader["monster_level"].ToString();
                szorny.Attribute = reader["monster_attribute"].ToString();
                szorny.Type = reader["monster_type"].ToString();
                szorny.Attack = reader["attack"].ToString();
                szorny.Defense = reader["defense"].ToString();
                szorny.LinkLevel = reader["link_level"].ToString();
                szorny.Rarity = reader["rarity"].ToString(); ;
                szorny.Quantity = reader["quantity"].ToString();
                records.Add(szorny);
            }
            command.Connection.Close();

            return records;
        }

        public void Delete(Szornyek record)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM szornyek WHERE azonosito = :azonosito";


            OracleParameter azonositoP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":azonosito",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Azonosito
            };
            command.Parameters.Add(azonositoP);
            command.ExecuteNonQuery();
            command.Connection.Close();

        }


        public void Update(Szornyek record, string regiAzon)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE SZORNYEK SET azonosito=:azonosito, nev=:nev, leiras=:leiras,monster_card_type=:monster_card_type, monster_level=:monster_level, monster_attribute=:monster_attribute, monster_type=:monster_type,attack=:attack, defense=:defense, link_level=:link_level, rarity=:rarity, quantity=:quantity WHERE azonosito=:regiAzon";
            OracleParameter azonositoP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":azonosito",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Azonosito
            };
            command.Parameters.Add(azonositoP);

            OracleParameter nevP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":nev",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Nev
            };
            command.Parameters.Add(nevP);

            OracleParameter leirasP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":leiras",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Leiras
            };
            command.Parameters.Add(leirasP);

            OracleParameter monsterCardTypeP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":monster_card_type",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.MonsterCardType
            };
            command.Parameters.Add(monsterCardTypeP);

            OracleParameter monsterLevelP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":monster_level",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Level
            };
            command.Parameters.Add(monsterLevelP);

            OracleParameter monsterAttributeP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":monster_attribute",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Attribute
            };
            command.Parameters.Add(monsterAttributeP);

            OracleParameter monsterTypeP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":monster_type",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Type
            };
            command.Parameters.Add(monsterTypeP);

            OracleParameter attackP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":attack",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Attack
            };
            command.Parameters.Add(attackP);

            OracleParameter defenseP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":defense",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Defense
            };
            command.Parameters.Add(defenseP);

            OracleParameter linkLevelP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":link_level",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.LinkLevel
            };
            command.Parameters.Add(linkLevelP);

            OracleParameter rarityP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":rarity",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Rarity
            };
            command.Parameters.Add(rarityP);

            OracleParameter quantityP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":quantity",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Quantity
            };
            command.Parameters.Add(quantityP);

            OracleParameter regiAzonositoP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":regiAzon",
                Direction = System.Data.ParameterDirection.Input,
                Value = regiAzon
            };
            command.Parameters.Add(regiAzonositoP);

            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public void Insert(Szornyek record)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "spInsert_szornyek";
            


            OracleParameter azonositoP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_azonosito",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Azonosito
            };
            command.Parameters.Add(azonositoP);

            OracleParameter nevP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_nev",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Nev
            };
            command.Parameters.Add(nevP);

            OracleParameter leirasP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_leiras",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Leiras
            };
            command.Parameters.Add(leirasP);

            OracleParameter monsterCardTypeP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_monster_card_type",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.MonsterCardType
            };
            command.Parameters.Add(monsterCardTypeP);

            OracleParameter monsterLevelP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_monster_level",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Level
            };
            command.Parameters.Add(monsterLevelP);
            
            OracleParameter monsterAttributeP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_monster_attribute",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Attribute
            };
            command.Parameters.Add(monsterAttributeP);

            OracleParameter monsterTypeP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_monster_type",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Type
            };
            command.Parameters.Add(monsterTypeP);
            
            OracleParameter attackP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_attack",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Attack
            };
            command.Parameters.Add(attackP);

            OracleParameter defenseP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_defense",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Defense
            };
            command.Parameters.Add(defenseP);

            OracleParameter linkLevelP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_link_level",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.LinkLevel
            };
            command.Parameters.Add(linkLevelP);

            OracleParameter rarityP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_rarity",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Rarity
            };
            command.Parameters.Add(rarityP);

            OracleParameter quantityP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_quantity",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Quantity
            };
            command.Parameters.Add(quantityP);

            command.ExecuteNonQuery();
            command.Connection.Close();
            
        }


        
    }
}
