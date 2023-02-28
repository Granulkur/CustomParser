using Antlr4.Runtime;
using CustomParserLibrary.AstNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.Models
{
    /// <summary>
    /// Прослушиватель сообщений об ошибках при парсинге ANTLR-дерева токенов.
    /// </summary>
    internal class AntlrErrorListener : IAntlrErrorListener<IToken>
    {
        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            throw new Exception($"Error at {line}:{charPositionInLine} => {msg}");
        }
    }
}
