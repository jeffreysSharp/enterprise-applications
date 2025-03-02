using Enterprise.Applications.Application.Common.Interfaces;
using MediatR;

namespace Enterprise.Applications.Application.Commands.Role.Update
{
    public class UpdateRoleCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
    }

    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, string>
    {
        private readonly IIdentityService _identityService;

        public UpdateRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.UpdateRole(request.Id, request.RoleName);

            return result;
        }
    }
}
