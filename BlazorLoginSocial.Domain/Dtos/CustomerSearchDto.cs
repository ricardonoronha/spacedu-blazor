namespace BlazorLoginSocial.Domain.Dtos;

public class CustomerSearchDto(string searchWord)
{
    public string SearchWord { get; set; } = searchWord;
}