using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.AstNodes
{
    /// <summary>
    /// Визуализация узла AST-дерева.
    /// </summary>
    public class AstNodeVisualization
    {
        /// <summary>
        /// Наименование узла.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Дочерние узлы.
        /// </summary>
        public AstNodeVisualization[] Children { get; }

        /// <summary>
        /// Создать визуализацию узла AST-дерева.
        /// </summary>
        /// <param name="name">Наименование узла.</param>
        /// <param name="children">Дочерние узлы.</param>
        public AstNodeVisualization(string name, params AstNodeVisualization[]? children)
        {
            Name = name;
            Children = children ?? Array.Empty<AstNodeVisualization>();
        }
    }
}
