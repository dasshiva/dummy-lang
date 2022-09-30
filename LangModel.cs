using System;

namespace Lang {

    /* The prefixes of the instructions indicate the type of their arguments and their order:
    USS - Unsigned int and int
    SUS - Signed int and unsigned int
    SS - Two signed ints
    USUS - Two unsigned ints
    */

    public enum Insns { 
        /* Variants of the add instruction */
        ADD_USS = 0x01,
        ADD_SUS = 0x02,
        ADD_SS = 0x03,
        ADD_USUS = 0x04,

        /* Variants of the sub instruction */
        SUB_USS = 0x05,
        SUB_SUS = 0x06,
        SUB_SS = 0x07,
        SUB_USUS = 0x08,

        /* Variants of the mul instruction */
        MUL_USS = 0x09,
        MUL_SUS = 0x0A,
        MUL_SS = 0x0B,
        MUL_USUS = 0x0C,

        /* Variants of the div instruction */
        DIV_USS = 0x0D,
        DIV_SUS = 0x0E,
        DIV_SS = 0x0F,
        DIV_USUS = 0x11

    }

    enum Registers {
        R1 = 0xAA, R2 = 0xAB, R3 = 0xAC, R4 = 0xAD, R5 = 0xAE, R6 = 0xAF,
        R7 = 0xBA, R8 = 0xBB, R9 = 0xBC, R10 = 0xBD, R11 = 0xBE, R12 = 0XBF
    }
}