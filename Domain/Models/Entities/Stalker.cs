using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models.Entities;
public class Stalker : IdentityUser<Guid>
{
    [MaxLength(128)]
    [NotNull]
    public required string Alias { get; set; }
    public Guid RangId { get; set; }
    public Rang? Rang { get; set; }
    public Guid GroupingId { get; set; }
    [ForeignKey(nameof(GroupingId))]
    public Grouping? Group { get; set; }
    public bool IsLeader { get; set; } = false;
    public Guid AvatarId { get; set; }
    public Avatar? Avatar { get; set; }

}

