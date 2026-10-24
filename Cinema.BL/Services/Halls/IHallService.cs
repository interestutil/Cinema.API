using System.Collections.Generic;
using Cinema.BL.DTOs.Halls;
using Cinema.DAL.Models;
using Cinema.DAL.Repos.Halls;

namespace Cinema.BL.Services.Halls
{
    public interface IHallService
    {
        IEnumerable<HallReadDTO> GetAllHalls();
        HallReadDTO? GetHallById(int id);
        HallReadDTO AddHall(HallWriteDTO hallDto);
        HallReadDTO? UpdateHall(int id, HallWriteDTO hallDto);
        bool DeleteHall(int id);
    }
}
