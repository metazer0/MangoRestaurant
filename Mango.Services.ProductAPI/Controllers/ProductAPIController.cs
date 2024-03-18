using Mango.Services.ProductAPI.Model.DTOs;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : Controller
    {
        private readonly IProductRepository _productRepository;
        protected ResponseDTO? _response;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var productDTOs = await _productRepository.GetProducts();
                _response!.Result = productDTOs;
            }catch (Exception ex)
            {
                _response!.Success = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return Ok(_response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var productDTO = await _productRepository.GetProductById(id);
                _response!.Result = productDTO;
            }
            catch (Exception ex)
            {
                _response!.Success = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return Ok(_response);
        }

        [HttpPost]
        public async Task<object> Post(ProductDTO productDto)
        {
            try
            {
                var product = await _productRepository.CreateUpdateProduct(productDto);
                _response!.Result = product;
            }catch (Exception ex)
            {
                _response!.Success = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpPut]
        public async Task<object> Put(ProductDTO productDto)
        {
            try
            {
                var product = await _productRepository.CreateUpdateProduct(productDto);
                _response!.Result = product;
            }
            catch (Exception ex)
            {
                _response!.Success = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpDelete]
        public async Task<object> Delete(int id)
        {
            try
            {
                var product = await _productRepository.DeleteProduct(id);
                _response!.Result = product;
            }
            catch (Exception ex)
            {
                _response!.Success = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }
    }
}
