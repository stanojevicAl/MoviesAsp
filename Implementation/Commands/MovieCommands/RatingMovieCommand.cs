using Application.DataTransfer;
using Application.Interfaces;
using Application.Interfaces.Commands;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class RatingMovieCommand : IRatingMovieCommand
    {
        private readonly Context _context;
        private readonly IApplicationUser _user;
        private readonly RatingValidator _validator;

        public RatingMovieCommand(Context context, RatingValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }
        public int Id => 11;

        public string Name =>"Rating movie";

        public void Execute(RatingMovieDto request)
        {
            _validator.ValidateAndThrow(request);

            var rating = new MovieRating
            {
                MovieId = request.MoviedId,
                UserId = _user.Id,
                Rating = request.Pating
            };

            _context.MovieRatings.Add(rating);
            _context.SaveChanges();
        }
    }
}
