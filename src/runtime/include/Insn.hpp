#ifndef _INSN_HPP_
#define _INSN_HPP_

#include "Types.hpp"
#include <fstream>

/* To understand what the suffixes mean, check 
 * src/compiler/LangModel.cs */

enum Insns {
	USS_ADD = 0x01,
	SUS_ADD = 0x02,
  	SS_ADD = 0x03,
	USUS_ADD = 0x04,
  	RS_ADD = 0x05,
    	SR_ADD = 0x06,
  	RUS_ADD = 0x07,
  	USR_ADD = 0x08,

  	USS_SUB = 0xA1,
  	SUS_SUB = 0xA2,
  	SS_SUB = 0xA3,
  	USUS_SUB = 0xA4,
  	RS_SUB = 0xA5,
  	SR_SUB = 0xA6,
  	RUS_SUB = 0xA7,
  	USR_SUB = 0xA8,

  	USS_MUL = 0xB1,
  	SUS_MUL = 0xB2,
  	SS_MUL = 0xB3,
  	USUS_MUL = 0xB4,
  	RS_MUL = 0xB5,
  	SR_MUL = 0xB6,
  	RUS_MUL = 0xB7,
  	USR_MUL = 0xB8,

	USS_DIV = 0xC1,
	SUS_DIV = 0xC2,
  	SS_DIV = 0xC3,
    	USUS_DIV = 0xC4,                                 
	RS_DIV = 0xC5,
  	SR_DIV = 0xC6,                                
	RUS_DIV = 0xC7,                                
	USR_DIV = 0xC8
};

enum Regs {
      	R1 = 0xAA, 
	R2 = 0xAB, 
	R3 = 0xAC, 
	R4 = 0xAD, 
	R5 = 0xAE, 
	R6 = 0xAF,
	R7 = 0xBA, 
	R8 = 0xBB, 
	R9 = 0xBC, 
	R10 = 0xBD, 
	R11 = 0xBE, 
	R12 = 0XBF
};

union Arg {
	i8 IArg;
	u8 UArg;
};

class Insn {
	public:
		Insns ins;
		u1 len;
		Regs dest;
		union Arg** args;

		void Prepare(std::ifstream& f);
	
	private:
		Insns GetInsn(u2 code);
		Regs GetReg(u1 reg);
		u1 GetArgLen();
};

#endif
