---
title: "Unity で Xbox Live を構成する"
author: KevinAsgari
description: "Xbox Live Unity プラグインを使用して、Unity ゲームで Xbox Live を構成する方法について説明します。"
ms.assetid: 55147c41-cc49-47f3-829b-fa7e1a46b2dd
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Unity, 構成"
ms.openlocfilehash: eecf41f579e16bca072e74d1024c355d6d156566
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="configure-xbox-live-in-unity"></a><span data-ttu-id="68b2b-104">Unity で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="68b2b-104">Configure Xbox Live in Unity</span></span>

> <span data-ttu-id="68b2b-105">**注:** 現在、実績とマルチプレイヤーがサポートされていないため、Xbox Live Unity プラグインは [Xbox Live クリエーターズ プログラム](../developer-program-overview.md)のメンバーに対してのみお勧めしています。</span><span class="sxs-lookup"><span data-stu-id="68b2b-105">**Note:** The Xbox Live Unity plugin is only recommended for [Xbox Live Creators Program](../developer-program-overview.md) members, since currently there is no support for achievements or multiplayer.</span></span>

<span data-ttu-id="68b2b-106">Xbox Live Unity プラグインを使用すると、Unity ゲームに Xbox Live サポートを簡単に追加できるため、タイトルに最適な方法で Xbox Live の使用に集中できます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-106">With the Xbox Live Unity plugin, adding Xbox Live support to a Unity game is easy, giving you more time to focus on using Xbox Live in ways that best suit your title.</span></span>

<span data-ttu-id="68b2b-107">このトピックでは、Unity で Xbox Live プラグインをセットアップする手順について説明します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-107">This topic will go through the process of setting up the Xbox Live plugin in Unity.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="68b2b-108">前提条件</span><span class="sxs-lookup"><span data-stu-id="68b2b-108">Prerequisites</span></span>

<span data-ttu-id="68b2b-109">Unity で Xbox Live を構成するには、次の前提条件があります。</span><span class="sxs-lookup"><span data-stu-id="68b2b-109">You will need the following to configure Xbox Live in Unity:</span></span>

