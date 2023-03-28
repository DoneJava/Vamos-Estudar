namespace VamosEstudar.Models.DTO
{
    public class RespostaApiDTO
    {
        public string? Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public object? ObjetoRetornado { get; set; }
    }
}
