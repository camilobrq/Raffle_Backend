using Application.UseCase.Security.Authentication.Commands.SignOut;
using Application.UseCase.Security.Authentication.Commands.SingIn;
using Application.UseCase.Security.Authentication.Commands.SignUp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Exceptions;
using static Dapper.SqlMapper;
using System.Security.Claims;
using Application.UseCase.Funtionality.Raffle.Commands.CreateProduct;
using Application.UseCase.Funtionality.Raffle.Commands.DeleteProduct;
using Application.UseCase.Funtionality.Raffle.Commands.GetProduct;
using Application.UseCase.Funtionality.Raffle.Commands.UpdateProduct;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IMediator _mediator) : ControllerBase
    {

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(CreateProductCommand createProductCommand)
        {
            return Ok(await _mediator.Send(createProductCommand));
        }

        [HttpPost("GetProduct")]
        public async Task<ActionResult> GetProduct(GetProductCommand GetProductCommand)
        {
            return Ok(await _mediator.Send(GetProductCommand));
        }
        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(UpdateProductCommand UpdateProductCommand)
        {
            return Ok(await _mediator.Send(UpdateProductCommand));
        }
        [HttpPut("DeleteProduct")]
        public async Task<ActionResult> DeleteProduct(DeleteProductCommand deleteProductCommand)
        {
            return Ok(await _mediator.Send(deleteProductCommand));
        }

    }
}
