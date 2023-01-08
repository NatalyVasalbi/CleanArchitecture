using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Streamer2.Commands.UpdateStreamer
{
    public class UpdateStreamerCommandValidation : AbstractValidator<UpdateStreamerCommand>
    {
        public UpdateStreamerCommandValidation()
        {
            RuleFor(p => p.Nombre)
                .NotNull().WithMessage("{Nombre} no permite valores nulos");
            RuleFor(p => p.Url)
                .NotNull().WithMessage("{Url} no permite valores nulos");
        }
    }
}
