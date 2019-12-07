using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.domain.core.Entity.User;
using System.ComponentModel.DataAnnotations;

namespace galdino.funcional.api.Models.ViewModel.User
{
    public class UserViewModel : IViewModel<UserDomain>
    {
        /// <summary>
        /// Seu usuário do sistema
        /// </summary>
        /// <example>meu.usuario</example>
        [Required]
        public string Login { get; set; }
        /// <summary>
        /// Sua senha cadastrada no sistema
        /// </summary>
        /// <example>minha.senha</example>
        [Required]
        public string Password { get; set; }
    }
}
