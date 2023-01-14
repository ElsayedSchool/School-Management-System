using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.System.Command
{
    public class DataSeederCommand : IRequest
    {
    }

    public class DataSeederCommandHandler : IRequestHandler<DataSeederCommand>
    {
        private readonly IUserManagerService _userManager;
        private readonly IApplicationRepo _applicationRepo;
        private readonly IUserSignInManagerService _signInmanager;
        private readonly IOptions<AppSettingModel> _option;

        public DataSeederCommandHandler(
            IUserManagerService userManager, 
            IApplicationRepo applicationRepo,
            IUserSignInManagerService signInmanager,
            IOptions<AppSettingModel> option)
        {
            _userManager = userManager;
            _applicationRepo = applicationRepo;
            _signInmanager = signInmanager;
            _option = option;
        }

        public async Task<Unit> Handle(DataSeederCommand request, CancellationToken cancellationToken)
        {
            var seeder = 
                new ApplicationDataSeeder(_applicationRepo, _userManager, _signInmanager, _option);
            await seeder.SeedAllAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
