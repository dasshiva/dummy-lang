using System;

namespace Lang {
  public static class EnumExtensions {
    public static string GetString(this Tokens tk) => tk
    switch {
      Tokens.INS_ADD => "Instruction Add",
        Tokens.INS_SUB => "Instruction Sub",
        Tokens.INS_MUL => "Instruction Mul",
        Tokens.INS_DIV => "Instruction Div",
        Tokens.K_REG => "Register",
        Tokens.K_FSTART => "Function def",
        Tokens.K_FEND => "Function def end",
        Tokens.L_INT => "Signed int",
        Tokens.L_USINT => "Unsigned int",
        Tokens.L_STRING => "String",
        Tokens.F_EOF => "End of file",
        _ => ""
    };

  }
}