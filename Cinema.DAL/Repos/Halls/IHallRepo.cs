using Cinema.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repos.Halls
{
    public interface IHallRepo
    {
        IEnumerable<Hall> GetAllHalls();
        Hall GetHall(int id);
        void AddHall(Hall hall);
        void UpdateHall(Hall hall);
        void DeleteHall(int id);
        int SaveChanges();
    }
}
