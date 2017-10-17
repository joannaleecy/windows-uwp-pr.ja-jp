---
title: Unity for UWP with IL2CPP backend
author: KevinAsgari
description: Add Xbox Live support to Unity for UWP with IL2CPP scripting backend for ID@Xbox and managed partners
ms.assetid: 790a49ad-eff4-4916-8578-968ca8483211
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one, Unity
ms.openlocfilehash: 8caa379683c7ca3961cde28ca11b3c60226fb120
ms.sourcegitcommit: fc695def93ba79064af709253ded5e0bfd634a9c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/25/2017
---
# <a name="add-xbox-live-support-to-unity-for-uwp-with-il2cpp-scripting-backend-for-idxbox-and-managed-partners"></a><span data-ttu-id="fe4b8-104">Add Xbox Live support to Unity for UWP with IL2CPP scripting backend for ID@Xbox and managed partners</span><span class="sxs-lookup"><span data-stu-id="fe4b8-104">Add Xbox Live support to Unity for UWP with IL2CPP scripting backend for ID@Xbox and managed partners</span></span>

## <a name="overview"></a><span data-ttu-id="fe4b8-105">Overview</span><span class="sxs-lookup"><span data-stu-id="fe4b8-105">Overview</span></span>

<span data-ttu-id="fe4b8-106">Windows Runtime Support for IL2CPP in Unity</span><span class="sxs-lookup"><span data-stu-id="fe4b8-106">Windows Runtime Support for IL2CPP in Unity</span></span>

<span data-ttu-id="fe4b8-107">With the release of Unity 5.6f3 the engine has included a new feature that enables developers to use Windows Runtime (WinRT) components directly in script by including them in the game project directly.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-107">With the release of Unity 5.6f3 the engine has included a new feature that enables developers to use Windows Runtime (WinRT) components directly in script by including them in the game project directly.</span></span> <span data-ttu-id="fe4b8-108">Until 5.6 developers have needed a plugin, or dll to support any platform feature (including Xbox Live SDK) from game script in UWP.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-108">Until 5.6 developers have needed a plugin, or dll to support any platform feature (including Xbox Live SDK) from game script in UWP.</span></span> <span data-ttu-id="fe4b8-109">This new projection layer removes the plugin requirement, and introduces a new and simplified workflow supported only with games that choose the IL2CPP scripting backend.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-109">This new projection layer removes the plugin requirement, and introduces a new and simplified workflow supported only with games that choose the IL2CPP scripting backend.</span></span>

<span data-ttu-id="fe4b8-110">For more information on how to get started, see the Unity documentation: https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html</span><span class="sxs-lookup"><span data-stu-id="fe4b8-110">For more information on how to get started, see the Unity documentation: https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html</span></span>

## <a name="steps"></a><span data-ttu-id="fe4b8-111">Steps</span><span class="sxs-lookup"><span data-stu-id="fe4b8-111">Steps</span></span>

**<span data-ttu-id="fe4b8-112">1) Install Unity</span><span class="sxs-lookup"><span data-stu-id="fe4b8-112">1) Install Unity</span></span>**

<span data-ttu-id="fe4b8-113">Install Unity 5.6 or higher, and ensure you have the "Windows Store Il2CPP scripting backend" selected during installation</span><span class="sxs-lookup"><span data-stu-id="fe4b8-113">Install Unity 5.6 or higher, and ensure you have the "Windows Store Il2CPP scripting backend" selected during installation</span></span>

<span data-ttu-id="fe4b8-114">**2) Install Visual Studio Tools for Unity version 3.1 and above for IntelliSense support when using WinMDs** For Visual Studio 2015, this can be found at https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-114">**2) Install Visual Studio Tools for Unity version 3.1 and above for IntelliSense support when using WinMDs** For Visual Studio 2015, this can be found at https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity.</span></span>  <span data-ttu-id="fe4b8-115">For Visual Studio 2017, the component can be added inside the Visual Studio 2017 installer.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-115">For Visual Studio 2017, the component can be added inside the Visual Studio 2017 installer.</span></span>

**<span data-ttu-id="fe4b8-116">3) Open a new or existing Unity project</span><span class="sxs-lookup"><span data-stu-id="fe4b8-116">3) Open a new or existing Unity project</span></span>**

**<span data-ttu-id="fe4b8-117">4) Switch the platform to Windows Store in the Unity Build Settings menu</span><span class="sxs-lookup"><span data-stu-id="fe4b8-117">4) Switch the platform to Windows Store in the Unity Build Settings menu</span></span>**

**<span data-ttu-id="fe4b8-118">5) Enable IL2CPP scripting backend in the Unity player settings, and set API compatibility to .NET 4.6</span><span class="sxs-lookup"><span data-stu-id="fe4b8-118">5) Enable IL2CPP scripting backend in the Unity player settings, and set API compatibility to .NET 4.6</span></span>**

