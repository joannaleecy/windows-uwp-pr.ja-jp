---
Xxxxxxxxxxx: Xxx xxxx xxxx XXXx xx xxx Xxxxxxx.XX.Xxxx.Xxxx xxxxxxxxx xxxxxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xx xxxxxxx xxxx xxxxx xxxx xxx xxxx xxxxxxx xxxxxxxxx xx Xxxxxxx xxxxxxx.
xxxxx: Xxxxxx xxxx xxxxx xxxxxxxx
xx.xxxxxxx: YYXYXYXX-YXYX-YYXX-YXYX-YYYYYYXXYXYY
xxxxx: Xxxxxx xxxx xxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxx xxxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxx xxxx xxxx XXXx xx xxx [**Xxxxxxx.XX.Xxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn958238) xxxxxxxxx xxxxxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xx xxxxxxx xxxx xxxxx xxxx xxx xxxx xxxxxxx xxxxxxxxx xx Xxxxxxx xxxxxxx. Xxx XXXx xxx xxxxxxx xx xxx [Xxxx Xxxxxxxx Xxxxxxxxx](https://msdn.microsoft.com/library/windows/desktop/ms629032) XXXx xx xxxx xxx xxx xx xxx xxxxxxxx xx xxxx xxxxxxxx xxxxxxxxx xx xxx xxxx xxxxxxxx. Xxxx xxxxxxx xxx xxx xx xxxxxxx xxxx xx xxx xxxxxxxx xxx xxxx xxx xxxxx xxxx, xxxx xxxxxxxx, xxxxxx, xx xxx.


**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.XX.Xxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn958238)
-   [**XxxxXxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958158)


## <span id="Why_use_core_text_APIs_">
            </span>
            <span id="why_use_core_text_apis_">
            </span>
            <span id="WHY_USE_CORE_TEXT_APIS_">
            </span>Xxx xxx xxxx xxxx XXXx?


Xxx xxxx xxxx, xxx XXXX xx XXXX xxxx xxx xxxxxxxx xxx xxxxxxxxxx xxx xxxx xxxxx xxx xxxxxxx. Xxxxxxx, xx xxxx xxx xxxxxxx xxxxxxx xxxx xxxxxxxxx, xxxx x xxxx xxxxxxxxxx xxx, xxx xxxxx xxxx xxx xxxxxxxxxxx xx x xxxxxx xxxx xxxx xxxxxxx. Xxx xxxxx xxx xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxxxxxxx XXXx xx xxxxxx xxxx xxxx xxxx xxxxxxx, xxx xxxxx xxx'x xxxxxxx x xxx xx xxxxxxx xxxxxxxxxxx-xxxxx xxxx xxxxx, xxxxx xx xxxxxxxx xx xxxxxxx Xxxx Xxxxx xxxxxxxxx.

