// dllmain.cpp: DLL 응용 프로그램의 진입점을 정의합니다.
#include "stdafx.h"
#include <cstdio>
#include <rpcndr.h>
#include "SRSCC.h"


HINSTANCE	hInstance;
FILE		*logFile = NULL;
CHAR		*gpSccName = "PBSCC Proxy";

HWND		consoleHwnd = NULL;


void log(const char* szFmt, ...) {
	if (logFile) {
		va_list args;
		va_start(args, szFmt);
		vfprintf(logFile, szFmt, args);
		fflush(logFile);
		va_end(args);
	}
}


BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
					 )
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}



SCCEXTERNC SCCRTN EXTFUN SccInitialize(LPVOID * ppContext, HWND hWnd, LPCSTR lpCallerName, LPSTR lpSccName, LPLONG lpSccCaps, LPSTR lpAuxPathLabel, LPLONG pnCheckoutCommentLen, LPLONG pnCommentLen) {
	log("SccInitialize:\n");

	return SCC_OK;
}

SCCEXTERNC SCCRTN EXTFUN SccUninitialize(LPVOID pContext) {
	log("SccUninitialize:\n");
	return SCC_OK;
}


SCCEXTERNC SCCRTN EXTFUN SccGetProjPath(LPVOID pContext, HWND hWnd, LPSTR lpUser, LPSTR lpProjName, LPSTR lpLocalPath, LPSTR lpAuxProjPath, BOOL bAllowChangePath, LPBOOL pbNew) {
	log("SccGetProjPath:\n");
	return SCC_OK;
}



SCCEXTERNC SCCRTN EXTFUN SccOpenProject(LPVOID pContext, HWND hWnd, LPSTR lpUser, LPSTR lpProjName, LPCSTR lpLocalProjPath, LPSTR lpAuxProjPath, LPCSTR lpComment, LPTEXTOUTPROC lpTextOutProc, LONG dwFlags) {
	log("SccOpenProject:\n");
	return SCC_OK;
}


SCCEXTERNC SCCRTN EXTFUN SccGetCommandOptions(LPVOID pContext, HWND hWnd, enum SCCCOMMAND nCommand, LPCMDOPTS * ppvOptions) {
	log("SccGetCommandOptions:\n");
	if (nCommand == SCC_COMMAND_OPTIONS)return SCC_OK;//SCC_I_ADV_SUPPORT; //no advanced button
	return SCC_E_OPNOTSUPPORTED;
}

SCCEXTERNC SCCRTN EXTFUN SccCloseProject(LPVOID pContext) {
	log("SccCloseProject:\n");
	THECONTEXT *ctx = (THECONTEXT *)pContext;
	return SCC_OK;
}

SCCEXTERNC SCCRTN EXTFUN SccGet(LPVOID pContext, HWND hWnd, LONG nFiles, LPCSTR* lpFileNames, LONG dwFlags, LPCMDOPTS pvOptions) {
	log("SccGet:\n");
	return SCC_OK;
}

//common function for SccQueryInfoEx and SccQueryInfo 
//the difference only in cbFunc and cbParm parameters
SCCRTN _SccQueryInfo(LPVOID pContext, LONG nFiles, LPCSTR* lpFileNames, LPLONG lpStatus, INFOEXCALLBACK cbFunc, LPVOID cbParm) {
	INFOEXCALLBACKPARM cbp;
	return SCC_OK;
}

SCCEXTERNC SCCRTN EXTFUN SccQueryInfoEx(LPVOID pContext, LONG nFiles, LPCSTR* lpFileNames, LPLONG lpStatus, INFOEXCALLBACK cbFunc, LPVOID cbParm) {
	log("SccQueryInfoEx:\n");
	return _SccQueryInfo(pContext, nFiles, lpFileNames, lpStatus, cbFunc, cbParm);
}

SCCEXTERNC SCCRTN EXTFUN SccQueryInfo(LPVOID pContext, LONG nFiles, LPCSTR* lpFileNames, LPLONG lpStatus) {
	log("SccQueryInfo:\n");
	return _SccQueryInfo(pContext, nFiles, lpFileNames, lpStatus, NULL, NULL);
}