![](../images/unity/unity-il2cpp-1.png)

<span data-ttu-id="fe4b8-119">**6) 最新バージョンの Xbox Live WinRT Unity アセット パッケージをインポートします。**このパッケージは https://github.com/Microsoft/xbox-live-api/releases で入手できます。</span><span class="sxs-lookup"><span data-stu-id="fe4b8-119">**6) Import the latest version of the Xbox Live WinRT Unity asset package** This can be found at https://github.com/Microsoft/xbox-live-api/releases</span></span>

**<span data-ttu-id="fe4b8-120">7) Add and attach a new C\# script to a Unity object.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-120">7) Add and attach a new C\# script to a Unity object.</span></span>**

<span data-ttu-id="fe4b8-121">For example, click on a Unity object such as the "Main Camera", and click "Add Component" \| "New Script" \| C\# Script \| and name it "XboxLiveScript".</span><span class="sxs-lookup"><span data-stu-id="fe4b8-121">For example, click on a Unity object such as the "Main Camera", and click "Add Component" \| "New Script" \| C\# Script \| and name it "XboxLiveScript".</span></span> <span data-ttu-id="fe4b8-122">Any game object will do.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-122">Any game object will do.</span></span>

**<span data-ttu-id="fe4b8-123">8) Open the script in Visual Studio (with VSTU 3.1+ installed)</span><span class="sxs-lookup"><span data-stu-id="fe4b8-123">8) Open the script in Visual Studio (with VSTU 3.1+ installed)</span></span>**

<span data-ttu-id="fe4b8-124">You will notice two projects, open your game script XboxLiveTest.cs in the "Player" project generated by VSTU</span><span class="sxs-lookup"><span data-stu-id="fe4b8-124">You will notice two projects, open your game script XboxLiveTest.cs in the "Player" project generated by VSTU</span></span>

![](../images/unity/unity-il2cpp-2.png)

<span data-ttu-id="fe4b8-125">This is a special project generated for UWP, and includes references for the winmd files you have placed in your assets.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-125">This is a special project generated for UWP, and includes references for the winmd files you have placed in your assets.</span></span>
<span data-ttu-id="fe4b8-126">It will also define the "#if ENABLE_WINMD_SUPPORT" define for you so IntelliSense and syntax highlighting will work properly.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-126">It will also define the "#if ENABLE_WINMD_SUPPORT" define for you so IntelliSense and syntax highlighting will work properly.</span></span>

**<span data-ttu-id="fe4b8-127">9) Add the following Xbox Live code to the XboxLiveTest.cs source file</span><span class="sxs-lookup"><span data-stu-id="fe4b8-127">9) Add the following Xbox Live code to the XboxLiveTest.cs source file</span></span>**

```cpp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class XboxLiveTest : MonoBehaviour
{
#if ENABLE_WINMD_SUPPORT
    Microsoft.Xbox.Services.System.XboxLiveUser m_user = new   Microsoft.Xbox.Services.System.XboxLiveUser();

    Microsoft.Xbox.Services.XboxLiveContext m_xboxLiveContext = null;
    Windows.UI.Core.CoreDispatcher UIDispatcher = null;
#endif
    string debugText = "";
    // Use this for initialization
    void Start()
    {
#if ENABLE_WINMD_SUPPORT
        Windows.ApplicationModel.Core.CoreApplicationView mainView = Windows.ApplicationModel.Core.CoreApplication.MainView;
        Windows.UI.Core.CoreWindow cw = mainView.CoreWindow;
        UIDispatcher = cw.Dispatcher;
        SignIn();
#endif
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnGUI()
    {
        GUI.Label(new UnityEngine.Rect(10, 10, 300, 50), debugText);
    }
#if ENABLE_WINMD_SUPPORT
    async void SignIn()
    {
        Microsoft.Xbox.Services.System.SignInResult result = await m_user.SignInAsync(UIDispatcher);
        if (result.Status == Microsoft.Xbox.Services.System.SignInStatus.Success)
        {
            m_xboxLiveContext = new Microsoft.Xbox.Services.XboxLiveContext(m_user);
            debugText += "\n User signed in: " + m_xboxLiveContext.User.Gamertag;
        }

    }
#endif
}

```

**<span data-ttu-id="fe4b8-128">10)   Make sure you have 'InternetClient' capability selected in the publishing settings found in player settings</span><span class="sxs-lookup"><span data-stu-id="fe4b8-128">10)   Make sure you have 'InternetClient' capability selected in the publishing settings found in player settings</span></span>**

![](../images/unity/unity-il2cpp-3.png)

**<span data-ttu-id="fe4b8-129">11) Build the project in Unity.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-129">11) Build the project in Unity.</span></span>**

