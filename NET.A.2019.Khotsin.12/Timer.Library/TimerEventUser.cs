using System;

namespace TimerLibrary
{
    /// <summary>
    /// Represents event listener
    /// </summary>
    public class TimerEventUser
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="timer">Given timer</param>
        public TimerEventUser(Timer timer)
        {
            timer.TimeIsOver += TimeHasPassed;
        }

        /// <summary>
        /// Prints messages when event is raised
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An object that contains the event data</param>
        private void TimeHasPassed(object sender, TimerEventArgs e)
        {
            Console.WriteLine($"Sender: {sender}");
            Console.WriteLine($"Message: {e.Message}");
            Console.WriteLine($"{e.Milliseconds} milliseconds passed");
        }
    }
}
