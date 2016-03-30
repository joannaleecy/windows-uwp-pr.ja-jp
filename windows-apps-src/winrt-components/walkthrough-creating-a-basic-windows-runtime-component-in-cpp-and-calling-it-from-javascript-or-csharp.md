---
xxxxx: Xxxxxxxx x xxxxx Xxxxxxx Xxxxxxx xxxxxxxxx xx X++ xxx xxxxxxx xx xxxx XxxxXxxxxx xx X#
xxxxxxxxxxx: Xxxx xxxxxxxxxxx xxxxx xxx xx xxxxxx x xxxxx Xxxxxxx Xxxxxxx Xxxxxxxxx XXX xxxx'x xxxxxxxx xxxx XxxxXxxxxx, X#, xx Xxxxxx Xxxxx.
xx.xxxxxxx: YYYXXYXY-YYYY-YXXX-YYXY-XYYYYYXYXYYY
---

# Xxxxxxxxxxx: Xxxxxxxx x xxxxx Xxxxxxx Xxxxxxx xxxxxxxxx xx X++ xxx xxxxxxx xx xxxx XxxxXxxxxx xx X\#


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


\[Xxxx xxxxxxxxxxx xxxxxxx xx xxx-xxxxxxxx xxxxxxx xxxxx xxx xx xxxxxxxxxxxxx xxxxxxxx xxxxxx xx'x xxxxxxxxxxxx xxxxxxxx. Xxxxxxxxx xxxxx xx xxxxxxxxxx, xxxxxxx xx xxxxxxx, xxxx xxxxxxx xx xxx xxxxxxxxxxx xxxxxxxx xxxx.\]

Xxxx xxxxxxxxxxx xxxxx xxx xx xxxxxx x xxxxx Xxxxxxx Xxxxxxx Xxxxxxxxx XXX xxxx'x xxxxxxxx xxxx XxxxXxxxxx, X\#, xx Xxxxxx Xxxxx. Xxxxxx xxx xxxxx xxxx xxxxxxxxxxx, xxxx xxxx xxxx xxx xxxxxxxxxx xxxxxxxx xxxx xx xxx Xxxxxxxx Xxxxxx Xxxxxxxxx (XXX), xxx xxxxxxx, xxx xxx Xxxxxx X++ Xxxxxxxxx Xxxxxxxxxx xxxx xxxx xxxxxxx xxxx xxx xxxxxxx xxxxxx. Xxx xxxx xxxxxxxxxxx, xxx [Xxxxxxxx Xxxxxxx Xxxxxxx Xxxxxxxxxx xx X++](creating-windows-runtime-components-in-cpp.md) xxx [Xxxxxx X++ Xxxxxxxx Xxxxxxxxx (X++/XX)](https://msdn.microsoft.com/library/windows/apps/xaml/hh699871.aspx).

## Xxxxxxxx xxx X++ xxxxxxxxx XXX


Xx xxxx xxxxxxx, xx xxxxxx xxx xxxxxxxxx xxxxxxx xxxxx, xxx xxx xxxxx xxxxxx xxx XxxxXxxxxx xxxxxxx xxxxx. Xxx xxxxx xxxxx’x xxxxxx.

Xxxxxx xxxx xxx xxxx xxxxx xx xxx xxxxxxxxx xxxxxxxx xxxxxxxx xx xxxxxxxx xxx xxxxxx xxxxxxxxxxx, xxx xx xxxxx xxxxxxxxxxx. Xxxxx xxx xxxxxxxx xxxx xx xxxx xxx xxx xx'x xxxx. Xxxx xxx xxx xxxxxxxx, xxx xx xxxx xxxxxxx, xx'xx xxxxxxx xxx xx xxx xxxxxxxxx xxxx xxxx xxx xxx xxxx.

## **Xx xxxxxx xxx X++ xxxxxxxxx xxxxxxx**

1.  Xx xxx Xxxxxx Xxxxxx xxxx xxx, xxxxxx **Xxxx, Xxx, Xxxxxxx**.
2.  Xx xxx **Xxx Xxxxxxx** xxxxxx xxx, xx xxx xxxx xxxx, xxxxxx **Xxxxxx X++** xxx xxxx xxxxxx xxx xxxx xxx Xxxxxxxxx Xxxxxxx xxxx.
3.  Xx xxx xxxxxx xxxx, xxxxxx **Xxxxxxx Xxxxxxx Xxxxxxxxx** xxx xxxx xxxx xxx xxxxxxx XxxXX\_XXX.
4.  Xxxxxx xxx **XX** xxxxxx.

## **Xx xxx xx xxxxxxxxxxx xxxxx xx xxx xxxxxxxxx**

1.  Xx xxxxxxxxxxx xxxxx xx xxx xxxx xxxxxx xxxx xxx xxxxxx xx xxxxx x **xxx** xxxxxxxxxx (**Xxx** xx Xxxxxx Xxxxx, xx **xxx xxx** xx X++). Xx xxxx xxxxxxxxx, xxx xxxxxxx xx xx **xxxxxx xxx xxxxx xxxxxx**. Xx xxxx, xxx XxxxxY.x xxx .xxx xxxxx xxxxxxx xxxx x xxx xxxxx. Xxx xxx xxxxxx xxx xxxx, xxx xx xxxx xxxxxxx xx’xx xxx xxx xxxxxxx xxxx—XxxxxY. Xxx xxx xxxxxx xxxxxxxxxx xxx xxxxxxx xx xxxxxxx xxxxxxx xx xxxx xxxxxxxxx xx xxxx xxx xxxxxxxx. Xxx xxxx xxxxxxxxxxx xxxxx xxx xxxxxxx, xxx [Xxxx Xxxxxx (X++/XX)](https://msdn.microsoft.com/library/windows/apps/hh755822.aspx).

2.  Xxx xxxxx \#xxxxxxx xxxxxxxxxx xx XxxxxY.x:

    ```cpp
             private void PrimesUnOrderedButton_Click_1(object sender, RoutedEventArgs e)
            {
                var nativeObject = new WinRT_CPP.Class1();

                StringBuilder sb = new StringBuilder();
                sb.Append("Primes found (unordered): ");
                PrimesUnOrderedResult.Text = sb.ToString();

                // primeFoundEvent is a user-defined event in nativeObject
                // It passes the results back to this thread as they are produced
                // and the event handler that we define here immediately displays them.
                nativeObject.primeFoundEvent += (n) =>
                {
                    sb.Append(n.ToString()).Append(" ");
                    PrimesUnOrderedResult.Text = sb.ToString();
                };

                // Call the async method.
                var asyncResult = nativeObject.GetPrimesUnordered(2, 100000);

                // Provide a handler for the Progress event that the asyncResult
                // object fires at regular intervals. This handler updates the progress bar.
                asyncResult.Progress += (asyncInfo, progress) =>
                    {
                        PrimesUnOrderedProgress.Value = progress;
                    };
            }

            private void Clear_Button_Click(object sender, RoutedEventArgs e)
            {
                PrimesOrderedProgress.Value = 0;
                PrimesUnOrderedProgress.Value = 0;
                PrimesUnOrderedResult.Text = "";
                PrimesOrderedResult.Text = "";
                Result1.Text = "";
            }
    ```

## Xxxxxxx xxx xxx


Xxxxxx xxxxxx xxx X\# xxxxxxx xx XxxxXxxxxx xxxxxxx xx xxx xxxxxxx xxxxxxx xx xxxxxxx xxx xxxxxxxx xxxx xxx xxx xxxxxxx xxxx xx Xxxxxxxx Xxxxxxxx xxx xxxxxxxx **Xxx Xx Xxxxxxx Xxxxxxx**. Xxxx xxxxx XY xx xxx xxxx xxxxxxxxx, xx Xxxx+XY xx xxx xxxxxxx xxxxxxxxx.

## Xxxxxxxxxx xxxx xxxxxxxxx xx Xxxxxx Xxxxxxx (xxxxxxxx)


Xx Xxxxxx Xxxxxxx, xxx xxx xxxxxxx xxx Xxxxxxx Xxxxxxx xxxxx xxxx xxx xxxxxxx xx .xxxxx xxxxx. Xxxx xxxxxxxx xxx xxxxx xx xxx Xxxxxxxx xxxxxxxxx xxx xxx xxxxxxx xxxxxxxxx. Xxxxxxx, xxxxxxx xxx xxxxx xx xxx Xxxxxxxx::Xxxxxxxxxxx xxxxxxxxx xxx xxxxxxx xx xxx xxxxxx xxxx xxxxxxxxxxx.x, xxx xx x xxxxx xxxx, xxxx xxx’x xxxxxx xx Xxxxxx Xxxxxxx.

## **Xx xxxxxxx x xxxxxxxxx**

1.  Xx xxx xxxx xxx, xxxxxx **Xxxx, Xxxxxx Xxxxxxx** (Xxxx+Xxx+X).
2.  Xx xxx xxxx xxxx xx xxx Xxxxxx Xxxxxxx, xxxxxx xxx XxxXX\_XXX xxxx xx xxxx xxx xxxxx xxx xxxxxxx xxxx xxx xxxxxxx xx xxxx xxxxxxxxx.

## Xxxxxxxxx xxxx


Xxx x xxxxxx xxxxxxxxx xxxxxxxxxx, xxxxxxxx xxx xxxxxxxxx xxxxxxx xxxx xxx xxxxxx Xxxxxxxxx xxxxxx xxxxxxx:

## **Xx xxxxxxxx xxxxxxxxx xxxxxxx**

1.  Xx xxx xxxx xxx, xxxxxx **Xxxxx, Xxxxxxx**.
2.  Xx xxx **Xxxxxxx** xxxxxx xxx, xxxxxx **Xxxxxxxxx** xxx xxxxxx **Xxxxxxx**.
3.  Xxxxxx **Xxxxxxxxx Xxxxxx Xxxxxxx** xxx xxx xxxxxx xxx **XX** xxxxxx.

Xx xxxxx xxxx xxxx xxxx xx xxxxxxxx xxx xxxxxxx xxx xxxxx xxxx. Xxx xxxxxx xxxxxxxxxxx xxx xxxx xxxx xxx xxxxx XY, xxxxxxx x xxxxx xxxxxxxxx xx xxxxx xx xxxxx xxx xxxxxxx.

Xxxx xxx xxxxx x XxxxXxxxxx xxxxxxxx xxxx xxx x xxxxxxxxx XXX, xxx xxx xxx xxx xxxxxxxx xx xxxxxx xxxxxx xxxxxxxx xxxxxxx xxxxxx xx xxxxxxxx xxxxxxx xxxxxx xxxx xx xxx xxxxxxxxx, xxx xxx xxxx xx xxx xxxx xxxx. Xx xxxxxx xxx xxxxxxx, xxxx xxx xxxxxxxx xxxx xxx xxx XxxxXxxxxx xxxxxxx xxxx xx Xxxxxxxx Xxxxxxxx xxx xxxxxx **Xxxxxxxxxx, Xxxxxxxxx, Xxxxxxxx Xxxx**.

Xx xxxx xx xxxxxx xxxxxxxxxxx xxxxxxxxxxxx xx xxx xxxxxxx xxxxxxxx. Xxx xxx xxxx xxx xxxxxxx xxxxxxxx xx xxxxxxx xxx Xxxxxxx.xxxxxxxxxxxx xxxx. Xxx xxxxxxx, xx xxx xxx xxxxxxxxxx xx xxxxxxxxxxxxxxxx xxxxxx xxxxx xx xxx Xxxxxxxx xxxxxx, xx xxxx xx xxxxxx xxx **Xxxxxxxx Xxxxxxx** xxxxx xxx xx xxx **Xxxxxxxxxxxx** xxxx xx xxx xxxxxxx xxxxxxxx.

Xx xxxx XxxxXxxxxx xxxx xxxxx'x xxxxxxxxx xxx xxxxxx xxxxxxxxxx xx xxxxxxx xx xxx xxxxxxxxx, xxxx xxxx xxxx xx XxxxXxxxxx xxx xxx xxxxx xxxxx xxxxxx. Xxx xxxxxxx, xxx `ComputeResult` X++ xxxxxx xxxx xx xxxxxxxxxx xx `computeResult` xx XxxxXxxxxx.

Xx xxx xxxxxx x X++ Xxxxxxx Xxxxxxx Xxxxxxxxx xxxxxxx xxxx x xxxxxxxx, xxx xxxx xxxx xxxxxxxx xxxxxx xxx xxxxxxx xxxxxxxxx xxxx xxx XxxxXxxxxx xxxxxxx. Xxxxxxx xx xx xx xxxxxxxx xxxxxxxxxx xxxxx xx xxxxx xxxxxxxxxx. Xx xxxxxxxxx, xxx xxx xxxx xxx xx xxxxxxxx xxxxxxxxx xx xxx XXX.

## Xxxxxxx xxxxxx

* [Xxxxxxxx Xxxxxxx Xxxxxxx Xxxxxxxxxx xx X++](creating-windows-runtime-components-in-cpp.md)

<!--HONumber=Mar16_HO1-->
