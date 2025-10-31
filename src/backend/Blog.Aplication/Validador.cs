using FluentValidation;

namespace Blog.Aplication
{
    public static class validador
    {      
        public static IRuleBuilderOptions<T, string> validarIsNullOrEmpt<T>(
         this IRuleBuilder<T, string> ruleBuilder, string msgErro)
        {
            return ruleBuilder
                .NotEmpty().WithMessage(msgErro)
                .NotNull().WithMessage(msgErro);
        }

        public static IRuleBuilderOptions<T, string> vadarTamanhoMin<T>(
        this IRuleBuilder<T, string> ruleBuilder, int min, string msgErro)
        {
            return ruleBuilder
                .MinimumLength(min).WithMessage(msgErro)
                .NotNull().WithMessage(msgErro);
        }
        public static IRuleBuilderOptions<T, string> vadarTamanhoMax<T>(
            this IRuleBuilder<T, string> ruleBuilder, int max, string msgErro)
        {
            return ruleBuilder
                .MaximumLength(max).WithMessage(msgErro)
                .NotNull().WithMessage(msgErro);
        }
    }
}
