using modelsLib;

namespace interfacesLib;

public interface IPizzaShopServices
{
    //   [Range(0,100000)]
        // int _id{get;set;}
    // [Required]
        //  int Delete_i{get;set;}
    
DateTime CreateDate{get;set;}
PizzaShopObj? GetId(int id);
List<PizzaShopObj> Get();
void Put(PizzaShopObj Pizza);
void Delete(int id);
void Post(PizzaShopObj Pizza);
  
}