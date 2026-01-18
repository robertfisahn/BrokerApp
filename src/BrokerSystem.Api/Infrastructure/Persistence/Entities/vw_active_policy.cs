using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Infrastructure.Persistence.Entities;

[Keyless]
public partial class vw_active_policy
{
    public int? policy_id { get; set; }

    public string? client_name { get; set; }

    public string? policy_type { get; set; }

    public DateOnly? start_date { get; set; }

    public DateOnly? end_date { get; set; }

    [Precision(12, 2)]
    public decimal? premium { get; set; }
}
