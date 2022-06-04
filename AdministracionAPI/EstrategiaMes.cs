namespace AdministracionAPI
{
    public class EstrategiaMes
    {
        public int ID { get; set; }
        
        public int Mes { get; set; }
        
        public int Ano { get; set; }
        
        public int IdEstrategia { get; set; }
        public Estrategias? Estrategia { get; set; }
        
        public int IdUsuario { get; set; }
        public Usuarios? Usuario { get; set; }

    }
}
