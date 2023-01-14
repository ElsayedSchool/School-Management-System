using Application.Common.Mediatr;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BranchApp
{
    
    public class UpsertBranchCommand : IRequestWrapper<bool>
    {
        public UpsertBranchCommand()
        {
        }


        public int Id { get; set; }
        public string BranchName { get; set; }
        public string BranchDesc { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public int RegionId { get; set; }
        public string Street { get; set; }
    }
}
