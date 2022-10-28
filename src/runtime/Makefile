objs = $(addprefix obj/, main.o Insn.o Read.o File.o Methods.o)

all: $(objs) | dir
	g++ -o runtime $^

$(objs): obj/%.o: %.cpp | dir
	g++ -c -o $@ $<

clean: 
	rm *.o

dir: 
	mkdir -p obj/
