namespace CustomParserUI.ViewModels;

using Avalonia.Controls;
using Avalonia.Interactivity;
using CustomParserUI.Models;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

/// <summary>
/// Представление главного окна приложения.
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    /// Текст программы.
    /// </summary>
    public string ProgramText
    {
        get => _programText;
        set => this.RaiseAndSetIfChanged(ref _programText, value);
    }

    /// <summary>
    /// Информационное сообщение.
    /// </summary>
    public string InfoText 
        => @"Введите код программы и нажмите на кнопку ""Построить AST"". В правой части отобразится AST-дерево или сообщение об ошибке";

    /// <summary>
    /// Узлы дерева для отображения в TreeView.
    /// </summary>
    public ObservableCollection<AstTreeViewModel> TreeNodes
    {
        get => _treeNodes;
        set => this.RaiseAndSetIfChanged(ref _treeNodes, value);
    }

    /// <summary>
    /// Команда построения представления AST-дерева узлов.
    /// </summary>
    public ReactiveCommand<Unit, Unit> BuildAstCommand { get; }

    /// <summary>
    /// Команда очистки набранного текста программы и представления AST-дерева.
    /// </summary>
    public ReactiveCommand<Unit, Unit> ClearCommand { get; }

    /// <summary>
    /// Текст программы (реализация).
    /// </summary>
    private string _programText = string.Empty;
    /// <summary>
    /// Узлы дерева для отображения в TreeView (реализация).
    /// </summary>
    private ObservableCollection<AstTreeViewModel> _treeNodes = new();

    public MainWindowViewModel()
    {
        BuildAstCommand = ReactiveCommand.Create(OnBuildAstCommand);
        ClearCommand = ReactiveCommand.Create(OnClearCommand);
    }

    /// <summary>
    /// Обработчик события команды построения представления AST-дерева узлов.
    /// </summary>
    void OnBuildAstCommand()
    {
        if (ProgramText.Length > 0)
            TreeNodes = CustomParser.ParseAstTreeViewModel(ProgramText);
    }

    /// <summary>
    /// Обработчик события команды очистки набранного текста программы и представления AST-дерева.
    /// </summary>
    private void OnClearCommand()
    {
        TreeNodes = new ObservableCollection<AstTreeViewModel>();
        ProgramText = string.Empty;        
    }
}