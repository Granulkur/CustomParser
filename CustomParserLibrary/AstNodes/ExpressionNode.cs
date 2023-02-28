using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Узел AST-дерева "Выражение".
    /// </summary>
    internal abstract class ExpressionNode
    {
        /// <summary>
        /// Получить визуализацию узла AST-дерева. 
        /// </summary>
        /// <returns>Визуализация узла AST-дерева.</returns>
        public abstract AstNodeVisualization ToVisualization();

        /// <summary>
        /// Получить визуализацию дочерних узлов AST-дерева.
        /// </summary>
        /// <param name="childrens">Дочерние узлы AST-дерева.</param>
        /// <returns>Визуализация дочерних узлов AST-дерева.</returns>
        public AstNodeVisualization[] CreateChildrenVizualization(params ExpressionNode[] childrens)
            => childrens.Where(x => x is not UndefinedNode).Select(x => x.ToVisualization()).ToArray();
    }
}