Xxxxxxx, xxx xxx [**Xxxxxxx.XX.Xxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn958238) XXXx xxxx xxx xxxx xx xxxxxx x xxxxxx xxxx xxxx xxxxxxx. Xxxxx XXXx xxx xxxxxxxx xx xxxx xxx x xxx xx xxxxxxxxxxx xx xxxxxxxxxx xxxx xxxxx, xx xxx xxxxxxxx, xxx xxx xxx xxxxxxx xxx xxxx xxxxxxxxxx xxxx xxxxxx xx xxxx xxx. Xxxx xxxxx xxx xxxx xxxxxxxx xxxxx xxxx xxx xxxx xxxx XXXx xxx xxxxxxx xxxx xxxxx xxxx xxx xxxxxxxx xxxx xxxxx xxxxxxx xx Xxxxxxx xxxxxxx, xxxx [Xxxx Xxxxxxxx Xxxxxxxxx](https://msdn.microsoft.com/library/windows/desktop/ms629032) xxxxx Xxxxx Xxxxxx Xxxxxxx (XXXx) xxx xxxxxxxxxxx xx XXx xx xxx XxxxXxxx xxxxxxxx (xxxxx xxxxxxxx xxxx-xxxxxxxxxx, xxxxxxxxxx, xxx xxxxxxxxx) xx xxxxxx xxxxxxx.

## <span id="Architecture">
            </span>
            <span id="architecture">
            </span>
            <span id="ARCHITECTURE">
            </span>Xxxxxxxxxxxx


Xxx xxxxxxxxx xx x xxxxxx xxxxxxxxxxxxxx xx xxx xxxx xxxxx xxxxxx.

-   "Xxxxxxxxxxx" xxxxxxxxxx x XXX xxx xxxxxxx x xxxxxx xxxx xxxxxxx xxxxx xxxxx xxx xxxx xxxx XXXx.
-   Xxx [**Xxxxxxx.XX.Xxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn958238) XXXx xxxxxxxxxx xxx xxxxxxxxxxxxx xxxx xxxx xxxxxxxx xxxxxxx Xxxxxxx. Xxxxxxxxxxxxx xxxxxxx xxx xxxx xxxx xxxxxxx xxx xxx xxxx xxxxxxxx xx xxxxxxx xxxxxxxxx xxxxxxx x [**XxxxXxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958158) xxxxxx xxxx xxxxxxxx xxx xxxxxxx xxx xxxxxx xx xxxxxxxxxx xxx xxxxxxxxxxxxx.

![xxxx xxxx xxxxxxxxxxxx xxxxxxx](images/coretext/architecture.png)

## <span id="Text_ranges_and_selection">
            </span>
            <span id="text_ranges_and_selection">
            </span>
            <span id="TEXT_RANGES_AND_SELECTION">
            </span>Xxxx xxxxxx xxx xxxxxxxxx


Xxxx xxxxxxxx xxxxxxx xxxxx xxx xxxx xxxxx xxx xxxxx xxxxxx xx xxxx xxxx xxxxxxxx xx xxxx xxxxx. Xxxx, xx xxxxxxx xxx xxxx xxxxxxxxxxx xxxxxx xxxx xx xxx xxxx xxxx XXXx xxx xxx xxxxxx xxx xxxxxxxxxx xxx xxxxxxxxxxx xx xxxx xxxxxx.

### <span id="Application_caret_position">
            </span>
            <span id="application_caret_position">
            </span>
            <span id="APPLICATION_CARET_POSITION">
            </span>Xxxxxxxxxxx xxxxx xxxxxxxx

Xxxx xxxxxx xxxx xxxx xxx xxxx xxxx XXXx xxx xxxxxxxxx xx xxxxx xx xxxxx xxxxxxxxx. Xx "Xxxxxxxxxxx Xxxxx Xxxxxxxx (XXX)" xx x xxxx-xxxxx xxxxxx xxxx xxxxxxxxx xxx xxxxx xx xxxxxxxxxx xxxx xxx xxxxx xx xxx xxxx xxxxxx xxxxxxxxxxx xxxxxx xxx xxxxx, xx xxxxx xxxx.

![xxxxxxx xxxx xxxxxx xxxxxxx](images/coretext/stream-1.png)
### <span id="Text_ranges_and_selection">
            </span>
            <span id="text_ranges_and_selection">
            </span>
            <span id="TEXT_RANGES_AND_SELECTION">
            </span>Xxxx xxxxxx xxx xxxxxxxxx

Xxxx xxxxxx xxx xxxxxxxxxx xxx xxxxxxxxxxx xx xxx [**XxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958201) xxxxxxxxx xxxxx xxxxxxxx xxx xxxxxx:

| Xxxxx                  | Xxxx xxxx                                                                 | Xxxxxxxxxxx                                                                      |
|------------------------|---------------------------------------------------------------------------|----------------------------------------------------------------------------------|
| **XxxxxXxxxxXxxxxxxx** | **Xxxxxx** \[XxxxXxxxxx\] | **Xxxxxx.XxxYY** \[.XXX\] | **xxxYY** \[X++\] | Xxx xxxxx xxxxxxxx xx x xxxxx xx xxx XXX xxxxxxxxxxx xxxxxx xxx xxxxx xxxxxxxxx. |
| **XxxXxxxxXxxxxxxx**   | **Xxxxxx** \[XxxxXxxxxx\] | **Xxxxxx.XxxYY** \[.XXX\] | **xxxYY** \[X++\] | Xxx xxx xxxxxxxx xx x xxxxx xx xxx XXX xxxxxxxxxxx xxxxx xxx xxxx xxxxxxxxx.     |

 

Xxx xxxxxxx, xx xxx xxxx xxxxx xxxxx xxxxxxxxxx, xxx xxxxx \[Y, Y\] xxxxxxxxx xxx xxxx "Xxxxx". **XxxxxXxxxxXxxxxxxx** xxxx xxxxxx xx xxxx xxxx xx xxxxx xx xxx **XxxXxxxxXxxxxxxx**. Xxx xxxxx \[Y, Y\] xx xxxxxxx.

### <span id="Insertion_point">
            </span>
            <span id="insertion_point">
            </span>
            <span id="INSERTION_POINT">
            </span>Xxxxxxxxx xxxxx

Xxx xxxxxxx xxxxx xxxxxxxx, xxxxxxxxxx xxxxxxxx xx xx xxx xxxxxxxxx xxxxx, xx xxxxxxxxxxx xx xxxxxxx xxx **XxxxxXxxxxXxxxxxxx** xx xx xxxxx xx xxx **XxxXxxxxXxxxxxxx**.

### <span id="Noncontiguous_selection">
            </span>
            <span id="noncontiguous_selection">
            </span>
            <span id="NONCONTIGUOUS_SELECTION">
            </span>Xxxxxxxxxxxxx xxxxxxxxx

Xxxx xxxx xxxxxxxx xxxxxxx xxxxxxxxxxxxx xxxxxxxxxx. Xxx xxxxxxx, Xxxxxxxxx Xxxxxx xxxx xxxxxxx xxxxxxxx xxxxxxxxx xxxxxxxxxx, xxx xxxx xxxxxx xxxx xxxxxxx xxxxxxx xxxxxx xxxxxxxxx. Xxxxxxx, xxx xxxx xxxx XXXx xx xxx xxxxxxx xxxxxxxxxxxxx xxxxxxxxxx. Xxxx xxxxxxxx xxxx xxxxxx xxxx x xxxxxx xxxxxxxxxx xxxxxxxxx, xxxx xxxxx xxx xxxxxx xxx-xxxxx xx xxx xxxxxxxxxxxxx xxxxxxxxxx.

Xxx xxxxxxx, xxxxxxxx xxxx xxxx xxxxxx:

![xxxxxxx xxxx xxxxxx xxxxxxx](images/coretext/stream-2.png)
Xxxxx xxx xxx xxxxxxxxxx: \[Y, Y\] xxx \[Y, YY\]. Xxx xxxx xxxxxxx xxxx xxxxxx xxxx xxx xx xxxx; xxxxxx \[Y, Y\] xx \[Y, YY\].

## <span id="Working_with_text">
            </span>
            <span id="working_with_text">
            </span>
            <span id="WORKING_WITH_TEXT">
            </span>Xxxxxxx xxxx xxxx


Xxx [**XxxxXxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958158) xxxxx xxxxxxx xxxx xxxx xxxxxxx Xxxxxxx xxx xxxx xxxxxxxx xxxxxxx xxx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958176) xxxxx, xxx [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958175) xxxxx, xxx xxx [**XxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958172) xxxxxx.

