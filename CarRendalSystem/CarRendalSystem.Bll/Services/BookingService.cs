using AutoMapper;
using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Dal.Entities;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Services;


public class BookingService : IBookingService
{
    private readonly IBookingRepo BookingRepo;
    private readonly IMapper Mapper;
    private readonly IValidator<BookingCreateDto> BookingCreateDtoValidator;
    private readonly IValidator<BookingUpdateDto> BookingUpdateDtoValidator;

    public BookingService(IBookingRepo bookingRepo, IMapper mapper, IValidator<BookingCreateDto> bookingCreateDtoValidator, IValidator<BookingUpdateDto> bookingUpdateDtoValidator)
    {
        BookingRepo = bookingRepo;
        Mapper = mapper;
        BookingCreateDtoValidator = bookingCreateDtoValidator;
        BookingUpdateDtoValidator = bookingUpdateDtoValidator;
    }

    public async Task<Booking> AddAsync(BookingCreateDto obj)
    {
        var validator = await BookingCreateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var cp = Mapper.Map<Booking>(obj);
        return await BookingRepo.AddAsync(cp);

    }

    public async Task DeleteAsync(long id)
    {
        if (id < 0)
        {
            throw new Exception($"Not found Id : {id} ");
        }
        await BookingRepo.DeleteAsync(id);

    }

    public async Task<ICollection<BookingGetDto>> GetAllAsync()
    {
        var all = await BookingRepo.GetAllAsync();
        return all.Select(cp => Mapper.Map<BookingGetDto>(cp)).ToList();

    }

    public async Task<BookingGetDto> GetByIdAsync(long id)
    {
        var byId = await BookingRepo.GetByIdAsync(id);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        return Mapper.Map<BookingGetDto>(byId);

    }

    public async Task UpdateAsync(BookingUpdateDto obj)
    {
        var validator = await BookingUpdateDtoValidator.ValidateAsync(obj);
        if (validator.IsValid == false)
        {
            throw new ValidationException($"{string.Join(',', validator.Errors)}");
        }
        var byId = await BookingRepo.GetByIdAsync(obj.Id);
        if (byId == null)
        {
            throw new Exception("Not found By Id");
        }
        var b = Mapper.Map(obj, byId);
        await BookingRepo.UpdateAsync(b);

    }
}
