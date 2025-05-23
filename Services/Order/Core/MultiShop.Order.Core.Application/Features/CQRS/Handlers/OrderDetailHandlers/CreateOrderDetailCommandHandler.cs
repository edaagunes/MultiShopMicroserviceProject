using MultiShop.Order.Core.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Core.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class CreateOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		public async Task Handle(CreateOrderDetailCommand command)
		{
			await _repository.CreateAsync(new OrderDetail
			{
				OrderingId = command.OrderingId,
				ProductAmount = command.ProductAmount,
				ProductId = command.ProductId,
				ProductName = command.ProductName,
				ProductPrice = command.ProductPrice,
				ProductTotalPrice = command.ProductTotalPrice,
			});
		}
	}
}
