---
title: Unity で Xbox Live を構成する
description: Xbox Live Unity プラグインを使用して、Unity ゲームで Xbox Live を構成する方法について説明します。
ms.assetid: 55147c41-cc49-47f3-829b-fa7e1a46b2dd
ms.date: 01/25/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, 構成
localizationpriority: medium
ms.openlocfilehash: d464fc54d322db9da91870bd3ca7cbc29957b379
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57596727"
---
# <a name="configure-xbox-live-in-unity"></a><span data-ttu-id="614e5-104">Unity で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="614e5-104">Configure Xbox Live in Unity</span></span>

> [!NOTE]
> <span data-ttu-id="614e5-105">Xbox Live の Unity プラグインにのみ推奨[Xbox Live クリエーターズ プログラム](../developer-program-overview.md)から現在のメンバーのアチーブメントまたはマルチ プレーヤー サポートはありません。</span><span class="sxs-lookup"><span data-stu-id="614e5-105">The Xbox Live Unity plugin is only recommended for [Xbox Live Creators Program](../developer-program-overview.md) members, since currently there is no support for achievements or multiplayer.</span></span>

<span data-ttu-id="614e5-106">[Xbox Live の Unity プラグイン](https://github.com/Microsoft/xbox-live-unity-plugin)、Unity ゲームに Xbox Live のサポートの追加は簡単な多くの時間が最もがタイトルを合わせての方法で Xbox Live の使用に重点を提供します。</span><span class="sxs-lookup"><span data-stu-id="614e5-106">With the [Xbox Live Unity Plugin](https://github.com/Microsoft/xbox-live-unity-plugin), adding Xbox Live support to a Unity game is easy, giving you more time to focus on using Xbox Live in ways that best suit your title.</span></span>

<span data-ttu-id="614e5-107">このトピックでは、Unity で Xbox Live プラグインをセットアップする手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="614e5-107">This topic will go through the process of setting up the Xbox Live plugin in Unity.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="614e5-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="614e5-108">Prerequisites</span></span>

<span data-ttu-id="614e5-109">Xbox Live を使用 Unity で前に、次を必要となります。</span><span class="sxs-lookup"><span data-stu-id="614e5-109">You will need the following before you can use Xbox Live in Unity:</span></span>

1. <span data-ttu-id="614e5-110"> **[Xbox Live アカウント](https://support.xbox.com/browse/my-account/manage-account/Create%20account)** します。</span><span class="sxs-lookup"><span data-stu-id="614e5-110">An **[Xbox Live account](https://support.xbox.com/browse/my-account/manage-account/Create%20account)**.</span></span>
1. <span data-ttu-id="614e5-111">登録、 **[パートナー センター開発者プログラム](https://developer.microsoft.com/store/register)** します。</span><span class="sxs-lookup"><span data-stu-id="614e5-111">Enrollment in the **[Partner Center developer program](https://developer.microsoft.com/store/register)**.</span></span>
2. <span data-ttu-id="614e5-112">**[Windows 10 Anniversary Update](https://microsoft.com/windows)** またはそれ以降</span><span class="sxs-lookup"><span data-stu-id="614e5-112">**[Windows 10 Anniversary Update](https://microsoft.com/windows)** or later</span></span>
3. <span data-ttu-id="614e5-113">**[Unity](https://store.unity.com/)** バージョン**5.5.4p5** (またはそれ以降)、 **2017.1p5** (またはそれ以降)、または**2017.2.0f3** (またはそれ以降) で**[Microsoft Visual Studio Tools for Unity](https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity)** と**Windows ストアの .NET バックエンドをスクリプト**します。</span><span class="sxs-lookup"><span data-stu-id="614e5-113">**[Unity](https://store.unity.com/)** versions **5.5.4p5** (or newer), **2017.1p5** (or newer), or **2017.2.0f3** (or newer) with **[Microsoft Visual Studio Tools for Unity](https://marketplace.visualstudio.com/items?itemName=SebastienLebreton.VisualStudio2015ToolsforUnity)** and **Windows Store .NET Scripting Backend**.</span></span>
4. <span data-ttu-id="614e5-114">**[Visual Studio 2015](https://www.visualstudio.com/)** または**[Visual Studio 2017 15.3.3](https://www.visualstudio.com/)** (またはそれ以降) で、**ユニバーサル Windows アプリ開発ツール**します。</span><span class="sxs-lookup"><span data-stu-id="614e5-114">**[Visual Studio 2015](https://www.visualstudio.com/)** or **[Visual Studio 2017 15.3.3](https://www.visualstudio.com/)** (or newer) with the **Universal Windows App Development Tools**.</span></span>
5. <span data-ttu-id="614e5-115">**[Xbox Live プラットフォーム拡張機能 SDK](https://aka.ms/xblextsdk)** します。</span><span class="sxs-lookup"><span data-stu-id="614e5-115">**[Xbox Live Platform Extensions SDK](https://aka.ms/xblextsdk)**.</span></span>


> [!NOTE]
> <span data-ttu-id="614e5-116">Unity 2017.2.0p2 が必要で、Xbox Live il2cpp バック エンドのスクリプトのバックエンドを使用する場合は、またはそれ以降、Xbox Live の Unity プラグイン バージョン"1802 Preview Release"またはそれ以降。</span><span class="sxs-lookup"><span data-stu-id="614e5-116">If you want to use the IL2CPP scripting backend with Xbox Live, you will need Unity 2017.2.0p2 or newer and the Xbox Live Unity plugin version "1802 Preview Release" or higher.</span></span>


## <a name="import-the-unity-plugin"></a><span data-ttu-id="614e5-117">Unity プラグインをインポートする</span><span class="sxs-lookup"><span data-stu-id="614e5-117">Import the Unity plugin</span></span>

<span data-ttu-id="614e5-118">新規または既存の Unity プロジェクトにプラグインをインポートするには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="614e5-118">To import the plugin into your new or existing Unity project, follow these steps:</span></span>

1. <span data-ttu-id="614e5-119">Xbox Live の Unity プラグイン [リリース] タブに移動します[ https://github.com/Microsoft/xbox-live-unity-plugin/releases](https://github.com/Microsoft/xbox-live-unity-plugin/releases)します。</span><span class="sxs-lookup"><span data-stu-id="614e5-119">Navigate to the Xbox Live Unity Plugin release tab on [https://github.com/Microsoft/xbox-live-unity-plugin/releases](https://github.com/Microsoft/xbox-live-unity-plugin/releases).</span></span>
2. <span data-ttu-id="614e5-120">ダウンロード**XboxLive.unitypackage**します。</span><span class="sxs-lookup"><span data-stu-id="614e5-120">Download **XboxLive.unitypackage**.</span></span>
3. <span data-ttu-id="614e5-121">Unity では、次のようにクリックします**資産** > **パッケージのインポート** > **カスタム パッケージ**に移動します**XboxLive.unitypackage。**.</span><span class="sxs-lookup"><span data-stu-id="614e5-121">In Unity, click **Assets** > **Import Package** > **Custom Package** and navigate to **XboxLive.unitypackage**.</span></span>

![インポートに成功](../images/unity/get-started-with-creators/importXBL_Small.gif)

### <a name="optional-configure-the-plugin-to-work-in-the-unity-editor-net-46-or-il2cpp-only"></a><span data-ttu-id="614e5-123">(省略可能)プラグインを構成する作業で、Unity エディター (.NET 4.6 または il2cpp バック エンドのみ)</span><span class="sxs-lookup"><span data-stu-id="614e5-123">(Optional) Configure the plugin to work in the Unity Editor (.NET 4.6 or IL2CPP only)</span></span>

> [!NOTE]
> <span data-ttu-id="614e5-124">Unity のスクリプトのランタイム バージョンを変更するには、Xbox Live の Unity プラグイン バージョン「1711 リリース」が必要です。 サポート以上の .NET 4.6 およびバージョン"1802 プレビュー リリース"以上 il2cpp バック エンドの。</span><span class="sxs-lookup"><span data-stu-id="614e5-124">Support for changing the Scripting Runtime Version in Unity requires the Xbox Live Unity Plugin version "1711 Release" or higher for .NET 4.6 and version "1802 Preview Release" or higher for IL2CPP.</span></span>

<span data-ttu-id="614e5-125">コードのコンパイル方法を定義する Unity のように構成できる 3 つの設定があります。</span><span class="sxs-lookup"><span data-stu-id="614e5-125">There are three settings that can be configured in Unity to define how your code is compiled:</span></span>

1. <span data-ttu-id="614e5-126">**バックエンド スクリプト**が使用されるコンパイラ。</span><span class="sxs-lookup"><span data-stu-id="614e5-126">The **scripting backend** is the compiler that is used.</span></span> <span data-ttu-id="614e5-127">Unity は、ユニバーサル Windows プラットフォーム用の 2 つの異なるスクリプト バックエンドをサポートしています: .NET と il2cpp バック エンドです。</span><span class="sxs-lookup"><span data-stu-id="614e5-127">Unity supports two different scripting backends for Universal Windows Platform: .NET and IL2CPP.</span></span>
2. <span data-ttu-id="614e5-128">**Scripting Runtime Version** Unity エディターを実行するスクリプトのランタイムのバージョンです。</span><span class="sxs-lookup"><span data-stu-id="614e5-128">The **Scripting Runtime Version** is the version of the scripting runtime that runs the Unity Editor.</span></span>
3. <span data-ttu-id="614e5-129">**API 互換性レベル**に対してゲームをビルドする API サーフェイスです。</span><span class="sxs-lookup"><span data-stu-id="614e5-129">The **API Compatibility Level** is the API surface you'll build your game against.</span></span>

<span data-ttu-id="614e5-130">次の表では、Xbox Live の Unity プラグインの現在のスクリプトのサポート マトリックスを示しています。</span><span class="sxs-lookup"><span data-stu-id="614e5-130">The following table shows the current scripting support matrix for the Xbox Live Unity Plugin:</span></span>

| <span data-ttu-id="614e5-131">スクリプトのバックエンド</span><span class="sxs-lookup"><span data-stu-id="614e5-131">Scripting Backend</span></span>     | <span data-ttu-id="614e5-132">スクリプトのランタイム バージョン</span><span class="sxs-lookup"><span data-stu-id="614e5-132">Scripting Runtime Version</span></span> | <span data-ttu-id="614e5-133">サポート対象</span><span class="sxs-lookup"><span data-stu-id="614e5-133">Supported</span></span>     | <span data-ttu-id="614e5-134">必要な最小の Unity バージョン</span><span class="sxs-lookup"><span data-stu-id="614e5-134">Minimum Unity Version Required</span></span> |
|-------------------    |-------------------        |-----------    |------------------------------- |
| <span data-ttu-id="614e5-135">IL2CPP バック エンド</span><span class="sxs-lookup"><span data-stu-id="614e5-135">IL2CPP</span></span>                | <span data-ttu-id="614e5-136">.NET 3.5 と同じです</span><span class="sxs-lookup"><span data-stu-id="614e5-136">.NET 3.5 Equivalent</span></span>       | <span data-ttu-id="614e5-137">X</span><span class="sxs-lookup"><span data-stu-id="614e5-137">No</span></span>            | <span data-ttu-id="614e5-138">なし</span><span class="sxs-lookup"><span data-stu-id="614e5-138">N/A</span></span>                            |
| <span data-ttu-id="614e5-139">Il2cpp バック エンド</span><span class="sxs-lookup"><span data-stu-id="614e5-139">Il2CPP</span></span>                | <span data-ttu-id="614e5-140">.NET 4.6 対応</span><span class="sxs-lookup"><span data-stu-id="614e5-140">.NET 4.6 Equivalent</span></span>       | <span data-ttu-id="614e5-141">〇</span><span class="sxs-lookup"><span data-stu-id="614e5-141">Yes</span></span>           | <span data-ttu-id="614e5-142">2017.2.0p2</span><span class="sxs-lookup"><span data-stu-id="614e5-142">2017.2.0p2</span></span>                     |
| <span data-ttu-id="614e5-143">.NET</span><span class="sxs-lookup"><span data-stu-id="614e5-143">.NET</span></span>                  | <span data-ttu-id="614e5-144">.NET 3.5 と同じです</span><span class="sxs-lookup"><span data-stu-id="614e5-144">.NET 3.5 Equivalent</span></span>       | <span data-ttu-id="614e5-145">〇</span><span class="sxs-lookup"><span data-stu-id="614e5-145">Yes</span></span>           | <span data-ttu-id="614e5-146">前提条件と同じ</span><span class="sxs-lookup"><span data-stu-id="614e5-146">Same as prerequisites</span></span>          |
| <span data-ttu-id="614e5-147">.NET</span><span class="sxs-lookup"><span data-stu-id="614e5-147">.NET</span></span>                  | <span data-ttu-id="614e5-148">.NET 4.6 対応</span><span class="sxs-lookup"><span data-stu-id="614e5-148">.NET 4.6 Equivalent</span></span>       | <span data-ttu-id="614e5-149">〇</span><span class="sxs-lookup"><span data-stu-id="614e5-149">Yes</span></span>           | <span data-ttu-id="614e5-150">前提条件と同じ</span><span class="sxs-lookup"><span data-stu-id="614e5-150">Same as prerequisites</span></span>          |

<span data-ttu-id="614e5-151">スクリプトのランタイム サポートを追加、Xbox Live Unity プラグインを「1711 リリース」バージョン以降に追加されました。</span><span class="sxs-lookup"><span data-stu-id="614e5-151">We've added additional scripting runtime support to the Xbox Live Unity Plugin, starting with version "1711 Release".</span></span> <span data-ttu-id="614e5-152">既定では、プラグインが Unity エディターで、.net バックエンド スクリプトおよび .NET 3.5 のランタイムのバージョンのスクリプトを実行するように構成します。</span><span class="sxs-lookup"><span data-stu-id="614e5-152">By default, the plugin is configured to run in the Unity editor with the .NET scripting backend and scripting runtime version of .NET 3.5.</span></span> <span data-ttu-id="614e5-153">プロジェクトが .NET 4.6 のスクリプトのランタイム バージョンを使用している場合は、エディターで正しく動作するようにプラグインを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="614e5-153">If your project is using the scripting runtime version of .NET 4.6, you will need to configure the plugin to work properly in the editor:</span></span>

1. <span data-ttu-id="614e5-154">Unity プロジェクト エクスプ ローラーに移動します。 **Xbox Live\Libs\UnityEditor\NET46**フォルダー内のすべての Dll を選択します。</span><span class="sxs-lookup"><span data-stu-id="614e5-154">In the Unity project explorer, navigate to **Xbox Live\Libs\UnityEditor\NET46** and select all of the DLLs in the folder.</span></span>
2. <span data-ttu-id="614e5-155">インスペクター ウィンドウで確認**エディター** **含めるプラットフォーム**します。</span><span class="sxs-lookup"><span data-stu-id="614e5-155">In the Inspector window, check **Editor** under **Include Platforms**.</span></span>
3. <span data-ttu-id="614e5-156">Unity プロジェクト エクスプ ローラーに移動します。 **Xbox Live\Libs\UnityEditor\NET35**フォルダー内のすべての Dll を選択します。</span><span class="sxs-lookup"><span data-stu-id="614e5-156">In the Unity project explorer, navigate to **Xbox Live\Libs\UnityEditor\NET35** and select all of the DLLs in the folder.</span></span>
4. <span data-ttu-id="614e5-157">Inspector] ウィンドウで、オフにします。**エディター** [**含めるプラットフォーム**します。</span><span class="sxs-lookup"><span data-stu-id="614e5-157">In the Inspector window, uncheck **Editor** under **Include Platforms**.</span></span>

![スクリプト ランタイムを変更します。](../images/unity/get-started-with-creators/changeScriptingRuntime.gif)

> [!IMPORTANT]
> <span data-ttu-id="614e5-159">次の手順は、3.5 にプロジェクトのスクリプトのランタイム バージョンを変更する場合を元に戻す必要があります。</span><span class="sxs-lookup"><span data-stu-id="614e5-159">These steps will need to be reversed if you change the scripting runtime version in your project back to 3.5.</span></span>

## <a name="set-visual-studio-as-the-ide-in-unity"></a><span data-ttu-id="614e5-160">Visual Studio を Unity に IDE として設定します。</span><span class="sxs-lookup"><span data-stu-id="614e5-160">Set Visual Studio as the IDE in Unity</span></span>

<span data-ttu-id="614e5-161">Visual Studio がビルドに必要な[ユニバーサル Windows プラットフォーム (UWP)](https://docs.microsoft.com/windows/uwp/get-started/whats-a-uwp)ゲームです。</span><span class="sxs-lookup"><span data-stu-id="614e5-161">Visual Studio is required to build a [Universal Windows Platform (UWP)](https://docs.microsoft.com/windows/uwp/get-started/whats-a-uwp) game.</span></span> <span data-ttu-id="614e5-162">移動して Visual Studio を Unity でお使いの IDE を設定できる**編集** > **設定** > **外部ツール**の設定と**External Script Editor** Visual Studio にします。</span><span class="sxs-lookup"><span data-stu-id="614e5-162">You can set your IDE in Unity to Visual Studio by going into **Edit** > **Preferences** > **External Tools** and setting the **External Script Editor** to Visual Studio.</span></span>

![VS の外部ツールを設定します。](../images/unity/get-started-with-creators/setVSExternalTool_Small.gif)

## <a name="unity-plugin-file-structure"></a><span data-ttu-id="614e5-164">Unity プラグインのファイル構造</span><span class="sxs-lookup"><span data-stu-id="614e5-164">Unity plugin file structure</span></span>

<span data-ttu-id="614e5-165">Unity プラグインのファイル構造は、次の部分に分かれています。</span><span class="sxs-lookup"><span data-stu-id="614e5-165">The Unity plugin's file structure is broken into the following parts:</span></span>

* <span data-ttu-id="614e5-166">__Xbox Live__ には、公開された **.unitypackage** に含まれている実際のプラグイン アセットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="614e5-166">__Xbox Live__ contains the actual plugin assets that are included in the published **.unitypackage**.</span></span>
    * <span data-ttu-id="614e5-167">__Editor__ には、基本的な Unity 構成 UI を表示し、ビルド時にプロジェクトを処理するスクリプトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="614e5-167">__Editor__ contains scripts that provide the basic Unity configuration UI and processes the projects during build.</span></span>
    * <span data-ttu-id="614e5-168">__Examples__ には、さまざまなプレハブを使って相互に接続する方法を示す一連のシンプルなシーン ファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="614e5-168">__Examples__ contains a set of simple scene files that show how to use the various prefabs and connect them together.</span></span>
    * <span data-ttu-id="614e5-169">__Images__ は、プレハブにより使用される小さいイメージ セットです。</span><span class="sxs-lookup"><span data-stu-id="614e5-169">__Images__ is a small set of images that are used by the prefabs.</span></span>
    * <span data-ttu-id="614e5-170">__Libs__ Xbox Live ライブラリが格納されます。</span><span class="sxs-lookup"><span data-stu-id="614e5-170">__Libs__ is where the Xbox Live libraries are stored.</span></span>
    * <span data-ttu-id="614e5-171">__Prefabs__ には、Xbox Live 機能を実装するさまざまな [Unity プレハブ](https://docs.unity3d.com/Manual/Prefabs.html) オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="614e5-171">__Prefabs__ contains various [Unity prefab](https://docs.unity3d.com/Manual/Prefabs.html) objects that implement Xbox Live functionality.</span></span>
    * <span data-ttu-id="614e5-172">__スクリプト__のプレハブから Xbox Live Api を呼び出すすべてのコード ファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="614e5-172">__Scripts__ contains all the code files that call the Xbox Live APIs from the prefabs.</span></span> <span data-ttu-id="614e5-173">これは、Xbox Live API を正しく呼び出す方法に関する例を探すのに最適な場所です。</span><span class="sxs-lookup"><span data-stu-id="614e5-173">This is a great place to look for examples about how to properly call the Xbox Live APIs.</span></span>
    * <span data-ttu-id="614e5-174">__Tools\AssociationWizard__ 、Xbox Live の関連付けウィザード、アプリケーションからの構成をプルするために使用を含む[パートナー センター](https://developer.microsoft.com/windows) Unity 内で使用します。</span><span class="sxs-lookup"><span data-stu-id="614e5-174">__Tools\AssociationWizard__ contains the Xbox Live Association Wizard, used to pull down application configuration from [Partner Center](https://developer.microsoft.com/windows) for use within Unity.</span></span>

## <a name="enable-xbox-live"></a><span data-ttu-id="614e5-175">Xbox Live を有効にする</span><span class="sxs-lookup"><span data-stu-id="614e5-175">Enable Xbox Live</span></span>

<span data-ttu-id="614e5-176">Xbox Live との対話にタイトル、Xbox Live の初期構成を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="614e5-176">For your title to interact with Xbox Live, you'll need to setup the initial Xbox Live configuration.</span></span> <span data-ttu-id="614e5-177">こうことに簡単にして、Unity 内で Xbox Live の関連付けウィザードを使用しています。</span><span class="sxs-lookup"><span data-stu-id="614e5-177">You can do this easily and inside of Unity by using the Xbox Live Association Wizard:</span></span>

1. <span data-ttu-id="614e5-178">**[Xbox Live]** メニューで **[Configuration]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="614e5-178">In the **Xbox Live** menu, select **Configuration**.</span></span>
2. <span data-ttu-id="614e5-179">**[Xbox Live]** ウィンドウで、**[Run Xbox Live Association Wizard]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="614e5-179">In the **Xbox Live** window, select **Run Xbox Live Association Wizard**.</span></span>
3. <span data-ttu-id="614e5-180">**タイトルを Windows ストアに関連付ける**ダイアログ ボックスで、 をクリックして**次へ**、パートナー センター アカウントでサインインします。</span><span class="sxs-lookup"><span data-stu-id="614e5-180">In the **Associate Your title with the Windows Store** dialog, click **Next**, and then sign in with your Partner Center account.</span></span>
4. <span data-ttu-id="614e5-181">このプロジェクトに関連付けるアプリを選択し、**[Select]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="614e5-181">Select the app that you want to associate with this project, and then click **Select**.</span></span> <span data-ttu-id="614e5-182">アプリが表示されない場合は、**[Refresh]** をクリックしてみてください。</span><span class="sxs-lookup"><span data-stu-id="614e5-182">If you don't see it there, try clicking **Refresh**.</span></span> <span data-ttu-id="614e5-183">または、名前を予約して **[Reserve]** をクリックすることで、新しいアプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="614e5-183">Alternatively, you can create a new app by reserving a name and clicking **Reserve**.</span></span>
5. <span data-ttu-id="614e5-184">まだある場合、Xbox Live を有効にするように促されます。</span><span class="sxs-lookup"><span data-stu-id="614e5-184">You will be prompted to enable Xbox Live if you have not already.</span></span> <span data-ttu-id="614e5-185">クリックして**を有効にする**タイトルで Xbox Live を有効にします。</span><span class="sxs-lookup"><span data-stu-id="614e5-185">Click **Enable** to enable Xbox Live in your title.</span></span>
6. <span data-ttu-id="614e5-186">**[Finish]** をクリックして構成を保存します。</span><span class="sxs-lookup"><span data-stu-id="614e5-186">Click **Finish** to save your configuration.</span></span>

<span data-ttu-id="614e5-187">Xbox Live サービスを呼び出すには、デスクトップが開発者モードになってし、タイトルは、Xbox Live の構成と同じサンド ボックスに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="614e5-187">To call Xbox Live services, your desktop must be in developer mode and set to the same sandbox as your title is in the Xbox Live configuration.</span></span> <span data-ttu-id="614e5-188">調べることで両方を確認することができます、 **Xbox Live 構成**Unity でのウィンドウ。</span><span class="sxs-lookup"><span data-stu-id="614e5-188">You can verify both by looking at the **Xbox Live Configuration** window in Unity:</span></span>

1. <span data-ttu-id="614e5-189">**開発者モード構成**と答えるべき**有効**します。</span><span class="sxs-lookup"><span data-stu-id="614e5-189">**Developer Mode Configuration** should say **Enabled**.</span></span> <span data-ttu-id="614e5-190">**[Disabled]** になっている場合、**[Switch to Developer Mode]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="614e5-190">If it says **Disabled**, click **Switch to Developer Mode**.</span></span>
2. <span data-ttu-id="614e5-191">**構成タイトル** > **サンド ボックス**として ID が同じである必要があります**開発者モード構成** > **開発者モード**します。</span><span class="sxs-lookup"><span data-stu-id="614e5-191">**Title Configuration** > **Sandbox** should have the same ID as **Developer Mode Configuration** > **Developer Mode**.</span></span>

![XBL 有効](../images/unity/unity-xbl-enabled.png)

<span data-ttu-id="614e5-193">参照してください[サンド ボックスの Xbox Live](../xbox-live-sandboxes.md)サンド ボックスについてはします。</span><span class="sxs-lookup"><span data-stu-id="614e5-193">See [Xbox Live sandboxes](../xbox-live-sandboxes.md) for information about sandboxes.</span></span>

## <a name="build-and-test-the-project"></a><span data-ttu-id="614e5-194">プロジェクトのビルドおよびテスト</span><span class="sxs-lookup"><span data-stu-id="614e5-194">Build and test the project</span></span>

<span data-ttu-id="614e5-195">エディターでタイトルを実行しているとき、Xbox Live の機能を使おうとすると仮のデータが表示されます。</span><span class="sxs-lookup"><span data-stu-id="614e5-195">When running your title in the editor, you will see fake data when you try to use Xbox Live functionality.</span></span> <span data-ttu-id="614e5-196">たとえば場合、する[サインオン機能を追加](unity-prefabs-and-sign-in.md)、シーンとサインインしようとする表示されます**偽のユーザー**プレース ホルダーのアイコン、プロファイル名として表示されます。</span><span class="sxs-lookup"><span data-stu-id="614e5-196">For example, if you [add sign in capabilities](unity-prefabs-and-sign-in.md) to your scene and try to sign in, you will see **Fake User** appear as your profile name, with a placeholder icon.</span></span> <span data-ttu-id="614e5-197">で実際のプロファイルを使用してサインインして、タイトルで Xbox Live の機能をテストするには、UWP ソリューションを構築し、Visual Studio で実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="614e5-197">To sign in with a real profile and test out Xbox Live functionality in your title, you'll need to build a UWP solution and run it in Visual Studio.</span></span>  <span data-ttu-id="614e5-198">次の手順では、Unity での UWP プロジェクトをビルドできます。</span><span class="sxs-lookup"><span data-stu-id="614e5-198">You can build the UWP project in Unity by following these steps:</span></span>

1. <span data-ttu-id="614e5-199">開く、 **Build Settings**ウィンドウを選択して**ファイル** > **Build Settings**します。</span><span class="sxs-lookup"><span data-stu-id="614e5-199">Open the **Build Settings** window by selecting **File** > **Build Settings**.</span></span>
2. <span data-ttu-id="614e5-200">すべての下で、ビルドに含めるシーンを追加、 **Scenes In Build**セクション。</span><span class="sxs-lookup"><span data-stu-id="614e5-200">Add all of the scenes that you want to include in your build under the **Scenes In Build** section.</span></span>
3. <span data-ttu-id="614e5-201">切り替えて、**ユニバーサル Windows プラットフォーム**を選択して**ユニバーサル Windows プラットフォーム\*\*\*\*[プラットフォーム]** をクリック**スイッチ プラットフォーム**.</span><span class="sxs-lookup"><span data-stu-id="614e5-201">Switch to the **Universal Windows Platform** by selecting **Universal Windows Platform** under **Platform** and clicking **Switch Platform**.</span></span>
4. <span data-ttu-id="614e5-202">設定**SDK**に**10.0.15063.0**以上。</span><span class="sxs-lookup"><span data-stu-id="614e5-202">Set **SDK** to **10.0.15063.0** or greater.</span></span>
5. <span data-ttu-id="614e5-203">スクリプトのデバッグ チェックを有効にする**UnityC#プロジェクト**します。</span><span class="sxs-lookup"><span data-stu-id="614e5-203">To enable script debugging check **Unity C# Projects**.</span></span>
6. <span data-ttu-id="614e5-204">クリックして**ビルド**し、プロジェクトの場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="614e5-204">Click **Build** and specify the location of the project.</span></span>

![ビルド設定](../images/unity/build_settings.JPG)

<span data-ttu-id="614e5-206">ビルドが完了すると、Unity には、Visual Studio での実行に必要になる新しい UWP ソリューション ファイルが生成が。</span><span class="sxs-lookup"><span data-stu-id="614e5-206">Once the build has finished, Unity will have generated a new UWP solution file which you will need to run in Visual Studio:</span></span>

1. <span data-ttu-id="614e5-207">指定したフォルダーを開きます **&lt;ProjectName&gt;.sln** Visual Studio でします。</span><span class="sxs-lookup"><span data-stu-id="614e5-207">In the folder that you specified, open **&lt;ProjectName&gt;.sln** in Visual Studio.</span></span>
2. <span data-ttu-id="614e5-208">上部にあるツールバーで選択**x64**を展開し、**ローカル マシン**します。</span><span class="sxs-lookup"><span data-stu-id="614e5-208">In the toolbar at the top, select **x64** and deploy to the **Local Machine**.</span></span>

<span data-ttu-id="614e5-209">有効にした場合**スクリプトのデバッグ**Unity から UWP ソリューションを構築したときに、スクリプトに置かれます、**アセンブリ CSharp (ユニバーサル Windows)** プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="614e5-209">If you enabled **script debugging** when you built the UWP solution from Unity, then your scripts will be located under the **Assembly-CSharp (Universal Windows)** project.</span></span>

![ユーザーを偽装します。123456789](../images/unity/get-started-with-creators/visualStudio.PNG)

> [!NOTE]
> <span data-ttu-id="614e5-211">Visual Studio のビルドを使用して、実際のデータを使用して、ゲームをテストする、前に以下の[このチェックリスト](test-visual-studio-build.md)タイトルが Xbox Live サービスにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="614e5-211">Before using your Visual Studio build to test your game with real data, follow [this checklist](test-visual-studio-build.md) to help ensure your title will be able to access the Xbox Live service.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="614e5-212">ようになりました 2018 必要な場合が Visual Studio で、UWP のタイトルを正しくテストするには、ある package.appxmanifest.xml ファイルに更新を作成します。</span><span class="sxs-lookup"><span data-stu-id="614e5-212">As of May 2018 it is now required that you make an update to the package.appxmanifest.xml file in order to test your UWP title properly in Visual Studio.</span></span> <span data-ttu-id="614e5-213">これには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="614e5-213">To do this:</span></span>
>
> 1. <span data-ttu-id="614e5-214">Package.appxmanifest.xml ファイルの ソリューション エクスプ ローラーを検索します。</span><span class="sxs-lookup"><span data-stu-id="614e5-214">Search the Solution Explorer for the package.appxmanifest.xml file</span></span>
> 2. <span data-ttu-id="614e5-215">ファイルを右クリックし、コードの表示を選択します。</span><span class="sxs-lookup"><span data-stu-id="614e5-215">Right click the file and choose View Code.</span></span>  
    <span data-ttu-id="614e5-216">コードの表示オプションは使用できません、package.appxmanifest ファイルで、拡張子が付いていない場合。</span><span class="sxs-lookup"><span data-stu-id="614e5-216">If the View Code option is not available or the package.appxmanifest file does not have an extension.</span></span> <span data-ttu-id="614e5-217">Xml ファイルを開き、残りの手順を続行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="614e5-217">You will need to open the file as an xml and continue with the remaining steps.</span></span>
> 3. <span data-ttu-id="614e5-218">で、`<Properties></Properties>`セクションで、次の行を追加:`<uap:SupportedUsers>multiple</uap:SupportedUsers>`します。</span><span class="sxs-lookup"><span data-stu-id="614e5-218">Under the `<Properties></Properties>` section, add the following line: `<uap:SupportedUsers>multiple</uap:SupportedUsers>`.</span></span>
> 4. <span data-ttu-id="614e5-219">お使いの Xbox にゲームを Visual Studio からリモートのデバッグ ビルドを開始して展開します。</span><span class="sxs-lookup"><span data-stu-id="614e5-219">Deploy the game to your Xbox by starting a remote debugging build from Visual Studio.</span></span> <span data-ttu-id="614e5-220">Xbox、タイトルを設定する命令を見つけることができます、 [Xbox 開発環境で、UWP 設定](../../xbox-apps/development-environment-setup.md)記事。</span><span class="sxs-lookup"><span data-stu-id="614e5-220">You can find instruction to set up your title on an Xbox in the [Set up your UWP on Xbox development environment](../../xbox-apps/development-environment-setup.md) article.</span></span>
>
> <span data-ttu-id="614e5-221">構成の変更の一部は、マルチ プレーヤーは有効にするが、1 つのプレーヤーのシナリオで、ゲームを実行する必要がように見える場合があります。</span><span class="sxs-lookup"><span data-stu-id="614e5-221">The piece of configuration changed may look like it is enabling multi-player but it is still necessary to run your game in single player scenarios.</span></span>

## <a name="try-out-the-examples"></a><span data-ttu-id="614e5-222">サンプルを試す</span><span class="sxs-lookup"><span data-stu-id="614e5-222">Try out the examples</span></span>

<span data-ttu-id="614e5-223">Unity プロジェクトで Xbox Live を使い始める準備ができました。</span><span class="sxs-lookup"><span data-stu-id="614e5-223">You're all set to start using Xbox Live in your Unity project!</span></span> <span data-ttu-id="614e5-224">**Xbox Live/Examples** フォルダーにあるシーンを開いて、プラグインの動作と機能の使用方法の例をご自分で確認してください。</span><span class="sxs-lookup"><span data-stu-id="614e5-224">Try opening scenes in the **Xbox Live/Examples** folder to see the plugin in action, and for examples of how to use the functionality yourself.</span></span> <span data-ttu-id="614e5-225">エディターの例を実行できるようになります仮のデータが、Visual Studio でプロジェクトをビルドする場合と[サンド ボックスで、Xbox Live アカウントを関連付ける](authorize-xbox-live-accounts.md)ゲーマータグでサインインすることができます。</span><span class="sxs-lookup"><span data-stu-id="614e5-225">Running the examples in the editor will give you fake data, but if you build the project in Visual Studio and [associate your Xbox Live account with the sandbox](authorize-xbox-live-accounts.md), you can sign in with your gamertag.</span></span>

<span data-ttu-id="614e5-226">Microsoft アカウントにサインインするには **SignInAndProfile** シーン、ランキングを作成するには **Leaderboard** シーン、統計を表示および更新するには **UpdateStat** シーンを試してみてください。</span><span class="sxs-lookup"><span data-stu-id="614e5-226">Try the **SignInAndProfile** scene for signing into your Microsoft Account, the **Leaderboard** scene for creating a leaderboard, and the **UpdateStat** scene for displaying and updating stats.</span></span>

## <a name="see-also"></a><span data-ttu-id="614e5-227">関連項目</span><span class="sxs-lookup"><span data-stu-id="614e5-227">See also</span></span>

* [<span data-ttu-id="614e5-228">Unity に住んで Xbox へのサインイン</span><span class="sxs-lookup"><span data-stu-id="614e5-228">Sign in to Xbox Live in Unity</span></span>](unity-prefabs-and-sign-in.md)
* [<span data-ttu-id="614e5-229">Xbox Live アカウントを承認します。</span><span class="sxs-lookup"><span data-stu-id="614e5-229">Authorize Xbox Live accounts</span></span>](authorize-xbox-live-accounts.md)
