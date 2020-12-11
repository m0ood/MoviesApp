using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.Services.Dto;

namespace MoviesApp.Services
{
    public class ActorService: IActorService
    {
        private readonly ActorsContext _context;
        private readonly IMapper _mapper;
        public ActorService(ActorsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public ActorDto GetActor(int id)
        {
            return _mapper.Map<ActorDto>(_context.Actor.FirstOrDefault(m => m.Id == id));
        }

        public IEnumerable<ActorDto> GetAllActors()
        {
            return _mapper.Map<IEnumerable<Actor>, IEnumerable<ActorDto>>(_context.Actor.ToList());
        }

        public ActorDto UpdateActor(ActorDto actorDto)
        {
            if (actorDto.Id == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }
            
            try
            {
                var actor = _mapper.Map<Actor>(actorDto);
                
                _context.Update(actor);
                _context.SaveChanges();
                
                return _mapper.Map<ActorDto>(actor);
            }
            catch (DbUpdateException)
            {
                if (!ActorExists((int) actorDto.Id))
                {
                    //упрощение для примера
                    //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                    return null;
                }
                else
                {
                    //упрощение для примера
                    //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                    return null;
                }
            }
        }

        public ActorDto AddActor(ActorDto actorDto)
        {
            var actor = _context.Add(_mapper.Map<Actor>(actorDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<ActorDto>(actor);
        }

        public ActorDto DeleteActor(int id)
        {
            var actor = _context.Actor.Find(id);
            if (actor == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }

            _context.Actor.Remove(actor);
            _context.SaveChanges();
            
            return _mapper.Map<ActorDto>(actor);
        }
        
        private bool ActorExists(int id)
        {
            return _context.Actor.Any(e => e.Id == id);
        }
    }
}