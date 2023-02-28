using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Математическое выражение".
    /// </summary>
    internal class MathExpressionNode : InfixExpressionNode
    {
        public override AstNodeVisualization ToVisualization()
            => ToVisualization("mathExpr");
    }
}
