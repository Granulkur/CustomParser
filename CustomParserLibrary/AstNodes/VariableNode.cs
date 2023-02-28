using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Переменная".
    /// </summary>
    internal class VariableNode: ExpressionNode
    {
        /// <summary>
        /// Имя переменной.
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// Создать новый узел "Переменная".
        /// </summary>
        /// <param name="name">Имя переменной.</param>
        public VariableNode(string name)
        {
            Name = name;
        }

        public override AstNodeVisualization ToVisualization()
            => new("variableExpr", new AstNodeVisualization(Name));
    }
}
