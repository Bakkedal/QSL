CSC = mcs
ILRUN = mono
QSL = qsl.dll

default: help

lib: $(QSL)
help:
	@echo '"make lib" builds the library, $(QSL)'
	@echo '"make test" runs tests'

srcdir = src
files = \
	$(srcdir)/complex.cs\
	$(srcdir)/vector.cs\
	$(srcdir)/matrix.cs\

$(QSL) : $(files)
	$(CSC) $< -target:library -out:$@

clean: clean-lib clean-test

clean-lib:
	rm -f $(QSL)

clean-test:
	rm -f test.exe

test: test.exe
	$(ILRUN) $<

test.exe: test.cs $(QSL)
	$(CSC) $< -target:exe -out:$@ -reference:$(QSL)
