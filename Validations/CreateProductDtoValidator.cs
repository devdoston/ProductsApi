using ClothesApi.Dto;
using FluentValidation;

namespace ClothesApi.Validations;
public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
	public CreateProductDtoValidator()
	{
		RuleFor(productDto => productDto.Name)
			.NotNull()
			.Length(1, 50)
			.WithMessage("Bu yerga mahsulot nomini kiriting!");

		RuleFor(productDto => productDto.Price)
			.NotNull()
			.WithMessage("Bu yerga mahsulotnign narxini kiriting");
	}
}