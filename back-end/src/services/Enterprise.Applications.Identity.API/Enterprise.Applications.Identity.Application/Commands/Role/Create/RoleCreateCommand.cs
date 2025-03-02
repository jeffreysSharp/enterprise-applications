using Enterprise.Applications.Application.Common.Interfaces;
using MediatR;


namespace Enterprise.Applications.Application.Commands.Role.Create
{
    public class RoleCreateCommand : IRequest<string>
    {
        public string RoleName { get; set; }
    }

    public class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommand, string>
    {
        private readonly IIdentityService _identityService;

        public RoleCreateCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(RoleCreateCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.CreateRoleAsync(request.RoleName);

            return result;
        }
    }
}
