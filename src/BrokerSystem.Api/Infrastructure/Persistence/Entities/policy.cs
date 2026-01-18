using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Infrastructure.Persistence.Entities;

public partial class policy
{
    [Key]
    public int id { get; set; }

    public int client_id { get; set; }

    public int policy_type_id { get; set; }

    public DateOnly start_date { get; set; }

    public DateOnly end_date { get; set; }

    [Precision(12, 2)]
    public decimal premium { get; set; }

    [InverseProperty("policy")]
    public virtual ICollection<claim> claims { get; set; } = new List<claim>();

    [ForeignKey("client_id")]
    [InverseProperty("policies")]
    public virtual client client { get; set; } = null!;

    [ForeignKey("policy_type_id")]
    [InverseProperty("policies")]
    public virtual policy_type policy_type { get; set; } = null!;
}
