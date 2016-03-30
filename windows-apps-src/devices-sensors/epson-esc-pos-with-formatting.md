---
xx.xxxxxxx: YYYYYYYY-YYYX-YXYY-YYXY-YYYYYYYYYYXY
xxxxx: Xxxxx XXX/XXX xxxx xxxxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxx xxx XXX/XXX xxxxxxx xxxxxxxx xx xxxxxx xxxx, xxxx xx xxxx xxx xxxxxx xxxx xxxxxxxxxx, xxx xxxx Xxxxx xx Xxxxxxx xxxxxxx.
---
# Xxxxx XXX/XXX xxxx xxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [XxxxxxxXxxxxxx Xxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt426652)
-   [**Xxxxxxx.Xxxxxxx.XxxxxXxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn298071)

Xxxxx xxx xx xxx xxx XXX/XXX xxxxxxx xxxxxxxx xx xxxxxx xxxx, xxxx xx xxxx xxx xxxxxx xxxx xxxxxxxxxx, xxx xxxx Xxxxx xx Xxxxxxx xxxxxxx.

## XXX/XXX xxxxx

Xxxxxxx Xxxxx xx Xxxxxxx xxxxxxxx xxx xx x xxxxxxx xx xxxxxxxx, xxxxxxxxx xxxxxxx Xxxxx XX xxxxxx xxxxxxxx (xxx x xxxx xxxx xx xxxxxxxxx xxxxxxxx, xxx xxx [XxxxxxxXxxxxxx Xxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt426652) xxxx). Xxxxxxx xxxxxxxx xxxxxxxx xxxxxxx xxx XXX/XXX xxxxxxx xxxxxxx xxxxxxxx, xxxxx xxxxxxxx xxxxxxxxx xxx xxxxxxxxxx xxxxxxxx xxx xxxxxxxxxxxxx xxxx xxxx xxxxxxx.

XXX/XXX xx x xxxxxxx xxxxxx xxxxxxx xx Xxxxx xxxx xxxxxx x xxxx xxxxx xx XXX xxxxxxx xxxxxxx, xxxxx xx xxxxxxxx xxxxxxxxxxxx xxxxxxx xxxx xx xxxxxxxxx xxxxxxxxx xxxxxxxxxxxxx. Xxxx xxxxxx xxxxxxxx xxxxxxx XXX/XXX.

Xxx xxxxxxxx xxxxx xxxx xxx XXX xxxxxxxxx (XXXXX YY, XXX YX) xx XX (XXXXX YY, XXX YX), xxxxxxxx xx xxxxxxx xxxxxxxxx xxxx xxxxxxxxx xxx xxxxxxx. Xxxxxx xxxx xx xxxxxx xxxx xx xxx xxxxxxx, xxxxxxxxx xx xxxx xxxxxx.

Xxx [**Xxxxxxx XxxxxXxXxxxxxx XXX**](https://msdn.microsoft.com/library/windows/apps/Dn298071) xxxxxxxx xxxx xx xxxx xxxxxxxxxxxxx xxx xxx xxx xxx **Xxxxx()** xx **XxxxxXxxx()** xxxxxxx. Xxxxxxx, xx xxx xxxxxxx xxxxxxxxxx xx xx xxxx xxxxxxxx xxxxxxxx, xxx xxxx xxx XXX/XXX xxxxxxxx, xxxxx xx x xxxxxx xxx xxxx xx xxx xxxxxxx.

## Xxxxxxx xxxxx xxxx xxx xxxxxx xxxx xxxxxxxxxx

Xxx xxxxxxx xxxxx xxxxx xxx xx xxx XXX/XXX xxxxxxxx xx xxxxx xx xxxx xxx xxxxxx xxxxx xxxxxxxxxx. Xxxx xxxx xxxx xxxxxxx xx xxxxx xx x xxxxxx, xxxx xxxxxxxx xxxx xxx xxxxxXxx xxxxx.

```csharp
// … prior plumbing code removed for brevity
// this code assumed you’ve already created a receipt print job (printJob)
// and also that you’ve already checked the PosPrinter Capabilities to 
// verify that the printer supports Bold and DoubleHighDoubleWide print modes

const string ESC = “\u001B”;
const string GS = “\u001D”;
const string InitializePrinter = ESC + “@”;
const string BoldOn = ESC + “E” + “\u0001”;
const string BoldOff = ESC + “E” + “\0”;
const string DoubleOn = GS + “!” + “\u0011”;  // 2x sized text (double-high + double-wide)
const string DoubleOff = GS + “!” + “\0”;

printJob.Print(InitializePrinter);
printJob.PrintLine(“Here is some normal text.”);
printJob.PrintLine(BoldOn + “Here is some bold text.” + BoldOff);
printJob.PrintLine(DoubleOn + “Here is some large text.” + DoubleOff);

printJob.ExecuteAsync();
```

Xxx xxxx xxxxxxxxxxx xx XXX/XXX, xxxxxxxxx xxxxxxxxx xxxxxxxx, xxxxx xxx xxx [Xxxxx XXX/XXX XXX](http://content.epson.de/fileadmin/content/files/RSD/downloads/escpos.pdf). Xxx xxxxxxx xx [**Xxxxxxx.Xxxxxxx.XxxxxXxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn298071) xxx xxx xxx xxxxxxxxx xxxxxxxxxxxxx, xxx [XxxxxxxXxxxxxx Xxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt426652) xx XXXX.


<!--HONumber=Mar16_HO1-->
