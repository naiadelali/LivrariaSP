using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace LivrariaEF.Data
{
    public static class DbComandos
    {
        private static readonly SqlConnection _connection = new SqlConnection(@"Data Source=AMR-00600-ES\SQLEXPRESS;Initial Catalog=LivrariaDB;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

        public static DataTable ConsultarProcedure(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                if(_connection.State == ConnectionState.Closed)
                    _connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql,_connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                if(_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            finally
            {
              if(_connection.State == ConnectionState.Open)
                  _connection.Close();
                
            }

            return dt;
        }

        public static DataTable ConsultarProcedure(string sql, List<SqlParameter> parametros)
        {
            DataTable dt = new DataTable();
            try
            {
                if(_connection.State == ConnectionState.Closed)
                    _connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, _connection))
                {
                    if(parametros.Count>0)
                        foreach (var p in parametros)
                            cmd.Parameters.Add(p);

                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                    
                }

                if(_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return dt;
        }

        public static void ExecutarProcedure(string sql)
        {
            try
            {
                if(_connection.State == ConnectionState.Closed)
                    _connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql,_connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                if(_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                if(_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }

        public static void ExecutarProcedure(string sql, List<SqlParameter> parameters)
        {
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                using (SqlCommand cmd = new SqlCommand(sql, _connection))
                {
                    if(parameters.Count>0)
                        foreach (var p in parameters)
                            cmd.Parameters.Add(p);

                    cmd.CommandType=CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }

                if(_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            finally
            {
                if(_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
    }
}
