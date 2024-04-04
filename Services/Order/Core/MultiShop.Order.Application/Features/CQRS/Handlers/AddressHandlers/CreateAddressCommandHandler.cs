using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler
{
    private readonly IRepository<Address> _addressRepository;

    public CreateAddressCommandHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        await _addressRepository.CreateAsync(new Address
        {
            UserId = request.UserId,
            District = request.District,
            City = request.City,
            Detail = request.Detail
        });
    }
}