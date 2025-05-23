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
	public class UpdateOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateOrderDetailCommand command)
		{
			var values = await _repository.GetByIdAsync(command.OrderDetailId);
			values.ProductName = command.ProductName;
			values.ProductPrice = command.ProductPrice;
			values.ProductTotalPrice = command.ProductTotalPrice;
			values.ProductAmount = command.ProductAmount;
			values.OrderingId = command.OrderingId;
			values.ProductId = command.ProductId;
			await _repository.UpdateAsync(values);
		}
	}
}
