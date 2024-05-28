namespace WebApplication1.Dto;

public class BirthDayRequestForm {
    public BirthDayRequestForm(int day, int month, int year) {
        Day = day;
        Month = month;
        Year = year;
    }
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    
}