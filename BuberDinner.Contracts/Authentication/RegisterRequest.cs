namespace BuberDinner.Contracts.Authentication;

    public record RegisterRequest
  (  
    string FirstName,
    string LastName,
    string Email,
    string Password
  );

// This code defines a record type `RegiterRequest` in the namespace `BuberDinner.Contracts.Authentication`.
