using BoundlessBook.Application.Products.AddImage;
using BoundlessBook.Application.Products.Create;
using BoundlessBook.Application.Products.Edit;
using BoundlessBook.Application.Products.RemoveImage;
using BoundlessBook.Bootstrapper.Infrastructure.Security;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate.Enums;
using BoundlessBook.Presentation.Facade.Products;
using BoundlessBook.Query.Products.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [PermissionChecker(Permission.Product_Menagement)]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductFacade _productFacade;

        public ProductsController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ProductFilterResult> GetProduct([FromQuery]ProductFilterParams filterParams)
        {
            return await _productFacade.GetByFilter(filterParams);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProductById(Guid id)
        {
            return await _productFacade.GetById(id);
        }
        [AllowAnonymous]
        [HttpGet("GetBySlug/{slug}")]
        public async Task<ProductDto> GetProductBySlug(string slug)
        {
            return await _productFacade.GetBySlug(slug);
        }

        [HttpPost]
        public async Task<OperationResult<Guid>> CreateProduct([FromForm]CreateProductCommand command)
        {
            return await _productFacade.Create(command);
        }

        [HttpPut]
        public async Task<OperationResult> EditProduct([FromForm] EditProductCommand command)
        {
            return await _productFacade.Edit(command);
        }

        [HttpPost("Images/Add")]
        public async Task<OperationResult> AddProductImage(AddProductImageCommand command)
        {
            return await _productFacade.AddImage(command);
        }

        [HttpDelete("Image/Remove")]
        public async Task<OperationResult> RemoveImage(RemoveProductImageCommand command)
        {
            return await _productFacade.RemoveImage(command);
        }



    }
}
