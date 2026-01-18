using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BrokerSystem.Api.Infrastructure.Persistence.Entities;

public partial class risk_assessment
{
    [Key]
    public int id { get; set; }

    public int client_id { get; set; }

    public string? notes { get; set; }

    [Column(TypeName = "timestamp without time zone")]
    public DateTime assessed_at { get; set; }

    [ForeignKey("client_id")]
    [InverseProperty("risk_assessments")]
    public virtual client client { get; set; } = null!;
}
