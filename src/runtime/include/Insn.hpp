#ifndef _INSN_HPP_
#define _INSN_HPP_

#include "Types.hpp"

union Arg {
	i64 IArg;
	u64 UArg;
}

public class Insn {
	public:
		u2 Code;
		u1 Dest;
		union* Args;
}

#endif
