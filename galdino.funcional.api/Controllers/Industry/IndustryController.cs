using AutoMapper;
using galdino.funcional.api.Controllers.Base;
using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.api.Models.Token;
using galdino.funcional.application.Interface.Service.Log;
using galdino.funcional.domain.shared.Interfaces.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace galdino.funcional.api.Controllers.Industry
{
	[ApiController]
	[Authorize]
	[Route("[controller]")]
	[EnableCors("SiteCorsPolicy")]
	[Produces("application/json")]
	public class IndustryController : BaseController
	{
		#region .::Constructor
		private readonly IMapper _mapper;
		private readonly ILoggerAppService loggerService;
		private readonly IMessaging messages;
		public IndustryController(IMapper mapper, ILoggerAppService loggerService, IMessaging messages)
		{
			_mapper = mapper;
			this.loggerService = loggerService;
			this.messages = messages;
		}
		#endregion

		#region .::Methods
		/// <summary>
		/// Retorna todos as industrias cadastradas.
		/// </summary>
		/// <response code="200">Historico de produtos</response>
		/// <response code="400">Se os parametros do metodo estiverem nulos</response> 
		/// <response code="401">Acesso negado</response> 
		/// <response code="409">Se alguma regra de negocio for violada</response> 
		/// <response code="500">Erro interno desconhecido</response> 
		[HttpGet]
		[Route("AllIndustry")]
		[ProducesResponseType(typeof(BaseViewModel<TokenViewModel>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.Conflict)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.InternalServerError)]
		public async Task<IActionResult> GetAllindustry()
		{

			return Ok();
		}

		#endregion
	}
}