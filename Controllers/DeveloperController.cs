using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/developers/")]
public class DeveloperController(IDeveloperService developerService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Developer developer)
    {
        bool res = await developerService.Create(developer);
        return res is false
        ? BadRequest("Bad request")
        : Ok("Ok");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Developer developer)
    {
        bool res = await developerService.Update(developer);
        return res is false
        ? BadRequest("Bad request")
        : Ok("Ok");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        bool res = await developerService.Delete(id);
        return res is false
        ? BadRequest("Bad request")
        : Ok("Ok");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Developer> res = await developerService.GetAll();
        return res is null
        ? NotFound("Not Found")
        : Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        Developer res = await developerService.GetById(id);
        return res is null
        ? NotFound("Not Found")
        : Ok(res);
    }
}