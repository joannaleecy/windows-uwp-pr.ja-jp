---
title: "XDK 用 Unity と IL2CPP バックエンド"
author: KevinAsgari
description: "ID@Xbox および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを XDK 用 Unity に追加する"
ms.assetid: 790a49ad-eff4-4916-8578-968ca8483211
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity"
ms.openlocfilehash: 9cff8eccaaa770b82db29f07c889e8b3604c5a6d
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="add-xbox-live-support-to-unity-for-xdk-with-il2cpp-scripting-backend-for-idxbox-and-managed-partners"></a><span data-ttu-id="fbdac-104">ID@Xbox および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを XDK 用 Unity に追加する</span><span class="sxs-lookup"><span data-stu-id="fbdac-104">Add Xbox Live support to Unity for XDK with IL2CPP scripting backend for ID@Xbox and managed partners</span></span>

## <a name="overview"></a><span data-ttu-id="fbdac-105">概要</span><span class="sxs-lookup"><span data-stu-id="fbdac-105">Overview</span></span>

<span data-ttu-id="fbdac-106">Unity での IL2CPP 用の Windows ランタイム サポート</span><span class="sxs-lookup"><span data-stu-id="fbdac-106">Windows Runtime Support for IL2CPP in Unity</span></span>

<span data-ttu-id="fbdac-107">Unity 5.6f3 のリリースでは、エンジンに新しい機能が組み込まれました。この新機能によって、開発者は Windows ランタイム (WinRT) コンポーネントをスクリプト内で直接使用することができます。そのためには、コンポーネントをゲーム プロジェクトに直接取り込みます。</span><span class="sxs-lookup"><span data-stu-id="fbdac-107">With the release of Unity 5.6f3 the engine has included a new feature that enables developers to use Windows Runtime (WinRT) components directly in script by including them in the game project directly.</span></span> <span data-ttu-id="fbdac-108">Until 5.6 を利用していた開発者は、ゲーム スクリプトでプラットフォーム機能 (Xbox Live SDK など) をサポートするために、プラグインや dll を必要としていました。</span><span class="sxs-lookup"><span data-stu-id="fbdac-108">Until 5.6 developers have needed a plugin, or dll to support any platform feature (including Xbox Live SDK) from game script.</span></span> <span data-ttu-id="fbdac-109">この新しいプロジェクション レイヤーによって、プラグインを使用する必要がなくなり、IL2CPP スクリプト バックエンドを選んだゲームでのみサポートされる、新しい簡略化されたワークフローが導入されました。</span><span class="sxs-lookup"><span data-stu-id="fbdac-109">This new projection layer removes the plugin requirement, and introduces a new and simplified workflow supported only with games that choose the IL2CPP scripting backend.</span></span>

<span data-ttu-id="fbdac-110">作業の開始方法について詳しくは、Unity に関するドキュメント (https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="fbdac-110">For more information on how to get started, see the Unity documentation: https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html</span></span>

## <a name="steps"></a><span data-ttu-id="fbdac-111">手順</span><span class="sxs-lookup"><span data-stu-id="fbdac-111">Steps</span></span>

**<span data-ttu-id="fbdac-112">1) Unity をインストールします。</span><span class="sxs-lookup"><span data-stu-id="fbdac-112">1) Install Unity</span></span>**

<span data-ttu-id="fbdac-113">Unity 5.6 以上をインストールし、Xbox One エディター拡張機能がインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-113">Install Unity 5.6 or higher, and ensure you have the Xbox One editor extension installed.</span></span>

<span data-ttu-id="fbdac-114">**2) WinMDs を使用するときに IntelliSense をサポートするために、Visual Studio Tools for Unity バージョン 3.1 以上をインストールします。**Visual Studio 2015 の場合、このツールは https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity で入手できます。</span><span class="sxs-lookup"><span data-stu-id="fbdac-114">**2) Install Visual Studio Tools for Unity version 3.1 and above for IntelliSense support when using WinMDs** For Visual Studio 2015, this can be found at https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity.</span></span>  <span data-ttu-id="fbdac-115">Visual Studio 2017 の場合、Visual Studio 2017 インストーラー内でこのコンポーネントを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="fbdac-115">For Visual Studio 2017, the component can be added inside the Visual Studio 2017 installer.</span></span>

