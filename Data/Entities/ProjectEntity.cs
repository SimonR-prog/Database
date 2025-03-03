namespace Data.Entities;

public class ProjectEntity
{
    public int Id { get; set; }
    public string ProjectName { get; set; } = null!;
    public string? ProjectDescription { get; set; }

    public int StatusId { get; set; }
    public int ClientId { get; set; }
    public int ProjectManagerId { get; set; }
    public int? ProductId { get; set; }
    public int ProjectTypeId { get; set; }
    public int ProjectScheduleId {  get; set; }
    public int? ProjectTimeLogId { get; set; }

    public StatusEntity Status { get; set; } = null!;
    public ClientEntity Client { get; set; } = null!;
    public EmployeeEntity ProjectManager { get; set; } = null!;
    public ProductEntity? Product { get; set; }
    public ProjectTypeEntity ProjectType { get; set; } = null!;
    public ProjectSchedulesEntity ProjectSchedule { get; set; } = null!;
    public ProjectTimeLogEntity? ProjectTimeLog { get; set; }
}

