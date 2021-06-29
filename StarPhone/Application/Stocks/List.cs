using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Stocks
{
    public class List
    {
        public class Query : IRequest<List<Phone>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Phone>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }

            public async Task<List<Phone>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Phones.ToListAsync();
            }
        }
    }
}