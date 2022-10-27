#ifndef _FILE_HPP_
#define _FILE_HPP

#include "Types.hpp"
#include "Methods.hpp"
#include <fstream>

class File {
	public:
		u8 Magic;
		u2 Major;
		u2 Minor;
		u2 Methods_Len;
		Methods* Mt;
		void Prepare(std::ifstream& file);

};

#endif
