using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shunking_Yar
{
    class Token
    {
        public Token(string str)
        {
            if (str == "+")
            {
                IsNumber = false;
                prio = 1;
                this.Operator = "+";
            }
            if (str == "-")
            {
                IsNumber = false;
                prio = 1;
                Operator = "-";
            }
            if (str == "(")
            {
                IsNumber = false;
                IsLeftBrace = true;
            }
            if (str == ")")
            {
                IsNumber = false;
                IsRightBrace = true;
            }
            if (str == "*")
            {
                IsNumber = false;
                prio = 2;
                Operator = "*";
            }
            if (str == "/")
            {
                IsNumber = false;
                prio = 2;
                Operator = "/";
            }
            if (str == "" || str == " ")
            {
                IsNumber = false;
                IsEmpty = true;
            }
            else if (str != "/" && str != "*" && str != ")" && str != "(" && str != "-" && str != "+" && str != " ")
            {
                Number = double.Parse(str);
            }
        }
        public bool IsEmpty = false;
        public int prio = -1;
        public double Number = 0;
        public bool IsNumber = true;
        public bool IsLeftBrace = false;
        public bool IsRightBrace = false;
        public string Operator = "Default";
    }
}
