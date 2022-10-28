using System;

namespace Lang {
  public enum Tokens {
    INS_ADD,
    INS_SUB,
    INS_MUL,
    INS_DIV,
    K_FSTART,
    K_FEND,
    K_REG,
    S_COMMA,
    S_SEMI_COL,
    L_INT,
    L_USINT,
    /*L_DECIMAL, */ L_STRING,
    F_EOF
  }

  public readonly record struct TokenizerResult(Tokens Type, object ? Arg);

  public class Tokenizer {
    public Reader src {
      get;
      set;
    }

    public Tokenizer(Reader src) {
      this.src = src;
    }

    private TokenizerResult Check(string word) => word
    switch {
        "add" => new TokenizerResult(Tokens.INS_ADD, null),
        "sub" => new TokenizerResult(Tokens.INS_SUB, null),
        "mul" => new TokenizerResult(Tokens.INS_MUL, null),
        "div" => new TokenizerResult(Tokens.INS_DIV, null),
        "function" => new TokenizerResult(Tokens.K_FSTART, null),
        "end" => new TokenizerResult(Tokens.K_FEND, null),
        "," => new TokenizerResult(Tokens.S_COMMA, null),
        ";" => new TokenizerResult(Tokens.S_SEMI_COL, null),
        _ => DealRest(word)

    };

    private TokenizerResult DealRest(string word) {
      long inum;
      //double dnum;
      UInt64 unum;
      if (Int64.TryParse(word, out inum))
        return new TokenizerResult(Tokens.L_INT, inum);
      /* else if (Double.TryParse(word, out dnum))
      	return new TokenizerResult(Tokens.L_DECIMAL, dnum); */
      else if (word[word.Length - 1] == 'U') {
        if (UInt64.TryParse(word.Substring(0, word.Length - 2), out unum))
          return new TokenizerResult(Tokens.L_USINT, unum);
      } else if (word[0] == 'r') {
        if (Byte.TryParse(word.Substring(1), out byte reg)) {
          if (reg < 1 || reg > 12)
            Program.SyntaxError($"Register {reg} is invalid", src);
          return new TokenizerResult(Tokens.K_REG, (byte ? ) reg);
        }
      }
      return new TokenizerResult(Tokens.L_STRING, word);
    }

    public TokenizerResult[] ReadLine() {
      var line = src.ReadLine();
      if (line == null)
        return new TokenizerResult[] {
          new TokenizerResult(Tokens.F_EOF, null)
        };
      var ret = new TokenizerResult[line.Length];
      for (int i = 0; i < line.Length; i++) {
        ret[i] = Check(line[i]);
      }
      return ret;
    }
  }
}
