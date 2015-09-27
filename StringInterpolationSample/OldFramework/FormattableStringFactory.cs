namespace System.Runtime.CompilerServices
{
    public static class FormattableStringFactory
    {

        public static FormattableString Create(string format, params object[] arguments)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }


            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }


            return new ConcreteFormattableString(format, arguments);
        }


        private sealed class ConcreteFormattableString : FormattableString
        {
            private readonly object[] _arguments;

            internal ConcreteFormattableString(string format, object[] arguments)
            {
                Format = format;
                _arguments = arguments;
            }

            public override string Format { get; }
            public override object[] GetArguments() => _arguments;
            public override int ArgumentCount => _arguments.Length;
            public override object GetArgument(int index) => _arguments[index];
            public override string ToString(IFormatProvider formatProvider) => string.Format(formatProvider, Format, _arguments);
        }
    }
}

