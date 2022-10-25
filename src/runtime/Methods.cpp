#include "include/Methods.hpp"
#include "include/Types.hpp"
#include "include/Read.hpp"
#include "include/Log.hpp"

void Methods::Prepare() {    
	Name_Len = Read_U2(*file);
	for (int i = 0; i < Name_Len; i++) {
		Name.append(1, Read_U1(*file));
	}
	LOG(debug, "Reading Method %s", Name.c_str());
}
