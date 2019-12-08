using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.api.Models.Token;
using galdino.funcional.api.Models.ViewModel.User;
using galdino.funcional.api.Security;
using galdino.funcional.application.Interface.Service.Log;
using galdino.funcional.application_2.Interface.Service.User;
using galdino.funcional.domain.core.Entity.User;
using galdino.funcional.domain.shared.Configurations.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace galdino.funcional.api.Controllers.Auth
{
	[ApiController]
	[AllowAnonymous]
	[Route("[controller]")]
	[EnableCors("SiteCorsPolicy")]
	[Produces("application/json")]
	public class AuthenticationController : ControllerBase
	{
		#region .::Constructor
		private IMapper _mapper;
		public AuthenticationController(IMapper mapper)
		{
			_mapper = mapper;
		}
		#endregion

		/// <summary>
		/// Retorna token de acesso ao usuario se o mesmo for validado corretamente
		/// </summary>
		/// <response code="200">Token de acesso a aplicacao</response>
		/// <response code="400">Se os parametros do metodo estiverem nulos</response> 
		/// <response code="401">Acesso negado</response> 
		/// <response code="409">Se alguma regra de negocio for violada</response> 
		/// <response code="500">Erro interno desconhecido</response> 
		[HttpPost]
		[Route("SigIn")]
		[ProducesResponseType(typeof(BaseViewModel<TokenViewModel>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.Conflict)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.InternalServerError)]
		public async Task<IActionResult> Login(
			[FromBody] UserViewModel usuario,
			[FromServices]TokenConfigurations tokenConfiguration,
			[FromServices]SignConfigurationToken signinConfiguration,
			[FromServices]IUserAppService usuarioAppService,
			[FromServices] ILoggerAppService loggerService)
		{
			if (usuario is null || !ModelState.IsValid)
				return BadRequest(ModelState);

			var objRetorno = new BaseViewModel<TokenViewModel>();

			var viewModel = _mapper.Map<UserDomain>(usuario);

			var userBase = await usuarioAppService.ValidarUsuarioAsync(viewModel);
			if (userBase != null)
			{
				var identity = new ClaimsIdentity(
					new GenericIdentity(userBase.Login, "Login"),
					new[]
					{
						new Claim(JwtRegisteredClaimNames.Jti, userBase.UserId.ToString()),
						new Claim(JwtRegisteredClaimNames.UniqueName, userBase.Email),
						new Claim("CompanyId",userBase.CompanyId.ToString())
					}
				);

				var dateCreate = DateTime.Now;
				var dateExpired = dateCreate + TimeSpan.FromDays(tokenConfiguration.ExpireIn);

				var handler = new JwtSecurityTokenHandler();

				var securityToken = handler.CreateToken(new SecurityTokenDescriptor
				{
					Issuer = tokenConfiguration.Issuer,
					Audience = tokenConfiguration.Audience,
					Subject = identity,
					NotBefore = dateCreate,
					Expires = dateExpired,

					SigningCredentials = new SigningCredentials(
						new SymmetricSecurityKey(
							Encoding.UTF8.GetBytes(tokenConfiguration.SigningKey)),
						SecurityAlgorithms.HmacSha256
					)
				});

				var token = handler.WriteToken(securityToken);
				objRetorno.ObjetoDeRetorno = new TokenViewModel()
				{
					UsuarioId = userBase.UserId,
					Nome = userBase.Name,
					Email = userBase.Email,
					Autenticado = true,
					Criacao = dateCreate,
					Expira = dateExpired,
					Token = token,
				};
				loggerService.SaveLogger(new domain.core.Entity.Log.LoggerDomain
				{
					objects = JsonConvert.SerializeObject(objRetorno.ObjetoDeRetorno),
					token = objRetorno.ObjetoDeRetorno.Token,
					userId = objRetorno.ObjetoDeRetorno.UsuarioId
				});
				return Ok(objRetorno);
			}

			return Unauthorized();
		}
	}
}