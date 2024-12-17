﻿using System;
using System.Text.RegularExpressions;
namespace StringCalculator
{
    public class ExpressionValidator
    {
        public void Validate(string expression)
        {
            if (!Regex.IsMatch(expression, @"^[0-9\+\-\*/\(\)\.]+$"))
            {
                throw new FormatException("Выражение содержит недопустимые символы.");
            }
            int openParenthesesCount = 0;
            foreach (char c in expression)
            {
                if (c == '(') openParenthesesCount++;
                if (c == ')') openParenthesesCount--;
            }
            if (openParenthesesCount != 0)
            {
                throw new FormatException("Несовпадающие круглые скобки.");
            }
            if (Regex.IsMatch(expression, @"[\+\-\*/]{2,}"))
            {
                throw new FormatException("Выражение содержит последовательные операторы.");
            }
        }
    }
}