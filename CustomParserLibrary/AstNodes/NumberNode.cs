using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Число".
    /// </summary>
    internal class NumberNode: ExpressionNode
    {
        /// <summary>
        /// Значение узла.
        /// </summary>
        public double Value { get; set; } = 0.0;

        public override AstNodeVisualization ToVisualization()
            => new("numberExpr", new AstNodeVisualization(Value.ToString()));
    }
}
