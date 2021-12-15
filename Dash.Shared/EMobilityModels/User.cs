using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMobility.Models
{
#nullable enable

    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string RfidTag { get; set; } = string.Empty;

        public DateTime Entry { get; set; }

        public DateTime? Leaving { get; set; }

    }

    public class CUserEntityConfiguration : IEntityTypeConfiguration<User>
    {

        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.ID);
            builder.HasCheckConstraint("LeavingAfterEntry",
                                                      $@"[{nameof(User.Leaving)}] IS NULL OR [{nameof(User.Leaving)}] > [{nameof(User.Entry)}]");
        }
    }
}