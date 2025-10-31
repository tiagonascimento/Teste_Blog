using Blog.Comunication.response;
using Blog.Exception;
using Blog.Exception.excecao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Blog.API.Filter
{
    public class ExcecaoFiltro:IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BlogExcecaoBase)
                Excecao(context);
            else
                ErroDesconhecido(context);
        }
        //trata erros conhecidos 
        private void Excecao(ExceptionContext context)
        {
            if (context.Exception is BlogExcecaoValidacao)
            {
                var ex = context.Exception as BlogExcecaoValidacao;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseException(ex.MensagemErro));
            }
        }
        //trata erros inesperados 
        private void ErroDesconhecido(ExceptionContext context)
        {
            //add log para erro na aplicacao

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseException(MensagemExcecao.ERRO_DESCONHECIDO));
        }
    }
}

