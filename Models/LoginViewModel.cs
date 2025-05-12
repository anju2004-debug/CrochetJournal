using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required]
    public string LoginIdentifier{get; set;}//either name or emial

    [Required]
    [DataType(DataType.Password)]
    public string Password{get; set;}
}