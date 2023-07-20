namespace Fetagne.Infrastructure.Services;

using System;
using Fetagne.Application.Common.Interface.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
