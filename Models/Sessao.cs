public class Sessao
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public string Descricao { get; set; } = string.Empty;

    public int PsicologoId { get; set; }
    public Psicologo? Psicologo { get; set; }

    public int PacienteId { get; set; }
    public Paciente? Paciente { get; set; }
}
