using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Configuration
{
    public class SessionFbConfiguration //: IEntityTypeConfiguration<StudentSessionFb>
    {
        public void Configure(EntityTypeBuilder<StudentSessionFb> builder)
        {
            builder.HasKey(p => new { p.StudentId, p.SessionId });
        }
    }
}
