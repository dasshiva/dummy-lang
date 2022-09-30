using System;

namespace Lang {
	public readonly record struct Insn (int insn, object[] args);
	public readonly record struct ParserResult(string? functionName, List<Insn> impl); 

	public class Parser {
	    private readonly Tokenizer src;
        private readonly Reader rd;
		public Parser(Tokenizer src) {
			this.src = src;
            rd = src.src;
		}

		public ParserResult Parse() {
			var read = src.ReadLine();
			for (int i = 0; i < read.Length; i++) {
				switch(read[i].Type) {
					case Tokens.K_FSTART:
					{
						if(read.Length < 2)
							Program.SyntaxError("Error: Funtion name expected!" , rd);
						if (read[i + 1].Type != Tokens.L_STRING)
							Program.SyntaxError("Error: Functiom name must be a string!", rd);
						string? functionName = (string?) read[i + 1].Arg;
						return new ParserResult(functionName, ParseFunction());
					}
					case Tokens.F_EOF: 
					return new ParserResult(null, new List<Insn>());

                    default: 
					Program.SyntaxError("Only function declarations are allowed at the top-level!", rd);
					break;
				}
			}

			return new ParserResult(); // Unreachable but needed for compiler happiness
		}

        private List<Insn> ParseFunction() {
			List<Insn> ls = new List<Insn>();
			TokenizerResult[] read;
			while ((read = src.ReadLine())[0].Type != Tokens.K_FEND) {
				switch (read[0].Type) {
					case Tokens.INS_ADD: 
					case Tokens.INS_SUB:
					case Tokens.INS_MUL:
					case Tokens.INS_DIV:
					{
						if (read.Length != 4)
						    Program.SyntaxError("Instruction needs 3 args exactly", rd);
						if (read[1].Type == Tokens.K_REG) {
							string variant = DetermineVariant(read[2], read[3]);
							string ins = read[0].ToString();
#pragma warning disable CS8601, CS8602, CS8629
                            int? insCode = (int?) typeof(Insns).GetField(ins + variant).GetValue(null);
							ls.Add(new Insn((int) insCode, new object[] { read[1].Arg , read[2].Arg, read[3].Arg }));
#pragma warning restore CS8601, CS8602, CS8629
						}
                    }
					break;

					case Tokens.F_EOF:
					Program.SyntaxError("Unexpected end of file while parsing", rd);
					break;

					default:
					Program.SyntaxError("Expected instruction here but got an unexpected token", rd);
					break; 
                }
            }
			return ls;
	}

        private string DetermineVariant(TokenizerResult arg1, TokenizerResult arg2) {
            if (arg1.Type == Tokens.L_INT && arg2.Type == Tokens.L_INT)
		    return "_SS";
	    
	    if (arg1.Type == Tokens.L_USINT && arg2.Type == Tokens.L_USINT)
		    return "_USUS";
	    
	    if (arg1.Type == Tokens.L_INT && arg2.Type == Tokens.L_USINT)
		    return "_SUS";
	    
	    if (arg1.Type == Tokens.L_USINT && arg2.Type == Tokens.L_INT)
		    return "_USS";
	    return ""; // Unreachable but neccesary for compiler happiness
            
        }

	}

}
