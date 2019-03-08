---
title: UWP 用 Unity と .NET スクリプト
description: ID@Xbox および対象パートナー向けに、.NET スクリプト バックエンドを使用して、Xbox Live サポートを UWP 用 Unity に追加する
ms.assetid: 790a49ad-eff4-4916-8578-968ca8483211
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity
ms.localizationpriority: medium
ms.openlocfilehash: 8c4ca9d58f89e215563adcc7985b978641efdf07
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594087"
---
# <a name="add-xbox-live-support-to-unity-for-uwp-with-net-scripting-backend-for-idxbox-and-managed-partners"></a><span data-ttu-id="b4a84-104">ID@Xbox および対象パートナー向けに、.NET スクリプト バックエンドを使用して、Xbox Live サポートを UWP 用 Unity に追加する</span><span class="sxs-lookup"><span data-stu-id="b4a84-104">Add Xbox Live support to Unity for UWP with .NET scripting backend for ID@Xbox and managed partners</span></span>

<span data-ttu-id="b4a84-105">**1) Unity をインストールします。**</span><span class="sxs-lookup"><span data-stu-id="b4a84-105">**1) Install Unity**</span></span>

<span data-ttu-id="b4a84-106">Unity 5.3 以上をインストールします。Unity のインストール プロセスで、[Windows Store .NET Scripting backend] コンポーネントをオンにします。</span><span class="sxs-lookup"><span data-stu-id="b4a84-106">Install Unity 5.3 or higher and during the Unity install process, check the "Windows Store .NET Scripting backend" component.</span></span>

![](../images/unity/unity1-install.png)

<span data-ttu-id="b4a84-107">**2) 新しいまたは既存の Unity プロジェクトを開く**</span><span class="sxs-lookup"><span data-stu-id="b4a84-107">**2) Open a new or existing Unity project**</span></span>

<span data-ttu-id="b4a84-108">このプロジェクトは、3D プロジェクトまたは 2D プロジェクトのいずれかですが、</span><span class="sxs-lookup"><span data-stu-id="b4a84-108">It can be a 3D or 2D project.</span></span> <span data-ttu-id="b4a84-109">どちらの種類のプロジェクトも Xbox Live SDK で動作します。</span><span class="sxs-lookup"><span data-stu-id="b4a84-109">Either type will work with the Xbox Live SDK.</span></span>

<span data-ttu-id="b4a84-110">**3) で確認できます、Xbox Live WinRT Unity asset パッケージの最新バージョンをインポートします。 https://github.com/Microsoft/xbox-live-api/releases**</span><span class="sxs-lookup"><span data-stu-id="b4a84-110">**3) Import the latest version of the Xbox Live WinRT Unity asset package This can be found at https://github.com/Microsoft/xbox-live-api/releases**</span></span>

<span data-ttu-id="b4a84-111">**4) を追加し、新しい C をアタッチ\#Unity オブジェクトへのスクリプト。**</span><span class="sxs-lookup"><span data-stu-id="b4a84-111">**4) Add and attach a new C\# script to a Unity object.**</span></span>

<span data-ttu-id="b4a84-112">たとえば、「メイン カメラ」などの Unity オブジェクトをクリックして、"コンポーネントの追加 をクリックします。 \| "新しいスクリプト" \| C\#スクリプト\|"XboxLiveScript"名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-112">For example, click on a Unity object such as the "Main Camera", and click "Add Component" \| "New Script" \| C\# Script \| and name it "XboxLiveScript".</span></span> <span data-ttu-id="b4a84-113">ゲーム オブジェクトの種類は問いません。</span><span class="sxs-lookup"><span data-stu-id="b4a84-113">Any game object will do.</span></span>

<span data-ttu-id="b4a84-114">**5) で Unity プロジェクトをビルドします。**</span><span class="sxs-lookup"><span data-stu-id="b4a84-114">**5) Build the project in Unity.**</span></span>

1.  <span data-ttu-id="b4a84-115">ファイルに移動して\|ビルド設定では、Windows ストア をクリックし、「スイッチ プラットフォーム」をクリックするかどうかを確認</span><span class="sxs-lookup"><span data-stu-id="b4a84-115">Go to File \| Build Settings, click Windows Store and make sure you click “Switch Platform”</span></span>

2.  <span data-ttu-id="b4a84-116">[Add Open Scenes] をクリックして、現在のシーンをビルドに追加します。</span><span class="sxs-lookup"><span data-stu-id="b4a84-116">Click "Add Open Scenes" to add the current scene to the build</span></span>

