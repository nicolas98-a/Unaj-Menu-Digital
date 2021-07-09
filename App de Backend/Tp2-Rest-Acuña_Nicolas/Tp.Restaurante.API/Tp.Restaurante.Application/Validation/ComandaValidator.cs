using FluentValidation;
using Tp.Restaurante.Domain.Commands;
using Tp.Restaurante.Domain.DTOs;
using Tp.Restaurante.Domain.Entities;

namespace Tp.Restaurante.Application.Validation
{
    public class ComandaValidator : AbstractValidator<CreateComandaRequestDto>
    {
        IGenericsRepository genericsRepository;

        public ComandaValidator(IGenericsRepository genericsRepository)
        {
            this.genericsRepository = genericsRepository;

            RuleFor(e => e.FormaEntrega).Must(ExisteFormaEntrega).WithMessage("Forma de entrega no valida");
            RuleForEach(e => e.Mercaderias).Must(ExisteMercaderia).WithMessage("Mercaderia no valida");
        }

        private bool ExisteFormaEntrega(int entrega)
        {

            FormaEntrega formaEntrega  = genericsRepository.Exists<FormaEntrega>(entrega);
            if (formaEntrega == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ExisteMercaderia(int mercaderiaId)
        {

            Mercaderia mercaderia  = genericsRepository.Exists<Mercaderia>(mercaderiaId);
            if (mercaderia == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
