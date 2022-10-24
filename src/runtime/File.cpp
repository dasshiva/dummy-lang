#include "include/File.hpp"
#include "include/Read.hpp"
#include "include/main.hpp"
#include "include/Methods.hpp"
#include "include/aixlog.hpp"

#define MAGIC 0x4D41474943UL
#define MAJOR_VERSION 0x0 
#define MINOR_VERSION 0x1

void File::Prepare() {
	Magic = Read_U8(*file);
	if (Magic != MAGIC)
		LOG(FATAL, "File::Prepare") << "Invalid magic number for file: " << Magic;
	LOG(DEBUG, "File::Prepare") << "Validated Magic number";

	Major = Read_U2(*file);
	if (Major != MAJOR_VERSION)
		LOG(FATAL, "File::Prepare") << "This VM does not support this major version";

	Minor = Read_U2(*file);
	if (Minor != MINOR_VERSION)
		LOG(FATAL, "File::Prepare") << "This VM does not support this minor version";
	
	LOG(DEBUG, "File::Prepare") << "Running file version " << MAJOR_VERSION << "." << MINOR_VERSION;
	Methods_Len = Read_U2(*file);
	LOG(DEBUG, "File::Prepare") << "File has " << Methods_Len << " method(s)";
	Mt = new Methods(file);
	Mt->Prepare();
}
