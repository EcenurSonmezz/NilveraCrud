using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilvera.Application.Features.Firma.Commands
{
    public class DeleteFirmaCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteFirmaCommand(int id)
        {
            Id = id;
        }
    }
}
