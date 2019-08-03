using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Json
{
    class Program
    {
        static void Main(string[] args)
        {
            // Value

            Json.Value jsonValue;

            Console.WriteLine("    [JsonString]");
            jsonValue = "abc";
            Console.WriteLine(jsonValue == "abc");
            Console.WriteLine(jsonValue != "def");
            Console.WriteLine("abc" == jsonValue);
            Console.WriteLine("def" != jsonValue);
            Console.WriteLine();

            Console.WriteLine("    [JsonBoolean]");
            jsonValue = true;
            Console.WriteLine(jsonValue == true);
            Console.WriteLine(jsonValue != false);
            Console.WriteLine(true == jsonValue);
            Console.WriteLine(false != jsonValue);
            Console.WriteLine();

            Console.WriteLine("    [JsonNull]");
            jsonValue = new Json.Value.Null();
            Console.WriteLine(jsonValue == null);
            Console.WriteLine(null == jsonValue);
            Console.WriteLine();

            Console.WriteLine("    [JsonNumber]");
            jsonValue = 123;
            Console.WriteLine(jsonValue == 123);
            Console.WriteLine(jsonValue == 123.0);
            Console.WriteLine(jsonValue != 456);
            Console.WriteLine(jsonValue != 456.0);
            Console.WriteLine(123 == jsonValue);
            Console.WriteLine(123.0 == jsonValue);
            Console.WriteLine(456 != jsonValue);
            Console.WriteLine(456.0 != jsonValue);
            Console.WriteLine();

            Console.WriteLine("    [JsonArray]");
            jsonValue = new List<Json.Value>(new Json.Value[] { 123, 456, 789 });
            foreach (int i in (List<Json.Value>)jsonValue)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            jsonValue = new List<Json.Value>(new Json.Value[] { "abc", "def", "ghi" });
            foreach (string i in (List<Json.Value>)jsonValue)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            jsonValue = new List<Json.Value>(new Json.Value[] { "str", true, 001 });
            Console.Write((string)jsonValue[0] + " ");
            Console.Write((bool)jsonValue[1] + " ");
            Console.Write((int)jsonValue[2] + " ");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("    [JsonObject]");
            Dictionary<string, Json.Value> dic = new Dictionary<string, Json.Value>();
            dic.Add("a", "str");
            dic.Add("b", true);
            dic.Add("c", 001);
            jsonValue = dic;
            Console.Write((string)jsonValue["a"] + " ");
            Console.Write((bool)jsonValue["b"] + " ");
            Console.Write((int)jsonValue["c"] + " ");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("    [JsonArrayMethods]");
            jsonValue = new Json.Value.Array();
            jsonValue.Add("abc");
            jsonValue.Add(true);
            jsonValue.Add(123);
            jsonValue.Add(456);
            Console.WriteLine(jsonValue);
            jsonValue.Remove(2);
            jsonValue.Insert(0, "def");
            Console.WriteLine(jsonValue);
            Console.WriteLine(jsonValue.Count);
            Console.WriteLine((string)jsonValue[1]);
            Console.WriteLine();


            Console.WriteLine("    [JsonObjectMethods]");
            jsonValue = new Json.Value.Object();
            jsonValue.Add("a", 123);
            jsonValue.Add("b", 456);
            jsonValue.Add("c", 789);
            Console.WriteLine(jsonValue);
            jsonValue.Remove("b");
            Console.WriteLine(jsonValue);
            Console.WriteLine(jsonValue.Count);
            Console.WriteLine(jsonValue.Contains("a"));
            Console.WriteLine((double)jsonValue["a"]);
            Console.WriteLine();

            jsonValue = null;

            if (!File.Exists("Test.json"))
            {
                Console.Write("    ([Test.json] not found, press Enter to quit)");
                Console.ReadLine();
                return;
            }

            using (FileStream stream = new FileStream("Test.json", FileMode.Open))
            {
                Console.WriteLine("File Size: {0} MB", (double)stream.Length / 1024 / 1024);
                Console.WriteLine();
                Stopwatch stopwatch = new Stopwatch();
                while (true)
                {
                    stream.Position = 0;

                    // Parse
                    Console.Write("    (Ready, press Enter to parse)");
                    Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("    [Parse]");
                    stopwatch.Reset();
                    stopwatch.Start();
                    Json.Value value = Json.Parser.Parse(stream);
                    stopwatch.Stop();
                    Console.Write("Elapsed time: {0} ms", stopwatch.ElapsedMilliseconds);

                    // Generate
                    Console.Write("    (Ready, press Enter to generate)");
                    Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("    [Generate]");
                    stopwatch.Reset();
                    stopwatch.Start();
                    string json = value.ToString();
                    stopwatch.Stop();
                    Console.Write("Elapsed time: {0} ms", stopwatch.ElapsedMilliseconds);
                    json = null;
                    value = null;
                    GC.Collect();
                }
            }
        }
    }
}
