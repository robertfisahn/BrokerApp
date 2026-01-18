using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Infrastructure.Persistence.Entities;

[Index("nip", Name = "clients_nip_key", IsUnique = true)]
public partial class client
{
    [Key]
    public int id { get; set; }

    public string name { get; set; } = null!;

    [StringLength(10)]
    public string nip { get; set; } = null!;

    public string industry { get; set; } = null!;

    public bool is_active { get; set; }

    public DateTime created_at { get; set; }

    [InverseProperty("client")]
    public virtual ICollection<policy> policies { get; set; } = new List<policy>();

    [InverseProperty("client")]
    public virtual ICollection<risk_assessment> risk_assessments { get; set; } = new List<risk_assessment>();
}
