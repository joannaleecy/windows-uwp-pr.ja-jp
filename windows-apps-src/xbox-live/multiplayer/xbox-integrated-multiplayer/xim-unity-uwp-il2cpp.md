---
title: XIM (Unity と IL2CPP) の使用
author: KevinAsgari
description: UWP 用の Unity と IL2CPP スクリプト バックエンドと共に Xbox Integrated Multiplayer を使用する
ms.author: kevinasg
ms.date: 04/03/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, Xbox Integrated Multiplayer
ms.localizationpriority: medium
ms.openlocfilehash: 4171fa830059eb557106ad3a7c485a6e96deeec6
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5767006"
---
# <a name="use-xim-unity-with-il2cpp"></a><span data-ttu-id="1bb56-104">XIM (Unity と IL2CPP) の使用</span><span class="sxs-lookup"><span data-stu-id="1bb56-104">Use XIM (Unity with IL2CPP)</span></span>

## <a name="overview"></a><span data-ttu-id="1bb56-105">概要</span><span class="sxs-lookup"><span data-stu-id="1bb56-105">Overview</span></span>

<span data-ttu-id="1bb56-106">Unity での IL2CPP 用の Windows ランタイム サポート</span><span class="sxs-lookup"><span data-stu-id="1bb56-106">Windows Runtime Support for IL2CPP in Unity</span></span>

<span data-ttu-id="1bb56-107">Unity 5.6f3 のリリースでは、エンジンに新しい機能が組み込まれました。この新機能によって、開発者は Windows ランタイム (WinRT) コンポーネントをスクリプト内で直接使用することができます。そのためには、コンポーネントをゲーム プロジェクトに直接取り込みます。</span><span class="sxs-lookup"><span data-stu-id="1bb56-107">With the release of Unity 5.6f3 the engine has included a new feature that enables developers to use Windows Runtime (WinRT) components directly in script by including them in the game project directly.</span></span> <span data-ttu-id="1bb56-108">5.6 まで、開発者は、UWP のゲーム スクリプトでプラットフォーム機能 (Xbox Integrated Multiplayer など) をサポートするために、プラグインや dll を必要としていました。</span><span class="sxs-lookup"><span data-stu-id="1bb56-108">Until 5.6 developers have needed a plugin, or dll to support any platform feature (including Xbox Integrated Multiplayer) from game script in UWP.</span></span> <span data-ttu-id="1bb56-109">この新しいプロジェクション レイヤーによって、プラグインを使用する必要がなくなり、IL2CPP スクリプト バックエンドを選んだゲームでのみサポートされる、新しい簡略化されたワークフローが導入されました。</span><span class="sxs-lookup"><span data-stu-id="1bb56-109">This new projection layer removes the plugin requirement, and introduces a new and simplified workflow supported only with games that choose the IL2CPP scripting backend.</span></span>

