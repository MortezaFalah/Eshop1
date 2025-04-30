using Domain.Eshop.Models.Wallet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Configuration.WalletConfig
{
    public class WalletConfig : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasOne(r => r.User)
                .WithMany(g => g.Wallets)
                .HasForeignKey(e => e.Userid)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(o=>o.Order)
                .WithMany(f=>f.Wallets)
                .HasForeignKey(w=>w.OrderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
