
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using rh.DTOs;
using rh.Models;
using rh.Repositories;
using rh.ViewModels;

namespace rh.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class FuncionariosController : ControllerBase {

        [HttpGet]
        [Authorize(Roles = "Administrador,Gerente,Funcionario")]
        public ActionResult<List<Funcionario>> Listar(){
            if(User.IsInRole(EPermissoes.Funcionario.GetDisplayName()))
                return Ok(FuncionarioRepository.Obter().Select(f => new FuncionarioListaViewModel(f.Nome, f.Permissao)).ToList());
            return Ok(FuncionarioRepository.Obter());
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar([FromBody] FuncionarioDTO funcionario){
            FuncionarioRepository.Adicionar(funcionario);
            return Created("api/funcionarios",funcionario);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador,Gerente")]
        public ActionResult ExcluirFuncionario([FromRoute] int id){
            return this.Excluir(id, 1);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public ActionResult ExcluirGerente([FromRoute] int id){
            return this.Excluir(id, 2);
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "Gerente")]
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
}