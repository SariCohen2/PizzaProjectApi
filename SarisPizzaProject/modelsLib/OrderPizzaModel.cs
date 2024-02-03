using modelsLib;
namespace modelsLib;

public class OrderPizzaobj
{
public int CostumerId{get;set;}
public string? CostumerName{get;set;}
public double TotalPrice{get;set;}
public List<PizzaShopObj>? ListP {get;set;}
public CreditCard CreditCardDetails{get;set;}

}