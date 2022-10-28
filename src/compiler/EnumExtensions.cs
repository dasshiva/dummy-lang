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

    public static int GetIndex(this Registers rs) => rs
    switch {
      Registers.R1 => 0,
        Registers.R2 => 1,
	Registers.R3 => 2,
	Registers.R4 => 3,
	Registers.R5 => 4,
	Registers.R6 => 5,
	Registers.R7 => 6,
	Registers.R8 => 7,
	Registers.R9 => 8,
	Registers.R10 => 9,
	Registers.R11 => 10,
	Registers.R12 => 11,
	_ => -1
    };
  }
}
