using System.ComponentModel.DataAnnotations;

namespace AdministracionAPI
{
    public class Inversiones
    {
        public int Id { get; set; }
        
        public int IdUsuario { get; set; }
        public Usuarios? Usuario { get; set; }
        
        [StringLength(20)]
        public string Nombre { get; set; } = string.Empty;
        
        public double Fondos { get; set; }
        
        public double Objectivos { get; set; }
        
        public int AnoInicio { get; set; }
        
        public int AnoFin { get; set; }
        
        public int Estado { get; set; }
        
        public double FondosIniciales { get; set; }
        
        public int PosicionDiseno { get; set; }

    }
}
