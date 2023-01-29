using ClothesApi.Data;
using ClothesApi.Entities;
using ClothesApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace ClothesApi.Controllers;
[Route("api/[controller]")]
[ApiController]

public class ProductsController : Controller
{
	private readonly AppDbContext _context;
    private readonly IValidator<CreateProductDto> _createProductDtoValidator;
	private readonly IValidator<UpdateProductDto> _updateProductDtoValidator;

    public ProductsController(AppDbContext context, 
        IValidator<CreateProductDto> createProductDtoValidator,
        IValidator<UpdateProductDto> updateProductDtoValidator)
    {
        _context = context;
        _createProductDtoValidator = createProductDtoValidator;
        _updateProductDtoValidator = updateProductDtoValidator;
    }

    [HttpGet]
	public async Task<IActionResult> GetAllProducts()
	{
		var products = await _context.Products.ToListAsync();
		
		if(products is null)
			return NotFound();

		return Ok(products);
	}

	[HttpPost]
	public async Task<IActionResult> AddProduct([FromForm]CreateProductDto createProductDto)
	{
		var validateProduct = await _createProductDtoValidator.ValidateAsync(createProductDto);

		if (!validateProduct.IsValid)
			return BadRequest();

		var product = new Product()
		{
			Name = createProductDto.Name,
			Price = createProductDto.Price,
			PhotoPath = createProductDto.PhotoPath,
			Size = createProductDto.Size
		};

		_context.Products.Add(product);
		_context.SaveChanges();

		return Ok(product);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateProduct(uint id, UpdateProductDto updateProductModel)
	{
        var validateProduct = await _updateProductDtoValidator.ValidateAsync(updateProductModel);

        if (!validateProduct.IsValid)
            return BadRequest();

        var product = _context.Products.FirstOrDefault(p => p.Id == id);

		product!.Name = updateProductModel.Name;
		product.Price = updateProductModel.Price;
		product.PhotoPath = updateProductModel.PhotoPath;
		product.Size = ESize.QirqTort;

		_context.SaveChanges();

		return Ok(product);
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteProduct(uint id)
	{
        var product = _context.Products.FirstOrDefault(p => p.Id == id);

		_context.Products.Remove(product);
		await _context.SaveChangesAsync();
		 
		return Ok(product);
    }
}