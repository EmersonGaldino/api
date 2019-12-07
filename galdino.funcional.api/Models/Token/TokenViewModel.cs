using System;

namespace galdino.funcional.api.Models.Token
{
    public class TokenViewModel
	{
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Autenticado { get; set; }
        public DateTime Criacao { get; set; }
        public DateTime Expira { get; set; }
        public string Token { get; set; }
        public int EmpresaId { get; set; }
    }
}
