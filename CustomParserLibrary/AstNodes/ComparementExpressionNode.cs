using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Выражение сравнения".
    /// </summary>
    internal class ComparementExpressionNode : InfixExpressionNode
    {
        public override AstNodeVisualization ToVisualization()
            => ToVisualization("compareExpr");
    }
}
