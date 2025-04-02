namespace UserInterface.MVVM.Commands.StatisticsCommands
{
    using System;
    using System.Windows.Input;

    public class DatePickerChangedCommand : ICommand
    {
        private StatisticsViewModel VM;

        public DatePickerChangedCommand(StatisticsViewModel vm)
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
            VM.ExecuteDatePickerChangedCommand();
        }
    }
}
