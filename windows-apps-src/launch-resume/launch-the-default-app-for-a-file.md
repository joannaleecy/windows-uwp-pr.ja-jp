---
xxxxx: Xxxxxx xxx xxxxxxx xxx xxx x xxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxx xxxxxxx xxx xxx x xxxx.
xx.xxxxxxx: XXYYXXXX-XXYY-YXYY-XYXY-YYXYYYXYXXYY
---

# Xxxxxx xxx xxxxxxx xxx xxx x xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.Xxxxxx.Xxxxxxxx.XxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701461)

Xxxxx xxx xx xxxxxx xxx xxxxxxx xxx xxx x xxxx. Xxxx xxxx xxxx xx xxxx xxxx xxxxx xxxx xxxx xxx'x xxxxxx xxxxxxxxxx. Xxx xxxxxxx, x-xxxx xxxx xxxxxxx x xxxxxxx xx xxxx xxxxx xxx xxxx x xxx xx xxxxxx xxxxx xxxxx xx xxxxx xxxxxxx xxxxxxxx. Xxxxx xxxxx xxxx xxx xx xxx xxx [**Xxxxxxx.Xxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241801) XXX xx xxxxxx xxx xxxxxxx xxxxxxx xxx x xxxx xxxx xxxx xxx xxx'x xxxxxx xxxxxx.

## Xxx xxx xxxx xxxxxx


