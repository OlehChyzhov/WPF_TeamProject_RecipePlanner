namespace UserInterface.MVVM.Commands.StatisticsCommands
{
    using System;
    using System.Windows.Input;

    public class ManageEntitiesCommand : ICommand
    {
        private StatisticsViewModel VM;

        public ManageEntitiesCommand(StatisticsViewModel vm)
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
            VM.ExecuteManageEntitiesCommand();
        }
    }
}
