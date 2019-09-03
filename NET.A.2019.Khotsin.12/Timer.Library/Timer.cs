using System;
using System.Threading;

namespace TimerLibrary
{
    /// <summary>
    /// Represents timer with simple functionality
    /// </summary>
    public class Timer
    {
        private int _millisecondsTimeout;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="millisecondsTimeout">Specified number of milliseconds</param>
        public Timer(int millisecondsTimeout)
        {
            MillisecondsTimeout = millisecondsTimeout;
            TimeIsOver = (sender, e) => { };
        }

        /// <summary>
        /// Represents the method with object and TimerEventArgs parameters
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An object that contains the event data</param>
        public delegate void TimerHandler(object sender, TimerEventArgs e);

        /// <summary>
        /// Event, raising when time is over
        /// </summary>
        public event TimerHandler TimeIsOver;

        /// <summary>
        /// Milliseconds timeout
        /// </summary>
        public int MillisecondsTimeout
        {
            get
            {
                return this._millisecondsTimeout;
            }

            set
            {
                if (!Validator.IsMillisecondsTimeoutValid(value))
                {
                    throw new ArgumentException("Invalid milliseconds value");
                }

                this._millisecondsTimeout = value;
            }
        }

        /// <summary>
        /// Starts the timer
        /// </summary>
        public void Start()
        {
            Thread.Sleep(this._millisecondsTimeout);
            TimeIsOver(this, new TimerEventArgs("The time is over", this._millisecondsTimeout));
        }
    }
}
