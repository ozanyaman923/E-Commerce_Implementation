using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product name cannot be empty YESYESYESYESYESYES");
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Product name must be at least 2 characters long");
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than 0");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Units in stock cannot be negative");
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
        }
    }
}
