using Domain.Eshop.Models.ContactUs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Configuration.ContactUsConfig
{
    public class ContactUsConfig : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.Property(i => i.Title).IsRequired().HasMaxLength(200);
            builder.Property(i => i.Fullname).IsRequired().HasMaxLength(60);
            builder.Property(i => i.Email).IsRequired().HasMaxLength(30);
            builder.Property(i => i.Mobile).IsRequired().HasMaxLength(15);
            builder.Property(i => i.Description).IsRequired().HasMaxLength(800);
            builder.Property(i => i.Answer).HasMaxLength(200);

            builder.HasOne(r => r.AnswerUser)
                .WithMany(r => r.ContactUs)
                .HasForeignKey(r => r.AnswerUserId)
                 .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
