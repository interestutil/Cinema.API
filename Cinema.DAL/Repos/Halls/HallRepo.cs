using Cinema.DAL.Data;
using Cinema.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repos.Halls
{
    public class HallRepo : IHallRepo
    {
        private readonly ApplicationContext _applicationContext;

        public HallRepo(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void AddHall(Hall hall)
        {
            _applicationContext.Halls.Add(hall);
        }

        public void DeleteHall(int id)
        {
            _applicationContext.Halls.Remove(_applicationContext.Halls.Find(id));
        }

        public IEnumerable<Hall> GetAllHalls()
        {
            return _applicationContext.Halls;
        }

        public Hall GetHall(int id)
        {
            return _applicationContext.Halls.Find(id);
        }

        public int SaveChanges()
        {
            return _applicationContext.SaveChanges();
        }
        

        public void UpdateHall(Hall hall)
        {
            _applicationContext.Halls.Update(hall);
        }
    }
}
