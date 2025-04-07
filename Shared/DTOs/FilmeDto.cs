namespace Shared.DTOs
{
    public class FilmeDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTimeOffset DataLancamento { get; set; }
    }
}
