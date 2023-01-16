namespace Allspring.OMS.Api.Model
{
    public static class IConfigurationExtension
    {
        public static FileMetadata extractFileMetadata(this IConfiguration configuration, OMSType omsType)
        {
            var prefix = $"Output:{omsType}";
            var extn = configuration[$"{prefix}:Extention"];
            var delimiter = configuration[$"{prefix}:Delimiter"];
            bool shouldHaveHeader;
            Boolean.TryParse(configuration[$"{prefix}:Header"], out shouldHaveHeader);
            var folderName = configuration["Output:Folder"];
            var fileName= configuration[$"{prefix}:FileName"];
            var HeaderLine = configuration[$"{prefix}:HeaderText"];

            return new FileMetadata { Delimiter = char.Parse(delimiter), Extention = extn, 
                ShouldHaveHeader = shouldHaveHeader,
                FolderName = folderName,
                FileName= fileName,
                HeaderLine = HeaderLine 

            };
        } 
    }
}
