﻿using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementProject.Models
{
	public class Prescription
	{
        public int Id { get; set; }
        public string Detail { get; set; }
        public Appointment Appointment { get; set; }

    }
}
