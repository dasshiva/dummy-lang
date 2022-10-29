#include "include/Read.hpp"
#include <arpa/inet.h>

u1 Read_U1(std::ifstream& src) {
	u1 res;
	src.read((char*) &res, sizeof(u1));
	return res;
}

u2 Read_U2(std::ifstream& src) {
	u2 res;
	src.read((char*) &res, sizeof(u2));
	return res;
}

u4 Read_U4(std::ifstream& src) {
	u4 res;
	src.read((char*) &res, sizeof(u4));
	return res;
}

u8 Read_U8(std::ifstream& src) {
	u8 res;
	src.read((char*) &res, sizeof(u8));
	return res;
}
