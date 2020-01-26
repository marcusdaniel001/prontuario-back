namespace Prontuario.Domain.Entities
{
    public class InscricaoConselhoMedicina : BaseEntity
    {
        public string Numero { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
    }
}
