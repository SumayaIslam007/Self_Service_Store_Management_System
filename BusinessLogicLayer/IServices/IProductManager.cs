using BusinessLogicLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IServices
{
    public interface IProductManager
    {
        List<ProductDto> GetAllProducts();
        ProductDto GetProductById(int id);
        void AddProduct(ProductDto productDto);
        void UpdateProduct(ProductDto productDto);
        void DeleteProduct(int id);
    }
}
