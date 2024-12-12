namespace API.ViewModels;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }
    
    public ApiResponse(T data)
    {
        Success = true;
        Message = "Operation successful";
        Data = data;
    }

    public ApiResponse(string message, T? data = default)
    {
        Success = false;
        Message = message;
        Data = data;
    }
}