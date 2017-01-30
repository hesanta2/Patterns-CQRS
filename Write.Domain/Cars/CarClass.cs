using System;

namespace CQRS.Write.Domain.Cars
{
    [Flags]
    public enum CarClass
    {
        Normal,
        Sport,
        Competition
    }
}
