

namespace rh.Models{
    public class Funcionario {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public EPermissoes Permissao { get; set; }
        public decimal Salario { get; set; }

        public Funcionario(){}
        public Funcionario(int id, string nome, string senha, EPermissoes ePermissoes, decimal salario){
            Id = id;
            Nome = nome;
            Senha = senha;
            Permissao = ePermissoes;
            Salario = salario;
        }
    }
}