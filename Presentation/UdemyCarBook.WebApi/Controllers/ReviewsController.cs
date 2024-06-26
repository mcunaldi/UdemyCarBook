﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.ReviewQueries;

namespace UdemyCarBook.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReviewsController(IMediator mediator) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> ReviewListByCarId(int id)
	{
		var values = await mediator.Send(new GetReviewByCarIdQuery(id));
		return Ok(values);
	}

	[HttpPost]
	public async Task<IActionResult> CreateReview(CreateReviewCommand command, CancellationToken cancellation)
	{
		if (!ModelState.IsValid)
		{
            return BadRequest(ModelState);
        }
		await mediator.Send(command);
		return Ok("Ekleme işlemi gerçekleşti.");
	}


    [HttpPut]
    public async Task<IActionResult> UpdateReview(UpdateReviewCommand command, CancellationToken cancellation)
    {
        await mediator.Send(command);
        return Ok("Güncelleme işlemi gerçekleşti.");
    }
}
