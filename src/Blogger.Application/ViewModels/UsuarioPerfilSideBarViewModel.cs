namespace Blogger.Application.ViewModels;

public class UsuarioPerfilSideBarViewModel
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int IdPerfil { get; set; }
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
    public DateTime CriadoEm { get; set; }
    public IEnumerable<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
    public IEnumerable<ExpertiseViewModel> Expertises { get; set; } = new List<ExpertiseViewModel>();
    public AvaliacaoGeralViewModel AvaliacaoGeral { get; set; } = new AvaliacaoGeralViewModel();
    public ProjetosEstastisticasViewModel ProjetosEstastisticas { get; set; } = new ProjetosEstastisticasViewModel();
    public string Observacao { get; set; }
}