using System.Data.Common;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace App1_ConnBdMySQL.Infrastructure.Databases;

// Readme #7
public class ConexionMySQL : IConexionMySQL
{

    private DbConnection _conexion;
    private IConfiguration _configuracion;

    public ConexionMySQL(IConfiguration configuracion)
    {
        _configuracion = configuracion;
    }

    public void Conectar()
    {
        var conexionString = _configuracion["ConnectionStrings:ConexionMySQL"];
        if (conexionString == null || conexionString.Trim().Count() == 0)
        {
            throw new Exception("Parametros de conexion errados");
        }
        try
        {
            _conexion = new MySqlConnection(conexionString);
            _conexion.Open();
        }
        catch (MySqlException er)
        {
            throw new Exception("Error a conectar con la BD\nDescripion: " + er.Message);
        }

    }

    public int Actualizar(string sql)
    {

        try
        {
            Conectar();
            var sqlCommand = new MySqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = (MySqlConnection)_conexion;
            int total = sqlCommand.ExecuteNonQuery();
            _conexion.Close();
            return total;
        }
        catch (System.Exception er)
        {
            System.Console.WriteLine("ERROR: " + er.Message);
            throw new Exception("Error al ACtualizar la BD");
        }
    }

    public DataTable consultar(string sql)
    {
        try
        {
            Conectar();
            var sqlCommand = new MySqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = (MySqlConnection)_conexion;
            MySqlDataReader resultado = sqlCommand.ExecuteReader();
            DataTable tabla = new DataTable();
            tabla.Load(resultado);
            _conexion.Close();
            return tabla;
        }
        catch (System.Exception er)
        {
            System.Console.WriteLine("ERROR: " + er.Message);
            throw new Exception("Error al Consultar la BD");
        }
    }


    public int Eliminar(string sql)
    {
        try
        {
            Conectar();
            var sqlCommand = new MySqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = (MySqlConnection)_conexion;
            int total = sqlCommand.ExecuteNonQuery();
            _conexion.Close();
            return total;
        }
        catch (System.Exception er)
        {
            System.Console.WriteLine("ERROR: " + er.Message);
            throw new Exception("Error al Eliminar la BD");
        }
    }

    public int Insertar(string sql)
    {
        try
        {
            Conectar();
            var sqlCommand = new MySqlCommand();
            sqlCommand.CommandText = sql;
            sqlCommand.Connection = (MySqlConnection)_conexion;
            int total = sqlCommand.ExecuteNonQuery();
            _conexion.Close();
            return total;
        }
        catch (System.Exception er)
        {
            System.Console.WriteLine("ERROR: " + er.Message);
            throw new Exception("Error al insertar en la BD");
        }
    }


}