* <span data-ttu-id="68b2b-110">[Xbox Live アカウント](https://support.xbox.com/browse/my-account/manage-account/Create%20account)</span><span class="sxs-lookup"><span data-stu-id="68b2b-110">An [Xbox Live account](https://support.xbox.com/browse/my-account/manage-account/Create%20account)</span></span>
* <span data-ttu-id="68b2b-111">[Windows 10 Anniversary Update](https://microsoft.com/windows) 以降</span><span class="sxs-lookup"><span data-stu-id="68b2b-111">[Windows 10 Anniversary Update](https://microsoft.com/windows)  or later</span></span>
* <span data-ttu-id="68b2b-112">[Unity 5.5](https://store.unity.com/) 以降</span><span class="sxs-lookup"><span data-stu-id="68b2b-112">[Unity 5.5](https://store.unity.com/) or later</span></span>
  * <span data-ttu-id="68b2b-113">インストールするときは、必ず **[Windows ストア .NET Scripting Backend]** を選択してください。</span><span class="sxs-lookup"><span data-stu-id="68b2b-113">Make sure to select the **Windows Store .NET scripting backend** when installing.</span></span>
* <span data-ttu-id="68b2b-114">[Visual Studio 2015](https://www.visualstudio.com/) 以降</span><span class="sxs-lookup"><span data-stu-id="68b2b-114">[Visual Studio 2015](https://www.visualstudio.com/) or later</span></span>
  * <span data-ttu-id="68b2b-115">Visual Studio のどのバージョンでも機能します (Community Edition を含む)。</span><span class="sxs-lookup"><span data-stu-id="68b2b-115">Any version of Visual Studio should work for this including Community Edition.</span></span>
  * <span data-ttu-id="68b2b-116">インストールするときは、必ず **[ユニバーサル Windows アプリ開発ツール]** の下にあるすべての項目を選択してください。</span><span class="sxs-lookup"><span data-stu-id="68b2b-116">Make sure to select everything under **Universal Windows App Development Tools** when installing.</span></span>  <span data-ttu-id="68b2b-117">インストールを変更して、既存のインストールにこれらの機能を追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-117">You can modify the installation to include these features for an existing installation as well.</span></span>

## <a name="import-the-unity-plugin"></a><span data-ttu-id="68b2b-118">Unity プラグインをインポートする</span><span class="sxs-lookup"><span data-stu-id="68b2b-118">Import the Unity plugin</span></span>

<span data-ttu-id="68b2b-119">新規または既存の Unity プロジェクトにプラグインをインポートするには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-119">To import the plugin into your new or existing Unity project, follow these steps:</span></span>

1. <span data-ttu-id="68b2b-120">[https://github.com/Microsoft/xbox-live-unity-plugin/releases](https://github.com/Microsoft/xbox-live-unity-plugin/releases) の Xbox Live Unity プラグインにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="68b2b-120">Navigate to the Xbox Live Unity plugin on [https://github.com/Microsoft/xbox-live-unity-plugin/releases](https://github.com/Microsoft/xbox-live-unity-plugin/releases).</span></span>
2. <span data-ttu-id="68b2b-121">XboxLive.unitypackage をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="68b2b-121">Download the XboxLive.unitypackage</span></span>
3. <span data-ttu-id="68b2b-122">XboxLive.unitypackage パッケージをダブルクリックするか、Unity のメニューから [Assets]、[Import Package]、[Custom Package] の順にクリックして、パッケージを Unity プロジェクトにインポートします。</span><span class="sxs-lookup"><span data-stu-id="68b2b-122">Double click the XboxLive.unitypackage package, or in Unity click in the menu under Assets | Import Package | Custom Package, to import it into your Unity project.</span></span>

![Unity パッケージのインポート](../images/unity/unity-import.png)

## <a name="unity-plugin-file-structure"></a><span data-ttu-id="68b2b-124">Unity プラグインのファイル構造</span><span class="sxs-lookup"><span data-stu-id="68b2b-124">Unity plugin file structure</span></span>

<span data-ttu-id="68b2b-125">Unity プラグインのファイル構造は、次の部分に分かれています。</span><span class="sxs-lookup"><span data-stu-id="68b2b-125">The Unity plugin's file structure is broken into the following parts:</span></span>

* <span data-ttu-id="68b2b-126">__Xbox Live__ には、公開された **.unitypackage** に含まれている実際のプラグイン アセットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="68b2b-126">__Xbox Live__ contains the actual plugin assets that are included in the published **.unitypackage**.</span></span>
    * <span data-ttu-id="68b2b-127">__Editor__ には、基本的な Unity 構成 UI を表示し、ビルド時にプロジェクトを処理するスクリプトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="68b2b-127">__Editor__ contains scripts that provide the basic Unity configuration UI and processes the projects during build.</span></span>
    * <span data-ttu-id="68b2b-128">__Examples__ には、さまざまなプレハブを使って相互に接続する方法を示す一連のシンプルなシーン ファイルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="68b2b-128">__Examples__ contains a set of simple scene files that show how to use the various prefabs and connect them together.</span></span>
    * <span data-ttu-id="68b2b-129">__Images__ は、プレハブにより使用される小さいイメージ セットです。</span><span class="sxs-lookup"><span data-stu-id="68b2b-129">__Images__ is a small set of images that are used by the prefabs.</span></span>
    * <span data-ttu-id="68b2b-130">__Libs__ は、Xbox Live ライブラリが保存される場所です。</span><span class="sxs-lookup"><span data-stu-id="68b2b-130">__Libs__ is where the Xbox Live libraries will be stored.</span></span>
    * <span data-ttu-id="68b2b-131">__Prefabs__ には、Xbox Live 機能を実装するさまざまな [Unity プレハブ](https://docs.unity3d.com/Manual/Prefabs.html) オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="68b2b-131">__Prefabs__ contains various [Unity prefab](https://docs.unity3d.com/Manual/Prefabs.html) objects that implement Xbox Live functionality.</span></span>
    * <span data-ttu-id="68b2b-132">__Scripts__ には、プレハブから Xbox Live API を実際に呼び出すコード ファイルがすべて含まれています。</span><span class="sxs-lookup"><span data-stu-id="68b2b-132">__Scripts__ contains all of the code files that actually call the Xbox Live APIs from the prefabs.</span></span>  <span data-ttu-id="68b2b-133">これは、Xbox Live API を正しく呼び出す方法に関する例を探すのに最適な場所です。</span><span class="sxs-lookup"><span data-stu-id="68b2b-133">This is a great place to look for examples about how to properly call the Xbox Live APIs.</span></span>
    * <span data-ttu-id="68b2b-134">__Tools\AssociationWizard__ には、Xbox Live の関連付けウィザードが含まれています。このウィザードは、Unity 内で使用するアプリケーション構成を [Windows デベロッパー センター](https://developer.microsoft.com/windows)から取得するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-134">__Tools\AssociationWizard__ contains the Xbox Live Association Wizard, used to pull down application configuration from the [Windows Dev Center](https://developer.microsoft.com/windows) for use within Unity.</span></span>

## <a name="enable-xbox-live"></a><span data-ttu-id="68b2b-135">Xbox Live を有効にする</span><span class="sxs-lookup"><span data-stu-id="68b2b-135">Enable Xbox Live</span></span>

<span data-ttu-id="68b2b-136">Unity プロジェクトで Xbox Live を実際に有効にするには、次の手順に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="68b2b-136">To actually enable Xbox Live in your Unity project, you'll need to follow these steps:</span></span>

1. <span data-ttu-id="68b2b-137">**[Xbox Live]** メニューで **[Configuration]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-137">In the **Xbox Live** menu, select **Configuration**.</span></span>

    ![Xbox Live: Configuration](../images/unity/xbox-live-configuration.PNG)

2. <span data-ttu-id="68b2b-139">**[Xbox Live]** ウィンドウで、**[Run Xbox Live Association Wizard]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-139">In the **Xbox Live** window, select **Run Xbox Live Association Wizard**.</span></span>

    ![Xbox Live: Xbox Live を有効にする](../images/unity/enable-xbox-live.PNG)

    > <span data-ttu-id="68b2b-141">**注:** Xbox Live サービスを呼び出すには、デバイスが開発者モードになっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="68b2b-141">**Note:** Your device must be in developer mode to call Xbox Live services.</span></span> <span data-ttu-id="68b2b-142">Xbox Live を有効にした後、**[Switch to Developer Mode]** を選択することで開発モードに切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-142">After you have enabled Xbox Live, you can switch to developer mode by selecting **Switch to Developer Mode**.</span></span>

3. <span data-ttu-id="68b2b-143">**[Associate Your Game with the Windows Store]** ダイアログで、**[Next]** をクリックし、デベロッパー センター アカウントを使用してサインインします。</span><span class="sxs-lookup"><span data-stu-id="68b2b-143">In the **Associate Your Game with the Windows Store** dialog, click **Next**, and then sign in with your Dev Center account.</span></span>

    ![Xbox Live: Xbox Live を有効にする](../images/unity/associate-game-with-store.png)

4. <span data-ttu-id="68b2b-145">このプロジェクトに関連付けるアプリを選択し、**[Select]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="68b2b-145">Select the app that you want to associate with this project, and then click **Select**.</span></span> <span data-ttu-id="68b2b-146">アプリが表示されない場合は、**[Refresh]** をクリックしてみてください。</span><span class="sxs-lookup"><span data-stu-id="68b2b-146">If you don't see it there, try clicking **Refresh**.</span></span> <span data-ttu-id="68b2b-147">または、名前を予約して **[Reserve]** をクリックすることで、新しいアプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-147">Alternatively, you can create a new app by reserving a name and clicking **Reserve**.</span></span>

5. <span data-ttu-id="68b2b-148">**[Enable]** をクリックして、ゲームで Xbox Live を有効にします。</span><span class="sxs-lookup"><span data-stu-id="68b2b-148">Click **Enable** to enable Xbox Live in your game.</span></span>

    ![ゲームで Xbox Live の機能を有効にする](../images/unity/associate-your-game-with-the-windows-store.PNG)

6. <span data-ttu-id="68b2b-150">**[Finish]** をクリックして構成を保存します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-150">Click **Finish** to save your configuration.</span></span>

7. <span data-ttu-id="68b2b-151">Unity で **[Xbox Live]** ウィンドウに戻り、**[Developer Mode Configuration]** に **[Enabled]** と表示されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-151">Back in the **Xbox Live** window in Unity, make sure that under **Developer Mode Configuration** it says **Enabled**.</span></span> <span data-ttu-id="68b2b-152">**[Disabled]** になっている場合、**[Switch to Developer Mode]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="68b2b-152">If it says **Disabled**, click **Switch to Developer Mode**.</span></span>

8. <span data-ttu-id="68b2b-153">タイトルが配置されているサンドボックスが、デバイスが現在配置されているサンドボックスと同じであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-153">Make sure that the sandbox in which your title resides is the same as the sandbox in which your device currently does.</span></span> <span data-ttu-id="68b2b-154">タイトルが配置されているサンドボックスは **[Title Configuration]** の **[Sandbox]** で確認できます。デバイスが配置されているサンドボックスは **[Developer Mode Configuration]** の **[Developer Mode]** でかっこで囲まれて示されます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-154">You can see which sandbox your title resides in under **Title Configuration**, next to **Sandbox**; the sandbox that your device is in is under **Developer Mode Configuration**, next to **Developer Mode**, in parentheses.</span></span> <span data-ttu-id="68b2b-155">サンドボックスの詳細、およびデバイスでサンドボックスを切り替える方法については、「[Xbox Live のサンドボックス](../xbox-live-sandboxes.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="68b2b-155">See [Xbox Live sandboxes](../xbox-live-sandboxes.md) for information about sandboxes and how to switch the sandbox on your device.</span></span> <span data-ttu-id="68b2b-156">プラグインでは、デバイスのサンドボックスが自動的に切り替わる必要があります。</span><span class="sxs-lookup"><span data-stu-id="68b2b-156">The plugin should switch the sandbox on your device automatically.</span></span>

    ![有効になった Xbox Live: サンドボックスの一致](../images/unity/unity-xbl-enabled.PNG)

9. <span data-ttu-id="68b2b-158">これで、Unity プロジェクトで Xbox Live が正常に有効になりました。</span><span class="sxs-lookup"><span data-stu-id="68b2b-158">You have now successfully enabled Xbox Live in your Unity project!</span></span>

## <a name="build-and-test-the-project"></a><span data-ttu-id="68b2b-159">プロジェクトのビルドおよびテスト</span><span class="sxs-lookup"><span data-stu-id="68b2b-159">Build and test the project</span></span>

<span data-ttu-id="68b2b-160">エディターでタイトルを実行しているとき、Xbox Live の機能を使おうとすると仮のデータが表示されます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-160">When running your title in the editor, you will see fake data when you try to use Xbox Live functionality.</span></span> <span data-ttu-id="68b2b-161">たとえば、**SignInAndProfile** サンプル シーンで、エディターで実行してサインインしようとすると、プレースホルダー アイコンと共にプロフィール名として **"Fake User 123456789"** と表示されます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-161">For example, in the **SignInAndProfile** example scene, if you run it in the editor and try to sign in, you will see **Fake User 123456789** appear as your profile name, with a placeholder icon.</span></span>

![仮のユーザー: 123456789](../images/unity/unity-game-fake-data.PNG)

<span data-ttu-id="68b2b-163">実際のプロフィールでサインインし、タイトルで Xbox Live の機能をテストするには、Visual Studio でタイトルをビルドして実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="68b2b-163">To sign in with a real profile and test out Xbox Live functionality in your title, you'll need to build and then run it in Visual Studio.</span></span>

1. <span data-ttu-id="68b2b-164">Unity で、**[File]、[Build Settings]** の順に選択するか、**Ctrl + Shift + B** キーを押して **[Build Settings]** ウィンドウを開きます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-164">In Unity, open the **Build Settings** window by selecting **File -> Build Settings** or by pressing **Ctrl+Shift+B**.</span></span>

2. <span data-ttu-id="68b2b-165">**[Scenes In Build]** で、テストするシーンがビルドに含まれていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-165">Make sure that you have the scene that you want to test included in your build under **Scenes In Build**.</span></span> <span data-ttu-id="68b2b-166">一覧に表示されない場合、シーンを開いて **[Add Open Scenes]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-166">If it's not listed, open the scene and select **Add Open Scenes**.</span></span>

3. <span data-ttu-id="68b2b-167">**[Platform]** で **[Windows Store]** を選択して **[Switch Platform]** をクリックすることで、**Windows ストア** プラットフォームに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-167">Switch to the **Windows Store** platform by selecting **Windows Store** under **Platform** and clicking **Switch Platform**.</span></span>

4. <span data-ttu-id="68b2b-168">**[SDK]** で **[Universal 10]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-168">Next to **SDK**, select **Universal 10**.</span></span>

5. <span data-ttu-id="68b2b-169">**[Debugging]** で **[Unity C# Projects]** をオンにします。</span><span class="sxs-lookup"><span data-stu-id="68b2b-169">Under **Debugging**, check **Unity C# Projects**.</span></span>

6. <span data-ttu-id="68b2b-170">**[Build]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="68b2b-170">Click **Build**.</span></span>

    ![ビルド設定](../images/unity/unity-build-settings.PNG)

7. <span data-ttu-id="68b2b-172">エクスプローラーで、ビルドを配置するフォルダーを選択します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-172">Select a folder in which to put the build in the file explorer.</span></span>

8. <span data-ttu-id="68b2b-173">指定したフォルダーから **&lt;ProjectName&gt;\\&lt;ProjectName&gt;.csproj** を Visual Studio で開きます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-173">In the folder that you specified, open **&lt;ProjectName&gt;\\&lt;ProjectName&gt;.csproj** in Visual Studio.</span></span>

9. <span data-ttu-id="68b2b-174">上部にあるツールバーで、デバイスでサポートされているプラットフォームに応じて **[x64]** または **[x86]** を選択し、**[ローカル コンピュータ]** に展開します。</span><span class="sxs-lookup"><span data-stu-id="68b2b-174">In the toolbar at the top, select **x64** or **x86**, depending on what your device supports, and deploy to the **Local Machine**.</span></span>

    ![デバッグ、x64、ローカル コンピューター](../images/unity/vs-debug-local-machine.PNG)

10. <span data-ttu-id="68b2b-176">Xbox Live にサインインする方法をプロジェクトに追加した場合、サンドボックスにアクセスできるアカウントを使用してサインインします。</span><span class="sxs-lookup"><span data-stu-id="68b2b-176">If you have added a way to sign in to Xbox Live to your project, sign in using an account with access to the sandbox.</span></span> <span data-ttu-id="68b2b-177">これで、Xbox Live がタイトルに接続されました。</span><span class="sxs-lookup"><span data-stu-id="68b2b-177">You have now connected Xbox Live to your title!</span></span>

## <a name="try-out-the-examples"></a><span data-ttu-id="68b2b-178">サンプルを試す</span><span class="sxs-lookup"><span data-stu-id="68b2b-178">Try out the examples</span></span>

<span data-ttu-id="68b2b-179">Unity プロジェクトで Xbox Live を使い始める準備ができました。</span><span class="sxs-lookup"><span data-stu-id="68b2b-179">You're all set to start using Xbox Live in your Unity project!</span></span> <span data-ttu-id="68b2b-180">**Xbox Live/Examples** フォルダーにあるシーンを開いて、プラグインの動作と機能の使用方法の例をご自分で確認してください。</span><span class="sxs-lookup"><span data-stu-id="68b2b-180">Try opening scenes in the **Xbox Live/Examples** folder to see the plugin in action, and for examples of how to use the functionality yourself.</span></span> <span data-ttu-id="68b2b-181">エディターでサンプルを実行するとダミー データが表示されますが、Visual Studio でプロジェクトをビルドして Microsoft アカウントをサンドボックスに関連付けた場合は、ゲーマータグでサインインすることができます。</span><span class="sxs-lookup"><span data-stu-id="68b2b-181">Running the examples in the editor will give you dummy data, but if you build the project in Visual Studio and associate your Microsoft Account with the sandbox, you can sign in with your gamertag!</span></span>

<span data-ttu-id="68b2b-182">Microsoft アカウントにサインインするには **SignInAndProfile** シーン、ランキングを作成するには **Leaderboard** シーン、統計を表示および更新するには **UpdateStat** シーンを試してみてください。</span><span class="sxs-lookup"><span data-stu-id="68b2b-182">Try the **SignInAndProfile** scene for signing into your Microsoft Account, the **Leaderboard** scene for creating a leaderboard, and the **UpdateStat** scene for displaying and updating stats.</span></span>

## <a name="see-also"></a><span data-ttu-id="68b2b-183">関連項目</span><span class="sxs-lookup"><span data-stu-id="68b2b-183">See also</span></span>

* [<span data-ttu-id="68b2b-184">Unity で Xbox Live にサインインする</span><span class="sxs-lookup"><span data-stu-id="68b2b-184">Sign in to Xbox Live in Unity</span></span>](sign-in-to-xbox-live-in-unity.md)
