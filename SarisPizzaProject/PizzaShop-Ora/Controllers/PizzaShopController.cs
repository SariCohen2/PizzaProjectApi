using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using interfacesLib;
using modelsLib;
using System;
using System.ComponentModel.DataAnnotations;
// using System.ComponentModel;// using System.Web.DynamicData;

namespace PizzaShop_Ora.Controllers;
[ApiController]
[Route("[controller]")]
public class PizzaShopController : ControllerBase
{
    private readonly IPizzaShopServices pizza;
    public PizzaShopController(IPizzaShopServices _pizza)
    {
        this.pizza=_pizza;
    }  

//Get
[HttpGet]
[Route("get")]
public ActionResult<List<PizzaShopObj>> Get()=>
pizza.Get();

//Get by id
[HttpGet]
[Route("getId/{id}")]
public PizzaShopObj? GetId(int id){
    return pizza.GetId(id);
}


//Update
[HttpPut]
    [Route("update")]   
    [Authorize(Policy ="SuperWorker")]
    public void Put(PizzaShopObj Pizza)=>
    pizza.Put(Pizza);

//new
[HttpPost]
    [Route("new")]   
        [Authorize(Policy ="SuperWorker")]
    public IActionResult Post(PizzaShopObj Pizza)
    {
        pizza.Post(Pizza);
        return CreatedAtAction(nameof(Get),new{id=Pizza.Id},Pizza);
    }

//delete

[HttpDelete]
[Route("delete/{id}")]
 [Authorize(Policy ="SuperWorker")]
public void Delete(int id){
 pizza.Delete(id); 
}
}
