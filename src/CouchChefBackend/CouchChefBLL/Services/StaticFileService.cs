using CouchChefBLL.Configurations;
using CouchChefBLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace CouchChefBLL.Services;

public class StaticFileService : IStaticFileService
{
    private readonly StaticFileSettings _fileSettings;
    private readonly string _rootPath;
    public StaticFileService(IOptions<StaticFileSettings> fileSettings, string rootPath)
    {
        _fileSettings = fileSettings.Value;
        _rootPath = rootPath;
    }

    public void Remove(string relativePath)
    {
        string directoryPath = _rootPath + "/" + _fileSettings.Path;
        string fullPath = _rootPath + "/" + relativePath;
        File.Delete(fullPath);
    }

    public async Task<string> UploadAsync(IFormFile file, bool addCustomGuid = true)
    {
        var customPart = addCustomGuid ? Guid.NewGuid().ToString() : string.Empty;
        var fileName = customPart + file.FileName;

        var relativePath = "/" + _fileSettings.Path + "/" + fileName;
        var directoryPath = _rootPath + "/" + _fileSettings.Path;
        string fullPath = directoryPath + "/" + fileName;

        if (Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        string[] fileEntries = Directory.GetFiles(directoryPath);

        if (fileName.Contains(fullPath))
        {
            throw new Exception("File is already exist.");
        }

        using (var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return relativePath;
    }
}
