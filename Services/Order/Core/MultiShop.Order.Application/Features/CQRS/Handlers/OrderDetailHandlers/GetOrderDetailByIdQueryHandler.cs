using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;

    public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var result= await _orderDetailRepository.GetByIdAsync(request.Id);
        return new GetOrderDetailByIdQueryResult
        {
            OrderDetailId = result.OrderDetailId,
            ProductId = result.ProductId,
            ProductName = result.ProductName,
            ProductPrice = result.ProductPrice,
            ProductAmount = result.ProductAmount,
            ProductTotalPrice = result.ProductTotalPrice,
            OrderingId = result.OrderingId
        };
    }
}