using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Stocks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PhoneController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult<List<Phone>>> GetPhones()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}