﻿using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;

namespace UdemyCarBook.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarsController(
    GetCarQueryHandler getCarQueryHandler,
    GetCarByIdQueryHandler getCarByIdQueryHandler,
    CreateCarCommandHandler createCarCommandHandler,
    UpdateCarCommandHandler updateCarCommandHandler,
    RemoveCarCommandHandler removeCarCommandHandler,
    GetCarWithBrandQueryHandler getCarWithBrandQueryHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> CarList()
    {
        var values = await getCarQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBanneer(int id)
    {
        var value = await getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        await createCarCommandHandler.Handle(command);
        return Ok("Araba bilgisi eklendi.");
    }

    [HttpDelete]
    public async Task<IActionResult> RemoveCar(int id)
    {
        await removeCarCommandHandler.Handle(new RemoveCarCommand(id));
        return Ok("Araba bilgisi silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
    {
        await updateCarCommandHandler.Handle(command);
        return Ok("Araba bilgisi güncellendi.");
    }

    [HttpGet("GetCarWithBrand")]
    public IActionResult GetCarWithBrand()
    {
        var values = getCarWithBrandQueryHandler.Handle();
        return Ok(values);
    }
}