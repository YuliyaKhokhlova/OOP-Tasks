using System;
using System.Collections.Generic;

namespace StackCalc
{
    class Context
    {
        Dictionary<string, double> _definedSymbols = new Dictionary<string, double>();
        public Dictionary<string, double>.KeyCollection DefinedSymbols
        {
            get
            {
                return _definedSymbols.Keys;
            }
        }

        public void DefineSymbol(string symbolName, double symbolValue)
        {
            _definedSymbols[symbolName] = symbolValue;
        }

        public double SymbolValue(string symbolName)
        {
            if (!_definedSymbols.ContainsKey(symbolName))
            {
                throw new UndefinedSymbolException(symbolName);
            }
            return _definedSymbols[symbolName];
        }

        public Context()
        { }

        public class UndefinedSymbolException : Exception
        {
            public UndefinedSymbolException() : base("Symbol is not defined it the current context")
            { }

            public UndefinedSymbolException(string symbolName) : base("Symbol '" + symbolName + "' is not defined it the current context")
            { }
        }
    }
}