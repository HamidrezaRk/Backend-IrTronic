namespace Application.Results;

public record SuccessfulResult(string Status = "successful");
public record AppBadRequestResult(int Code,string Massage);

