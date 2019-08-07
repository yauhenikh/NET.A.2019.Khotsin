Задача на понимание многофайловых сборок и подписание сборок, в качестве классов можно выбрать все, что придет в голову

Создадим файлы [First.cs](First.cs) и [Second.cs](Second.cs).

Скомпилируем файлы в отдельные модули (First.netmodule и Second.netmodule).
```
csc /t:module First.cs
csc /t:module Second.cs
```
Для создания многофайловой сборки (MultiFileLib.dll) воспользуемся, например, утилитой AL.
```
al /out:MultiFileLib.dll /t:library First.netmodule Second.netmodule
```
Создадим файл [UsingMultiFileLib.cs](UsingMultiFileLib.cs).

Построим приложение, которое использует типы сборки MultiFileLib.dll.
```
csc /r:MultiFileLib.dll /t:exe UsingMultiFileLib.cs
```
Запустим приложение
```
UsingMultiFileLib.exe
Hello from the FirstClass
Hello from the SecondClass
```
