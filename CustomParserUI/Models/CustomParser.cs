using CustomParserLibrary.Models;
using CustomParserUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserUI.Models
{
    /// <summary>
    /// Парсер текста программы.
    /// </summary>
    internal static class CustomParser
    {
        /// <summary>
        /// Стандартный парсер текста программы.
        /// </summary>
        private static readonly CustomParserLibrary.Models.CustomParser _defaultCustomParser = new();

        /// <summary>
        /// Получить представления AST-дерева узлов.
        /// </summary>
        /// <param name="code">Код программы.</param>
        /// <returns>Представления AST-дерева узлов.</returns>
        public static ObservableCollection<AstTreeViewModel> ParseAstTreeViewModel(string code)
            => new ObservableCollection<AstTreeViewModel> { new AstTreeViewModel(_defaultCustomParser.ParseAstVisualizationTree(code)) };
    }
}
