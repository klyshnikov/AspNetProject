namespace WebApplication1.Dto;

public class ChangeForAdminRequestForm {
    public ChangeForAdminRequestForm(string userLogin, string name, int gender, BirthDayRequestForm birthDate) {
        UserLogin = userLogin;
        Name = name;
        Gender = gender;
        BirthDate = birthDate;
    }

    public String UserLogin { get; set; }
    public String Name { get; set; }
    public int Gender { get; set; }
    public BirthDayRequestForm BirthDate { get; set; }
}