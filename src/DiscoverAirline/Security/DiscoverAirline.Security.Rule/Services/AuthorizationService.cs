using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.AuthorizationManager;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IBaseRepository<Role> _roleRepository;
        private readonly IBaseRepository<Application> _applicationRepository;
        private readonly IBaseRepository<Access> _accessRepository;
        private readonly IBaseRepository<Domain.Entities.Action> _actionRepository;
        private readonly IBaseRepository<Authorization> _authorizationRepository;

        public AuthorizationService(
            IBaseRepository<Role> roleRepository,
            IBaseRepository<Application> applicationRepository,
            IBaseRepository<Access> accessRepository,
            IBaseRepository<Domain.Entities.Action> actionRepository,
            IBaseRepository<Authorization> authorizationRepository)
        {
            _roleRepository = roleRepository;
            _applicationRepository = applicationRepository;
            _accessRepository = accessRepository;
            _actionRepository = actionRepository;
            _authorizationRepository = authorizationRepository;
        }

        public async Task<Notification> ManagementsToAuthorizations(object model)
        {
            var request = (AuthManagersRequest)model;
            foreach (var application in request.Applications)
            {
                foreach (var access in application.Access)
                {
                    await ManagementToAuthorizations(new AuthManagerRequest
                    {
                        RoleId = request.RoleId,
                        ApplicationId = application.ApplicationId,
                        AccessId = access.AccessId,
                        Actions = access.Actions
                    });
                }
            }

            return Notification.Create(new
            {
                Data = request,
                Statua = true
            });
        }

        public async Task<Notification> ManagementToAuthorizations(object model)
        {
            var request = (AuthManagerRequest)model;
            var role = await _roleRepository.GetByIdAsync(request.RoleId);

            if (role != null)
            {
                var app = await _applicationRepository.GetByIdAsync(request.ApplicationId);
                var access = await _accessRepository.GetByIdAsync(request.AccessId);
                var actions = await _actionRepository.WhereAsync(x => request.Actions.Any(y => y == x.Id));

                await _authorizationRepository.AddAsync(new Authorization
                {
                    RoleId = role.Id,
                    ApplicationId = app.Id,
                    AccessId = access.Id,
                    Actions = actions.ToList()
                });

                return Notification.Create(new
                {
                    Data = request,
                    Status = true
                });
            }
            return Notification.Create(false);
        }


    }
}
