using Microsoft.AspNetCore.Http;
using MyPortfolio.Application.Storages;

namespace MyPortfolio.Infrastructure.Storages;

public class StorageService : IStorageService
{
    readonly IStorage _storage;

    public StorageService(IStorage storage)
    {
        _storage = storage;
    }

    public Task DeleteAsync(string path) => _storage.DeleteAsync(path);

    public Task<string> UploadAsync(string path, IFormFile image) => _storage.UploadAsync(path, image);
}
