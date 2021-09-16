using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;
        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }


        [HttpGet]
        public async Task<Object> Get()
        {
            try 
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errormessages = new List<string> { ex.ToString() };

            }
            return _response;
        }

        
        [HttpGet]
        [Route("{id}")]
        public async Task<Object> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _response.Result = productDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errormessages = new List<string> { ex.ToString() };

            }
            return _response;
        }

        [HttpPost]
        [Authorize]
        public async Task<Object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errormessages = new List<string> { ex.ToString() };

            }
            return _response;
        }

        [HttpPut]
        [Authorize]
        public async Task<Object> Put ([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errormessages = new List<string> { ex.ToString() };

            }
            return _response;
        }

        [HttpDelete]
        [Authorize(Roles ="Admin")]
        [Route("{id}")]
        public async Task<Object> Delete (int id)
        {
            try
            {
                bool isSucess = await _productRepository.DeleteProduct(id);
                _response.Result = isSucess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Errormessages = new List<string> { ex.ToString() };

            }
            return _response;
        }
    }
}
