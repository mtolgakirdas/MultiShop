using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommandHandler)
        {
            await _repository.CreateAsync(new Address
            {
               City = createAddressCommandHandler.City,
               Detail = createAddressCommandHandler.Detail,
               District = createAddressCommandHandler.District,
               UserId = createAddressCommandHandler.UserId
            });
        }
        
    }
}
