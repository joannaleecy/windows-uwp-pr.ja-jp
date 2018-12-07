---
title: XDK 用 Unity と IL2CPP バックエンド
description: ID@Xbox および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを XDK 用 Unity に追加する
ms.assetid: 790a49ad-eff4-4916-8578-968ca8483211
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity
ms.localizationpriority: medium
ms.openlocfilehash: cfd722ca0d0b080f6395680cd62000cea9b402fa
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8779071"
---
# <a name="add-xbox-live-support-to-unity-for-xdk-with-il2cpp-scripting-backend-for-idxbox-and-managed-partners"></a><span data-ttu-id="0714a-104">ID@Xbox および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを XDK 用 Unity に追加する</span><span class="sxs-lookup"><span data-stu-id="0714a-104">Add Xbox Live support to Unity for XDK with IL2CPP scripting backend for ID@Xbox and managed partners</span></span>

## <a name="overview"></a><span data-ttu-id="0714a-105">概要</span><span class="sxs-lookup"><span data-stu-id="0714a-105">Overview</span></span>

<span data-ttu-id="0714a-106">Unity での IL2CPP 用の Windows ランタイム サポート</span><span class="sxs-lookup"><span data-stu-id="0714a-106">Windows Runtime Support for IL2CPP in Unity</span></span>

<span data-ttu-id="0714a-107">Unity 5.6f3 のリリースでは、エンジンに新しい機能が組み込まれました。この新機能によって、開発者は Windows ランタイム (WinRT) コンポーネントをスクリプト内で直接使用することができます。そのためには、コンポーネントをゲーム プロジェクトに直接取り込みます。</span><span class="sxs-lookup"><span data-stu-id="0714a-107">With the release of Unity 5.6f3 the engine has included a new feature that enables developers to use Windows Runtime (WinRT) components directly in script by including them in the game project directly.</span></span> <span data-ttu-id="0714a-108">Until 5.6 を利用していた開発者は、ゲーム スクリプトでプラットフォーム機能 (Xbox Live SDK など) をサポートするために、プラグインや dll を必要としていました。</span><span class="sxs-lookup"><span data-stu-id="0714a-108">Until 5.6 developers have needed a plugin, or dll to support any platform feature (including Xbox Live SDK) from game script.</span></span> <span data-ttu-id="0714a-109">この新しいプロジェクション レイヤーによって、プラグインを使用する必要がなくなり、IL2CPP スクリプト バックエンドを選んだゲームでのみサポートされる、新しい簡略化されたワークフローが導入されました。</span><span class="sxs-lookup"><span data-stu-id="0714a-109">This new projection layer removes the plugin requirement, and introduces a new and simplified workflow supported only with games that choose the IL2CPP scripting backend.</span></span>

<span data-ttu-id="0714a-110">作業を開始する方法について詳しくは、Unity のドキュメント (https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0714a-110">For more information on how to get started, see the Unity documentation: https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html</span></span>

## <a name="steps"></a><span data-ttu-id="0714a-111">手順</span><span class="sxs-lookup"><span data-stu-id="0714a-111">Steps</span></span>

**<span data-ttu-id="0714a-112">1) Unity をインストールします。</span><span class="sxs-lookup"><span data-stu-id="0714a-112">1) Install Unity</span></span>**

<span data-ttu-id="0714a-113">Unity 5.6 以上をインストールし、Xbox One エディター拡張機能がインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0714a-113">Install Unity 5.6 or higher, and ensure you have the Xbox One editor extension installed.</span></span>

<span data-ttu-id="0714a-114">**2) WinMDs を使用するときに IntelliSense をサポートするために、Visual Studio Tools for Unity バージョン 3.1 以上をインストールします。** Visual Studio 2015 の場合、このツールは https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity で入手できます。</span><span class="sxs-lookup"><span data-stu-id="0714a-114">**2) Install Visual Studio Tools for Unity version 3.1 and above for IntelliSense support when using WinMDs** For Visual Studio 2015, this can be found at https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity.</span></span>  <span data-ttu-id="0714a-115">Visual Studio 2017 の場合、Visual Studio 2017 インストーラー内でこのコンポーネントを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="0714a-115">For Visual Studio 2017, the component can be added inside the Visual Studio 2017 installer.</span></span>

**<span data-ttu-id="0714a-116">3) 新規または既存の Unity プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="0714a-116">3) Open a new or existing Unity project</span></span>**

