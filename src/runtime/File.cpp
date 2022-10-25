#include "include/File.hpp"
#include "include/Read.hpp"
#include "include/main.hpp"
#include "include/Methods.hpp"
#include "include/Log.hpp"

#define MAGIC 0x4D41474943UL
#define MAJOR_VERSION 0x0 
#define MINOR_VERSION 0x1

void File::Prepare() {
	Magic = Read_U8(*file);
	if (Magic != MAGIC)
		LOG(fatal, "Invalid magic number for file:  %i", Magic);
	LOG(debug, "Validated Magic number (Expected = %i, Got= %i)", MAGIC, Magic);

	Major = Read_U2(*file);
	if (Major != MAJOR_VERSION)
		LOG(fatal, "This VM does not support major version: %i", Major);

	Minor = Read_U2(*file);
	if (Minor != MINOR_VERSION)
		LOG(fatal, "This VM does not support this minor version: %i", Minor);
	
	LOG(debug,"Running file version %i.%i", MAJOR_VERSION, MINOR_VERSION);
	Methods_Len = Read_U2(*file);
	LOG(debug, "File has %i method(s)", Methods_Len);
	Mt = new Methods(file);
	Mt->Prepare();
}
