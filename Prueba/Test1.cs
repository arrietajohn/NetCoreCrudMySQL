using System.Data;
using App1_ConnBdMySQL.Infrastructure.Databases;
using Microsoft.Extensions.Configuration;

public class Test1
{
    public static void probarConexion(IConfiguration conf)
    {
        var conBd = new ConexionMySQL(conf);
        conBd.Conectar();
        System.Console.WriteLine("ok");
    }

    public static void probarInsertar(IConfiguration conf)
    {
        var conBd = new ConexionMySQL(conf);
        string sql = "INSERT INTO Usuarios VALUES ('123', 'Abc', 'FULANITO 1 DEL TAL', 'f1@gmail.com')";
        int total = conBd.Insertar(sql);
        System.Console.WriteLine("TOTAL: " + Convert.ToString(total));
    }


    public static void probarEliminar(IConfiguration conf)
    {
        var conBd = new ConexionMySQL(conf);
        string sql = "DELETE FROM USUARIOS WHERE id = '123'";
        int total = conBd.Eliminar(sql);
        System.Console.WriteLine("TOTAL ELIMINADOS: " + Convert.ToString(total));
    }


    public static void probarActualizar(IConfiguration conf)
    {
        var conBd = new ConexionMySQL(conf);
        string sql = "UPDATE Usuarios SET nombre = 'Funalito ABC'  WHERE id = '123'";
        int total = conBd.Actualizar(sql);
        System.Console.WriteLine("TOTAL ACTUALIZADOS: " + Convert.ToString(total));
    }

       public static void probarConsulta(IConfiguration conf)
    {
        var conBd = new ConexionMySQL(conf);
        string sql = "Select * FROM Usuarios";
        var resultado = conBd.consultar(sql);
        System.Console.WriteLine("TOTAL USUARIOS: " + Convert.ToString(resultado.Rows.Count));
        var filas = resultado.Rows;
        foreach(DataRow fila in filas){
            int pos = filas.IndexOf(fila)+1;
            System.Console.WriteLine("----------------");
            System.Console.WriteLine("USUARIOS #"+pos);
            System.Console.WriteLine($"ID: {fila[0]}");
            System.Console.WriteLine($"ID: {fila[1]}");
            System.Console.WriteLine($"ID: {fila[2]}");
            System.Console.WriteLine($"ID: {fila[3]}");
            System.Console.WriteLine("----------------");
        }
        
    }



}