using System.Collections.Generic;

namespace ExceptionHandlingTask3.DoNotChange
{
    public interface IUser
    {
        IList<UserTask> Tasks { get; }
    }
}