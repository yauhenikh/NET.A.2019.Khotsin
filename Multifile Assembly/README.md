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
Подпишем сборку. Создадим пару ключей и поместим в файл MyKey.snk.
```
sn -k MyKey.snk
```
Извлечем открытый ключ из пары ключей в файле MyKey.snk и экспортируем в MyPublicKey.snk.
```
sn -p MyKey.snk MyPublicKey.snk
```

Посмотрим токен открытого ключа из MyPublicKey.snk вместе с открытым ключом.
```
sn -tp MyPublicKey.snk
Открытый ключ (алгоритм хэширования: sha1):
0024000004800000940000000602000000240000525341310004000001000100056e448f69dbfd
9296eb1c05e26d4543ee586435de20e5e59a0ebc92147ed326b902090397c515392ca160daa449
94baf588f2e4d2a650e4815d03835f48cf811c20772112c342dc729dbebfde8605070fde33c1eb
fbabdce24e66bb674ac3d53b7a30cc5ca49d8e37bdbbd59e326ad041ce7e12287b65b82b3b23d3
bcaafadf

Токен открытого ключа: 7f9296f3d12d9c36
```

Скомпилируем сборку с параметром /keyfile
```
al /out:MultifileLib.dll /t:library /keyfile:MyKey.snk First.netmodule Second.netmodule
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
