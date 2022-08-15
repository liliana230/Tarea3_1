using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Tarea3_1.Models;


namespace Tarea3_1.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection db;
         public DataBase (string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Empleados>().Wait();
        }

        public Task<List<Empleados>> ObtenerListaEmpleados()
        {
            return db.Table<Empleados>().ToListAsync();
        }


        public Task<Empleados> ObtenerEmpleado(int codidoid)
        {
            return db.Table<Empleados>()
                .Where(i => i.id == codidoid)
                .FirstOrDefaultAsync();
        }

        public Task<int> AggEmpleado(Empleados emple)
        {
            if (emple.id != 0)
            {
                return db.UpdateAsync(emple);
            }
            else
            {
                return db.InsertAsync(emple);
            }

        }
        public Task<int> EliminarEmpleado(Empleados emplea)
        {
            return db.DeleteAsync(emplea);
        }
    }
}
