using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var useDbContext = new HotelDbContext())
            {
                useDbContext.Hotels.Add(hotel);
                useDbContext.SaveChanges();
                return hotel;
            }
        }

        public void DeleteHotel(int id)
        {
            using (var useDbContext = new HotelDbContext())
            {
                var deleteHotel = GetHotelById(id);
                useDbContext.Remove(deleteHotel);
                useDbContext.SaveChanges();
            }
        }

        public List<Hotel> GetAllHotels()
        {
            using (var useDbContext = new HotelDbContext())
            {
                return useDbContext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var useDbContext = new HotelDbContext())
            {
                return useDbContext.Hotels.Find(id);
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using (var useDbContext = new HotelDbContext())
            {
                useDbContext.Hotels.Update(hotel);
                useDbContext.SaveChanges();
                return hotel;
            }
        }
    }
}
