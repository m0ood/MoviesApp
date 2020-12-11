using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.ViewModels;
using System.Collections.Generic;
using MoviesApp.Services;
using MoviesApp.Services.Dto;

namespace MoviesApp.Controllers
{
    [Route("api/Actor")]
    [ApiController]
    public class ActorControllerApi : Controller
    {
        private readonly IActorService _service;
        public ActorControllerApi(IActorService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ActorViewModel>))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ActorViewModel>> GetActors()
        {
            return Ok(_service.GetAllActors());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ActorDto))]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var actor = _service.GetActor(id);
            if (actor == null) return NotFound();
            return Ok(actor);
        }

        [HttpPost]
        public ActionResult<InputActorViewModel> PostActor(ActorDto actorDto)
        {

            var actor = _service.AddActor(actorDto);
            return CreatedAtAction("GetById", new { id = actor.Id }, actor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, ActorDto editDto)
        {
             var actor = _service.UpdateActor(editDto);
            if (actor == null)
            {
                return BadRequest();
            }

            return Ok(actor);
        }

        [HttpDelete("{id}")]
        public ActionResult<DeleteActorViewModel> DeleteActor(int id)
        {
            var actor = _service.DeleteActor(id);
            if (actor == null) return NotFound();
            return Ok(actor);
        }

    }
}