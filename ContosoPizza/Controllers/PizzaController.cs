using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;



[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {

    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
        PizzaServices.GetAll();

    // GET by Id action
    [HttpGet("id/{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaServices.Get(id);

        if (pizza == null)
            return NotFound();

        return pizza;
    }

    // GET by Name action
    [HttpGet("name/{pizza_name}")]
    public ActionResult<Pizza> GetByName(string pizza_name)
    {
        var pizza = PizzaServices.GetByName(pizza_name);

        if (pizza == null)
            return NotFound();

        return pizza;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaServices.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    // PUT action
    [HttpPut("id/{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = PizzaServices.Get(id);
        if (existingPizza is null)
            return NotFound();

        PizzaServices.Update(pizza);

        return NoContent();
    }

    // DELETE action
    [HttpDelete("id/{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaServices.Get(id);

        if (pizza is null)
            return NotFound();

        PizzaServices.Delete(id);

        return NoContent();
    }
}
