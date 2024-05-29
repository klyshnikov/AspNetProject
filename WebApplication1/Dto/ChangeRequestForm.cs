namespace WebApplication1.Dto;

public class ChangeRequestForm {
    public ChangeRequestForm(string name, int gender, BirthDayRequestForm birthDate) {
        Name = name;
        Gender = gender;
        BirthDate = birthDate;
    }
    
    public string Name { get; set; }
    public int Gender { get; set; }
    public BirthDayRequestForm BirthDate { get; set; }
}