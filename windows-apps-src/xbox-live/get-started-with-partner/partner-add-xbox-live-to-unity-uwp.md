---
title: "UWP 用 Unity と .NET スクリプト"
author: KevinAsgari
description: "ID@Xbox および対象パートナー向けに、.NET スクリプト バックエンドを使用して、Xbox Live サポートを UWP 用 Unity に追加する"
ms.assetid: 790a49ad-eff4-4916-8578-968ca8483211
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity"
ms.openlocfilehash: b71ff7da5e8d4963f860690d34eae0d5a4b602b1
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="add-xbox-live-support-to-unity-for-uwp-with-net-scripting-backend-for-idxbox-and-managed-partners"></a><span data-ttu-id="fb6da-104">ID@Xbox および対象パートナー向けに、.NET スクリプト バックエンドを使用して、Xbox Live サポートを UWP 用 Unity に追加する</span><span class="sxs-lookup"><span data-stu-id="fb6da-104">Add Xbox Live support to Unity for UWP with .NET scripting backend for ID@Xbox and managed partners</span></span>

**<span data-ttu-id="fb6da-105">1) Unity をインストールします。</span><span class="sxs-lookup"><span data-stu-id="fb6da-105">1) Install Unity</span></span>**

<span data-ttu-id="fb6da-106">Unity 5.3 以上をインストールします。Unity のインストール プロセスで、[Windows Store .NET Scripting backend] コンポーネントをオンにします。</span><span class="sxs-lookup"><span data-stu-id="fb6da-106">Install Unity 5.3 or higher and during the Unity install process, check the "Windows Store .NET Scripting backend" component.</span></span>

![](../images/unity/unity1-install.png)

**<span data-ttu-id="fb6da-107">2) 新規または既存の Unity プロジェクトを開きます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-107">2) Open a new or existing Unity project</span></span>**

<span data-ttu-id="fb6da-108">このプロジェクトは、3D プロジェクトまたは 2D プロジェクトのいずれかですが、</span><span class="sxs-lookup"><span data-stu-id="fb6da-108">It can be a 3D or 2D project.</span></span> <span data-ttu-id="fb6da-109">どちらの種類のプロジェクトも Xbox Live SDK で動作します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-109">Either type will work with the Xbox Live SDK.</span></span>

**<span data-ttu-id="fb6da-110">3) Microsoft.Xbox.Services.winmd ファイルを Unity Assets フォルダーにドラッグ アンド ドロップします。</span><span class="sxs-lookup"><span data-stu-id="fb6da-110">3) Drag and drop the Microsoft.Xbox.Services.winmd file to the Unity Assets folder</span></span>**

![](../images/unity/unity2-winmd.png)

<span data-ttu-id="fb6da-111">そのためには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-111">To do this,</span></span>

1.  <span data-ttu-id="fb6da-112">Xbox Live WinMD を [http://aka.ms/xboxlivesdkunity](http://aka.ms/xboxlivesdkunity) からダウンロードし、ハード ディスク上の適当な場所に展開します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-112">Download the Xbox Live WinMD from [http://aka.ms/xboxlivesdkunity](http://aka.ms/xboxlivesdkunity) and extract it to somewhere on your hard drive.</span></span>

2.  <span data-ttu-id="fb6da-113">Microsoft.Xbox.Services.winmd を、開いている Unity プロジェクトのアセット パネルにドラッグ アンド ドロップします。</span><span class="sxs-lookup"><span data-stu-id="fb6da-113">Drag and drop Microsoft.Xbox.Services.winmd into your open Unity project assets panel</span></span>

<span data-ttu-id="fb6da-114">Xbox Live 呼び出しを含むスクリプトを Unity エディター内から実行することはできませんが、この手順を行うことにより、Xbox Live 呼び出しを含むスクリプトを Unity エディター内からコンパイルできるようになります。</span><span class="sxs-lookup"><span data-stu-id="fb6da-114">While you cannot run scripts with Xbox Live calls from within the Unity editor, doing this step will enable scripts that have Xbox Live calls to be compiled from within the Unity editor.</span></span>

**<span data-ttu-id="fb6da-115">4) 新しい C\# スクリプトを Unity オブジェクトに追加およびアタッチします。</span><span class="sxs-lookup"><span data-stu-id="fb6da-115">4) Add and attach a new C\# script to a Unity object.</span></span>**

