using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Блок ELSE".
    /// </summary>
    internal class ElseBlockNode : ExpressionNode
    {
        /// <summary>
        /// Выполняемые действия.
        /// </summary>
        public ExpressionNode[] Actions { get; set; } = Array.Empty<ExpressionNode>();

        public override AstNodeVisualization ToVisualization()
            => new("elseBlock", CreateChildrenVizualization(Actions));
    }
}
