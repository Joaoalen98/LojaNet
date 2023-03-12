﻿using System.ComponentModel.DataAnnotations;

namespace LojaNet.API.ViewModels
{
    public class UsuarioCriarViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Telefone { get; set; }
        
        [Required]
        public string Senha { get; set; }
    }
}
