using modelsLib;
using Microsoft.AspNetCore.Mvc;
namespace interfacesLib;

public interface IOrderPizza
{
  DateTime CreateDate{get;set;}
 void Post(OrderPizzaobj order);
 ActionResult<List<OrderPizzaobj>> Get();
 void finishOrder(OrderPizzaobj myOrder);
 void  Pay(OrderPizzaobj myOrder);
 void  MakePizza();
 void ForInvoice(OrderPizzaobj list,string json);

  
}