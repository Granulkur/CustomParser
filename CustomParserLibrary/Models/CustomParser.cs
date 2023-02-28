using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Tree;
using CustomParserLibrary.AstNodes;

namespace CustomParserLibrary.Models
{
    /// <summary>
    /// Парсер текста программы.
    /// </summary>
    public class CustomParser
    {
        /// <summary>
        /// Получить визуализацию AST-дерева узлов. 
        /// </summary>
        /// <param name="text">Текст программы.</param>
        /// <returns>Визуализация AST-дерева узлов.</returns>
        public AstNodeVisualization ParseAstVisualizationTree(string text)
        {
            // Получение ANTLR-дерева.
            ICharStream stream = CharStreams.fromString(text);
            var lexer = new AntlrLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new AntlrParser(tokens);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(new AntlrErrorListener());
            parser.BuildParseTree = true;

            try
            {
                // Парсинг текста программы.
                var antlrTree = parser.ifThenElseBlock();

                // Создание AST-дерева.
                var ifThenElseblock = (IfThenElseBlock)new AstNodeVisitor().VisitIfThenElseBlock(antlrTree);
                return ifThenElseblock.ToVisualization();
            }
            catch (Exception e) 
            {
                return new AstNodeVisualization(e.Message);
            }
        }       

    }
}
