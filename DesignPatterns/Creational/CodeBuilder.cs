using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational
{
    public class CodeBuilder
    {
        private Code Code { get; }

        public CodeBuilder(string className)
        {
            Code = new Code(className);
        }

        public CodeBuilder AddField(string fieldName, string type)
        {
            Code.Fields.Add(fieldName, type);
            return this;
        }

        public override string ToString()
        {
            var indent = new string(' ', 2);
            var classBuilder = new StringBuilder();
            classBuilder.AppendLine($"public class {Code.ClassName}").AppendLine("{");


            foreach (var codeField in Code.Fields)
            {
                classBuilder.AppendLine($"{indent}public {codeField.Value} {codeField.Key};");
            }

            classBuilder.Append("}");

            return classBuilder.ToString();
        }

        public static implicit operator string(CodeBuilder cb)
        {
            return cb.ToString();
        }
    }

    internal class Code
    {
        public string ClassName { get; set; }
        public Dictionary<string, string> Fields { get; set; } = new();

        public Code(string className)
        {
            ClassName = className;
        }
    }
}