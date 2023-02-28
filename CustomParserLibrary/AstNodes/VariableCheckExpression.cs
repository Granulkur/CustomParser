using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Проверка переменной".
    /// </summary>
    internal class VariableCheckExpression : ExpressionNode
    {
        /// <summary>
        /// Имя переменной.
        /// </summary>
        public string Name { get; private set; } = string.Empty;

        /// <summary>
        /// Создать новый узел "Проверка переменной".
        /// </summary>
        /// <param name="name">Имя переменной.</param>
        public VariableCheckExpression(string name)
        {
            Name = name;
        }

        public override AstNodeVisualization ToVisualization()
            => new("variableCheckExpr", new AstNodeVisualization(Name));
    }
}
