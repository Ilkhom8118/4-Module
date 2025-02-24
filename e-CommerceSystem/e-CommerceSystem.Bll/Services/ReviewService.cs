using AutoMapper;
using e_CommerceSystem.Bll.DTOs;
using e_CommerceSystem.Bll.Validators;
using e_CommerceSystem.Repoistory.Service;
using e_CommerceSystem_.Dal.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace e_CommerceSystem.Bll.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepo ReviewRepo;
    private readonly IMapper Mapper;
    private readonly IValidator<ReviewCreateDto> ReviewCreateDtoValidator;
    private readonly IValidator<ReviewUpdateDto> ReviewUpdateDtoValidator;


    public ReviewService(IReviewRepo reviewRepo, IMapper mapper, IValidator<ReviewCreateDto> reviewCreateDtoValidator, IValidator<ReviewUpdateDto> reviewUpdateDtoValidator)
    {
        ReviewRepo = reviewRepo;
        Mapper = mapper;
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
        var review = Mapper.Map<Review>(obj);
        return await ReviewRepo.AddAsync(review);
    }

    public async Task DeleteAsync(long id)
    {
        if (id < 0)
        {
            throw new Exception("Not found Id");
        }
        await ReviewRepo.DeleteAsync(id);
    }

    public async Task<ICollection<ReviewDto>> GetAllAsync()
    {
        var all = ReviewRepo.GetAll();
        var res = await all.ToListAsync();
        return res.Select(p => Mapper.Map<ReviewDto>(p)).ToList();
        
    }

    public async Task<ReviewDto> GetByIdAsync(long id)
    {
        var byId = await ReviewRepo.GetByIdAsync(id);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        return Mapper.Map<ReviewDto>(byId);
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
        var review = Mapper.Map(obj, byId);
        await ReviewRepo.UpdateAsync(review);
        
    }
}