**<span data-ttu-id="0714a-117">4) Unity の [Build Settings] メニューで、プラットフォームを Xbox One に切り替えます。</span><span class="sxs-lookup"><span data-stu-id="0714a-117">4) Switch the platform to Xbox One in the Unity Build Settings menu</span></span>**

**<span data-ttu-id="0714a-118">5) Unity のプレイヤーの設定で IL2CPP スクリプト バックエンドを有効にして、API の互換性を .NET 4.6 に設定します。</span><span class="sxs-lookup"><span data-stu-id="0714a-118">5) Enable IL2CPP scripting backend in the Unity player settings, and set API compatibility to .NET 4.6</span></span>**

![](../images/unity/unity-il2cpp-1.png)

**<span data-ttu-id="0714a-119">6) スクリプト コンパイラを Roslyn に切り替えます。</span><span class="sxs-lookup"><span data-stu-id="0714a-119">6) Switch the Script Compiler to Roslyn</span></span>**

**<span data-ttu-id="0714a-120">7) Xbox One の該当するシステム ライブラリがすべて自動的にプロジェクトに追加されます。プラットフォーム バイナリを取り込むための追加の手順は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="0714a-120">7) The Xbox One appropriate system libraries will all be added automatically to your project, and no extra steps are needed to include the platform binaries.</span></span>**

**<span data-ttu-id="0714a-121">8) 新しい C\# スクリプトを Unity オブジェクトに追加およびアタッチします。</span><span class="sxs-lookup"><span data-stu-id="0714a-121">8) Add and attach a new C\# script to a Unity object.</span></span>**

<span data-ttu-id="0714a-122">たとえば、"Main Camera" などの Unity オブジェクトをクリックし、[Add Component]、[New Script]、[C\# Script] の順にクリックして、"XboxLiveScript" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="0714a-122">For example, click on a Unity object such as the "Main Camera", and click "Add Component" \| "New Script" \| C\# Script \| and name it "XboxLiveScript".</span></span> <span data-ttu-id="0714a-123">ゲーム オブジェクトの種類は問いません。</span><span class="sxs-lookup"><span data-stu-id="0714a-123">Any game object will do.</span></span>

**<span data-ttu-id="0714a-124">9) Visual Studio (VSTU 3.1+ がインストールされていること) でスクリプトを開きます。</span><span class="sxs-lookup"><span data-stu-id="0714a-124">9) Open the script in Visual Studio (with VSTU 3.1+ installed)</span></span>**

<span data-ttu-id="0714a-125">2 つのプロジェクトを確認し、VSTU によって生成された "Player" プロジェクト内のゲーム スクリプト XboxLiveTest.cs を開きます。</span><span class="sxs-lookup"><span data-stu-id="0714a-125">You will notice two projects, open your game script XboxLiveTest.cs in the "Player" project generated by VSTU</span></span>

![](../images/unity/unity-il2cpp-2.png)

<span data-ttu-id="0714a-126">このプロジェクトは XDK 用に生成された特別なプロジェクトであり、アセットに配置した winmd ファイルへの参照が含まれています。</span><span class="sxs-lookup"><span data-stu-id="0714a-126">This is a special project generated for XDK, and includes references for the winmd files you have placed in your assets.</span></span>
<span data-ttu-id="0714a-127">また、"#if ENABLE_WINMD_SUPPORT" 定義が自動的に設定されるため、IntelliSense と構文の強調表示が適切に機能します。</span><span class="sxs-lookup"><span data-stu-id="0714a-127">It will also define the "#if ENABLE_WINMD_SUPPORT" define for you so IntelliSense and syntax highlighting will work properly.</span></span>

**<span data-ttu-id="0714a-128">10) 次の Xbox Live コードを XboxLiveTest.cs ソース ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="0714a-128">10) Add the following Xbox Live code to the XboxLiveTest.cs source file</span></span>**

```csharp

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

**<span data-ttu-id="0714a-129">11) プレイヤーの設定内にある公開の設定で、"InternetClient" 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="0714a-129">11)   Make sure you have 'InternetClient' capability selected in the publishing settings found in player settings</span></span>**

![](../images/unity/unity-il2cpp-3.png)

**<span data-ttu-id="0714a-130">12) Unity でプロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="0714a-130">12) Build the project in Unity.</span></span>**
