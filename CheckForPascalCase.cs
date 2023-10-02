using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PascalCaseChecker
{
    public class PascalCaseCheck
    {
        public static void Check()
        { 
            var assembly = Assembly.GetCallingAssembly();
            List<string> validTypes = new List<string>();
            List<string> inValidTypes = new List<string>();
            string PascalCasePattern = "^[A-Z][a-z]+(?:[A-Z][a-z]+)*$";
            Type[] types = assembly.GetTypes().Where(type => !IsCompilerGenerated(type)).ToArray();
            foreach (Type type in types)
            {
                if (type.FullName.StartsWith(assembly.FullName.Split(",")[0]))
                {
                    if(Regex.Match(type.Name , PascalCasePattern).Success)
                    {
                        validTypes.Add(type.Name);
                    }
                    else
                    {
                        inValidTypes.Add(type.Name);
                    }
                }
            }

            if (validTypes.Count > 0)
            {
                Console.WriteLine("Types In PascalCase are:");
                Console.WriteLine(string.Join(Environment.NewLine, validTypes));
            }
            if(inValidTypes.Count > 0)
            {
                Console.WriteLine("Types Not In PascalCase are:");
                Console.WriteLine(string.Join(Environment.NewLine, inValidTypes));
            }
           
        }
        public static bool IsCompilerGenerated(Type type)
        {
            return type.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), false).Any()
                || type.Name.StartsWith("<>") || type.Name.Contains("__AnonymousType");
        }

    }
}
