using API_Tutorial.Models;
using API_Tutorial.Dto;

namespace API_Tutorial.Services.AuthService;

public class AuthService : IAuthService
{
	public AuthService()
	{
	}

    public async Task<CommonResponseDto<LoginModel>> LoginService(LoginModel model)
    {
        var result = new CommonResponseDto<LoginModel> { IsSuccess = false, StatusCode = Helpers.Status.Failed, Status = Helpers.Status.Failed.ToString(), Data = model };
        if (model is not null &&
           model.LoginId!.Equals("admin@example.com", StringComparison.OrdinalIgnoreCase) &&
           model.Password!.Equals("password", StringComparison.InvariantCultureIgnoreCase))
        {
            result.IsSuccess = true;
            result.StatusCode = Helpers.Status.Success;
            result.Status = Helpers.Status.Success.ToString();
        }
        
        return await Task.FromResult(result);
    }
}