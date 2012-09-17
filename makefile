CSC = mcs
ILRUN = mono
GSL = gsl.dll

default: help

lib: $(GSL)
help:
	@echo '"make lib" builds the library, $(GSL)'
	@echo '"make test" runs tests'

srcdir = src
files = \
	$(srcdir)/complex.cs\
	$(srcdir)/vector.cs\
	$(srcdir)/matrix.cs\

$(GSL) : $(files)
	$(CSC) $< -target:library -out:$@

clean: clean-lib clean-test

clean-lib:
	rm -f $(GSL)

clean-test:
	rm -f test.exe

test: test.exe
	$(ILRUN) $<

test.exe: test.cs $(GSL)
	$(CSC) $< -target:exe -out:$@ -reference:$(GSL)
