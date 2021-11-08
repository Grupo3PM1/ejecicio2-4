using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ejeciciodoscuatro.Models
{
    public class foto
    {
        [PrimaryKey, AutoIncrement]
        public int IdFoto { get; set; }
        public byte[] Imagen { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
    }
}
