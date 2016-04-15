using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Proyecto.Models;

namespace Proyecto.Models
{
    public class DB_PROYECTO : DbContext
    {
        public DB_PROYECTO() : base("name=DB_PROYECTO") { }
        public virtual DbSet<Rol> rol { get; set; }
        public virtual DbSet<Usuario> usuario { get; set; }
        public virtual DbSet<Compra> compra { get; set; }
        public virtual DbSet<Marca> marca { get; set; }
        public virtual DbSet<Modelo> modelo { get; set; }
        public virtual DbSet<Transmision> transmision { get; set; }
        public virtual DbSet<Combustible> combustible { get; set; }
        public virtual DbSet<Automovil> automovil { get; set; }
        public virtual DbSet<Archivo> archivo { get; set; }

    }
}