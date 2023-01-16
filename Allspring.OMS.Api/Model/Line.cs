using System.Runtime.CompilerServices;
using Allspring.OMS.Api.Service.Validators;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Allspring.OMS.Api.Model;

public class Line
{
    private readonly string _data;
    public Line(string data) {
        _data = data;
    }

    public string Content => _data;

    public override string ToString()
    {
        return Content;
    }
}
