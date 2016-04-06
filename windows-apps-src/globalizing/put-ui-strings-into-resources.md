---
Description: Put string resources for your UI into resource files. You can then reference those strings from your code or markup.
title: Put UI strings into resources
ms.assetid: E420B9BB-C0F6-4EC0-BA3A-BA2875B69722
label: Put UI strings into resources
template: detail.hbs
---

# Put UI strings into resources


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Important APIs**

-   [**ApplicationModel.Resources.ResourceLoader**](https://msdn.microsoft.com/library/windows/apps/br206014)
-   [**WinJS.Resources.processAll**](https://msdn.microsoft.com/library/windows/apps/br211864)

Put string resources for your UI into resource files. You can then reference those strings from your code or markup.

This topic shows the steps to add several language string resources to your Universal Windows app, and how to briefly test it.

## <span id="put_strings_into_resource_files__instead_of_putting_them_directly_in_code_or_markup."></span><span id="PUT_STRINGS_INTO_RESOURCE_FILES__INSTEAD_OF_PUTTING_THEM_DIRECTLY_IN_CODE_OR_MARKUP."></span>Put strings into resource files, instead of putting them directly in code or markup.


1.  Open your solution (or create a new one) in Visual Studio.

2.  Open package.appxmanifest in Visual Studio, go to the **Application** tab, and (for this example) set the Default language to "en-US". If there are multiple package.appxmanifest files in your solution, do this for each one.
    <br>**Note**  This specifies the default language for the project. The default language resources are used if the user's preferred language or display languages do not match the language resources provided in the application.
3.  Create a folder to contain the resource files.
    1.  In the Solution Explorer, right-click the project (the Shared project if your solution contains multiple projects) and select **Add** &gt; **New Folder**.
    2.  Name the new folder "Strings".
    3.  If the new folder is not visible in Solution Explorer, select **Project** &gt; **Show All Files** from the Microsoft Visual Studio menu while the project is still selected.

4.  Create a sub-folder and a resource file for English (United States).
    1.  Right-click the Strings folder and add a new folder beneath it. Name it "en-US". The resource file is to be placed in a folder that has been named for the [BCP-47](http://go.microsoft.com/fwlink/p/?linkid=227302) language tag. See [How to name resources using qualifiers](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324) for details on the language qualifier and a list of common language tags.
    2.  Right-click the en-US folder and select **Add** &gt; **New Item…**.
    3.  **XAML:** Select "Resources File (.resw)".
        <br>**HTML:** Select "Resources File (.resjson)".

    4.  Click **Add**. This adds a resource file with the default name "Resources.resw" (for **XAML**) or "resources.rejson" (for **HTML**). We recommend that you use this default filename. Apps can partition their resources into other files, but you must be careful to refer to them correctly (see [How to load string resources](https://msdn.microsoft.com/library/windows/apps/xaml/hh965323)).
    5.  **XAML only:** If you have .resx files with only string resources from previous .NET projects, select **Add** &gt; **Existing Item…**, add the .resx file, and rename it to .resw.
    6.  Open the file and use the editor to add these resources:

        **XAML:**

        Strings/en-US/Resources.resw
        ![add resource, english](images/addresource-en-us.png)
        In this example, "Greeting.Text" and "Farewell" identify the strings that are to be displayed. "Greeting.Width" identifies the Width property of the "Greeting" string. The comments are a good place to provide any special instructions to translators who localize the strings to other languages.

        **HTML:**

        The new file contains default content. Replace the content with the following (which may be similar to the default):

        Strings/en-US/resources.resjson

        ```        json
        {
                "greeting"              : "Hello",
                "_greeting.comment"     : "A welcome greeting",

                "farewell"              : "Goodbye",
                "_farewell.comment"     : "A goodbye"
        }
        ```

        This is strict JavaScript Object Notation (JSON) syntax where a comma must be placed after each name/value pair, except the last one. In this sample, "greeting" and "farewell" identify the strings that are to be displayed. The other pairs ("\_greeting.comment" and "\_farewell.comment") are comments that describe the strings. The comments are a good place to provide any special instructions to translators who localize the strings to other languages.

## <span id="associate_controls_to_resources."></span><span id="ASSOCIATE_CONTROLS_TO_RESOURCES."></span>Associate controls to resources.


**XAML only:**

You need to associate every control that needs localized text with the .resw file. You do this using the **x:Uid** attribute on your XAML elements like this:

```XAML
<TextBlock x:Uid="Greeting" Text="" />
```

For the resource name, you give the **Uid** attribute value, plus you specify what property is to get the translated string (in this case the Text property). You can specify other properties/values for different languages such as Greeting.Width, but be careful with such layout-related properties. You should strive to allow the controls to lay out dynamically based on the device's screen.

Note that attached properties are handled differently in resw files such as AutomationPeer.Name. You need to explicitly write out the namespace like this:

```XAML
MediumButton.[using:Windows.UI.Xaml.Automation]AutomationProperties.Name</code></pre></td>
```

## <span id="add_string_resource_identifiers_to_code_and_markup."></span><span id="ADD_STRING_RESOURCE_IDENTIFIERS_TO_CODE_AND_MARKUP."></span>Add string resource identifiers to code and markup.


**XAML:**

In your code, you can dynamically reference strings:

**C#**
```CSharp
var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
var str = loader.GetString("Farewell");
```

**C++**
```ManagedCPlusPlus
auto loader = ref new Windows::ApplicationModel::Resources::ResourceLoader();
auto str = loader->GetString("Farewell");
```

**HTML:**

1.  Add references to the Windows Library for JavaScript to your HTML file, if they aren't already there.

    **Note**  The following code shows the HTML for the default.html file of the Windows project that is generated when you create a new **Blank App (Universal Windows)** JavaScript project in Visual Studio. Note that the file already contains references to the WinJS.

    ```    HTML
    <!-- WinJS references -->
    <link href="WinJS/css/ui-dark.css" rel="stylesheet" />
    <script src="WinJS/js/base.js"></script>
    <script src="WinJS/js/ui.js"></script>
    ```

2.  In the JavaScript code that accompanies your HTML file, call the [**WinJS.Resources.processAll**](https://msdn.microsoft.com/library/windows/apps/br211864) function when your HTML is loaded.

    ```    JavaScript
    WinJS.Application.onloaded = function(){
        WinJS.Resources.processAll();
    }
    ```
    
    If additional HTML is loaded into a [**WinJS.UI.Pages.PageControl**](https://msdn.microsoft.com/library/windows/apps/jj126158) object, call [**WinJS.Resources.processAll**](https://msdn.microsoft.com/library/windows/apps/br211864)(*element*) in the page control's [**IPageControlMembers.ready**](https://msdn.microsoft.com/library/windows/apps/hh770590) method, where *element* is the HTML element (and its child elements) being loaded. This example is based on scenario 6 of the [Application resources and localization sample](http://go.microsoft.com/fwlink/p/?linkid=227301):

    ```    JavaScript
    var output;
    
    var page = WinJS.UI.Pages.define("/html/scenario6.html", {
        ready: function (element, options) {
            output = element.querySelector('#output');
            WinJS.Resources.processAll(output); // Refetch string resources
            WinJS.Resources.addEventListener("contextchanged", refresh, false);
        }
        unload: function () { 
            WinJS.Resources.removeEventListener("contextchanged", refresh, false); 
        } 
    });
    ```

3.  In the HTML, refer to the string resources using the resource identifiers ('greeting' and 'farewell') from the resource files.
    ```    HTML
    <h2><span data-win-res="{textContent: 'greeting';}"></span></h2>
    <h2><span data-win-res="{textContent: 'farewell'}"></span></h2>
    ```

4.  Refer to string resources for attributes.

    ```    HTML
    <div data-win-res="{attributes: {'aria-label'; : 'String1'}}" >
    ```

    The general pattern of the data-win-res attribute for HTML replacement is data-win-res="{*propertyname1*: '*resource ID*', *propertyname2*: '*resource ID2*'}".

    **Note**  If the string does not contain any markup, then bind the resource wherever possible to the textContent property instead of innerHTML. The textContent property is much faster to replace than innerHTML.

5.  Refer to string resources in JavaScript.
    <span codelanguage="JavaScript"></span>
    ```    JavaScript
    var el = element.querySelector('#header');
    var res = WinJS.Resources.getString('greeting');
    el.textContent = res.value;
    el.setAttribute('lang', res.lang);
    ```

## <span id="add_folders_and_resource_files_for_two_additional_languages."></span><span id="ADD_FOLDERS_AND_RESOURCE_FILES_FOR_TWO_ADDITIONAL_LANGUAGES."></span>Add folders and resource files for two additional languages.


1.  Add another folder under the Strings folder for German. Name the folder "de-DE" for Deutsch (Deutschland).
2.  Create another resources file in the de-DE folder, and add the following:

    **XAML:**

    strings/de-DE/Resources.resw

    ![add resource, german](images/addresource-de-de.png)

    **HTML:**

    strings/de-DE/resources.resjson

    ```    json
    {
        "greeting"              : "Hallo",
        "_greeting.comment"     : "A welcome greeting.",

        "farewell"              : "Auf Wiedersehen",
        "_farewell.comment"     : "A goodbye."
    }
    ```

3.  Create one more folder named "fr-FR", for français (France). Create a new resources file and add the following:

    **XAML:**

    strings/fr-FR/Resources.resw
    ![add resource, french](images/addresource-fr-fr.png)
    **HTML:**

    strings/fr-FR/resources.resjson

    ```    json
    {
        "greeting"              : "Bonjour",
        "_greeting.comment"     : "A welcome greeting.",

        "farewell"              : "Au revoir",
        "_farewell.comment"     : "A goodbye."
    }
    ```

## <span id="build_and_run_the_app."></span><span id="BUILD_AND_RUN_THE_APP."></span>Build and run the app.


Test the app for your default display language.

1.  Press F5 to build and run the app.
2.  Note that the greeting and farewell are displayed in the user's preferred language.
3.  Exit the app.

Test the app for the other languages.

1.  Bring up **Settings** on your device.
2.  Select **Time & language**.
3.  Select **Region & language** (or on a phone or phone emulator, **Language**).
4.  Note that the language that was displayed when you ran the app is the top language listed that is English, German, or French. If your top language is not one of these three, the app falls back to the next one on the list that the app supports.
5.  If you do not have all three of these languages on your machine, add the missing ones by clicking **Add a language** and adding them to the list.
6.  To test the app with another language, select the language in the list and click **Set as default** (or on a phone or phone emulator, tap and hold the language in the list and then tap **Move up** until it is at the top). Then run the app.

## <span id="related_topics"></span>Related topics


* [How to name resources using qualifiers](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)
* [How to load string resources](https://msdn.microsoft.com/library/windows/apps/xaml/hh965323)
* [The BCP-47 language tag](http://go.microsoft.com/fwlink/p/?linkid=227302)
 

 





<!--HONumber=Mar16_HO1-->


