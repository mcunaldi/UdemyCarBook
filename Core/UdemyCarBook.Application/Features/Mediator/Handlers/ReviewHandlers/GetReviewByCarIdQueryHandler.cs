﻿using MediatR;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;
using UdemyCarBook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReviewHandlers;
public class GetReviewByCarIdQueryHandler(IReviewRepository repository) : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
{
	public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
	{
		var values = repository.GetAllReviewsByCarId(request.Id);
		return values.Select(x => new GetReviewByCarIdQueryResult
		{
			CarID = x.CarID,
			Comment = x.Comment,
			CustomerImage = x.CustomerImage,
			CustomerName = x.CustomerName,
			RaytingValue = x.RaytingValue,
			ReviewDate = x.ReviewDate,
			ReviewID = x.ReviewID
		}).ToList();
	}
}
