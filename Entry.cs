using System;
using Lang;

namespace Lang {
	public class Program {
		public static void Exit(string cause) {
			Console.WriteLine(cause);
			Environment.Exit(1);
		}

		static void Main (string[] args) {
			if (args.Length < 1) 
				Exit("Need a filename!");
			Reader a = new Reader(args[0]);
			while(!a.End) {
				var str = a.ReadLine();
				if (str == null)
					break;
				Console.WriteLine(String.Join(',', str));
			}
		}
	}
}
