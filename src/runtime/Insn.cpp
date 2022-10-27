#include "include/Insn.hpp"
#include "include/Read.hpp"

void Insn::Prepare(std::ifstream& file) {
	ins = GetIns(Read_U2(file));
	len = GegArgLen();
	dest = Read_U1(file);

}

Ins Insn::GetIns(u2 code) {
	if (code > 0xC8)
		LOG(fatal, "Illegal instruction %i", code);
	if (code < 0x08) {
		switch(code) {
			case 0x00: return Ins::ADD_USS;
			case 0x01: return Ins::ADD_SUS;
			case 0x02: return Ins::ADD_SS;
			case 0x03: return Ins::ADD_USUS;
		}
	}
}



