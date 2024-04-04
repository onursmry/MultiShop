using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;

    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        await _orderDetailRepository.CreateAsync(new OrderDetail
        {
            OrderingId = request.OrderingId,
            ProductId = request.ProductId,
            ProductName = request.ProductName,
            ProductAmount = request.ProductAmount,
            ProductPrice = request.ProductPrice,
            ProductTotalPrice = request.ProductTotalPrice
        });
    }
}