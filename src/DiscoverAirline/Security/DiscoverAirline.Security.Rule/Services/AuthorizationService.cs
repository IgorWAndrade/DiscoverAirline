using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using DiscoverAirline.Security.Rule.Applications.Request.AuthorizationManager;
using DiscoverAirline.Security.Rule.Applications.Request.AuthorizationManager.Controllers;
using System;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IBaseRepository<Role> _roleRepository;

        private readonly IBaseRepository<Service> _serviceRepository;

        private readonly IBaseRepository<Controller> _controllerRepository;

        private readonly IBaseRepository<Domain.Entities.Action> _actionRepository;

        private readonly IRoleService _roleService;

        public AuthorizationService(
            IBaseRepository<Role> roleRepository,
            IBaseRepository<Service> serviceRepository,
            IBaseRepository<Controller> controllerRepository,
            IBaseRepository<Domain.Entities.Action> actionRepository,
            IRoleService roleService)
        {
            _roleRepository = roleRepository;
            _serviceRepository = serviceRepository;
            _controllerRepository = controllerRepository;
            _actionRepository = actionRepository;
            _roleService = roleService;
        }

        public async Task<Notification> ManagementToAuthorizations(object model)
        {
            var request = (AuthManagerRequest)model;

            throw new NotImplementedException();
        }

        public Task<Notification> ManagementToUsers(object model)
        {
            throw new NotImplementedException();
        }


        #region Services

        public async Task<Notification> GetServicesAsync() => Notification.Create(await _serviceRepository.GetAsync());

        public Task<Notification> AddServiceAsync(object model)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> UpdateServiceAsync(object model)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> DeleteServiceAsync(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Controllers

        public async Task<Notification> GetControllersAsync() => Notification.Create(await _controllerRepository.GetAsync());

        public async Task<Notification> AddControllerAsync(object requestModel)
        {
            var request = (ControllerRequest)requestModel;
            var model = new Controller()
            {
                Name = request.Name
            };

            var response = await _controllerRepository.AddAsync(model);
            return Notification.Create(response);
        }

        public async Task<Notification> UpdateControllerAsync(object requestModel)
        {
            var request = (ControllerUpdateRequest)requestModel;
            var model = await _controllerRepository.GetByIdAsync(request.Id);

            model.Name = request.Name;

            var response = await _controllerRepository.UpdateAsync(model);
            return Notification.Create(response);
        }

        public async Task<Notification> DeleteControllerAsync(int id)
        {
            var response = await _controllerRepository.DeleteAsync(id);
            return Notification.Create(response);
        }

        #endregion

        #region Actions

        public async Task<Notification> GetActionsAsync() => Notification.Create(await _actionRepository.GetAsync());

        #endregion

    }
}
