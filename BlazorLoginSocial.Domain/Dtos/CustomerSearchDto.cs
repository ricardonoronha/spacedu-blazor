namespace BlazorLoginSocial.Domain.Dtos;

public class CustomerSearchDto : IPaginatedSearchDto
{
    public string? SearchWord { get; set; }  = string.Empty;
    public int? PageIndex { get; set; } = 1;
    public int? PageSize { get; set; } = 15;

    public CustomerSearchDto()
    { }

    public CustomerSearchDto(string searchWord, int pageIndex, int pageSize)
    {
        SearchWord = searchWord;
        PageIndex = pageIndex;
        PageSize = pageSize;
    }
}
