using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace ReservasGimnasio.Core.Entities
{
    public static class ConexionDB
    {
        public static SqlConnection Conectar()
        {
            return new SqlConnection("Data Source=DESKTOP-MHHCE8Q;Initial Catalog=Gimnasio;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
