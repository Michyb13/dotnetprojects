using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.DTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly MusicDbContext _dbContext;

        public MusicController(MusicDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var music = _dbContext.Musics.ToList();

           return Ok(music);
        }


        [HttpGet("{id}")]
      
        public IActionResult GetOne(int id)
        {
            var music = _dbContext.Musics.Find(id);

            if(music == null)
            {
                return NotFound();
            }
           
             return Ok(music);
        }


        [HttpPost]
        public IActionResult Create(Music MusicReq )
        {
           
           _dbContext.Musics.Add(MusicReq);
           _dbContext.SaveChanges();
           return CreatedAtAction(nameof(GetOne), new { id = MusicReq.Id }, MusicReq);
        }


        [HttpPut("{id}")]
        public IActionResult Edit(int id, Music UpdateMusic)
        {
            if(id != UpdateMusic.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(UpdateMusic).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOne(int id)
        {
            var music = _dbContext.Musics.Find(id);
            if(music == null)
            {
                return NotFound();
            }
            _dbContext.Musics.Remove(music);
            _dbContext.SaveChanges();
            return NoContent();
        }


    }
}