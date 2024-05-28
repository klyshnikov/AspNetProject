namespace WebApplication1.Dto;

public class ChangeRequestForm {
    public ChangeRequestForm(string originalLogin, string name, int gender, BirthDayRequestForm birthDate) {
        OriginalLogin = originalLogin;
        Name = name;
        Gender = gender;
        BirthDate = birthDate;
    }

    public String OriginalLogin { get; set; }
    public String Name { get; set; }
    public int Gender { get; set; }
    public BirthDayRequestForm BirthDate { get; set; }
    
    
}