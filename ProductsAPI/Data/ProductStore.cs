using ProductsAPI.Models.Dto;

namespace ProductsAPI.Data
{
    public class ProductStore
    {
        public static List<ProductDTO> productList = new List<ProductDTO> {
                new ProductDTO { Id = 1, Name="Teste1"},
                new ProductDTO { Id = 2, Name="Teste2"}
            };
    }
}
