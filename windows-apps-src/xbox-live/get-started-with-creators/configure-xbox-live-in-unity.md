---
title: Configure Xbox Live in Unity
author: KevinAsgari
description: Learn how to use the Xbox Live Unity plugin to configure Xbox Live in your Unity game.
ms.assetid: 55147c41-cc49-47f3-829b-fa7e1a46b2dd
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one, Unity, configure
ms.openlocfilehash: 774acdc126c70e37d8fb09c9f41bd8fc41564b39
ms.sourcegitcommit: fc695def93ba79064af709253ded5e0bfd634a9c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/25/2017
---
# <a name="configure-xbox-live-in-unity"></a><span data-ttu-id="98e2a-104">Configure Xbox Live in Unity</span><span class="sxs-lookup"><span data-stu-id="98e2a-104">Configure Xbox Live in Unity</span></span>

> <span data-ttu-id="98e2a-105">**Note:** The Xbox Live Unity plugin is only recommended for [Xbox Live Creators Program](../developer-program-overview.md) members, since currently there is no support for achievements or multiplayer.</span><span class="sxs-lookup"><span data-stu-id="98e2a-105">**Note:** The Xbox Live Unity plugin is only recommended for [Xbox Live Creators Program](../developer-program-overview.md) members, since currently there is no support for achievements or multiplayer.</span></span>

<span data-ttu-id="98e2a-106">With the Xbox Live Unity plugin, adding Xbox Live support to a Unity game is easy, giving you more time to focus on using Xbox Live in ways that best suit your title.</span><span class="sxs-lookup"><span data-stu-id="98e2a-106">With the Xbox Live Unity plugin, adding Xbox Live support to a Unity game is easy, giving you more time to focus on using Xbox Live in ways that best suit your title.</span></span>

<span data-ttu-id="98e2a-107">This topic will go through the process of setting up the Xbox Live plugin in Unity.</span><span class="sxs-lookup"><span data-stu-id="98e2a-107">This topic will go through the process of setting up the Xbox Live plugin in Unity.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="98e2a-108">Prerequisites</span><span class="sxs-lookup"><span data-stu-id="98e2a-108">Prerequisites</span></span>

<span data-ttu-id="98e2a-109">You will need the following to configure Xbox Live in Unity:</span><span class="sxs-lookup"><span data-stu-id="98e2a-109">You will need the following to configure Xbox Live in Unity:</span></span>