**<span data-ttu-id="fbdac-116">3) 新規または既存の Unity プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="fbdac-116">3) Open a new or existing Unity project</span></span>**

**<span data-ttu-id="fbdac-117">4) Unity の [Build Settings] メニューで、プラットフォームを Xbox One に切り替えます。</span><span class="sxs-lookup"><span data-stu-id="fbdac-117">4) Switch the platform to Xbox One in the Unity Build Settings menu</span></span>**

**<span data-ttu-id="fbdac-118">5) Unity のプレイヤーの設定で IL2CPP スクリプト バックエンドを有効にして、API の互換性を .NET 4.6 に設定します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-118">5) Enable IL2CPP scripting backend in the Unity player settings, and set API compatibility to .NET 4.6</span></span>**

![](../images/unity/unity-il2cpp-1.png)

**<span data-ttu-id="fbdac-119">6) Xbox One の該当するシステム ライブラリがすべて自動的にプロジェクトに追加されるので、プラットフォーム バイナリを取り込むための追加の手順は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="fbdac-119">6) The Xbox One appropriate system libraries will all be added automatically to your project, and no extra steps are needed to include the platform binaries.</span></span>**

**<span data-ttu-id="fbdac-120">7) 新しい C\# スクリプトを Unity オブジェクトに追加およびアタッチします。</span><span class="sxs-lookup"><span data-stu-id="fbdac-120">7) Add and attach a new C\# script to a Unity object.</span></span>**

<span data-ttu-id="fbdac-121">たとえば、"Main Camera" などの Unity オブジェクトをクリックし、[Add Component]、[New Script]、[C\# Script] の順にクリックして、"XboxLiveScript" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="fbdac-121">For example, click on a Unity object such as the "Main Camera", and click "Add Component" \| "New Script" \| C\# Script \| and name it "XboxLiveScript".</span></span> <span data-ttu-id="fbdac-122">ゲーム オブジェクトの種類は問いません。</span><span class="sxs-lookup"><span data-stu-id="fbdac-122">Any game object will do.</span></span>

**<span data-ttu-id="fbdac-123">8) Visual Studio (VSTU 3.1+ がインストールされていること) でスクリプトを開きます。</span><span class="sxs-lookup"><span data-stu-id="fbdac-123">8) Open the script in Visual Studio (with VSTU 3.1+ installed)</span></span>**

<span data-ttu-id="fbdac-124">2 つのプロジェクトを確認し、VSTU によって生成された "Player" プロジェクト内のゲーム スクリプト XboxLiveTest.cs を開きます。</span><span class="sxs-lookup"><span data-stu-id="fbdac-124">You will notice two projects, open your game script XboxLiveTest.cs in the "Player" project generated by VSTU</span></span>

![](../images/unity/unity-il2cpp-2.png)

<span data-ttu-id="fbdac-125">このプロジェクトは XDK 用に生成された特別なプロジェクトであり、アセットに配置した winmd ファイルへの参照が含まれています。</span><span class="sxs-lookup"><span data-stu-id="fbdac-125">This is a special project generated for XDK, and includes references for the winmd files you have placed in your assets.</span></span>
<span data-ttu-id="fbdac-126">また、"#if ENABLE_WINMD_SUPPORT" 定義が自動的に設定されるため、IntelliSense と構文の強調表示が適切に機能します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-126">It will also define the "#if ENABLE_WINMD_SUPPORT" define for you so IntelliSense and syntax highlighting will work properly.</span></span>

