using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuGiOhCardLister.Models.Records;
using YuGiOhCardLister.Models.Enums;
using Oracle.ManagedDataAccess.Client;

namespace YuGiOhCardLister.Models.Manager
{
    class SzornyekTabla
    {
        OracleConnection GetOracleConnection()
        {
            OracleConnection connection = new OracleConnection();

            string connectionString = @"Data Source=193.225.33.71;User Id=ORA_S1340;Password=EKE2020;";
            connection.ConnectionString = connectionString;
            return connection;
        }

        public List<Szornyek> Select()
        {
            List<Szornyek> records = new List<Szornyek>();

            OracleConnection connection = new OracleConnection();
            connection.Open();

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM szornyek"
            };

            command.Connection = connection;

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Szornyek szorny = new Szornyek();
                szorny.Azonosito = reader["rendszam"].ToString();
                szorny.Nev = reader["nev"].ToString();
                szorny.Leiras = reader["leiras"].ToString();
                szorny.MonsterCardType = (MonsterCardType)reader["monster_card_type"];
                szorny.Level = (int)reader["monster_level"];
                szorny.Attribute = (Attributum)reader["monster_attribute"];
                szorny.Type = reader["monster_type"].ToString();
                szorny.Attack = (int)reader["attack"];
                szorny.Defense = (int)reader["defense"];
                szorny.LinkLevel = (byte)reader["link_level"];
                szorny.Rarity = (Rarity)reader["rarity"];
                szorny.Quantity = (int)reader["quantity"];
                records.Add(szorny);
            }
            connection.Close();

            return records;
        }


        public int Delete(Szornyek record)
        {
            OracleConnection connection = GetOracleConnection();
            connection.Open();

            OracleTransaction ot = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "DELETE FROM szornyek WHERE azonosito = :azonosito"
            };

            OracleParameter azonositoP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":azonosito",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Azonosito
            };
            command.Parameters.Add(azonositoP);

            command.Connection = connection;
            command.Transaction = ot;

            int affectedRows = 0;
            try
            {
                affectedRows = command.ExecuteNonQuery();
                ot.Commit();
            }
            catch (Exception)
            {
                ot.Rollback();
            }
            connection.Close();

            return affectedRows;
        }


        public int Insert(Szornyek record)
        {
            OracleConnection connection = GetOracleConnection();
            connection.Open();

            OracleTransaction ot = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "spInsert_szornyek"
            };


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



            OracleParameter rowcountParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "p_out_rowcnt",
                Direction = System.Data.ParameterDirection.Output
            };

            command.Connection = connection;
            command.Transaction = ot;

            connection.Close();

            try
            {
                command.ExecuteNonQuery();
                int affectedRows = int.Parse(rowcountParameter.Value.ToString());
                ot.Commit();
                return affectedRows;
            }
            catch (Exception)
            {
                ot.Rollback();
                return 0;
            }


        }


        public bool CheckAzonosito(string azonosito)
        {
            OracleConnection connection = GetOracleConnection();
            connection.Open();

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "sf_check_szorny_azonosito"
            };

            OracleParameter correct = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                Direction = System.Data.ParameterDirection.ReturnValue
            };

            OracleParameter azonositoP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_azonosito",
                Direction = System.Data.ParameterDirection.Input,
                Value = azonosito

            };
            command.Parameters.Add(azonositoP);

            command.Connection = connection;

            try
            {
                int succesful = int.Parse(correct.Value.ToString());

                return succesful != 0;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}
