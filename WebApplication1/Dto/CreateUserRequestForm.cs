namespace WebApplication1.Dto;

public class CreateUserRequestForm {
    public string login { get; set; }
    public string password { get; set; }
    public string name { get; set; }
    public int gender { get; set; }
    public BirthDayRequestForm birthDay { get; set; }
    public string role { get; set; }
}