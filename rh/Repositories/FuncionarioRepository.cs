

public static class FuncionarioRepository {

    public static List<Funcionario> Funcionarios {get; set;} = new List<Funcionario> {new Funcionario(1,"admin","admin",EPermissoes	.Administrador,0M)};

    public static List<Funcionario> Obter(){
        return Funcionarios;
    }

    public static Funcionario ObterPorUsuarioESenha(string nome, string senha){
        return Funcionarios.FirstOrDefault(f => f.Nome == nome && f.Senha == senha);
    }

    public static void Adicionar(FuncionarioDTO funcionario){
        int id = RetornaID();
        Funcionarios.Add(new Funcionario(id, funcionario.Nome, funcionario.Senha, funcionario.Permissao, funcionario.Salario));
    }

    public static void Editar(FuncionarioDTO funcionario){
        Funcionario funcEditado = ObterPorUsuarioESenha(funcionario.Nome, funcionario.Senha);
        funcEditado.Nome = funcionario.Nome;
        funcEditado.Senha = funcionario.Senha;
        funcEditado.Permissao = funcionario.Permissao;
        funcEditado.Salario = funcionario.Salario;
    }

    public static void Excluir(Funcionario funcionario){
        Funcionarios.Remove(funcionario);
    }
    
    private static int RetornaID(){
        return new Random().Next(2,99999999);
    }
}