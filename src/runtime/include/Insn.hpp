#ifndef _INSN_HPP_
#define _INSN_HPP_

#include "Types.hpp"

union Arg {
	i64 IArg;
	u8 UArg;
};

class Insn {
	public:
		u2 Code;
		u1 Dest;
		union Arg* Args;
};

#endif
