using System;

namespace Lang {
	public class Parser {
	        private readonly Tokenizer src;
	        // private bool inLabel;	
		public Parser(Tokenizer src) {
			this.src = src;
		}

		public void Parse() {
			var read = src.ReadLine();
			for (int i = 0; i < read.Length; i++) {
				switch(read[i].Type) {
					case Tokens.K_FSTART:
					case Tokens.K_FEND:
					{
						if(read.Length < 2)
							Program.Exit("Error: Funtion name expected!");
						if (read[i + 1].Type != Tokens.L_STRING)
							Program.Exit("Error: Functiom name must be a string!");
						ParseFunction((string?) read[i + 1].Arg);
					}
                    break;

				}
			}
		}

		public void ParseFunction(string? name) {
			var read = src.ReadLine();

		}

	}

	public class ParserResult {
		private string? functionName;
		// private 
	}
}
