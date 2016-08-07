using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;

namespace wt.Library
{
	public sealed class CalculateExpression
	{
		public CalculateExpression()
		{
		}

		public static object Calculate(string expression)
		{
			string str = "Calc";
			string str1 = "Run";
			expression = expression.Replace("/", "*1.0/");
			CodeDomProvider cSharpCodeProvider = new CSharpCodeProvider();
			CompilerParameters compilerParameter = new CompilerParameters()
			{
				GenerateExecutable = false,
				GenerateInMemory = true
			};
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(string.Concat("public   class   ", str, "\n"));
			stringBuilder.Append("{\n");
			stringBuilder.Append(string.Concat("         public   object   ", str1, "()\n"));
			stringBuilder.Append("         {\n");
			stringBuilder.Append(string.Concat("                 return   ", expression, ";\n"));
			stringBuilder.Append("         }\n");
			stringBuilder.Append("}");
			string[] strArrays = new string[] { stringBuilder.ToString() };
			CompilerResults compilerResult = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameter, strArrays);
			object obj = compilerResult.CompiledAssembly.CreateInstance(str);
			MethodInfo method = obj.GetType().GetMethod(str1);
			object obj1 = method.Invoke(obj, null);
			GC.Collect();
			return obj1;
		}
	}
}