3.  <span data-ttu-id="b4a84-117">[SDK] コンボ ボックスで、[Universal 10] を選択します。</span><span class="sxs-lookup"><span data-stu-id="b4a84-117">In the SDK combo box, choose "Universal 10"</span></span>

4.  <span data-ttu-id="b4a84-118">UWP ビルド タイプのコンボ ボックスで [D3D] を選択しますが、必要に応じて [XAML] も選択できます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-118">In the UWP build type combo box, choose "D3D", but "XAML" will also work if you prefer.</span></span>

5.  <span data-ttu-id="b4a84-119">をクリックして、"Unity C\#プロジェクト"アセンブリ Csharp.dll プロジェクトを生成する チェック ボックス</span><span class="sxs-lookup"><span data-stu-id="b4a84-119">Click the "Unity C\# Projects" checkbox to generate the Assembly-Csharp.dll projects</span></span>

6.  <span data-ttu-id="b4a84-120">Unity の [Build] をクリックして、UWP アプリケーション内に Unity ゲームをラップする UWP Visual Studio プロジェクトを生成します。</span><span class="sxs-lookup"><span data-stu-id="b4a84-120">Click "Build" for Unity to generate the UWP Visual Studio project that wraps your Unity game in a UWP application.</span></span> <span data-ttu-id="b4a84-121">新しいファイルが多数作成されるため、場所を指定するときは、混乱を避けるために新しいフォルダーを作成します。</span><span class="sxs-lookup"><span data-stu-id="b4a84-121">When you get prompted for a location, create a new folder to avoid confusion since a lot of new files will be created.</span></span> <span data-ttu-id="b4a84-122">フォルダーの名前を "Build" にすることをお勧めします。フォルダーに名前を付けたら、そのフォルダーを選択します。</span><span class="sxs-lookup"><span data-stu-id="b4a84-122">It’s recommended you call the folder "Build", and then select that folder</span></span>

![](../images/unity/unity3-buildsettings.png)


<span data-ttu-id="b4a84-123">**6) Visual Studio で生成された UWP プロジェクトを開く**</span><span class="sxs-lookup"><span data-stu-id="b4a84-123">**6) Open the generated UWP project in Visual Studio**</span></span>

<span data-ttu-id="b4a84-124">Unity では、エクスプローラーで出力プロジェクト フォルダーが開きます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-124">Unity will open the output project folder in Explorer.</span></span>  <span data-ttu-id="b4a84-125">フォルダー内の .sln ファイルは無視してください。</span><span class="sxs-lookup"><span data-stu-id="b4a84-125">Ignore the .sln file there.</span></span>  <span data-ttu-id="b4a84-126">代わりに、Build フォルダーに移動し、生成された .sln を Visual Studio で開きます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-126">Instead navigate into your Build folder and open the generated .sln in Visual Studio.</span></span>  

<span data-ttu-id="b4a84-127">このソリューションには 3 つのプロジェクトがあります。</span><span class="sxs-lookup"><span data-stu-id="b4a84-127">You'll see 3 projects in this solution.</span></span>

1.  <span data-ttu-id="b4a84-128">Assembly-CSharp。</span><span class="sxs-lookup"><span data-stu-id="b4a84-128">Assembly-CSharp.</span></span> <span data-ttu-id="b4a84-129">Xbox Live スクリプトが配置される場所です。</span><span class="sxs-lookup"><span data-stu-id="b4a84-129">This is where your Xbox Live scripts will live</span></span>

2.  <span data-ttu-id="b4a84-130">Assembly-Csharp-firstpass。</span><span class="sxs-lookup"><span data-stu-id="b4a84-130">Assembly-Csharp-firstpass.</span></span> <span data-ttu-id="b4a84-131">今回、このプロジェクトは無視してかまいません。</span><span class="sxs-lookup"><span data-stu-id="b4a84-131">This project can be ignored for our purposes.</span></span>

3.  <span data-ttu-id="b4a84-132">プロジェクトの名前に基づいた UWP アプリ。</span><span class="sxs-lookup"><span data-stu-id="b4a84-132">UWP app based on the name of your project.</span></span> <span data-ttu-id="b4a84-133">これは、Unity エンジンをホストする従来の UWP アプリです。</span><span class="sxs-lookup"><span data-stu-id="b4a84-133">This is a traditional UWP app that hosts the Unity engine.</span></span> <span data-ttu-id="b4a84-134">ここでは、従来の UWP アプリに似たいくつかの Xbox Live 構成をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="b4a84-134">This is where you'll be setting up some Xbox Live configuration similar to a traditional UWP app.</span></span>


