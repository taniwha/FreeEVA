KSPDIR		:= ${HOME}/ksp/KSP_linux
MANAGED		:= ${KSPDIR}/KSP_Data/Managed
GAMEDATA	:= ${KSPDIR}/GameData
FrEVAGAMEDATA  := ${GAMEDATA}/FreeEVA
PLUGINDIR	:= ${FrEVAGAMEDATA}/Plugins

TARGETS		:= FreeEVA.dll

FrEVA_FILES := \
    AssemblyInfo.cs	\
	Checkers.cs \
	FreeEVA.cs \
	Toolbar.cs \
	ToolbarWrapper.cs \
	VersionReport.cs \
	$e

DOC_FILES := \
	FreeEVA.png \
	License.txt \
	README.md

RESGEN2		:= resgen2
GMCS		:= mcs
GMCSFLAGS	:= -optimize -warnaserror
GIT			:= git
TAR			:= tar
ZIP			:= zip

all: version ${TARGETS} FreeEVA.png

.PHONY: version
version:
	@./git-version.sh

info:
	@echo "FreeEVA Build Information"
	@echo "    resgen2:    ${RESGEN2}"
	@echo "    gmcs:       ${GMCS}"
	@echo "    gmcs flags: ${GMCSFLAGS}"
	@echo "    git:        ${GIT}"
	@echo "    tar:        ${TAR}"
	@echo "    zip:        ${ZIP}"
	@echo "    KSP Data:   ${KSPDIR}"

FreeEVA.dll: ${FrEVA_FILES}
	${GMCS} ${GMCSFLAGS} -t:library -lib:${MANAGED} \
		-r:Assembly-CSharp,Assembly-CSharp-firstpass \
		-r:UnityEngine \
		-r:KSPUtil \
		-out:$@ $^

FreeEVA.png: FreeEVA.svg
	inkscape --export-png $@ $^

clean:
	rm -f ${TARGETS} AssemblyInfo.cs FreeEVA.png

install: all
	mkdir -p ${PLUGINDIR}
	cp ${TARGETS} ${PLUGINDIR}
	cp ${DOC_FILES} ${FrEVAGAMEDATA}

.PHONY: all clean install
