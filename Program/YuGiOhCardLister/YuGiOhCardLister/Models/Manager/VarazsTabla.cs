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
    class VarazsTabla:adatbKapcsolat
    {

        public List<Varazs> Select()
        {
            List<Varazs> records = new List<Varazs>();

            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM varazslap";

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Varazs varazslap = new Varazs();
                varazslap.Azonosito = reader["rendszam"].ToString();
                varazslap.Nev = reader["nev"].ToString();
                varazslap.Leiras = reader["leiras"].ToString();
                varazslap.VarazsTipus = (VarazsTipus)reader["magic_type"];
                varazslap.Rarity = reader["rarity"].ToString();
                varazslap.Quantity = reader["quantity"].ToString();
                records.Add(varazslap);
            }
            command.Connection.Close();

            return records;
        }


        public void Delete(Varazs record)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "DELETE FROM varazslap WHERE azonosito = :azonosito";

            OracleParameter azonositoP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":azonosito",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Azonosito
            };
            command.Parameters.Add(azonositoP);

            command.Connection.Close();

        }


        public void Insert(Varazs record)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "spInsert_varazs";


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

            OracleParameter magicTypeP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_magic_type",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.VarazsTipus
            };
            command.Parameters.Add(magicTypeP);

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


            command.Connection.Close();


        }


        public bool CheckAzonosito(string azonosito)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "sf_check_varazs_azonosito";


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

            

            try
            {
                int succesful = int.Parse(correct.Value.ToString());
                command.Connection.Close();
                return succesful != 0;
            }
            catch (Exception)
            {
                return false;
            }


        }

    }
}
