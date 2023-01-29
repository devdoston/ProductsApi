using ClothesApi.Dto;
using System.ComponentModel.DataAnnotations;

namespace ClothesApi.Entities;

public class Product
{
    public uint Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? PhotoPath { get; set; }
    public ESize? Size { get; set; }
}