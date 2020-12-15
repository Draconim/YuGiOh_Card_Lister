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
    class CsapdaTabla:adatbKapcsolat
    {

        public List<Csapda> Select()
        {
            List<Csapda> records = new List<Csapda>();

            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM csapdalap";


            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Csapda csapdalap = new Csapda();
                csapdalap.Azonosito = reader["azonosito"].ToString();
                csapdalap.Nev = reader["nev"].ToString();
                csapdalap.Leiras = reader["leiras"].ToString();
                csapdalap.CsapdaTipus = reader["trap_type"].ToString();
                csapdalap.Rarity = reader["rarity"].ToString();
                csapdalap.Quantity = reader["quantity"].ToString();
                records.Add(csapdalap);
            }
            command.Connection.Close();

            return records;
        }
        public List<Csapda> keresSelect(string nev, string azonosito)
        {
            OracleCommand command = new OracleCommand();
            List<Csapda> records = new List<Csapda>();
            OracleDataReader reader;
            if (nev != null)
            {

                command.Connection = openConnection();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM csapdalap WHERE nev LIKE '%" + nev + "%'";
                reader = command.ExecuteReader();
            }
            else
            {

                command.Connection = openConnection();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM csapdalap WHERE azonosito='" + azonosito + "'";
                reader = command.ExecuteReader();
            }


            while (reader.Read())
            {
                Csapda csapdalap = new Csapda();
                csapdalap.Azonosito = reader["azonosito"].ToString();
                csapdalap.Nev = reader["nev"].ToString();
                csapdalap.Leiras = reader["leiras"].ToString();
                csapdalap.CsapdaTipus = reader["trap_type"].ToString();
                csapdalap.Rarity = reader["rarity"].ToString();
                csapdalap.Quantity = reader["quantity"].ToString();
                records.Add(csapdalap);
            }
            command.Connection.Close();

            return records;
        }

        public void Delete(Csapda record)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM csapdalap WHERE azonosito = :azonosito";


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


        public void Update(Csapda record, string regiAzon)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE CSAPDALAP SET azonosito=:azonosito, nev=:nev, leiras=:leiras, trap_type=:trap_type, rarity=:rarity, quantity=:quantity WHERE azonosito=:regiAzon";
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

            OracleParameter trapTypeP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":trap_type",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.CsapdaTipus
            };
            command.Parameters.Add(trapTypeP);

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

        public void Insert(Csapda record)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "spInsert_csapda";


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



            command.ExecuteNonQuery();
            command.Connection.Close();
            



        }


        
    }
}
