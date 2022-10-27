#ifndef _INSN_HPP_
#define _INSN_HPP_

#include "Types.hpp"
#include <fstream>

/* To understand what the suffixes mean, check 
 * src/compiler/LangModel.cs */

enum Insns {
	ADD_USS = 0x01,
	ADD_SUS = 0x02,
  	ADD_SS = 0x03,                                           
      	ADD_USUS = 0x04,
  	ADD_RS = 0x05,
    	ADD_SR = 0x06,
  	ADD_RUS = 0x07,
  	ADD_USR = 0x08,

  	SUB_USS = 0xA1,
  	SUB_SUS = 0xA2,
  	SUB_SS = 0xA3,
  	SUB_USUS = 0xA4,
  	SUB_RS = 0xA5,
  	SUB_SR = 0xA6,
  	SUB_RUS = 0xA7,
  	SUB_USR = 0xA8,

  	MUL_USS = 0xB1,
  	MUL_SUS = 0xB2,
  	MUL_SS = 0xB3,
  	MUL_USUS = 0xB4,
  	MUL_RS = 0xB5,
  	MUL_SR = 0xB6,
  	MUL_RUS = 0xB7,
  	MUL_USR = 0xB8,

	DIV_USS = 0xC1,
	DIV_SUS = 0xC2,
  	DIV_SS = 0xC3,
    	DIV_USUS = 0xC4,                                 
	DIV_RS = 0xC5,
  	DIV_SR = 0xC6,                                
	DIV_RUS = 0xC7,                                
	DIV_USR = 0xC8
};

union Arg {
	i8 IArg;
	u8 UArg;
};

class Insn {
	public:
		Insns ins;
		u1 len;
		u1 dest;
		union Arg** args;

		void Prepare(std::ifstream& f);
	
	private:
		Insns GetInsn(u2 code);
		u1 GetArgLen();
};

#endif
