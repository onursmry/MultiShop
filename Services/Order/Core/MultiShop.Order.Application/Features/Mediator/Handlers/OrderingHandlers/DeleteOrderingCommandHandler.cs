using MediatR;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
{
    private readonly IRepository<Ordering> _orderingRepository;

    public DeleteOrderingCommandHandler(IRepository<Ordering> orderingRepository)
    {
        _orderingRepository = orderingRepository;
    }

    public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
    {
        var result = await _orderingRepository.GetByIdAsync(request.Id);
        await _orderingRepository.DeleteAsync(result);
    }
}