- <span data-ttu-id="1bb56-110">WinRT と Unity を使用して作業を開始する方法について詳しくは、[Unity のドキュメント](https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1bb56-110">For more information on how to get started with using WinRT and Unity, see the [Unity documentation](https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html).</span></span>
- <span data-ttu-id="1bb56-111">IL2CPP を使用して Unity に Xbox Live のサポートを追加する方法の詳細については、それに関する [Xbox Live のドキュメント](https://docs.microsoft.com/windows/uwp/xbox-live/get-started-with-partner/partner-add-xbox-live-to-unity-uwp)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1bb56-111">For more information on how to add Xbox Live support to Unity using IL2CPP, see the [Xbox Live documentation](https://docs.microsoft.com/windows/uwp/xbox-live/get-started-with-partner/partner-add-xbox-live-to-unity-uwp) on the subject.</span></span>

## <a name="using-the-xim-unity-asset-package"></a><span data-ttu-id="1bb56-112">XIM Unity アセット パッケージの使用</span><span class="sxs-lookup"><span data-stu-id="1bb56-112">Using the XIM Unity asset package</span></span>

### <a name="1-install-unity"></a><span data-ttu-id="1bb56-113">1. Unity をインストールします。</span><span class="sxs-lookup"><span data-stu-id="1bb56-113">1. Install Unity</span></span>

<span data-ttu-id="1bb56-114">Unity 5.6 以上をインストールし、インストール時には **[Windows Store Il2CPP scripting backend]** を必ず選択してください。</span><span class="sxs-lookup"><span data-stu-id="1bb56-114">Install Unity 5.6 or higher, and ensure you have the **Windows Store Il2CPP scripting backend** selected during installation</span></span>

### <a name="2-install-visual-studio-tools-for-unity-version-31-and-above-for-intellisense-support-when-using-winmds"></a><span data-ttu-id="1bb56-115">2. WinMDs を使用するときに IntelliSense をサポートするために、Visual Studio Tools for Unity バージョン 3.1 以上をインストールします。</span><span class="sxs-lookup"><span data-stu-id="1bb56-115">2. Install Visual Studio Tools for Unity version 3.1 and above for IntelliSense support when using WinMDs</span></span>

<span data-ttu-id="1bb56-116">Visual Studio 2015 の場合、このツールは [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity) で入手できます。</span><span class="sxs-lookup"><span data-stu-id="1bb56-116">For Visual Studio 2015, this can be found [in the Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity).</span></span> <span data-ttu-id="1bb56-117">Visual Studio 2017 の場合、Visual Studio 2017 インストーラー内でこのコンポーネントを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="1bb56-117">For Visual Studio 2017, the component can be added inside the Visual Studio 2017 installer.</span></span>

### <a name="3-open-a-new-or-existing-unity-project"></a><span data-ttu-id="1bb56-118">3. 新規または既存の Unity プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="1bb56-118">3. Open a new or existing Unity project</span></span>

### <a name="4-switch-the-platform-to-universal-windows-platform-in-the-unity-build-settings-menu"></a><span data-ttu-id="1bb56-119">4. Unity の [Build Settings] メニューで、プラットフォームをユニバーサル Windows プラットフォームに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="1bb56-119">4. Switch the platform to Universal Windows Platform in the Unity Build Settings menu</span></span>

![Unity の [Build Settings] メニューでユニバーサル Windows プラットフォームのビルド設定を選択した状態](../../images/xboxintegratedmultiplayer/xim-unity-build.png)

### <a name="5-enable-il2cpp-scripting-backend-in-the-unity-player-settings-and-set-api-compatibility-to-net-46"></a><span data-ttu-id="1bb56-121">5. Unity のプレイヤーの設定で IL2CPP スクリプト バックエンドを有効にして、API の互換性を .NET 4.6 に設定します。</span><span class="sxs-lookup"><span data-stu-id="1bb56-121">5. Enable IL2CPP scripting backend in the Unity player settings, and set API compatibility to .NET 4.6</span></span>

![Unity の [Player Settings] メニューの [Configuration] セクションで、[Api Compatibility] を [.NET 4.6] に設定した状態](../../images/unity/unity-il2cpp-1.png)

### <a name="6-import-the-latest-version-of-the-xbox-integrated-multiplayer-winrt-unity-asset-package"></a><span data-ttu-id="1bb56-123">6. 最新バージョンの Xbox Integrated Multiplayer WinRT Unity アセット パッケージをインポートします。</span><span class="sxs-lookup"><span data-stu-id="1bb56-123">6. Import the latest version of the Xbox Integrated Multiplayer WinRT Unity asset package</span></span>

<span data-ttu-id="1bb56-124">このパッケージは https://github.com/Microsoft/xbox-integrated-multiplayer-unity-plugin/releases で入手できます。</span><span class="sxs-lookup"><span data-stu-id="1bb56-124">This can be found at https://github.com/Microsoft/xbox-integrated-multiplayer-unity-plugin/releases</span></span>

### <a name="7-you-can-now-use-xim-in-your-scripts"></a><span data-ttu-id="1bb56-125">7. スクリプトで XIM を使用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="1bb56-125">7. You can now use XIM in your scripts</span></span>

<span data-ttu-id="1bb56-126">C# で XIM を使用する方法の詳細なガイダンスについては、「[XIM の使用 (C#)](using-xim-cs.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1bb56-126">For more guidance on how to use XIM with C#, see [Use XIM (C#)](using-xim-cs.md).</span></span>

<span data-ttu-id="1bb56-127">次のスニペットでは、コードで XIM を統合する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1bb56-127">The following snippet shows how XIM might be integrated with your code:</span></span>

```cs

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ENABLE_WINMD_SUPPORT
using Microsoft.Xbox.Services.XboxIntegratedMultiplayer;
#endif

public class XimScript
{
    public void Start()
    {
#if ENABLE_WINMD_SUPPORT
        XboxIntegratedMultiplayer.TitleId = XboxLiveAppConfiguration.SingletonInstance.TitleId;
        XboxIntegratedMultiplayer.ServiceConfigurationId = XboxLiveAppConfiguration.SingletonInstance.ServiceConfigurationId;
#endif
    }

    public void Update()
    {
#if ENABLE_WINMD_SUPPORT
        using (var stateChanges = XboxIntegratedMultiplayer.GetStateChanges())
        {
            foreach (var stateChange in stateChanges)
            {
                switch (stateChange.Type)
                {
                    case XimStateChangeType.PlayerJoined:
                        HandlePlayerJoined((XimPlayerJoinedStateChange)stateChange);
                        break;

                    case XimStateChangeType.PlayerLeft:
                        HandlePlayerLeft((XimPlayerLeftStateChange)stateChange);
                        break;
                    [...]
                }
            }
        }
#endif
    }
}
```

<span data-ttu-id="1bb56-128">`ENABLE_WINMD_SUPPORT` の #define ディレクティブの詳細については、[Windows ランタイムのサポート](https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html)に関する Unity のドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="1bb56-128">For more information on the `ENABLE_WINMD_SUPPORT` #define directive, see the Unity documentation on [Windows Runtime Support](https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html)</span></span>

### <a name="8-required-capability-content"></a><span data-ttu-id="1bb56-129">8. 必要な機能の内容</span><span class="sxs-lookup"><span data-stu-id="1bb56-129">8. Required capability content</span></span>

<span data-ttu-id="1bb56-130">本質的に XIM を使用するアプリケーションでは、インターネット経由とローカル ネットワーク経由の両方でネットワーク リソースに接続し、ネットワーク リソースからの接続を受け入れる必要があります。</span><span class="sxs-lookup"><span data-stu-id="1bb56-130">An application using XIM inherently requires connecting to and accepting connections from network resources both over the Internet and the local network.</span></span> <span data-ttu-id="1bb56-131">また、ボイス チャットをサポートするマイク デバイスへのアクセスも必要です。</span><span class="sxs-lookup"><span data-stu-id="1bb56-131">It also requires access to microphone devices to support voice chat.</span></span> <span data-ttu-id="1bb56-132">そのため、アプリのプレイヤー設定にある公開設定では、"InternetClientServer" 機能、"PrivateNetworkClientServer" 機能、"Microphone" デバイス機能を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1bb56-132">As a result, the app should declare the "InternetClientServer" and "PrivateNetworkClientServer" capabilities, and the "Microphone" device capability in the publishing settings found in player settings.</span></span>

![Unity の [Capabilities] メニューで "InternetClientServer"、"PrivateNetworkClientServer"、"Microphone" 機能が選択された状態](../../images/xboxintegratedmultiplayer/xim-unity-capability.png)

### <a name="9-build-the-project-in-unity"></a><span data-ttu-id="1bb56-134">9. Unity でプロジェクトを ビルドします。</span><span class="sxs-lookup"><span data-stu-id="1bb56-134">9. Build the project in Unity.</span></span>

1. <span data-ttu-id="1bb56-135">[File]、[Build Settings] の順に移動し、**[ユニバーサル Windows プラットフォーム]** をクリックして、**[Switch Platform]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="1bb56-135">Go to File \| Build Settings, click **Universal Windows Platform** and make sure you click **Switch Platform**</span></span>

2. <span data-ttu-id="1bb56-136">[Add Open Scenes] をクリックして、現在のシーンをビルドに追加します。</span><span class="sxs-lookup"><span data-stu-id="1bb56-136">Click "Add Open Scenes" to add the current scene to the build</span></span>

3. <span data-ttu-id="1bb56-137">[SDK] コンボ ボックスで、[Universal 10] を選択します。</span><span class="sxs-lookup"><span data-stu-id="1bb56-137">In the SDK combo box, choose "Universal 10"</span></span>

4. <span data-ttu-id="1bb56-138">UWP ビルド タイプのコンボ ボックスで [D3D] を選択しますが、必要に応じて [XAML] も選択できます。</span><span class="sxs-lookup"><span data-stu-id="1bb56-138">In the UWP build type combo box, choose "D3D", but "XAML" will also work if you prefer.</span></span>

5. <span data-ttu-id="1bb56-139">Unity の [Build] をクリックして、UWP アプリケーション内に Unity ゲームをラップする UWP Visual Studio プロジェクトを生成します。</span><span class="sxs-lookup"><span data-stu-id="1bb56-139">Click "Build" for Unity to generate the UWP Visual Studio project that wraps your Unity game in a UWP application.</span></span>

    <span data-ttu-id="1bb56-140">新しいファイルが多数作成されるため、場所を指定するときは、混乱を避けるために新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="1bb56-140">When you get prompted for a location, create a new folder to avoid confusion since a lot of new files will be created.</span></span> <span data-ttu-id="1bb56-141">フォルダーの名前を "Build" にすることをお勧めします。フォルダーに名前を付けたら、そのフォルダーを選択します。</span><span class="sxs-lookup"><span data-stu-id="1bb56-141">It’s recommended you call the folder "Build", and then select that folder.</span></span>

6. <span data-ttu-id="1bb56-142">XIM のネットワーク マニフェストをプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="1bb56-142">Add XIM's network manifest to your project</span></span>

    <span data-ttu-id="1bb56-143">networkmanifest.xml ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="1bb56-143">Add the networkmanifest.xml file:</span></span>

    ![Visual Studio の networkmanifest.xml のプロパティ](../../images/xboxintegratedmultiplayer/xim-unity-networkmanifest.png)

    <span data-ttu-id="1bb56-145">ネットワーク マニフェストとその内容の詳細については、「[XIM プロジェクト構成](xim-manifest.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1bb56-145">See [XIM Project Configuration](xim-manifest.md) for more information on the network manifest and its content.</span></span>

7. <span data-ttu-id="1bb56-146">Visual Studio から UWP アプリをコンパイルして実行します。</span><span class="sxs-lookup"><span data-stu-id="1bb56-146">Compile and run the UWP app from Visual Studio</span></span>

<span data-ttu-id="1bb56-147">これにより、通常の UWP アプリのようにアプリが起動し、動作のために UWP アプリ コンテナーが必要なときに Xbox Live 呼び出しが可能になります。</span><span class="sxs-lookup"><span data-stu-id="1bb56-147">This will launch the app like a normal UWP app and allow Xbox Live calls to operate as they require a UWP app container to function.</span></span>

### <a name="10-rebuild-if-you-make-changes-to-anything-in-unity"></a><span data-ttu-id="1bb56-148">10. Unity で変更を加えた場合はリビルドします。</span><span class="sxs-lookup"><span data-stu-id="1bb56-148">10. Rebuild if you make changes to anything in Unity</span></span>

<span data-ttu-id="1bb56-149">Unity で変更を加えた場合、UWP プロジェクトをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1bb56-149">If you change anything in Unity, then you must rebuild the UWP project</span></span>
