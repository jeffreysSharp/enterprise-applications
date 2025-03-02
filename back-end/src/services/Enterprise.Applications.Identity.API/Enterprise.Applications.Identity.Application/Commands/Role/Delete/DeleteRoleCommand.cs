using Enterprise.Applications.Application.Common.Interfaces;
using MediatR;

namespace Enterprise.Applications.Application.Commands.Role.Delete
{
    public class DeleteRoleCommand : IRequest<string>
    {
        public string RoleId { get; set; }
    }

    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, string>
    {
        private readonly IIdentityService _identityService;

        public DeleteRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.DeleteRoleAsync(request.RoleId);

            return result;
        }
    }
}
