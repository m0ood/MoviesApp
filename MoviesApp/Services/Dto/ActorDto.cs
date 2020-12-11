using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.Services.Dto
{
    public class ActorDto
    {
        public int? Id { get; set; }
        [Required]
        [LessThan4Characters]
        public string FirstName { get; set; }
        [Required]
        [LessThan4Characters]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}