using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;

namespace Infrastructure.Common
{
    public static class MediatorExtensions
    {
        public static void DispatchDomainEvents(this IMediator mediator, ICartRepository cartRepository)
        {
            
        }
    }
}
