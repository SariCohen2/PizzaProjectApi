using System.ComponentModel.DataAnnotations;

namespace modelsLib;

public class PizzaShopObj
{
[Required]
public int Id{get;set;}

[Required]
[StringLength(40, MinimumLength =2,ErrorMessage="your name is least than 2 letters")]
public string? Name{get;set;}

[Required]
[Range(0,100000,ErrorMessage="the field must be between 0 to 100000")]
public double Price{get;set;}

[Required]
public bool Gluten{get;set;}

}