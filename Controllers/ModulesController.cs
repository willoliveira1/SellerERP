using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SellerERP.Dtos.ModuleDto;
using SellerERP.Models;
using SellerERP.Repositories.Interfaces;

namespace SellerERP.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModulesController : ControllerBase
{
    private readonly IModuleRepository _moduleRepository;
    private readonly IMapper _mapper;

    public ModulesController(IModuleRepository moduleRepository, IMapper mapper)
    {
        _moduleRepository = moduleRepository;
        _mapper = mapper;
    }

    //GET api/modules
    [HttpGet]
    public ActionResult<IEnumerable<ModuleReadDto>> GetAllModules()
    {
        var modules = _moduleRepository.GetAllItems();

        return Ok(_mapper.Map<IEnumerable<ModuleReadDto>>(modules));
    }

    //GET api/modules/{id}
    [HttpGet("{id}", Name = "GetModuleById")]
    public ActionResult<IEnumerable<ModuleReadDto>> GetModuleById(int id)
    {
        var module = _moduleRepository.GetItemById(id);

        if (module != null)
        {
            return Ok(_mapper.Map<ModuleReadDto>(module));
        }
        else
        {
            return NotFound();
        }
    }

    //POST api/modules
    [HttpPost]
    public ActionResult<ModuleCreateDto> CreateModule(ModuleCreateDto moduleCreateDto)
    {
        var moduleModel = _mapper.Map<Module>(moduleCreateDto);
        _moduleRepository.Add(moduleModel);
        _moduleRepository.SaveChanges();

        var moduleReadDto = _mapper.Map<ModuleReadDto>(moduleModel);

        return CreatedAtRoute(nameof(GetModuleById), new { Id = moduleReadDto.Id }, moduleReadDto);
    }

    //PUT api/modules/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateModule(int id, ModuleUpdateDto moduleUpdateDto)
    {
        var moduleModelFromRepository = _moduleRepository.GetItemById(id);
        if (moduleModelFromRepository == null)
        {
            return NotFound();
        }

        _mapper.Map(moduleUpdateDto, moduleModelFromRepository);
        _moduleRepository.Edit(moduleModelFromRepository);
        _moduleRepository.SaveChanges();

        return NoContent();
    }

    //PATCH api/modules/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialUpdateModule(int id, JsonPatchDocument<ModuleUpdateDto> patchDoc)
    {
        var moduleModelFromRepository = _moduleRepository.GetItemById(id);
        if (moduleModelFromRepository == null)
        {
            return NotFound();
        }

        var moduleToPatch = _mapper.Map<ModuleUpdateDto>(moduleModelFromRepository);
        patchDoc.ApplyTo(moduleToPatch, ModelState);
        if (!TryValidateModel(moduleToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(moduleToPatch, moduleModelFromRepository);
        _moduleRepository.Edit(moduleModelFromRepository);
        _moduleRepository.SaveChanges();

        return NoContent();
    }

    //DELETE api/modules/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteModule(int id)
    {
        var moduleModelFromRepository = _moduleRepository.GetItemById(id);
        if(moduleModelFromRepository == null)
        {
            return NotFound();
        }

        _moduleRepository.Delete(moduleModelFromRepository);
        _moduleRepository.SaveChanges();

        return NoContent();
    }
}