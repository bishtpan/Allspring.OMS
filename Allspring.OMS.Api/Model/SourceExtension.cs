using Allspring.OMS.Api.Entity.Enum;

namespace Allspring.OMS.Api.Model
{
    public static class SourceExtension
    {
        public static IEnumerable<Line> ReadAll(this SourceType source, IConfiguration configuration)
        {
            var fileName = configuration[$"Input:{source}:FileName"];
            var delimiter = configuration[$"Input:{source}:Delimiter"];

            char delimiterForSplit = ',';
            Char.TryParse(delimiter, out delimiterForSplit);

            var filePath = $"Csv/{fileName}.csv";

            var rows = File.ReadAllLines(filePath);
            var lines = from row in rows
                        select new Line(row);
            return lines;
        }
    }
}
