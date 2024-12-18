using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities;
public class Avatar
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<Stalker>? Stalkers { get; set; }
    public Guid GroupingId { get; set; }
    [ForeignKey(nameof(GroupingId))]
    public Grouping? Group { get; set; }
}

