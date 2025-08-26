using API_Tutorial.Helpers;
namespace API_Tutorial.Dto;

public class CommonResponseDto<T>
{
	public bool IsSuccess { get; set; }
	public Status StatusCode { get; set; }
	public string? Status { get; set; }
	public T? Data { get; set; }
}

