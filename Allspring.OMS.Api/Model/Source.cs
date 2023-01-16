using System.Runtime.CompilerServices;

namespace Allspring.OMS.Api.Model
{
    public class Source
    {
        public string FileName { get; private set; }
        public char Delimiter{ get; private set; }
        public Source(string fileName , char delimiter)
        {
            FileName= fileName;
            Delimiter= delimiter;
        }

        public Source(string fileName):this(fileName,',')
        {

        }
    }
}
