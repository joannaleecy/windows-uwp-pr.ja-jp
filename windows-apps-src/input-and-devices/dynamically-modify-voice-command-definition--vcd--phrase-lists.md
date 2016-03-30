---
Xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxx xxxxxx xxx xxxx xx xxxxxxxxx xxxxxxx (XxxxxxXxxx xxxxxxxx) xx x Xxxxx Xxxxxxx Xxxxxxxxxx (XXX) xxxx xxxxx xxx xxxxxx xxxxxxxxxxx xxxxxx xx xxx xxxx.
xxxxx: Xxxxxxxxxxx xxxxxx XXX xxxxxx xxxxx
xx.xxxxxxx: YYYYYXXX-XXYX-YYXX-XXXY-XYYYXXYXYYYY
xxxxx: Xxxxxx XXX xxxxxx xxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxxxxxx xxxxxx XXX xxxxxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.XxxxxxxxxxxXxxxx.XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**XXX xxxxxxxx xxx xxxxxxxxxx xY.Y**](https://msdn.microsoft.com/library/windows/apps/dn706593)

Xxxxx xxx xx xxxxxx xxx xxxxxx xxx xxxx xx xxxxxxxxx xxxxxxx (**XxxxxxXxxx** xxxxxxxx) xx x Xxxxx Xxxxxxx Xxxxxxxxxx (XXX) xxxx xxxxx xxx xxxxxx xxxxxxxxxxx xxxxxx xx xxx xxxx.

Xxxxxxxxxxx xxxxxxxxx x xxxxxx xxxx xx xxx xxxx xxx xx xxxxxx xx xxx xxxxx xxxxxxx xx xxxxxxxx xx x xxxx xxxxxxxxx xxxx xxxx xx xxxx-xxxxxxx xxxxxxxxx xx xxxxxxxxx xxx xxxx.

Xxx xxxxxxx, xxx'x xxx xxx xxxx x xxxxxx xxx xxxxx xxxxx xxx xxxxx xxxxxxxxxxxx, xxx xxx xxxx xxxxx xx xx xxxx xx xxxxx xxx xxx xx xxxxxx xxx xxx xxxx xxxxxxxx xx "Xxxx xxxx xx &xx;xxxxxxxxxxx&xx;". Xxx xxx'x xxxx xx xxxxxx x xxxxxxxx **XxxxxxXxx** xxxxxxx xxx xxxx xxxxxxxx xxxxxxxxxxx. Xxxxxxx, xxx xxx xxxxxxxxxxx xxxxxxxx **XxxxxxXxxx** xx xxx xxxx xxxx xxx xxxxxxxxxxxx xxxxxxx xx xxx xxxx. Xx xxx **XxxxxxXxx** xxxxxxx xxxxxx, xxx xxxxx xxxxxxx xxxxxxxxx xxxx: `<ListenFor> Show trip to {destination}  </ListenFor>`, xxxxx "xxxxxxxxxxx" xx xxx xxxxx xx xxx **Xxxxx** xxxxxxxxx xxx xxx **XxxxxxXxxx**.

Xxx xxxx xxxx xxxxx **XxxxxxXxxx** xxx xxxxx XXX xxxxxxxx, xxx xxx [**XXX xxxxxxxx xxx xxxxxxxxxx xY.Y**](https://msdn.microsoft.com/library/windows/apps/dn706593) xxxxxxxxx.

**Xxxxxxxxxxxxx:  **

Xxxx xxxxx xxxxxx xx [Xxxxxx x xxxxxxxxxx xxx xxxx xxxxx xxxxxxxx xx Xxxxxxx](launch-a-foreground-app-with-voice-commands-in-cortana.md). Xx xxxxxxxx xxxx xx xxxxxxxxxxx xxxxxxxx xxxx x xxxx xxxxxxxx xxx xxxxxxxxxx xxx xxxxx **Xxxxxxxxx Xxxxx**.

Xx xxx'xx xxx xx xxxxxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx, xxxx x xxxx xxxxxxx xxxxx xxxxxx xx xxx xxxxxxxx xxxx xxx xxxxxxxxxxxx xxxxxxxxx xxxx.

-   [Xxxxxx xxxx xxxxx xxx](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   Xxxxx xxxxx xxxxxx xxxx [Xxxxxx xxx xxxxxx xxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185584)

**Xxxx xxxxxxxxxx xxxxxxxxxx:  **

Xxx [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233) xxx xxxx xxxxx xxx xx xxxxxxxxx xxxx xxx xxxx **Xxxxxxx** xxx [Xxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn596121) xxx xxxxxxx xxxx xx xxxxxxxxx x xxxxxx xxx xxxxxxxx xxxxxx-xxxxxxx xxx.

## <span id="Identify_the_command">
            </span>
            <span id="identify_the_command">
            </span>
            <span id="IDENTIFY_THE_COMMAND">
            </span>Xxxxxxxx xxx xxxxxxx


Xx xxxxxx x **XxxxxxXxxx** xxxxxxx xx xxx XXX xxxx, xxx xxx **XxxxxxxXxx** xxxxxxx xxxx xxxxxxxx xxx xxxxxx xxxx. Xxx xxx **Xxxx** xxxxxxxxx xx xxxx **XxxxxxxXxx** xxxxxxx (**Xxxx** xxxx xx xxxxxx xx xxx XXX xxxx) xx x xxx xx xxxxxx xxx [**XxxxxXxxxxxxXxxxxxx.XxxxxxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn653257) xxxxxxxx xxx xxx xxx [**XxxxxXxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn653258) xxxxxxxxx.

## <span id="Replace_the_phrase_list">
            </span>
            <span id="replace_the_phrase_list">
            </span>
            <span id="REPLACE_THE_PHRASE_LIST">
            </span>Xxxxxxx xxx xxxxxx xxxx


Xxxxx xxx'xx xxxxxxxxxx xxx xxxxxxx xxx, xxx x xxxxxxxxx xx xxx xxxxxx xxxx xxxx xxx xxxx xx xxxxxx xxx xxxx xxx [**XxxXxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653261) xxxxxx; xxx xxx **Xxxxx** xxxxxxxxx xx xxx **XxxxxxXxxx** xxxxxxx xxx xx xxxxx xx xxxxxxx xx xxx xxx xxxxxxx xx xxx xxxxxx xxxx.

**Xxxx**  Xx xxx xxxxxx x xxxxxx xxxx, xxx xxxxxx xxxxxx xxxx xx xxxxxxxx. Xx xxx xxxx xx xxxxxx xxx xxxxx xxxx x xxxxxx xxxx, xxx xxxx xxxxxxx xxxx xxx xxxxxxxx xxxxx xxx xxx xxx xxxxx xx xxx xxxx xx [**XxxXxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653261).

 

Xxxx, xxx XXX xxxx xxxxxxx x **Xxxxxxx**"xxxxXxxxXxXxxxxxxxxxx" xxxx x **XxxxxxXxxx** xxxx xxxxxxx xxxxx xxxxxxx xxx xxxxxxxxx x xxxxxxxxxxx xx xxx **Xxxxxxxxx Xxxxx** xxxxxx xxx. Xx xxx xxxx xxxxx xxx xxxxxxx xxxxxxxxxxxx xx xxx xxx, xxx xxx xxxxxxx xxx xxxxxxx xx xxx **XxxxxxXxxx**.

```XML
<?xml version="1.0" encoding="utf-8"?>
<VoiceCommands xmlns="http://schemas.microsoft.com/voicecommands/1.1">
  <CommandSet xml:lang="en-us" Name="AdventureWorksCommandSet_en-us">
    <CommandPrefix> Adventure Works, </CommandPrefix>
    <Example> Show trip to London </Example>

    <Command Name="showTripToDestination">
      <Example> show trip to London  </Example>
      <ListenFor> show trip to {destination} </ListenFor>
      <Feedback> Showing trip to {destination} </Feedback>
      <Navigate/>
    </Command>

    <PhraseList Label="destination">
      <Item> London </Item>
      <Item> Dallas </Item>
      <Item> New York </Item>
    </PhraseList>

  </CommandSet>

<!-- Other CommandSets for other languages -->

</VoiceCommands>
```

Xxxx'x xxx xx xxxxxx xxx **XxxxxxXxxx** xxxxx xx xxx xxxxxxxx xxxxxxx xxxx xx xxxxxxxxxx xxxxxxxxxxx xx Xxxxxxx.

```CSharp
Windows.ApplicationModel.VoiceCommands.VoiceCommnadDefinition.VoiceCommandSet commandSetEnUs;

if (Windows.ApplicationModel.VoiceCommands.VoiceCommandDefinitionManager.
      InstalledCommandSets.TryGetValue(
        "AdventureWorksCommandSet_en-us", out commandSetEnUs))
{
  await commandSetEnUs.SetPhraseListAsync(
    "destination", new string[] {“London”, “Dallas”, “New York”, “Phoenix”});
}
```

## <span id="Remarks">
            </span>
            <span id="remarks">
            </span>
            <span id="REMARKS">
            </span>Xxxxxxx


Xxxxx x **XxxxxxXxxx** xx xxxxxxxxx xxx xxxxxxxxxxx xx xxxxxxxxxxx xxx x xxxxxxxxxx xxxxx xxx xx xxxxx. Xxxx xxx xxx xx xxxxx xx xxx xxxxx (xxxxxxxx xx xxxxx, xxx xxxxxxx), xx xxxxxxx’x xx xxxxxxxxxxx xx xxx, xxx xxx **XxxxxxXxxxx** xxxxxxx xxx x **Xxxxxxx** xxxxxxx xx xxxxxx xxx xxxxxxxxx xx xxxxxx-xxxxxxxxxxx xxxxxxx xx xxxxxxx xxxxxxxxxxx.

Xx xxx xxxxxxx, xx xxxx x **XxxxxxXxxxx** xxxx x **Xxxxxxxx** xx "Xxxxxx", xxxxxxx xxxxxxx xx x **Xxxxxxx** xx "Xxxx\\Xxxxx".

```XML
<?xml version="1.0" encoding="utf-8"?>
<VoiceCommands xmlns="http://schemas.microsoft.com/voicecommands/1.1">
  <CommandSet xml:lang="en-us" Name="AdventureWorksCommandSet_en-us">
    <CommandPrefix> Adventure Works, </CommandPrefix>
    <Example> Show trip to London </Example>

    <Command Name="showTripToDestination">
      <Example> show trip to London  </Example>
      <ListenFor> show trip to {destination} </ListenFor>
      <Feedback> Showing trip to {destination} </Feedback>
      <Navigate/>
    </Command>

    <PhraseList Label="destination">
      <Item> London </Item>
      <Item> Dallas </Item>
      <Item> New York </Item>
    </PhraseList>

    <PhraseTopic Label="destination" Scenario="Search">
      <Subject>City/State</Subject>
    </PhraseTopic>

  </CommandSet>
```

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx


**Xxxxxxxxxx**
* [Xxxxxxx xxxxxxxxxxxx](cortana-interactions.md)
* [Xxxxxx x xxxxxxxxxx xxx xxxx xxxxx xxxxxxxx xx Xxxxxxx](launch-a-foreground-app-with-voice-commands-in-cortana.md)
* [Xxxxxx x xxxxxxxxxx xxx xxxx xxxxx xxxxxxxx xx Xxxxxxx](launch-a-background-app-with-voice-commands-in-cortana.md)
* [
            **XXX xxxxxxxx xxx xxxxxxxxxx xY.Y**](https://msdn.microsoft.com/library/windows/apps/dn706593)
**Xxxxxxxxx**
* [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233)
* [Xxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn596121)
**Xxxxxxx**
* [Xxxxxxx xxxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=619899)
 

 




<!--HONumber=Mar16_HO1-->
