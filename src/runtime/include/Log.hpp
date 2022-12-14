// This file implements a very simple logger which 
// dumps all the information to std::cout 

#include <iostream>
#include <iomanip>
#include <string>
#include <cstdarg>
#include <cstring>
#include "Types.hpp"

#define LOG(Severity, Message, ...) \
	Log(Severity, __LINE__, __FILE__, __func__, Message, __VA_ARGS__);

enum {
	debug = 1,
	info  = 2,
	fatal = 3
};

static auto to_String(int i) {
	switch(i) {
		case debug: return (const char*) "DEBUG";
		case info:  return (const char*) "INFO";
		case fatal: return (const char*) "FATAL";
		default: return (const char*) "";
	}
}

static void Log(int s, int line, const char* file, const char* name, const char* msg, ...) {
	std::string str;
	std::va_list ap;
	va_start(ap, msg);
	char buf[100];
	strcpy(buf, msg);
	char *a = buf , *c;
	int i;
	while (*a) {
		if(*a != '%')
			str.append(1, *a);
		else {
			switch (*(++a)) {
				case 'i': 
					i = va_arg(ap, int);
					str.append(std::to_string(i));
					break;

				case 's':
					c = va_arg(ap, char*);
					str.append(c);
					break;
					
				default: // silently ignore
					continue;
			}
		}
		++a;
	}

	std::cout << '[' << to_String(s) << "] " << file << ':' << line << " (" << name << ") : " << str << std::endl ;
}
