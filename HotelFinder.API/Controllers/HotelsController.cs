using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService) => _hotelService = hotelService;

        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels);
        }

        /// <summary>
        /// Get Hotel By id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel); // 200 + data
            }
            return NotFound();
        }

        /// <summary>
        /// Get Hotel Update
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public Hotel Put([FromBody] Hotel hotel) => _hotelService.UpdateHotel(hotel);

        /// <summary>
        /// Get Create by Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Post([FromBody] Hotel hotel)
        {
            var createdHotel = _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createdHotel.ID }, createdHotel);
        }

        /// <summary>
        /// Delete by hotel
        /// </summary>
        /// <param name="id"></param>
        /// 
        [HttpDelete("{id}")]
        public void Delete(int id) => _hotelService.DeleteHotel(id);

    }
}
