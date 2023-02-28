using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Блок THEN".
    /// </summary>
    internal class ThenBlockNode : ExpressionNode
    {
        /// <summary>
        /// Выполняемые действия.
        /// </summary>
        public IEnumerable<ExpressionNode> Actions { get; set; } = Enumerable.Empty<ExpressionNode>();

        public override AstNodeVisualization ToVisualization()
            => new("thenBlock", CreateChildrenVizualization(Actions.ToArray()));
    }
}
