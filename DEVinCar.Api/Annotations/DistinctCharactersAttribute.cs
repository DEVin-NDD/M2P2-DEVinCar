using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Api.Annotations;

public class DistinctCharactersAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {   
        string password = value.ToString();
        var arrPassword = password.ToCharArray().ToList();

        foreach (char letter in arrPassword){
            System.Console.WriteLine(arrPassword[0]);
            if(letter != arrPassword[0])
                return ValidationResult.Success;
        } 
        return new ValidationResult("Invalid Password.");    
    }
}