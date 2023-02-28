using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Блок IF-THEN-ELSE".
    /// </summary>
    internal class IfThenElseBlock : ExpressionNode
    {
        /// <summary>
        /// Блок IF.
        /// </summary>
        public ExpressionNode IfBlock { get; set; } = new UndefinedNode();
        /// <summary>
        /// Блок THEN.
        /// </summary>
        public ExpressionNode ThenBlock { get; set; } = new UndefinedNode();
        /// <summary>
        /// Блоки ELSE-IF.
        /// </summary>
        public ExpressionNode[] ElseIfBlocks { get; set; } = Array.Empty<ExpressionNode>();
        /// <summary>
        /// Блок ELSE.
        /// </summary>
        public ExpressionNode ElseBlock { get; set; } = new UndefinedNode();

        public override AstNodeVisualization ToVisualization()
            => new("ifThenElseBlock", CreateChildrenVizualization(new[] { IfBlock, ThenBlock }.Concat(ElseIfBlocks).Append(ElseBlock).ToArray()));
    }
}
