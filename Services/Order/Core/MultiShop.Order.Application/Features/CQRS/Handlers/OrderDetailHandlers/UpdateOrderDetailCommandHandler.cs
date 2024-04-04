using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _orderDetailRepository;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderDetailRepository.GetByIdAsync(request.OrderDetailId);
        result.ProductId = request.ProductId;
        result.ProductName = request.ProductName;
        result.ProductPrice = request.ProductPrice;
        result.ProductAmount = request.ProductAmount;
        result.ProductTotalPrice = request.ProductTotalPrice;
        result.OrderingId = request.OrderingId;
        await _orderDetailRepository.UpdateAsync(result);
    }
}