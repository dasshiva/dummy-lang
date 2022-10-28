using System;

namespace Lang {
  public readonly record struct Insn(int insn, object[] args);
  public readonly record struct ParserResult(string ? functionName, List < Insn > impl);

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
        switch (read[i].Type) {
        case Tokens.K_FSTART: {
          if (read.Length < 2) Program.SyntaxError("Error: Funtion name expected!", rd);

          if (read[i + 1].Type != Tokens.L_STRING) Program.SyntaxError("Error: Functiom name must be a string!", rd);
          string ? functionName = (string ? ) read[i + 1].Arg;
          return new ParserResult(functionName, ParseFunction());
        }
        case Tokens.F_EOF:
          return new ParserResult(null, new List < Insn > ());
        default:
          Program.SyntaxError("Only function declarations are allowed at the top-level!", rd);
          break;
        }
      }
      return new ParserResult(); // Unreachable but needed for compiler happiness
    }
    private List < Insn > ParseFunction() {
      List < Insn > ls = new List < Insn > ();
      TokenizerResult[] read;
      while ((read = src.ReadLine())[0].Type != Tokens.K_FEND) {
        switch (read[0].Type) {
        case Tokens.INS_ADD:
        case Tokens.INS_SUB:
        case Tokens.INS_MUL:
        case Tokens.INS_DIV: {
          if (read.Length != 4)
            Program.SyntaxError("Instruction needs 3 args exactly", rd);

          if (read[1].Type == Tokens.K_REG) {
            string variant = DetermineVariant(read[2], read[3]);
            string ins = read[0].Type.ToString().TrimStart("INS_".ToCharArray());
            #pragma warning disable CS8601, CS8602, CS8629
            var insCode = typeof (Insns).GetField(ins + variant)?.GetValue(null);
            if (insCode == null)
              Program.SyntaxError("Arguments for instruction are not in proper order", rd);
            ls.Add(new Insn((ushort) insCode, new object[] {
              read[1].Arg, read[2].Arg, read[3].Arg
            }));
            #pragma warning restore CS8601, CS8602, CS8629
          } else
            Program.SyntaxError("The first operand of any instruction must be a register", rd);
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

    private string GetTypeSuffix(TokenizerResult arg) => arg.Type
    switch {
      Tokens.L_INT => "S",
        Tokens.L_USINT => "US",
        Tokens.K_REG => "R",
        _ => "" // Unreachable but you get it
    };

    private string DetermineVariant(TokenizerResult arg1, TokenizerResult arg2) => "_" + GetTypeSuffix(arg1) + GetTypeSuffix(arg2);

  }

}
