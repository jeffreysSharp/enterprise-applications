using Enterprise.Applications.Application.Common.Exceptions;
using Enterprise.Applications.Application.Common.Interfaces;
using Enterprise.Applications.Application.DTOs;
using MediatR;



namespace Enterprise.Applications.Application.Commands.Auth
{
    public class RegisterCommand : IRequest<AuthResponseDTO>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
        public List<string> Roles { get; set; }
    }


    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthResponseDTO>
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IIdentityService _identityService;

        public RegisterCommandHandler(IIdentityService identityService, ITokenGenerator tokenGenerator)
        {
            _identityService = identityService;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthResponseDTO> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var registerResult = await _identityService.CreateUserAsync(request.UserName, request.Password, request.Email, request.FullName, request.Roles);

            if (!registerResult.isSucceed)            
                throw new BadRequestException("Invalid username or password");            
            else            
                await _identityService.SigninUserAsync(request.UserName, request.Password);

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
