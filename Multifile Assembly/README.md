Задача на понимание многофайловых сборок и подписание сборок, в качестве классов можно выбрать все, что придет в голову

Создадим файлы [First.cs](First.cs) и [Second.cs](Second.cs).

Скомпилируем файлы в отдельные модули (First.netmodule и Second.netmodule)
```
csc /t:module First.cs
csc /t:module Second.cs
```
