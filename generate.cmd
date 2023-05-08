@echo off
pushd generation
for /r %%f in (generate.rsp) do if exist %%f (
    pushd %%~dpf
    ClangSharpPInvokeGenerator @generate.rsp
    popd
)
popd
pause