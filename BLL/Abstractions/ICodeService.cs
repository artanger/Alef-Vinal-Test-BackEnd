using System.Collections.Generic;
using BLL.Models;

namespace BLL.Abstractions
{
    public interface ICodeService
    {
        IEnumerable<CodeDto> GetAllCodes();

        CodeDto GetCode(int id);

        int AddCode(CodeDto code);

        int DeleteCode(int id);

        int UpdateCode(CodeDto code);
    }
}
