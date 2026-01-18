using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Infrastructure.Persistence.Entities;

[Index("name", Name = "policy_types_name_key", IsUnique = true)]
public partial class policy_type
{
    [Key]
    public int id { get; set; }

    public string name { get; set; } = null!;

    [InverseProperty("policy_type")]
    public virtual ICollection<policy> policies { get; set; } = new List<policy>();
}
