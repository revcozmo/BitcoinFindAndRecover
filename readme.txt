CRYPTOFINDER

Bitcoin recovery tool. Supports all desktop wallets. It will work for most altcoins wallets, forked from the ones
listed below.

Automatizes the process of searching for wallet files, both existing and deleted. Very simple to use and safe.
Prevents the user from recovering to a folder on the same partition, if he's recovering deleted files. Works only on 
Windows and requires .NET 4.0 or above. Get it from here: http://www.microsoft.com/en-us/download/details.aspx?id=17851

Supports:

- Armory
- Bitcoin-QT
- Bither
- Copay
- Electrum
- mSIGNA
- Multibit
- MultibitHD

All files will be restored to the selected folder. If you chose to recover deleted files, all of them will be placed
on a subfolder called "RestoredTemp".
Different subfolders will be created per wallet. Files recovered that weren't deleted will have the directory structure
intact. Those recovered from deletion will not, due to a limitation of the file system. Those will be placed on
a subfolder called "recovered", under each wallet's folder.

The software won't process media and system files, to speed up the process.
There's a limit to the size of the file to analyze of 1024 KB. That limit is excepmpt for certain file names and
extensions.

While the program is working, it will appear to stop responding, that is normal. You can see the progress by looking
at the files restored. Working on adding a GUI indicator of the progress.