Xxxxx, xxx x [**Xxxxxxx.Xxxxxxx.XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxxx xxx xxx xxxx.

Xx xxx xxxx xx xxxxxxxx xx xxx xxxxxxx xxx xxxx xxx, xxx xxx xxx xxx [**Xxxxxxx.XxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224681) xxxxxxxx xx xxx x [**Xxxxxxx.Xxxxxxx.XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xxxxxx xxx xxx [**Xxxxxxx.Xxxxxxx.XxxxxxxXxxxxx.XxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227272) xxxxxx xx xxx xxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxxx.

Xx xxx xxxx xx xx x xxxxx xxxxxx, xxx xxx xxx xxx xxxxxxxxxx xx xxx [**Xxxxxxx.Xxxxxxx.XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227151) xxxxx xx xxx x [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227230) xxx xxx [**XxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227272) xxxxxx xx xxx xxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171) xxxxxx.

## Xxxxxx xxx xxxx


Xxxxxxx xxxxxxxx xxxxxxx xxxxxxxxx xxxxxxx xxx xxxxxxxxx xxx xxxxxxx xxxxxxx xxx x xxxx. Xxxxx xxxxxxx xxx xxxxxxxxx xx xxxx xxxxx xxx xx xxx xxxxxxxx xxxx xxxxxx.

| Xxxxxx | Xxxxxx | Xxxxxxxxxxx |
|----------------------------------------|-------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Xxxxxxx xxxxxx | [**XxxxxxXxxxXxxxx(XXxxxxxxXxxx)**](https://msdn.microsoft.com/library/windows/apps/hh701471) | Xxxxxx xxx xxxxxxxxx xxxx xxxx xxx xxxxxxx xxxxxxx. |
| Xxxx Xxxx xxxxxx | [**XxxxxxXxxxXxxxx(XXxxxxxxXxxx, XxxxxxxxXxxxxxx)**](https://msdn.microsoft.com/library/windows/apps/hh701465) | Xxxxxx xxx xxxxxxxxx xxxx xxxxxxx xxx xxxx xxxx xxx xxxxxxx xxxxxxx xxx Xxxx Xxxx xxxxxx. |
| Xxxxxx xxxx x xxxxxxxxxxx xxx xxxxxxxx | [**XxxxxxXxxxXxxxx(XXxxxxxxXxxx, XxxxxxxxXxxxxxx)**](https://msdn.microsoft.com/library/windows/apps/hh701465) | Xxxxxx xxx xxxxxxxxx xxxx xxxx xxx xxxxxxx xxxxxxx. Xx xx xxxxxxx xx xxxxxxxxx xx xxx xxxxxx, xxxxxxxxx xx xxx xx xxx xxxxx xx xxx xxxx. |
| Xxxxxx xxxx x xxxxxxx xxxxxxxxx xxxx | [
            **XxxxxxXxxxXxxxx(XXxxxxxxXxxx, XxxxxxxxXxxxxxx)**](https://msdn.microsoft.com/library/windows/apps/hh701465) (Xxxxxxx-xxxx) | Xxxxxx xxx xxxxxxxxx xxxx xxxx xxx xxxxxxx xxxxxxx. Xxxxxxx x xxxxxxxxxx xx xxxx xx xxxxxx xxxxx xxx xxxxxx xxx xxxxxxx x xxxxxxxx xxxxxx xxxx. |
|  |  |  |
|  |  | **Xxxxxx xxxxxx xxxxxx:  **[**XxxxxxxxXxxxxxx.XxxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn298314) xxx'x xxxxxxxxx xx xxx xxxxxx xxxxxx xxxxxx. |

 
### Xxxxxxx xxxxxx

Xxxx xxx [**Xxxxxxx.Xxxxxx.Xxxxxxxx.XxxxxxXxxxXxxxx(XXxxxxxxXxxx)**](https://msdn.microsoft.com/library/windows/apps/hh701471) xxxxxx xx xxxxxx xxx xxxxxxx xxx. Xxxx xxxxxxx xxxx xxx [**Xxxxxxx.Xxxxxxx.XxxxxxxXxxxxx.XxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br227272) xxxxxx xx xxxxxx xx xxxxx xxxx, xxxx.xxx, xxxx xx xxxxxxxx xx xxx xxx xxxxxxx.


> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```vb
> async Sub DefaultLaunch()
>    ' Path to the file in the app package to launch
>    Dim imageFile = "images\test.png"
>    Dim file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile)
>    
>    If file IsNot Nothing Then
>       ' Launch the retrieved file
>       Dim success = await Windows.System.Launcher.LaunchFileAsync(file)
> 
>       If success Then
>          ' File launched
>       Else
>          ' File launch failed
>       End If
>    Else
>       ' Could not find file
>    End If
> End Sub
> ```
> ```cpp
> void MainPage::DefaultLaunch()
> {
>    auto installFolder = Windows::ApplicationModel::Package::Current->InstalledLocation;
> 
>    concurrency::task<Windows::Storage::StorageFile^> getFileOperation(installFolder->GetFileAsync("images\\test.png"));
>    getFileOperation.then([](Windows::Storage::StorageFile^ file)
>    {
>       if (file != nullptr)
>       {
>          // Launch the retrieved file
>          concurrency::task<bool> launchFileOperation(Windows::System::Launcher::LaunchFileAsync(file));
>          launchFileOperation.then([](bool success)
>          {
>             if (success)
>             {
>                // File launched
>             }
>             else
>             {
>                // File launch failed
>             }
>          });
>       }
>       else
>       {
>          // Could not find file
>       }
>    });
> }
> ```
> ```cs
> async void DefaultLaunch()
> {
>    // Path to the file in the app package to launch
>    string imageFile = @"images\test.png";
>    
>    var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);
>    
>    if (file != null)
>    {
>       // Launch the retrieved file
>       var success = await Windows.System.Launcher.LaunchFileAsync(file);
> 
>       if (success)
>       {
>          // File launched
>       }
>       else
>       {
>          // File launch failed
>       }
>    }
>    else
>    {
>       // Could not find file
>    }
> }
> ```

### Xxxx Xxxx xxxxxx

Xxxx xxx [**Xxxxxxx.Xxxxxx.Xxxxxxxx.XxxxxxXxxxXxxxx(XXxxxxxxXxxx, XxxxxxxxXxxxxxx)**](https://msdn.microsoft.com/library/windows/apps/hh701465) xxxxxx xxxx [**XxxxxxxxXxxxxxx.XxxxxxxXxxxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701438) xxx xx **xxxx** xx xxxxxx xxx xxx xxxx xxx xxxx xxxxxxx xxxx xxx **Xxxx Xxxx** xxxxxx xxx.

Xx xxxxxxxxx xxxx xxx xxx xxx **Xxxx Xxxx** xxxxxx xxx xxxx xxx xxxx xxx xxxx xx xxxxxx xx xxx xxxxx xxxx xxx xxxxxxx xxx x xxxxxxxxxx xxxx. Xxx xxxxxxx, xx xxxx xxx xxxxxx xxx xxxx xx xxxxxx xx xxxxx xxxx, xxx xxxxxxx xxxxxxx xxxx xxxxxx xx x xxxxxx xxx. Xx xxxx xxxxx, xxx xxxx xxx xxxx xx xxxx xxx xxxxx xxxxxxx xx xxxxxxx xx. Xxx xxx **Xxxx Xxxx** xxxxxx xxxxx xxxx xx xxxxxxxxxxx xxxxxxx xx xxx **XxxXxx** xx xx x xxxxxxx xxxx xx xxx xxx xxxx xxxxx xx xxx **Xxxx Xxxx** xxxxxx xxx xxxxxx xxx xxxxxx xxx xx xxxxx xxxxx xx xxxxxxxxx.

![xxx xxxx xxxx xxxxxx xxx x .xxx xxxx xxxxxx. xxx xxxxxx xxxxxxxx x xxxxxxxx xxxxx xxxxxxxxx xx xxx xxxx’x xxxxxx xxxxxx xx xxxx xxx xxx .xxx xxxxx xx xxxx xxxx xxx .xxx xxxx. xxx xxxxxx xxxxxxxx xxxx xxx xxxxxxx xxx xxxxxxxxx xxx xxxx xxx x ‘xxxx xxxxxxx’ xxxx.](images/checkboxopenwithdialog.png)

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```vb
> async Sub DefaultLaunch()
> 
>    ' Path to the file in the app package to launch
>    Dim imageFile = "images\test.png"
> 
>    Dim file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile)
> 
>    If file IsNot Nothing Then
>       ' Set the option to show the picker
>       Dim options = Windows.System.LauncherOptions()
>       options.DisplayApplicationPicker = True
> 
>       ' Launch the retrieved file
>       Dim success = await Windows.System.Launcher.LaunchFileAsync(file)
> 
>       If success Then
>          ' File launched
>       Else
>          ' File launch failed
>       End If
>    Else
>       ' Could not find file
>    End If
> End Sub
> ```
> ```cpp
> void MainPage::DefaultLaunch()
> {
>    auto installFolder = Windows::ApplicationModel::Package::Current->InstalledLocation;
> 
>    concurrency::task<Windows::Storage::StorageFile^> getFileOperation(installFolder->GetFileAsync("images\\test.png"));
>    getFileOperation.then([](Windows::Storage::StorageFile^ file)
>    {
>       if (file != nullptr)
>       {
>          // Set the option to show the picker
>          auto launchOptions = ref new Windows::System::LauncherOptions();
>          launchOptions->DisplayApplicationPicker = true;
> 
>          // Launch the retrieved file
>          concurrency::task<bool> launchFileOperation(Windows::System::Launcher::LaunchFileAsync(file, launchOptions));
>          launchFileOperation.then([](bool success)
>          {
>             if (success)
>             {
>                // File launched
>             }
>             else
>             {
>                // File launch failed
>             }
>          });
>       }
>       else
>       {
>          // Could not find file
>       }
>    });
> }
> ```
> ```cs
> async void DefaultLaunch()
> {
>    // Path to the file in the app package to launch
>       string imageFile = @"images\test.png";
>       
>    var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);
> 
>    if (file != null)
>    {
>       // Set the option to show the picker
>       var options = new Windows.System.LauncherOptions();
>       options.DisplayApplicationPicker = true;
> 
>       // Launch the retrieved file
>       bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
>       if (success)
>       {
>          // File launched
>       }
>       else
>       {
>          // File launch failed
>       }
>    }
>    else
>    {
>       // Could not find file
>    }
> }
> ```

**Xxxxxx xxxx x xxxxxxxxxxx xxx xxxxxxxx**

Xx xxxx xxxxx xxx xxxx xxx xxx xxxx xx xxx xxxxxxxxx xx xxxxxx xxx xxxx xxxx xxx xxx xxxxxxxxx. Xx xxxxxxx, Xxxxxxx xxxx xxxxxx xxxxx xxxxx xx xxxxxxxxx xxx xxxx xxxx x xxxx xx xxxxxx xxx xx xxxxxxxxxxx xxx xx xxx xxxxx. Xx xxx xxxxx xxxx xx xxxx xxx xxxx x xxxxxxxx xxxxxxxxxxxxxx xxx xxxxx xxx xx xxxxxxx xx xxxx xxxxxxxx, xxx xxx xx xx xx xxxxxxx xxxx xxxxxxxxxxxxxx xxxxx xxxx xxx xxxx xxxx xxx xxx xxxxxxxxx. Xx xx xxxx, xxxx xxx [**Xxxxxxx.Xxxxxx.Xxxxxxxx.xxxxxxXxxxXxxxx(XXxxxxxxXxxx, XxxxxxxxXxxxxxx)**](https://msdn.microsoft.com/library/windows/apps/hh701465) xxxxxx xxxx [**XxxxxxxxXxxxxxx.XxxxxxxxxXxxxxxxxxxxXxxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh965482) xxx xx xxx xxxxxxx xxxxxx xxxx xx xxx xxx xx xxx Xxxxx xxxx xxx xxxx xx xxxxxxxxx. Xxxx, xxx xxx [**XxxxxxxxXxxxxxx.XxxxxxxxxXxxxxxxxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh965481) xx xxx xxxx xx xxxx xxx. Xxxxxxx xxxx xxx xxxx xxxxxxxxxxx xx xxxxxxx xxx xxxxxxx xxxxxx xx xxxxxx xxx xx xxx xx xxx xxxxx xxxx x xxxxxxxx xxxxxx xx xxxxxxx xxx xxxxxxxxxxx xxx xxxx xxx Xxxxx.

> **Xxxx**  Xxx xxxx xxx xxxx xx xxxxx xxxxxxx xx xxxxxxxxx xx xxx. Xxxxxxx xxx xxxxxxx xxx xxxxx xxxx xxxxxx xx x xxxxxxx.

![xxx xxxx xxxx xxxxxx xxx x .xxxxxxx xxxx xxxxxx. xxxxx .xxxxxxx xxxx xxx xxxx x xxxxxxx xxxxxxxxx xx xxx xxxxxxx xxx xxxxxx xxxxxxxx xx xxxxxx xxxx xxx xxxxx xxxx xxx xxxx xxxxx xxxxxx xxx xxxx xx xxx xxxxxxx xxxxxxx xx xxx xxxxx. xxx xxxxxx xxxx xxxxxxxx x ‘xxxx xxxxxxx’ xxxx'.](images/howdoyouwanttoopen.png)


> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```vb
> async Sub DefaultLaunch()
> 
>    ' Path to the file in the app package to launch
>    Dim imageFile = "images\test.contoso"
> 
>    ' Get the image file from the package's image directory
>    Dim file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile)
> 
>    If file IsNot Nothing Then
>       ' Set the recommended app
>       Dim options = Windows.System.LauncherOptions()
>       options.PreferredApplicationPackageFamilyName = "Contoso.FileApp_8wknc82po1e";
>       options.PreferredApplicationDisplayName = "Contoso File App";
> 
>       ' Launch the retrieved file pass in the recommended app 
>       ' in case the user has no apps installed to handle the file
>       Dim success = await Windows.System.Launcher.LaunchFileAsync(file)
> 
>       If success Then
>          ' File launched
>       Else
>          ' File launch failed
>       End If
>    Else
>       ' Could not find file
>    End If
> End Sub
> ```
> ```cpp
> void MainPage::DefaultLaunch()
> {
>    auto installFolder = Windows::ApplicationModel::Package::Current->InstalledLocation;
> 
>    concurrency::task<Windows::Storage::StorageFile^> getFileOperation(installFolder->GetFileAsync("images\\test.contoso"));
>    getFileOperation.then([](Windows::Storage::StorageFile^ file)
>    {
>       if (file != nullptr)
>       {
>          // Set the recommended app
>          auto launchOptions = ref new Windows::System::LauncherOptions();
>          launchOptions-> preferredApplicationPackageFamilyName = "Contoso.FileApp_8wknc82po1e";
>          launchOptions-> preferredApplicationDisplayName = "Contoso File App";
>          
>          // Launch the retrieved file pass in the recommended app 
>          // in case the user has no apps installed to handle the file
>          concurrency::task<bool> launchFileOperation(Windows::System::Launcher::LaunchFileAsync(file, launchOptions));
>          launchFileOperation.then([](bool success)
>          {
>             if (success)
>             {
>                // File launched
>             }
>             else
>             {
>                // File launch failed
>             }
>          });
>       }
>       else
>       {
>          // Could not find file
>       }
>    });
> }
> ```
> ```cs
> async void DefaultLaunch()
> {
>    // Path to the file in the app package to launch
>    string imageFile = @"images\test.contoso";
> 
>    // Get the image file from the package's image directory
>    var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);
> 
>    if (file != null)
>    {
>       // Set the recommended app
>       var options = new Windows.System.LauncherOptions();
>       options.PreferredApplicationPackageFamilyName = "Contoso.FileApp_8wknc82po1e";
>       options.PreferredApplicationDisplayName = "Contoso File App";
> 
> 
>       // Launch the retrieved file pass in the recommended app 
>       // in case the user has no apps installed to handle the file
>       bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
>       if (success)
>       {
>          // File launched
>       }
>       else
>       {
>          // File launch failed
>       }
>    }
>    else
>    {
>       // Could not find file
>    }
> }
> ```

### Xxxxxx xxxx x Xxxxxxx Xxxxxxxxx Xxxx (Xxxxxxx-xxxx)

Xxxxxx xxxx xxxx xxxx [**XxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701461) xxx xxxxxxx xxxx xxxx xxxxxx xx xxxxxx xxxxx x xxxx xxxxxx. Xx xxxxxxx, Xxxxxxx xxxxxxxx xx xxxxx xxx xxxxxxxxx xxxxx xxxxxxx xxxxxxx xxx xxxxxx xxx xxx xxx xxxxxx xxx xxxx xxxxxxx xxx xxxx. Xxxxxx xxxx xxx xxx xxx [**XxxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn298314) xxxxxxxx xx xxxxxxxx xx xxx xxxxxxxxx xxxxxx xxxx xxxx xxxxxx xxxxx xxx xxxxxx xx xxxx xx xxxx xx xxxx xx xxx xxxxxxxxx xxxxx. **XxxxxxxXxxxxxxxxXxxx** xxx xxxx xx xxxx xx xxxxxxxx xxxx xxx xxxxxx xxx xxxx xxx xxxx xx xxxxxx xx xxxxxx xxxxx xxx xxxx xxxxxx xxx xxx xx xxxxxxxxxx xxxxxxxx xx xxx xxxxxx xxx. Xxxx xxxxxxxx xxxx xxxxxxxxx xxx xxxxxxxxx xxxxxx xxxx xx xxx xxxxxxx xxx. Xx xxxxx'x xxxxxxx xxx xxxxxxxx xx xxxxx xxxx xxxx xxx xxxxxx xx xxxx xx xx xxxxxx xx xxx xxxx xxxx.

> **Xxxx**  Xxxxxxx xxxxx xxxx xxxxxxx xxxxxxxx xxxxxxxxx xxxxxxx xxxx xx xxxxxxxxxx xxx xxxxxx xxx'x xxxxx xxxxxx xxxx, xxx xxxxxxx, xxx xxxxxxxxxx xx xxx xxxxxx xxx, xxx xxxxxx xx xxxx xx xxxxxx, xxx xxxxxx xxxxxxxxxxx, xxx xx xx. Xx xxxxxxx [**XxxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn298314), xxx xxxx'x xxxxxxxxxx x xxxxxxxx xxxxxxxxx xxxxxxxx xxx xxx xxxxxx xxx.

**Xxxxxx xxxxxx xxxxxx:  **[**XxxxxxxxXxxxxxx.XxxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn298314) xxx'x xxxxxxxxx xx xxx xxxxxx xxxxxx xxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
> ```cpp
> void MainPage::DefaultLaunch()
> {
>    auto installFolder = Windows::ApplicationModel::Package::Current->InstalledLocation;
> 
>    concurrency::task<Windows::Storage::StorageFile^> getFileOperation(installFolder->GetFileAsync("images\\test.png"));
>    getFileOperation.then([](Windows::Storage::StorageFile^ file)
>    {
>       if (file != nullptr)
>       {
>          // Set the desired remaining view
>          auto launchOptions = ref new Windows::System::LauncherOptions();
>          launchOptions->DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;
> 
>          // Launch the retrieved file
>          concurrency::task<bool> launchFileOperation(Windows::System::Launcher::LaunchFileAsync(file, launchOptions));
>          launchFileOperation.then([](bool success)
>          {
>             if (success)
>             {
>                // File launched
>             }
>             else
>             {
>                // File launch failed
>             }
>          });
>       }
>       else
>       {
>          // Could not find file
>       }
>    });
> }
> ```
> ```cs
> async void DefaultLaunch()
> {
>    // Path to the file in the app package to launch
>    string imageFile = @"images\test.png";
>    
>    var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(imageFile);
> 
>    if (file != null)
>    {
>       // Set the desired remaining view
>       var options = new Windows.System.LauncherOptions();
>       options.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;
> 
>       // Launch the retrieved file
>       bool success = await Windows.System.Launcher.LaunchFileAsync(file, options);
>       if (success)
>       {
>          // File launched
>       }
>       else
>       {
>          // File launch failed
>       }
>    }
>    else
>    {
>       // Could not find file
>    }
> }
> ```

## Xxxxxxx

Xxxx xxx xxx'x xxxxxx xxx xxx xxxx xx xxxxxxxx. Xxx xxxx xxxxxxxxxx xxxxx xxx xx xxxxxxxx. Xxx xxxx xxx xxxxxx xxxxxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xx x Xxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx.

Xxxx xxxxxxxxx x xxxx, xxxx xxx xxxx xx xxx xxxxxxxxxx xxx, xxxx xx, xx xxxx xx xxxxxxx xx xxx xxxx. Xxxx xxxxxxxxxxx xxxxx xxxxxx xxxx xxx xxxx xxxxxxx xx xxxxxxx. Xx xxxx xxxx xxxxxxxxxxx, xxxx xxxx xxxx xxx xxx xxx xxxx xxxxxxxx xxxxxxxx xx xxx XX xx xxxx xxx. Xxxx xxxxxx, xxx xxxx xxxx xxxxxx xxxx xxxx xxxxxx xx xxxxxxxx x xxxx xxxxxx.

Xxx xxx'x xxxxxx xxxx xxxxx xxxx xxxxxxx xxxx xx xxxxxx xx xxxx xxx xxxxxxxx xxxxxxxxxxxxx xx xxx xxxxxxxxx xxxxxx, xxxx xx, .xxx, .xxx, xxx .xx xxxxx. Xxxx xxxxxxxxxxx xxxxxxxx xxxxx xxxx xxxxxxxxxxx xxxxxxxxx xxxxx xxxx xxxxx xxxxxx xxx xxxxxxxxx xxxxxx. Xxx xxx xxx xxxx xxxxxx xx xxxxxx xxxx xxxxx xxxx xxx xxxxxxx xxxxxx xx xxxx xxx xxxxxxxx xx xx xxx xxxx xxxxxxxx xxx xxxxxx, xxxx xx, .xxxx xxxxx. Xxxx xxxx Xxxxxxxxx Xxxx xxxx xxx xxxxxx xx .xxxx xxxxx xxxx xxxxxxxxx xxx xxxxxxxxx xxxxxx.

Xx xxx xxx xx xxxxxx x xxxxxxxxxx xxxx xxxx, xxx xxxxxx xxxx xxxx xxx xxxx xxxxx xxxxxxxx xxxx xx xxxxxxx. Xx xxxx xxx xxxxxxx xxxx xxxxxxxxx xxxxx xx xxxxx xxx xxx xxxxxx xxxx xxx xxxx xxx xxxx xxxxx, xx xxxxxxxxx xxxx xxx xxxxxxx x xxxxxxxx xxxxxxxxxx xx xxxx xxxx. Xxx xxxxxxx, xxx xxxxx xxxx xxx xxxx xx xxxxxx xx xxxx xxx xxxx xx xxx xxxxxxx, xxx xxxx xxxxx xxxx xx xxxxx.

> **Xxxx**  Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx’xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

 
## Xxxxxxx xxxxxx


**Xxxxx**

* [Xxxxxx xxx xxxxxxx xxx xxx x XXX](launch-default-app.md)
* [Xxxxxx xxxx xxxxxxxxxx](handle-file-activation.md)

**Xxxxxxxxxx**

* [Xxxxxxxxxx xxx xxxx xxxxx xxx XXXx](https://msdn.microsoft.com/library/windows/apps/hh700321)

**Xxxxxxxxx**

* [**Xxxxxxx.Xxxxxxx.XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227171)
* [**Xxxxxxx.Xxxxxx.Xxxxxxxx.XxxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701461)

 

 



<!--HONumber=Mar16_HO1-->
