using Microsoft.AspNetCore.Mvc;
using interfacesLib;
using modelsLib;
using FileService;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace servicesLib;

public  class OrderPizzaService : IOrderPizza
{
      private IMail mail{get;set;}
   public OrderPizzaService(IMail _mail)
    {
      this.mail=_mail;
      Orders=new List<OrderPizzaobj>{
        new OrderPizzaobj {CostumerId=0,CostumerName="Moshe",TotalPrice=56.9,ListP=new List<PizzaShopObj>{
            new PizzaShopObj{Id=7,Name="nonGluten",Price=23.6,Gluten=false},
            new PizzaShopObj{Id=8,Name="sharp",Price=39.8,Gluten=true}
        }}
      };
        // o.CreateDate=DateTime.Now;
        // Console.WriteLine("from order pizza "+o.CreateDate);
    }

    public List<OrderPizzaobj> Orders= new List<OrderPizzaobj>{
        new OrderPizzaobj {
          CostumerId=0,CostumerName="ora",TotalPrice=500,ListP=new List<PizzaShopObj>{
        new PizzaShopObj {Id=0,Name="italian",Price=50.99,Gluten=true},
        new PizzaShopObj {Id=1,Name="olives",Price=45.99,Gluten=true},
        new PizzaShopObj {Id=2,Name="onion",Price=48.99,Gluten=false},
        new PizzaShopObj {Id=3,Name="XXL",Price=70.99,Gluten=true}
      },
     CreditCardDetails=new CreditCard{CardNumber=45864,CardDateYear=2000,Name="Moshe"} 
      },
       new OrderPizzaobj {
          CostumerId=1,CostumerName="Sari",TotalPrice=500,ListP=new List<PizzaShopObj>{
        new PizzaShopObj {Id=0,Name="italian",Price=50.99,Gluten=true},
        new PizzaShopObj {Id=1,Name="olives",Price=45.99,Gluten=true}
      },
     CreditCardDetails=new CreditCard{CardNumber=45864,CardDateYear=2000,Name="Moshe"} 
      }
      };
    // static OrderPizzaService o;
    public DateTime CreateDate{get;set;}    
    public void Post(OrderPizzaobj order)
    {
        order.CostumerId=Orders.Last().CostumerId+1;
        // order.Id=Counter++;
        Orders.Add(order);
    }
    public ActionResult<List<OrderPizzaobj>> Get()
    {
      return Orders;
      // return FileService.ReadFromFile<OrderPizzaobj>();
    }
public void finishOrder(OrderPizzaobj myOrder)
{
   Pay( myOrder);
   MakePizza();
}
public async void  Pay(OrderPizzaobj myOrder)//לא אכפת לנו שתוך כדי התשלום הפיצה תתמכן
{
  string json=JsonSerializer.Serialize(myOrder);
  Console.WriteLine("Start paying...");
   double sum=myOrder.TotalPrice;
     await Task.Delay(3000);
  Console.WriteLine("you payed on the order successfully!!\n you had to pay "+sum+"₪");
   ForInvoice(myOrder,json);//רק אחרי שסיימנו את התשלום נשלח חשבונית
 
}
public  void  MakePizza()
{
    Console.WriteLine("I made you a pizza!!");
}
public void ForInvoice(OrderPizzaobj list,string json)
{
  this.mail.WriteMessage(json);
   Console.WriteLine("the invoice sent to you in mail..."+list.CostumerName+"\n");
}

}