<span data-ttu-id="fb6da-116">たとえば、"Main Camera" などの Unity オブジェクトをクリックし、[Add Component]、[New Script]、[C\# Script] の順にクリックして、"XboxLiveScript" という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-116">For example, click on a Unity object such as the "Main Camera", and click "Add Component" \| "New Script" \| C\# Script \| and name it "XboxLiveScript".</span></span> <span data-ttu-id="fb6da-117">ゲーム オブジェクトの種類は問いません。</span><span class="sxs-lookup"><span data-stu-id="fb6da-117">Any game object will do.</span></span>

**<span data-ttu-id="fb6da-118">5) Unity でプロジェクトを ビルドします。</span><span class="sxs-lookup"><span data-stu-id="fb6da-118">5) Build the project in Unity.</span></span>**

1.  <span data-ttu-id="fb6da-119">[File]、[Build Settings] の順に移動し、[Windows Store] をクリックして、[Switch Platform] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="fb6da-119">Go to File \| Build Settings, click Windows Store and make sure you click “Switch Platform”</span></span>

2.  <span data-ttu-id="fb6da-120">[Add Open Scenes] をクリックして、現在のシーンをビルドに追加します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-120">Click "Add Open Scenes" to add the current scene to the build</span></span>

3.  <span data-ttu-id="fb6da-121">[SDK] コンボ ボックスで、[Universal 10] を選択します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-121">In the SDK combo box, choose "Universal 10"</span></span>

4.  <span data-ttu-id="fb6da-122">UWP ビルド タイプのコンボ ボックスで [D3D] を選択しますが、必要に応じて [XAML] も選択できます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-122">In the UWP build type combo box, choose "D3D", but "XAML" will also work if you prefer.</span></span>

5.  <span data-ttu-id="fb6da-123">[Unity C\# Projects] チェック ボックスをオンにして、Assembly-Csharp.dll プロジェクトを生成します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-123">Click the "Unity C\# Projects" checkbox to generate the Assembly-Csharp.dll projects</span></span>

6.  <span data-ttu-id="fb6da-124">Unity の [Build] をクリックして、XDK アプリケーション内に Unity ゲームをラップする UWP Visual Studio プロジェクトを生成します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-124">Click "Build" for Unity to generate the UWP Visual Studio project that wraps your Unity game in a UWP application.</span></span> <span data-ttu-id="fb6da-125">新しいファイルが多数作成されるため、場所を指定するときは、混乱を避けるために新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-125">When you get prompted for a location, create a new folder to avoid confusion since a lot of new files will be created.</span></span> <span data-ttu-id="fb6da-126">フォルダーの名前を "Build" にすることをお勧めします。フォルダーに名前を付けたら、そのフォルダーを選択します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-126">It’s recommended you call the folder "Build", and then select that folder</span></span>

![](../images/unity/unity3-buildsettings.png)

  

**<span data-ttu-id="fb6da-127">6) 生成した UWP プロジェクトを Visual Studio で開きます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-127">6) Open the generated UWP project in Visual Studio</span></span>**

<span data-ttu-id="fb6da-128">Unity では、エクスプローラーで出力プロジェクト フォルダーが開きます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-128">Unity will open the output project folder in Explorer.</span></span>  <span data-ttu-id="fb6da-129">フォルダー内の .sln ファイルは無視してください。</span><span class="sxs-lookup"><span data-stu-id="fb6da-129">Ignore the .sln file there.</span></span>  <span data-ttu-id="fb6da-130">代わりに、Build フォルダーに移動し、生成された .sln を Visual Studio で開きます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-130">Instead navigate into your Build folder and open the generated .sln in Visual Studio.</span></span>  

<span data-ttu-id="fb6da-131">このソリューションには 3 つのプロジェクトがあります。</span><span class="sxs-lookup"><span data-stu-id="fb6da-131">You'll see 3 projects in this solution.</span></span>

