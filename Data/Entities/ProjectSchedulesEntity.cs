using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class ProjectSchedulesEntity
{
    public int Id { get; set; }

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }
}


