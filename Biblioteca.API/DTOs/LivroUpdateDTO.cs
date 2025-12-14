namespace Biblioteca.API.DTOs
{
    public class LivroUpdateDTO
    {
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public bool EstaDisponivel { get; set; }
    }
}
