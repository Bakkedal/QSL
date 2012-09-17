CSC = mcs
ILRUN = mono

default: lib
lib: gsls.dll

srcdir = src
files = $(srcdir)/complex.cs

gsls.dll : $(files)
	$(CSC) $(files) -target:library -out:gsls.dll

clean: clean-lib

clean-lib:
	rm -f gsls.dll

test: test.exe
	$(ILRUN) test.exe

test.exe: test.cs gsls.dll
	$(CSC) $< -target:exe -out:$@ -reference:gsls.dll
