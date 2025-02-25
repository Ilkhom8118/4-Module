using AutoMapper;
using CarRendalSystem.Bll.DTOs;
using CarRendalSystem.Bll.Validators;
using CarRendalSystem.Dal.Entities;
using CarRendalSystem.Repoistory.Services;
using FluentValidation;

namespace CarRendalSystem.Bll.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepo CarRepo;
        private readonly IMapper Mapper;
        private IValidator<CarCreateDto> CarCreateDtoValidator;
        private IValidator<CarUpdateDto> CarUpdateDtoValidator;
        public CarService(ICarRepo carRepo, IMapper mapper, IValidator<CarCreateDto> carCreateDtoValidator, IValidator<CarUpdateDto> carUpdateDtoValidator)
        {
            CarRepo = carRepo;
            Mapper = mapper;
            CarCreateDtoValidator = carCreateDtoValidator;
            CarUpdateDtoValidator = carUpdateDtoValidator;
        }

        public async Task<Car> AddAsync(CarCreateDto obj)
        {
            var validator = await CarCreateDtoValidator.ValidateAsync(obj);
            if (validator.IsValid == false)
            {
                throw new ValidationException($"{string.Join(',', validator.Errors)}");
            }
            var c = Mapper.Map<Car>(obj);
            return await CarRepo.AddAsync(c);

        }

        public async Task DeleteAsync(long id)
        {
            if (id < 0)
            {
                throw new Exception($"Not found Id : {id} ");
            }
            await CarRepo.DeleteAsync(id);
        }

        public async Task<ICollection<CarGetDto>> GetAllAsync()
        {
            var all = await CarRepo.GetAllAsync();
            return all.Select(cp => Mapper.Map<CarGetDto>(cp)).ToList();
            
        }

        public async Task<CarGetDto> GetByIdAsync(long id)
        {
            var byId = await CarRepo.GetByIdAsync(id);
            if (byId == null)
            {
                throw new Exception("Not found By Id");
            }
            return Mapper.Map<CarGetDto>(byId);
            
        }

        public async Task UpdateAsync(CarUpdateDto obj)
        {
            var validator = await CarUpdateDtoValidator.ValidateAsync(obj);
            if (validator.IsValid == false)
            {
                throw new ValidationException($"{string.Join(',', validator.Errors)}");
            }
            var byId = await CarRepo.GetByIdAsync(obj.Id);
            if (byId == null)
            {
                throw new Exception("Not found By Id");
            }
            var c = Mapper.Map(obj, byId);
            await CarRepo.UpdateAsync(c);
        }
    }
}
