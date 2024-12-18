using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.Entities;
public class Rang
{
    [NotNull]
    public Guid Id { get; set; }
    [MaxLength(128)]
    [NotNull]
    public required string Name { get; set; }
    public int Power { get; set; }
    public ICollection<Stalker>? Stalkers { get; set; }
}

