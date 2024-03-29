﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PackageDelivery.GUI.Models.Parameters
{
    public class PersonModel
    {
        public long Id { get; set; }

        [Required]
        [DisplayName("Primer nombre")]
        public string FirstName { get; set; }

        [DisplayName("Otros nombres")]
        public string OtherNames { get; set; }

        [Required]
        [DisplayName("Primer apellido")]
        public string FirstLastname { get; set; }

        [DisplayName("Segundo apellido")]
        public string SecondLastname { get; set; }

        [Required]
        [DisplayName("Número de identificación")]
        public string IdentificationNumber { get; set; }

        [Required]
        [DisplayName("Celular")]
        public string Cellphone { get; set; }

        [Required]
        [DisplayName("Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Tipo de documento")]
        public int IdentificationType { get; set; }

        [DisplayName("Tipo de documento")]
        public string DocumentTypeName { get; set; }

        [DisplayName("Tipo de documento")]
        public IEnumerable<DocumentTypeModel> DocumentTypeList { get; set; }

        public string FullName { get; set; }
    }
}