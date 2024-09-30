﻿namespace WPF.Helpers;

#pragma warning disable CS8601
public class RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
{
    private readonly Action<object> execute = execute ?? throw new ArgumentNullException(nameof(execute));
    private readonly Func<object, bool> canExecute = canExecute;

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter)
    {
        return canExecute == null || canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        execute(parameter);
    }
}
