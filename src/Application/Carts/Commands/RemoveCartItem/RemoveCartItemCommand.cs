using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;
using Domain.ValueObjects;
using MediatR;

namespace Application.Carts.Commands.RemoveCartItem
{
    public record RemoveCartItemCommand : IRequest
    {
        public int CartId { get; init; }

        public CartItem CartItem { get; set; }
    };

    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand>
    {
        private readonly ICartRepository _cartRepository;


        public RemoveCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Task Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
        {
            var entity = _cartRepository.GetCart(request.CartId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Cart), request.CartId);
            }

            var index = entity.Items.IndexOf(request.CartItem);
            if (index == -1)
            {
                throw new NotFoundException(nameof(CartItem), request.CartItem);
            }

            entity.Items.RemoveAt(index);

            entity.AddDomainEvent(new CartItemRemovedEvent(request.CartItem));

            _cartRepository.UpdateCart(entity);

            return Task.CompletedTask;
        }
    }

}
