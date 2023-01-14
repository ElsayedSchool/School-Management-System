using Application.Common.Interfaces.EntityRepositories;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repository
{
    public class CountryRepo : Repository<Country>, ICountryRepo
    {
        private readonly AcademyDbContext _applicationDb;

        public CountryRepo(AcademyDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }

        public async Task<RespDto<List<Country>>> GetAllAddressLookups()
        {
            try
            {
                var lookups = await _applicationDb.Countries.Include(p => p.Cities).ThenInclude(p => p.Regions).ToListAsync();
                return new RespDto<List<Country>>() { Data = lookups };
            }
            catch (Exception)
            {
                return new RespDto<List<Country>>().Get500Error("Failed Loading Address Lookups, please Refresh the page");
            }
        }
    }
}
