using MultiShop.Order.Core.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Core.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Core.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Core.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailByIdQueryHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
		{
			var values = await _repository.GetByIdAsync(query.Id);
			return new GetOrderDetailByIdQueryResult
			{
				OrderDetailId = values.OrderDetailId,
				ProductTotalPrice = values.ProductTotalPrice,
				ProductPrice = values.ProductPrice,
				ProductName = values.ProductName,
				ProductId = values.ProductId,
				ProductAmount = values.ProductAmount,
				OrderingId=values.OrderingId,
			};
		}
	}
}
