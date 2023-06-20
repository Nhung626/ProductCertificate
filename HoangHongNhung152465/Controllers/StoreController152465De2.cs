using HoangHongNhung152465.Dtos.Product;
using HoangHongNhung152465.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HoangHongNhung152465.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController152465De2 : Controller
    {
        private readonly IProductService152465De2 _productService;

        public StoreController152465De2(IProductService152465De2 productService)
        {
            _productService = productService;
        }
        [HttpPost("create")]
        public IActionResult Create(CreateProductDto152465De2 input)
        {
            _productService.CreateProduct(input);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateProductDto152465De2 input)
        {
            _productService.UpdateProduct(input);
            return Ok();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll(string keyword, int page = 1, int pageSize = 10)
        {
            return Ok(_productService.GetAllProduct(page, pageSize, keyword));
        }

        //[HttpGet("get-supplier/{id}")]
        //public IActionResult GetById([Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0")] int id, int page = 1, int pageSize = 10)
        //{
        //    return Ok(_productService.GetMax(page,pageSize, id));
        //}
    }
}
