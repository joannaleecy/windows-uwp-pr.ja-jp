---
Description: Windows 10, version 1511 and updates to developer tools continue to provide the tools, features, and experiences powered by the Universal Windows Platform.
title: What is new for developers in Windows 10, version 1511: November 2015
---

# What's new for developers in Windows 10, version 1511: November 2015

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Windows 10, version 1511 and updates to developer tools continue to provide the tools, features, and experiences powered by the Universal Windows Platform. [Install the tools and SDK](https://dev.windows.com/downloads) on Windows 10, version 1511 and you’re ready to either [create a new Universal Windows app](https://msdn.microsoft.com/library/windows/apps/bg124288) or explore how you can use your [existing app code on Windows](https://msdn.microsoft.com/library/windows/apps/mt238321).

## User Experience

The new <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.startscreen.aspx">Windows.UI.StartScreen.JumpList</a> and <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.startscreen.aspx">Windows.UI.StartScreen.JumpListItem</a>  classes provide apps with the ability to programmatically select the type of system-managed jump list they want to use, to add custom task entry points to their jump list, and to add custom groups to their jump list.

## Input
                                        
* <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.input.keyboarddeliveryinterceptor.aspx">Keyboard delivery interceptor</a>
                                        
    Enables an app to override the system processing of raw keyboard input, including shortcut keys, access keys (or hot keys), accelerator keys, and application keys, but excluding secure attention sequence (SAS) key combinations.

    Secure attention sequence (SAS) key combinations, including Ctrl-Alt-Del and Windows-L, continue to be processed by the system.
                                        
* Cross-process chaining of pointer input for both <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.core.corewindow.aspx">UWP apps</a> and <a href="https://msdn.microsoft.com/library/windows/desktop/hh454903(v=vs.85).aspx">Classic Windows apps</a>.
                                        
    New pointer events that enable cross-process chaining of input.    
                                        
* <a href="https://msdn.microsoft.com/library/windows/desktop/mt622165(v=vs.85).aspx">Ink Presenter for Classic Desktop apps</a>
                                        
    The ink presenter APIs enable Microsoft Win32 apps to manage the input, processing, and rendering of ink input (standard and modified) through an <a href="https://msdn.microsoft.com/library/windows/desktop/windows.ui.input.inking.inkpresenter.aspx">InkPresenter</a> object inserted into the app's <a href="https://msdn.microsoft.com/library/windows/desktop/hh437371(v=vs.85).aspx">DirectComposition</a> visual tree.    
                                    
## Networking
                                                                        
For WebSockets users: <a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.streams.datawriter.flushasync.aspx">MessageWebSocket.OutputStream.FlushAsync</a> and <a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.streams.datawriter.flushasync.aspx">StreamWebSocket.OutputStream.FlushAsync</a> have been fully implemented, and wait for previously-issued WriteAsync calls to complete. Note that this may cause existing code to throw an exception if the WebSocket is in an invalid state when you call <a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.streams.datawriter.flushasync.aspx">FlushAsync</a>.    

A new property <a href="https://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx">CookieUsageBehavior</a> was added to the existing <a href="https://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx">Windows.Web.Http.Filters.HttpBaseProtocolFilter class</a>. This allows developers to have control of how cookies are handled by the system.    
                                    
## ORTC
                                    
Microsoft Edge now implements <a href="https://msdn.microsoft.com/library/mt433097(v=vs.85).aspx">ORTC (Object Real-Time Communications)</a> enabling real-time audio/video calls on the web directly between browsers, mobile devices, and servers via native Javascript APIs. Developers can now build advanced real-time audio/video communication applications on top of the Microsoft Edge browser using the ORTC API, with support for group video calls, simulcast, scalable video coding (SVC), and more.    

For a demo of a 1:1 audio/video call via the ORTC API between Microsoft Edge browsers, visit <a href="/microsoft-edge/testdrive/demos/ortcdemo/">Test Drive sites and demos</a>. For an overview and code sample walk-through, visit the <a href="https://msdn.microsoft.com/library/mt588497(v=vs.85).aspx">ORTC Developer Guide entry</a>.
                                        
## Microsoft Edge F12 Developer Tools
                                                                        
Microsoft Edge introduces great new improvements to F12 developer tools, including some of the most requested features from <a href="https://wpdev.uservoice.com/forums/257854-microsoft-edge-developer">UserVoice</a>. Explore new features in the DOM Explorer, Console, Debugger, Network, Performance, Memory, Emulation, and a new Experiments tool, that allows you to try out powerful new features before they're finished. The new tools are built in TypeScript, and are always running, so no reloads are required. In addition, F12 developer tools documentation is now part of the <a href="http://dev.modern.ie/">Microsoft Edge Dev site</a> and fully available on <a href="https://github.com/MicrosoftEdge/MicrosoftEdge-Documentation">GitHub</a>. From this point on, the docs will not only be influenced by your feedback, but you're invited to contribute and help shape our documentation. For a brief video introduction to the F12 developer tools, visit <a href="https://channel9.msdn.com/Blogs/One-Dev-Minute/Microsoft-Edge-F12-tools">Channel9’s One Dev Minute</a>.    
                                    
## Windows Hello
                                    
Windows Hello provides your app the ability to enable facial or fingerprint recognition to log on to a Windows system or device.

The Providers APIs allow IHVs and OEMs to expose depth, infrared, and color cameras (and related metadata) for computer vision into UWP, and to designate a camera as participating in Windows Hello face authentication. The <a href="http://go.microsoft.com/fwlink/?LinkId=691697">Windows.Devices.Perception</a> namespace contains the client APIs that allow a UWP application to access the color, depth, or infrared data of computer vision cameras.
                                    
## New Gaming API

Use the new Windows.Gaming.UI.GameBar class to receive notifications when Game bar is shown or dismissed.    
                            
                                    
## Bluetooth APIs
                                    
Several APIs were added and updated to extend support for Bluetooth LE, device enumeration, and other features in Bluetooth. See <a href="https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.aspx">Windows.Devices.Bluetooth</a> namespace .    
                                   
## Smart Card APIs ## 

Several SmartCardCryptogram APIs were added to the <a href="https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.aspx">Windows.Devices.SmartCards</a> namespace to support secure cryptogram payment protocols. Payment apps using host card emulation to support tap-to-pay can use these APIs for additional security and performance. Apps can create a key and protect limited-use transaction keys using the TPM. Apps can also leverage the NGC (Next Generation Credentials) framework to protect the keys with the user’s PIN. These APIs delegate cryptogram generation to the system for enhanced performance. This also prevents any access to the keys and cryptograms by other apps.    
                                    
## Updated Storage APIs ## 
    
<a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.downloadsfolder.aspx">Windows.Storage.DownloadsFolder class</a><br />
Your app can now <a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.downloadsfolder.createfileforuserasync.aspx">create a file</a> or <a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.downloadsfolder.createfolderforuserasync.aspx">create a folder</a> inside the Downloads folder for a specific <a href="https://msdn.microsoft.com/library/windows/apps/windows.system.user.aspx">User</a>.
                                            
<a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.storagelibrary.aspx">Windows.Storage.StorageLibrary class</a><br />
Your app can now <a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.storagelibrary.getlibraryforuserasync.aspx">get a specified Library</a> for a specific <a href="https://msdn.microsoft.com/library/windows/apps/windows.system.user.aspx">User</a>.
                                    
## Windows App Certification Kit ## 
                                    
The Windows App Certification Kit has been updated with improved tests. For a complete list of updates, visit the <a href="/develop/app-certification-kit">Windows App Certification Kit</a> page.    
                                    
## Design downloads ## 

Check out our new UWP app design templates for Adobe Photoshop. We also updated our Microsoft PowerPoint and Adobe Illustrator templates and made a PDF version of our guidelines available. <a href="/design/assets">Visit the Design downloads page</a>.    




<!--HONumber=Mar16_HO5-->


