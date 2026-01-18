using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Infrastructure.Persistence.Entities;

public partial class claim
{
    [Key]
    public int id { get; set; }

    public int policy_id { get; set; }

    public DateOnly claim_date { get; set; }

    [Precision(12, 2)]
    public decimal amount { get; set; }

    [ForeignKey("policy_id")]
    [InverseProperty("claims")]
    public virtual policy policy { get; set; } = null!;
}
