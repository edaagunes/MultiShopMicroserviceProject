using MediatR;
using MultiShop.Order.Core.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Core.Application.Features.Mediator.Handlers.OrderingHandlers
{
	public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
	{
		private readonly IRepository<Ordering> _repository;

		public CreateOrderingCommandHandler(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Ordering
			{
				OrderDate = request.OrderDate,
				TotalPrice = request.TotalPrice,
				UserId = request.UserId,
			});
		}
	}
}
