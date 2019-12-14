using galdino.funcional.domain.shared.Interfaces.Message;

namespace galdino.funcional.utils.Messages.message
{
	public class Messaging : IMessaging
	{
		#region .::Constructor
		private string message;

		public Messaging(string message)
		{
			this.message = message;
		}
		#endregion

		#region .::Methods
		public string INDUSTRY_NOT_FOUND() =>
			"Não encontramos nenhuma industria com esta descrição";

		public string PRODUCTS_RESULT() =>
			"Produtos encontrados no nosso estoque.";

		public string PRODUCT_CREATE_FAIL() =>
			"Não foi possivel criar o produto.";

		public string PRODUCT_CREATE_SUCCESS() =>
			"Produto criado com sucesso.";

		public string PRODUCT_DELETED_FAIL() =>
			"Não foi possivel deletar o produto.";

		public string PRODUCT_DELETED_SUCCESS() =>
		"Produto deletado com sucesso.";

		public string PRODUCT_UPDATE_FAIL() =>
			 "Não encontramos produto com este ID.";

		public string PRODUCT_UPDATE_SUCCESS() =>
			"Produto alterado com sucesso.";


		#endregion


	}
}
