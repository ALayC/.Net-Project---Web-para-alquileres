using Obligatorio_MVC.Models;

namespace Obligatorio_MVC
{
    public interface IUsuarioService
    {
        Task Registrar(UsuarioViewModel usuario);

        Task<string> Login(UsuarioViewModel model);
    }
}
