using Blog.Comunication.response;
using Blog.Comunication.request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Blog.Aplication.posts.interfaces;


namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponsePost), StatusCodes.Status201Created)]
        public async Task<IActionResult>Post([FromServices]  IPost post, [FromServices] IValidacaoPost validacao, ResquestPostJSON postJson)
        {
            validacao.ValidarELancarExcecao(postJson);
            var resposta = await post.CriarPost(postJson);            
            return Created(string.Empty, resposta);

        }


        [HttpPost("{id}/comments")]
        [ProducesResponseType(typeof(ResponsePost), StatusCodes.Status201Created)]
        public async Task<IActionResult> comments([FromServices] IComentario comentario, int id, [FromServices] IValidacaoComentario validacao, RequestCommentsJSON comentarioJson)
        {
            comentarioJson.IdPost = id;
            validacao.ValidarELancarExcecao(comentarioJson);
            var resposta = await comentario.CriarComentario(comentarioJson);
         
            return Created(string.Empty, resposta);

        }


        [HttpGet("posts")]
        [ProducesResponseType(typeof(ResponsePost), StatusCodes.Status200OK)]
        public async Task<IActionResult> posts([FromServices] IValidacaoComentario validacao, [FromServices] IPost post)
        {          
           
            var resposta = await post.ListaPosts();

            return Ok(resposta);

        }
    }
}
