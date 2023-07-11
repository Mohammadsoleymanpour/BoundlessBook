using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.FileUtil.Interfaces;
using BoundlessBook.Common.Common.Application.Utilities;
using BoundlessBook.Domain.UserAggregate.Repository;
using BoundlessBook.Domain.UserAggregate.Services;

namespace BoundlessBook.Application.Users.Edit;

public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserDomainService _userDomainService;
    private readonly IFileService _fileService;

    public EditUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService, IFileService fileService)
    {
        _userRepository = userRepository;
        _userDomainService = userDomainService;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = await _userRepository.GetTracking(request.UserId);
        if (currentUser == null)
        {
            return OperationResult.NotFound();
        }

        if (currentUser.AvatarName != "avatar.png")
        {
            _fileService.DeleteFile(Directories.UserAvatar, currentUser.AvatarName);
        }
        var avatarName = await _fileService.SaveFileAndGenerateName(request.AvatarFile, Directories.UserAvatar);

        currentUser.EditUser(request.Name, request.Family, request.PhoneNumber, request.Email, avatarName,
            request.Gender, _userDomainService);

        await _userRepository.Save();
        return OperationResult.Success();
    }
}