namespace Blogger.Application.ViewModels;

public class UsuarioGerenciamentoListViewModel
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public PerfilViewModel Perfil { get; set; }
    public int Status { get; set; }

    public string StatusNome
    {
        get
        {
            return Status switch
            {
                0 => "Inativo",
                1 => "Ativo",
                2 => "PendenteAtivacao",
                _ => ""
            };
        }
    }

    public int StatusAtual { get; set; }
    public string StatusAtualNome
    {
        get
        {
            return Status switch
            {
                0 => "Inativo",
                1 => "Online",
                2 => "Ausente",
                _ => ""
            };
        }
    }
    public bool Excluido { get; set; }
    public bool ExcluidoPermanente { get; set; }
    public DateTime CriadoEm { get; set; }
    public IEnumerable<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
}