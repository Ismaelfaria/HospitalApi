using FluentValidation;
using HospitalApi.Mappers.Models;

namespace HospitalApi.Mappers.Validator
{
    public class ModelInputValidator : AbstractValidator<HospitalInputModel>
    {
        public ModelInputValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Name não pode ser vazio");

            RuleFor(m => m.Age)
                .NotEmpty()
                .WithMessage("Idade não pode ser vazio");

            RuleFor(m => m.Sexuality)
                .NotEmpty()
                .WithMessage("Sexualidade não pode ser vazia");

            RuleFor(m => m.Condition)
                .NotEmpty()
                .WithMessage("A condiçao não pode ser vazia");
        }
    }
}
