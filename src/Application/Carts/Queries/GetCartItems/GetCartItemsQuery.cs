using Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Carts.Queries.GetCartItems
{
    public record GetCartItemsQuery : IRequest<CartItemsVm>
    {
        public int CartId { get; init; }
    }

    public class GetCartItemsQueryHandler : IRequestHandler<GetCartItemsQuery, CartItemsVm>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartItemsQueryHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public Task<CartItemsVm> Handle(GetCartItemsQuery request, CancellationToken cancellationToken)
        {
            var items = _cartRepository.GetCart(request.CartId)?.Items;
            return Task.FromResult(new CartItemsVm() {Items = _mapper.Map<List<CartItemDto>>(items)});
        }
    }
}
