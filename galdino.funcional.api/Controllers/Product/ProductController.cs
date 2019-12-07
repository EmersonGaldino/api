using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using galdino.funcional.api.Models.Interface.Base;
using galdino.funcional.api.Models.ModelView.Products;
using galdino.funcional.api.Models.Token;
using galdino.funcional.api.Models.ViewModel.Products;
using galdino.funcional.api.Security;
using galdino.funcional.application.Interface.Service.Products;
using galdino.funcional.domain.core.Entity.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace galdino.funcional.api.Controllers.Product
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    [EnableCors("SiteCorsPolicy")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        #region .::Constructor
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
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

            return Ok(returnModelView);
        }

        /// <summary>
        /// Retorna todos os produtos cadastrados para a determinada industria.
        /// </summary>
        /// <response code="200">Historico de produtos</response>
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
            [FromBody] ProductsViewModel model,
            [FromServices] IProductsAppService productsAppService
            )
        {

            if(model is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var data = _mapper.Map<ProductsDomain>(model);
            var search = await productsAppService.GetProductsByIndustryAsync(data);
            var dataReturn = _mapper.Map<List<ProductsModelView>>(search);
            var returnModelView = new BaseViewModel<List<ProductsModelView>>
            {
                Sucesso = true,
                ObjetoDeRetorno = dataReturn
            };

            return Ok(returnModelView);
        }


        #endregion
    }
}