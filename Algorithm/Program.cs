using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shunking_Yar
{
    class Program
    {
        static Stack<Token> _stack = new Stack<Token>();
        static List<Token> _list = new List<Token>();
        static void Main(string[] args)
        {
            var str = "(45 + 60 * 2) - 30";
            str = str.Replace("+", "b+b");
            str = str.Replace("-", "b-b");
            str = str.Replace("*", "b*b");
            str = str.Replace("(", "b(b");
            str = str.Replace(")", "b)b");
            var str1 = str.Split("b");
            Console.WriteLine(Finalize(ToOutFormat(Tokenisation(str1))));


            Console.ReadLine();
        }
        static public List<Token> Tokenisation(string[] str)
        {
            List<Token> ReturnList = new List<Token>();
            foreach (string item in str)
            {
                ReturnList.Add(new Token(item));
            }
            return ReturnList;
        }
        static public List<Token> ToOutFormat(List<Token> firstList)
        {
            for (int i = 0; i < firstList.Count; i++)
            {
                if (firstList[i].IsEmpty)
                {

                }
                if (firstList[i].IsLeftBrace)
                {
                    _stack.Push(firstList[i]);
                }
                if (firstList[i].IsRightBrace)
                {
                    var tmp = _stack.Count;
                    for (int j = 0; j < tmp; j++)
                    {
                        if (!_stack.Peek().IsLeftBrace)
                        {
                            _list.Add(_stack.Pop());
                        }
                        else if (_stack.Peek().IsLeftBrace)
                        {
                            _stack.Pop();
                            break;
                        }
                    }
                }
                if (firstList[i].Operator != "Default")
                {
                    if (_stack.Count == 0)
                    {
                        _stack.Push(firstList[i]);
                    }
                    else if (firstList[i].prio < _stack.Peek().prio)
                    {
                        _list.Add(_stack.Pop());
                        _stack.Push(firstList[i]);
                    }
                    else
                    {
                        _stack.Push(firstList[i]);
                    }
                }
                if (firstList[i].IsNumber)
                {
                    _list.Add(firstList[i]);
                }
            }
            if (_stack.Count != 0)
            {
                for (int i = 0; i < _stack.Count; i++)
                {
                    _list.Add(_stack.Pop());
                }
            }
            return _list;
        }
        static public double Finalize(List<Token> origin)
        {

            for (int i = 0; i < origin.Count; i++)
            {
                if (origin[i].IsNumber)
                {
                    _stack.Push(origin[i]);
                }
                if (origin[i].Operator != "Default")
                {
                    var tmp1 = _stack.Pop();
                    var tmp2 = _stack.Pop();
                    double tmp;
                    switch (origin[i].Operator)
                    {
                        case "+":
                            tmp = tmp2.Number + tmp1.Number;
                            _stack.Push(new Token(tmp.ToString()));
                            break;
                        case "-":
                            tmp = tmp2.Number - tmp1.Number;
                            _stack.Push(new Token(tmp.ToString()));
                            break;
                        case "/":
                            tmp = tmp2.Number / tmp1.Number;
                            _stack.Push(new Token(tmp.ToString()));
                            break;
                        case "*":
                            tmp = tmp2.Number * tmp1.Number;
                            _stack.Push(new Token(tmp.ToString()));
                            break;
                    }
                }
            }
            if (_stack.Count == 1)
            {
                return _stack.Pop().Number;
            }
            return default(double);
        }
    }
}
