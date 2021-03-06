﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace JSIL.Compiler {
    class Program {
        static void ParseOption (AssemblyTranslator translator, string option) {
            var m = Regex.Match(option, "-(-?)(?'key'[a-zA-Z]*)([=:](?'value'.*))?", RegexOptions.ExplicitCapture);
            if (m.Success) {
                switch (m.Groups["key"].Value.ToLower()) {
                    case "out":
                    case "o":
                        translator.OutputDirectory = Path.GetFullPath(m.Groups["value"].Value);
                        break;
                    case "nodeps":
                    case "nd":
                        translator.IncludeDependencies = false;
                        break;
                    case "ignore":
                    case "i":
                        translator.IgnoredAssemblies.Add(new Regex(m.Groups["value"].Value, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture));
                        break;
                    case "stub":
                    case "s":
                        translator.StubbedAssemblies.Add(new Regex(m.Groups["value"].Value, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture));
                        break;
                    case "proxy":
                    case "p":
                        translator.AddProxyAssembly(Path.GetFullPath(m.Groups["value"].Value), false);
                        break;
                    case "os":
                        translator.OptimizeStructCopies = false;
                        break;
                    case "oo":
                        translator.SimplifyOperators = false;
                        break;
                    case "ol":
                        translator.SimplifyLoops = false;
                        break;
                    case "ot":
                        translator.EliminateTemporaries = false;
                        break;
                }
            }
        }

        static void ApplyDefaults (AssemblyTranslator translator) {
            Console.Error.WriteLine("// Applying default settings. To suppress, use --nodefaults.");

            translator.StubbedAssemblies.Add(new Regex(@"mscorlib,"));
            translator.StubbedAssemblies.Add(new Regex(@"System.*"));
            translator.StubbedAssemblies.Add(new Regex(@"Microsoft.*"));
            translator.StubbedAssemblies.Add(new Regex(@"Accessibility,"));
        }

        static void Main (string[] arguments) {
            var translator = new AssemblyTranslator();
            translator.LoadingAssembly += (fn, progress) => {
                Console.Error.WriteLine("// Loading {0}. ", fn);
            };
            translator.Decompiling += (progress) => {
                Console.Error.Write("// Decompiling ");

                var previous = new int[1] { 0 };

                progress.ProgressChanged += (s, p, max) => {
                    var current = p * 20 / max;
                    if (current != previous[0]) {
                        previous[0] = current;
                        Console.Error.Write(".");
                    }
                };

                progress.Finished += (s, e) => {
                    Console.Error.WriteLine(" done");
                };
            };
            translator.Optimizing += (progress) => {
                Console.Error.Write("// Optimizing ");

                var previous = new int[1] { 0 };

                progress.ProgressChanged += (s, p, max) => {
                    var current = p * 20 / max;
                    if (current != previous[0]) {
                        previous[0] = current;
                        Console.Error.Write(".");
                    }
                };

                progress.Finished += (s, e) => {
                    Console.Error.WriteLine(" done");
                };
            };
            translator.Writing += (progress) => {
                Console.Error.Write("// Writing JS ");

                var previous = new int[1] { 0 };

                progress.ProgressChanged += (s, p, max) => {
                    var current = p * 20 / max;
                    if (current != previous[0]) {
                        previous[0] = current;
                        Console.Error.Write(".");
                    }
                };

                progress.Finished += (s, e) => {
                    Console.Error.WriteLine(" done");
                };
            };
            translator.CouldNotLoadSymbols += (fn, ex) => {
                Console.Error.WriteLine("// {0}", ex.Message);
            };
            translator.CouldNotResolveAssembly += (fn, ex) => {
                Console.Error.WriteLine("// Could not load module {0}: {1}", fn, ex.Message);
            };
            translator.CouldNotDecompileMethod += (fn, ex) => {
                Console.Error.WriteLine("// Could not decompile method {0}: {1}", fn, ex.Message);
            };

            var filenames = new HashSet<string>(arguments);
            bool includeDefaults = true;

            foreach (var filename in arguments) {
                if (filename.StartsWith("-")) {
                    filenames.Remove(filename);
                    if (filename == "--nodefaults") {
                        includeDefaults = false;
                    } else {
                        ParseOption(translator, filename);
                    }
                }
            }

            if (filenames.Count == 0) {
                var asmName = Assembly.GetExecutingAssembly().GetName();
                Console.WriteLine("==== JSILc v{0}.{1}.{2} ====", asmName.Version.Major, asmName.Version.Minor, asmName.Version.Revision);
                Console.WriteLine("Usage: JSILc [options] ...");
                Console.WriteLine("Specify one or more compiled assemblies (dll/exe) to translate them. Symbols will be loaded if they exist in the same directory.");
                Console.WriteLine("You can also specify Visual Studio solution files (sln) to build them and automatically translate their output(s).");
                Console.WriteLine("Options:");
                Console.WriteLine("--out:<folder>");
                Console.WriteLine("  Specifies the directory into which the generated javascript should be written.");
                Console.WriteLine("--nodeps");
                Console.WriteLine("  Disables translating dependencies.");
                Console.WriteLine("--nodefaults");
                Console.WriteLine("  Disables the built-in default stub list. Use this if you actually want to translate huge Microsoft assemblies like mscorlib.");
                Console.WriteLine("--oS");
                Console.WriteLine("  Disables struct copy optimizations");
                Console.WriteLine("--oO");
                Console.WriteLine("  Disables operator optimizations");
                Console.WriteLine("--oL");
                Console.WriteLine("  Disables loop optimizations");
                Console.WriteLine("--oT");
                Console.WriteLine("  Disables temporary variable elimination");
                Console.WriteLine("--proxy:<assembly>");
                Console.WriteLine("  Specifies the location of a proxy assembly that contains type information for other assemblies.");
                Console.WriteLine("--ignore:<regex>");
                Console.WriteLine("  Specifies a regular expression filter used to ignore certain dependencies.");
                Console.WriteLine("--stub:<regex>");
                Console.WriteLine("  Specifies a regular expression filter used to specify that certain dependencies should only be generated as stubs.");
                return;
            }

            if (includeDefaults)
                ApplyDefaults(translator);

            while (filenames.Count > 0) {
                var filename = filenames.First();
                filenames.Remove(filename);

                var extension = Path.GetExtension(filename);
                switch (extension.ToLower()) {
                    case ".exe":
                    case ".dll":
                        translator.Translate(filename);
                        break;
                    case ".sln":
                        foreach (var resultFilename in SolutionBuilder.Build(filename)) {
                            filenames.Add(resultFilename);
                        }
                        break;
                    default:
                        Console.Error.WriteLine("// Don't know what to do with file '{0}'.", filename);
                        break;
                }
            }
        }
    }
}