1.  <span data-ttu-id="fb6da-132">Assembly-CSharp。</span><span class="sxs-lookup"><span data-stu-id="fb6da-132">Assembly-CSharp.</span></span> <span data-ttu-id="fb6da-133">Xbox Live スクリプトが配置される場所です。</span><span class="sxs-lookup"><span data-stu-id="fb6da-133">This is where your Xbox Live scripts will live</span></span>

2.  <span data-ttu-id="fb6da-134">Assembly-Csharp-firstpass。</span><span class="sxs-lookup"><span data-stu-id="fb6da-134">Assembly-Csharp-firstpass.</span></span> <span data-ttu-id="fb6da-135">今回、このプロジェクトは無視してかまいません。</span><span class="sxs-lookup"><span data-stu-id="fb6da-135">This project can be ignored for our purposes.</span></span>

3.  <span data-ttu-id="fb6da-136">プロジェクトの名前に基づいた UWP アプリ。</span><span class="sxs-lookup"><span data-stu-id="fb6da-136">UWP app based on the name of your project.</span></span> <span data-ttu-id="fb6da-137">これは、Unity エンジンをホストする従来の UWP アプリです。</span><span class="sxs-lookup"><span data-stu-id="fb6da-137">This is a traditional UWP app that hosts the Unity engine.</span></span> <span data-ttu-id="fb6da-138">ここでは、従来の UWP アプリに似たいくつかの Xbox Live 構成をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="fb6da-138">This is where you'll be setting up some Xbox Live configuration similar to a traditional UWP app.</span></span>

**<span data-ttu-id="fb6da-139">7) "Microsoft.Xbox.Live.SDK.WinRT.UWP" NuGet パッケージ参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-139">7) Add the "Microsoft.Xbox.Live.SDK.WinRT.UWP" NuGet package references</span></span>**

<span data-ttu-id="fb6da-140">「[Xbox Live API のバイナリ パッケージを UWP プロジェクトに追加する](add-xbox-live-apis-binary-to-a-uwp-project.md)」の手順に従います</span><span class="sxs-lookup"><span data-stu-id="fb6da-140">Follow [Adding Xbox Live APIs binary package to your UWP project](add-xbox-live-apis-binary-to-a-uwp-project.md)</span></span>

<span data-ttu-id="fb6da-141">"Microsoft.Xbox.Live.SDK.WinRT.UWP" NuGet パッケージ参照を UWP アプリ プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-141">Add the "Microsoft.Xbox.Live.SDK.WinRT.UWP" NuGet package references to the UWP app project</span></span>

**<span data-ttu-id="fb6da-142">8) Xbox Live 構成を UWP アプリに追加します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-142">8) Add Xbox Live configuration to the UWP app</span></span>**

<span data-ttu-id="fb6da-143">「[新規または既存の UWP プロジェクトに Xbox Live を追加する](get-started-with-visual-studio-and-uwp.md)」というドキュメント ページの手順に従います。</span><span class="sxs-lookup"><span data-stu-id="fb6da-143">Follow the doc page called [Adding Xbox Live to a new or existing UWP project](get-started-with-visual-studio-and-uwp.md)</span></span>

**<span data-ttu-id="fb6da-144">9) Xbox Live コードをスクリプトに追加します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-144">9) Add Xbox Live code to your script</span></span>**

<span data-ttu-id="fb6da-145">以下のサンプルの Xbox Live コードをコピーし、ゲーム オブジェクトにアタッチしたスクリプトに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-145">Copy/paste this example Xbox Live code into script you attached to the game object.</span></span> <span data-ttu-id="fb6da-146">このスクリプトは "Assembly-CSharp" プロジェクトに表示されます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-146">This script will appear in the "Assembly-CSharp" project.</span></span> <span data-ttu-id="fb6da-147">コードは自由に変更できます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-147">You can change the code as desired.</span></span>

