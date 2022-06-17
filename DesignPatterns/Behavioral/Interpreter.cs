using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Behavioral
{
    public interface IElement
    {
        int Value { get; }
    }

    public class Integer : IElement
    {
        public Integer(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class BinaryOperation : IElement
    {
        public enum Type
        {
            Addition,
            Subtraction
        }

        public Type MyType;
        public IElement Left, Right;

        public int Value
        {
            get
            {
                switch (MyType)
                {
                    case Type.Addition:
                        return Left.Value + Right.Value;
                    case Type.Subtraction:
                        return Left.Value - Right.Value;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public class Token
    {
        public enum Type
        {
            Integer,
            Plus,
            Minus
        }

        public Type MyType;
        public string Text;

        public Token(Type type, string text)
        {
            MyType = type;
            Text = text;
        }

        public override string ToString()
        {
            return $"`{Text}`";
        }
    }

    public class ExpressionProcessor
    {
        public Dictionary<char, int> Variables = new Dictionary<char, int>();

        public List<Token> Lex(string input)
        {
            var result = new List<Token>();

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '+':
                        result.Add(new Token(Token.Type.Plus, "+"));
                        break;
                    case '-':
                        result.Add(new Token(Token.Type.Minus, "-"));
                        break;
                    default:
                        var sb = new StringBuilder(input[i].ToString());
                        for (int j = i + 1; j < input.Length; ++j)
                        {
                            int val;
                            if (char.IsDigit(input[j]))
                            {
                                sb.Append(input[j]);
                                ++i;
                            }
                            else if (Variables.TryGetValue(input[j], out val))
                            {
                                sb.Append(val);
                                ++i;
                            }
                            else
                            {
                                result.Add(new Token(Token.Type.Integer, sb.ToString()));
                                break;
                            }
                        }

                        if (i == input.Length - 1)
                        {
                            int val;
                            if (Variables.TryGetValue(input[i], out val))
                            {
                                sb.Replace(input[i], char.Parse(val.ToString()));
;                            }

                            result.Add(new Token(Token.Type.Integer, sb.ToString()));
                        }

                        // result.Add(new Token(Token.Type.Integer, sb.ToString()));
                        break;
                }
            }

            return result;
        }

        public int Calculate(string expression)
        {
            var tokens = Lex(expression);
            var result = new BinaryOperation();
            bool haveLHS = false;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.MyType)
                {
                    case Token.Type.Integer:
                        int val;
                        if (!int.TryParse(token.Text, out val)) return 0;
                        var integer = new Integer(val);
                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }

                        break;
                    case Token.Type.Plus:
                        result.MyType = BinaryOperation.Type.Addition;
                        break;
                    case Token.Type.Minus:
                        result.MyType = BinaryOperation.Type.Subtraction;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (IsOperationSet(result))
                {
                    result.Left = new Integer(result.Value);
                    result.Right = null;
                }
            }

            return result.Left.Value;
        }

        private bool IsOperationSet(BinaryOperation operation)
        {
            return operation.Left != null && operation.Right != null;
        }
    }
}