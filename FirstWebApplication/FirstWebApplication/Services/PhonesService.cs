using FirstWebApplication.Models;
using FirstWebApplication.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApplication.Services
{
    public class PhonesService:IGenericRepository<Phone>
    {
        SqlConnection con = new SqlConnection();
        
        public PhonesService()
        {
            var str = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build().GetSection("ConnectionStrings")["PhonesConnection"];
            con.ConnectionString = str;
        }

        public IEnumerable<Phone> GetAll()
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

        public Phone GetById(int id)
        {
            var cmd = new SqlCommand("Select * from Phones where IdPhone = " + id.ToString()
                , con);

            con.Open();
            var rdr = cmd.ExecuteReader();
            Phone phone = null;
            while (rdr.Read())
            {
                phone = new Phone();
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

        public void Add(Phone ph)
        {
            var cmd = new SqlCommand("insert into Phones(Brand,Model,Price,Count,Image) "
                + "values(@Brand,@Model,@Price,@Count,@Image)", con);
            cmd.Parameters.AddWithValue("@Brand", ph.Brand);
            cmd.Parameters.AddWithValue("@Model", ph.Model);
            cmd.Parameters.AddWithValue("@Price", ph.Price);
            cmd.Parameters.AddWithValue("@Count", ph.Count);
            cmd.Parameters.AddWithValue("@Image", ph.Image);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Update(Phone ph)
        {
            var cmd = new SqlCommand("Update Phones set Brand=@Brand, Model=@Model, " +
                "Price=@Price, Count=@Count, Image=@Image where IdPhone=@id", con);
            cmd.Parameters.AddWithValue("@Brand", ph.Brand);
            cmd.Parameters.AddWithValue("@Model", ph.Model);
            cmd.Parameters.AddWithValue("@Price", ph.Price);
            cmd.Parameters.AddWithValue("@Count", ph.Count);
            cmd.Parameters.AddWithValue("@Image", ph.Image);
            cmd.Parameters.AddWithValue("@id", ph.IdPhone);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public void Remove(Phone phone)
        {
            var cmd = new SqlCommand("delete from Phones where IdPhone = @id", con);
            cmd.Parameters.AddWithValue("@id", phone.IdPhone);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
