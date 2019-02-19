using System;
using Xbehave;
using Xbehave.Sdk;

namespace Biblioteca.Domain.Tests
{
    public static class TestExtension
    {
        public static IStepBuilder Do(this string text, Action body)
        {
            return text.x(body);
        }
    }
}