using ClothesApi.Entities;

namespace ClothesApi.Dto;

public class CreateProductDto
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? PhotoPath { get; set; }
    public ESize? Size { get; set; }
}