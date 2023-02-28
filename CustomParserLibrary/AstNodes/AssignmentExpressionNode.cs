using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Выражение присваивания".
    /// </summary>
    internal class AssignmentExpressionNode : ExpressionNode
    {
        /// <summary>
        /// Переменная.
        /// </summary>
        public ExpressionNode Variable { get; set; } = new UndefinedNode();

        /// <summary>
        /// Присваиваемое значение.
        /// </summary>
        public ExpressionNode Value { get; set; } = new UndefinedNode();

        public override AstNodeVisualization ToVisualization()
            => new("assignExpr", CreateChildrenVizualization(Variable, Value));
    }
}
