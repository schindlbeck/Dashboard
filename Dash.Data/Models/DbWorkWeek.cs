using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Dash.Data.Models
{
    public class DbWorkWeek
    {
        public int Id { get; set; }
        public int Year { get; set; }

        public int CalendarWeek { get; set; }

        public int ProductionMinutes { get; set; }

        public List<WorkDay> WorkDays { get; set; }

        public override string ToString()
        {
            return "CW: " + CalendarWeek.ToString() + " Days: " + WorkDays.Count.ToString();
        }
    }

    public class DbWorkWeekEntityConfiguration : IEntityTypeConfiguration<DbWorkWeek>
    {
        private readonly JsonSerializerOptions options = new();

        public void Configure(EntityTypeBuilder<DbWorkWeek> builder)
        {
            builder.HasKey(e => e.Id);

            ValueConverter<List<WorkDay>, string> valueConverter = new(wd => JsonSerializer.Serialize(wd, options),
                                                                        wd => JsonSerializer.Deserialize<List<WorkDay>>(wd, options));

            builder.Property(p => p.WorkDays).HasConversion(valueConverter);

            builder.Property(p => p.WorkDays).HasColumnName("DetailInfo");
        }
    }
}
