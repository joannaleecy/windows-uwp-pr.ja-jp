---
title: UWP 用 Unity と IL2CPP バックエンド
author: KevinAsgari
description: ID@Xbox および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを UWP 用 Unity に追加する
ms.assetid: 790a49ad-eff4-4916-8578-968ca8483211
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity
ms.localizationpriority: low
ms.openlocfilehash: c45bb6accfbb9c3ae6aa0684f701cdb5ed5ff63e
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="add-xbox-live-support-to-unity-for-uwp-with-il2cpp-scripting-backend-for-idxbox-and-managed-partners"></a><span data-ttu-id="54b1c-104">ID@Xbox および対象パートナー向けに、IL2CPP スクリプト バックエンドを使用して、Xbox Live サポートを UWP 用 Unity に追加する</span><span class="sxs-lookup"><span data-stu-id="54b1c-104">Add Xbox Live support to Unity for UWP with IL2CPP scripting backend for ID@Xbox and managed partners</span></span>

## <a name="overview"></a><span data-ttu-id="54b1c-105">概要</span><span class="sxs-lookup"><span data-stu-id="54b1c-105">Overview</span></span>

<span data-ttu-id="54b1c-106">Unity での IL2CPP 用の Windows ランタイム サポート</span><span class="sxs-lookup"><span data-stu-id="54b1c-106">Windows Runtime Support for IL2CPP in Unity</span></span>

<span data-ttu-id="54b1c-107">Unity 5.6f3 のリリースでは、エンジンに新しい機能が組み込まれました。この新機能によって、開発者は Windows ランタイム (WinRT) コンポーネントをスクリプト内で直接使用することができます。そのためには、コンポーネントをゲーム プロジェクトに直接取り込みます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-107">With the release of Unity 5.6f3 the engine has included a new feature that enables developers to use Windows Runtime (WinRT) components directly in script by including them in the game project directly.</span></span> <span data-ttu-id="54b1c-108">Until 5.6 を利用していた開発者は、UWP でゲーム スクリプトによってプラットフォーム機能 (Xbox Live SDK など) をサポートするために、プラグインや dll を必要としていました。</span><span class="sxs-lookup"><span data-stu-id="54b1c-108">Until 5.6 developers have needed a plugin, or dll to support any platform feature (including Xbox Live SDK) from game script in UWP.</span></span> <span data-ttu-id="54b1c-109">この新しいプロジェクション レイヤーによって、プラグインを使用する必要がなくなり、IL2CPP スクリプト バックエンドを選んだゲームでのみサポートされる、新しい簡略化されたワークフローが導入されました。</span><span class="sxs-lookup"><span data-stu-id="54b1c-109">This new projection layer removes the plugin requirement, and introduces a new and simplified workflow supported only with games that choose the IL2CPP scripting backend.</span></span>

<span data-ttu-id="54b1c-110">作業の開始方法について詳しくは、Unity に関するドキュメント (https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="54b1c-110">For more information on how to get started, see the Unity documentation: https://docs.unity3d.com/Manual/IL2CPP-WindowsRuntimeSupport.html</span></span>

## <a name="steps"></a><span data-ttu-id="54b1c-111">手順</span><span class="sxs-lookup"><span data-stu-id="54b1c-111">Steps</span></span>

**<span data-ttu-id="54b1c-112">1) Unity をインストールします。</span><span class="sxs-lookup"><span data-stu-id="54b1c-112">1) Install Unity</span></span>**

<span data-ttu-id="54b1c-113">Unity 5.6 以上をインストールし、インストール時には **[Windows Store Il2CPP scripting backend]** を必ず選択してください。</span><span class="sxs-lookup"><span data-stu-id="54b1c-113">Install Unity 5.6 or higher, and ensure you have the **Windows Store Il2CPP scripting backend** selected during installation</span></span>

<span data-ttu-id="54b1c-114">**2) WinMDs を使用するときに IntelliSense をサポートするために、Visual Studio Tools for Unity バージョン 3.1 以上をインストールします。** Visual Studio 2015 の場合、このツールは https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity で入手できます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-114">**2) Install Visual Studio Tools for Unity version 3.1 and above for IntelliSense support when using WinMDs** For Visual Studio 2015, this can be found at https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity.</span></span>  <span data-ttu-id="54b1c-115">Visual Studio 2017 の場合、Visual Studio 2017 インストーラー内でこのコンポーネントを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-115">For Visual Studio 2017, the component can be added inside the Visual Studio 2017 installer.</span></span>

**<span data-ttu-id="54b1c-116">3) 新規または既存の Unity プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-116">3) Open a new or existing Unity project</span></span>**

