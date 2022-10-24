#include "include/File.hpp"
#include "include/Read.hpp"
#include "include/main.hpp"
#include "include/Methods.hpp"
#include "include/aixlog.hpp"

#define MAGIC 0x4D41474349UL
#define MAJOR_VERSION 0x0 
#define MINOR_VERSION 0x1

void File::Prepare() {
	Magic = Read_U8(*file);
	if (Magic != MAGIC)
		Exit("Invalid Magic Number for file");
	LOG(DEBUG) << "Magic number: " << Magic;

	Major = Read_U2(*file);
	if (Minor != MAJOR_VERSION)
		Exit("This VM does not support this major version");

	Minor = Read_U2(*file);
	if (Minor != MINOR_VERSION)
		Exit("This VM does not support this minor version");
	Methods_Len = Read_U2(*file);
	Mt = new Methods(file);
	Mt->Prepare();
}
