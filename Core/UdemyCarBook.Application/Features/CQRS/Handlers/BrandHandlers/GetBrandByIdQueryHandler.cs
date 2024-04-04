﻿using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
public class GetBrandByIdQueryHandler(IRepository<Brand> repository)
{
    public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
    {
        var values = await repository.GetByIdAsync(query.Id);
        return new GetBrandByIdQueryResult
        {
            BrandID = values.BrandID,
            Name = values.Name
        };
    }
}
