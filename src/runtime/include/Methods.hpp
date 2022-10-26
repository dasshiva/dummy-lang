#ifndef _METHODS_HPP_
#define _METHODS_HPP_

#include <string>
#include "Types.hpp"
#include "Insn.hpp"
#include <fstream>

class Methods {
	public:
		u2 Name_Len;
		std::string Name;
		Insn** Ins;

		Methods(std::ifstream* src) {
			file = src;
		}
		void Prepare();

	private:
		std::ifstream* file;
		u2 insn_num;

};

#endif
