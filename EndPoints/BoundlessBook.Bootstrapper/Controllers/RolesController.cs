using BoundlessBook.Application.Roles.Create;
using BoundlessBook.Application.Roles.Edit;
using BoundlessBook.Bootstrapper.Infrastructure.Security;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate.Enums;
using BoundlessBook.Presentation.Facade.Roles;
using BoundlessBook.Query.Roles.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [PermissionChecker(Permission.Role_Management)]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleFacade _roleFacade;

        public RolesController(IRoleFacade roleFacade)
        {
            _roleFacade = roleFacade;
        }

        [HttpGet]
        public async Task<List<RoleDto>> GetRoles()
        {
            return await _roleFacade.GetRoles();
        }

        [HttpGet("{id}")]
        public async Task<RoleDto> GetRoleById(Guid id)
        {
            return await _roleFacade.GetRoleById(id);
        }

        [HttpPost]
        public async Task<OperationResult> CreateRole(CreateRoleCommand command)
        {
            return await _roleFacade.Create(command);
        }

        [HttpPut]
        public async Task<OperationResult> EditRole(EditRoleCommand command)
        {
            return await _roleFacade.Edit(command);
        }

    }
}
