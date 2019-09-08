Mini-project "File Cabinet"

Step 1

Work with records, use memory, List

"create" command
```
> create
First name: ...
Last name: ...
Date of birth: ...
Record #1 is created.
```
"list" command
```
> list
#1, John, Doe
#2, Stan, Smith
```
"stat" command
```
> stat
3 records.
```
Step 2

"find" command
```
> find firstname "John"
#1
#2
```
"edit" command
```
> edit #1
First name: ...
Last name: ...
Date of birth: ...
```
Step 3

"export csv" command
```
> export csv
```
"export xml" command
```
> export xml
```
Step 4

Adding file system

Step 5

Extension of "find" command
```
> find firstname "John", lastname "Doe"
#1
#2
```
Extension of "list" command
```
> list id, firstname, lastname
#1, John, Doe
#2, Stan, Smith
```
Step 6

Adding indexer

Step 7

"import csv" command
```
> import csv filename.csv
```
"import xml" command
```
> import xml filename.xml
```

Step 8

"remove" command
```
> remove #1
Record #1 is removed.
```

"purge" command
```
> purge
```