Xxxx xxxx xxxxxxx xxxxxxxx xxxx xxxxxxx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958176) xxxxxx xxxx xxx xxxxxxxxx xxxx xxxxx xxxxxxxx xxxx xxxx xxxxx xxxxxxx xxxx xxxxxxxxx, xxxxxx, xx XXXx.

Xxxx xxx xxxxxx xxxx xx xxxx xxxx xxxxxxx, xxx xxxxxxx, xx xxxxxxx xxxx xxxx xxx xxxxxxx, xxx xxxx xx xxxxxx Xxxxxxx xx xxxxxxx [**XxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958172).

Xx xxx xxxx xxxxxxx xxxxxxxx xxx xxx xxxx, xxxx x [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958175) xxxxx xx xxxxxx. Xxx xxxx xxxxxxx xxx xxx xxxx xx xxx **XxxxXxxxxxxxx** xxxxx xxxxxxx.

### <span id="Accepting_text_updates">
            </span>
            <span id="accepting_text_updates">
            </span>
            <span id="ACCEPTING_TEXT_UPDATES">
            </span>Xxxxxxxxx xxxx xxxxxxx

Xxxx xxxx xxxxxxx xxxxxx xxxxxxxxx xxxxxx xxxx xxxxxx xxxxxxxx xxxxxxx xxxx xxxxxxxxx xxx xxxx xxx xxxx xxxxx xx xxxxx. Xx xxx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958176) xxxxx xxxxxxx, xxxxx xxxxxxx xxx xxxxxxxx xx xxxx xxxx xxxxxxx:

1.  Xxxxxx xxx xxxx xxxxxxxxx xx [**XxxxXxxxXxxxXxxxxxxxXxxxxXxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn958236) xx xxx xxxxxxxx xxxxxxxxx xx [**XxxxXxxxXxxxXxxxxxxxXxxxxXxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958234).
2.  Xxxxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxxxx xx [**XxxxXxxxXxxxXxxxxxxxXxxxxXxxx.XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958233).
3.  Xxxxxx xxx xxxxxx xxxx xxx xxxxxx xxxxxxxxx xx xxxxxxx [**XxxxXxxxXxxxXxxxxxxxXxxxxXxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958235) xx [**XxxxXxxxXxxxXxxxxxxxXxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958237).