1.  <span data-ttu-id="fe4b8-130">Go to File \| Build Settings, click Windows Store and make sure you click “Switch Platform”</span><span class="sxs-lookup"><span data-stu-id="fe4b8-130">Go to File \| Build Settings, click Windows Store and make sure you click “Switch Platform”</span></span>

2.  <span data-ttu-id="fe4b8-131">Click "Add Open Scenes" to add the current scene to the build</span><span class="sxs-lookup"><span data-stu-id="fe4b8-131">Click "Add Open Scenes" to add the current scene to the build</span></span>

3.  <span data-ttu-id="fe4b8-132">In the SDK combo box, choose "Universal 10"</span><span class="sxs-lookup"><span data-stu-id="fe4b8-132">In the SDK combo box, choose "Universal 10"</span></span>

4.  <span data-ttu-id="fe4b8-133">In the UWP build type combo box, choose "D3D", but "XAML" will also work if you prefer.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-133">In the UWP build type combo box, choose "D3D", but "XAML" will also work if you prefer.</span></span>

5.  <span data-ttu-id="fe4b8-134">Click the "Unity C\# Projects" checkbox to generate the Assembly-Csharp.dll projects</span><span class="sxs-lookup"><span data-stu-id="fe4b8-134">Click the "Unity C\# Projects" checkbox to generate the Assembly-Csharp.dll projects</span></span>

6.  <span data-ttu-id="fe4b8-135">Click "Build" for Unity to generate the UWP Visual Studio project that wraps your Unity game in a UWP application.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-135">Click "Build" for Unity to generate the UWP Visual Studio project that wraps your Unity game in a UWP application.</span></span> <span data-ttu-id="fe4b8-136">When you get prompted for a location, create a new folder to avoid confusion since a lot of new files will be created.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-136">When you get prompted for a location, create a new folder to avoid confusion since a lot of new files will be created.</span></span> <span data-ttu-id="fe4b8-137">It’s recommended you call the folder "Build", and then select that folder</span><span class="sxs-lookup"><span data-stu-id="fe4b8-137">It’s recommended you call the folder "Build", and then select that folder</span></span>

**<span data-ttu-id="fe4b8-138">12) Add Xbox Live configuration to your project</span><span class="sxs-lookup"><span data-stu-id="fe4b8-138">12) Add Xbox Live configuration to your project</span></span>**

<span data-ttu-id="fe4b8-139">Add the xboxservices.config file</span><span class="sxs-lookup"><span data-stu-id="fe4b8-139">Add the xboxservices.config file</span></span>
![](../images/unity/unity-il2cpp-4.png)

<span data-ttu-id="fe4b8-140">Follow the doc page called [Adding Xbox Live to a new or existing UWP project](get-started-with-visual-studio-and-uwp.md)</span><span class="sxs-lookup"><span data-stu-id="fe4b8-140">Follow the doc page called [Adding Xbox Live to a new or existing UWP project](get-started-with-visual-studio-and-uwp.md)</span></span>

**<span data-ttu-id="fe4b8-141">13) Compile and run the UWP app from Visual Studio</span><span class="sxs-lookup"><span data-stu-id="fe4b8-141">13) Compile and run the UWP app from Visual Studio</span></span>**

<span data-ttu-id="fe4b8-142">This will launch the app like a normal UWP app and allow Xbox Live calls to operate as they require a UWP app container to function.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-142">This will launch the app like a normal UWP app and allow Xbox Live calls to operate as they require a UWP app container to function.</span></span>

**<span data-ttu-id="fe4b8-143">14) Rebuild if you make changes to anything in Unity</span><span class="sxs-lookup"><span data-stu-id="fe4b8-143">14) Rebuild if you make changes to anything in Unity</span></span>**
  
<span data-ttu-id="fe4b8-144">If you change anything in Unity, then you must rebuild the UWP project.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-144">If you change anything in Unity, then you must rebuild the UWP project.</span></span>

<span data-ttu-id="fe4b8-145">Note that Unity will replace your pfx file when you recompile which will cause Xbox Live sign-in to fail, so you must update it inside the Unity project to avoid this issue.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-145">Note that Unity will replace your pfx file when you recompile which will cause Xbox Live sign-in to fail, so you must update it inside the Unity project to avoid this issue.</span></span>

<span data-ttu-id="fe4b8-146">To do this, go to File \| Build Settings, click on "Build Settings" on the Windows Store player and click the PFX button to replace the PFX file with the one you got from above.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-146">To do this, go to File \| Build Settings, click on "Build Settings" on the Windows Store player and click the PFX button to replace the PFX file with the one you got from above.</span></span> <span data-ttu-id="fe4b8-147">You can alternatively delete the PFX file each time you rebuild the project from within Unity.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-147">You can alternatively delete the PFX file each time you rebuild the project from within Unity.</span></span>

