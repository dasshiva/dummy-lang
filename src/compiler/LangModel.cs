using System;

namespace Lang {

  /* The prefixes of the instructions indicate the type of their arguments and their order:
  USS - (Immediate) Unsigned int and int
  SUS - (Immediate) Signed int and unsigned int
  SS - (Immediate) Two signed ints
  USUS - (Immediate) Two unsigned ints
  RS - Register and immediate int
  SR - Immediate int and register
  RUS - Register and immediate unsigned int
  USR - Immediate unsigned int and register
  */

  public enum Insns: ushort {
    /* Variants of the add instruction */
    ADD_USS = 0x01,
      ADD_SUS = 0x02,
      ADD_SS = 0x03,
      ADD_USUS = 0x04,
      ADD_RS = 0x05,
      ADD_SR = 0x06,
      ADD_RUS = 0x07,
      ADD_USR = 0x08,

      /* Variants of the sub instruction */
      SUB_USS = 0xA1,
      SUB_SUS = 0xA2,
      SUB_SS = 0xA3,
      SUB_USUS = 0xA4,
      SUB_RS = 0xA5,
      SUB_SR = 0xA6,
      SUB_RUS = 0xA7,
      SUB_USR = 0xA8,

      /* Variants of the mul instruction */
      MUL_USS = 0xB1,
      MUL_SUS = 0xB2,
      MUL_SS = 0xB3,
      MUL_USUS = 0xB4,
      MUL_RS = 0xB5,
      MUL_SR = 0xB6,
      MUL_RUS = 0xB7,
      MUL_USR = 0xB8,

      /* Variants of the div instruction */
      DIV_USS = 0xC1,
      DIV_SUS = 0xC2,
      DIV_SS = 0xC3,
      DIV_USUS = 0xC4,
      DIV_RS = 0xC5,
      DIV_SR = 0xC6,
      DIV_RUS = 0xC7,
      DIV_USR = 0xC8
  }

  public enum Registers: byte {
    R1 = 0xAA, R2 = 0xAB, R3 = 0xAC, R4 = 0xAD, R5 = 0xAE, R6 = 0xAF,
      R7 = 0xBA, R8 = 0xBB, R9 = 0xBC, R10 = 0xBD, R11 = 0xBE, R12 = 0XBF
  }

  public enum FileConstants: ulong {
    MAGIC = 0x4D41474943, /* String "MAGIC" */
      MINOR_VERSION = 0x1,
      MAJOR_VERSION = 0x0
  }
}