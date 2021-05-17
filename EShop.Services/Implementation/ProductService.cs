using EShop.Domain.Domain;
using EShop.Domain.DTO;
using EShop.Repository.Interface;
using EShop.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShop.Services.Implementation
{
    public class ProductService : IProductService
    {
        public readonly IRepository<Product> _productRepository;
        public readonly IRepository<ProductInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IRepository<Product> productRepository, ILogger<ProductService> logger, IRepository<ProductInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        { 
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _logger = logger;
        }

        public bool AddToShoppingCart(Domain.DTO.AddToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userShoppingCart = user.UserCart;

            if (item.selectedProductId != null && userShoppingCart != null)
            {

                var product = this.GetDetailsForProduct(item.selectedProductId);

                if (product != null)
                {
                    ProductInShoppingCart itemToAdd = new ProductInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        product = product,
                        ProductId = product.Id,
                        cart = userShoppingCart,
                        ShoppingCartId = userShoppingCart.Id,
                        Qantity = item.quantity
                    };

                    this._productInShoppingCartRepository.Insert(itemToAdd);
                    _logger.LogInformation("Product was succesfully added into Shopping Cart.");
                    return true;
                }
                return false;
            }
            _logger.LogInformation("Something went wrong.");
            return false;
        }

        public void CreateNewProduct(Product p)
        {
            //p.Id = Guid.NewGuid(); ova ne e potrebno bidejki samata app kje go naprai noviot id
            this._productRepository.Insert(p);
        }

        public void DeleteProduct(Guid id)
        {
            var product = this.GetDetailsForProduct(id);
            this._productRepository.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            _logger.LogInformation("GetAllProducts was called.");
            return this._productRepository.GetAll().ToList();
        }

        public Product GetDetailsForProduct(Guid? id)
        {
            return this._productRepository.Get(id);
        }

        public Domain.DTO.AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var product = this.GetDetailsForProduct(id);

            Domain.DTO.AddToShoppingCartDto model = new Domain.DTO.AddToShoppingCartDto
            {
                selectedProduct = product,
                selectedProductId = product.Id,
                quantity = 1
            };
            return model;
        }

        public void UpdeteExistingProduct(Product p)
        {
            this._productRepository.Update(p);
        }
    }
}
