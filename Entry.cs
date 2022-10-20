﻿using System;
using Lang;

namespace Lang {
	public class Program {
		public static void Exit(string cause) {
			Console.WriteLine(cause);
			Environment.Exit(1);
		}

		public static void SyntaxError(string cause, Reader src) => Exit($"Syntax error (at line {src.LineNo}) : {cause}");

		static void Main (string[] args) {
			if (args.Length < 1) 
				Exit("Need a filename!");
			Parser a = new Parser(new Tokenizer(new Reader(args[0])));
			Codegen cs = new Codegen("a.out");
			while (true) {
				var res = a.Parse();
				if (res.functionName == null)
					break;
				Console.WriteLine("Written");
				cs.Write(res);
			}
		}
	}
}
