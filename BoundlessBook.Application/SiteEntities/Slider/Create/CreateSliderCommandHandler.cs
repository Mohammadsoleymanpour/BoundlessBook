using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.FileUtil.Interfaces;
using BoundlessBook.Common.Common.Application.Utilities;
using BoundlessBook.Domain.SiteEntities.Repositories;

namespace BoundlessBook.Application.SiteEntities.Slider.Create;

public class CreateSliderCommandHandler:IBaseCommandHandler<CreateSliderCommand>
{
    private readonly ISliderRepository _sliderRepository;
    private readonly IFileService _fileService;

    public CreateSliderCommandHandler(ISliderRepository sliderRepository, IFileService fileService)
    {
        _sliderRepository = sliderRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SiteSlider);

        var slider = new Domain.SiteEntities.Slider(request.Link, imageName, request.Title);
        await _sliderRepository.AddAsync(slider);
        await _sliderRepository.Save();
        return OperationResult.Success();
    }
}