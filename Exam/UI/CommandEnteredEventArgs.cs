using System;

namespace Exam.UI
{
    public class CommandEnteredEventArgs : EventArgs
    {
        // add command property to base class EventArgs
        public string Command { get; set; }
    }
}
