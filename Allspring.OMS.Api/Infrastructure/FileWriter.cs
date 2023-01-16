namespace Allspring.OMS.Api.Infrastructure;

public class FileWriter : IPersister
{
    private readonly ILogger<FileWriter> _logger;
    public FileWriter(ILogger<FileWriter> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public async Task<bool> Persist(FileMetadata fileMetadata, IEnumerable<string> dataToWrite)
    {
        try
        {
            var toWrite = new List<string>();
            if (fileMetadata.ShouldHaveHeader)
            {
                toWrite.Add(fileMetadata.HeaderLine);
            }

            toWrite.AddRange(dataToWrite.ToList());

            var filePath = $"{fileMetadata.FolderName}/{fileMetadata.FileName}.{fileMetadata.Extention}";
            await File.WriteAllLinesAsync(filePath, toWrite);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error writing file for OMS AAA ${ex.ToString}");
            return false;
        }
        return true;
    }
}
