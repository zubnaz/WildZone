using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.Entities;
public class Grouping
{
    [NotNull]
    public Guid Id { get; set; }
    [MaxLength(128)]
    [NotNull]
    public required string Name { get; set; }
    public int Power { get; set; }
    public Guid? LeaderId { get; set; }
    [ForeignKey(nameof(LeaderId))]
    public Stalker? Leader { get; set; }
    public ICollection<Stalker>? Members { get; set; }
    public required string Logo { get; set; }
}

