using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using modelsLib;
using interfacesLib;

namespace Workers.Controllers;
[ApiController]
[Route("[controller]")]
[Authorize(Policy = "Admin")]
public class WorkersController : ControllerBase
{
    private readonly IWorkers worker;
    public WorkersController(IWorkers _worker)
    {
        this.worker=_worker;
        // _worker.CreateDate=DateTime.Now;
        // Console.WriteLine("from  worker "+_worker.CreateDate);
    }   
    
//Get
[HttpGet]
     [Route("get")]
     public List<workerobj> Get()=>
     worker.Get();

//Update
[HttpPut]
    [Route("updatePrice/{worker}")]   
    public void Put([FromBody] workerobj W)=>
    worker.Put(W);
}   