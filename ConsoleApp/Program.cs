using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsGenerator;
using TestsGenerator.IO;
using TestsGenerator.Options;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassReader reader = new ClassReader();
            ClassWriter writer = new ClassWriter("C:\\testsDone");
            GeneratorOptions options = new GeneratorOptions(1, 1, 1);
            Generator generator = new Generator(options, reader, writer);
            List<string> files = new List<string>(Directory.GetFiles("C:\\tests"));

            generator.Generate(files).Wait();
            Console.WriteLine("Finish...");
            Console.ReadKey();
        }
    }
}
