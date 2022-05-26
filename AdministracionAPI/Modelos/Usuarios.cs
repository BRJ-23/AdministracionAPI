using System.ComponentModel.DataAnnotations;

namespace AdministracionAPI.Modelos
{
    public class Usuarios
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(50)]
        public string Apellidos { get; set; } = string.Empty;

        public DateTime FechaRegistro { get; set; }

        [StringLength(50)]
        public string Correo { get; set; } = string.Empty;

        [StringLength(50)]
        public string Moneda { get; set; } = string.Empty;

        [StringLength(50)]
        public string Contraseña { get; set; } = string.Empty;

        public double AhorrosTotales { get; set; }

        public double AhorrosIniciales { get; set; }

        public double GastosMensuales { get; set; }
    }
}
