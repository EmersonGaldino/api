namespace galdino.funcional.domain.shared.Interfaces.Message
{
	public interface IMessaging
	{
		string INDUSTRY_NOT_FOUND();
		string PRODUCTS_RESULT();
		string PRODUCT_UPDATE_SUCCESS();
		string PRODUCT_UPDATE_FAIL();
		string PRODUCT_CREATE_SUCCESS();
		string PRODUCT_CREATE_FAIL();
		string PRODUCT_DELETED_SUCCESS();
		string PRODUCT_DELETED_FAIL();
		string PRODUCTS_ALL_FAIL();
		string PRODUCTS_ALL_SUCCESS();
	}
}
