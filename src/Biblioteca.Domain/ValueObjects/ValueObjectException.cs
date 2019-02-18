using System;
using System.Collections.Generic;

namespace Biblioteca.Domain.ValueObjects
{
    public class ValueObjectException : Exception
    {
        internal ValueObjectException(IEnumerable<string> messages) : base(FormatMessages(messages))
        {
        }

        internal ValueObjectException(string message) : base(message)
        {
        }

        private static string FormatMessages(IEnumerable<string> messages)
        {
            return string.Join("\n -", messages);
        }
    }
}