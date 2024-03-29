﻿namespace PackageDelivery.Repository.DBModels.Parameters
{
    public class PersonDBModel
    {
        /*
		private long id;

		public long Id
		{
			get { return id; }
			set { id = value; }
		}
		private string primerNombre;

		public string PrimerNombre
		{
			get { return primerNombre; }
			set { primerNombre = value; }
		}

		private string otherNames;

		public string OtherNames
		{
			get { return otherNames; }
			set { otherNames = value; }
		}

		private string firstLastName;

		public string FirstLastName
		{
			get { return firstLastName; }
			set { firstLastName = value; }
		}

		private string secondLastName;

		public string SecondLastName
		{
			get { return secondLastName; }
			set { secondLastName = value; }
		}
		*/
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
