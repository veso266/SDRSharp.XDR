RDS data is provided by the RDS encoder in ASCII representation in this format:
```"G:"+#13+#10+"AAAABBBBCCCCDDDD"+#13+#10+#13+#10```
where
AAAA is PI,
BBBB is block 2,
CCCC is block 3,
DDDD is block 4 of the RDS group.

lets decipher this a bit 
#13 is ASCII character for CR (Clear Line (\r))
#10 is ASCII character for LF (Line Feed (\n))

so in human readable format this would look like:
```
G:
AAAABBBBCCCCDDDD


```
or in computer form
```G:CRLFAAAABBBBCCCCDDDDCRLF```

in C# you would write it
```csharp
Console.WriteLine("G:");
Console.WriteLine("AAAABBBBCCCCDDDD");
Console.WriteLine();
Console.WriteLine();
```
