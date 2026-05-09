using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VikiCarWash.Application.DTOs;
using VikiCarWash.Application.Interfaces;
using VikiCarWash.Domain.Entities;

namespace VikiCarWash.Infrastructure.Repositories
{
    public class CarWashCenterService : ICarWashCenterService
    {
        private readonly ICarWashCenterRepository _repository;

        public CarWashCenterService(ICarWashCenterRepository repository)
        {
            _repository = repository;
        }

        public async Task<CenterResponseDTO> CreateAsync(CreateCenterDTO dto, int ownerId)
        {
            var center = new CarWashCenter
            {
                Name = dto.Name,
                Location = dto.Location,
                Address = dto.Address,
                City = dto.City,
                PhoneNumber = dto.PhoneNumber,
                Rating = 0,
                IsActive = true,
                OwnerId = ownerId
            };

            await _repository.AddAsync(center);

            var saved = await _repository.GetByIdAsync(center.Id);

            return new CenterResponseDTO
            {
                Id = saved.Id,
                Name = saved.Name,
                Location = saved.Location,
                Address = saved.Address,
                City = saved.City,
                PhoneNumber = saved.PhoneNumber,
                Rating = saved.Rating,
                IsActive = saved.IsActive,
                OwnerName = saved.Owner?.Name
            };
        }

        public async Task<List<CenterResponseDTO>> GetAllAsync()
        {
            var centers = await _repository.GetAllAsync();

            return centers.Select(x => new CenterResponseDTO
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
                Address = x.Address,
                City = x.City,
                PhoneNumber = x.PhoneNumber,
                Rating = x.Rating,
                IsActive = x.IsActive,
                OwnerName = x.Owner?.Name
            }).ToList();
        }

        public async Task<List<CenterResponseDTO>> GetByCityAsync(string city)
        {
            var centers = await _repository.GetByCityAsync(city);

            return centers.Select(x => new CenterResponseDTO
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
                Address = x.Address,
                City = x.City,
                PhoneNumber = x.PhoneNumber,
                Rating = x.Rating,
                IsActive = x.IsActive,
                OwnerName = x.Owner?.Name
            }).ToList();
        }

        public async Task<List<CenterResponseDTO>> GetMyCentersAsync(int ownerId)
        {
            var centers = await _repository.GetByOwnerIdAsync(ownerId);

            return centers.Select(x => new CenterResponseDTO
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
                Address = x.Address,
                City = x.City,
                PhoneNumber = x.PhoneNumber,
                Rating = x.Rating,
                IsActive = x.IsActive,
                OwnerName = null
            }).ToList();
        }

        public async Task<CenterResponseDTO> UpdateAsync(int id, UpdateCenterDTO dto, int ownerId)
        {
            var center = await _repository.GetByIdAsync(id);

            if (center == null)
                throw new Exception("Center not found");

            if (center.OwnerId != ownerId)
                throw new UnauthorizedAccessException("You do not own this center");

            center.Name = dto.Name;
            center.Location = dto.Location;
            center.Address = dto.Address;
            center.City = dto.City;
            center.PhoneNumber = dto.PhoneNumber;
            center.IsActive = dto.IsActive;

            await _repository.UpdateAsync(center);

            return new CenterResponseDTO
            {
                Id = center.Id,
                Name = center.Name,
                Location = center.Location,
                Address = center.Address,
                City = center.City,
                PhoneNumber = center.PhoneNumber,
                Rating = center.Rating,
                IsActive = center.IsActive,
                OwnerName = center.Owner?.Name
            };
        }
    }
}