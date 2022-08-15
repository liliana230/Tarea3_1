using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Tarea3_1.Models
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string foto { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string edad { get; set; }
        public string direccion { get; set; }
        public string puesto { get; set; }
        
    }
}
