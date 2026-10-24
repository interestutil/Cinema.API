using System.Collections.Generic;
using System.Linq;
using Cinema.BL.DTOs.Halls;
using Cinema.DAL.Models;
using Cinema.DAL.Repos.Halls;

namespace Cinema.BL.Services.Halls
{
    public class HallService : IHallService
    {
        private readonly IHallRepo _hallRepo;

        public HallService(IHallRepo hallRepo)
        {
            _hallRepo = hallRepo;
        }

        public IEnumerable<HallReadDTO> GetAllHalls()
        {
            return _hallRepo.GetAllHalls()
                .Select(MapToReadDto)
                .ToList();
        }

        public HallReadDTO? GetHallById(int id)
        {
            var hall = _hallRepo.GetHall(id);
            return hall == null ? null : MapToReadDto(hall);
        }

        public HallReadDTO AddHall(HallWriteDTO hallDto)
        {
            var hall = new Hall
            {
                Name = hallDto.Name,
                Capacity = hallDto.Capacity
            };

            _hallRepo.AddHall(hall);
            _hallRepo.SaveChanges();

            return MapToReadDto(hall);
        }

        public HallReadDTO? UpdateHall(int id, HallWriteDTO hallDto)
        {
            var existingHall = _hallRepo.GetHall(id);
            if (existingHall == null)
            {
                return null;
            }

            existingHall.Name = hallDto.Name;
            existingHall.Capacity = hallDto.Capacity;

            _hallRepo.UpdateHall(existingHall);
            _hallRepo.SaveChanges();

            return MapToReadDto(existingHall);
        }

        public bool DeleteHall(int id)
        {
            var existingHall = _hallRepo.GetHall(id);
            if (existingHall == null)
            {
                return false;
            }

            _hallRepo.DeleteHall(id);
            _hallRepo.SaveChanges();
            return true;
        }

        private static HallReadDTO MapToReadDto(Hall hall)
        {
            return new HallReadDTO
            {
                Id = hall.Id,
                Name = hall.Name,
                Capacity = hall.Capacity
            };
        }
    }
}
