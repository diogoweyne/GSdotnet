public class Psicologo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Especialidade { get; set; }
    public ICollection<Sessao>? Sessoes { get; set; }
}