```cpp
#if NETFX_CORE

using UnityEngine;
using System;
using Microsoft.Xbox.Services.System;

public class XboxLiveScript : MonoBehaviour
{
    Microsoft.Xbox.Services.System.XboxLiveUser m_user = new Microsoft.Xbox.Services.System.XboxLiveUser();
    Microsoft.Xbox.Services.XboxLiveContext m_xboxLiveContext = null;
    Windows.UI.Core.CoreDispatcher UIDispatcher = null;
    string debugText = "";

    void Start()
    {
        Windows.ApplicationModel.Core.CoreApplicationView mainView = Windows.ApplicationModel.Core.CoreApplication.MainView;
        Windows.UI.Core.CoreWindow cw = mainView.CoreWindow;

        UIDispatcher = cw.Dispatcher;
        SignIn();
    }

    void Update()
    {
    }

    void OnGUI()
    {
        GUI.Label(new UnityEngine.Rect(10, 10, 300, 50), debugText);
    }

    async void SignIn()
    {
        SignInResult result = await m_user.SignInAsync(UIDispatcher);

        if (result.Status == SignInStatus.Success)
        {
            m_xboxLiveContext = new Microsoft.Xbox.Services.XboxLiveContext(m_user);
            debugText += "\n User signed in: " + m_xboxLiveContext.User.Gamertag;
        }
    }
}

#endif
```

**<span data-ttu-id="fb6da-148">10) Visual Studio から UWP アプリをコンパイルして実行します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-148">10) Compile and run the UWP app from Visual Studio</span></span>**

<span data-ttu-id="fb6da-149">これにより、通常の UWP アプリのようにアプリが起動し、動作のために UWP アプリ コンテナーが必要なときに Xbox Live 呼び出しが可能になります。</span><span class="sxs-lookup"><span data-stu-id="fb6da-149">This will launch the app like a normal UWP app and allow Xbox Live calls to operate as they require a UWP app container to function.</span></span>

**<span data-ttu-id="fb6da-150">11) Unity で変更を加えた場合はリビルドします。</span><span class="sxs-lookup"><span data-stu-id="fb6da-150">11) Rebuild if you make changes to anything in Unity</span></span>**
  
<span data-ttu-id="fb6da-151">Unity で変更を加えた場合、UWP プロジェクトをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb6da-151">If you change anything in Unity, then you must rebuild the UWP project.</span></span>

<span data-ttu-id="fb6da-152">再コンパイル時に Unity が pfx ファイルを置き換えることによって Xbox Live へのサインインが失敗することに注意してください。この問題を避けるために Unity プロジェクト内でファイルを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fb6da-152">Note that Unity will replace your pfx file when you recompile which will cause Xbox Live sign-in to fail, so you must update it inside the Unity project to avoid this issue.</span></span>

<span data-ttu-id="fb6da-153">これを行うには、[File]、[Build Settings] の順に移動し、Windows Store プレイヤー上で [Build Settings] をクリックしてから、[PFX] ボタンをクリックして、PFX ファイルを前の手順で取得したファイルに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-153">To do this, go to File \| Build Settings, click on "Build Settings" on the Windows Store player and click the PFX button to replace the PFX file with the one you got from above.</span></span> <span data-ttu-id="fb6da-154">別の方法として、Unity 内でプロジェクトをリビルドするたびに PFX ファイルを削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-154">You can alternatively delete the PFX file each time you rebuild the project from within Unity.</span></span>

## <a name="troubleshooting-common-issues"></a><span data-ttu-id="fb6da-155">一般的な問題のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="fb6da-155">Troubleshooting common issues</span></span>

<span data-ttu-id="fb6da-156">**1)** Unity において、関連付けられたスクリプトを読み込めない場合、手順 3 を実行して WinMD を Unity のプロジェクト アセット パネルにドラッグしたことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="fb6da-156">**1)** If Unity has that an associated script can not be loaded, then ensure that you did step 3 to drag the WinMD to the Unity project assets panel</span></span>

<span data-ttu-id="fb6da-157">**2)** 起動後すぐ、または次のコード行を実行しようとしたときにアプリがクラッシュする場合:</span><span class="sxs-lookup"><span data-stu-id="fb6da-157">**2)** If the app crashes immedately at startup or when trying to run this line of code:</span></span>

    Microsoft.Xbox.Services.System.XboxLiveUser m_user = new Microsoft.Xbox.Services.System.XboxLiveUser();

