using Enterprise.Applications.Application.Common.Exceptions;
using Enterprise.Applications.Application.Common.Interfaces;
using Enterprise.Applications.Application.DTOs;
using MediatR;
using Microsoft.IdentityModel.Tokens;



namespace Enterprise.Applications.Application.Commands.Auth
{
    public class LoginCommand : IRequest<AuthResponseDTO>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


    public class AuthCommandHandler : IRequestHandler<LoginCommand, AuthResponseDTO>
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IIdentityService _identityService;

        public AuthCommandHandler(IIdentityService identityService, ITokenGenerator tokenGenerator)
        {
            _identityService = identityService;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthResponseDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.SigninUserAsync(request.UserName, request.Password);

            if (result.IsNullOrEmpty())
            {
                throw new BadRequestException("Invalid username or password");
            }

            var (userId, fullName, userName, email, roles) = await _identityService.GetUserDetailsAsync(await _identityService.GetUserIdAsync(request.UserName));

            string token = _tokenGenerator.GenerateJWTToken((userId, userName, roles));

            return new AuthResponseDTO()
            {
                UserId = userId,
                Name = userName,
                Token = token
            };
        }
    }
}