**<span data-ttu-id="54b1c-117">4) Unity の [Build Settings] メニューで、プラットフォームをユニバーサル Windows プラットフォームに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-117">4) Switch the platform to Universal Windows Platform in the Unity Build Settings menu</span></span>**

**<span data-ttu-id="54b1c-118">5) Unity のプレイヤーの設定で IL2CPP スクリプト バックエンドを有効にして、API の互換性を .NET 4.6 に設定します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-118">5) Enable IL2CPP scripting backend in the Unity player settings, and set API compatibility to .NET 4.6</span></span>**

![](../images/unity/unity-il2cpp-1.png)

<span data-ttu-id="54b1c-119">**6) 最新バージョンの Xbox Live WinRT Unity アセット パッケージをインポートします。** このパッケージは https://github.com/Microsoft/xbox-live-api/releases で入手できます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-119">**6) Import the latest version of the Xbox Live WinRT Unity asset package** This can be found at https://github.com/Microsoft/xbox-live-api/releases</span></span>

**<span data-ttu-id="54b1c-120">7) 新しい C\# スクリプトを Unity オブジェクトに追加およびアタッチします。</span><span class="sxs-lookup"><span data-stu-id="54b1c-120">7) Add and attach a new C\# script to a Unity object.</span></span>**

<span data-ttu-id="54b1c-121">たとえば、"Main Camera" などの Unity オブジェクトをクリックし、[Add Component]、[New Script]、[C\# Script] の順にクリックして、"XboxLiveScript" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-121">For example, click on a Unity object such as the "Main Camera", and click "Add Component" \| "New Script" \| C\# Script \| and name it "XboxLiveScript".</span></span> <span data-ttu-id="54b1c-122">ゲーム オブジェクトの種類は問いません。</span><span class="sxs-lookup"><span data-stu-id="54b1c-122">Any game object will do.</span></span>

**<span data-ttu-id="54b1c-123">8) Visual Studio (VSTU 3.1+ がインストールされていること) でスクリプトを開きます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-123">8) Open the script in Visual Studio (with VSTU 3.1+ installed)</span></span>**

<span data-ttu-id="54b1c-124">2 つのプロジェクトを確認し、VSTU によって生成された "Player" プロジェクト内のゲーム スクリプト XboxLiveTest.cs を開きます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-124">You will notice two projects, open your game script XboxLiveTest.cs in the "Player" project generated by VSTU</span></span>

![](../images/unity/unity-il2cpp-2.png)

<span data-ttu-id="54b1c-125">このプロジェクトは UWP 用に生成された特別なプロジェクトであり、アセットに配置した winmd ファイルへの参照が含まれています。</span><span class="sxs-lookup"><span data-stu-id="54b1c-125">This is a special project generated for UWP, and includes references for the winmd files you have placed in your assets.</span></span>
<span data-ttu-id="54b1c-126">また、"#if ENABLE_WINMD_SUPPORT" 定義が自動的に設定されるため、IntelliSense と構文の強調表示が適切に機能します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-126">It will also define the "#if ENABLE_WINMD_SUPPORT" define for you so IntelliSense and syntax highlighting will work properly.</span></span>

**<span data-ttu-id="54b1c-127">9) 次の Xbox Live コードを XboxLiveTest.cs ソース ファイルに追加します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-127">9) Add the following Xbox Live code to the XboxLiveTest.cs source file</span></span>**

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

**<span data-ttu-id="54b1c-128">10) プレイヤーの設定内にある公開の設定で、"InternetClient" 機能が選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-128">10)   Make sure you have 'InternetClient' capability selected in the publishing settings found in player settings</span></span>**

![](../images/unity/unity-il2cpp-3.png)

**<span data-ttu-id="54b1c-129">11) Unity でプロジェクトを ビルドします。</span><span class="sxs-lookup"><span data-stu-id="54b1c-129">11) Build the project in Unity.</span></span>**

1.  <span data-ttu-id="54b1c-130">[File]、[Build Settings] の順に移動し、**[ユニバーサル Windows プラットフォーム]** をクリックして、**[Switch Platform]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="54b1c-130">Go to File \| Build Settings, click **Universal Windows Platform** and make sure you click **Switch Platform**</span></span>

2.  <span data-ttu-id="54b1c-131">[Add Open Scenes] をクリックして、現在のシーンをビルドに追加します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-131">Click "Add Open Scenes" to add the current scene to the build</span></span>

3.  <span data-ttu-id="54b1c-132">[SDK] コンボ ボックスで、[Universal 10] を選択します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-132">In the SDK combo box, choose "Universal 10"</span></span>

