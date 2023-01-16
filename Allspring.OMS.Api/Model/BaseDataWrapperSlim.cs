using System.Runtime.CompilerServices;

namespace Allspring.OMS.Api.Model;

public record BaseDataWrapperSlim
{
    public Portfolio Portfolio { get; set; }
    public Security Security { get; set; } 
    public Transaction Transaction { get; set; }
}