* <span data-ttu-id="98e2a-110">An [Xbox Live account](https://support.xbox.com/browse/my-account/manage-account/Create%20account)</span><span class="sxs-lookup"><span data-stu-id="98e2a-110">An [Xbox Live account](https://support.xbox.com/browse/my-account/manage-account/Create%20account)</span></span>
* <span data-ttu-id="98e2a-111">[Windows 10 Anniversary Update](https://microsoft.com/windows)  or later</span><span class="sxs-lookup"><span data-stu-id="98e2a-111">[Windows 10 Anniversary Update](https://microsoft.com/windows)  or later</span></span>
* <span data-ttu-id="98e2a-112">[Unity 5.5](https://store.unity.com/) or later</span><span class="sxs-lookup"><span data-stu-id="98e2a-112">[Unity 5.5](https://store.unity.com/) or later</span></span>
  * <span data-ttu-id="98e2a-113">インストール時に次のコンポーネントを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="98e2a-113">You need to include the following components when installing.</span></span>
    * [<span data-ttu-id="98e2a-114">Microsoft Visual Studio Tools for Unity</span><span class="sxs-lookup"><span data-stu-id="98e2a-114">Microsoft Visual Studio Tools for Unity</span></span>](https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity)
    * <span data-ttu-id="98e2a-115">Windows ストア .NET Scripting Backend</span><span class="sxs-lookup"><span data-stu-id="98e2a-115">Windows Store .NET Scripting Backend</span></span>
* <span data-ttu-id="98e2a-116">[Visual Studio 2015](https://www.visualstudio.com/) 以降</span><span class="sxs-lookup"><span data-stu-id="98e2a-116">[Visual Studio 2015](https://www.visualstudio.com/) or later</span></span>
  * <span data-ttu-id="98e2a-117">Any version of Visual Studio should work for this including Community Edition.</span><span class="sxs-lookup"><span data-stu-id="98e2a-117">Any version of Visual Studio should work for this including Community Edition.</span></span>
  * <span data-ttu-id="98e2a-118">Make sure to select everything under **Universal Windows App Development Tools** when installing.</span><span class="sxs-lookup"><span data-stu-id="98e2a-118">Make sure to select everything under **Universal Windows App Development Tools** when installing.</span></span>  <span data-ttu-id="98e2a-119">インストールを変更して、既存のインストールにこれらの機能を追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="98e2a-119">You can modify the installation to include these features for an existing installation as well.</span></span>
* [<span data-ttu-id="98e2a-120">Xbox Live Platform Extensions SDK</span><span class="sxs-lookup"><span data-stu-id="98e2a-120">Xbox Live Platform Extensions SDK</span></span>](http://aka.ms/xblextsdk) 

## <a name="import-the-unity-plugin"></a><span data-ttu-id="98e2a-121">Unity プラグインをインポートする</span><span class="sxs-lookup"><span data-stu-id="98e2a-121">Import the Unity plugin</span></span>

<span data-ttu-id="98e2a-122">To import the plugin into your new or existing Unity project, follow these steps:</span><span class="sxs-lookup"><span data-stu-id="98e2a-122">To import the plugin into your new or existing Unity project, follow these steps:</span></span>

1. <span data-ttu-id="98e2a-123">Navigate to the Xbox Live Unity plugin on [https://github.com/Microsoft/xbox-live-unity-plugin/releases](https://github.com/Microsoft/xbox-live-unity-plugin/releases).</span><span class="sxs-lookup"><span data-stu-id="98e2a-123">Navigate to the Xbox Live Unity plugin on [https://github.com/Microsoft/xbox-live-unity-plugin/releases](https://github.com/Microsoft/xbox-live-unity-plugin/releases).</span></span>
2. <span data-ttu-id="98e2a-124">Download the XboxLive.unitypackage</span><span class="sxs-lookup"><span data-stu-id="98e2a-124">Download the XboxLive.unitypackage</span></span>
3. <span data-ttu-id="98e2a-125">Double click the XboxLive.unitypackage package, or in Unity click in the menu under Assets | Import Package | Custom Package, to import it into your Unity project.</span><span class="sxs-lookup"><span data-stu-id="98e2a-125">Double click the XboxLive.unitypackage package, or in Unity click in the menu under Assets | Import Package | Custom Package, to import it into your Unity project.</span></span>

![Unity パッケージのインポート](../images/unity/unity-import.png)

## <a name="set-visual-studio-as-editor-in-unity"></a><span data-ttu-id="98e2a-127">Visual Studio を Unity のエディターとして設定する</span><span class="sxs-lookup"><span data-stu-id="98e2a-127">Set Visual Studio as Editor in Unity</span></span>

<span data-ttu-id="98e2a-128">Unity で外部ツールを Visual Studio に設定します。これを行うには、[Unity]、[Preferences]、[External Tools] の順に移動して、Visual Studio に切り替えます。</span><span class="sxs-lookup"><span data-stu-id="98e2a-128">Set your External Tools in Unity to Visual Studio by going into Unity > Preferences > External Tools and switching to Visual Studio.</span></span>
<span data-ttu-id="98e2a-129">このプラグインは "Microsoft Visual Studio Tools for Unity" に依存するため、ビルドには Visual Studio が必要です。</span><span class="sxs-lookup"><span data-stu-id="98e2a-129">This plugin depends on "Microsoft Visual Studio Tools for Unity" so Visual Studio is required to build.</span></span>

## <a name="unity-plugin-file-structure"></a><span data-ttu-id="98e2a-130">Unity プラグインのファイル構造</span><span class="sxs-lookup"><span data-stu-id="98e2a-130">Unity plugin file structure</span></span>

<span data-ttu-id="98e2a-131">The Unity plugin's file structure is broken into the following parts:</span><span class="sxs-lookup"><span data-stu-id="98e2a-131">The Unity plugin's file structure is broken into the following parts:</span></span>

* <span data-ttu-id="98e2a-132">__Xbox Live__ contains the actual plugin assets that are included in the published **.unitypackage**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-132">__Xbox Live__ contains the actual plugin assets that are included in the published **.unitypackage**.</span></span>
    * <span data-ttu-id="98e2a-133">__Editor__ contains scripts that provide the basic Unity configuration UI and processes the projects during build.</span><span class="sxs-lookup"><span data-stu-id="98e2a-133">__Editor__ contains scripts that provide the basic Unity configuration UI and processes the projects during build.</span></span>
    * <span data-ttu-id="98e2a-134">__Examples__ contains a set of simple scene files that show how to use the various prefabs and connect them together.</span><span class="sxs-lookup"><span data-stu-id="98e2a-134">__Examples__ contains a set of simple scene files that show how to use the various prefabs and connect them together.</span></span>
    * <span data-ttu-id="98e2a-135">__Images__ is a small set of images that are used by the prefabs.</span><span class="sxs-lookup"><span data-stu-id="98e2a-135">__Images__ is a small set of images that are used by the prefabs.</span></span>
    * <span data-ttu-id="98e2a-136">__Libs__ is where the Xbox Live libraries will be stored.</span><span class="sxs-lookup"><span data-stu-id="98e2a-136">__Libs__ is where the Xbox Live libraries will be stored.</span></span>
    * <span data-ttu-id="98e2a-137">__Prefabs__ contains various [Unity prefab](https://docs.unity3d.com/Manual/Prefabs.html) objects that implement Xbox Live functionality.</span><span class="sxs-lookup"><span data-stu-id="98e2a-137">__Prefabs__ contains various [Unity prefab](https://docs.unity3d.com/Manual/Prefabs.html) objects that implement Xbox Live functionality.</span></span>
    * <span data-ttu-id="98e2a-138">__Scripts__ contains all of the code files that actually call the Xbox Live APIs from the prefabs.</span><span class="sxs-lookup"><span data-stu-id="98e2a-138">__Scripts__ contains all of the code files that actually call the Xbox Live APIs from the prefabs.</span></span>  <span data-ttu-id="98e2a-139">This is a great place to look for examples about how to properly call the Xbox Live APIs.</span><span class="sxs-lookup"><span data-stu-id="98e2a-139">This is a great place to look for examples about how to properly call the Xbox Live APIs.</span></span>
    * <span data-ttu-id="98e2a-140">__Tools\AssociationWizard__ contains the Xbox Live Association Wizard, used to pull down application configuration from the [Windows Dev Center](https://developer.microsoft.com/windows) for use within Unity.</span><span class="sxs-lookup"><span data-stu-id="98e2a-140">__Tools\AssociationWizard__ contains the Xbox Live Association Wizard, used to pull down application configuration from the [Windows Dev Center](https://developer.microsoft.com/windows) for use within Unity.</span></span>

## <a name="enable-xbox-live"></a><span data-ttu-id="98e2a-141">Enable Xbox Live</span><span class="sxs-lookup"><span data-stu-id="98e2a-141">Enable Xbox Live</span></span>

<span data-ttu-id="98e2a-142">To actually enable Xbox Live in your Unity project, you'll need to follow these steps:</span><span class="sxs-lookup"><span data-stu-id="98e2a-142">To actually enable Xbox Live in your Unity project, you'll need to follow these steps:</span></span>

1. <span data-ttu-id="98e2a-143">In the **Xbox Live** menu, select **Configuration**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-143">In the **Xbox Live** menu, select **Configuration**.</span></span>

    ![Xbox Live: Configuration](../images/unity/xbox-live-configuration.PNG)

2. <span data-ttu-id="98e2a-145">In the **Xbox Live** window, select **Run Xbox Live Association Wizard**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-145">In the **Xbox Live** window, select **Run Xbox Live Association Wizard**.</span></span>

    ![Xbox Live: Enable Xbox Live](../images/unity/enable-xbox-live.PNG)

    > <span data-ttu-id="98e2a-147">**Note:** Your device must be in developer mode to call Xbox Live services.</span><span class="sxs-lookup"><span data-stu-id="98e2a-147">**Note:** Your device must be in developer mode to call Xbox Live services.</span></span> <span data-ttu-id="98e2a-148">After you have enabled Xbox Live, you can switch to developer mode by selecting **Switch to Developer Mode**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-148">After you have enabled Xbox Live, you can switch to developer mode by selecting **Switch to Developer Mode**.</span></span>

3. <span data-ttu-id="98e2a-149">In the **Associate Your Game with the Windows Store** dialog, click **Next**, and then sign in with your Dev Center account.</span><span class="sxs-lookup"><span data-stu-id="98e2a-149">In the **Associate Your Game with the Windows Store** dialog, click **Next**, and then sign in with your Dev Center account.</span></span>

    ![Xbox Live: Enable Xbox Live](../images/unity/associate-game-with-store.png)

4. <span data-ttu-id="98e2a-151">Select the app that you want to associate with this project, and then click **Select**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-151">Select the app that you want to associate with this project, and then click **Select**.</span></span> <span data-ttu-id="98e2a-152">If you don't see it there, try clicking **Refresh**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-152">If you don't see it there, try clicking **Refresh**.</span></span> <span data-ttu-id="98e2a-153">Alternatively, you can create a new app by reserving a name and clicking **Reserve**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-153">Alternatively, you can create a new app by reserving a name and clicking **Reserve**.</span></span>

5. <span data-ttu-id="98e2a-154">Click **Enable** to enable Xbox Live in your game.</span><span class="sxs-lookup"><span data-stu-id="98e2a-154">Click **Enable** to enable Xbox Live in your game.</span></span>

    ![Enable Xbox Live Features for Your Game](../images/unity/associate-your-game-with-the-windows-store.PNG)

6. <span data-ttu-id="98e2a-156">Click **Finish** to save your configuration.</span><span class="sxs-lookup"><span data-stu-id="98e2a-156">Click **Finish** to save your configuration.</span></span>

7. <span data-ttu-id="98e2a-157">Back in the **Xbox Live** window in Unity, make sure that under **Developer Mode Configuration** it says **Enabled**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-157">Back in the **Xbox Live** window in Unity, make sure that under **Developer Mode Configuration** it says **Enabled**.</span></span> <span data-ttu-id="98e2a-158">If it says **Disabled**, click **Switch to Developer Mode**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-158">If it says **Disabled**, click **Switch to Developer Mode**.</span></span>

8. <span data-ttu-id="98e2a-159">Make sure that the sandbox in which your title resides is the same as the sandbox in which your device currently does.</span><span class="sxs-lookup"><span data-stu-id="98e2a-159">Make sure that the sandbox in which your title resides is the same as the sandbox in which your device currently does.</span></span> <span data-ttu-id="98e2a-160">You can see which sandbox your title resides in under **Title Configuration**, next to **Sandbox**; the sandbox that your device is in is under **Developer Mode Configuration**, next to **Developer Mode**, in parentheses.</span><span class="sxs-lookup"><span data-stu-id="98e2a-160">You can see which sandbox your title resides in under **Title Configuration**, next to **Sandbox**; the sandbox that your device is in is under **Developer Mode Configuration**, next to **Developer Mode**, in parentheses.</span></span> <span data-ttu-id="98e2a-161">See [Xbox Live sandboxes](../xbox-live-sandboxes.md) for information about sandboxes and how to switch the sandbox on your device.</span><span class="sxs-lookup"><span data-stu-id="98e2a-161">See [Xbox Live sandboxes](../xbox-live-sandboxes.md) for information about sandboxes and how to switch the sandbox on your device.</span></span> <span data-ttu-id="98e2a-162">The plugin should switch the sandbox on your device automatically.</span><span class="sxs-lookup"><span data-stu-id="98e2a-162">The plugin should switch the sandbox on your device automatically.</span></span>

    ![Xbox Live enabled: match sandboxes](../images/unity/unity-xbl-enabled.PNG)

9. <span data-ttu-id="98e2a-164">You have now successfully enabled Xbox Live in your Unity project!</span><span class="sxs-lookup"><span data-stu-id="98e2a-164">You have now successfully enabled Xbox Live in your Unity project!</span></span>

## <a name="build-and-test-the-project"></a><span data-ttu-id="98e2a-165">Build and test the project</span><span class="sxs-lookup"><span data-stu-id="98e2a-165">Build and test the project</span></span>

<span data-ttu-id="98e2a-166">When running your title in the editor, you will see fake data when you try to use Xbox Live functionality.</span><span class="sxs-lookup"><span data-stu-id="98e2a-166">When running your title in the editor, you will see fake data when you try to use Xbox Live functionality.</span></span> <span data-ttu-id="98e2a-167">For example, in the **SignInAndProfile** example scene, if you run it in the editor and try to sign in, you will see **Fake User 123456789** appear as your profile name, with a placeholder icon.</span><span class="sxs-lookup"><span data-stu-id="98e2a-167">For example, in the **SignInAndProfile** example scene, if you run it in the editor and try to sign in, you will see **Fake User 123456789** appear as your profile name, with a placeholder icon.</span></span>

![Fake User: 123456789](../images/unity/unity-game-fake-data.PNG)

<span data-ttu-id="98e2a-169">To sign in with a real profile and test out Xbox Live functionality in your title, you'll need to build and then run it in Visual Studio.</span><span class="sxs-lookup"><span data-stu-id="98e2a-169">To sign in with a real profile and test out Xbox Live functionality in your title, you'll need to build and then run it in Visual Studio.</span></span>

1. <span data-ttu-id="98e2a-170">In Unity, open the **Build Settings** window by selecting **File -> Build Settings** or by pressing **Ctrl+Shift+B**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-170">In Unity, open the **Build Settings** window by selecting **File -> Build Settings** or by pressing **Ctrl+Shift+B**.</span></span>

2. <span data-ttu-id="98e2a-171">Make sure that you have the scene that you want to test included in your build under **Scenes In Build**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-171">Make sure that you have the scene that you want to test included in your build under **Scenes In Build**.</span></span> <span data-ttu-id="98e2a-172">If it's not listed, open the scene and select **Add Open Scenes**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-172">If it's not listed, open the scene and select **Add Open Scenes**.</span></span>

3. <span data-ttu-id="98e2a-173">Switch to the **Windows Store** platform by selecting **Windows Store** under **Platform** and clicking **Switch Platform**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-173">Switch to the **Windows Store** platform by selecting **Windows Store** under **Platform** and clicking **Switch Platform**.</span></span>

4. <span data-ttu-id="98e2a-174">Next to **SDK**, select **Universal 10**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-174">Next to **SDK**, select **Universal 10**.</span></span>

5. <span data-ttu-id="98e2a-175">Under **Debugging**, check **Unity C# Projects**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-175">Under **Debugging**, check **Unity C# Projects**.</span></span>

6. <span data-ttu-id="98e2a-176">Click **Build**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-176">Click **Build**.</span></span>

    ![Build Settings](../images/unity/unity-build-settings.PNG)

7. <span data-ttu-id="98e2a-178">Select a folder in which to put the build in the file explorer.</span><span class="sxs-lookup"><span data-stu-id="98e2a-178">Select a folder in which to put the build in the file explorer.</span></span>

8. <span data-ttu-id="98e2a-179">In the folder that you specified, open **&lt;ProjectName&gt;\\&lt;ProjectName&gt;.csproj** in Visual Studio.</span><span class="sxs-lookup"><span data-stu-id="98e2a-179">In the folder that you specified, open **&lt;ProjectName&gt;\\&lt;ProjectName&gt;.csproj** in Visual Studio.</span></span>

9. <span data-ttu-id="98e2a-180">In the toolbar at the top, select **x64** or **x86**, depending on what your device supports, and deploy to the **Local Machine**.</span><span class="sxs-lookup"><span data-stu-id="98e2a-180">In the toolbar at the top, select **x64** or **x86**, depending on what your device supports, and deploy to the **Local Machine**.</span></span>

    ![Debug; x64; Local Machine](../images/unity/vs-debug-local-machine.PNG)

10. <span data-ttu-id="98e2a-182">If you have added a way to sign in to Xbox Live to your project, sign in using an account with access to the sandbox.</span><span class="sxs-lookup"><span data-stu-id="98e2a-182">If you have added a way to sign in to Xbox Live to your project, sign in using an account with access to the sandbox.</span></span> <span data-ttu-id="98e2a-183">You have now connected Xbox Live to your title!</span><span class="sxs-lookup"><span data-stu-id="98e2a-183">You have now connected Xbox Live to your title!</span></span>

## <a name="try-out-the-examples"></a><span data-ttu-id="98e2a-184">Try out the examples</span><span class="sxs-lookup"><span data-stu-id="98e2a-184">Try out the examples</span></span>

<span data-ttu-id="98e2a-185">You're all set to start using Xbox Live in your Unity project!</span><span class="sxs-lookup"><span data-stu-id="98e2a-185">You're all set to start using Xbox Live in your Unity project!</span></span> <span data-ttu-id="98e2a-186">Try opening scenes in the **Xbox Live/Examples** folder to see the plugin in action, and for examples of how to use the functionality yourself.</span><span class="sxs-lookup"><span data-stu-id="98e2a-186">Try opening scenes in the **Xbox Live/Examples** folder to see the plugin in action, and for examples of how to use the functionality yourself.</span></span> <span data-ttu-id="98e2a-187">Running the examples in the editor will give you dummy data, but if you build the project in Visual Studio and associate your Microsoft Account with the sandbox, you can sign in with your gamertag!</span><span class="sxs-lookup"><span data-stu-id="98e2a-187">Running the examples in the editor will give you dummy data, but if you build the project in Visual Studio and associate your Microsoft Account with the sandbox, you can sign in with your gamertag!</span></span>

<span data-ttu-id="98e2a-188">Try the **SignInAndProfile** scene for signing into your Microsoft Account, the **Leaderboard** scene for creating a leaderboard, and the **UpdateStat** scene for displaying and updating stats.</span><span class="sxs-lookup"><span data-stu-id="98e2a-188">Try the **SignInAndProfile** scene for signing into your Microsoft Account, the **Leaderboard** scene for creating a leaderboard, and the **UpdateStat** scene for displaying and updating stats.</span></span>

## <a name="see-also"></a><span data-ttu-id="98e2a-189">See also</span><span class="sxs-lookup"><span data-stu-id="98e2a-189">See also</span></span>

* [<span data-ttu-id="98e2a-190">Sign in to Xbox Live in Unity</span><span class="sxs-lookup"><span data-stu-id="98e2a-190">Sign in to Xbox Live in Unity</span></span>](sign-in-to-xbox-live-in-unity.md)
