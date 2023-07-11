using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.FileUtil.Interfaces;
using BoundlessBook.Common.Common.Application.Utilities;
using BoundlessBook.Domain.SiteEntities.Repositories;

namespace BoundlessBook.Application.SiteEntities.Banner.Edit;

public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
{
    private readonly IBannerRepository _bannerRepository;
    private readonly IFileService _fileService;

    public EditBannerCommandHandler(IBannerRepository bannerRepository, IFileService fileService)
    {
        _bannerRepository = bannerRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
    {
        var currentBanner = await _bannerRepository.GetTracking(request.BannerId);
        if (currentBanner == null)
        {
            return OperationResult.NotFound();
        }

        _fileService.DeleteFile(Directories.SiteBanners, currentBanner.ImageName);
        string imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SiteBanners);

        currentBanner.Edit(request.Link, imageName, request.BannerPosition);
        await _bannerRepository.Save();
        return OperationResult.Success();
    }
}