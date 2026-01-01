using Microsoft.AspNetCore.Http;

namespace MyPortfolio.Application.Storages;

public interface IStorage
{
    Task<string> UploadAsync(string folderName, IFormFile images);
    Task DeleteAsync(string filePath);
}