<span data-ttu-id="fb6da-158">xboxservices.config テキスト ファイルをプロジェクトに追加して、そのプロパティで "Build Action" を "Content" に、"Copy to Output Directory" を "Copy Always" に設定したことを確認します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-158">Ensure you have added a xboxservices.config text file to the project and in its properties, set the "Build Action" to "Content", and "Copy to Output Directory" set to "Copy Always".</span></span>
<span data-ttu-id="fb6da-159">また、次のような正しい JSON フォーマット (10 進形式の TitleId) がテキスト ファイルに含まれていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-159">Also ensure it contains proper JSON formatting with the TitleId in decimal form, such as:</span></span>

```json
{
    "TitleId" : 928643728,
    "PrimaryServiceConfigId" : "3ebd0100-ace5-4aa4-ab9c-5b733759fa90"
}
```

<span data-ttu-id="fb6da-160">**3)** アプリが起動するがサインインに失敗する場合は、以下を確認してください。</span><span class="sxs-lookup"><span data-stu-id="fb6da-160">**3)** If the app launches, but fails to signin then check the following:</span></span>

<span data-ttu-id="fb6da-161">a) コンピューターがデベロッパー サンドボックスに設定されていること。</span><span class="sxs-lookup"><span data-stu-id="fb6da-161">a) Your machine is set to the your developer sandbox.</span></span>  <span data-ttu-id="fb6da-162">これを行うには、Xbox Live SDK の \Tools フォルダーにある SwitchSandbox.cmd スクリプトを使用します。</span><span class="sxs-lookup"><span data-stu-id="fb6da-162">Use the SwitchSandbox.cmd script in the \Tools folder of the Xbox Live SDK to do this.</span></span>

<span data-ttu-id="fb6da-163">b) デベロッパー サンドボックスにアクセスできる Xbox Live アカウントでサインインしていること。</span><span class="sxs-lookup"><span data-stu-id="fb6da-163">b) You are signing in with an Xbox Live account that has access to the developer sandbox.</span></span>  <span data-ttu-id="fb6da-164">通常のリテール Xbox Live アカウントにはそのようなアクセス権がありません。</span><span class="sxs-lookup"><span data-stu-id="fb6da-164">Normal retail Xbox Live accounts don't have access.</span></span>  <span data-ttu-id="fb6da-165">XDP またはデベロッパー センターを使用してテスト アカウントを作成できます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-165">You can use XDP or Dev Center to create an test accounts.</span></span>

<span data-ttu-id="fb6da-166">c) UWP アプリの package.appxmanfiest で正しい Identity が設定されていること。</span><span class="sxs-lookup"><span data-stu-id="fb6da-166">c) Your package.appxmanfiest in your UWP app is set to the correct Identity.</span></span>  <span data-ttu-id="fb6da-167">これは手動で編集できますが、Visual Studio でプロジェクトを右クリックし、[ストア] の [アプリケーションをストアと関連付ける] を選択するのが最も簡単な修正方法です。</span><span class="sxs-lookup"><span data-stu-id="fb6da-167">You can edit this manually, but the easiest way to fix this is to right click on the Project in Visual Studio and choose "Store" \| "Associate App with the Store".</span></span>

<span data-ttu-id="fb6da-168">d) Unity によって提供されるストック .pfx ファイルは Identity が正しくないため、そのファイルをディスクから削除し、そのファイルを参照する行を .csproj から削除します。または、Visual Studio でプロジェクトを右クリックし、[ストア] の [アプリケーションをストアと関連付ける] を選択すれば、適切な .pfx ファイルが配置されます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-168">d) The stock .pfx file provided by Unity won't have the correct identity so either delete it from the disk and remove the line in the .csproj that references it, or right click on the Project in Visual Studio and choose "Store" \| "Associate App with the Store" which will place down a proper .pfx file.</span></span>  <span data-ttu-id="fb6da-169">その後、Unity に戻って Windows Store プレイヤー上で [Build Settings] をクリックし、[PFX] ボタンをクリックして、.pfx ファイルを Visual Studio での [アプリケーションをストアと関連付ける] 操作により取得したファイルに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="fb6da-169">Be sure then to go back to Unity, click on "Build Settings" on the Windows Store player and click the PFX button to replace the .pfx file with the one you got from Visual Studio's "Associate App with the Store" action.</span></span>
