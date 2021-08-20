using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace Quintaapp.Models
{
	public class Usuario
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Range(1,200, ErrorMessage = "O Id deve estar entre 1 e 200")]
		public int UsuId { get; set; }

		[Required(ErrorMessage = "O nome é obrigatório.")]
		public string Nome { get; set; }

		[StringLength(50, MinimumLength = 5, ErrorMessage = "Insira uma informação de 5 até 50 caracteres")]
		public string Obs { get; set; }

		[Required (ErrorMessage = "A data é obrigatória")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime Nasc { get; set; }

		[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Digite um email válido.")]
		public string Email { get; set; }

		[RegularExpression (@"[a-zA-Z]{5,15}", ErrorMessage = "Somente letras, no mínino 5 e no máximo 15 caracteres")]
		[Required (ErrorMessage = "O Login é obrigatório")]
        [Remote ("ValidaLogin", "Usuario", ErrorMessage = "Este login já existe!")]
		public string Login { get; set; }

		[Required (ErrorMessage = "A senha é obrigatória")]
		public string Senha { get; set; }

		[Compare ("Senha", ErrorMessage = "As senhas são diferentes")]
		public string ConfirmarSenha { get; set; }
	}
}