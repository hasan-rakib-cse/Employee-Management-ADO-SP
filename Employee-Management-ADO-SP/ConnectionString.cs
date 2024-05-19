using Microsoft.AspNetCore.Hosting.Server;

namespace Employee_Management_ADO_SP
{
    // static class use kortase cause amder jate se class er object create korar proyojon na hoy.
    // jate kore amra direct oi class ke access kori & dot(.) dea amra se class er property access korte pari.
    public static class ConnectionString
    {
        // cs = connection String, dbcs = database connection String, 
        private static string cs = "Server=DESKTOP-SC1LO7R; Database=EmployeeManagementADOSP;Trusted_Connection=True;User Id =sa; Password=rakib123;TrustServerCertificate=True;MultipleActiveResultSets=true";
        // uporer private property get korar jnno necher variable ata use kortase
        public static string dbcs { get => cs; }
    }
}
