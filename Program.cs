using App1_ConnBdMySQL.Infrastructure.Databases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// ReadMe # 9
var config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();

// ReadMe # 10
var app = Host.CreateDefaultBuilder(args)
.ConfigureServices(servicio =>
{
    // ReadMe # 11
    servicio.AddTransient<IConexionMySQL, ConexionMySQL>();
}).Build();


// Test1.probarConexion(config);
// Test1.probarInsertar(config);
// Test1.probarEliminar(config);
// Test1.probarActualizar(config);
Test1.probarConsulta(config);


// ReadMe # 10
await app.RunAsync();
// System.Console.WriteLine($"CONEXOIN: {config["ConnectionStrings:ConexionMySQL"]}");