using System;
using System.Collections.Generic;

namespace quicklystart {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            // Type.GenericTypeArguments 此属性仅获取泛型类型参数
            var propertyType = typeof(Example).GetProperty("Somes").PropertyType;
            // 获取范型类型参数 SomeClass
            var genericType = propertyType.GetGenericTypeDefinition();

            Console.WriteLine($"typeof(Example).GetProperty(\"Somes\").PropertyType = {genericType.FullName}");

            Console.WriteLine($"typeof(Example).GetProperty(\"Somes\").PropertyType.BaseType = {genericType.BaseType}");

            Console.WriteLine($"typeof(Example).GetProperty(\"Somes\").PropertyType.DeclaringType = {genericType.DeclaringType}");

            // 获取范型类型定义的参数类型
            var genericTypeParameters = propertyType.GenericTypeArguments;
            Console.WriteLine($"propertyType.GenericTypeArguments[0] = {genericTypeParameters[0].FullName}");

            // Type.GetGenericTypeDefinition
            Dictionary<string, Example> d = new Dictionary<string, Example>();
            Type constructed = d.GetType();
            DisplayTypeInfo(constructed);

            Type generic = constructed.GetGenericTypeDefinition();
            DisplayTypeInfo(generic);
        }

        private static void DisplayTypeInfo(Type t) {
            Console.WriteLine("\r\n{0}", t);
            Console.WriteLine("\tIs this a generic type definition? {0}",
                t.IsGenericTypeDefinition);
            Console.WriteLine("\tIs it a generic type? {0}",
                t.IsGenericType);
            Type[] typeArguments = t.GetGenericArguments();
            Console.WriteLine("\tList type arguments ({0}):", typeArguments.Length);
            foreach (Type tParam in typeArguments) {
                Console.WriteLine("\t\t{0}", tParam);
            }
        }
    }

    class Example {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<SomeClass> Somes { get; set; }
    }

    class SomeClass {
        public long Id { get; set; }
        public ICollection<int> ParentIds { get; set; }
    }
}