Xxx xxxxxxx, xxxx xx xxx xxxxx xx xx xxxx xxxxxxx xxxxxx xxx xxxx xxxxx "x". Xxx xxxxxxxxx xxxxx xx xx \[YY, YY\].

![xxxxxxx xxxx xxxxxx xxxxxxx](images/coretext/stream-3.png)
Xxxx xxx xxxx xxxxx "x", x [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958176) xxxxx xx xxxxxx xxxx xxx xxxxxxxxx [**XxxxXxxxXxxxXxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn958229) xxxx:

-   [
            **Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958234) = \[YY, YY\]
-   [
            **Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn958236) = "x"
-   [
            **XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958233) = \[YY, YY\]

Xx xxxx xxxx xxxxxxx, xxxxx xxx xxxxxxxxx xxxxxxx xxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958235) xx **Xxxxxxxxx**. Xxxx'x xxx xxxxx xx xxx xxxxxxx xxxxx xxx xxxxxxx xxx xxxxxxx.

![xxxxxxx xxxx xxxxxx xxxxxxx](images/coretext/stream-4.png)
### <span id="Rejecting_text_updates">
            </span>
            <span id="rejecting_text_updates">
            </span>
            <span id="REJECTING_TEXT_UPDATES">
            </span>Xxxxxxxxx xxxx xxxxxxx

Xxxxxxxxx, xxx xxxxxx xxxxx xxxx xxxxxxx xxxxxxx xxx xxxxxxxxx xxxxx xx xx xx xxxx xx xxx xxxx xxxxxxx xxxx xxxxxx xxx xx xxxxxxx. Xx xxxx xxxx, xxx xxxxxx xxx xxxxx xxx xxxxxxx. Xxxxxxx, xxxxxx xxx xxxxxx xxxx xxx xxxxxx xxxxxx xx xxxxxxx [**XxxxXxxxXxxxXxxxxxxxXxxxxXxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958235) xx [**XxxxXxxxXxxxXxxxxxxxXxxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958237).

Xxx xxxxxxx, xxxxxxxx xx xxxx xxxxxxx xxxx xxxxxxx xxxx xx x-xxxx xxxxxxx. Xxxxxx xxxxxx xx xxxxxxxx xxxxxxx x-xxxx xxxxxxxxx xxxxxx xxxxxxx xxxxxx, xx xxxx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958176) xxxxxx xxx xxxxxx xxx xxx xxxxx xxx, xxx xxxxxx xxxxxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958235) xx **Xxxxxx** xx xxxx xxxx xxxxxxx.

### <span id="Notifying_text_changes">
            </span>
            <span id="notifying_text_changes">
            </span>
            <span id="NOTIFYING_TEXT_CHANGES">
            </span>Xxxxxxxxx xxxx xxxxxxx

Xxxxxxxxx, xxxx xxxx xxxxxxx xxxxx xxxxxxx xx xxxx xxxx xx xxxx xxxx xx xxxxxx xx xxxx-xxxxxxxxx. Xx xxxxx xxxxx, xxx xxxx xxxxxx xxx xxxx xxxxxxxx xx xxxxx xxxxxxx xx xxxxxxx xxx [**XxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958172) xxxxxx.

Xxx xxxxxxx, xxxx xx xxx xxxxx xx xx xxxx xxxxxxx xxxxxx xxx xxxx xxxxxx "Xxxxx". Xxx xxxxxxxxx xxxxx xx xx \[Y, Y\].

![xxxxxxx xxxx xxxxxx xxxxxxx](images/coretext/stream-5.png)
Xxx xxxx xxxxxxxx xxx xxxxx xxxxxx xxx xxx xxxx xxxxxxx xxxx xx xxxx xxx xxxxxxxxx xxxx:

![xxxxxxx xxxx xxxxxx xxxxxxx](images/coretext/stream-4.png)
Xxxx xxxx xxxxxxx, xxx xxxxxx xxxx [**XxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958172) xxxx xxxxx xxxxxxxxx:

-   *xxxxxxxxXxxxx* = \[Y, Y\]
-   *xxxXxxxxx* = Y
-   *xxxXxxxxxxxx* = \[YY, YY\]

Xxx xx xxxx [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958175) xxxxxx xxxx xxxxxx, xxxxx xxx xxxxxx xx xxxxxx xxx xxxx xxxx xxx xxxx xxxxxxxx xxx xxxxxxx xxxx.

### <span id="Overriding_text_updates">
            </span>
            <span id="overriding_text_updates">
            </span>
            <span id="OVERRIDING_TEXT_UPDATES">
            </span>Xxxxxxxxxx xxxx xxxxxxx

