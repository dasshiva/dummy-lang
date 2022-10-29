#include "include/Insn.hpp"
#include "include/Read.hpp"
#include "include/Log.hpp"

#define SUFFIX(pre, dig) (dig == 1) ? USS_##pre : (dig == 2) ? SUS_##pre :(dig == 3) ? SS_##pre : (dig == 4) ? USUS_##pre : (dig == 5) ? RS_##pre : (dig == 6) ? SR_##pre : (dig == 7) ? RUS_##pre : (dig == 8) ? USR_##pre : 0;


void Insn::Prepare(std::ifstream& file) {
	ins = GetInsn(Read_U2(file));
	// len = GetArgLen();
	dest = Read_U1(file);

}

Insns Insn::GetInsn(u2 code) {
	Insns ret;
	if (code > 0xC8)
		LOG(fatal, "Illegal instruction %i", code);

	if (code < 0x08) 
		ret = SUFFIX(ADD, code % 10)
	else if (code > 0xA1 && code < 0xA9)
		ret = SUFFIX(SUB, code % 10)
	else if (code > 0xB1 && code < 0xB9)
		ret = SUFFIX(MUL, code % 10)
	else if (code > 0xC1)
		ret = SUFFIX(DIV, code % 10)
	else
		LOG(fatal, "Illegal instruction %i", code);
	if (ret == 0)
		LOG(fatal, "Illegal instruction %i", code);
	return ret;
}

Regs Insn::GetRegs(u1 code) {
	switch (code) {
		case 0xAA: return R1;
		case 0xAB: return R2;
		case 0xAC: return R3;
		case 0xAD: return R4;
		case 0xAE: return R5;
		case 0xAF: return R6;
		case 0xBA: return R7;
		case 0xBB: return R8;
		case 0xBC: return R9;
	}
}

