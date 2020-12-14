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
    class CsapdaTabla
    {
        OracleConnection GetOracleConnection()
        {
            OracleConnection connection = new OracleConnection();

            string connectionString = @"Data Source=193.225.33.71;User Id=ORA_S1340;Password=EKE2020;";
            connection.ConnectionString = connectionString;
            return connection;
        }

        public List<Csapda> Select()
        {
            List<Csapda> records = new List<Csapda>();

            OracleConnection connection = new OracleConnection();
            connection.Open();

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM csapdalap"
            };

            command.Connection = connection;

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Csapda csapdalap = new Csapda();
                csapdalap.Azonosito = reader["rendszam"].ToString();
                csapdalap.Nev = reader["nev"].ToString();
                csapdalap.Leiras = reader["leiras"].ToString();
                csapdalap.CsapdaTipus = (CsapdaTipus)reader["trap_type"];
                csapdalap.Rarity = (Rarity)reader["rarity"];
                csapdalap.Quantity = (int)reader["quantity"];
                records.Add(csapdalap);
            }
            connection.Close();

            return records;
        }


        public int Delete(Csapda record)
        {
            OracleConnection connection = GetOracleConnection();
            connection.Open();

            OracleTransaction ot = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "DELETE FROM csapdalap WHERE azonosito = :azonosito"
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


        public int Insert(Csapda record)
        {
            OracleConnection connection = GetOracleConnection();
            connection.Open();

            OracleTransaction ot = connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            OracleCommand command = new OracleCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "spInsert_csapda"
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

            OracleParameter trapTypeP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_trap_type",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.CsapdaTipus
            };
            command.Parameters.Add(trapTypeP);

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
                CommandText = "sf_check_csapda_azonosito"
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