Xx xxxx xxxx xxxxxxx, xxx xxxxx xxxx xx xxxxxxxx x xxxx xxxxxx xx xxxxxxx xxxx-xxxxxxxxxx xxxxxxxx.

Xxx xxxxxxx, xxxxxxxx xx xxxx xxxxxxx xxxx xxxxxxxx x xxxxxxxxxx xxxxxxx xxxx xxxxxxxxxx xxxxxxxxxxxx. Xxxx xx xxx xxxxx xx xxx xxxx xxxxxxx xxxxxx xxx xxxx xxxxx xxx xxxxx xxx xx xxxxxxx xxx xxxxxxxxxx. Xxx xxxxxxxxx xxxxx xx xx \[Y, Y\].

![xxxxxxx xxxx xxxxxx xxxxxxx](images/coretext/stream-6.png)
Xxx xxxx xxxxxxx xxx xxxxx xxx xxx x xxxxxxxxxxxxx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958176) xxxxx xx xxxxxx. Xxx xxxx xxxxxxx xxxxxxx xxx xxxx xxxxxx. Xxxx xx xxx xxxxx xx xxx xxxx xxxxxxx xxx x xxxxx xxxxxx xxxxxx xxx xxxxxxxxxx xx xxxxxxxxx. Xxx xxxxxxxxx xxxxx xx xx \[Y, Y\].

![xxxxxxx xxxx xxxxxx xxxxxxx](images/coretext/stream-7.png)
Xxxxxxx xx xxx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958176) xxxxx xxxxxxx, xxx xxxx xxxxxxx xxxxx xxx xxxxxxxxx xxxxxxxxxx. Xxxx xx xxx xxxxx xx xxx xxxx xxxxxxx xxxxx xxx xxxxxxxxxx xx xxxxxxxx. Xxx xxxxxxxxx xxxxx xx xx \[Y, Y\].

![xxxxxxx xxxx xxxxxx xxxxxxx](images/coretext/stream-8.png)
Xxxx xxxx xxxxxxx, xxx xxxxxx xxxx [**XxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958172) xxxx xxxxx xxxxxxxxx:

-   *xxxxxxxxXxxxx* = \[Y, Y\]
-   *xxxXxxxxx* = Y
-   *xxxXxxxxxxxx* = \[Y, Y\]

Xxx xx xxxx [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958175) xxxxxx xxxx xxxxxx, xxxxx xxx xxxxxx xx xxxxxx xxx xxxx xxxx xxx xxxx xxxxxxxx xxx xxxxxxx xxxx.

### <span id="Providing_requested_text">
            </span>
            <span id="providing_requested_text">
            </span>
            <span id="PROVIDING_REQUESTED_TEXT">
            </span>Xxxxxxxxx xxxxxxxxx xxxx

Xx'x xxxxxxxxx xxx xxxx xxxxxxxx xx xxxx xxx xxxxxxx xxxx xx xxxxxxx xxxxxxxx xxxx xxxx-xxxxxxxxxx xx xxxxxxxxxx, xxxxxxxxxx xxx xxxx xxxx xxxxxxx xxxxxxx xx xxx xxxx xxxxxxx, xxxx xxxxxxx x xxxxxxxx, xxx xxxxxxx, xx xxxx xxxx xx xxxxxxxx xx xxx xxxx xxxxxxx xx xxxxxxxxx xx xxxxxxxx xxxxxxxx. Xxxxxxxxx, xxxxxxxx x [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958175) xxxxx xx xxxxxx, xxx xxxx xxxxxxx xxx xxxx xxxxxxxxx xx xxxx xxxx xxxxxxx xxx xxx xxxxxxxxx xxxxx.

Xxxxx xxxx xx xxxxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958227) xx [**XxxxXxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958221) xxxxxxxxx x xxxxx xxxx xxxx xxxx xxxxxxx xxxxxx xxxxxxxxxxx xx-xx. Xxx xxxxxxx, xxx **Xxxxx** xx xxxxxx xxxx xxx xxxx xx xxx xxxx xxxxxxx xx xxx xxxx xx xxx [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn958175) xxxxx, xx xxx xxx xx xxx **Xxxxx** xx xxx xx xxxxxx. Xx xxxxx xxxxx, xxx xxxxxx xxxxxx xxxxxxxx xxxxx xxxxx xxxxx, xxxxx xx xxxxxxxxx x xxxxxx xx xxx xxxxxxxxx xxxxx.

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx


**Xxxxxxx xxxxxxx**
* [XXXX xxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=251417)
 

 




<!--HONumber=Mar16_HO1-->
