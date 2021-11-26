using Microsoft.AspNetCore.Mvc;
using ProjectAlefVinal.Models;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Abstractions;
using BLL.Models;
using ProjectAlefVinal.Helpers;

namespace ProjectAlefVinal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICodeService _service;

        public HomeController(IMapper mapper, ICodeService service)
        {
            _mapper = mapper;
            _service = service;
        }
        
        [HttpGet]
        [Route("getcodes")]
        public ActionResult<List<CodeModel>> GetAllCodes()
        {
            return _service.GetAllCodes().Select(code => _mapper.Map<CodeDto, CodeModel>(code)).ToList();
        }
        
        [HttpGet]
        [Route("getcode")]
        public ActionResult<CodeModel> GetCode(int id)
        {
            if (id == 0)
            {
                return BadRequest(Consts.ValidationMessages.CodeIdCanNotBeEmptyOrZero);
            }

            var code = _service.GetCode(id);
            if (code.Id == -1)
            {
                return BadRequest($"Code within id='{id}' was not found");
            }

            return _mapper.Map<CodeDto, CodeModel>(code);
        }

        [HttpPost]
        [Route("addcode")]
        public ActionResult AddCode([FromBody] CodeModel model)
        {
            var result = _service.AddCode(_mapper.Map<CodeModel, CodeDto>(model));
            if (result == 0)
            {
                return BadRequest(Consts.ValidationMessages.ChangesNotAffected);
            }

            return Ok(Consts.ValidationMessages.Success);
        }

        [HttpGet]
        [Route("deletecode")]
        public ActionResult DeleteCode(int id)
        {
            if (id == 0)
            {
                return BadRequest(Consts.ValidationMessages.CodeIdCanNotBeEmptyOrZero);
            }

            var result = _service.DeleteCode(id);
            if (result == -1)
            {
                return BadRequest($"Code within id='{id}' was not found");
            }
            if (result == 0)
            {
                return BadRequest(Consts.ValidationMessages.ChangesNotAffected);
            }

            return Ok(Consts.ValidationMessages.Success);
        }

        [HttpPost]
        [Route("editcode")]
        public ActionResult EditCodeById([FromBody] CodeModel code)
        {
            var result = _service.UpdateCode(_mapper.Map<CodeModel, CodeDto>(code));
            if (result == -1)
            {
                return BadRequest($"Code within id='{code.Id}' was not found");
            }
            if (result == 0)
            {
                return BadRequest(Consts.ValidationMessages.ChangesNotAffected);
            }

            return Ok(Consts.ValidationMessages.Success);
        }
    }
}
