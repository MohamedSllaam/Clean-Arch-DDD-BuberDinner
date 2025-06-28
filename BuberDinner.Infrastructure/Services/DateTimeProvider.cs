using BuberDinner.Application.Common.InterFaces.Services;

namespace BuberDinner.Infrastructure.Services;

 public class DateTimeProvider : IDateTimeProvider
 {
  public DateTime UtcNow => DateTime.UtcNow;
 }
