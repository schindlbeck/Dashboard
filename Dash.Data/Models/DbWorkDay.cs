using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Text.Json;

namespace Dash.Data.Models
{
    public class DbWorkDay
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ProductionMinutes { get; set; }

        public int CalendarWeek { get; set; }

        public WorkDay WorkDay { get; set; }
    }

    public class DbWorkDayEntityConfiguration : IEntityTypeConfiguration<DbWorkDay>
    {
        private readonly JsonSerializerOptions options = new();

        public void Configure(EntityTypeBuilder<DbWorkDay> builder)
        {
            builder.HasKey(e => e.Id);

            ValueConverter<WorkDay, string> valueConverter = new(wd => JsonSerializer.Serialize(wd, options),
                                                                        wd => JsonSerializer.Deserialize<WorkDay>(wd, options) );

            builder.Property(p => p.WorkDay).HasConversion(valueConverter);

            builder.Property(p => p.WorkDay).HasColumnName("DetailInfo");
        }
    }
}
