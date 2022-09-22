using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DataAccessLayer
    {
        static string sConn = "Data Source = localhost ; Initial Catalog = RentalAppDB;Integrated Security = true; ";
        SqlConnection dbConn = new SqlConnection(sConn);
        SqlCommand dbComm;
        SqlDataAdapter dbAdapter;
        DataTable dt;

        public int PropertyTypeInsert(PropertyType pt)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_PropertyTypeInsert", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyTypeDescription", pt.PropertyTypeDescription);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;

        }

        public DataTable PropertyTypeGET()
        {
            dbConn.Open();
            string sql = "PropertyTypeGET";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            return dt;

        }
        public int PropertyInsert(Property p)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_PropertyInsert", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Description", p.Description);
            dbComm.Parameters.AddWithValue("@Price", p.Price);
            dbComm.Parameters.AddWithValue("@Image", p.Image);
            dbComm.Parameters.AddWithValue("@PropertyTypeID", p.PropertyTypeID);
            dbComm.Parameters.AddWithValue("@Status", p.Status);
            dbComm.Parameters.AddWithValue("@SurbubID", p.SurbubID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;

        }
        public int PropertyUpdate(Property p)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_PropertyUpdate", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyID", p.PropertyID);
            dbComm.Parameters.AddWithValue("@Price", p.Price);
            dbComm.Parameters.AddWithValue("@PropertyTypeID", p.PropertyTypeID);
            dbComm.Parameters.AddWithValue("@Status", p.Status);
            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable PropertyGET()
        {
            dbConn.Open();
            string sql = "PropertyGET";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            return dt;
        }
        public int PropertyDelete(Property p)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_PropertyDelete", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyID", p.PropertyID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int ProvinceInsert(Province prov)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_ProvinceInsert", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Description", prov.Description);
            
            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable ProvinceGet()
        {
            dbConn.Open();
            string sql = "ProvinceGET";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            return dt;
        }
        public int CityInsert(City c)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_CityInsert", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@CityDescription", c.CityDescription);            
            dbComm.Parameters.AddWithValue("@ProvinceID", c.ProvinceID);          

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable CityGet()
        {
            dbConn.Open();
            string sql = "CityGET";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            return dt;
        }
        public int SuburbsInsert(Surbub s)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_SuburbsInsert", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@SurbubDescription", s.SurbubDescription);
            dbComm.Parameters.AddWithValue("@PostalCode", s.PostalCode);
            dbComm.Parameters.AddWithValue("@CityID", s.CityID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable SurbubGet()
        {
            dbConn.Open();
            string sql = "SurbubGET";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            return dt;
        }
        public int AgenciesInsert(Agency a)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_AgenciesInsert", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AgencyName", a.AgencyName);
            dbComm.Parameters.AddWithValue("@SurbubID", a.SurbubID);           

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;

        }
        public DataTable AgenciesGet()
        {
            dbConn.Open();
            string sql = "AgenciesGET";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            return dt;
        }
        public int AgenciesDelete(Agency a)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_AgenciesDelete", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AgencyID", a.AgencyID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }

        public int AgentInsert(Agent at)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_AgentInsert", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Name", at.Name);
            dbComm.Parameters.AddWithValue("@Surname", at.Surname);
            dbComm.Parameters.AddWithValue("@Email", at.Email);
            dbComm.Parameters.AddWithValue("@Password", at.Password);
            dbComm.Parameters.AddWithValue("@Phone", at.Phone);
            dbComm.Parameters.AddWithValue("@Status", at.Status);
            dbComm.Parameters.AddWithValue("@AgencyID", at.AgencyID);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable AgentGet()
        {
            dbConn.Open();
            string sql = "AgentGET";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            return dt;
        }
        public int AgentDelete(Agent at)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_AgentDelete", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AgentID", at.AgentID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int AgentUpdate(Agent at)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_AgentUpdate", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@AgentID", at.AgentID);
            dbComm.Parameters.AddWithValue("@Email", at.Email);
            dbComm.Parameters.AddWithValue("@Phone", at.Phone);
            dbComm.Parameters.AddWithValue("@Status", at.Status);
            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public int TenantInsert(Tenant t)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_TenantInsert", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Name", t.Name);
            dbComm.Parameters.AddWithValue("@Surname", t.Surname);
            dbComm.Parameters.AddWithValue("@Email", t.Email);
            dbComm.Parameters.AddWithValue("@Password", t.Password);
            dbComm.Parameters.AddWithValue("@Phone", t.Phone);
            dbComm.Parameters.AddWithValue("@Status", t.Status);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable TenantGet()
        {
            dbConn.Open();
            string sql = "TenantGET";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            return dt;
        }
        public int TenantDelete(Tenant t)
        {
            dbConn.Open();

            dbComm = new SqlCommand("sp_TenantDelete", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@TenantID", t.TenantID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int TenantUpdate(Tenant t)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_TenantUpdate", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@TenantID", t.TenantID);
            dbComm.Parameters.AddWithValue("@Email", t.Email);
            dbComm.Parameters.AddWithValue("@Phone", t.Phone);
            dbComm.Parameters.AddWithValue("@Status", t.Status);
            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public int PropertyAgentInsert(PropertyAgent pa)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_AgentInsert", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyID", pa.PropertyID);
            dbComm.Parameters.AddWithValue("@AgentID", pa.AgentID);
            dbComm.Parameters.AddWithValue("@Date", pa.Date);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable PropertyAgentGet()
        {
            dbConn.Open();
            string sql = "PropertyAgentGET";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            return dt;
        }
        public int PropertyAgentUpdate(PropertyAgent pa)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_PropertyAgentUpdate", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyAgentID", pa.PropertyAgentID);
            dbComm.Parameters.AddWithValue("@PropertyID", pa.PropertyID);
            dbComm.Parameters.AddWithValue("@AgentID", pa.AgentID);
            dbComm.Parameters.AddWithValue("@Date", pa.Date);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public int RentalInsert(Rental r)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_RentalInsert", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@PropertyTenantID", r.PropertyTenantID);
            dbComm.Parameters.AddWithValue("@TenantID", r.TenantID);
            dbComm.Parameters.AddWithValue("@StartDate", r.StartDate);
            dbComm.Parameters.AddWithValue("@EndDate", r.EndDate);

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }
        public DataTable RentalGet()
        {
            dbConn.Open();
            string sql = "RentalGET";
            dbComm = new SqlCommand(sql, dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;
            dbAdapter = new SqlDataAdapter(dbComm);
            dt = new DataTable();
            dbAdapter.Fill(dt);

            return dt;
        }
        public int RentalUpdate(Rental r)
        {
            dbConn.Open();
            dbComm = new SqlCommand("sp_RentalUpdate", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@RentalID", r.RentalID);
            dbComm.Parameters.AddWithValue("@StartDate", r.StartDate);
            dbComm.Parameters.AddWithValue("@EndDate", r.EndDate);            

            int x = dbComm.ExecuteNonQuery();

            dbConn.Close();

            return x;
        }

    }

}
