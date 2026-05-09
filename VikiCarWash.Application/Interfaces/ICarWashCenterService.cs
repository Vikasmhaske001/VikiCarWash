using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VikiCarWash.Application.DTOs;

namespace VikiCarWash.Application.Interfaces
{
    public interface ICarWashCenterService
    {
        Task<CenterResponseDTO> CreateAsync(CreateCenterDTO dto, int ownerId);
        Task<List<CenterResponseDTO>> GetAllAsync();
        Task<List<CenterResponseDTO>> GetByCityAsync(string city);
        Task<List<CenterResponseDTO>> GetMyCentersAsync(int ownerId);
        Task<CenterResponseDTO> UpdateAsync(int id, UpdateCenterDTO dto, int ownerId);
    }
}
