using AutoMapper;
using galdino.funcional.api.Controllers.Base;
using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.api.Models.ModelView.Products;
using galdino.funcional.api.Models.Token;
using galdino.funcional.api.Models.ViewModel.Products;
using galdino.funcional.application.Interface.Service.Log;
using galdino.funcional.application.Interface.Service.Products;
using galdino.funcional.domain.core.Entity.Log;
using galdino.funcional.domain.core.Entity.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace galdino.funcional.api.Controllers.Product
{
	[ApiController]
	[Authorize]
	[Route("[controller]")]
	[EnableCors("SiteCorsPolicy")]
	[Produces("application/json")]
	public class ProductController : BaseController
	{
		#region .::Constructor
		private readonly IMapper _mapper;
		private readonly ILoggerAppService loggerService;
		public ProductController(IMapper mapper, ILoggerAppService loggerService)
		{
			_mapper = mapper;
			this.loggerService = loggerService;
		}
		#endregion


		#region .::Methods
		/// <summary>
		/// Retorna todos os produtos cadastrados.
		/// </summary>
		/// <response code="200">Historico de produtos</response>
		/// <response code="400">Se os parametros do metodo estiverem nulos</response> 
		/// <response code="401">Acesso negado</response> 
		/// <response code="409">Se alguma regra de negocio for violada</response> 
		/// <response code="500">Erro interno desconhecido</response> 
		[HttpGet]
		[Route("AllProducts")]
		[ProducesResponseType(typeof(BaseViewModel<TokenViewModel>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.Conflict)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.InternalServerError)]
		public async Task<IActionResult> GetAllProductsAsync(
			[FromServices] IProductsAppService productsAppService
			)
		{
			var search = await productsAppService.GetAllProductsAsync();
			var data = _mapper.Map<List<ProductsModelView>>(search);
			var returnModelView = new BaseViewModel<List<ProductsModelView>>
			{
				Sucesso = true,
				ObjetoDeRetorno = data
			};

			#region .::Log Requests
			loggerService.SaveLoggerSuccess(new LoggerDomain
			{
				objects = JsonConvert.SerializeObject(returnModelView),
				userId = UsuarioId
			});
			#endregion

			return Ok(returnModelView);
		}

		/// <summary>
		/// Retorna todos os produtos cadastrados para a determinada industria.
		/// </summary>
		/// <response code="200">Lsita de produtos</response>
		/// <response code="400">Se os parametros do metodo estiverem nulos</response> 
		/// <response code="401">Acesso negado</response> 
		/// <response code="409">Se alguma regra de negocio for violada</response> 
		/// <response code="500">Erro interno desconhecido</response> 
		[HttpPost]
		[Route("ProductsByIndustry")]
		[ProducesResponseType(typeof(BaseViewModel<TokenViewModel>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.Conflict)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.InternalServerError)]
		public async Task<IActionResult> GetProductsByIndustryAsync(
			string model,
			[FromServices] IProductsAppService productsAppService
			)
		{

			if (model is null || !ModelState.IsValid)
				return BadRequest(ModelState);

			//var data = _mapper.Map<ProductsDomain>(model);
			var search = await productsAppService.GetProductsByIndustryAsync(model);
			var dataReturn = _mapper.Map<List<ProductsModelView>>(search);
			var returnModelView = new BaseViewModel<List<ProductsModelView>>
			{
				Sucesso = true,
				Mensagem = dataReturn.Count <= 0 ? "Não encontramos nenhum produto com esta descrição" : "Tai seus produtos",
				ObjetoDeRetorno = dataReturn
			};

			#region .::Log Requests
			loggerService.SaveLoggerSuccess(new LoggerDomain
			{
				objects = JsonConvert.SerializeObject(returnModelView),
				userId = UsuarioId
			});
			#endregion

			return Ok(returnModelView);
		}
		/// <summary>
		/// Alterar produto.
		/// </summary>
		/// <response code="200">Produto alterado com sucesso</response>
		/// <response code="400">Se os parametros do metodo estiverem nulos</response> 
		/// <response code="401">Acesso negado</response> 
		/// <response code="409">Se alguma regra de negocio for violada</response> 
		/// <response code="500">Erro interno desconhecido</response> 
		[HttpPut]
		[Route("ProductUpdate")]
		[ProducesResponseType(typeof(BaseViewModel<TokenViewModel>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.Conflict)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.InternalServerError)]

		public async Task<IActionResult> ProductUpdateAsync(
			[FromBody]ProductsViewModel model,
			[FromServices] IProductsAppService productsAppService
			)
		{
			if (model is null || !ModelState.IsValid)
				return BadRequest(ModelState);

			var data = _mapper.Map<ProductsDomain>(model);
			var search = await productsAppService.ProductyUpdateAsync(data);
			var dataReturn = _mapper.Map<ProductsModelView>(search);

			var returnModelView = new BaseViewModel<ProductsModelView>
			{
				Sucesso = true,
				Mensagem = dataReturn.Product_id != 0 ? "Produto alterado com sucesso." : "Não encontramos produto com este ID.",
				ObjetoDeRetorno = dataReturn
			};

			#region .::Log Requests
			loggerService.SaveLoggerSuccess(new LoggerDomain
			{
				objects = JsonConvert.SerializeObject(returnModelView),
				userId = UsuarioId
			});
			#endregion

			return Ok(returnModelView);
		}

		/// <summary>
		/// Criar um produto.
		/// </summary>
		/// <response code="200">Produto criado com sucesso</response>
		/// <response code="400">Se os parametros do metodo estiverem nulos</response> 
		/// <response code="401">Acesso negado</response> 
		/// <response code="409">Se alguma regra de negocio for violada</response> 
		/// <response code="500">Erro interno desconhecido</response> 
		[HttpPost]
		[Route("ProductCreate")]
		[ProducesResponseType(typeof(BaseViewModel<TokenViewModel>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.Conflict)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.InternalServerError)]

		public async Task<IActionResult> ProductCreateAsync(
			[FromBody] IList<ProductsViewModel> model,
			[FromServices] IProductsAppService productsAppService
			)
		{
			if (model is null || !ModelState.IsValid)
				return BadRequest(ModelState);

			var data = _mapper.Map<IList<ProductsDomain>>(model);
			var search = await productsAppService.ProductyCreateAsync(data);
			var dataReturn = _mapper.Map<List<ProductsModelView>>(search);

			var returnModelView = new BaseViewModel<List<ProductsModelView>>
			{
				Sucesso = true,
				Mensagem = dataReturn.Count > 0 ? "Produto criado com sucesso." : "Não foi possivel criar o produto.",
				ObjetoDeRetorno = dataReturn
			};

			#region .::Log Requests
			loggerService.SaveLoggerSuccess(new LoggerDomain
			{
				objects = JsonConvert.SerializeObject(returnModelView),
				userId = UsuarioId
			});
			#endregion

			return Ok(returnModelView);
		}


		/// <summary>
		/// Deletar um produto.
		/// </summary>
		/// <response code="200">Produto deletado com sucesso</response>
		/// <response code="400">Se os parametros do metodo estiverem nulos</response> 
		/// <response code="401">Acesso negado</response> 
		/// <response code="409">Se alguma regra de negocio for violada</response> 
		/// <response code="500">Erro interno desconhecido</response> 
		[HttpDelete]
		[Route("ProductDelete")]
		[ProducesResponseType(typeof(BaseViewModel<TokenViewModel>), (int)HttpStatusCode.OK)]
		[ProducesResponseType((int)HttpStatusCode.BadRequest)]
		[ProducesResponseType((int)HttpStatusCode.Unauthorized)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.Conflict)]
		[ProducesResponseType(typeof(BaseViewModel<ErroViewModel>), (int)HttpStatusCode.InternalServerError)]

		public async Task<IActionResult> ProductDeleteAsync(
			 int model,
			[FromServices] IProductsAppService productsAppService
			)
		{
			if (model is 0 || !ModelState.IsValid)
				return BadRequest(ModelState);

			var search = await productsAppService.ProductyDeleteAsync(model);

			var returnModelView = new BaseViewModel<bool>
			{
				Sucesso = true,
				Mensagem = search ? "Produto deletado com sucesso." : "Não foi possivel deletar o produto.",

			};

			#region .::Log Requests
			loggerService.SaveLoggerSuccess(new LoggerDomain
			{
				objects = JsonConvert.SerializeObject(returnModelView),
				userId = UsuarioId
			});
			#endregion

			return Ok(returnModelView);
		}
		#endregion
	}
}