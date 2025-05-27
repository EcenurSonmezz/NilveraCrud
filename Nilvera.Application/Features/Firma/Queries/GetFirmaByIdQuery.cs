using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Nilvera.Domain.Entities;

namespace Nilvera.Application.Features.Firma.Queries
{
    public class GetFirmaByIdQuery : IRequest<Nilvera.Domain.Entities.Firma>
    {
        public int Id { get; set; }

        public GetFirmaByIdQuery(int id)
        {
            Id = id;
        }
    }
}
