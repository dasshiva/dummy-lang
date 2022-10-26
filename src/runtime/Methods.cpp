#include "include/Methods.hpp"
#include "include/Insn.hpp"
#include "include/Types.hpp"
#include "include/Read.hpp"
#include "include/Log.hpp"

void Methods::Prepare() {    
	Name_Len = Read_U2(*file);
	for (int i = 0; i < Name_Len; i++) {
		Name.append(1, Read_U1(*file));
	}
	LOG(debug, "Reading Method %s", Name.c_str());
	insn_num = Read_U2(*file);
	Ins = new Insn*[insn_num];
	for (int i = 0; i < insn_num; i++) {
		Ins[i] = new Insn();
	}
}
