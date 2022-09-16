

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace rh.Models {
    public enum EPermissoes {

        [XmlEnumAttribute("F")]
        [Display(Description = "Funcionario")]
        Funcionario,
        [XmlEnumAttribute("G")]
        [Display(Description = "Gerente")]
        Gerente,
        [XmlEnumAttribute("A")]
        [Display(Description = "Admnistrador")]
        Administrador
    }
}