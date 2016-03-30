---
Xxxxxxxxxxx: Xxxxx xxx xx xxxxxx Xxxxxxx xxxx xxxx xxxxxxxx xxx xxxxxxx xxxxx xxxxxxxx, xx x xxxx xxx xxx xxxx xxx'x xxxx xxxxxxxx xx xxx xxxxxxx.
xxxxx: Xxxxxxx xxxxxxx xxxxxxxx xxxxx xxxxxxxx xx Xxxxxxx
xx.xxxxxxx: YYYXYYYX-YYYX-YXYX-YYYX-XYYYYXYYYYYY
xxxxx: Xxxxxxx xxxxxxx xxxxxxxx xxxxx xxxxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxxxx xxxxxxx xxxxxxxx xxxxx xxxxxxxx xx Xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxx xxx xx xxxxxx **Xxxxxxx** xxxx xxxx xxxxxxxx xxx xxxxxxx xxxxx xxxxxxxx, xx x xxxx xxx xxx xxxx xxx'x xxxx xxxxxxxx xx xxx xxxxxxx.

**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.XxxxxxxxxxxXxxxx.XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn706594)
-   [**Xxxxx Xxxxxxx Xxxxxxxxxx (XXX) xxxxxxxx xxx xxxxxxxxxx xY.Y**](https://msdn.microsoft.com/library/windows/apps/dn706593)


Xxxxxxxxx **Xxxxxxx** xxxxxxx xxxxx xxxxxxxx xxxxxxxx xxx xxxx xx xxxxxxxx xxxx xxx xxx xxx xxx xxxxxxxx xxxxxxx xx xxxxxxxx xx xxxxxxx. Xxxx xx xxxxxxxxx xxxxxxxxxxxx xx xxxxxxxxxx xxx xxx xxxx xx xxx xxxxxxxxx xx xxx xxxxx xxxxxxx. Xxx xxxxxxx, "Xxxxxxxxx Xxxxx, xxx x xxx xxxx xx Xxx Xxxxx."

Xxxxxxx, xxxxxxxxxx xxx xxxxxxxxxxx xxxx xxxxxx xxx xxxxxxx xxxxx xxxxx xxxxxxx, xxxxxxx, xx xxx xxxx xxxx xxxxx. Xx xxxx xxxxx, xxxxx xxxx xx xxx xxx xxx xxxx xxxxxxxxx xx xxx xxxxxxx xx xxxx xxxxxxxxxxx xxx xxxxxxx, xxx xxxxx xxxx xxx xxxxxxxxxxx xxxx xxxx xxxxxxxxx xxx xxxxxxxx xxx xxx xxxx. Xxx xxxxxxxx xxxxxxx, "Xxxxxxxxx Xxxxx, xxx x xxx xxxx xx Xxx Xxxxx." xxxxx xx xxxxxxxxx xx "Xxx x xxx Xxxxxxxxx Xxxxx xxxx xx Xxx Xxxxx." xx "Xxx x xxx xxxx xx Xxx Xxxxx xxxxx Xxxxxxxxx Xxxxx."

Xxx xxx xxx xx xxxx xxxxx xxxxxxxx xx xxxxxxx xxx xxx xxxx xx x:

-   Xxxxxx - xxxxxx xxx xxxxxxx xxxxxx
-   Xxxxx - xxxxxx xxx xxxxxxx xxxxxx
-   Xxxxxx - xxxxx xxx xxxxxxx xxxxxx

**Xxxxxxxxxxxxx:  **

Xxxx xxxxx xxxxxx xx [Xxxxxx x xxxxxxxxxx xxx xxxx xxxxx xxxxxxxx xx Xxxxxxx](launch-a-background-app-with-voice-commands-in-cortana.md). Xx xxxxxxxx xxxx xx xxxxxxxxxxx xxxxxxxx xxxx x xxxx xxxxxxxx xxx xxxxxxxxxx xxx xxxxx **Xxxxxxxxx Xxxxx**.

Xx xxx'xx xxx xx xxxxxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx, xxxx x xxxx xxxxxxx xxxxx xxxxxx xx xxx xxxxxxxx xxxx xxx xxxxxxxxxxxx xxxxxxxxx xxxx.

-   [Xxxxxx xxxx xxxxx xxx](https://msdn.microsoft.com/library/windows/apps/bg124288)
-   Xxxxx xxxxx xxxxxx xxxx [Xxxxxx xxx xxxxxx xxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185584)

**Xxxx xxxxxxxxxx xxxxxxxxxx:  **

Xxx [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233) xxx xxxx xxxxx xxx xx xxxxxxxxx xxxx xxx xxxx **Xxxxxxx** xxx [Xxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn596121) xxx xxxxxxx xxxx xx xxxxxxxxx x xxxxxx xxx xxxxxxxx xxxxxx-xxxxxxx xxx.

## <span id="Specify_an_AppName_element_in_the_VCD">
            </span>
            <span id="specify_an_appname_element_in_the_vcd">
            </span>
            <span id="SPECIFY_AN_APPNAME_ELEMENT_IN_THE_VCD">
            </span>Xxxxxxx xx **XxxXxxx** xxxxxxx xx xxx XXX


Xxx **XxxXxxx** xxxxxxx xx xxxx xx xxxxxxx x xxxx-xxxxxxxx xxxx xxx xx xxx xx x xxxxx xxxxxxx.

```XML
<AppName>Adventure Works</AppName></code></pre></td>
</tr>
</tbody>
</table>
```

## <span id="Specify_where_the_app_name_can_be_spoken_in_the_voice_command">
            </span>
            <span id="specify_where_the_app_name_can_be_spoken_in_the_voice_command">
            </span>
            <span id="SPECIFY_WHERE_THE_APP_NAME_CAN_BE_SPOKEN_IN_THE_VOICE_COMMAND">
            </span>Xxxxxxx xxxxx xxx xxx xxxx xxx xx xxxxxx xx xxx xxxxx xxxxxxx


Xxx **XxxxxxXxx** xxxxxxx xxx x **XxxxxxxXxxXxxx** xxxxxxxxx xxxx xxxxxxxxx xxxxx xxx xxx xxxx xxx xxxxxx xx xxx xxxxx xxxxxxx. Xxxx xxxxxxxxx xxxxxxxx xxxx xxxxxx.

1.  **XxxxxxXxxxxx**

    Xxxxxxx.

    Xxxxxxxxx xxxx xxxxx xxxx xxx xxxx xxx xxxx xxxxxx xxx xxxxxxx xxxxxx.

    Xxxx, Xxxxxxx xxxxxxx xxx "Xxxxxxxxx Xxxxx xxxx xx xx xxxx xx Xxx Xxxxx".

    <span codelanguage="XML"></span>
```    XML
    <colgroup>
    <col width="100%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">XML</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
<ListenFor RequireAppName="BeforePhrase"> when is [my] trip to {destination} </code></pre></td>
    </tr>
    </tbody>
    </table>
```

2.  **XxxxxXxxxxx**

    Xxxxxxxxx xxxx xxxxx xxxx xxx xxxx xxx xxxx xxxxx xxx xxxxxxx xxxxxx.

    X xxxxxxxxx xxxxxx xxxx xx xxxxxxxxxxxxx xxxxxxxxxxxx xx xxxxxxxx xx xxx xxxxxx. Xxxx xxxxxxxx xxxxxxx xxxx xx, "xxxxx", "xxxx "xxx "xx".

    Xxxx, Xxxxxxx xxxxxxx xxx xxxxxxxx xxxx "Xxxx xx xxxx xxxx xx Xxx Xxxxx xx Xxxxxxxxx Xxxxx" xxx "Xxxx xx xxxx xxxx xx Xxx Xxxxx xxxxx Xxxxxxxxx Xxxxx".

    <span codelanguage="XML"></span>
```    XML
    <colgroup>
    <col width="100%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">XML</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
<ListenFor RequireAppName="AfterPhrase">show [my] next trip to {destination} </ListenFor></code></pre></td>
    </tr>
    </tbody>
    </table>
```

3.  **XxxxxxXxXxxxxXxxxxx**

    Xxxxxxxxx xxxx xxxxx xxxx xxx xxxx xxx xxxx xxxxxx xxxxxx xx xxxxx xxx xxxxxxx xxxxxx.

    Xxx xxx xxxxxx xxxxxxx, x xxxxxxxxx xxxxxx xxxx xx xxxxxxxxxxxxx xxxxxxxxxxxx xx xxxxxxxx xx xxx xxxxxx. Xxxx xxxxxxxx xxxxxxx xxxx xx, "xxxxx", "xxxx "xxx "xx".

    Xxxx, Xxxxxxx xxxxxxx xxx xxxxxxxx xxxx "Xxxxxxxxx Xxxxx, xxxx xx xxxx xxxx xx Xxx Xxxxx" xx "Xxxx xx xxxx xxxx xx Xxxx Xxxxx xx Xxxxxxxxx xxxxx".

    <span codelanguage="XML"></span>
```    XML
    <colgroup>
    <col width="100%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">XML</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
<ListenFor RequireAppName="BeforeOrAfterPhrase">show [my] next trip to {destination} </ListenFor></code></pre></td>
    </tr>
    </tbody>
    </table>
```

4.  **XxxxxxxxxxXxxxxxxxx**

    Xxxxxxxxx xxxx xxxxx xxxx xxx xxxx xxx xxxx xxxxxxx xxxxx xxx xxxxxxx xx xxx xxxxxxx xxxxxx. Xxx xxxx xx xxx xxxxxxxx xx xxx xxx xxx xxxx xxxxxx xxxxxx xx xxxxx xxx xxxxxx.

    Xxx xxxx xxxxxxxxxx xxxxxxxxx xxxx xxx xxxx xxxxx xxx **{xxxxxxx:XxxXxxx}** xxx.

    Xxxx, Xxxxxxx xxxxxxx xxx xxxxxxxx xxxx "Xxxxxxxxx Xxxxx, xxxx xx xxxx xxxx xx Xxx Xxxxx" xx "Xxxx xx xxxx Xxxxxxxxx Xxxxx xxxx xx Xxx Xxxxx".

    <span codelanguage="XML"></span>
```    XML
    <colgroup>
    <col width="100%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">XML</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
<ListenFor RequireAppName="ExplicitlySpecified">show [my] next {builtin:AppName} trip to {destination} </ListenFor></code></pre></td>
    </tr>
    </tbody>
    </table>
```

## <span id="Special_cases">
            </span>
            <span id="special_cases">
            </span>
            <span id="SPECIAL_CASES">
            </span>Xxxxxxx xxxxx


Xxxx xxx xxxxxxx x **XxxxxxXxx** xxxxxxx xxxxx **XxxxxxxXxxXxxx** xx xxxxxx "XxxxxXxxxxx" xx "XxxxxxxxxxXxxxxxxxx", xxx xxxx xxxxxx xxxxxxx xxxxxxxxxxxx xxx xxx:

1.  **{xxxxxxx:XxxXxxx}** xxxx xxxxxx xxxx xxx xxxx xxxx xxxx **XxxxxxxXxxXxxx** xx "XxxxxxxxxxXxxxxxxxx".

    Xxxx xxxx xxxxx, xxx xxxxxx xxxxxx xxxxx xxxxx xxx xxx xxxx xxx xxxxxx xx xxx xxxxx xxxxxxx. Xxx xxxx xxxxxxxxxx xxxxxxx xxx xxxxxxxx.

2.  Xxx xxxxxx xxxx x xxxxx xxxxxxx xxxxx xxxx x **XxxxxxXxxxx** xxxxxxx, xxxxx xx xxxxxxxxx xxxx xxx xxxxx xxxxxxxxxx xxxxxx xxxxxxxxxxx. Xx xxxxx xxx xxxx xxxx xxxxxxx xx.

    Xxxx xxxxx xx xxxxxxxx xxx xxxxxx xxxx **Xxxxxxx** xxxxxxxx xxxx xxx xx x xxxxxxx xxxxxxxx xxxx xxx xxxx, xx xxxx xx xx, xxxxxxxx xx xxx xxxxxxxxx.

    Xxxx xx xx xxxxxxx xxxxxxxxxxx xxxx xxxxx xxxx xx **Xxxxxxx** xxxxxxxxx xxx **Xxxxxxxxx Xxxxx** xxx xx xxx xxxx xxxx xxxxxxxxx xxxx "Xxxx xx xxxxxxx xxx Xxxxxx xxxxxxxxx xxxxx".

    <span codelanguage="XML"></span>
```    XML
    <colgroup>
    <col width="100%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">XML</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
<ListenFor RequireAppName="ExplicitlySpecified">{searchPhrase} {builtin:AppName}</ListenFor></code></pre></td>
    </tr>
    </tbody>
    </table>
```

3.  Xxxxx xxxx xx xx xxxxx xxx xxxxx xx xxx **XxxxxxXxx** xxxxxx xxxxxxx xxxx xxx xxxx xxx xxxxxxxxxx xx **XxxxxxXxxxx** xxxxxxxx.

    Xxxxxxx xx xxxx Y, xxx xxxx xx xxxxxx xxxx xxxxxxxx xxxxxxx xxxxxxxxxx xxxxxxxx xxxxxxx xx xxxxxxxx xxx xxxxxxx xxxx xxx xx xxxxxxxx xxxxxxxxxxxxxxx.

    Xxxx xxxxx xxx xxx xx xxxx xxxxxxxxxxx xxx xxxx xxxxxxxx xxxxxxx xx xxxx xxxxxxxxxxx xxxx xxx xxx xxxxxxxxxxx xxxxxxxx xxxx xxxx xxxx xxx xxxxxxx “Xxxx Xxxxxx Xxxxxxxxx xxxxx”.

    Xxxx xxx xxxxxxx xxxxxxxxxxxx xxxx xxxxx xxxx xx **Xxxxxxx** xxxxxxxxx xxx **Xxxxxxxxx Xxxxx** xxx xx xxx xxxx xxxx xxxxxxxxx xxxx "Xxx xxxxxxxxx xxxxx" xx "Xxxx Xxxxxx xxxxxxxxx xxxxx".

    <span codelanguage="XML"></span>
```    XML
    <colgroup>
    <col width="100%" />
    </colgroup>
    <thead>
    <tr class="header">
    <th align="left">XML</th>
    </tr>
    </thead>
    <tbody>
    <tr class="odd">
<ListenFor RequireAppName="ExplicitlySpecified">Hey {builtin:AppName}</ListenFor>
    <ListenFor RequireAppName="ExplicitlySpecified">Find {searchPhrase} {builtin:AppName}</ListenFor>
```

## <span id="Remarks">
            </span>
            <span id="remarks">
            </span>
            <span id="REMARKS">
            </span>Xxxxxxx


Xxxxxxxxxx xxxx xxxxxxxxx xx xxx x xxxxx xxxxxxx xxx xx xxxxxxx xx x xxxx xx **Xxxxxxx** xxxx xxxxxxxxx xxx xxxxxxx xxxxxxxxx xx xxxx xxx.

Xxxxx xxxxxx "Xxx \[xxx xxxx\]" xx xxxx **XxxXxxx** xx **XxxxxxxXxxxxx**. Xxxxx xxx xxxx xxxx xxxxxx xx xxx "Xxx Xxxxxxx" xx xxxxxx Xxxxxxx xxxxxxx xxxxx xxxxxxxxxx, xxx xxxxxx "Xxx \[xxx xxxx\]" xx xxx xxxxxxxxx xxxx xxx xxxxx xxxxxxx. Xxx xxxxxxx, "Xxx Xxxxxxx, xxxx xx xxxx xxxx xx Xxx Xxxxx xx Xxx Xxxxxxxxx Xxxxx".

Xxxxxxxx xxxxxx xxxxx/xxxxxx xxxxxxxxxx xx xxxx xxxxxxxx xxxxx xxxxxxxx. Xx xx'xx xxxxx xxxx, xx xxxxx'x xxxxxxx x xxx xx xxxxxx xx xxx xx xxxxxxxxxx xxxxxxxxx xx xxxx xxxxxxxx **XxxxxxXxx** xxxxxxxx xxx xxxxxxx xxxxxx xxxxxxxx. Xx xxxxx x xxx xxxx xxxxxxx xx xxx "Xxx Xxxxxxx, xxxx xx xxxx xxxx xx Xxx Xxxxx xx Xxxxxxxxx xxxxx" xxxx "Xxx Xxxxxxx, Xxxxxxxxx Xxxxx, xxxx xx xxxx xxxx xx Xxx Xxxxx".

Xxxxxxxx xxxxx xxxx xxx xxxx xx x xxxxxx xx xxxxx xxxxx xxx xxxxx xxxxxxx xxxxxxxxx xxxx xxxxxxxx **Xxxxxxx** xxxxxxxxxxxxx (xxxxxxx, xxxxxxxxx, xxx xx xx). Xxx xxxxxxx, "Xxxxxxxxx Xxxxx, xxxxxxx \[xxxxxx xxxxx\] xxxxx Xxx Xxxxx xxxx".

## <span id="Complete_example">
            </span>
            <span id="complete_example">
            </span>
            <span id="COMPLETE_EXAMPLE">
            </span>Xxxxxxxx xxxxxxx


Xxxx xx x XXX xxxx xxxx xxxxxxxxxxxx xxxxxxx xxxx xx xxxxxxx xxxx xxxxxxx xxxxxxxx xxxxx xxxxxxxx.

**Xxxx**  Xx xx xxxxx xx xxxx xxxxxxxx **XxxxxxXxx** xxxxxxxx, xxxx xxxx x xxxxxxxxx **XxxxxxxXxxXxxx** xxxxxxxxx xxxxx.

 

```XML
<?xml version="1.0" encoding="utf-8"?>
<VoiceCommands xmlns="http://schemas.microsoft.com/voicecommands/1.1">
  <CommandSet xml:lang="en-us" Name="commandSet_en-us">
    <AppName>Adventure Works</AppName>
    <Example> When is my trip to Las Vegas? </Example>
    <Command Name="whenIsTripToDestination">
      <Example> When is my trip to Las Vegas?</Example>
      <ListenFor RequireAppName="BeforePhrase">
        when is my] trip to {destination} </ListenFor>

      <!-- This ListenFor command will set up Cortana to accept commands like 
           “Show my next trip to Las Vegas on Adventure Works”; “Show my next 
           trip to Las Vegas using Adventure Works” -->
      <ListenFor RequireAppName="AfterPhrase">
        show [my] next trip to {destination} </ListenFor>

      <!-- This ListenFor command will set up Cortana to accept commands when 
           the user specifies your app name either before or after the command. 
           “Adventure Works, show my next trip to Las Vegas”; 
           “Show my next trip to Last Vegas on Adventure works” -->
      <ListenFor RequireAppName="BeforeOrAfterPhrase">
        show [my] next trip to {destination} </ListenFor>

      <!-- This ListenFor command will set up Cortana to accept commands 
           when the user specifies your app name inline. 
           “Show my next Adventure Works trip to Las Vegas” -->
      <ListenFor RequireAppName="ExplicitlySpecified">
        show [my] next {builtin:AppName} trip to {destination} </ListenFor>

      <Feedback> Looking for trip to {destination} </Feedback>
      <Navigate />
    </Command>
    <PhraseList Label="destination">
      <Item> Las Vegas </Item>
      <Item> Dallas </Item>
      <Item> New York </Item>
    </PhraseList>
  </CommandSet>
  <!-- Other CommandSets for other languages -->
</VoiceCommands>
```

## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx


**Xxxxxxxxxx**
* [Xxxxxxx xxxxxxxxxxxx](cortana-interactions.md)
* [Xxxxxx xxxxxx xxxxxxxxxxx xxxxxxxxxxx](define-custom-recognition-constraints.md)
* [**XXX xxxxxxxx xxx xxxxxxxxxx xY.Y**](https://msdn.microsoft.com/library/windows/apps/dn706593)

**Xxxxxxxxx**
* [Xxxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn974233)
* [Xxxxxx xxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn596121)

**Xxxxxxx**
* [Xxxxxxx xxxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=619899)
 

 




<!--HONumber=Mar16_HO1-->
