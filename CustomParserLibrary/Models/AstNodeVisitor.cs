using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using CustomParserLibrary.AstNodes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomParserLibrary.Models
{
    /// <summary>
    /// Класс-посититель, проходящий по ANTLR-дереву узлов и строющий AST-дерево узлов.
    /// </summary>
    internal class AstNodeVisitor : AntlrBaseVisitor<ExpressionNode>
    {
        /// <summary>
        /// Проход в лексему "numberExpr".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Число".</returns>
        public override ExpressionNode VisitNumberExpr([NotNull] AntlrParser.NumberExprContext context)
        {
            return new NumberNode
            {
                Value = double.TryParse(
                    s: context.value.Text,
                    style: NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent,
                    provider: CultureInfo.InvariantCulture,
                    result: out var result) ? result : 0
            };
        }

        /// <summary>
        /// Проход в лексему "variableExpr".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Переменная".</returns>
        public override ExpressionNode VisitVariableExpr([NotNull] AntlrParser.VariableExprContext context)
        {
            return new VariableNode(context.name.Text);
        }

        /// <summary>
        /// Проход в лексему "variableCheckExpr".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Переменная".</returns>
        public override ExpressionNode VisitVariableCheckExpr([NotNull] AntlrParser.VariableCheckExprContext context)
        {
            return new VariableCheckExpression(context.name.Text);
        }

        /// <summary>
        /// Проход в лексему "predicateExpr".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Логическое выражение".</returns>
        public override ExpressionNode VisitPredicateExpr([NotNull] AntlrParser.PredicateExprContext context)
        {
            return CreateInfixExpressionNode<LogicExpressionNode>(context);
        }

        /// <summary>
        /// Проход в лексему "compareExpr".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Выражение сравнения".</returns>
        public override ExpressionNode VisitCompareExpr([NotNull] AntlrParser.CompareExprContext context)
        {
            return CreateInfixExpressionNode<ComparementExpressionNode>(context);
        }

        /// <summary>
        /// Проход в лексему "logicExpr".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Логическое выражение".</returns>
        public override ExpressionNode VisitLogicExpr([NotNull] AntlrParser.LogicExprContext context)
        {
            return CreateInfixExpressionNode<LogicExpressionNode>(context);
        }

        /// <summary>
        /// Проход в лексему "assignExpr".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Выражение присваивания".</returns>
        public override ExpressionNode VisitAssignExpr([NotNull] AntlrParser.AssignExprContext context)
        {
            return new AssignmentExpressionNode
            {
                Value = Visit(context.value),
                Variable = new VariableNode(context.var.Text)
            };
        }

        /// <summary>
        /// Проход в лексему "mathExpr".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Математическое выражение".</returns>
        public override ExpressionNode VisitMathExpr([NotNull] AntlrParser.MathExprContext context)
        {
            return CreateInfixExpressionNode<MathExpressionNode>(context);
        }

        /// <summary>
        /// Проход в лексему "elseBlock".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Блок ELSE".</returns>
        public override ExpressionNode VisitElseBlock([NotNull] AntlrParser.ElseBlockContext context)
        {
            return new ElseBlockNode
            {
                Actions = context._actions.Select(VisitAssignExpr).ToArray()
            };
        }

        /// <summary>
        /// Проход в лексему "elseIfBlock".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Блок ELSE-IF".</returns>
        public override ExpressionNode VisitElseIfBlock([NotNull] AntlrParser.ElseIfBlockContext context)
        {
            return new ElseIfBlockNode
            {
                Actions = context._actions.Select(VisitAssignExpr).ToArray(),
                Predicate = Visit(context.predicate)
            };
        }

        /// <summary>
        /// Проход в лексему "thenBlock".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Блок THEN".</returns>
        public override ExpressionNode VisitThenBlock([NotNull] AntlrParser.ThenBlockContext context)
        {
            return new ThenBlockNode
            {
                Actions = context._actions.Select(VisitAssignExpr)
            };
        }

        /// <summary>
        /// Проход в лексему "ifThenElseBlock".
        /// </summary>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева "Блок ELSE-IF".</returns>
        public override ExpressionNode VisitIfThenElseBlock([NotNull] AntlrParser.IfThenElseBlockContext context)
        {
            return new IfThenElseBlock
            {
                ThenBlock = Visit(context.then),
                IfBlock = Visit(context.@if),
                ElseBlock = Visit(context.@else),
                ElseIfBlocks = context._elseIf.Select(VisitElseIfBlock).ToArray()
            };
        }

        /// <summary>
        /// Проход в лексему.
        /// </summary>
        /// <param name="tree">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева.</returns>
        public override ExpressionNode Visit(IParseTree tree)
        {
            return tree != null ? base.Visit(tree) : new UndefinedNode();
        }

        /// <summary>
        /// Создать узел AST-дерева, производный от узла "Выражение с двумя членами".
        /// </summary>
        /// <typeparam name="T">Тип узла выражения.</typeparam>
        /// <param name="context">Контекст лексемы.</param>
        /// <returns>Узел AST-дерева заданного типа.</returns>
        private ExpressionNode CreateInfixExpressionNode<T>(dynamic context) where T: InfixExpressionNode
        {
            if (Activator.CreateInstance(typeof(T)) is not InfixExpressionNode expressionNode)
                return new UndefinedNode();
            expressionNode.Left = Visit(context.left);
            expressionNode.Right = Visit(context.right);
            expressionNode.Operation = context.op.Text;
            return expressionNode;
        }
    }
}