4.  <span data-ttu-id="54b1c-133">UWP ビルド タイプのコンボ ボックスで [D3D] を選択しますが、必要に応じて [XAML] も選択できます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-133">In the UWP build type combo box, choose "D3D", but "XAML" will also work if you prefer.</span></span>

5.  <span data-ttu-id="54b1c-134">Unity の [Build] をクリックして、UWP アプリケーション内に Unity ゲームをラップする UWP Visual Studio プロジェクトを生成します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-134">Click "Build" for Unity to generate the UWP Visual Studio project that wraps your Unity game in a UWP application.</span></span> <span data-ttu-id="54b1c-135">新しいファイルが多数作成されるため、場所を指定するときは、混乱を避けるために新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-135">When you get prompted for a location, create a new folder to avoid confusion since a lot of new files will be created.</span></span> <span data-ttu-id="54b1c-136">フォルダーの名前を "Build" にすることをお勧めします。フォルダーに名前を付けたら、そのフォルダーを選択します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-136">It’s recommended you call the folder "Build", and then select that folder</span></span>

**<span data-ttu-id="54b1c-137">12) Xbox Live 構成をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-137">12) Add Xbox Live configuration to your project</span></span>**

<span data-ttu-id="54b1c-138">xboxservices.config ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-138">Add the xboxservices.config file:</span></span>

![](../images/unity/unity-il2cpp-4.png)

<span data-ttu-id="54b1c-139">「[新規または既存の UWP プロジェクトに Xbox Live を追加する](get-started-with-visual-studio-and-uwp.md)」というドキュメント ページの手順に従います。</span><span class="sxs-lookup"><span data-stu-id="54b1c-139">Follow the doc page called [Adding Xbox Live to a new or existing UWP project](get-started-with-visual-studio-and-uwp.md)</span></span>

> [!NOTE]
> <span data-ttu-id="54b1c-140">xboxservices.config 内のすべての値で大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-140">All values inside xboxservices.config are case sensitive.</span></span>

**<span data-ttu-id="54b1c-141">13) Visual Studio から UWP アプリをコンパイルして実行します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-141">13) Compile and run the UWP app from Visual Studio</span></span>**

<span data-ttu-id="54b1c-142">これにより、通常の UWP アプリのようにアプリが起動し、動作のために UWP アプリ コンテナーが必要なときに Xbox Live 呼び出しが可能になります。</span><span class="sxs-lookup"><span data-stu-id="54b1c-142">This will launch the app like a normal UWP app and allow Xbox Live calls to operate as they require a UWP app container to function.</span></span>

**<span data-ttu-id="54b1c-143">14) Unity で変更を加えた場合はリビルドします。</span><span class="sxs-lookup"><span data-stu-id="54b1c-143">14) Rebuild if you make changes to anything in Unity</span></span>**
  
<span data-ttu-id="54b1c-144">Unity で変更を加えた場合、UWP プロジェクトをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="54b1c-144">If you change anything in Unity, then you must rebuild the UWP project.</span></span>

<span data-ttu-id="54b1c-145">再コンパイル時に Unity が pfx ファイルを置き換えることによって Xbox Live へのサインインが失敗することに注意してください。この問題を避けるために Unity プロジェクト内でファイルを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="54b1c-145">Note that Unity will replace your pfx file when you recompile which will cause Xbox Live sign-in to fail, so you must update it inside the Unity project to avoid this issue.</span></span>

<span data-ttu-id="54b1c-146">これを行うには、[File]、[Build Settings] の順に移動し、**ユニバーサル Windows プラットフォーム** プレイヤー上で [Build Settings] をクリックしてから、[PFX] ボタンをクリックして、PFX ファイルを前の手順で取得したファイルに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-146">To do this, go to File \| Build Settings, click on "Build Settings" on the **Universal Windows Platform** player and click the PFX button to replace the PFX file with the one you got from above.</span></span> <span data-ttu-id="54b1c-147">別の方法として、Unity 内でプロジェクトをリビルドするたびに PFX ファイルを削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-147">You can alternatively delete the PFX file each time you rebuild the project from within Unity.</span></span>

## <a name="troubleshooting-common-issues"></a><span data-ttu-id="54b1c-148">一般的な問題のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="54b1c-148">Troubleshooting common issues</span></span>

<span data-ttu-id="54b1c-149">**1)** Unity において、関連付けられたスクリプトを読み込めない場合、手順 3 を実行して WinMD を Unity のプロジェクト アセット パネルにドラッグしたことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="54b1c-149">**1)** If Unity has that an associated script can not be loaded, then ensure that you did step 3 to drag the WinMD to the Unity project assets panel</span></span>

