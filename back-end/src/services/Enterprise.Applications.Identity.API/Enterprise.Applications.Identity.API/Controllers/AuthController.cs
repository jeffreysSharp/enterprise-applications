﻿using Enterprise.Applications.Application.Commands.Auth;
using Enterprise.Applications.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Enterprise.Applications.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Login")]
        [ProducesDefaultResponseType(typeof(AuthResponseDTO))]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Register")]
        [ProducesDefaultResponseType(typeof(int))]
        public async Task<ActionResult> Register(RegisterCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