<span data-ttu-id="b4a84-135">**7) 構成の Xbox Live を UWP アプリに追加します。**</span><span class="sxs-lookup"><span data-stu-id="b4a84-135">**7) Add Xbox Live configuration to the UWP app**</span></span>

<span data-ttu-id="b4a84-136">「[新規または既存の UWP プロジェクトに Xbox Live を追加する](get-started-with-visual-studio-and-uwp.md)」というドキュメント ページの手順に従います。</span><span class="sxs-lookup"><span data-stu-id="b4a84-136">Follow the doc page called [Adding Xbox Live to a new or existing UWP project](get-started-with-visual-studio-and-uwp.md)</span></span>

<span data-ttu-id="b4a84-137">**8)、スクリプトに Xbox Live のコードを追加します。**</span><span class="sxs-lookup"><span data-stu-id="b4a84-137">**8) Add Xbox Live code to your script**</span></span>

<span data-ttu-id="b4a84-138">以下のサンプルの Xbox Live コードをコピーし、ゲーム オブジェクトにアタッチしたスクリプトに貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-138">Copy/paste this example Xbox Live code into script you attached to the game object.</span></span> <span data-ttu-id="b4a84-139">このスクリプトは "Assembly-CSharp" プロジェクトに表示されます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-139">This script will appear in the "Assembly-CSharp" project.</span></span> <span data-ttu-id="b4a84-140">コードは自由に変更できます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-140">You can change the code as desired.</span></span>

