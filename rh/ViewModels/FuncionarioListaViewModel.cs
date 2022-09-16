

using rh.Models;

namespace rh.ViewModels {

    public class FuncionarioListaViewModel {

        public string Nome { get; set; }

        public EPermissoes Permissao {get; set;}

        public FuncionarioListaViewModel(string nome, EPermissoes permissao){
            Nome = nome;
            Permissao = permissao;
        }
    }
}