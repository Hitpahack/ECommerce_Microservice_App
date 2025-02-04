namespace ShoppingCart.UI.Services
{
    public interface IProductService
    {
        Task<T> GetAllProducts<T>();
    }
}
