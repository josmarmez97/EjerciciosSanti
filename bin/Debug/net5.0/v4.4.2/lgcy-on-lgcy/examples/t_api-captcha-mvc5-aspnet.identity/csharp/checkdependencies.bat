find /c "packages\" %1
if %errorlevel% equ 1 (
  echo Run the "Update-Package -reinstall -safe" in your Package Manager Console to install build dependencies!
  echo Please note:
  echo The "Update-Package" command execution will fail if the resulting pathname of any dependency is going to be longer than 260 characters.
  echo We recommend you to mitigate this issue in advance by not placing this example too deep within the folder structure.
  exit /b 1
)