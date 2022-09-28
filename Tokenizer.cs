using System;

namespace Lang {
	public enum Tokens {
		INS_ADD, INS_SUB, INS_MUL, INS_DIV,
		K_FSTART, K_FEND,
		S_COMMA, S_SEMI_COL,
		L_INT, L_SINT, L_DECIMAL, L_STRING,
		F_EOF
	}

	public readonly record struct TokenizerResult (Tokens Type, object? Arg);

	public class Tokenizer {
		public Reader src { get; set; }
		private TokenizerResult Check(string word) => word switch {
			"add" => new TokenizerResult(Tokens.INS_ADD, null),
			"sub" => new TokenizerResult(Tokens.INS_SUB, null),
			"mul" => new TokenizerResult(Tokens.INS_MUL, null),
			"div" => new TokenizerResult(Tokens.INS_DIV, null),
			"function" => new TokenizerResult(Tokens.FSTART, null),
			"," => new TokenizerResult(Tokens.S_COMMA, null),
			";" => new TokenizerResult(Tokens.S_SEMI_COL, null),
			_ => DealRest(word)

		};

		private TokenizerResult DealRest(string word) {
			long inum;
			double dnum;
			UInt64 unum;
			if (Int64.TryParse(word, out inum))
				return new TokenizerResult(Tokens.L_INT, inum);
			else if (Double.TryParse(word, out dnum))
				return new TokenizerResult(Tokens.L_DECIMAL, dnum);
			else if (word[word.Length - 1] == 'U') {
				if(UInt64.TryParse(word.SubString(0, word.Length - 2), out unum))
					return new TokenizerResult(Tokens.L_SINT, unum);
			}
			return new TokenizerResult(Tokens.L_STRING, word);
		}

		public TokenizerResult[] ReadLine() {
			var line = src.ReadLine();
			if (line == null)
				return new TokenizerResult[] {new TokenizerResult(Tokens.F_EOF, null)};
		        var ret = new TokenizerResult[line.Length];
		        for (int i = 0; i < line.Length; i++) {
				ret[i] = Check(line[i]);
			}
		        return ret;	
		}
	}
}
