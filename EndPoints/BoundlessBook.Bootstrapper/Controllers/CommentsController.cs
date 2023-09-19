using BoundlessBook.Application.Comments.ChangeStatus;
using BoundlessBook.Application.Comments.Create;
using BoundlessBook.Application.Comments.Edit;
using BoundlessBook.Bootstrapper.Infrastructure.Security;
using BoundlessBook.Common.Common.Application;
using BoundlessBook.Domain.RoleAggregate.Enums;
using BoundlessBook.Presentation.Facade.Comments;
using BoundlessBook.Query.Comments.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoundlessBook.Bootstrapper.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentFacade _commentFacade;

        public CommentsController(ICommentFacade commentFacade)
        {
            _commentFacade = commentFacade;
        }

        [PermissionChecker(Permission.Comment_Management)]
        [HttpGet]
        public async Task<CommentFilterResult> Get(CommentFilterParams filterParams)
        {
            return await _commentFacade.GetByFilter(filterParams);
        }

        [PermissionChecker(Permission.Comment_Management)]
        [HttpGet("{id}")]
        public async Task<CommentDto> Get(Guid id)
        {
            return await _commentFacade.GetById(id);
        }

        [HttpPost]
        public async Task<OperationResult> Create(CreateCommentCommand command)
        {
            return await _commentFacade.Create(command);
        }

        [HttpPut]
        public async Task<OperationResult> Edit(EditCommentCommand command)
        {
            return await _commentFacade.Edit(command);
        }

        [PermissionChecker(Permission.Comment_Management)]
        [HttpPut("ChangeStatus")]
        public async Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command)
        {
            return await _commentFacade.ChangeStatus(command);
        }


    }
}
