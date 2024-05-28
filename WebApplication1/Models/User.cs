using System;
using System.Text.Json;
using Microsoft.AspNetCore.Routing.Constraints;
using WebApplication1.Dto;

namespace WebApplication1.Models;

public class User {
    public User() { }

    public User(string login, string password, string name, Genders gender, DateTime birthDate, string role) {
        Login = login;
        Password = password;
        Name = name;
        Gender = gender;
        Bithday = birthDate;
        Admin = (role == "admin");
        
        CreatedOn = DateTime.Now;
        CreatedBy = login;
    }

    public Role Role { get; set; }

    public int Guid { get; set; }

    // Login
    private string _login;
    public string Login {
        get { return _login; }
        set {
            if (value.All(letter => Char.IsLetterOrDigit(letter)))
                _login = value;
        }
    }

    // Password
    private string _password;
    public string Password {
        get { return _password; }
        set {
            if (value.All(letter => Char.IsLetterOrDigit(letter)))
                _password = value;
        }
    }
    
    
    // Name
    private string _name;
    public string Name {
        get { return _name;  }
        set {
            if (value.All(letter =>
                    Char.IsLetter(letter) || (letter <= 'Я' && letter >= 'А')))
                _name = value;
        }
    }

    public Genders Gender { get; set; }

    public DateTime? Bithday { get; set; }

    public bool Admin { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? RevokedOn { get; set; }

    public string? RevokedBy { get; set; }
}