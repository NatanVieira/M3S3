

using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/funcionarios")]
    public class FuncionariosController : ControllerBase {

        [HttpGet]
        public ActionResult<List<Funcionario>> Listar(){
            return Ok(FuncionarioRepository.Obter());
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] FuncionarioDTO funcionario){
            FuncionarioRepository.Adicionar(funcionario);
            return Created("api/funcionarios",funcionario);
        }

        [HttpDelete("{id}")]
        public ActionResult ExcluirFuncionario([FromRoute] int id){
            return this.Excluir(id, 1);
        }

        [HttpDelete("{id}")]
        public ActionResult ExcluirGerente([FromRoute] int id){
            return this.Excluir(id, 2);
        }

        [HttpPatch("{id}")]
        public ActionResult AlterarSalario([FromBody] SalarioDTO salario,
                                           [FromRoute] int id){
            Funcionario funcionario = FuncionarioRepository.ObterPorId(id);
            if(funcionario != null){
                FuncionarioRepository.Editar(new FuncionarioDTO(funcionario.Nome, funcionario.Senha,funcionario.Permissao, salario.Salario));
                return Ok();
            }
            return NotFound();
        }
        private ActionResult Excluir(int id, int tipoExclusao){
            Funcionario funcionario = FuncionarioRepository.ObterPorId(id);
            if(funcionario != null){
                if((funcionario.Permissao == EPermissoes.Funcionario && tipoExclusao == 1) || (funcionario.Permissao == EPermissoes.Gerente && tipoExclusao == 2)){
                    FuncionarioRepository.Excluir(funcionario);
                    return Ok();
                }
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }
            return NotFound();           
        }
    }