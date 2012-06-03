using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Windows.Data;

namespace GalaSoft.MvvmLight.Converters
{
    /// <summary>
    /// Implements a universal converter able to take a lambda expression (as the parameter)
    /// and to run this expression dynamically at runtime to convert the value.
    /// Usage: Store an instance of UniversalConverter into the application's resources
    /// and use this instance in XAML, for example with:
    /// {Binding MyProperty,
    ///  Converter={StaticResource UniversalConverter},
    ///  ConverterParameter='b=>!b'}
    /// </summary>
    public class UniversalConverter : IValueConverter
    {
        private static Dictionary<string, Delegate> _operations;

        /// <summary>
        /// Converts a value into another using an expression (lambda) passed as a string
        /// and evaluated at runtime.
        /// The process is optimized and already created expression cached for further use.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="targetType">This parameter
        /// is not used.</param>
        /// <param name="parameter">The lambda expression to be evaluated at runtime,
        /// expressed as a string. For example expressions such as 'b=>!b' or
        /// 'myValue=>myValue?Visibility.Visible:Visibility.Collapsed' (or more
        /// complex expressions) can be used.</param>
        /// <param name="culture">This parameter is not used.</param>
        /// <returns>The result of the conversion.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetValue(0, value, parameter);
        }

        private object GetValue(int index, object value, object expression)
        {
            if (value == null
                || expression == null)
            {
                return value;
            }

            var expressionString = expression.ToString();

            if (string.IsNullOrEmpty(expressionString))
            {
                return value;
            }

            var expressionStrings = new[]
            {
                expressionString
            };

            if (expressionString.IndexOf("#") > -1)
            {
                expressionStrings = expressionString.Split(
                    new[]
                    {
                        '#'
                    });
            }

            if (index > expressionStrings.Length - 1)
            {
                return value;
            }

            var operation = ConstructOperation(value, expressionStrings[index]);

            if (operation == null)
            {
                return value;
            }

            return operation.DynamicInvoke(new[]
            {
                value
            });
        }

        private static Delegate ConstructOperation(object value, string parameter)
        {
            if (_operations == null)
            {
                _operations = new Dictionary<string, Delegate>();
            }

            if (_operations.ContainsKey(parameter))
            {
                return _operations[parameter];
            }

            var operationIndex = parameter.IndexOf("=>");
            if (operationIndex < 0)
            {
                throw new ArgumentException("No lambda operator =>", "parameter");
            }
            
            var param = parameter.Substring(0, operationIndex);
            var body = parameter.Substring(operationIndex + 2);
            
            var p = System.Linq.Expressions.Expression.Parameter(value.GetType(), param);

            var lambda = DynamicExpressionEx.ParseLambda(
                new[] { p }, typeof(object), body, value);

            var operation = lambda.Compile();
            _operations.Add(parameter, operation);
            return operation;
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="value">Unused parameter.</param>
        /// <param name="targetType">Unused parameter.</param>
        /// <param name="parameter">Unused parameter.</param>
        /// <param name="culture">Unused parameter.</param>
        /// <returns>This method is not implemented.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetValue(1, value, parameter);
        }
    }
}
