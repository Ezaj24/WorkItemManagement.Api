using System.ComponentModel.DataAnnotations;


namespace WorkItemManagement.Api.DTOs;

public class CreateWorkItemDto

{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Description { get; set; } = string.Empty;


}