using System.Data;

namespace App1_ConnBdMySQL.Infrastructure.Databases;

// Readme #6
public interface IConexionMySQL{
    public int Insertar(string sql);
    public DataTable consultar(string sql);
    public int Eliminar(string sql);
    public int Actualizar(string sql);

}