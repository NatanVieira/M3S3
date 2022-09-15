

using System.ComponentModel.DataAnnotations;

public enum EPermissoes {

    [Display(Name = "Funcionário")]
    Funcionario = 1,
    [Display(Name = "Gerente")]
    Gerente = 2,
    [Display(Name = "Diretor")]
    Administrador = 3
}