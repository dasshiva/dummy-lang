#ifndef _METHODS_HPP_
#define _METHODS_HPP_

#include <string>
#include "Types.hpp"
#include "Insn.hpp"

public class Methods {
	public:
		u4 Name_Len;
		std::string Name;
		Insn* Ins;

		Methods(int met_num) :  num(met_num) {}
		void Prepare();

	private:
		int num;

}

#endif
