using StateActionsReducersTutorial.Store;
using StateActionsReducersTutorial.Store.CounterUseCase;

namespace StateActionsReducersTutorial
{
    public class App
    {
        private readonly IStore Store;
        public readonly IDispatcher Dispatcher;
        private readonly IState<CounterState> CounterState;

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="store"></param>
        /// <param name="counterState"></param>
        public App(IStore store, IDispatcher dispatcher, IState<CounterState> counterState)
        {
            Store = store;
            Dispatcher = dispatcher;
            CounterState = counterState;
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            CounterState.StateChanged += CounterState_StateChanged;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
        }

        /// <summary>
        /// Run method
        /// </summary>
        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Initializing store");
            Store.InitializeAsync().Wait();
            string input = "";
            do
            {
                Console.WriteLine("1: Increment counter");
                Console.WriteLine("x: Exit");
                Console.Write("> ");
                input = Console.ReadLine();

                switch (input.ToLowerInvariant())
                {
                    case "1":
                        var action = new IncrementCounterAction();
                        Dispatcher.Dispatch(action);
                        break;

                    case "x":
                        Console.WriteLine("Program terminated");
                        return;
                }
            } while (true);
        }

        /// <summary>
        /// CounterState_StateChanged method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CounterState_StateChanged(object sender, EventArgs e)
        {
            Console.WriteLine("");
            Console.WriteLine("==========================> CounterState");
            Console.WriteLine("ClickCount is " + CounterState.Value.ClickCount);
            Console.WriteLine("<========================== CounterState");
            Console.WriteLine("");
        }
    }
}