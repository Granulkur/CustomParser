using Antlr4.Runtime.Tree;
using CustomParserLibrary.AstNodes;
using CustomParserLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserUI.ViewModels
{
    /// <summary>
    /// Представление AST-дерева узлов.
    /// </summary>
    public class AstTreeViewModel : ViewModelBase
    {
        /// <summary>
        /// Дочерние узлы.
        /// </summary>
        public ObservableCollection<AstTreeViewModel> Children { get; }
        /// <summary>
        /// Значение текущего узла.
        /// </summary>
        public string NodeName { get; }

        /// <summary>
        /// Создать новое представление AST-дерева узлов.
        /// </summary>
        /// <param name="astNodeVisualization">Визуализация AST-дерева узлов.</param>
        public AstTreeViewModel(AstNodeVisualization astNodeVisualization)
        {
            NodeName = astNodeVisualization.Name;
            Children = new ObservableCollection<AstTreeViewModel>();

            // Создание дочерних узлов.
            foreach (var child in astNodeVisualization.Children)
                Children.Add(new AstTreeViewModel(child));
        }
    }
}
