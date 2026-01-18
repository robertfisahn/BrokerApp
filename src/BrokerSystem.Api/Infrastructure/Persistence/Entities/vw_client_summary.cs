using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Infrastructure.Persistence.Entities;

[Keyless]
public partial class vw_client_summary
{
    public int? id { get; set; }

    public string? name { get; set; }

    public long? policies_count { get; set; }

    public decimal? total_premium { get; set; }
}
