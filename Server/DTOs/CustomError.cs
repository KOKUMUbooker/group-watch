namespace MovieManager.DTOs;

public enum AuthErrorType
{
    None,
    InvalidCredentials,
    EmailNotVerified,
    InvalidClient
}


public class CustomError {
    public string? Error {get; set;} = "ERROR";
    public string Message {get; set;}
}