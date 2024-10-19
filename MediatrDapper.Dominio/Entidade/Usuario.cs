﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MediatrDapper.Dominio.Entidade
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Usuario Incluir()
        {
            Id = 1;
            Nome = "Nome";
            Codigo = "Codigo";
            Email = "Email";

            return this;
        }
    }
}
