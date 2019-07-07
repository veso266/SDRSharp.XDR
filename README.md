# SDRSharp.XDR
This is Server for XDR-GTK
It doesn't do much yet
but things that work are:
  * Signal Meter
  * Filter Bandwith
  * Tunning
  * Modulation select (AM/FM)
  * Squelch (exept Stereo Squelch as I don't know what that is)
  
 What does not work:
  * RDS
  * AGC Threshold (don't know what this does :()
  * Antena Switch (have nothing to switch so no use for it yet)
  * RF/IF Gain boost (SDR# doesn't expose any methods for that)
  * Stereo Indicator (SDR# doesn't expose this to plugins yet)
  * Volume control (you could control your PC volume with that or SDR# volume :))
  * Stereo de-emphasis switch (now way of switching it from SDR# eather so :()
 
 MagicLine
 ```xml
<add key="XDR" value="SDRSharp.XDR.XDRPlugin,SDRSharp.XDR" />
 ```
 
 Exmplanation of MagicLine(if you want to write your own plugin someday)
 ```xml
 <add key="Whatever-you-want-that-is-unique" value="NameSpace.EntryPoint.DLLName" />
 ```