**<span data-ttu-id="fbdac-127">9) 次の Xbox Live コードを XboxLiveTest.cs ソース ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-127">9) Add the following Xbox Live code to the XboxLiveTest.cs source file</span></span>**

```cpp

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class XboxLiveTest : MonoBehaviour
{
#if ENABLE_WINMD_SUPPORT
    Windows.Xbox.System.User mCurrentUser = null;
    XboxLiveContext mContext = null;
#endif

    // Use this for initialization
    void Start()
    {
#if ENABLE_WINMD_SUPPORT
        mCurrentUser = Windows.Xbox.ApplicationModel.Core.CoreApplicationContext.CurrentUser;
        mContext = new XboxLiveContext(mCurrentUser);
#endif
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnGUI()
    {
        if(mContext != null) Gui.TextArea(new Rect(10,10,50,200), mContext.XboxUserId);
    }
}

```

**<span data-ttu-id="fbdac-128">10) プレイヤーの設定内にある公開の設定で、"InternetClient" 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-128">10)   Make sure you have 'InternetClient' capability selected in the publishing settings found in player settings</span></span>**

![](../images/unity/unity-il2cpp-3.png)

**<span data-ttu-id="fbdac-129">11) Unity でプロジェクトを ビルドします。</span><span class="sxs-lookup"><span data-stu-id="fbdac-129">11) Build the project in Unity.</span></span>**

1.  <span data-ttu-id="fbdac-130">[File]、[Build Settings] の順に移動し、[Xbox One] をクリックしてから、必ず [Switch Platform] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="fbdac-130">Go to File \| Build Settings, click Xbox One and make sure you click “Switch Platform”</span></span>

2.  <span data-ttu-id="fbdac-131">[Add Open Scenes] をクリックして、現在のシーンをビルドに追加します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-131">Click "Add Open Scenes" to add the current scene to the build</span></span>

5.  <span data-ttu-id="fbdac-132">[Unity C\# Projects] チェック ボックスをオンにして、Assembly-Csharp.dll プロジェクトを生成します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-132">Click the "Unity C\# Projects" checkbox to generate the Assembly-Csharp.dll projects</span></span>

6.  <span data-ttu-id="fbdac-133">Unity の [Build] をクリックして、XDK アプリケーション内に Unity ゲームをラップする XDK Visual Studio プロジェクトを生成します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-133">Click "Build" for Unity to generate the XDK Visual Studio project that wraps your Unity game in a XDK application.</span></span> <span data-ttu-id="fbdac-134">新しいファイルが多数作成されるため、場所を指定するときは、混乱を避けるために新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-134">When you get prompted for a location, create a new folder to avoid confusion since a lot of new files will be created.</span></span> <span data-ttu-id="fbdac-135">フォルダーの名前を "Build" にすることをお勧めします。フォルダーに名前を付けたら、そのフォルダーを選択します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-135">It’s recommended you call the folder "Build", and then select that folder</span></span>

**<span data-ttu-id="fbdac-136">13) Visual Studio から XDK アプリをコンパイルして実行します。</span><span class="sxs-lookup"><span data-stu-id="fbdac-136">13) Compile and run the XDK app from Visual Studio</span></span>**

<span data-ttu-id="fbdac-137">これにより、通常の Xbox One ERA タイトルのようにアプリが起動し、Xbox Live 呼び出しが可能になります。</span><span class="sxs-lookup"><span data-stu-id="fbdac-137">This will launch the app like a normal Xbox One ERA title and allow Xbox Live calls to operate.</span></span>

**<span data-ttu-id="fbdac-138">14) Unity で変更を加えた場合はリビルドします。</span><span class="sxs-lookup"><span data-stu-id="fbdac-138">14) Rebuild if you make changes to anything in Unity</span></span>**
  
<span data-ttu-id="fbdac-139">Unity で変更を加えた場合、UWP プロジェクトをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fbdac-139">If you change anything in Unity, then you must rebuild the UWP project.</span></span>
