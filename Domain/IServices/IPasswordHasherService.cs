namespace Domain.IServices;

 public interface IPasswordHasherService
 {
    bool VerifyPassword(string InputPassword, string hashPassword);
    public string HashPassword(string password);
 }
