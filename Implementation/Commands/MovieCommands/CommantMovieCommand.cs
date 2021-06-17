using Application.DataTransfer;
using Application.Exceptions;
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
    public class CommantMovieCommand : ICommentMovieCommand
    {
        private readonly Context _context;
        private readonly IApplicationUser _user;
        private readonly CommentValidator _validator;
        private readonly IMapper _mapper;

        public CommantMovieCommand(Context context, CommentValidator validator, IMapper mapper, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _user = user;
        }
        public int Id => 10;

        public string Name => "Comment movie";

        public void Execute(CommentMovieDto request)
        {
            _validator.ValidateAndThrow(request);

            var com = new MovieComment
                {
                    MovieId = request.IdMovie,
                    UserId = _user.Id,
                    Comment = request.Comment,
                    CommentDate = DateTime.Now
                };

            _context.MovieComments.Add(com);
            _context.SaveChanges();
        }
    }
}
