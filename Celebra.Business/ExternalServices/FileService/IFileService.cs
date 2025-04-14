using Celebra.Business.Dtos.FileDtos;
using Microsoft.AspNetCore.Http;

namespace Celebra.Business.ExternalServices.FileService;

public interface IFileService
{
    Task<List<FileDto>> UploadAllAsync(string path, ICollection<IFormFile> files);
    Task<FileDto> UploadAsync(string path, IFormFile file);
    Task<FileDto> ImageUploadLowQualityAsync(string path, IFormFile file);
    Task VideoUploadLowQualityAsync(string path, IFormFile file);
    string RenameFile(string fileName);
    void DeleteFile(string path);
    void DeleteFiles(IEnumerable<string> paths);
    List<string> GetFiles(string pathOrContainerName);
    bool HasFile(string pathOrContainerName);
    Task CopyAsync(string path, IFormFile file);
    void DeleteFilesInPath(string path);
}
