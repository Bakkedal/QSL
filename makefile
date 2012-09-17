CSC = mcs
ILRUN = mono

default: lib
lib: gsls.dll

srcdir = src
files = \
	$(srcdir)/complex.cs\
	$(srcdir)/vector.cs\
	$(srcdir)/matrix.cs\

gsls.dll : $(files)
	$(CSC) $< -target:library -out:gsls.dll

clean: clean-lib clean-test

clean-lib:
	rm -f gsls.dll

clean-test:
	rm -f test.exe

test: test.exe
	$(ILRUN) $<

test.exe: test.cs gsls.dll
	$(CSC) $< -target:exe -out:$@ -reference:gsls.dll
