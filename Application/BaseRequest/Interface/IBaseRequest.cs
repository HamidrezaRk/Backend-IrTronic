namespace Application.BaseRequest.Interface;

public interface IBaseRequest
{
    public int? UserId { get; set; }
    public string? Ip { get; set; }

  //  public DateTime? TokenIat { get; set; }
}