<span data-ttu-id="54b1c-150">**2)** 起動後すぐ、または次のコード行を実行しようとしたときにアプリがクラッシュする場合:</span><span class="sxs-lookup"><span data-stu-id="54b1c-150">**2)** If the app crashes immediately at startup or when trying to run this line of code:</span></span>

    Microsoft.Xbox.Services.System.XboxLiveUser m_user = new Microsoft.Xbox.Services.System.XboxLiveUser();

<span data-ttu-id="54b1c-151">xboxservices.config テキスト ファイルをプロジェクトに追加して、そのプロパティで "Build Action" を "Content" に、"Copy to Output Directory" を "Copy Always" に設定したことを確認します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-151">Ensure you have added a xboxservices.config text file to the project and in its properties, set the "Build Action" to "Content", and "Copy to Output Directory" set to "Copy Always".</span></span>
<span data-ttu-id="54b1c-152">また、次のような正しい JSON フォーマット (10 進形式の TitleId) がテキスト ファイルに含まれていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-152">Also ensure it contains proper JSON formatting with the TitleId in decimal form, such as:</span></span>

```json
{
    "TitleId" : 928643728,
    "PrimaryServiceConfigId" : "3ebd0100-ace5-4aa4-ab9c-5b733759fa90"
}
```

<span data-ttu-id="54b1c-153">**3)** アプリが起動するがサインインに失敗する場合は、以下を確認してください。</span><span class="sxs-lookup"><span data-stu-id="54b1c-153">**3)** If the app launches, but fails to signin then check the following:</span></span>

<span data-ttu-id="54b1c-154">a) コンピューターがデベロッパー サンドボックスに設定されていること。</span><span class="sxs-lookup"><span data-stu-id="54b1c-154">a) Your machine is set to the your developer sandbox.</span></span>  <span data-ttu-id="54b1c-155">これを行うには、Xbox Live SDK の \Tools フォルダーにある SwitchSandbox.cmd スクリプトを使用します。</span><span class="sxs-lookup"><span data-stu-id="54b1c-155">Use the SwitchSandbox.cmd script in the \Tools folder of the Xbox Live SDK to do this.</span></span>

<span data-ttu-id="54b1c-156">b) デベロッパー サンドボックスにアクセスできる Xbox Live アカウントでサインインしていること。</span><span class="sxs-lookup"><span data-stu-id="54b1c-156">b) You are signing in with an Xbox Live account that has access to the developer sandbox.</span></span>  <span data-ttu-id="54b1c-157">通常のリテール Xbox Live アカウントにはそのようなアクセス権がありません。</span><span class="sxs-lookup"><span data-stu-id="54b1c-157">Normal retail Xbox Live accounts don't have access.</span></span>  <span data-ttu-id="54b1c-158">XDP またはデベロッパー センターを使用してテスト アカウントを作成できます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-158">You can use XDP or Dev Center to create an test accounts.</span></span>

<span data-ttu-id="54b1c-159">c) UWP アプリの package.appxmanfiest で正しい Identity が設定されていること。</span><span class="sxs-lookup"><span data-stu-id="54b1c-159">c) Your package.appxmanfiest in your UWP app is set to the correct Identity.</span></span>  <span data-ttu-id="54b1c-160">これは手動で編集できますが、Visual Studio でプロジェクトを右クリックし、[ストア] の [アプリケーションをストアと関連付ける] を選択するのが最も簡単な修正方法です。</span><span class="sxs-lookup"><span data-stu-id="54b1c-160">You can edit this manually, but the easiest way to fix this is to right click on the Project in Visual Studio and choose "Store" \| "Associate App with the Store".</span></span>

<span data-ttu-id="54b1c-161">d) Unity によって提供されるストック .pfx ファイルは Identity が正しくないため、そのファイルをディスクから削除し、そのファイルを参照する行を .csproj から削除します。または、Visual Studio でプロジェクトを右クリックし、[ストア] の [アプリケーションをストアと関連付ける] を選択すれば、適切な .pfx ファイルが配置されます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-161">d) The stock .pfx file provided by Unity won't have the correct identity so either delete it from the disk and remove the line in the .csproj that references it, or right click on the Project in Visual Studio and choose "Store" \| "Associate App with the Store" which will place down a proper .pfx file.</span></span>  <span data-ttu-id="54b1c-162">その後、Unity に戻って **ユニバーサル Windows プラットフォーム** プレイヤー上で [Build Settings] をクリックし、[PFX] ボタンをクリックして、.pfx ファイルを Visual Studio での [アプリケーションを Microsoft Store と関連付ける] 操作により取得したファイルに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="54b1c-162">Be sure then to go back to Unity, click on "Build Settings" on the **Universal Windows Platform** player and click the PFX button to replace the .pfx file with the one you got from Visual Studio's "Associate App with the Store" action.</span></span>
