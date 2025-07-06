using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
public static partial class Errors
   {
       public static class Authentication
         {
      public static Error InvalidCredentials =>
       Error.Validation(
       code: "Auth.InvalidCredentials",
       description: "The provided credentials are invalid. Please check your email and password and try again."
          );
         }
    }
  }

   