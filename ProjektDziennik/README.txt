Aplikacja składa się z aplikacji internetowej elektronicznego dziennika. Jej zadaniem jest wyświetlanie ocen danego użytkownika. Zakłada również, że jeden użytkownik może być zarówno uczniem, jak i nauczycielem. Została zasilona startowymi danymi (11 kont, 1 superadmin, 3 nauczycieli i 7 uczniów). Dane logowania zostały umieszczone w pliku Logins.txt

Instalacja:
1) sprawdź czy posiadasz zainstalowane pakiety:
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.SqlServer

2) w konsoli menedżera pakietów NuGet wpisz: update-database

3) uruchom program