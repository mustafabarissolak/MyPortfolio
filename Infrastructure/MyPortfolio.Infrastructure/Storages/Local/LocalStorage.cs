using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyPortfolio.Application.Storages.Local;

namespace MyPortfolio.Infrastructure.Storages.Local;

public class LocalStorage : Storage, ILocalStorage
{
    readonly IWebHostEnvironment _env;

    public LocalStorage(IWebHostEnvironment env)
    {
        _env = env;
    }
    public async Task DeleteAsync(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            return;

        // bşataki / karakterini kaldırır çünkü (wwwroot) yok sayılır
        filePath = filePath.TrimStart('/');

        // / karakterlerini işletim sistemine uygun dizin ayırıcıya çevirir
        filePath = filePath.Replace("/", Path.DirectorySeparatorChar.ToString());

        // wwwroot\uploads\about-image\xxx.jpg
        string fullPath = Path.Combine(_env.WebRootPath, filePath);

        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }

    public async Task<string> UploadAsync(string folderPath, IFormFile image)
    {
        // wwwroot/uploads
        var dir = Path.Combine(_env.WebRootPath, "uploads", folderPath);

        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        var name = Path.GetFileNameWithoutExtension(image.FileName); // "imageName"
        var ext = Path.GetExtension(image.FileName); // ".jpg"

        var fileName = name + ext; // "imageName.jpg"
        var path = Path.Combine(dir, fileName); // wwwroot/uploads/{folderPath}/{fileName}

        byte i = 1;
        while(File.Exists(path))
        {
            fileName = $"{name}({i}){ext}";
            path = Path.Combine(dir, fileName);
            i++;
        }

        await using var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);

        return $"/uploads/{folderPath}/{fileName}";
    }
}