```csharp
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

<span data-ttu-id="b4a84-141">**9) をコンパイルし、Visual Studio から UWP アプリの実行**</span><span class="sxs-lookup"><span data-stu-id="b4a84-141">**9) Compile and run the UWP app from Visual Studio**</span></span>

<span data-ttu-id="b4a84-142">これにより、通常の UWP アプリのようにアプリが起動し、動作のために UWP アプリ コンテナーが必要なときに Xbox Live 呼び出しが可能になります。</span><span class="sxs-lookup"><span data-stu-id="b4a84-142">This will launch the app like a normal UWP app and allow Xbox Live calls to operate as they require a UWP app container to function.</span></span>

<span data-ttu-id="b4a84-143">**Unity 内のあらゆるものに変更を加える場合は 10) リビルド**  </span><span class="sxs-lookup"><span data-stu-id="b4a84-143">**10) Rebuild if you make changes to anything in Unity**  </span></span>
<span data-ttu-id="b4a84-144">Unity で変更を加えた場合、UWP プロジェクトをリビルドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b4a84-144">If you change anything in Unity, then you must rebuild the UWP project.</span></span>

<span data-ttu-id="b4a84-145">再コンパイル時に Unity が pfx ファイルを置き換えることによって Xbox Live へのサインインが失敗することに注意してください。この問題を避けるために Unity プロジェクト内でファイルを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b4a84-145">Note that Unity will replace your pfx file when you recompile which will cause Xbox Live sign-in to fail, so you must update it inside the Unity project to avoid this issue.</span></span>

<span data-ttu-id="b4a84-146">ファイルに移動するのには、\|ビルド設定 が Windows ストアのプレーヤーで ビルド設定 をクリックし、上から取得したもので、PFX ファイルを置換する PFX ボタンをクリックします。</span><span class="sxs-lookup"><span data-stu-id="b4a84-146">To do this, go to File \| Build Settings, click on "Build Settings" on the Windows Store player and click the PFX button to replace the PFX file with the one you got from above.</span></span> <span data-ttu-id="b4a84-147">別の方法として、Unity 内でプロジェクトをリビルドするたびに PFX ファイルを削除することもできます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-147">You can alternatively delete the PFX file each time you rebuild the project from within Unity.</span></span>

## <a name="troubleshooting-common-issues"></a><span data-ttu-id="b4a84-148">一般的な問題のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="b4a84-148">Troubleshooting common issues</span></span>

<span data-ttu-id="b4a84-149">**1)** Unity において、関連付けられたスクリプトを読み込めない場合、手順 3 を実行して WinMD を Unity のプロジェクト アセット パネルにドラッグしたことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="b4a84-149">**1)** If Unity has that an associated script can not be loaded, then ensure that you did step 3 to drag the WinMD to the Unity project assets panel</span></span>

<span data-ttu-id="b4a84-150">**2)** 起動後すぐ、または次のコード行を実行しようとしたときにアプリがクラッシュする場合:</span><span class="sxs-lookup"><span data-stu-id="b4a84-150">**2)** If the app crashes immedately at startup or when trying to run this line of code:</span></span>

    Microsoft.Xbox.Services.System.XboxLiveUser m_user = new Microsoft.Xbox.Services.System.XboxLiveUser();

<span data-ttu-id="b4a84-151">xboxservices.config テキスト ファイルをプロジェクトに追加して、そのプロパティで "Build Action" を "Content" に、"Copy to Output Directory" を "Copy Always" に設定したことを確認します。</span><span class="sxs-lookup"><span data-stu-id="b4a84-151">Ensure you have added a xboxservices.config text file to the project and in its properties, set the "Build Action" to "Content", and "Copy to Output Directory" set to "Copy Always".</span></span>

> [!NOTE]
> <span data-ttu-id="b4a84-152">xboxservices.config 内のすべての値で大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-152">All values inside xboxservices.config are case sensitive.</span></span>

<span data-ttu-id="b4a84-153">また、次のような正しい JSON フォーマット (10 進形式の TitleId) がテキスト ファイルに含まれていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b4a84-153">Also ensure it contains proper JSON formatting with the TitleId in decimal form, such as:</span></span>

```json
{
    "TitleId" : 928643728,
    "PrimaryServiceConfigId" : "3ebd0100-ace5-4aa4-ab9c-5b733759fa90"
}
```

<span data-ttu-id="b4a84-154">**3)** アプリが起動するがサインインに失敗する場合は、以下を確認してください。</span><span class="sxs-lookup"><span data-stu-id="b4a84-154">**3)** If the app launches, but fails to signin then check the following:</span></span>

<span data-ttu-id="b4a84-155">a) コンピューターがデベロッパー サンドボックスに設定されていること。</span><span class="sxs-lookup"><span data-stu-id="b4a84-155">a) Your machine is set to the your developer sandbox.</span></span>  <span data-ttu-id="b4a84-156">これを行うには、Xbox Live SDK の \Tools フォルダーにある SwitchSandbox.cmd スクリプトを使用します。</span><span class="sxs-lookup"><span data-stu-id="b4a84-156">Use the SwitchSandbox.cmd script in the \Tools folder of the Xbox Live SDK to do this.</span></span>

<span data-ttu-id="b4a84-157">b) デベロッパー サンドボックスにアクセスできる Xbox Live アカウントでサインインしていること。</span><span class="sxs-lookup"><span data-stu-id="b4a84-157">b) You are signing in with an Xbox Live account that has access to the developer sandbox.</span></span>  <span data-ttu-id="b4a84-158">通常のリテール Xbox Live アカウントにはそのようなアクセス権がありません。</span><span class="sxs-lookup"><span data-stu-id="b4a84-158">Normal retail Xbox Live accounts don't have access.</span></span>  <span data-ttu-id="b4a84-159">XDP またはパートナー センターを使用して、テスト アカウントを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-159">You can use XDP or Partner Center to create test accounts.</span></span>

<span data-ttu-id="b4a84-160">c) UWP アプリの package.appxmanfiest で正しい Identity が設定されていること。</span><span class="sxs-lookup"><span data-stu-id="b4a84-160">c) Your package.appxmanfiest in your UWP app is set to the correct Identity.</span></span>  <span data-ttu-id="b4a84-161">これを手動で編集できますが、これを解決する最も簡単な方法は、Visual Studio でプロジェクトを右クリックし、"Store"を選択する\|「、ストアでアプリを関連付ける」。</span><span class="sxs-lookup"><span data-stu-id="b4a84-161">You can edit this manually, but the easiest way to fix this is to right click on the Project in Visual Studio and choose "Store" \| "Associate App with the Store".</span></span>

<span data-ttu-id="b4a84-162">d) Unity によって提供されるストックの .pfx ファイルは、適切な id を必要はありませんので、いずれか、ディスクから削除し、それを参照する .csproj に行を削除または、右が Visual Studio でプロジェクトをクリックし、"Store"を選択\|"に関連付けるアプリ ストアと"これを適切な .pfx ファイルを配置します。</span><span class="sxs-lookup"><span data-stu-id="b4a84-162">d) The stock .pfx file provided by Unity won't have the correct identity so either delete it from the disk and remove the line in the .csproj that references it, or right click on the Project in Visual Studio and choose "Store" \| "Associate App with the Store" which will place down a proper .pfx file.</span></span>  <span data-ttu-id="b4a84-163">その後、Unity に戻って Windows Store プレイヤー上で [Build Settings] をクリックし、[PFX] ボタンをクリックして、.pfx ファイルを Visual Studio での [アプリケーションをストアと関連付ける] 操作により取得したファイルに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="b4a84-163">Be sure then to go back to Unity, click on "Build Settings" on the Windows Store player and click the PFX button to replace the .pfx file with the one you got from Visual Studio's "Associate App with the Store" action.</span></span>
