public class Paciente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Contato { get; set; }
    public ICollection<Sessao>? Sessoes { get; set; }
}