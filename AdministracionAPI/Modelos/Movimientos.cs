﻿using System.ComponentModel.DataAnnotations;

namespace AdministracionAPI.Modelos
{
    public class Movimientos
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public int Valor { get; set; }

        public DateTime Fecha { get; set; }

        public int IdUsuario { get; set; }
        public Usuarios? Usuario { get; set; }

        public int IdCategoria { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }

        public int IdTipoGasto { get; set; }
    }
}
