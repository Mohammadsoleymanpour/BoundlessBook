using BoundlessBook.Application.Categories.AddChild;
using BoundlessBook.Application.Categories.Create;
using BoundlessBook.Application.Categories.Edit;
using BoundlessBook.Application.Categories.Remove;
using BoundlessBook.Bootstrapper.Infrastructure.Security;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate.Enums;
using BoundlessBook.Presentation.Facade.Categories;
using BoundlessBook.Query.Categories.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [PermissionChecker(Permission.Category_Management)]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoriesController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            return await _categoryFacade.GetAll();
        }
        [AllowAnonymous]
        [HttpGet("/{id}")]
        public async Task<CategoryDto> Get(Guid id)
        {
            return await _categoryFacade.GetById(id);
        }

        [HttpGet("GetChildByParentId/{id}")]
        public async Task<List<ChildCategoryDto>> GetByParentId(Guid id)
        {
            return await _categoryFacade.GetByParentId(id);
        }

        [HttpPost]
        public async Task<OperationResult<Guid>> Create(CreateCategoryCommand command)
        {
            var result = await _categoryFacade.Create(command);

            return result;
        }

        [HttpPost("AddChild")]
        public async Task<OperationResult<Guid>> Create(AddCategoryChildCommand command)
        {
            var result = await _categoryFacade.AddChild(command);

            return result;
        } 

        [HttpPut]
        public async Task<OperationResult> Edit(EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);

            return result;
        }

        [HttpDelete]
        public async Task<OperationResult> Delete(RemoveCategoryCommand command)
        {
            var result = await _categoryFacade.remove(command);

            return result;
        }
    }
}
