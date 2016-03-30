---
xxxxx: Xxxxxx xxxxxx xxx xxxxx xxxxxxxxx xx Xxxxxxx Xxxxxxx Xxxxxxxxxx
xxxxxxxxxxx: .XXX Xxxxxxxxx xxxxxxx xxx Xxxxxxx Xxxxxxx Xxxxxxxxxx xxxxx xx xxxx xx xxxxxxx xxxxxx xxxxxxxxxx xx xxxxxx xxx xxxxxxxxxxx xxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxx xxxxxxx xxx xxx .XXX Xxxxxxxxx xxxxx xxxxxxx.
xx.xxxxxxx: YXYYXYYX-YYYY-YYXY-YYYY-YYXXYXXXYXXY
---

# Xxxxxx xxxxxx xxx xxxxx xxxxxxxxx xx Xxxxxxx Xxxxxxx Xxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


\[Xxxx xxxxxxxxxxx xxxxxxx xx xxx-xxxxxxxx xxxxxxx xxxxx xxx xx xxxxxxxxxxxxx xxxxxxxx xxxxxx xx'x xxxxxxxxxxxx xxxxxxxx. Xxxxxxxxx xxxxx xx xxxxxxxxxx, xxxxxxx xx xxxxxxx, xxxx xxxxxxx xx xxx xxxxxxxxxxx xxxxxxxx xxxx.\]

.XXX Xxxxxxxxx xxxxxxx xxx Xxxxxxx Xxxxxxx Xxxxxxxxxx xxxxx xx xxxx xx xxxxxxx xxxxxx xxxxxxxxxx xx xxxxxx xxx xxxxxxxxxxx xxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxx xxxxxxx xxx xxx .XXX Xxxxxxxxx xxxxx xxxxxxx. Xxxxxxx, xxxx xxx xxxxxxx xxxxxx xxxxx xxxxxxxxx xx x Xxxxxxx Xxxxxxx Xxxxxxxxx, xxx xxxx xxxxxx xxx xxxxxxx xxxx xx xxx XXX.

## Xxxxxxxxxxx xxxxxx


Xxxx xxx xxxxxxxx xx xxxxxx xx xxxxx xx xxx XXX, xxx xxx xxxxxxxx xxxxxxx x xxxxx. Xx xxxxxxxxxx, xxx xxxx xxxx xxxxx xx xxx xxxxxx xxxxxxxx. Xxxx xxxxx xxxx xxx xxx xxx xxxxxx xxxxxxxxx xxx XXX xxxxxx xxxx xxxxxxxxx xxxxxxxxxx xxxx xxx xxxxxxxxx xxx'xx xxxx xx.

Xxxxxxxxxxx, xxx Xxxxxx Xxxxx xxx X\# xxxxxxxxx xxxxxxxx xxxx xxxxxxx: Xxxx xxx xxxxxxx xx xxxxx xxxx xxxxxx xxxxxxxxx xx x Xxxxxxx Xxxxxxx Xxxxxxxxx, xxx xxxxxxxxx xxxxxxxxxxxxx xxx xxx XXX xxxxxxx. Xxx xxxxxxx, xxx xxx x xxxxxxxx xxxxx xx xxxx xxx xxxxxxxx xxxxx'x xxxxxx x xxxxx. Xxx .XXX Xxxxxxxxx xxxxxxxx xxx xxxxx xx xxxxxxx xxx xxxxxxxxxxxxxx:

-   Xxx [XxxxxXxxxxxxxxxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/windows.foundation.eventregistrationtoken.aspx) xxxxxxxxx xxxxxxxxxx xxx xxxxx.
-   Xxx [XxxxxXxxxxxxxxxxxXxxxxXxxxx&xx;X&xx;](https://msdn.microsoft.com/library/hh138412.aspx) xxxxx xxxxxxx xxxxxx xxx xxxxxxxxx x xxxxxxx xxxxxxx xxxxxx xxx xxxxx xxxxxxxx. Xxx xxxxxxx xxxx xxxxxxxx xx xxx xxxxx xxxxxxxx xxxx. Xxx xxxxxx xx xxxxxxxx xx xxxx xxxxx xxx xxxx xxxxx, xxx xxxxx xxxx xx xxxxx xxxxxxx xx xxxxxxxxxx xxx xxxx xxxxx.

Xxx xxxxxxxxx xxxx xxx xxx XxxxxxXxxxxxx xxxxx xxxxx xxx xxxxx xxxxxxx xxx XXX xxxxxx. Xx xxxx xxxxxxx, xxx xxxxxxxxxxx xxx xxx xxxxx xxxxxxxx xxxxxx, XxxxxxXxxxxxxXxxxxXxxx, xxxxx x xxxxxx xxxxxxx xxxxxxxxx xxxx xxxxxxxxxx xxx xxxxxxx xxxxxxx xxxxx.

> **Xxxx**  Xxxx xx xxx xxxx xxxxxxx xxx xxxxxxxxx xxx xxx xxxxxxxx xxxxxx xxxx xxx xxxxxxx xx x Xxxxxxx Xxxxxxx Xxxxxxxxx.

 
> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```csharp
> private EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>> 
>     m_NumberChangedTokenTable = null;
> 
> public event EventHandler<NumberChangedEventArgs> NumberChanged
> {
>     add
>     {
>         return EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>             .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
>             .AddEventHandler(value);
>     }
>     remove
>     {
>         EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>             .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
>             .RemoveEventHandler(value);
>     }
> }
> 
> internal void OnNumberChanged(int newValue)
> {
>     EventHandler<NumberChangedEventArgs> temp = 
>         EventRegistrationTokenTable<EventHandler<NumberChangedEventArgs>>
>         .GetOrCreateEventRegistrationTokenTable(ref m_NumberChangedTokenTable)
>         .InvocationList;
>     if (temp != null)
>     {
>         temp(this, new NumberChangedEventArgs(newValue));
>     }
> }
> ```
> ```vb
> Private m_NumberChangedTokenTable As  _
>     EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs))
> 
> Public Custom Event NumberChanged As EventHandler(Of NumberChangedEventArgs)
> 
>     AddHandler(ByVal handler As EventHandler(Of NumberChangedEventArgs))
>         Return EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs)).
>             GetOrCreateEventRegistrationTokenTable(m_NumberChangedTokenTable).
>             AddEventHandler(handler)
>     End AddHandler
> 
>     RemoveHandler(ByVal token As EventRegistrationToken)
>         EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs)).
>             GetOrCreateEventRegistrationTokenTable(m_NumberChangedTokenTable).
>             RemoveEventHandler(token)
>     End RemoveHandler
> 
>     RaiseEvent(ByVal sender As Class1, ByVal args As NumberChangedEventArgs)
>         Dim temp As EventHandler(Of NumberChangedEventArgs) = _
>             EventRegistrationTokenTable(Of EventHandler(Of NumberChangedEventArgs)).
>             GetOrCreateEventRegistrationTokenTable(m_NumberChangedTokenTable).
>             InvocationList
>         If temp IsNot Nothing Then
>             temp(sender, args)
>         End If
>     End RaiseEvent
> End Event
> ```

Xxx xxxxxx (Xxxxxx xx Xxxxxx Xxxxx) XxxXxXxxxxxXxxxxXxxxxxxxxxxxXxxxxXxxxx xxxxxx xxxxxxx xxx xxxxx’x xxxxxxxx xx xxx XxxxxXxxxxxxxxxxxXxxxxXxxxx&xx;X&xx; xxxxxx xxxxxx. Xxxx xxx xxxxx-xxxxx xxxxx xxxx xxxx xxxx xxx xxxxx xxxxx xxxxxxxx xx xxxx xxxxxx. Xx xxx xxxxx xx xxxxx, xxx xxxxxx xxxxxxx xxx xxxxx, xxxxxx x xxxxxxxxx xx xxx xxxxx xx xxx xxxxx, xxx xxxxxxx x xxxxxxxxx xx xxx xxxxx. Xx xxx xxxxx xxxxxxx xxxxxxxx x xxxxx xxxxx xxxxxxxxx, xxx xxxxxx xxxx xxxxxxx xxxx xxxxxxxxx.

> **Xxxxxxxxx**  Xx xxxxxx xxxxxx xxxxxx, xxx xxxxx xxxx xxxxx xxx xxxxx’x xxxxxxxx xx XxxxxXxxxxxxxxxxxXxxxxXxxxx&xx;X&xx; xxxx xx x xxxxx-xxxxx xxxxx. Xx xx xx x xxxxx-xxxxx xxxxx, xxx XxxXxXxxxxxXxxxxXxxxxxxxxxxxXxxxxXxxxx xxxxxx xxxxxxx xxxx xxxx xxxxxxxx xxxxxxx xxx xx xxxxxx xxx xxxxx xxxxx, xxx xxxxxxx xxx xxx xxxx xxxxxxxx xx xxx xxxxx. Xxx x xxxxx xxxxx, xxx xxxxx xx xxx XxxXxXxxxxxXxxxxXxxxxxxxxxxxXxxxxXxxxx xxxxxx xxxx xxx xxx xxxx xxxxx-xxxxx xxxxx.

Xxxxxxx xxx XxxXxXxxxxxXxxxxXxxxxxxxxxxxXxxxxXxxxx xxxxxx xx xxx xxxxxx xxxxxxxx xxx xx xxx [XxxxxXxxxx](https://msdn.microsoft.com/library/fwd3bwed.aspx) xxxxxx (xxx XxXxxxxXxxxx xxxxxx xx X\#) xxxxxxx xxxx xx xxxxxxxxxx xxxxx xx xxxxx xxxxxxx xxx xxxxxx xxxxxx xxx xxxxx xxxxxxx xxxxxxxxx xxxx xxxx xxxxx.

Xxx xxxxx xxxxxxx xx xxx XxxxxXxxxxxxxxxxxXxxxxXxxxx&xx;X&xx; xxxxx xxxx xxx xxxx xx xxx XXX xxxxx xxxxxxx xxxxxxx xxx xxxxxxxxx:

-   Xxx [XxxXxxxxXxxxxxx](https://msdn.microsoft.com/library/hh138458.aspx) xxxxxx xxxxxxxxx x xxxxx xxx xxx xxxxx xxxxxxx xxxxxxxx, xxxxxx xxx xxxxxxxx xx xxx xxxxx, xxxx xx xx xxx xxxxxxxxxx xxxx, xxx xxxxxxx xxx xxxxx.
-   Xxx [XxxxxxXxxxxXxxxxxx(XxxxxXxxxxxxxxxxxXxxxx)](https://msdn.microsoft.com/library/hh138425.aspx) xxxxxx xxxxxxxx xxxxxxx xxx xxxxxxxx xxxx xxx xxxxx xxx xxxx xxx xxxxxxxxxx xxxx.

    >**Xxxx**  Xxx XxxXxxxxXxxxxxx xxx XxxxxxXxxxxXxxxxxx(XxxxxXxxxxxxxxxxxXxxxx) xxxxxxx xxxx xxx xxxxx xx xxxx xxxxxx xxxxxx xxxxxx.

-   Xxx [XxxxxxxxxxXxxx](https://msdn.microsoft.com/library/hh138465.aspx) xxxxxxxx xxxxxxx x xxxxxxxx xxxx xxxxxxxx xxx xxx xxxxx xxxxxxxx xxxx xxx xxxxxxxxx xxxxxxxxxx xx xxxxxx xxx xxxxx. Xxx xxxx xxxxxxxx xx xxxxx xxx xxxxx, xx xxx xxx xxxxxxx xx xxx Xxxxxxxx xxxxx xx xxxxxx xxx xxxxxxxx xxxxxxxxxxxx.

    >**Xxxx**  Xx xxxxxxxxx xxxx xxx xxxxxx xxx xxxxxxx xxxxx xx xxx xxxxxxx xxxxxxxx xxxxxxx xx xxxx xxxxxxx, xxx xxxx xxx xxxxxxxx xx x xxxxxxxxx xxxxxxxx xxxxxx xxxxxxxx xx. Xxxx xxxxxx x xxxx xxxxxxxxx xx xxxxx xxx xxxxxx xxxxxxx xxx xxxx xxxxxxx, xxxxxxxx xxx xxxxxxxx xx xxxx xxxx xxxxxx xxxxxxx xxxxxx xxxxx xx xxxxxx xxx xxxxxxxx. Xxxxxxxxx xxx xxxxxxxxx, xx xxx xxxx xx xxxxx xxxxx.

Xxxxx xxxx xxx xxxx xx xxx xxxxxxxxx xx xxxxxxxxxxx. Xx xxxxxx xxxxxx xx xx xxxxx, xxx xxxx xxxxxxx xxxx xxx xxxxxxx xxx xxxx xxxx.

X\# xxxxx: Xxxx xxx xxxxx xxxxxx xxxxx xxxxxxxxx xx xxx XXX xxxxx xxxxxxx, xxx xxxxxxxx xxxxx'x xxxxxxx xxx xxxxx xxxxxxxxx xxxxxxxxx. Xx xxxxxxxxx xxxxxx xx xxx xxx xxx xxxx xx xxx xxxxx xx xxxx xxxx.

Xxxxxx Xxxxx xxxxx: Xx xxx .XXX Xxxxxxxxx, xx xxxxx xx xxxx x xxxxxxxxx xxxxxxxx xxxx xxxxxxxxxx xxx xxx xxxxxxxxxx xxxxx xxxxxxxx. Xxxxxxx xxx xxxxx xxxx xxxxx xxxxxxxx xxx xxxxxxxx. Xxxxxx Xxxxx xxxxxx xxxxxxxxx xxxxx xxx xxxxxxxxxxxx xxxx xxx xxxxxxxx, xxx xxx xxxxxxxx xxxxxx xxx xxxxxxxx xxxxxx xxxxxxxx xx, xx xxxxxxxxx xx xxx xxxx xxxxx xxxxxx xxxxxx. Xxxx xxx xxxxxx x xxxxxx xxxxx xx x Xxxxxxx Xxxxxxx Xxxxxxxxx, xxx xxxx xx xxxx xxxx xxx xxxxxxxx xxxxxxxx. Xxxx xxxx xxxxx xxxx xxx xxx, xxx xxxxxxx, xxx xxx [XxxxxxxxxXxxxxxxx.XxxXxxxxxxxxxXxxx](https://msdn.microsoft.com/library/system.multicastdelegate.getinvocationlist.aspx) xxxxxx xx xxx xx xxxxx xxxx xxxxxxxx x xxxxxxxx xxxxxxxx xxx xxxx xxxxx xxxxxxx, xx xxx xxxx xx xxxxxx xxx xxxxxxxx xxxxxxxxxx.

## Xxxxxxx xxxxxx

* [Xxxxxx (Xxxxxx Xxxxx)](https://msdn.microsoft.com/library/ms172877.aspx)
* [Xxxxxx (X\# Xxxxxxxxxxx Xxxxx)](https://msdn.microsoft.com/library/awbftdfh.aspx)
* [.XXX xxx Xxxxxxx Xxxxx Xxxx Xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/br230302.aspx)
* [.XXX xxx XXX xxxx](https://msdn.microsoft.com/library/windows/apps/xaml/mt185501.aspx)
* [Xxxxxxxxxxx: Xxxxxxxx x Xxxxxx Xxxxxxx Xxxxxxx Xxxxxxxxx xxx xxxxxxx xx xxxx XxxxXxxxxx](walkthrough-creating-a-simple-windows-runtime-component-and-calling-it-from-javascript.md)

<!--HONumber=Mar16_HO1-->
