# SDRSharp.XDR
This is Server for XDR-GTK
It doesn't do much yet
but things that work are:
  * Signal Meter
  * Filter Bandwith
  * Tunning
  * Modulation select (AM/FM)
  * Squelch (exept Stereo Squelch as I don't know what that is)
 RDS Still doesn't work
 
 MagicLine
 ```xml
<add key="XDR" value="SDRSharp.XDR.XDRPlugin,SDRSharp.XDR" />
 ```
 
 Exmplanation of MagicLine(if you want to write your own plugin someday)
 ```xml
 <add key="Whatever-you-want-that-is-unique" value="NameSpace.EntryPoint.DLLName" />
 ```
