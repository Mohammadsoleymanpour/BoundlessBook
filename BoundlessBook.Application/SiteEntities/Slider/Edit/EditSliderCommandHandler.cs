using BoundlessBook.Common.Common.Application;
using BoundlessBook.Common.Common.Application.FileUtil.Interfaces;
using BoundlessBook.Common.Common.Application.Utilities;
using BoundlessBook.Domain.SiteEntities.Repositories;

namespace BoundlessBook.Application.SiteEntities.Slider.Edit;

public class EditSliderCommandHandler:IBaseCommandHandler<EditSliderCommand>
{
    private readonly ISliderRepository _sliderRepository;
    private readonly IFileService _fileService;

    public EditSliderCommandHandler(ISliderRepository sliderRepository, IFileService fileService)
    {
        _sliderRepository = sliderRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
    {
        var currentSlider = await _sliderRepository.GetTracking(request.SliderId);
        if (currentSlider==null)
        {
            return OperationResult.NotFound();
        }

        string imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.SiteSlider);

        _fileService.DeleteFile(Directories.SiteSlider,currentSlider.ImageName);

        currentSlider.Edit(request.Link,imageName,request.Title);
        await _sliderRepository.Save();
        return OperationResult.Success();
    }
}