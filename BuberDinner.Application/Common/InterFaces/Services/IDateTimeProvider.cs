namespace BuberDinner.Application.Common.InterFaces.Services
{
    public interface IDateTimeProvider
    {
      DateTime UtcNow { get; }    
    }
}