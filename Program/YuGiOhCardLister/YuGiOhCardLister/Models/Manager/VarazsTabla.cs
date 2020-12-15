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
                varazslap.Azonosito = reader["azonosito"].ToString();
                varazslap.Nev = reader["nev"].ToString();
                varazslap.Leiras = reader["leiras"].ToString();
                varazslap.VarazsTipus = reader["magic_type"].ToString(); ;
                varazslap.Rarity = reader["rarity"].ToString();
                varazslap.Quantity = reader["quantity"].ToString();
                records.Add(varazslap);
            }
            command.Connection.Close();

            return records;
        }

        public List<Varazs> keresSelect(string nev,string azonosito)
        {
            OracleCommand command = new OracleCommand();
            List<Varazs> records = new List<Varazs>();
            OracleDataReader reader;
            if (nev != null)
            {
                
                command.Connection = openConnection();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM varazslap WHERE nev LIKE '%" + nev + "%'";
                reader = command.ExecuteReader();
            }
            else
            {

                command.Connection = openConnection();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM varazslap WHERE azonosito='" + azonosito + "'";
                reader = command.ExecuteReader();
            }
            
            while (reader.Read())
            {
                Varazs varazslap = new Varazs();
                varazslap.Azonosito = reader["azonosito"].ToString();
                varazslap.Nev = reader["nev"].ToString();
                varazslap.Leiras = reader["leiras"].ToString();
                varazslap.VarazsTipus = reader["magic_type"].ToString(); ;
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
            command.ExecuteNonQuery();
            command.Connection.Close();

        }


        public void Update(Varazs record, string regiAzon)
        {
            OracleCommand command = new OracleCommand();
            command.Connection = openConnection();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE VARAZSLAP SET azonosito=:azonosito, nev=:nev, leiras=:leiras, magic_type=:magic_type, rarity=:rarity, quantity=:quantity WHERE azonosito=:regiAzon";
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

            OracleParameter magicTypeP = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = ":magic_type",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.VarazsTipus
            };
            command.Parameters.Add(magicTypeP);

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
            command.ExecuteNonQuery();

            command.Connection.Close();


        }


        

    }
}
