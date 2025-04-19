using Domain.Enums;

namespace Domain.DTOs;
public class TermsAndConditionsDTO
{
    public TermsAndConditionType Type { get; set; }
    public string? Value { get; set; }
}
