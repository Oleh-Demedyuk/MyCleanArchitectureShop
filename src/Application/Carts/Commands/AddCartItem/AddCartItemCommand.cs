using MediatR;
using Domain.ValueObjects;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Events;

namespace Application.Carts.Commands.AddCartItem
{
    public record AddCartItemCommand : IRequest<int>
    {
        public int CartId { get; init; }

        public CartItem CartItem { get; set; }
    }

    public class AddCartItemCommandHandler : IRequestHandler<AddCartItemCommand, int>
    {
        private readonly ICartRepository _cartRepository;

        public AddCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Task<int> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var entity = _cartRepository.GetCart(request.CartId);
            
            if (entity == null)
            {
                entity = new Cart();
                entity.Items.Add(request.CartItem);

                entity.AddDomainEvent(new CartItemAddedEvent(request.CartItem));
                
                _cartRepository.InsertCart(entity);
            }
            else
            {
                entity.Items.Add(request.CartItem);

                entity.AddDomainEvent(new CartItemAddedEvent(request.CartItem));
                _cartRepository.UpdateCart(entity);
            }

            return Task.FromResult(entity.Id);
        }
    }
}
