using System;
using System.Linq.Expressions;

namespace Viticulture.Utils
{
    public static class MemberNameHelper
    {
        /// <summary> Gets the member name of an object of a specified type.</summary>
        /// <param name="instance">The instance where the member resides.</param>
        /// <param name="expression">The expression representing a member.</param>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <returns>The member name.</returns>
        public static string GetMemberName<T>(
            this T instance,
            Expression<Func<T, object>> expression)
        {
            return GetMemberName(expression);
        }

        /// <summary> Gets the member name a specified type.</summary>
        /// <param name="expression">The expression representing a member.</param>
        /// <typeparam name="T">The type where the member resides.</typeparam>
        /// <returns>The member name.</returns>
        public static string GetMemberName<T>(
            Expression<Func<T, object>> expression)
        {
            return GetMemberName((LambdaExpression)expression);
        }

        /// <summary> Gets the member name a specified type.</summary>
        /// <param name="instance">The instance where the member resides.</param>
        /// <param name="expression">The expression representing a member.</param>
        /// <typeparam name="T">The type where the member resides.</typeparam>
        /// <returns>The member name.</returns>
        public static string GetMemberName<T>(this T instance,
            Expression<Action<T>> expression)
        {
            return GetMemberName((LambdaExpression)expression);
        }

        /// <summary> Gets the member name a specified type.</summary>
        /// <param name="expression">The expression representing a member.</param>
        /// <typeparam name="T">The type where the member resides.</typeparam>
        /// <returns>The member name.</returns>
        public static string GetMemberName<T>(
            Expression<Action<T>> expression)
        {
            return GetMemberName((LambdaExpression)expression);
        }

        /// <summary> Gets the member name a specified type.</summary>
        /// <param name="expression">The lambda expression representing a member.</param>
        /// <returns>The member name.</returns>
        public static string GetMemberName(LambdaExpression expression)
        {
            return GetMemberName(expression.Body);
        }

        /// <summary> Gets the member name of an expression.</summary>
        /// <param name="expression">The expression containing the method.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetMemberName(
            Expression expression)
        {
            var memberExpression = expression as MemberExpression;
            if (memberExpression != null)
            {
                // Reference type property or field
                return memberExpression.Member.Name;
            }

            var methodCallExpression = expression as MethodCallExpression;
            if (methodCallExpression != null)
            {
                // Reference type method
                return methodCallExpression.Method.Name;
            }

            var unaryExpression = expression as UnaryExpression;
            if (unaryExpression != null)
            {
                // Property, field of method returning value type
                return GetMemberName(unaryExpression);
            }

            throw new ArgumentException("Invalid expression");
        }

        /// <summary> Gets the member name of a unary expression.</summary>
        /// <param name="unaryExpression">The unary expression.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetMemberName(
            UnaryExpression unaryExpression)
        {
            var methodCallExpression = unaryExpression.Operand as MethodCallExpression;
            if (methodCallExpression != null)
            {
                return methodCallExpression.Method.Name;
            }

            return ((MemberExpression)unaryExpression.Operand).Member.Name;
        }
    }
}
