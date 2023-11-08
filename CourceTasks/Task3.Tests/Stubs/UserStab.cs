using System.Collections.Generic;
using ExceptionHandlingTask3.DoNotChange;

namespace ExceptionHandlingTask3.Tests.Stubs
{
    internal class UserStab : IUser
    {
        public IList<UserTask> Tasks { get; } = new List<UserTask>
        {
            new UserTask("task1"),
            new UserTask("task2"),
            new UserTask("task3")
        };
    }
}