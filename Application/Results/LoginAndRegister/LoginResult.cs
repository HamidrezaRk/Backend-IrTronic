using Domain.DTOs;

namespace Application.Results.LoginAndRegister;

public record LoginResult(UserNameWithPasswordDTO userDetails, string Token);
