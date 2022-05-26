using System.ComponentModel.DataAnnotations;

namespace AdministracionAPI
{
    public class Estrategias
    {
        public int Id { get; set; }
        
        [StringLength(20)]
        public string Nombre { get; set; } = string.Empty;

        public int PorcentajeMensual { get; set; }
        
        public int PorcentajePersonal { get; set; }
        
        public int PorcentajeInversion { get; set; }
        
        public int PorcentajeAhorros { get; set; }
        
        public int IdUsuario { get; set; }
        public Usuarios? Usuario { get; set; }
    }
}
