using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Незадано".
    /// </summary>
    internal class UndefinedNode : ExpressionNode
    {
        public override AstNodeVisualization ToVisualization()
            => new("undefined");
    }
}
