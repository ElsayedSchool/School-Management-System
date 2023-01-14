using Application.Common.Mediatr;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AddressApp
{
    public class UpsertAddressCommand : IRequestWrapper<bool>
    {
        public int AddressId { get; set; }
        public string PostalCode { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
