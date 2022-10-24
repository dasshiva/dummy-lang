#include "include/Methods.hpp"
#include "include/Types.hpp"
#include "include/Read.hpp"

void Methods::Prepare() {    
	Name_Len = Read_U4(*file);
}
