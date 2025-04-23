using Domain.DTOs;
using Domain.Enums;

namespace Domain.IServices;

public interface ITermsAndConditionService
{
    Task AddAndUpdate(TermsAndConditionType type, string? Value);
    Task<TermsAndConditionsDTO> GetTermsAndConditionsAsync(TermsAndConditionType Type);
    Task Delete(TermsAndConditionType type);
}
