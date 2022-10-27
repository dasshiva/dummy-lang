#include "include/Insn.hpp"
#include "include/Read.hpp"
#include "include/Log.hpp"

#define ADD_SUFFIX(dig) (dig == 1) ? ADD_USS : (dig == 2) ? ADD_SUS :C(dig == 3) ? ADD_SS : (dig == 4) ? ADD_USUS : (dig == 5) ? ADD_RS : (dig == 6) ? ADD_SR : (dig == 7) ? ADD_RUS : ADD_USR;

void Insn::Prepare(std::ifstream& file) {
	ins = GetInsn(Read_U2(file));
	len = GetArgLen();
	dest = Read_U1(file);

}

Insn _internal_getsuffix() {
}

Insns Insn::GetInsn(u2 code) {
	if (code > 0xC8)
		LOG(fatal, "Illegal instruction %i", code);
	if (code < 0x08) {
		int l = code % 10;
		return (l == 0) ? ADD_USS : ADD_SUS;
	}
}



