using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wynathan.Stellaris.Common.Helpers;
using Wynathan.Stellaris.Common.IO;
using Wynathan.Stellaris.Common.Modding.Models;

namespace Wynathan.Stellaris.Common.Parsing
{
    public class Parser
    {
        public static Dictionary<string, TEntity> Parse<TEntity>(string filePath)
            where TEntity : class, new()
        {
            return ParseEnumerate<TEntity>(filePath).ToDictionary(x => x.Key, x => x.Value);
        }

        public static IEnumerable<KeyValuePair<string, TEntity>> ParseEnumerate<TEntity>(string filePath)
            where TEntity : class, new()
        {
            string content;
            using (var file = new SynchronisedFileAccessor(filePath))
                content = file.ReadAll();

            if (string.IsNullOrWhiteSpace(content))
                yield break;

            bool isStringData = false;
            bool isSkippingComment = false;
            bool isList = false;
            var builder = new StringBuilder();
            var stack = new Stack<object>();
            object currentObject = null;
            var currentList = new List<string>();
            PropertyInfo currentProperty = null;
            string currentKey = null;
            string value;

            foreach (var character in content)
            {
                switch (character)
                {
                    case '#':
                        if (!isStringData)
                            isSkippingComment = true;
                        else
                            goto default;
                        break;
                    case '\r':
                        continue;
                    case '\n':
                        isSkippingComment = false;
                        if (builder.Length > 0)
                        {
                            value = builder.ToString();
                            if (isList)
                                currentList.Add(value);
                            else
                                SetValue(currentProperty, currentObject, value);
                            builder.Clear();
                        }
                        break;
                    case '{':
                        if (isSkippingComment)
                            continue;

                        if (currentProperty == null)
                            continue;

                        var tmpObject = currentProperty.GetValue(currentObject);
                        isList = tmpObject.GetType() == typeof(List<string>);

                        if (isList)
                        {
                            currentList.Clear();
                        }
                        else
                        {
                            if (currentObject != tmpObject)
                                stack.Push(currentObject);
                            currentObject = tmpObject;
                        }

                        break;
                    case '}':
                        if (isSkippingComment)
                            continue;
                        
                        if (isList)
                        {
                            currentProperty.SetValue(currentObject, new List<string>(currentList));
                            currentList.Clear();
                            isList = false;
                        }
                        else
                        {
                            currentProperty = null;
                            if (stack.Count == 0)
                            {
                                yield return new KeyValuePair<string, TEntity>(currentKey, currentObject as TEntity);
                                currentObject = null;
                            }
                            else
                            {
                                var parent = stack.Pop();
                                currentObject = parent;
                            }
                        }
                        break;
                    case '"':
                        if (isSkippingComment)
                            continue;

                        if (isStringData)
                        {
                            isStringData = false;
                            goto case ' ';
                        }
                        else
                        {
                            isStringData = true;
                        }
                        break;
                    case '=':
                        if (isSkippingComment)
                            continue;

                        value = builder.ToString();
                        builder.Clear();

                        if (currentObject == null)
                        {
                            currentKey = value;
                            currentObject = new TEntity();
                            currentProperty = null;
                        }
                        else
                        {
                            currentProperty = ParserCache.GetTypeCacheByName(currentObject.GetType(), value);
                        }
                        break;
                    case '\t':
                    case ' ':
                        if (isSkippingComment)
                            continue;
                        
                        if (isStringData)
                            builder.Append(character);
                        else if (builder.Length > 0 && isList)
                        {
                            value = builder.ToString();
                            currentList.Add(value);
                            builder.Clear();
                        }
                        break;
                    default:
                        if (isSkippingComment)
                            continue;
                        
                        builder.Append(character);
                        break;
                }
            }
        }

        private static void SetValue(PropertyInfo propertyInfo, object o, string value)
        {
            if (propertyInfo == null)
                return;

            if (o == null)
                return;
            
            object valueWrapped = TypeHelper.Convert(value, propertyInfo.PropertyType);
            propertyInfo.SetValue(o, valueWrapped);
        }
    }
}
