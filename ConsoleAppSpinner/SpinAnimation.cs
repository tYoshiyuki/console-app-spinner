using System;
using System.ComponentModel;

namespace ConsoleAppSpinner
{
    public static class SpinAnimation
    {
        private static BackgroundWorker spinner = InitialiseBackgroundWorker();
        private static int spinnerPosition = 25;
        private static int spinWait = 25;

        public static bool IsRunning { get; private set; }

        /// <summary>
        /// Worker thread factory
        /// </summary>
        /// <returns>background worker thread</returns>
        private static BackgroundWorker InitialiseBackgroundWorker()
        {
            BackgroundWorker obj = new BackgroundWorker
            {
                WorkerSupportsCancellation = true
            };

            obj.DoWork += delegate
            {
                spinnerPosition = Console.CursorLeft;

                while (!obj.CancellationPending)
                {
                    var spinChars = new char[] { '|', '/', '-', '\\' };

                    foreach (char spinChar in spinChars)
                    {
                        Console.CursorLeft = spinnerPosition;
                        Console.Write(spinChar);
                        System.Threading.Thread.Sleep(spinWait);
                    }
                }
            };

            return obj;
        }

        /// <summary>
        /// Start the animation
        /// </summary>
        /// <param name="spinWait">wait time between spin steps in milliseconds</param>
        public static void Start(int spinWait)
        {
            IsRunning = true;
            SpinAnimation.spinWait = spinWait;

            if (!spinner.IsBusy)
            {
                spinner.RunWorkerAsync();
            }
            else
            {
                throw new InvalidOperationException("Cannot start spinner whilst spinner is already running");
            }
        }

        /// <summary>
        /// Overloaded Start method with default wait value
        /// </summary>
        public static void Start() { Start(25); }

        /// <summary>
        /// Stop the spin animation
        /// </summary>
        public static void Stop()
        {
            spinner.CancelAsync();

            while (spinner.IsBusy) System.Threading.Thread.Sleep(100);
            Console.CursorLeft = spinnerPosition;
            IsRunning = false;
        }
    }
}
