using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Выражение с двумя членами".
    /// </summary>
    internal abstract class InfixExpressionNode : ExpressionNode
    {
        /// <summary>
        /// Левый член выражения.
        /// </summary>
        public ExpressionNode Left { get; set; } = new UndefinedNode();
        /// <summary>
        /// Правый член выражения.
        /// </summary>
        public ExpressionNode Right { get; set; } = new UndefinedNode();
        /// <summary>
        /// Строковое представление операции выражения.
        /// </summary>
        public string Operation { get; set; } = string.Empty;

        /// <inheritdoc cref="ExpressionNode.ToVisualization"/>
        /// <param name="nodeName">Наименование узла.</param>
        public AstNodeVisualization ToVisualization(string nodeName)
            => new(nodeName, Left.ToVisualization(), new AstNodeVisualization(Operation), Right.ToVisualization());
    }
}
