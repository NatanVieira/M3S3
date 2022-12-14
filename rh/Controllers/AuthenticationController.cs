

using Microsoft.AspNetCore.Mvc;
using rh.DTOs;
using rh.Repositories;
using rh.Services;

namespace rh.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase {
        
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] FuncionarioLoginDTO funcionarioLogin){
            var funcionario = FuncionarioRepository.ObterPorUsuarioESenha(funcionarioLogin.Nome,funcionarioLogin.Senha);

            if(funcionario == null)
                return Unauthorized();
            
            var token = TokenService.GenerateToken(funcionario);
            return Ok(new {token});
        }

    }
}