using AutoMapper;
using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Services;

public class ReviewService : IReviewService
{
    private readonly IMapper Mapper;
    private readonly IReviewRepo ReviewRepo;
    private readonly IValidator<ReviewCreateDto> ReviewCreateDtoValidator;
    private readonly IValidator<ReviewUpdateDto> ReviewUpdateDtoValidator;

    public ReviewService(IMapper mapper, IReviewRepo reviewRepo, IValidator<ReviewCreateDto> reviewCreateDtoValidator, IValidator<ReviewUpdateDto> reviewUpdateDtoValidator)
    {
        Mapper = mapper;
        ReviewRepo = reviewRepo;
        ReviewCreateDtoValidator = reviewCreateDtoValidator;
        ReviewUpdateDtoValidator = reviewUpdateDtoValidator;
    }

    public async Task<Review> AddAsync(ReviewCreateDto obj)
    {
        var validator = await ReviewCreateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var c = Mapper.Map<Review>(obj);
        return await ReviewRepo.AddAsync(c);
    }

    public async Task DeleteAsync(long id)
    {
        if (id < 0)
        {
            throw new Exception($"Not found Id : {id} ");
        }
        await ReviewRepo.DeleteAsync(id);
    }

    public async Task<ICollection<ReviewGetDto>> GetAllAsync()
    {
        var all = await ReviewRepo.GetAllAsync();
        return all.Select(cp => Mapper.Map<ReviewGetDto>(cp)).ToList();
    }

    public async Task<ReviewGetDto> GetByIdAsync(long id)
    {
        var byId = await ReviewRepo.GetByIdAsync(id);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        return Mapper.Map<ReviewGetDto>(byId);
    }

    public async Task UpdateAsync(ReviewUpdateDto obj)
    {
        var validator = await ReviewUpdateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var byId = await ReviewRepo.GetByIdAsync(obj.Id);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        var c = Mapper.Map(obj, byId);
        await ReviewRepo.UpdateAsync(c);
    }
}