## <a name="troubleshooting-common-issues"></a><span data-ttu-id="fe4b8-148">Troubleshooting common issues</span><span class="sxs-lookup"><span data-stu-id="fe4b8-148">Troubleshooting common issues</span></span>

<span data-ttu-id="fe4b8-149">**1)** If Unity has that an associated script can not be loaded, then ensure that you did step 3 to drag the WinMD to the Unity project assets panel</span><span class="sxs-lookup"><span data-stu-id="fe4b8-149">**1)** If Unity has that an associated script can not be loaded, then ensure that you did step 3 to drag the WinMD to the Unity project assets panel</span></span>

<span data-ttu-id="fe4b8-150">**2)** If the app crashes immediately at startup or when trying to run this line of code:</span><span class="sxs-lookup"><span data-stu-id="fe4b8-150">**2)** If the app crashes immediately at startup or when trying to run this line of code:</span></span>

    Microsoft.Xbox.Services.System.XboxLiveUser m_user = new Microsoft.Xbox.Services.System.XboxLiveUser();

<span data-ttu-id="fe4b8-151">Ensure you have added a xboxservices.config text file to the project and in its properties, set the "Build Action" to "Content", and "Copy to Output Directory" set to "Copy Always".</span><span class="sxs-lookup"><span data-stu-id="fe4b8-151">Ensure you have added a xboxservices.config text file to the project and in its properties, set the "Build Action" to "Content", and "Copy to Output Directory" set to "Copy Always".</span></span>
<span data-ttu-id="fe4b8-152">Also ensure it contains proper JSON formatting with the TitleId in decimal form, such as:</span><span class="sxs-lookup"><span data-stu-id="fe4b8-152">Also ensure it contains proper JSON formatting with the TitleId in decimal form, such as:</span></span>

```json
{
    "TitleId" : 928643728,
    "PrimaryServiceConfigId" : "3ebd0100-ace5-4aa4-ab9c-5b733759fa90"
}
```

<span data-ttu-id="fe4b8-153">**3)** If the app launches, but fails to signin then check the following:</span><span class="sxs-lookup"><span data-stu-id="fe4b8-153">**3)** If the app launches, but fails to signin then check the following:</span></span>

<span data-ttu-id="fe4b8-154">a) Your machine is set to the your developer sandbox.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-154">a) Your machine is set to the your developer sandbox.</span></span>  <span data-ttu-id="fe4b8-155">Use the SwitchSandbox.cmd script in the \Tools folder of the Xbox Live SDK to do this.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-155">Use the SwitchSandbox.cmd script in the \Tools folder of the Xbox Live SDK to do this.</span></span>

<span data-ttu-id="fe4b8-156">b) You are signing in with an Xbox Live account that has access to the developer sandbox.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-156">b) You are signing in with an Xbox Live account that has access to the developer sandbox.</span></span>  <span data-ttu-id="fe4b8-157">Normal retail Xbox Live accounts don't have access.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-157">Normal retail Xbox Live accounts don't have access.</span></span>  <span data-ttu-id="fe4b8-158">You can use XDP or Dev Center to create an test accounts.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-158">You can use XDP or Dev Center to create an test accounts.</span></span>

<span data-ttu-id="fe4b8-159">c) Your package.appxmanfiest in your UWP app is set to the correct Identity.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-159">c) Your package.appxmanfiest in your UWP app is set to the correct Identity.</span></span>  <span data-ttu-id="fe4b8-160">You can edit this manually, but the easiest way to fix this is to right click on the Project in Visual Studio and choose "Store" \| "Associate App with the Store".</span><span class="sxs-lookup"><span data-stu-id="fe4b8-160">You can edit this manually, but the easiest way to fix this is to right click on the Project in Visual Studio and choose "Store" \| "Associate App with the Store".</span></span>

<span data-ttu-id="fe4b8-161">d) The stock .pfx file provided by Unity won't have the correct identity so either delete it from the disk and remove the line in the .csproj that references it, or right click on the Project in Visual Studio and choose "Store" \| "Associate App with the Store" which will place down a proper .pfx file.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-161">d) The stock .pfx file provided by Unity won't have the correct identity so either delete it from the disk and remove the line in the .csproj that references it, or right click on the Project in Visual Studio and choose "Store" \| "Associate App with the Store" which will place down a proper .pfx file.</span></span>  <span data-ttu-id="fe4b8-162">Be sure then to go back to Unity, click on "Build Settings" on the Windows Store player and click the PFX button to replace the .pfx file with the one you got from Visual Studio's "Associate App with the Store" action.</span><span class="sxs-lookup"><span data-stu-id="fe4b8-162">Be sure then to go back to Unity, click on "Build Settings" on the Windows Store player and click the PFX button to replace the .pfx file with the one you got from Visual Studio's "Associate App with the Store" action.</span></span>
