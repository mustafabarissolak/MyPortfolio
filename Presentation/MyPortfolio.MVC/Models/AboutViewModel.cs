using MyPortfolio.Application.DTOs;

namespace MyPortfolio.MVC.Models;

public class AboutViewModel
{
    public AboutDto? AboutModel { get; set; }
    public List<SocialMediaAccountDto>? SocialMediaAccountModels { get; set; }
    public ContactInfoDto? ContactInfoDtoModel { get; set; }
}
