using Microsoft.AspNetCore.Mvc;
using NDDTraining.Domain.Interfaces.Services;
using NDDTraining.Domain.Models;

namespace NDDTraining.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainingsController : ControllerBase
{
    private readonly ITrainingService _trainingService;
    private readonly IModuleService _moduleService;

    public TrainingsController(ITrainingService trainingService, IModuleService moduleService)
    {
        _trainingService = trainingService;
        _moduleService = moduleService;
    }

    [HttpGet] 
    public IActionResult GetAll(
        [FromQuery] string category,
        int skip = 0,
        int take = 20
    )
    {
        var paging = new Paging(take, skip);
        var totalRegistros = _trainingService.ObterTotal();

        Response.Headers.Add("x-Paginacao-TotalRegistros", totalRegistros.ToString());
        return Ok(_trainingService.GetAll(category, paging));
    } 

    [HttpGet("totalRegisters")]
    public IActionResult GetTotalRegisters()
    {
        return Ok(_trainingService.ObterTotal());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(
        [FromRoute] int id
    )
    {
        return Ok(_trainingService.GetById(id));
    }

    [HttpGet("{id}/modules")]
    public IActionResult GetByTrainin(
             [FromRoute] int id)
    {

        return Ok(_moduleService.GetByTraining(id));

    }

    [HttpGet]
    [Route("~/api/Users/{userId}/Trainings")]
    public IActionResult GetByUser(
    [FromRoute] int userId,
    int skip = 0,
    int take = 20
    )
    {
        var paging = new Paging(take, skip);
        return Ok(_trainingService.GetTrainingsByUser(userId, paging));
    }
}
