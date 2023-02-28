using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Логическое выражение".
    /// </summary>
    internal class LogicExpressionNode : InfixExpressionNode
    {
        public override AstNodeVisualization ToVisualization()
            => ToVisualization("logicExpr");
    }
}