SCCEXTERNC SCCRTN EXTFUN SccCheckout(LPVOID pContext, HWND hWnd, LONG nFiles, LPCSTR* lpFileNames, LPCSTR lpComment, LONG dwFlags, LPCMDOPTS pvOptions) {
	THECONTEXT *ctx = (THECONTEXT *)pContext;
	return SCC_OK;
}

SCCEXTERNC SCCRTN EXTFUN SccUncheckout(LPVOID pContext, HWND hWnd, LONG nFiles, LPCSTR* lpFileNames, LONG dwFlags, LPCMDOPTS pvOptions) {
	return SCC_OK;
}

SCCEXTERNC SCCRTN EXTFUN SccCheckin(LPVOID pContext, HWND hWnd, LONG nFiles, LPCSTR* lpFileNames, LPCSTR lpComment, LONG dwFlags, LPCMDOPTS pvOptions) {
	log("SccCheckin: \n");
	return SCC_OK;
}

SCCEXTERNC SCCRTN EXTFUN SccAdd(LPVOID pContext, HWND hWnd, LONG nFiles, LPCSTR* lpFileNames, LPCSTR lpComment, LONG * pdwFlags, LPCMDOPTS pvOptions) {
	log("SccAdd:\n");
	return SCC_OK;
}

SCCEXTERNC SCCRTN EXTFUN SccRemove(LPVOID pContext, HWND hWnd, LONG nFiles, LPCSTR* lpFileNames, LPCSTR lpComment, LONG dwFlags, LPCMDOPTS pvOptions) {
	log("SccRemove:\n");
	return SCC_OK;
}

SCCEXTERNC SCCRTN EXTFUN SccDiff(LPVOID pContext, HWND hWnd, LPCSTR lpFileName, LONG dwFlags, LPCMDOPTS pvOptions) {
	log("SccDiff: %s, %X :\n", lpFileName, dwFlags);
	return SCC_OK;
}

SCCEXTERNC SCCRTN EXTFUN SccHistory(LPVOID pContext, HWND hWnd, LONG nFiles, LPCSTR* lpFileNames, LONG dwFlags, LPCMDOPTS pvOptions) {
	THECONTEXT *ctx = (THECONTEXT *)pContext;
	return SCC_OK;
}


SCCEXTERNC LONG EXTFUN SccGetVersion() {
	log("SccGetVersion %i\n", SCC_VER_NUM);
	return SCC_VER_NUM;
}






//---------------------------------------------------------------------------------------------


SCCEXTERNC SCCRTN EXTFUN SccRename(LPVOID pContext, HWND hWnd, LPCSTR lpFileName, LPCSTR lpNewName) {
	log("SccRename: not supported\n");
	return SCC_E_OPNOTSUPPORTED;
}

SCCEXTERNC SCCRTN EXTFUN SccProperties(LPVOID pContext, HWND hWnd, LPCSTR lpFileName) {
	log("SccProperties:\n");
	return SCC_OK;
}

SCCEXTERNC SCCRTN EXTFUN SccPopulateList(LPVOID pContext, enum SCCCOMMAND nCommand, LONG nFiles, LPCSTR* lpFileNames, POPLISTFUNC pfnPopulate, LPVOID pvCallerData, LPLONG lpStatus, LONG dwFlags) {
	log("SccPopulateList: not supported\n");
	return SCC_E_OPNOTSUPPORTED;
}

SCCEXTERNC SCCRTN EXTFUN SccGetEvents(LPVOID pContext, LPSTR lpFileName, LPLONG lpStatus, LPLONG pnEventsRemaining) {
	log("SccGetEvents: not supported\n");
	return SCC_E_OPNOTSUPPORTED;
}

SCCEXTERNC SCCRTN EXTFUN SccRunScc(LPVOID pContext, HWND hWnd, LONG nFiles, LPCSTR* lpFileNames) {
	log("SccRunScc: not supported\n");
	return SCC_E_OPNOTSUPPORTED;
}

SCCEXTERNC SCCRTN EXTFUN SccAddFromScc(LPVOID pContext, HWND hWnd, LPLONG pnFiles, LPCSTR** lplpFileNames) {
	log("SccAddFromScc: not supported\n");
	return SCC_E_OPNOTSUPPORTED;
}

SCCEXTERNC SCCRTN EXTFUN SccSetOption(LPVOID pContext, LONG nOption, LONG dwVal) {
	log("SccSetOption: not supported\n");
	return SCC_E_OPNOTSUPPORTED;
}

