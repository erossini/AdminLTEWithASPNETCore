using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Domain.Enums
{
    /// <summary>
    /// Enum LogType
    /// </summary>
    public enum LogType
    {
        Error,
        Information,
        ServiceMessage,
        SendNotification,
        UserInteraction,
        Warning
    }
}