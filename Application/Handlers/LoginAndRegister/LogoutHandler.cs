using Application.Commands.LoginAndRegister;
using Application.Results;
using MediatR;
using static Application.Failures.Failures;

namespace Application.Handlers.LoginAndRegister;

 public class LogoutHandler : IRequestHandler<LogoutCommand , SuccessfulResult>
 {
    public async Task<SuccessfulResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        if (userId is not null)
        {
            return new SuccessfulResult();
        }
        throw new UserNotFound();
    }
 }
