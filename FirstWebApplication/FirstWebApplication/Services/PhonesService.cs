using FirstWebApplication.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Services
{
    public class PhonesService
    {
        SqlConnection con = new SqlConnection();
        
        public PhonesService()
        {
            var str = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["PhonesConnection"];
            con.ConnectionString = str;
        }

        public List<Phone> GetPhones()
        {
            var cmd = new SqlCommand("Select * from Phones", con);

            con.Open();
            var rdr = cmd.ExecuteReader();
            var lst = new List<Phone>();
            while(rdr.Read())
            {
                lst.Add(new Phone()
                {
                    IdPhone = rdr.GetInt32(0),
                    Brand = rdr[1].ToString(),
                    Model = rdr[2].ToString(),
                    Price = rdr.GetInt32(3),
                    Count = rdr.GetInt32(5),
                    Image = rdr.GetString(4)
                });
            }
            con.Close();
            return lst;

        }

        public Phone GetPhone(int i)
        {
            var cmd = new SqlCommand("Select * from Phones where IdPhone = " + i.ToString()
                , con);

            con.Open();
            var rdr = cmd.ExecuteReader();
            var phone = new Phone();
            while (rdr.Read())
            {
                phone.IdPhone = rdr.GetInt32(0);
                phone.Brand = rdr[1].ToString();
                phone.Model = rdr[2].ToString();
                phone.Price = rdr.GetInt32(3);
                phone.Count = rdr.GetInt32(5);
                phone.Image = rdr.GetString(4);
            }
            con.Close();
            return phone;
        }


    }
}
