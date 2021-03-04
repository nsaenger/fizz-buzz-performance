using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Collections.Generic;

namespace FizzBuzz.Implementations {
    public class FizzBuzzImplementations {
        public static string branchless(int i) {
            return String.Concat(Enumerable.Repeat("Fizz", Convert.ToInt32(i % 3 == 0))) +
                String.Concat(Enumerable.Repeat("Buzz", Convert.ToInt32(i % 5 == 0)));
        }

        public static string inline(int i) {
            return (i % 3 == 0 ? "Fizz" : "") +
                (i % 5 == 0 ? "Fizz" : "") +
                " ";
        }

        public static string standard(int i) {
            string result = "";
            if (i % 15 == 0) {
                result += "FizzBuzz";
            } else if (i % 3 == 0) {
                result += "Fizz";
            } else if (i % 5 == 0) {
                result += "Buzz";
            }
            return result + " ";
        }

        public static string standard2(int i) {
            string result = "";
            if (i % 3 == 0) {
                result += "Fizz";
            }
            if (i % 5 == 0) {
                result += "Buzz";
            }
            return result + " ";
        }

        public static string linqMadness(int i) {
            var combos = new List<Tuple<int, string>> {
                new Tuple<int, string> (3, "Fizz"),
                new Tuple<int, string> (5, "Buzz"),
            };
            var matches = combos.Where(x => i % x.Item1 == 0);
            return (matches.Count() > 0 ? string.Join("", matches.Select(x => x.Item2)) : "") + " ";
        }
    }
}