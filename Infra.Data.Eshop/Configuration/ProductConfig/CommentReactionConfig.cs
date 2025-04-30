using Domain.Eshop.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Configuration.ProductConfig
{
    public class CommentReactionConfig:IEntityTypeConfiguration<CommentReaction>
    {
        public void Configure(EntityTypeBuilder<CommentReaction> builder)
        {
            //builder.Property(g => g.CommentId).IsRequired();
            //builder.Property(t => t.ProductId).IsRequired();
            //builder.Property(e => e.UserId).IsRequired();
            builder.Property(t => t.Status).IsRequired();

            builder.HasOne(cr => cr.Product)
                .WithMany(t => t.CommentReactions)
                .HasForeignKey(t => t.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(cr => cr.User)
                .WithMany(i => i.CommentReactions)
                .HasForeignKey(y => y.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.ProductComment)
                .WithMany(e => e.CommentReactions)
                .HasForeignKey(v => v.CommentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
