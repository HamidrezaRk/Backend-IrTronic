using Application.BaseRequest.Interface;
using Application.Results.TermsAndConditions;
using Domain.Enums;

namespace Application.Queries.TermsAndConditions;

public class GetTermsAndConditionsRequest
{
    public TermsAndConditionType Type { get; set; }

}
public class GetTermsAndConditionsQuery() : BaseRequest<GetTermsAndConditionsRequest,GetTermsAndConditionsResult>;