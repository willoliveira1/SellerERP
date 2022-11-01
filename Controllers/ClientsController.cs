using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SellerERP.Dtos.ClientDto;
using SellerERP.Models;
using SellerERP.Repositories.Interfaces;

namespace SellerERP.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public ClientsController(IClientRepository clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    //GET api/clients
    [HttpGet]
    public ActionResult <IEnumerable<Client>> GetAllClients()
    {
        var clientItems = _clientRepository.GetAllItems();

        return Ok(clientItems);
    }

    //GET api/clients/{id}
    [HttpGet("{id}", Name = "GetClientById")]
    public ActionResult <IEnumerable<Client>> GetClientById(int id)
    {
        var clientItem = _clientRepository.GetItemById(id);

        return Ok(clientItem);
    }

    //POST api/clients
    [HttpPost]
    public ActionResult<ClientCreateDto> CreateClient(ClientCreateDto clientCreateDto)
    {
        var clientModel = _mapper.Map<Client>(clientCreateDto);
        _clientRepository.Add(clientModel);
        _clientRepository.SaveChanges();

        var clientReadDto = _mapper.Map<ClientReadDto>(clientModel);

        return CreatedAtRoute(nameof(GetClientById), new { Id = clientReadDto.Id }, clientReadDto);
    }

    //PUT api/clients/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateClient(int id, ClientUpdateDto clientUpdateDto)
    {
        var clientModelFromRepository = _clientRepository.GetItemById(id);
        if (clientModelFromRepository == null)
        {
            return NotFound();
        }

        _mapper.Map(clientUpdateDto, clientModelFromRepository);
        _clientRepository.Edit(clientModelFromRepository);
        _clientRepository.SaveChanges();

        return NoContent();
    }

    //PATCH api/client/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialUpdateModule(int id, JsonPatchDocument<ClientUpdateDto> patchDoc)
    {
        var clientModelFromRepository = _clientRepository.GetItemById(id);
        if (clientModelFromRepository == null)
        {
            return NotFound();
        }

        var clientToPatch = _mapper.Map<ClientUpdateDto>(clientModelFromRepository);
        patchDoc.ApplyTo(clientToPatch, ModelState);
        if (!TryValidateModel(clientToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(clientToPatch, clientModelFromRepository);
        _clientRepository.Edit(clientModelFromRepository);
        _clientRepository.SaveChanges();

        return NoContent();
    }

    //DELETE api/client/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteClient(int id)
    {
        var clientModelFromRepository = _clientRepository.GetItemById(id);
        if (clientModelFromRepository == null)
        {
            return NotFound();
        }

        _clientRepository.Delete(clientModelFromRepository);
        _clientRepository.SaveChanges();

        return NoContent();
    }
}