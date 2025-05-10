using Microsoft.AspNetCore.Http;

namespace CouchChefBLL.Interfaces;

public interface IStaticFileService
{
    Task<string> UploadAsync(IFormFile file, bool addCustomGuid = true);
    void Remove(string relativePath);
}
