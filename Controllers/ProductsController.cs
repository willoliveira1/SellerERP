using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SellerERP.Dtos.ProductDto;
using SellerERP.Models;
using SellerERP.Repositories.Interfaces;

namespace SellerERP.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductsController(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    //GET api/products
    [HttpGet]
    public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
    {
        var products = _productRepository.GetAllItems();

        return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
    }

    //GET api/products/{id}
    [HttpGet("{id}", Name = "GetProductById")]
    public ActionResult<IEnumerable<ProductReadDto>> GetProductById(int id)
    {
        var product = _productRepository.GetItemById(id);

        if (product != null)
        {
            return Ok(_mapper.Map<ProductReadDto>(product));
        }
        else
        {
            return NotFound();
        }
    }

    //POST api/products
    [HttpPost]
    public ActionResult<ProductCreateDto> CreateProduct(ProductCreateDto productCreateDto)
    {
        var productModel = _mapper.Map<Product>(productCreateDto);
        _productRepository.Add(productModel);
        _productRepository.SaveChanges();

        var productReadDto = _mapper.Map<ProductReadDto>(productModel);

        return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
    }

    //PUT api/products/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto) 
    {
        var productModelFromRepository = _productRepository.GetItemById(id);
        if (productModelFromRepository == null)
        {
            return NotFound();
        }

        _mapper.Map(productUpdateDto, productModelFromRepository);
        _productRepository.Edit(productModelFromRepository);
        _productRepository.SaveChanges();

        return NoContent();
    }

    //PATCH api/products/{id}
    [HttpPatch("{id}")]
    public ActionResult PartialProductUpdate(int id)
    {
        var patchDoc = new JsonPatchDocument<ProductUpdateDto>();
        var productModelFromRepository = _productRepository.GetItemById(id);
        if (productModelFromRepository == null)
        {
            return NotFound();
        }

        var productToPatch = _mapper.Map<ProductUpdateDto>(productModelFromRepository);
        patchDoc.ApplyTo(productToPatch, ModelState);
        if (!TryValidateModel(productToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(productToPatch, productModelFromRepository);
        _productRepository.Edit(productModelFromRepository);
        _productRepository.SaveChanges();

        return NoContent();
    }

    //DELETE api/product/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        var productModelFromRepository = _productRepository.GetItemById(id);
        if (productModelFromRepository == null)
        {
            return NotFound();
        }

        _productRepository.Delete(productModelFromRepository);
        _productRepository.SaveChanges();

        return NoContent();
    }
}