using Livraria.Application.UseCases.Livro.Delete;
using Livraria.Application.UseCases.Livro.GetAll;
using Livraria.Application.UseCases.Livro.Register;
using Livraria.Application.UseCases.Livro.Update;
using Livraria.Communication.Request;
using Livraria.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseLivroCreatedJson), StatusCodes.Status201Created)]
        public IActionResult Post([FromBody] RequestLivroRegisterJson request)
        {
            var useCase = new RegisterLivroUseCase();

            useCase.execute(request);

            return Created();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseLivroCreatedJson), StatusCodes.Status200OK)]
        public IActionResult Update([FromRoute] int id, RequestLivroRegisterJson request)
        {
            var useCase= new UpdateLivroUseCase();
            var response = useCase.execute(id, request);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseAllLivrosJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllLivroUseCase();
            var response = useCase.execute();

            if (response.Livros.Any())
            {
                return Ok(response);
            }

            return NoContent();
        }

        [HttpDelete]


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete([FromRoute] int id)
        {
            var useCase = new DeleteLivroUseCase();
            useCase.execute(id);

            return NoContent();

        }
    }
}
