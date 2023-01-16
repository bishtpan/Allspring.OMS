using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allspring.OMS.Api.Model;

namespace Allspring.OMS.Api.Test
{
    internal static class Utility
    {
        public static Microsoft.Extensions.Configuration.IConfiguration SetupIConfiguration(string omsType, string fileName,
            string extension , string delimiter, string header, string headerText)
        {
            var configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            configuration.SetupGet(x => x[It.Is<string>(s => s == "Input:Portfolio:Delimiter")]).Returns(",");
            configuration.SetupGet(x => x[It.Is<string>(s => s == "Input:Security:Delimiter")]).Returns(",");
            configuration.SetupGet(x => x[It.Is<string>(s => s == "Input:Transaction:Delimiter")]).Returns(",");

            configuration.SetupGet(x => x[It.Is<string>(s => s == "Output:Folder")]).Returns("OMSFiles");
            configuration.SetupGet(x => x[It.Is<string>(s => s == $"Output:{omsType}:FileName")]).Returns(fileName);
            configuration.SetupGet(x => x[It.Is<string>(s => s == $"Output:{omsType}:Extention")]).Returns(extension);
            configuration.SetupGet(x => x[It.Is<string>(s => s == $"Output:{omsType}:Delimiter")]).Returns(delimiter);
            configuration.SetupGet(x => x[It.Is<string>(s => s == $"Output:{omsType}:Header")]).Returns(header);
            configuration.SetupGet(x => x[It.Is<string>(s => s == $"Output:{omsType}:HeaderText")]).Returns(headerText);

            return configuration.Object;
        }


        public static  bool VerifyFileMetadata(FileMetadata metadata, char delimiter, string extension, string fileName, 
            string headerText, bool shouldHaveHeader)
        {
            return metadata.Delimiter == delimiter
                && metadata.Extention == extension
                && metadata.FileName == fileName
                && metadata.HeaderLine == headerText
                && metadata.ShouldHaveHeader == shouldHaveHeader;
        }

        public static bool VerifyFileData(IEnumerable<string> lines, string security , string code , string splitter=",")
        {
            var line = lines.First();
            var splitted = line.Split(splitter);
            return splitted[0] == security && splitted[1] == code;
        }
    }
}
