using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Блок ELSE-IF".
    /// </summary>
    internal class ElseIfBlockNode : ExpressionNode
    {
        /// <summary>
        /// Условие выполнения блока.
        /// </summary>
        public ExpressionNode Predicate { get; set; } = new UndefinedNode();
        /// <summary>
        /// Выполняемые действия при истинности условия.
        /// </summary>
        public ExpressionNode[] Actions { get; set; } = Array.Empty<ExpressionNode>();

        public override AstNodeVisualization ToVisualization()
            => new("elseIfBlock", CreateChildrenVizualization(Actions.Prepend(Predicate).ToArray()));
    }
}
