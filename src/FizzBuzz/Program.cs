using System.Linq;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using ExtensionMethods;
using FizzBuzz.Implementations;

namespace FizzBuzz {
    class Program {

        static int Main(string[] args) {
            // Default values
            uint maxFizzbuzzIterations = 1000;
            uint maxTestIterations = 100;

            // Validating command line arguments
            try {
                (maxFizzbuzzIterations, maxTestIterations) = validateArgs(args, maxFizzbuzzIterations, maxTestIterations);
            } catch (Exception) {
                printHelp();
                return -1;
            }

            // Setting up lists
            List<int> testIterations = Enumerable.Range(1, (int)maxTestIterations).ToList();
            List<int> fizzbuzzIterations = Enumerable.Range(1, (int)maxFizzbuzzIterations).ToList();
            List<Func<int, string>> options = new List<Func<int, string>> {
                FizzBuzzImplementations.branchless,
                FizzBuzzImplementations.inline,
                FizzBuzzImplementations.standard,
                FizzBuzzImplementations.standard2,
                FizzBuzzImplementations.linqMadness
            };
            List<Tuple<string, int>> results = new List<Tuple<string, int>>();

            // Begin tests            
            foreach (var option in options) {
                string name = option.Method.Name;
                List<int> times = new List<int>();
                Console.WriteLine("Testing FizzBuzz({0}) '{1}' {2} times...", fizzbuzzIterations.Count(), name, testIterations.Count());

                // Start FizzBuzz testing
                foreach (var iteration in testIterations) {
                    // Eye candy
                    string progress = ((float)iteration / (float)testIterations.Count() * 100f)
                        .ToString("F2")
                        .PadRight(5, ' ');
                    Console.Write("\r\t{0}%", progress);

                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    string result = "";
                    foreach (int i in fizzbuzzIterations) {
                        string fizzBuzz = option(i);
                        result += fizzBuzz.Length > 0 ? fizzBuzz + " " : "";
                    }
                    result = "";
                    sw.Stop();

                    times.Add(sw.Elapsed.Milliseconds);
                }

                // Result evaluation
                int min = Int32.MaxValue;
                int max = Int32.MinValue;
                int sum = 0;
                int avg = 0;

                foreach (int x in times) {
                    sum += x;
                    min = x < min ? x : min;
                    max = x > max ? x : max;
                }
                avg = sum / testIterations.Count();
                Console.WriteLine(" finished in {0}ms", sum);
                Console.WriteLine("\t Averag: {0}ms", avg);
                Console.WriteLine("\t Range:  {0}ms - {1}ms", min, max);
            }

            return 0;
        }

        public static (uint, uint) validateArgs(string[] args, uint defaultFizzbuzzIterations, uint defaultTestIterations) {
            if (args.Length == 0) {
                return (defaultFizzbuzzIterations, defaultTestIterations);
            } else {
                if (args[0] == "-h") {
                    throw new Exception("Help him!");
                }

                if (args.Length == 1) {
                    return (UInt32.Parse(args[0]), defaultTestIterations);
                } else if (args.Length == 2) {
                    return (UInt32.Parse(args[0]), UInt32.Parse(args[1]));
                } else {
                    throw new Exception("Too many arguments");
                }
            }
        }

        public static void printHelp() {
            Console.WriteLine("Performance Test Suite for for Fizz Buzz implementations\n");
            Console.WriteLine("Usage: fizzbuzz [options] [(unsigned int) fizzbuzz_iterations] [(unsigned int) test_iterations]");
            Console.WriteLine("\tOptions:");
            Console.WriteLine("\t\t-h\t\t\tDisplays this text");
            Console.WriteLine("\tArguments:");
            Console.WriteLine("\t\tfizzbuzz_iterations\tTo which number fizz buzz should count (Default: 1000)");
            Console.WriteLine("\t\ttest_iterations\t\tHow many times each function should be tested (Default: 100)");
        }

    }
}
