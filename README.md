# Texas Holdem
Combination analyzers for Texas Holdem Poker.

# Limitations
The homework took me 6 hours to develop. I skipped cases when 2-n players can have the same weight of combinations, but the one whose combo's power is greater should win. For example first player has "As 2s 3d 4s 5h" straight and second has "2s 3d 4s 5h 6s". Second player must win, because his straight combo is stronger. I made design that potentially can cover comparison logic, but I was not sure that this was part of homework and decided to skip this case. If the current solution is not enough and you want me to add comparison logic please let me know.
Also app reads lines from the file (you can find sample file in the root). 

# How to compile & run
1) Download and install SDK and runtime. https://dotnet.microsoft.com/download/dotnet-core .NET Core version is 2.2
2) Publish the app. Sample command: "dotnet publish -c release --self-contained --runtime linux-x64 --framework netcoreapp2.2"
3) put input.txt in the root directory
4) run the application
If you do not want to go through all these steps, let me know please. I can deploy app to the remote server.
