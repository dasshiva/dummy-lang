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
        ADD_SUS = 0X02,
        ADD_SS = 0X03,
        ADD_USUS = 0x04,

        /* Variants of the sub instruction */
        SUB_USS = 0x05,
        SUB_SUS = 0X06,
        SUB_SS = 0X07,
        SUB_USUS = 0x08,

        /* Variants of the mul instruction */
        MUL_USS = 0x09,
        MUL_SUS = 0X0A,
        MUL_SS = 0X0B,
        MUL_USUS = 0x0C,

        /* Variants of the div instruction */
        DIV_USS = 0x0D,
        DIV_SUS = 0X0E,
        DIV_SS = 0X0F,
        DIV_USUS = 0x11

    }
}