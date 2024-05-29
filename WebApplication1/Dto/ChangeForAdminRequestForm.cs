namespace WebApplication1.Dto;

public class ChangeForAdminRequestForm {
    public ChangeForAdminRequestForm(string userLogin, string name, int gender, BirthDayRequestForm birthDate) {
        UserLogin = userLogin;
        Name = name;
        Gender = gender;
        BirthDate = birthDate;
    }

    public string UserLogin { get; set; }
    public string Name { get; set; }
    public int Gender { get; set; }
    public BirthDayRequestForm BirthDate { get; set; }
}