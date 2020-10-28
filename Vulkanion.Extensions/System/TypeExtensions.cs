using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Vulkanion.Extensions.System
{
    public static class TypeExtensions
    {
        public static Type GetElementTypeForExpression(this Type seqType)
        {
            var enumerableType = FindIEnumerableType(seqType);
            return enumerableType == null ? seqType : enumerableType.GetGenericArguments()[0];
        }

        public static MethodInfo GetGenericMethod(this Type owner, string methodName)
        {
            return owner.GetMethods().SingleOrDefault(m => m.Name == methodName && m.IsGenericMethod);
        }

        public static Type FindIEnumerableType(Type seqType)
        {
            if(seqType == null || seqType == typeof(string))
                return null;

            if(seqType.IsArray)
                return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());

            if(seqType.IsGenericType)
            {
                foreach(Type arg in seqType.GetGenericArguments())
                {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if(ienum.IsAssignableFrom(seqType))
                    {
                        return ienum;
                    }
                }
            }

            var ifaces = seqType.GetInterfaces();
            if(ifaces?.Length > 0)
            {
                foreach(Type iface in ifaces)
                {
                    Type ienum = FindIEnumerableType(iface);
                    if(ienum != null)
                    {
                        return ienum;
                    }
                }
            }

            if(seqType?.BaseType != typeof(object))
            {
                return FindIEnumerableType(seqType.BaseType);
            }

            return null;
        }
    }
}
// From: https://github.com/conwid/BetterRepository, https://dotnetfalcon.com/implementing-the-repository-pattern-with-direct-iqueryable-support/.