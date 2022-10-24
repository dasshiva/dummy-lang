#include <iostream>
#include <iomanip>
#include <fstream>
#include <cstdlib>

#include "include/Read.hpp"
#include "include/aixlog.hpp"
#include "include/File.hpp"

void Exit(const char* reason) {
	std::cout << reason;
	std::exit(-1);
}

int main(int argc, const char* argv[]) {
	if (argc < 2) 
		Exit("Need a filename!");
	std::ifstream in(argv[1], std::ios::binary);
	if (!in.good())
		Exit("Unable to read input file");
	AixLog::Log::init<AixLog::SinkCout>(AixLog::Severity::trace);
	File cf(&in);
	cf.Prepare();
}
