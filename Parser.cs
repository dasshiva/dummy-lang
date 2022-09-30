using System;

namespace Lang {
	public class Parser {
	    private readonly Tokenizer src;
        private readonly Reader rd;
	    private bool inLabel;	
		public Parser(Tokenizer src) {
			this.src = src;
            rd = src.src;
		}

		public void Parse() {
			var read = src.ReadLine();
			for (int i = 0; i < read.Length; i++) {
				switch(read[i].Type) {
					case Tokens.K_FSTART:
					case Tokens.K_FEND:
					{
						if(read.Length < 2)
							Program.SyntaxError("Error: Funtion name expected!" , rd);
						if (read[i + 1].Type != Tokens.L_STRING)
							Program.SyntaxError("Error: Functiom name must be a string!", rd);
						ParseLine();
					}
                    break;
                    default: break;
				}
			}
		}

		// TODO : IMPLEMENT
        private void ParseLine() {
			var read = src.ReadLine();
            switch (read[0].Type) {
                case Tokens.INS_ADD: 
                {
                    if (read.Length != 4)
                        Program.SyntaxError("Instruction needs 3 args exactly", rd);
                    if (read[1].Type == Tokens.K_REG) {
                        string variant = DetermineVariant(read[2], read[3]);
                    } 
                }
                break;
            }
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

    public readonly record struct Insn (int insn, object[] args);

	public class ParserResult {
		private string? functionName;
		private Insn[] impl;
	}
}
