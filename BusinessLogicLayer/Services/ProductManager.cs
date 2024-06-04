using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class ProductManager : IProductManager
    {
        private readonly ProductRepository _productRepository;
        private readonly EntityDtoTransformer _transformer;

        public ProductManager()
        {
            _productRepository = new ProductRepository();
            _transformer = new EntityDtoTransformer();
        }

        public List<ProductDto> GetAllProducts()
        {
            List<Product> products = _productRepository.GetAllProducts();
            List<ProductDto> productDtos = new List<ProductDto>();
            foreach (var product in products)
            {
                productDtos.Add(_transformer.TransformToProductDto(product));
            }
            return productDtos;
        }

        public ProductDto GetProductById(int id)
        {
            Product product = _productRepository.GetProductById(id);
            return _transformer.TransformToProductDto(product);
        }

        public void AddProduct(ProductDto productDto)
        {
            Product product = _transformer.TransformToProductEntity(productDto);
            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(ProductDto productDto)
        {
            Product product = _transformer.TransformToProductEntity(productDto);
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }
    }
}
