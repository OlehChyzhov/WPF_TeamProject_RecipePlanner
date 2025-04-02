namespace UserInterface.MVVM.Commands.StatisticsCommands
{
    using System;
    using System.Windows.Input;

    public class RemoveSelectedEntityCommand : ICommand
    {
        private StatisticsViewModel VM;

        public RemoveSelectedEntityCommand(StatisticsViewModel vm)
        {
            VM = vm;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.ExecuteRemoveSelectedEntityCommand();
        }
    }
}
