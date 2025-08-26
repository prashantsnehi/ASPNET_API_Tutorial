using API_Tutorial.Models;
using API_Tutorial.Dto;
namespace API_Tutorial.Services.AuthService;

public interface IAuthService
{
	Task<CommonResponseDto<LoginModel>> LoginService(LoginModel model);
}