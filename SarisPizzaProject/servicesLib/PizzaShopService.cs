using modelsLib;
using interfacesLib;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using FileService;
namespace servicesLib;

public  class PizzaShopServices :IPizzaShopServices
{
    private Ifile FileService{get;set;}
   
    public DateTime CreateDate{get;set;}
    public PizzaShopServices(Ifile _fileService)
    {
      this.FileService=_fileService;
        this.CreateDate=DateTime.Now;
        Console.WriteLine("from pizza shop "+this.CreateDate+" yes, it's singleton!!");
    }
    public List<PizzaShopObj> Get()
    {
      return FileService.ReadFromFile<PizzaShopObj>();
    }
    public PizzaShopObj? GetId(int id)
    {
      List<PizzaShopObj> pizzas=FileService.ReadFromFile<PizzaShopObj>();
        foreach(var p in pizzas)
        {
            if(p.Id==id)
            return p;
        }
        return null;
    }
    public  void Put(PizzaShopObj Pizza)
    {   List<PizzaShopObj> pizzas=FileService.ReadFromFile<PizzaShopObj>();
        var index=pizzas.FindIndex(p=>p.Id==Pizza.Id);
        pizzas[index]=Pizza;
        string json=JsonSerializer.Serialize(pizzas);
        FileService.WriteMessage(json);
    }

    public  void Delete(int id)
    {
      List<PizzaShopObj> pizzas=FileService.ReadFromFile<PizzaShopObj>();
         foreach(var p in pizzas)
        {
            if(p.Id==id)
              {
                 pizzas.Remove(p);
                 break;
              }
        }
      string json=JsonSerializer.Serialize(pizzas);
      FileService.WriteMessage(json);
    }

    public void Post(PizzaShopObj Pizza)
      {
        List<PizzaShopObj> pizzas=FileService.ReadFromFile<PizzaShopObj>();     
        if(pizzas!=null)
       {
         Pizza.Id=pizzas.Last().Id+1;
        pizzas.Add(Pizza);
       }
        else
        {
          pizzas=new List<PizzaShopObj>{};
          Pizza.Id=0;
          pizzas.Add(Pizza);
        }
        if(Pizza!=null)
        {
          string json=JsonSerializer.Serialize(pizzas);
          FileService.WriteMessage(json);
        }
      }
    
}

