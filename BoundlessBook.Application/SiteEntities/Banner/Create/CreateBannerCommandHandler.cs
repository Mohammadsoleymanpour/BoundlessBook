using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.FileUtil.Interfaces;
using BoundlessBook.Common.Common.Application.Utilities;
using BoundlessBook.Domain.SiteEntities.Repositories;

namespace BoundlessBook.Application.SiteEntities.Banner.Create;

public class CreateBannerCommandHandler:IBaseCommandHandler<CreateBannerCommand>
{
    private readonly IBannerRepository _bannerRepository;
    private readonly IFileService _fileService;

    public CreateBannerCommandHandler(IBannerRepository bannerRepository, IFileService fileService)
    {
        _bannerRepository = bannerRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SiteBanners);

        var banner = new Domain.SiteEntities.Banner(request.Link, imageName, request.BannerPosition);
        await _bannerRepository.AddAsync(banner);
        await _bannerRepository.Save();
        return OperationResult.Success();
    }
}