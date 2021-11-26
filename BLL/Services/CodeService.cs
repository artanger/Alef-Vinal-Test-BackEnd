using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Abstractions;
using BLL.Models;
using DAL.Abstractions;
using DAL.Models;

namespace BLL.Services
{
    public class CodeService: ICodeService
    {
        private readonly IMapper _mapper;
        private readonly ICodeRepository _repository;

        public CodeService(IMapper mapper, ICodeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<CodeDto> GetAllCodes()
        {
            return _repository.GetAllCodes().Select(code => _mapper.Map<Code, CodeDto>(code));
        }

        public CodeDto GetCode(int id)
        {
            var code = _repository.GetCode(id);
            
            return _mapper.Map<Code, CodeDto>(code);
        }

        public int AddCode(CodeDto code)
        {
            return _repository.AddCode(_mapper.Map<CodeDto, Code>(code));
        }

        public int DeleteCode(int id)
        {
            return _repository.DeleteCode(id);
        }

        public int UpdateCode(CodeDto code)
        {
            return _repository.UpdateCode(_mapper.Map<CodeDto, Code>(code));
        }
    }
}
