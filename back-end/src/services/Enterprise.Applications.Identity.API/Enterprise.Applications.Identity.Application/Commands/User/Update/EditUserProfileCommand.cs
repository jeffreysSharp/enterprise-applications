using Enterprise.Applications.Application.Common.Interfaces;
using MediatR;

namespace Enterprise.Applications.Application.Commands.User.Update
{
    public class EditUserProfileCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }

    public class EditUserProfileCommandHandler : IRequestHandler<EditUserProfileCommand, string>
    {
        private readonly IIdentityService _identityService;

        public EditUserProfileCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(EditUserProfileCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.UpdateUserProfile(request.Id, request.FullName, request.Email, request.Roles);

            return result;
        }
    }
}
