namespace LojaNet.API.ViewModels
{
    public class ErroViewModel
    {
        public string Erro { get; set; }
        public string? Detalhes { get; set; }

        public ErroViewModel(string erro, string detalhes = null!)
        {
            Erro = erro;
            Detalhes = detalhes;
        }
    }
}
