using Microsoft.AspNetCore.Mvc;
using modelsLib;
using interfacesLib;
namespace OrderPizza.Controllers;
[ApiController]
[Route("[controller]")]

public class OrderPizzaController : ControllerBase
{  
    private readonly IOrderPizza _order;

    public OrderPizzaController(IOrderPizza order)
    { 
        _order=order;
        _order.CreateDate=DateTime.Now;
        Console.WriteLine("from order pizza "+_order.CreateDate);
    }   

[HttpPost]
    [Route("new/{order}")]   
    public void Post(OrderPizzaobj order)=>
    _order.Post(order);

[HttpGet]
[Route("get")]
public ActionResult<List<OrderPizzaobj>> Get()
{
    return _order.Get();
}
[HttpPost]
[Route("order")]
public async void Pay(OrderPizzaobj myOrder)
{
_order.finishOrder(myOrder);
}
// [HttpPost]
// [Route("get2")]
// public void MakePizza()
// {
// _order.MakePizza();
// }



}
