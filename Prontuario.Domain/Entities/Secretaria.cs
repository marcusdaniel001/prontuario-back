namespace Prontuario.Domain.Entities
{
    public class Secretaria : BaseEntity
    {
        public string Senha { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int LocalAtendimentoId { get; set; }
        public LocalAtendimento LocalAtendimento { get; set; }
    }
}
