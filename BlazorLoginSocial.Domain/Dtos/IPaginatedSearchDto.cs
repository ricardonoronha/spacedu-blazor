namespace BlazorLoginSocial.Domain.Dtos;

public interface IPaginatedSearchDto
{
    int? PageIndex { get; set; }
    int? PageSize { get; set; }
}
