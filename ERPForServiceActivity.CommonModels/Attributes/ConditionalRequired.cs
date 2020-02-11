using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ERPForServiceActivity.CommonModels.BindingModels.Repairs;

namespace ERPForServiceActivity.CommonModels.Attributes {
	public class ConditionalRequired : 
		ValidationAttribute {

		protected override ValidationResult IsValid(
			object value, 
			ValidationContext validationContext) {
			
			AddRepairBindingModel repair = 
				(AddRepairBindingModel)
				validationContext.ObjectInstance;
		
			if(repair.ApplianceType == "Mobile Phone") {
				return new ValidationResult("IMEI is required");
			}

			string type = repair.ApplianceType;
			return !type.Equals("Mobile Phone") ? 
				new ValidationResult("Model and S/N are required") : 
				ValidationResult.Success;
		}
	}
}
