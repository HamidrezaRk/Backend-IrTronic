using MediatR;

namespace Application.BaseRequest.Interface
{
    public class BaseRequest<Body, Result> : IBaseRequest, IRequest<Result>
    {
        public required Body RequestBody { get; set; }
        public int? UserId { get; set; }
        public string? Ip { get; set; }
    }
}
