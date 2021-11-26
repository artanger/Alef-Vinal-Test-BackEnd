using System.Collections.Generic;
using DAL.Models;

namespace DAL.Abstractions
{
    public interface ICodeRepository
    {
        IEnumerable<Code> GetAllCodes();

        Code GetCode(int id);

        int AddCode(Code code);

        int DeleteCode(int id);

        int UpdateCode(Code code);
    }
}
