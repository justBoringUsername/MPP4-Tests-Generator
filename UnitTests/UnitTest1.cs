using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestsGenerator;
using TestsGenerator.IO;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using TestsGenerator.Options;
using System.Threading.Tasks;

namespace UnitTestTestsGenerator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task Tests_Creation()
        {
            ClassReader reader = new ClassReader();
            ClassWriter writer = new ClassWriter("result1");
            GeneratorOptions options = new GeneratorOptions(2, 2, 2);
            Generator generator = new Generator(options, reader, writer);
            List<string> files = new List<string>(Directory.GetFiles("test1"));
            await generator.Generate(files);
            Assert.AreEqual(1, Directory.GetFiles("result1").Length);
        }
        [TestMethod]
        public void Tests_Count()
        {
            ClassReader reader = new ClassReader();
            ClassWriter writer = new ClassWriter("result1");
            GeneratorOptions options = new GeneratorOptions(2, 2, 2);
            Generator generator = new Generator(options, reader, writer);
            List<string> files = new List<string>(Directory.GetFiles("test1"));
            generator.Generate(files).Wait();
            Assert.AreEqual(ParseCompilationUnit(File.ReadAllText(Directory.GetFiles("result1")[0])).DescendantNodes().OfType<MethodDeclarationSyntax>().Count(),
                            ParseCompilationUnit(File.ReadAllText(Directory.GetFiles("test1")[0])).DescendantNodes().OfType<MethodDeclarationSyntax>().Count());
        }
        [TestMethod]
        public void TestsCount_EqualsToClassCount()
        {
            ClassReader reader = new ClassReader();
            ClassWriter writer = new ClassWriter("result2");
            GeneratorOptions options = new GeneratorOptions(2, 2, 2);
            Generator generator = new Generator(options, reader, writer);
            List<string> files = new List<string>(Directory.GetFiles("test2"));
            generator.Generate(files).Wait();
            Assert.AreEqual(Directory.GetFiles("result2").Length, ParseCompilationUnit(File.ReadAllText(Directory.GetFiles("test2")[0])).DescendantNodes().OfType<ClassDeclarationSyntax>().Count());
        }
        [TestMethod]
        public void TestsMethodsCount_EqualsToClassMethodsCount()
        {
            ClassReader reader = new ClassReader();
            ClassWriter writer = new ClassWriter("result2");
            GeneratorOptions options = new GeneratorOptions(2, 2, 2);
            Generator generator = new Generator(options, reader, writer);
            List<string> files = new List<string>(Directory.GetFiles("test2"));
            generator.Generate(files).Wait();
            int method_count = 0;
            foreach (string file in Directory.GetFiles("test2"))
            {
                method_count += ParseCompilationUnit(File.ReadAllText(file)).DescendantNodes().OfType<MethodDeclarationSyntax>().Count();
            }

            Assert.AreEqual(method_count, ParseCompilationUnit(File.ReadAllText(Directory.GetFiles("test2")[0])).DescendantNodes().OfType<MethodDeclarationSyntax>().Count());
        }
        [TestMethod]
        public void TestsTwoConstructors()
        {
            ClassReader reader = new ClassReader();
            ClassWriter writer = new ClassWriter("result3");
            GeneratorOptions options = new GeneratorOptions(2, 2, 2);
            Generator generator = new Generator(options, reader, writer);
            List<string> files = new List<string>(Directory.GetFiles("test3"));
            generator.Generate(files).Wait();
            Assert.AreEqual(2, ParseCompilationUnit(File.ReadAllText(Directory.GetFiles("result3")[0])).DescendantNodes().OfType<MethodDeclarationSyntax>().Count());
        }

    }
}
