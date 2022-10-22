#ifndef _FILE_HPP_
#define _FILE_HPP

#include "Types.hpp"
#include "Methods.hpp"

public class File {
	public:
		u8 Magic;
		u2 Major;
		u2 Minor;
		Methods* Mt;

}

#endif
