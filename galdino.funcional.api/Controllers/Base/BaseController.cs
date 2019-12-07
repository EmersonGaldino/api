using galdino.funcional.domain.core.Entity.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace galdino.funcional.api.Controllers.Base
{
    public class BaseController: ControllerBase
	{
        public int UsuarioId => Convert.ToInt32(User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value);
        public string UsuarioNome => User.Identity.Name;
        public string IP => Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        public int EmpresaId => Convert.ToInt32(User.FindFirst("company_id")?.Value);


        public UserDomain Usuario => new UserDomain
        {

            UserId = Convert.ToInt32(User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value),
            CompanyId = Convert.ToInt32(User.FindFirst("company_id")?.Value)
        };
    }
}
