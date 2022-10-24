#ifndef _METHODS_HPP_
#define _METHODS_HPP_

#include <string>
#include "Types.hpp"
#include "Insn.hpp"
#include <fstream>

class Methods {
	public:
		u4 Name_Len;
		std::string Name;
		Insn* Ins;

<<<<<<< HEAD
		Methods(int ins_num) :  num(ins_num) {}
=======
		Methods(std::ifstream* src) {
			file = src;
		}
>>>>>>> 4e3a4b960070c1f3806af437dd7a8b03c0013b46
		void Prepare();

	private:
		std::ifstream* file;

};

#endif
