# SDRSharp.XDR
This is Server for XDR-GTK
It doesn't do much yet
but things that work are:
  * Signal Meter
  * RDS (almost as PS Correction doesn't work and RDS LED is always lid as there is no isRDSDeceted bool in SDR# yet)
  * Filter Bandwith
  * Tunning
  * Modulation select (AM/FM)
  * Squelch (exept Stereo Squelch as I don't know what that is)
  * Stereo Indicator (Thanks Youssef for adding FmPilotIsDetected to ISharpControl in SDR# rev 1702)
  
 What does not work:
  * AGC Threshold (don't know what this does :()
  * Antena Switch (have nothing to switch so no use for it yet)
  * RF/IF Gain boost (SDR# doesn't expose any methods for that)
  * Volume control (you could control your PC volume with that or SDR# volume :))
  * Stereo de-emphasis switch (no way of switching it from SDR# eather so :()
 
 MagicLine
 ```xml
<add key="XDR" value="SDRSharp.XDR.XDRPlugin,SDRSharp.XDR" />
 ```
 
 Exmplanation of MagicLine(if you want to write your own plugin someday)
 ```xml
 <add key="Whatever-you-want-that-is-unique" value="NameSpace.EntryPoint,DLLName" />
 ```
 ![SDRSharp.XDR](IMGS/SDRSharp.XDRv0.6v1.PNG?raw=true "How it looks like when it works :)")
 ![SDRSharp.XDR](IMGS/SDRSharp.XDRv0.6v2.PNG?raw=true "How it looks like when it works :)")
