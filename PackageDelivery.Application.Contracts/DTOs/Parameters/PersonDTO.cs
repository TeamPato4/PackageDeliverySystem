﻿namespace PackageDelivery.Application.DTOs.Parameters
{
    public class PersonDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string OtherNames { get; set; }
        public string FirstLastname { get; set; }
        public string SecondLastname { get; set; }
        public string IdentificationNumber { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public int IdentificationType { get; set; }
        public string DocumentTypeName { get; set; }
    }
}
