---
title: XDK から UWP への Xbox Live コードの移植
author: KevinAsgari
description: Xbox Live コードを Xbox 開発キット (XDK) プラットフォームからユニバーサル Windows プラットフォーム (UWP) に移植する方法について説明します。
ms.assetid: 69939f95-44ad-4ffd-851f-59b0745907c8
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, XDK, 移植
ms.localizationpriority: medium
ms.openlocfilehash: 91a30a81123902d7b4b2f8311ae1f24bd23b3e43
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6209570"
---
# <a name="porting-xbox-live-code-from-the-xbox-developer-kit-xdk-to-universal-windows-platform-uwp"></a><span data-ttu-id="ab456-104">Xbox 開発キット (XDK) からユニバーサル Windows プラットフォーム (UWP) への Xbox Live コード移植</span><span class="sxs-lookup"><span data-stu-id="ab456-104">Porting Xbox Live code from the Xbox Developer Kit (XDK) to Universal Windows Platform (UWP)</span></span>

## <a name="introduction"></a><span data-ttu-id="ab456-105">概要</span><span class="sxs-lookup"><span data-stu-id="ab456-105">Introduction</span></span>

<span data-ttu-id="ab456-106">この記事では、Xbox One XDK を使用していたデベロッパーが、その Xbox Live コードの Windows 10 ユニバーサル Windows プラットフォーム (UWP) への移行を開始できるように情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="ab456-106">This article is intended to help developers who have used the Xbox One XDK to get started migrating their Xbox Live code to the Windows 10 Universal Windows Platform (UWP).</span></span>

<span data-ttu-id="ab456-107">この移行の一環として、XSAPI 1.0 (Xbox Live Services API、August 2015 まで Xbox One XDK に含まれていました) から XSAPI 2.0 (November 2015 以降 の Xbox One XDK に含まれ、Xbox Live SDK でも利用できます) への切り替えがあります。</span><span class="sxs-lookup"><span data-stu-id="ab456-107">Part of this migration includes switching from XSAPI 1.0 (Xbox Live Services API, included in the Xbox One XDK through August 2015) to XSAPI 2.0 (included in the Xbox One XDK starting in November 2015, and also available in the Xbox Live SDK.</span></span> <span data-ttu-id="ab456-108">これらの API の機能は実質的に同一ですが、実装上の重要な相違点がいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="ab456-108">The functionality of these APIs are virtually identical, but there are some important implementation differences.</span></span>

<span data-ttu-id="ab456-109">この記事で取り上げるその他のトピックには、Windows 開発用コンピューターを準備すること、通常は Xbox Live サービスの使用時に必要になる、セキュア ソケット API やクラウド バックアップのゲーム セーブを管理するための接続ストレージ API などの API をインストールすることが含まれます。</span><span class="sxs-lookup"><span data-stu-id="ab456-109">Other topics to be covered in this article include preparing your Windows development computer and installing other APIs typically needed when using Xbox Live services, such as the Secure Sockets API as well as the Connected Storage API for managing cloud-backed game saves.</span></span>

<a name="_Setting_up_and"></a>

## <a name="setting-up-and-configuring-your-project-in-partner-center-and-xdp"></a><span data-ttu-id="ab456-110">設定して、パートナー センターおよび XDP でプロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="ab456-110">Setting up and configuring your project in Partner Center and XDP</span></span>

<span data-ttu-id="ab456-111">Xbox Live サービスを使用する UWP タイトルは、[パートナー センター](https://partner.microsoft.com/dashboard)で構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-111">A UWP title that uses Xbox Live services needs to be configured in [Partner Center](https://partner.microsoft.com/dashboard).</span></span> <span data-ttu-id="ab456-112">最新の情報については、[Xbox Live SDK](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx) に含まれる『Xbox Live プログラミング ガイド』の「[新規または既存の UWP プロジェクトに Xbox Live を追加する方法](../get-started-with-partner/get-started-with-visual-studio-and-uwp.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-112">For the latest information, see [Adding Xbox Live to a new or existing UWP project](../get-started-with-partner/get-started-with-visual-studio-and-uwp.md) in the Xbox Live Programming Guide included with the [Xbox Live SDK](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx).</span></span>

<span data-ttu-id="ab456-113">そのページのトピックには、タイトルで Xbox Live サービスを使用するための、以下の手順が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ab456-113">Topics on that page include these steps for using Xbox Live services in your title:</span></span>

-   <span data-ttu-id="ab456-114">パートナー センターで UWP アプリ プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="ab456-114">Create the UWP app project in Partner Center.</span></span>

-   <span data-ttu-id="ab456-115">XDP を使用して、Xbox Live を使用するためにプロジェクトをセットアップする。</span><span class="sxs-lookup"><span data-stu-id="ab456-115">Use XDP to set up your project for Xbox Live usage.</span></span>

-   <span data-ttu-id="ab456-116">パートナー センター製品を XDP のプロダクトにリンクします。</span><span class="sxs-lookup"><span data-stu-id="ab456-116">Link your Partner Center product to your XDP product.</span></span>

-   <span data-ttu-id="ab456-117">XDP でデベロッパー アカウントを作成する (サンドボックスでの Xbox Live タイトルの実行時に必要)。</span><span class="sxs-lookup"><span data-stu-id="ab456-117">Create developer accounts in XDP (required when running your Xbox Live title in your sandbox).</span></span>

<span data-ttu-id="ab456-118">タイトルでマルチプレイヤー プレイをサポートする場合は、マルチプレイヤー セッション テンプレートで、いくつかの追加設定が必要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="ab456-118">If your titles support multiplayer play, some additional settings may be required in your multiplayer session templates.</span></span> <span data-ttu-id="ab456-119">Xbox Live マルチプレイヤーを使用し、MPSD (Multiplayer Session Directory) に書き込みを行うすべての Windows 10 タイトルで、セッション テンプレートにある "機能" のリスト内に、```userAuthorizationStyle: true``` という新しいフィールドが必要です。</span><span class="sxs-lookup"><span data-stu-id="ab456-119">All Windows 10 titles that use Xbox Live multiplayer and write to an MPSD (multiplayer session document) require this new field in the list of "capabilities" found in your session templates: ```userAuthorizationStyle: true```.</span></span>

### <a name="enabling-cross-play"></a><span data-ttu-id="ab456-120">クロス プレイの有効化</span><span class="sxs-lookup"><span data-stu-id="ab456-120">Enabling cross-play</span></span>

<span data-ttu-id="ab456-121">"クロス プレイ" (デバイス横断型のマルチプレイヤー ゲームを可能にする、Xbox One と PC ゲーム 間で共有される Xbox Live 構成) をサポートする予定であれば、この機能も、セッション テンプレートに **crossPlay: true** として追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-121">If you will support "cross-play" (a shared Xbox Live configuration between Xbox One and PC games, allowing cross-device multiplayer gaming), you will also need to add this capability to your session templates: **crossPlay: true**.</span></span>

<span data-ttu-id="ab456-122">XDP でクロス プレイとその構成要件をサポートにすることに関する追加情報については、『Xbox Live プログラミング ガイド』の「XDP での XDK および UWP のクロスプレイ タイトルの取り込み」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-122">For additional information about supporting cross-play and its configuration requirements in XDP, see "Ingesting XDK and UWP Cross-Play Titles in XDP" in the Xbox Live Programming Guide.</span></span>

<span data-ttu-id="ab456-123">また、プログラムに関するいくつかの考慮事項については、後の「[Xbox One および PC UWP 間のマルチプレイヤー クロス プレイのサポート](#_Supporting_multiplayer_cross-play)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-123">Also, for some programmatic considerations, see the later section [Supporting multiplayer cross-play between Xbox One and PC](#_Supporting_multiplayer_cross-play).</span></span>

## <a name="setting-up-your-windows-development-environment"></a><span data-ttu-id="ab456-124">Windows 開発環境のセットアップ</span><span class="sxs-lookup"><span data-stu-id="ab456-124">Setting up your Windows development environment</span></span>

1.  <span data-ttu-id="ab456-125">[最新の **Xbox Live SDK** をダウンロード](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx)して、ローカルに抽出します。</span><span class="sxs-lookup"><span data-stu-id="ab456-125">[Download the latest **Xbox Live SDK**](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx) and extract locally.</span></span>

2.  <span data-ttu-id="ab456-126">UWP 用にセキュア ソケット API や Game Save API (別名接続ストレージ API) が必要な場合は、[**Xbox Live Platform Extensions SDK** をインストール](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="ab456-126">[Install the **Xbox Live Platform Extensions SDK**](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx) if you need the Secure Sockets API and/or the Game Save API (aka Connected Storage) for UWP.</span></span>

3.  <span data-ttu-id="ab456-127">Visual Studio で、ユニバーサル Windows アプリ プロジェクトに Xbox Live サポートを追加します。</span><span class="sxs-lookup"><span data-stu-id="ab456-127">Add Xbox Live support to your Universal Windows app project in Visual Studio.</span></span> <span data-ttu-id="ab456-128">完全なソースを追加したり、Visual Studio のプロジェクトに NuGet パッケージをインストールしてバイナリを参照することができます。</span><span class="sxs-lookup"><span data-stu-id="ab456-128">You can add either the full source or reference the binaries by installing the NuGet package into your Visual Studio project.</span></span> <span data-ttu-id="ab456-129">C++ と WinRT の両方にパッケージが提供されています。</span><span class="sxs-lookup"><span data-stu-id="ab456-129">Packages are available for both C++ and WinRT.</span></span> <span data-ttu-id="ab456-130">詳細については、「[新規または既存の UWP プロジェクトに Xbox Live を追加する方法](../get-started-with-partner/get-started-with-visual-studio-and-uwp.md)」を参照してください</span><span class="sxs-lookup"><span data-stu-id="ab456-130">For more detail see [Adding Xbox Live to a new or existing UWP project](../get-started-with-partner/get-started-with-visual-studio-and-uwp.md)</span></span>

4.  <span data-ttu-id="ab456-131">開発用コンピューターを、サンドボックスを使用するように構成します。</span><span class="sxs-lookup"><span data-stu-id="ab456-131">Configure your development computer to use your sandbox.</span></span> <span data-ttu-id="ab456-132">Xbox Live SDK の Tools ディレクトリに、管理者のコマンド プロンプトから使用できるコマンド ライン スクリプト (例: SwitchSandbox.cmd XDKS.1) があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-132">There's a command-line script in the Tools directory of the Xbox Live SDK that you can use from an administrator command prompt (for example: SwitchSandbox.cmd XDKS.1).</span></span>

  <span data-ttu-id="ab456-133">**注** Retail サンドボックスに切り替える場合は、スクリプトによって変更されたレジストリ キーを削除しても、RETAIL という名前のサンドボックスに切り替えてもかまいません。</span><span class="sxs-lookup"><span data-stu-id="ab456-133">**Note** To switch back to the retail sandbox, you can either delete the registry key that the script modifies, or you can switch to the sandbox called RETAIL.</span></span>

1.  <span data-ttu-id="ab456-134">開発用コンピューターにデベロッパー アカウントを追加します。</span><span class="sxs-lookup"><span data-stu-id="ab456-134">Add a developer account to your development computer.</span></span> <span data-ttu-id="ab456-135">XDP で作成したデベロッパー アカウントは、割り当てられたサンドボックスでの開発時やサンプルの実行時には、ランタイムで Xbox Live サービスとやり取りする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-135">A developer account created in XDP is required to interact with Xbox Live services at runtime when you are developing in your assigned sandbox or running samples.</span></span> <span data-ttu-id="ab456-136">Windows に 1 つまたは複数のアカウントを追加するには、次の操作を行います。</span><span class="sxs-lookup"><span data-stu-id="ab456-136">To add one or more accounts to Windows:</span></span>

    1.  <span data-ttu-id="ab456-137">**[設定]** を開きます (ショートカット: Windows キー + I)。</span><span class="sxs-lookup"><span data-stu-id="ab456-137">Open **Settings** (shortcut: Windows key + I).</span></span>

    2.  <span data-ttu-id="ab456-138">**[アカウント]** を開きます。</span><span class="sxs-lookup"><span data-stu-id="ab456-138">Open **Accounts**.</span></span>

    3.  <span data-ttu-id="ab456-139">**[アカウント]** タブで、**[Microsoft アカウントを追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="ab456-139">On the **Your Account** tab, click **Add a Microsoft account**.</span></span>

    4.  <span data-ttu-id="ab456-140">デベロッパー アカウントの電子メールとパスワードを入力します。</span><span class="sxs-lookup"><span data-stu-id="ab456-140">Enter the developer account email and password.</span></span>

### <a name="appxmanifest-changes"></a><span data-ttu-id="ab456-141">AppXManifest の変更</span><span class="sxs-lookup"><span data-stu-id="ab456-141">AppxManifest changes</span></span>

<span data-ttu-id="ab456-142">Xbox バージョンの appxmanifest.xml ファイルと、UWP バージョンの appxmanifest.xml ファイルの最も一般的な変更点は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="ab456-142">The most common changes between the Xbox and UWP versions of the appxmanifest.xml file are:</span></span>

1. <span data-ttu-id="ab456-143">UWP では、開発中であっても Package Identity が問題となります。</span><span class="sxs-lookup"><span data-stu-id="ab456-143">Package Identity matters in UWP, even during development.</span></span> <span data-ttu-id="ab456-144">Id 名と発行元の両方*と一致する必要があります*UWP アプリのパートナー センターで定義されたものです。</span><span class="sxs-lookup"><span data-stu-id="ab456-144">Both the Identity Name and Publisher *must match* what was defined in Partner Center for your UWP app.</span></span>

1. <span data-ttu-id="ab456-145">Package Dependency セクションが必要です。</span><span class="sxs-lookup"><span data-stu-id="ab456-145">A Package Dependency section is required.</span></span> <span data-ttu-id="ab456-146">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ab456-146">For example:</span></span>

```xml
  <Dependencies>
    <TargetDeviceFamily Name="Windows.Universal" MinVersion="10.0.10240.0" MaxVersionTested="10.0.10240.0" />
  </Dependencies>
```

1.  <span data-ttu-id="ab456-147">アプリケーション マニフェストの、UWP には固有の要件があるその他のセクションについては、UWP アプリケーション マニフェストの例 (たとえば、```<VisualElements>``` など、Xbox Live SDK に含まれる UWP サンプルの 1 つや、Visual Studio 内に作成される既定のユニバーサル Windows アプリ プロジェクト) を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-147">Refer to an example UWP application manifest (for example, one of the UWP samples included with the Xbox Live SDK or a default Universal Windows app project created in Visual Studio) for other sections of the application manifest that have specific requirements for UWP, such as ```<VisualElements>```.</span></span>

1.  <span data-ttu-id="ab456-148">タイトルと SCID は、"xbox.live" 拡張機能カテゴリーではなく、xboxservices.config ファイル ([次のセクション](#_Define_your_title)を参照) で定義されます。</span><span class="sxs-lookup"><span data-stu-id="ab456-148">Title and SCID are defined in the xboxservices.config file (see the [next section](#_Define_your_title)) instead of in the "xbox.live" extension category.</span></span>

1.  <span data-ttu-id="ab456-149">"xbox.system.resources" 拡張機能カテゴリーは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="ab456-149">The "xbox.system.resources" extension category is not needed.</span></span>

1.  <span data-ttu-id="ab456-150">セキュア ソケットは、"windows.xbox.networking" カテゴリーではなく、networkmanifest.xml ファイル (「[セキュア ソケット](#_Secure_sockets)」を参照) で定義されます。</span><span class="sxs-lookup"><span data-stu-id="ab456-150">Secure Sockets are defined in the networkmanifest.xml file (see [Secure sockets](#_Secure_sockets)) instead of in the "windows.xbox.networking" category.</span></span>

1.  <span data-ttu-id="ab456-151">UWP タイトルで Xbox Live の招待を受信するためには、"windows.protocol" 拡張機能カテゴリーが定義されている必要があります (「[招待の送受信](#_Sending_and_receiving)」を参照)。</span><span class="sxs-lookup"><span data-stu-id="ab456-151">A "windows.protocol" extension category must be defined in order to receive Xbox Live invites in your UWP title (see [Sending and receiving invites](#_Sending_and_receiving)).</span></span>

1.  <span data-ttu-id="ab456-152">GameChat API を使用する場合は、```<Capabilities>``` 要素内にマイク デバイスの機能を追加することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ab456-152">If you use the GameChat API, you'll want to add the microphone device capability inside the ```<Capabilities>``` element.</span></span> <span data-ttu-id="ab456-153">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ab456-153">For example:</span></span>

  ```<DeviceCapability Name="microphone">```

<a name="_Define_your_title"></a>

### <a name="define-your-title-and-scid-for-the-xbox-live-sdk-in-a-config-file"></a><span data-ttu-id="ab456-154">config ファイルで、Xbox Live SDK のタイトルと SCID を定義する</span><span class="sxs-lookup"><span data-stu-id="ab456-154">Define your title and SCID for the Xbox Live SDK in a config file</span></span>

<span data-ttu-id="ab456-155">Xbox Live SDK はタイトルの ID と SCID を知る必要がありますが、それらは UWP タイトルの appxmanifest.xml には含まれなくなっています。</span><span class="sxs-lookup"><span data-stu-id="ab456-155">The Xbox Live SDK needs to know your title ID and SCID, which are no longer included in the appxmanifest.xml for UWP titles.</span></span> <span data-ttu-id="ab456-156">代わりに、プロジェクトのルート ディレクトリ内に **xboxservices.config** という名前のテキスト ファイルを作成し、タイトルの情報で値を置き換えて次のフィールドを追加します。</span><span class="sxs-lookup"><span data-stu-id="ab456-156">Instead, you create a text file named **xboxservices.config** in your project root directory and add the following fields, replacing the values with the info for your title:</span></span>

```
{
  "TitleId": 123456789,
  "PrimaryServiceConfigId": "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
}
```

> [!NOTE]
> <span data-ttu-id="ab456-157">xboxservices.config 内のすべての値で大文字と小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="ab456-157">All values inside xboxservices.config are case sensitive.</span></span>

<span data-ttu-id="ab456-158">ビルド出力で使用できるように、この config ファイルを内容としてプロジェクトに含めます。</span><span class="sxs-lookup"><span data-stu-id="ab456-158">Include this config file as content in your project so that it is available in the build output.</span></span>

<span data-ttu-id="ab456-159">**注** これらの値は、次の API を使用することによって、タイトル内でプログラムから使用可能になります。</span><span class="sxs-lookup"><span data-stu-id="ab456-159">**Note** These values will be available programmatically within your title by using the following API:</span></span>

```cpp
Microsoft::Xbox::Services::XboxLiveAppConfiguration^ xblConfig = xblContext->AppConfig;
unsigned int titleId = xblConfig->TitleId;
Platform::String^ scid = xblConfig->ServiceConfigurationId;
```

### <a name="api-namespace-mapping"></a><span data-ttu-id="ab456-160">API 名前空間のマッピング</span><span class="sxs-lookup"><span data-stu-id="ab456-160">API namespace mapping</span></span>

<span data-ttu-id="ab456-161">表 1: </span><span class="sxs-lookup"><span data-stu-id="ab456-161">Table 1.</span></span> <span data-ttu-id="ab456-162">XDK から UWP への名前空間のマッピング</span><span class="sxs-lookup"><span data-stu-id="ab456-162">Namespace mapping from XDK to UWP.</span></span>

<table>
  <tr>
    <td></td>
    <td><b><span data-ttu-id="ab456-163">Xbox One XDK</span><span class="sxs-lookup"><span data-stu-id="ab456-163">Xbox One XDK</span></span></b></td><td><b><span data-ttu-id="ab456-164">UWP</span><span class="sxs-lookup"><span data-stu-id="ab456-164">UWP</span></span></b></td>
    <td><b><span data-ttu-id="ab456-165">API の収録先</span><span class="sxs-lookup"><span data-stu-id="ab456-165">API is available with...</span></span></b></td>
  </tr>
  <tr>
    <td><span data-ttu-id="ab456-166">Xbox サービス API (XSAPI)</span><span class="sxs-lookup"><span data-stu-id="ab456-166">Xbox Services API (XSAPI)</span></span></td>
    <td><span data-ttu-id="ab456-167">Microsoft::Xbox::Services</span><span class="sxs-lookup"><span data-stu-id="ab456-167">Microsoft::Xbox::Services</span></span></td>
    <td><span data-ttu-id="ab456-168">Microsoft::Xbox::Services (<i>変更なし</i>)</span><span class="sxs-lookup"><span data-stu-id="ab456-168">Microsoft::Xbox::Services (<i>no change</i>)</span></span></td>
    <td><span data-ttu-id="ab456-169">Xbox Live SDK (NuGet バイナリまたはソースを使用)</span><span class="sxs-lookup"><span data-stu-id="ab456-169">Xbox Live SDK (use NuGet binary or source)</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="ab456-170">GameChat</span><span class="sxs-lookup"><span data-stu-id="ab456-170">GameChat</span></span></td>
    <td>
<span data-ttu-id="ab456-171">Microsoft::Xbox::GameChat Windows::Xbox::Chat</span><span class="sxs-lookup"><span data-stu-id="ab456-171">Microsoft::Xbox::GameChat Windows::Xbox::Chat</span></span> </td>
    <td>
<span data-ttu-id="ab456-172">Microsoft::Xbox::GameChat (*変更なし*) Microsoft::Xbox::ChatAudio</span><span class="sxs-lookup"><span data-stu-id="ab456-172">Microsoft::Xbox::GameChat (*no change*) Microsoft::Xbox::ChatAudio</span></span> </td>
    <td>
<span data-ttu-id="ab456-173">Xbox Live SDK (NuGet binary バイナリを使用)</span><span class="sxs-lookup"><span data-stu-id="ab456-173">Xbox Live SDK (use NuGet binary)</span></span> </td>
  </tr>
  <tr>
    <td><span data-ttu-id="ab456-174">SecureSockets</span><span class="sxs-lookup"><span data-stu-id="ab456-174">SecureSockets</span></span></td>
    <td><span data-ttu-id="ab456-175">Windows::Xbox::Networking</span><span class="sxs-lookup"><span data-stu-id="ab456-175">Windows::Xbox::Networking</span></span></td>
    <td><span data-ttu-id="ab456-176">Windows::Networking::XboxLive</span><span class="sxs-lookup"><span data-stu-id="ab456-176">Windows::Networking::XboxLive</span></span></td>
    <td><span data-ttu-id="ab456-177">Xbox Live Platform Extensions SDK</span><span class="sxs-lookup"><span data-stu-id="ab456-177">Xbox Live Platform Extensions SDK</span></span></td>
  </tr>
  <tr>
    <td><span data-ttu-id="ab456-178">接続ストレージ</span><span class="sxs-lookup"><span data-stu-id="ab456-178">Connected Storage</span></span></td>
    <td><span data-ttu-id="ab456-179">Windows::Xbox::Storage</span><span class="sxs-lookup"><span data-stu-id="ab456-179">Windows::Xbox::Storage</span></span></td>
    <td><span data-ttu-id="ab456-180">Windows::Gaming::XboxLive::Storage</span><span class="sxs-lookup"><span data-stu-id="ab456-180">Windows::Gaming::XboxLive::Storage</span></span></td>
    <td><span data-ttu-id="ab456-181">Xbox Live Platform Extensions SDK</span><span class="sxs-lookup"><span data-stu-id="ab456-181">Xbox Live Platform Extensions SDK</span></span></td>
  </tr>
</table>

### <a name="multiplayer-subscriptions-and-event-handling"></a><span data-ttu-id="ab456-182">マルチプレイヤーのサブスクリプションとイベント処理</span><span class="sxs-lookup"><span data-stu-id="ab456-182">Multiplayer subscriptions and event handling</span></span>

<span data-ttu-id="ab456-183">ほとんどのマルチプレイヤー タイトルに影響する XSAPI 1.0 から XSAPI 2.0 への最新の変更の 1 つは、いくつかのメソッドとイベントが **RealTimeActivityService** から **MultiplayerService** に移されたことです。</span><span class="sxs-lookup"><span data-stu-id="ab456-183">One of the breaking changes from XSAPI 1.0 to XSAPI 2.0 that most multiplayer titles will encounter is the move of several methods and events from the **RealTimeActivityService** to the **MultiplayerService**.</span></span>

<span data-ttu-id="ab456-184">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ab456-184">For example:</span></span>

-   <span data-ttu-id="ab456-185">**EnableMultiplayerSubscriptions()\*** メソッド</span><span class="sxs-lookup"><span data-stu-id="ab456-185">**EnableMultiplayerSubscriptions()\*** method</span></span>

-   <span data-ttu-id="ab456-186">**DisableMultiplayerSubscriptions()** メソッド</span><span class="sxs-lookup"><span data-stu-id="ab456-186">**DisableMultiplayerSubscriptions()** method</span></span>

-   <span data-ttu-id="ab456-187">**MultiplayerSessionChanged** イベント</span><span class="sxs-lookup"><span data-stu-id="ab456-187">**MultiplayerSessionChanged** event</span></span>

-   <span data-ttu-id="ab456-188">**MultiplayerSubscriptionLost** イベント</span><span class="sxs-lookup"><span data-stu-id="ab456-188">**MultiplayerSubscriptionLost** event</span></span>

-   <span data-ttu-id="ab456-189">**MultiplayerSubscriptionsEnabled** プロパティ</span><span class="sxs-lookup"><span data-stu-id="ab456-189">**MultiplayerSubscriptionsEnabled** property</span></span>

<span data-ttu-id="ab456-190">**実装に関する重要事項** これらのイベントやメソッドの **MultiplayerService** への移行後、**RealTimeActivityService** で他に何も明示的に使用していなくても、マルチプレイヤーのサブスクリプションには RTA サービスが必要なため、**EnableMultiplayerSubscriptions()** を呼び出す前に **xblContext-&gt;RealTimeActivityService-&gt;Activate()** を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-190">**Important implementation note** Even though you might not be explicitly using anything else in the **RealTimeActivityService** after moving these events and methods over to the **MultiplayerService**, you must still call **xblContext-&gt;RealTimeActivityService-&gt;Activate()** before calling **EnableMultiplayerSubscriptions()** because the multiplayer subscriptions require the RTA service.</span></span>

## <a name="whats-handled-differently-in-uwp"></a><span data-ttu-id="ab456-191">UWP では処理が異なる事柄</span><span class="sxs-lookup"><span data-stu-id="ab456-191">What's handled differently in UWP</span></span>

<span data-ttu-id="ab456-192">次の非常に大まかなリストは、新しい [NetRumble サンプル](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx) (XDK および UWP の両方のバージョンが含まれます) で確認できるような、XDK と UWP の間で違いがある可能性が高いコードのセクションを示しています。</span><span class="sxs-lookup"><span data-stu-id="ab456-192">Following is a very high level list of sections of code that will likely have differences between the XDK and UWP, as encountered in the new [NetRumble sample](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx) (which includes both XDK and UWP versions):</span></span>

-   <span data-ttu-id="ab456-193">タイトル ID と SCID 情報へのアクセス</span><span class="sxs-lookup"><span data-stu-id="ab456-193">Accessing title ID and SCID info</span></span>

-   <span data-ttu-id="ab456-194">起動前アクティベーション (UWP では新機能)</span><span class="sxs-lookup"><span data-stu-id="ab456-194">Prelaunch activation (new for UWP)</span></span>

-   <span data-ttu-id="ab456-195">PLM 処理の一時停止/再開</span><span class="sxs-lookup"><span data-stu-id="ab456-195">Suspend/resume PLM handling</span></span>

-   <span data-ttu-id="ab456-196">拡張実行 (UWP では新機能)</span><span class="sxs-lookup"><span data-stu-id="ab456-196">Extended execution (new for UWP)</span></span>

-   <span data-ttu-id="ab456-197">Xbox の **User** オブジェクトとユーザー処理の違い</span><span class="sxs-lookup"><span data-stu-id="ab456-197">Xbox **User** object and user-handling differences</span></span>

    -   <span data-ttu-id="ab456-198">サインインおよびサインアウトの処理</span><span class="sxs-lookup"><span data-stu-id="ab456-198">Sign-in and sign-out handling</span></span>

    -   <span data-ttu-id="ab456-199">コントローラーのペアリング (Xbox でのみ処理されます)</span><span class="sxs-lookup"><span data-stu-id="ab456-199">Controller pairing (only handled on Xbox)</span></span>

    -   <span data-ttu-id="ab456-200">コントローラーの処理</span><span class="sxs-lookup"><span data-stu-id="ab456-200">Gamepad handling</span></span>

-   <span data-ttu-id="ab456-201">マルチプレイヤー権限の確認</span><span class="sxs-lookup"><span data-stu-id="ab456-201">Checking multiplayer privileges</span></span>

-   <span data-ttu-id="ab456-202">Xbox One および PC の間のマルチプレイヤー クロスプレイのサポート</span><span class="sxs-lookup"><span data-stu-id="ab456-202">Supporting multiplayer cross-play between Xbox One and PC</span></span>

-   <span data-ttu-id="ab456-203">ゲームへの招待の送信</span><span class="sxs-lookup"><span data-stu-id="ab456-203">Sending game invites</span></span>

    -   <span data-ttu-id="ab456-204">ゲーム内からパーティー アプリを開く機能 (UWP では対象外)</span><span class="sxs-lookup"><span data-stu-id="ab456-204">Ability to open party app from in-game - n/a on UWP</span></span>

    -   <span data-ttu-id="ab456-205">ゲーム内からパーティー メンバーを列挙する機能 (UWP では対象外)</span><span class="sxs-lookup"><span data-stu-id="ab456-205">Ability to enumerate party members from in-game - n/a on UWP</span></span>

-   <span data-ttu-id="ab456-206">ゲーマー プロフィールの表示</span><span class="sxs-lookup"><span data-stu-id="ab456-206">Showing the gamer profile</span></span>

-   <span data-ttu-id="ab456-207">セキュア ソケット API サーフェスの変更</span><span class="sxs-lookup"><span data-stu-id="ab456-207">Secure Socket API surface changes</span></span>

-   <span data-ttu-id="ab456-208">QoS 測定の開始と結果の処理</span><span class="sxs-lookup"><span data-stu-id="ab456-208">QoS measurement initiation and result handling</span></span>

-   <span data-ttu-id="ab456-209">ゲーム イベントの書き込み</span><span class="sxs-lookup"><span data-stu-id="ab456-209">Writing game events</span></span>

-   <span data-ttu-id="ab456-210">GameChat: イベント、設定、ChatUser オブジェクト</span><span class="sxs-lookup"><span data-stu-id="ab456-210">GameChat: events, settings, and ChatUser object</span></span>

-   <span data-ttu-id="ab456-211">接続ストレージ API サーフェスの変更</span><span class="sxs-lookup"><span data-stu-id="ab456-211">Connected Storage API surface changes</span></span>

-   <span data-ttu-id="ab456-212">PIX イベント (Xbox のみ、このホワイト ペーパーの範囲外)</span><span class="sxs-lookup"><span data-stu-id="ab456-212">PIX events (only on Xbox; not covered in this white paper)</span></span>

-   <span data-ttu-id="ab456-213">レンダリングに関するいくつかの相違</span><span class="sxs-lookup"><span data-stu-id="ab456-213">Some rendering differences</span></span>

<span data-ttu-id="ab456-214">後続のセクションでは、これらの違いの多くについて、さらに詳しく説明してゆきます。</span><span class="sxs-lookup"><span data-stu-id="ab456-214">The following sections go into further detail on many of these differences.</span></span>

### <a name="accessing-title-id-and-scid-info"></a><span data-ttu-id="ab456-215">タイトル ID と SCID 情報へのアクセス</span><span class="sxs-lookup"><span data-stu-id="ab456-215">Accessing title ID and SCID info</span></span>

<span data-ttu-id="ab456-216">UWP では、タイトル ID とサービス構成 ID には、**XboxLiveContext** のインスタンスで、AppConfig プロパティを通じてアクセスします。</span><span class="sxs-lookup"><span data-stu-id="ab456-216">In UWP, your title ID and service configuration ID are accessed through the AppConfig property on an instance of an **XboxLiveContext**.</span></span>

```cpp
Microsoft::Xbox::Services::XboxLiveAppConfiguration^ xblConfig = xblContext->AppConfig;
unsigned int titleId = xblConfig->TitleId;
Platform::String^ scid = xblConfig->ServiceConfigurationId;
```

<span data-ttu-id="ab456-217">**注** XDK では、これらの新しいプロパティまたは **Windows::Xbox::Services::XboxLiveConfiguration** の古い静的プロパティを使用して、これらの ID を取得できます。</span><span class="sxs-lookup"><span data-stu-id="ab456-217">**Note** In the XDK, you can get these IDs by using either these new properties or the old static properties in **Windows::Xbox::Services::XboxLiveConfiguration**.</span></span>

### <a name="prelaunch-activation"></a><span data-ttu-id="ab456-218">起動前アクティベーション</span><span class="sxs-lookup"><span data-stu-id="ab456-218">Prelaunch activation</span></span>

<span data-ttu-id="ab456-219">Windows 10 で頻繁に使用されるタイトルは、ユーザーがサインインするときにあらかじめ起動されていることがあります。</span><span class="sxs-lookup"><span data-stu-id="ab456-219">Frequently-used titles in Windows 10 may be prelaunched when the user signs in.</span></span> <span data-ttu-id="ab456-220">これに対処するため、タイトルには、**PreLaunchActivated** の起動引数をチェックするコードを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-220">To handle this, your title should have code that checks the launch arguments for **PreLaunchActivated**.</span></span> <span data-ttu-id="ab456-221">たとえば、このような種類のアクティベーションの間にすべてのリソースを読み込む必要は、おそらくないでしょう。</span><span class="sxs-lookup"><span data-stu-id="ab456-221">For example, you probably don't want to load all your resources during this kind of activation.</span></span> <span data-ttu-id="ab456-222">詳細については、MSDN のホワイトペーパー「[アプリの事前起動の処理](https://msdn.microsoft.com/library/windows/apps/mt593297.ASPx)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-222">For more information, see the MSDN article [Handle app prelaunch](https://msdn.microsoft.com/library/windows/apps/mt593297.ASPx).</span></span>

### <a name="suspendresume-plm-handling"></a><span data-ttu-id="ab456-223">PLM 処理の一時停止/再開</span><span class="sxs-lookup"><span data-stu-id="ab456-223">Suspend/resume PLM handling</span></span>

<span data-ttu-id="ab456-224">一時停止と再開、および PLM 全般は、ユニバーサル Windows アプリでも Xbox One と同様に動作します。ただし、留意すべきいくつかの重要な相違点があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-224">Suspend and resume, and PLM in general, work similarly in a Universal Windows app to the way they work on Xbox One; however, there are a few important differences to keep in mind:</span></span>

-   <span data-ttu-id="ab456-225">PC には **Constrained** 状態はありません。これは Xbox One 限定の概念です。</span><span class="sxs-lookup"><span data-stu-id="ab456-225">There is no **Constrained** state on the PC—this is an Xbox One exclusive concept.</span></span>

-   <span data-ttu-id="ab456-226">一時停止は、タイトルが最小化されると直ちに始まります。これを回避する方法については、「[拡張実行](#_Extended_execution)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-226">Suspending begins immediately when the title is minimized; for a way around this, see the section [Extended execution](#_Extended_execution).</span></span>

-   <span data-ttu-id="ab456-227">タイミングが異なります。一時停止するまで、本体では 1 秒ですが、PC では 5 秒あります。</span><span class="sxs-lookup"><span data-stu-id="ab456-227">The timing is different: you have 5 seconds to suspend on a PC instead of the 1 second on the console.</span></span>

<span data-ttu-id="ab456-228">接続ストレージを使用する場合の別の重要な考慮事項は、UWP バージョンのこの API に含まれる新しい **ContainersChangedSinceLastSync** プロパティです。</span><span class="sxs-lookup"><span data-stu-id="ab456-228">Another important consideration if you use connected storage is the new **ContainersChangedSinceLastSync** property in the UWP version of this API.</span></span> <span data-ttu-id="ab456-229">再開イベントを処理するときには、このプロパティをチェックして、タイトルの一時停止中にコンテナーがクラウドで変更されたかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="ab456-229">When handling a resume event, you can check this property to see if any containers changed in the cloud while your title was suspended.</span></span> <span data-ttu-id="ab456-230">これは、プレイヤーが 1 つの PC でゲームを一時停止し、別の場所でプレイしてから最初の PC に戻った場合に起きることがあります。</span><span class="sxs-lookup"><span data-stu-id="ab456-230">This can happen if the player suspended the game on one PC, played elsewhere, and then returned to the first PC.</span></span> <span data-ttu-id="ab456-231">一時停止する前にこれらのコンテナーからメモリーにデータを読み込んだ場合は、おそらく、それらを再度読み込んで何が変化したかを確認し、それに応じて変更に対処する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-231">If you had read data from these containers into memory before you had suspended, you probably want to read them again to see what changed and handle the changes accordingly.</span></span>

<span data-ttu-id="ab456-232">Windows 10 における UWP アプリでの PLM 処理の詳細については、MSDN のホワイトペーパー「[起動、再開、バックグラウンド タスク](https://msdn.microsoft.com/library/windows/apps/xaml/mt227652.aspx)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-232">For more information about handling PLM in a UWP app on Windows 10, see the MSDN article [Launching, resuming, and background tasks](https://msdn.microsoft.com/library/windows/apps/xaml/mt227652.aspx).</span></span>

<span data-ttu-id="ab456-233">ゲームを念頭に置いて記述されていて、アプリのライフサイクルの処理に関する概念の大半は PC にも当てはまるため、GDN のホワイト ペーパー「[Xbox One の PLM](https://developer.xboxlive.com/en-us/platform/development/education/Documents/PLM%20for%20Xbox%20One.aspx)」も役立つ場合があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-233">You may also find the [PLM for Xbox One](https://developer.xboxlive.com/en-us/platform/development/education/Documents/PLM%20for%20Xbox%20One.aspx) white paper on GDN useful because it was written with games in mind, and most of the concepts for handling the app lifecycle still apply on a PC.</span></span>

<a name="_Extended_execution"></a>

### <a name="extended-execution"></a><span data-ttu-id="ab456-234">拡張実行</span><span class="sxs-lookup"><span data-stu-id="ab456-234">Extended execution</span></span>

<span data-ttu-id="ab456-235">PC 上で UWP アプリを最小化すると、すぐに一時停止が始まります。</span><span class="sxs-lookup"><span data-stu-id="ab456-235">Minimizing a UWP app on a PC typically results in it immediately starting to suspend.</span></span> <span data-ttu-id="ab456-236">拡張実行を使用することによって、この処理を遅らせる機会が得られます。</span><span class="sxs-lookup"><span data-stu-id="ab456-236">By using extended execution, you have the opportunity to delay this process.</span></span> <span data-ttu-id="ab456-237">実装例:</span><span class="sxs-lookup"><span data-stu-id="ab456-237">Example implementation:</span></span>

```cpp
using namespace Windows::ApplicationModel::ExtendedExecution;
//If this goes out of scope the request is nullified
ExtendedExecutionSession^ session;
void App::RequestExtension()
{
       if (!session)
       {
              session = ref new ExtendedExecutionSession();
       }
       session->Reason = ExtendedExecutionReason::Unspecified;
       session->Description = "foo";
       session->Revoked += ref new TypedEventHandler<Platform::Object^, ExtendedExecutionRevokedEventArgs^>(this, &App::ExtensionRevokedHandler);
       IAsyncOperation<ExtendedExecutionResult>^ request = session->RequestExtensionAsync();
       //At this point the request has been made. When the IAsyncOperation request completes, verify that the ExtendedExecutionResult == Allowed and you will not suspend for up to 10 minutes while minimized.
}

void App::ExtensionRevokedHandler(Platform::Object^ obj, ExtendedExecutionRevokedEventArgs^ args)
{
       if (args->Reason == Windows::ApplicationModel::ExtendedExecutionRevokedReason::Resumed)
       {
              //Request the extension again in preparation for the next suspend.
RequestExtension();
       }
       //The app will either complete suspending if the extension was revoked by system policy or resume running if the user has switched back to the app.
}

```

<span data-ttu-id="ab456-238">**ExtensionRevokedHandler** が呼び出された後は、その後一時停止が起きる場合に備えて新しい拡張機能が必要です。</span><span class="sxs-lookup"><span data-stu-id="ab456-238">After the **ExtensionRevokedHandler** has been called, a new extension needs to be requested for future potential suspensions.</span></span> <span data-ttu-id="ab456-239">システム内にメモリー負荷があり、10 分が経過するか、ゲームが最小化されているときにユーザーがゲームに戻ると、**ExtensionRevokedHandler** が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="ab456-239">The **ExtensionRevokedHandler** is called when there is memory pressure in the system, 10 minutes have elapsed, or the user switches back to the game while the game is minimized.</span></span> <span data-ttu-id="ab456-240">そのため、おそらく以下のときに **RequestExtension()** を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-240">So **RequestExtension()** should likely be called at these times:</span></span>

-   <span data-ttu-id="ab456-241">起動時。</span><span class="sxs-lookup"><span data-stu-id="ab456-241">During startup.</span></span>

-   <span data-ttu-id="ab456-242">args-&gt;Reason == Resumed のときに **ExtensionRevokedHandler** 内で (ゲームが最小化されていて、10 分のタイマーが期限切れになる前にユーザーがタブで戻った)。</span><span class="sxs-lookup"><span data-stu-id="ab456-242">In the **ExtensionRevokedHandler** when args-&gt;Reason == Resumed (the user tabbed back while the game was minimized before the 10-minute timer expired).</span></span>

-   <span data-ttu-id="ab456-243">**OnResuming** ハンドラー内で (メモリー負荷または 10 分のタイマーのためにタイトルが一時停止された場合)。</span><span class="sxs-lookup"><span data-stu-id="ab456-243">In the **OnResuming** handler (if the title was suspended due to memory pressure or the 10-minute timer).</span></span>

### <a name="handling-users-and-controllers"></a><span data-ttu-id="ab456-244">ユーザーとコントローラーの処理</span><span class="sxs-lookup"><span data-stu-id="ab456-244">Handling users and controllers</span></span>

<span data-ttu-id="ab456-245">Windows では、一度に 1 人のサインイン ユーザーを扱います。</span><span class="sxs-lookup"><span data-stu-id="ab456-245">On Windows, you work with one signed-in user at a time.</span></span> <span data-ttu-id="ab456-246">Xbox Live SDK では、まず **XboxLiveUser** オブジェクトを作成し、それらを Xbox Live にサインインした後に、このユーザーから **XboxLiveContext** オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="ab456-246">In the Xbox Live SDK, you first create an **XboxLiveUser** object, sign them in to Xbox Live, and then create **XboxLiveContext** objects from this user.</span></span>

<span data-ttu-id="ab456-247">以前は、Xbox One XDK で次のようにしました。</span><span class="sxs-lookup"><span data-stu-id="ab456-247">Before, on the Xbox One XDK:</span></span>

1.  <span data-ttu-id="ab456-248">ユーザーを取得します (たとえばゲームパッドの対話から)。</span><span class="sxs-lookup"><span data-stu-id="ab456-248">Acquire a user (from gamepad interaction, for example).</span></span>
2.  <span data-ttu-id="ab456-249">そのユーザーから **XboxLiveContext** を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab456-249">Create an **XboxLiveContext** from that user:</span></span>
  ```
  ref new Microsoft::Xbox::Services::XboxLiveContext( Windows::Xbox::System::User^ user )
  ```
1.  <span data-ttu-id="ab456-250">**SignOut** イベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="ab456-250">Handle a **SignOut** event:</span></span>
  ```
  Windows::Xbox::System::User::SignOutStarted
  ```
1.  <span data-ttu-id="ab456-251">次のコードを使用してゲームパッド/コントローラーのペアリングを処理します。</span><span class="sxs-lookup"><span data-stu-id="ab456-251">Handle gamepad/controller pairing using:</span></span>
  ```
  Windows::Xbox::Input::Controller::ControllerRemoved
  Windows::Xbox::Input::Controller::ControllerPairingChanged
  ```

<span data-ttu-id="ab456-252">今回、UWP/Xbox Live SDK については次のようにします。</span><span class="sxs-lookup"><span data-stu-id="ab456-252">Now, for the UWP/Xbox Live SDK:</span></span>

1.  <span data-ttu-id="ab456-253">**XboxLiveUser** を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab456-253">Create an **XboxLiveUser**:</span></span>

  ```
  auto xblUser = ref new Microsoft::Xbox::Services::System::XboxLiveUser();
  ```

1.  <span data-ttu-id="ab456-254">それらの UI 操作は行わずに、最後に使用された Microsoft アカウントを使用してサインインを試みます。</span><span class="sxs-lookup"><span data-stu-id="ab456-254">Try to sign them in by using the last Microsoft account they used, without bothering them with UI:</span></span>

  ```
  xblUser->SignInSilentlyAsync();
  ```

1.  <span data-ttu-id="ab456-255">この非同期操作の結果内で **SignInResult::Success** を取得したら、**XboxLiveContext** を作成し、終了します。</span><span class="sxs-lookup"><span data-stu-id="ab456-255">If you get **SignInResult::Success** in the result from this async operation, create the **XboxLiveContext**, and then you're finished:</span></span>

  ```
  auto xblContext = ref new Microsoft::Xbox::Services::XboxLiveContext( xblUser );
  ```

1.  <span data-ttu-id="ab456-256">代わりに **SignInResult::UserInteractionRequired** が返された場合は、システム UI を表示させる対話型のサインイン メソッドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-256">If instead you get **SignInResult::UserInteractionRequired**, you need to call the interactive sign-in method that brings up system UI:</span></span>

  ```
  xblUser->SignInAsync();
  ```

1.  <span data-ttu-id="ab456-257">ここから **SignInResult::UserCancel** が返されることがあります。この場合、サインインしたユーザーがいないので、再度サインインを試みられるようにメニュー オプションを提供することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-257">From here you may get **SignInResult::UserCancel**, in which case you don't have a signed-in user and you should consider providing a menu option for them to try signing in again.</span></span>

  <span data-ttu-id="ab456-258">**注** メニュー オプションを提供する場合は、異なる Microsoft アカウントに切り替えるオプションを提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ab456-258">**Note** When providing menu options, it's a good idea to give them the option to switch to a different Microsoft account:</span></span>

  ```
  xblUser->SwitchAccountAsync( nullptr );
  ```

1.  <span data-ttu-id="ab456-259">サインインしたユーザーがいる状態になったら、ユーザーのサインアウトに対応できるように **XboxLiveUser::SignOutCompleted** イベントをフックすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ab456-259">After you have a signed-in user, you may want to hook up the **XboxLiveUser::SignOutCompleted** event so that you can react to the user signing out:</span></span>

  ```
  xblUser->SignOutCompleted += ref new Windows::Foundation::EventHandler<Microsoft::Xbox::Services::System::SignOutCompletedEventArgs^>( &OnSignOutCompleted );
  ```

1.  <span data-ttu-id="ab456-260">Windows 10 で処理するコントローラーのペアリングはありません。</span><span class="sxs-lookup"><span data-stu-id="ab456-260">There is no controller pairing to handle in Windows 10.</span></span>

<span data-ttu-id="ab456-261">これは、C++/WinRT 向けに単純化した例です。</span><span class="sxs-lookup"><span data-stu-id="ab456-261">This is a simplified example for C++ / WinRT.</span></span> <span data-ttu-id="ab456-262">詳細な例については、『Xbox Live プログラミング ガイド』の「Xbox Live Authentication in Windows 10」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-262">For a more detailed example, see "Xbox Live Authentication in Windows 10" in the Xbox Live Programming Guide.</span></span> <span data-ttu-id="ab456-263">より幅広い例が紹介されている「Adding Xbox Live to a new UWP project」も役立つ可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-263">You may also find the broader example at "Adding Xbox Live to a new UWP project" helpful.</span></span>

### <a name="checking-multiplayer-privileges"></a><span data-ttu-id="ab456-264">マルチプレイヤー権限の確認</span><span class="sxs-lookup"><span data-stu-id="ab456-264">Checking multiplayer privileges</span></span>

<span data-ttu-id="ab456-265">Xbox Live SDK で、**CheckPrivilegeAsync()** と同等のものはまだ利用できません。</span><span class="sxs-lookup"><span data-stu-id="ab456-265">The equivalent to **CheckPrivilegeAsync()** is not yet available in the Xbox Live SDK.</span></span> <span data-ttu-id="ab456-266">現在のところ、**XboxLiveUser** の **Privileges** プロパティで返される文字列リストで、必要な権限を検索する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-266">For now, you will need to search for the privilege you need in the string list returned by the **Privileges** property for an **XboxLiveUser**.</span></span> <span data-ttu-id="ab456-267">たとえば、マルチプレイヤー権限を確認するには、権限 "254" を探します。</span><span class="sxs-lookup"><span data-stu-id="ab456-267">For example, to check for multiplayer privileges, look for privilege "254."</span></span> <span data-ttu-id="ab456-268">XDK ドキュメントを参考に、**Windows::Xbox::ApplicationModel::Store::KnownPrivileges** 列挙型で返されるすべての Xbox Live 権限のリストを確認できます。</span><span class="sxs-lookup"><span data-stu-id="ab456-268">Using the XDK documentation, you can find a list of all the Xbox Live privileges in the **Windows::Xbox::ApplicationModel::Store::KnownPrivileges** enumeration.</span></span>

<span data-ttu-id="ab456-269">このトピックに関する議論については、[xsapi とユーザー権限](https://forums.xboxlive.com/questions/48513/xsapi-user-privileges.html)についてのフォーラムの投稿を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-269">For a discussion on this topic, see the forum post [xsapi & user privileges](https://forums.xboxlive.com/questions/48513/xsapi-user-privileges.html).</span></span>

<a name="_Supporting_multiplayer_cross-play"></a>

### <a name="supporting-multiplayer-cross-play-between-xbox-one-and-pc-uwp"></a><span data-ttu-id="ab456-270">Xbox One および PC UWP の間のマルチプレイヤー クロスプレイのサポート</span><span class="sxs-lookup"><span data-stu-id="ab456-270">Supporting multiplayer cross-play between Xbox One and PC UWP</span></span>

<span data-ttu-id="ab456-271">XDP で新しいセッション テンプレートの要件に加えて ([を設定しパートナー センターおよび XDP でプロジェクトを構成する](#_Setting_up_and)を参照)、クロス プレイのセッションへの参加機能に新しい制限が付属します。</span><span class="sxs-lookup"><span data-stu-id="ab456-271">In addition to new session template requirements in XDP (see [Setting up and configuring your project in Partner Center and XDP](#_Setting_up_and)), cross-play comes with new restrictions on session join ability.</span></span> <span data-ttu-id="ab456-272">セッションへの参加制限として "None" を使用できなくなりました。</span><span class="sxs-lookup"><span data-stu-id="ab456-272">You can no longer use "None" as a session join restriction.</span></span> <span data-ttu-id="ab456-273">"Followed" または "Local" のいずれかを使用する必要があります (既定の制限は "Local")。</span><span class="sxs-lookup"><span data-stu-id="ab456-273">You must use either "Followed" or "Local" (the default restriction is "Local").</span></span>

<span data-ttu-id="ab456-274">また、Windows 10 でのマルチプレイヤーに必要な **userAuthorizationStyle** 機能のために、参加と読み取りの制限は既定で "Local" になります。</span><span class="sxs-lookup"><span data-stu-id="ab456-274">Also, the join and read restrictions default to "Local" because of the required **userAuthorizationStyle** capability for Windows 10 multiplayer.</span></span>

<span data-ttu-id="ab456-275">このフォーラムのホワイトペーパー「[Is it possible to create a public multiplayer session](https://forums.xboxlive.com/questions/46781/is-it-possible-to-create-public-multiplayer-sessio.html)」には、さらに詳しい情報が記載されています。</span><span class="sxs-lookup"><span data-stu-id="ab456-275">This forum article, [Is it possible to create a public multiplayer session](https://forums.xboxlive.com/questions/46781/is-it-possible-to-create-public-multiplayer-sessio.html), contains additional insight.</span></span>

<span data-ttu-id="ab456-276">さらに詳しい情報や例については、更新されたマルチプレイヤー デベロッパーのフローチャート、クロス プレイ対応マルチプレイヤーのサンプル NetRumble、または担当のデベロッパー アカウント マネージャー (DAM) から入手できます。</span><span class="sxs-lookup"><span data-stu-id="ab456-276">Further information and examples can be found in the updated multiplayer developer flowcharts, the cross-play-enabled multiplayer sample NetRumble, or from your Developer Account Manager (DAM).</span></span>

<a name="_Sending_and_receiving"></a>

### <a name="sending-and-receiving-invites"></a><span data-ttu-id="ab456-277">招待の送受信</span><span class="sxs-lookup"><span data-stu-id="ab456-277">Sending and receiving invites</span></span>

<span data-ttu-id="ab456-278">現在では、招待を送信するための UI を表示する API は **Microsoft::Xbox::Services::System::TitleCallableUI::ShowGameInviteUIAsync()** です。</span><span class="sxs-lookup"><span data-stu-id="ab456-278">The API to bring up the UI for sending invites is now **Microsoft::Xbox::Services::System::TitleCallableUI::ShowGameInviteUIAsync()**.</span></span> <span data-ttu-id="ab456-279">アクティビティ セッション (通常はロビー) の、セッション-&gt; **SessionReference** オブジェクトを渡します。</span><span class="sxs-lookup"><span data-stu-id="ab456-279">You pass in a session-&gt; **SessionReference** object from your activity session (typically your lobby).</span></span> <span data-ttu-id="ab456-280">必要に応じて、XDP のサービス構成で定義されたカスタムの招待文字列 ID を参照する 2 番目のパラメーターを渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="ab456-280">You can optionally pass in a second parameter that references a custom invite string ID that's been defined in your service configuration in XDP.</span></span> <span data-ttu-id="ab456-281">そこで定義する文字列は、招待されたプレイヤーに送信されるトースト通知内に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ab456-281">The string you define there will appear in the toast notification sent to the invited players.</span></span> <span data-ttu-id="ab456-282">このメソッドのパラメーターとして ID 番号を渡すときには、番号がそのサービスにとって適切な形式になっている必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-282">Note that what you are passing in as a parameter to this method is the ID number, and it must be formatted properly for the service.</span></span> <span data-ttu-id="ab456-283">たとえば、文字列 ID "1" は "///1" として渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-283">For example, string ID "1" must be passed in as "///1".</span></span>

<span data-ttu-id="ab456-284">マルチプレイヤー サービスを使用して (つまり、どの UI も表示せずに) 招待を直接送信する場合でも、ユーザーの **XboxLiveContext** から他の招待メソッド **Microsoft::Xbox::Services::Multiplayer::MultiplayerService::SendInvitesAsync()** を使用することができます。</span><span class="sxs-lookup"><span data-stu-id="ab456-284">If you want to send invites directly by using the multiplayer service (that is, without showing any UI), you can still use the other invite method, **Microsoft::Xbox::Services::Multiplayer::MultiplayerService::SendInvitesAsync()** from the user's **XboxLiveContext**.</span></span>

<span data-ttu-id="ab456-285">招待が Windows に到着してプロトコルでタイトルをアクティベーションできるようにするには、appxmanifest で、次の拡張機能を **&lt;Application&gt;** 要素に追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-285">To allow for invites coming into Windows to protocol-activate your title, you need to add this extension to the **&lt;Application&gt;** element in the appxmanifest:</span></span>

```xml
<Extensions>
  <uap:Extension Category="windows.protocol">
    <uap:Protocol Name="ms-xbl-multiplayer" />
  </uap:Extension>
</Extensions>
```

<span data-ttu-id="ab456-286">**CoreApplication** が **Activated** イベントを取得し、アクティベーションの種類が **ActivationKind::Protocol** であれば、以前に Xbox One で行ったように招待を処理することができます。</span><span class="sxs-lookup"><span data-stu-id="ab456-286">You can then handle the invite as you did before on Xbox One when your **CoreApplication** gets an **Activated** event and the activation Kind is an **ActivationKind::Protocol**.</span></span>

### <a name="showing-the-gamer-profile-card"></a><span data-ttu-id="ab456-287">ゲーマー プロフィール カードの表示</span><span class="sxs-lookup"><span data-stu-id="ab456-287">Showing the gamer profile card</span></span>

<span data-ttu-id="ab456-288">UWP 上にゲーマー プロフィール カードを表示するには、**Microsoft::Xbox::Services::System::TitleCallableUI::ShowProfileCardUIAsync()** を使用して、ターゲット ユーザーの XUID を渡します。</span><span class="sxs-lookup"><span data-stu-id="ab456-288">To pop up the gamer profile card on UWP, use **Microsoft::Xbox::Services::System::TitleCallableUI::ShowProfileCardUIAsync()**, passing in the XUID for the target user.</span></span>

<a name="_Secure_sockets"></a>

### <a name="secure-sockets"></a><span data-ttu-id="ab456-289">セキュア ソケット</span><span class="sxs-lookup"><span data-stu-id="ab456-289">Secure sockets</span></span>

<span data-ttu-id="ab456-290">セキュア ソケット API は、別の [Xbox Live Platform Extensions SDK](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx) に含まれています。</span><span class="sxs-lookup"><span data-stu-id="ab456-290">The Secure Socket API is included in the separate [Xbox Live Platform Extensions SDK](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx).</span></span>

<span data-ttu-id="ab456-291">API の使い方については、フォーラムの投稿「[Setting up SecureDeviceAssociation for cross platform](https://forums.xboxlive.com/answers/45722/view.html)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-291">See this forum post for API usage: [Setting up SecureDeviceAssociation for cross platform](https://forums.xboxlive.com/answers/45722/view.html).</span></span>

<span data-ttu-id="ab456-292">**注** UWP では、**SocketDescriptions** セクションが、appxmanifest の外部の、独自の [networkmanifest.xml](https://forums.xboxlive.com/storage/attachments/410-networkmanifestxml.txt) に移動されました。</span><span class="sxs-lookup"><span data-stu-id="ab456-292">**Note** For UWP, the **SocketDescriptions** section has moved out of the appxmanifest and into its own [networkmanifest.xml](https://forums.xboxlive.com/storage/attachments/410-networkmanifestxml.txt).</span></span> <span data-ttu-id="ab456-293">&lt;SocketDescriptions&gt; 要素内の形式は、ほぼ同じで、**mx:** プレフィックスがないだけです。</span><span class="sxs-lookup"><span data-stu-id="ab456-293">The format inside the &lt;SocketDescriptions&gt; element is virtually identical, just without the **mx:** prefix.</span></span>

<span data-ttu-id="ab456-294">Xbox および Windows 10 間のクロスプレイについては、2 種類のマニフェスト (Xbox One の Package.appxmanifest と Windows 10 の networkmanifest.xml) で、すべてが*まったく同じ*に定義されていることを*確認*してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-294">For cross-play between Xbox and Windows 10, be *sure* that everything is defined *identically* between the two different kinds of manifests (Package.appxmanifest for Xbox One and networkmanifest.xml for Windows 10).</span></span> <span data-ttu-id="ab456-295">ソケット名、プロトコルなどが*正確に*一致している必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-295">The socket name, protocol, etc. must match *exactly*.</span></span>

<span data-ttu-id="ab456-296">クロスプレイの場合も、Xbox One の Package.appxmanifest と Windows 10 の networkmanifest.xml の*両方*で、```<AllowedUsages>``` 要素内に次の 4 つの SDA 使用法を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-296">Also for cross-play, you will need to define the following four SDA usages inside the ```<AllowedUsages>``` element in *both* the Xbox One Package.appxmanifest and the Windows 10 networkmanifest.xml:</span></span>

```xml
<SecureDeviceAssociationUsage Type="InitiateFromMicrosoftConsole" />
<SecureDeviceAssociationUsage Type="AcceptOnMicrosoftConsole" />
<SecureDeviceAssociationUsage Type="InitiateFromWindowsDesktop" />
<SecureDeviceAssociationUsage Type="AcceptOnWindowsDesktop" />
```

### <a name="multiplayer-qos-measurements"></a><span data-ttu-id="ab456-297">マルチプレイヤー QoS の測定</span><span class="sxs-lookup"><span data-stu-id="ab456-297">Multiplayer QoS measurements</span></span>

<span data-ttu-id="ab456-298">セキュア ソケット API における名前空間の変更に加えて、オブジェクトの名前と値の一部も変更されています。</span><span class="sxs-lookup"><span data-stu-id="ab456-298">In addition to the namespace change in the Secure Sockets API, some of the object names and values have changed, too.</span></span> <span data-ttu-id="ab456-299">次の表に、よく使用される測定ステータスのマッピングを示します。</span><span class="sxs-lookup"><span data-stu-id="ab456-299">The mapping for the typically-used measurement status is found in the following table.</span></span>

<span data-ttu-id="ab456-300">表 2: </span><span class="sxs-lookup"><span data-stu-id="ab456-300">Table 2.</span></span> <span data-ttu-id="ab456-301">よく使用される測定ステータスのマッピング</span><span class="sxs-lookup"><span data-stu-id="ab456-301">Typically used measurement status mapping.</span></span>

| <span data-ttu-id="ab456-302">XDK (Windows::Xbox::Networking::QualityOfServiceMeasurementStatus)</span><span class="sxs-lookup"><span data-stu-id="ab456-302">XDK (Windows::Xbox::Networking::QualityOfServiceMeasurementStatus)</span></span>  | <span data-ttu-id="ab456-303">UWP (Windows::Networking::XboxLive::XboxLiveQualityOfServiceMeasurementStatus)</span><span class="sxs-lookup"><span data-stu-id="ab456-303">UWP (Windows::Networking::XboxLive::XboxLiveQualityOfServiceMeasurementStatus)</span></span>  |
|------------------------------------|--------------------------------------------|
| <span data-ttu-id="ab456-304">HostUnreachable</span><span class="sxs-lookup"><span data-stu-id="ab456-304">HostUnreachable</span></span>                    | <span data-ttu-id="ab456-305">NoCompatibleNetworkPaths</span><span class="sxs-lookup"><span data-stu-id="ab456-305">NoCompatibleNetworkPaths</span></span>                   |
| <span data-ttu-id="ab456-306">MeasurementTimedOut</span><span class="sxs-lookup"><span data-stu-id="ab456-306">MeasurementTimedOut</span></span>                | <span data-ttu-id="ab456-307">TimedOut</span><span class="sxs-lookup"><span data-stu-id="ab456-307">TimedOut</span></span>                                   |
| <span data-ttu-id="ab456-308">PartialResults</span><span class="sxs-lookup"><span data-stu-id="ab456-308">PartialResults</span></span>                     | <span data-ttu-id="ab456-309">InProgressWithProvisionalResults</span><span class="sxs-lookup"><span data-stu-id="ab456-309">InProgressWithProvisionalResults</span></span>           |
| <span data-ttu-id="ab456-310">Success</span><span class="sxs-lookup"><span data-stu-id="ab456-310">Success</span></span>                            | <span data-ttu-id="ab456-311">Succeeded</span><span class="sxs-lookup"><span data-stu-id="ab456-311">Succeeded</span></span>                                  |

<span data-ttu-id="ab456-312">QoS (サービスの品質) の*測定*と*結果の処理*に必要な手順は、API の XDK バージョンと UWP バージョンを比較すると、基本的に同じです。</span><span class="sxs-lookup"><span data-stu-id="ab456-312">The steps involved in *measuring* QoS (quality of service) and *processing the results* are in principle the same when you compare the XDK and UWP versions of the API.</span></span> <span data-ttu-id="ab456-313">ただし、名前の変更といくつかの設計変更のために、一部の場所では結果のコードが異なってきます。</span><span class="sxs-lookup"><span data-stu-id="ab456-313">However, due to the name changes and a few design changes, the resulting code looks different in some places.</span></span>

<span data-ttu-id="ab456-314">**XDK** のために QoS を測定する場合、セキュア デバイス アドレスのコレクションとメトリックのコレクションを作成し、それらを **MeasureQualityOfServiceAsync()** メソッドに渡していました。</span><span class="sxs-lookup"><span data-stu-id="ab456-314">To measure the QoS for the **XDK**, you created a collection of secure device addresses and a collection of metrics and passed these into the **MeasureQualityOfServiceAsync()** method.</span></span>

<span data-ttu-id="ab456-315">**UWP** のために QoS を測定するには、新しい **XboxLiveQualityOfServiceMeasurement()** オブジェクトを作成し、その **Metrics** プロパティと **DeviceAddresses** プロパティに対して **Append()** を呼び出してから、オブジェクトの **MeasureAsync()** メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ab456-315">To measure the QoS for **UWP**, you create a new **XboxLiveQualityOfServiceMeasurement()** object, call **Append()** to its **Metrics** and **DeviceAddresses** properties, and then call the object's **MeasureAsync()** method.</span></span>

<span data-ttu-id="ab456-316">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ab456-316">For example:</span></span>

```cpp
auto qosMeasurement = ref new Windows::Networking::XboxLive::XboxLiveQualityOfServiceMeasurement();
qosMeasurement->Metrics->Append(Windows::Networking::XboxLive::XboxLiveQualityOfServiceMetric::AverageInboundBitsPerSecond);
qosMeasurement->Metrics->Append(Windows::Networking::XboxLive::XboxLiveQualityOfServiceMetric::AverageOutboundBitsPerSecond);
qosMeasurement->Metrics->Append(Windows::Networking::XboxLive::XboxLiveQualityOfServiceMetric::AverageLatencyInMilliseconds);
qosMeasurement->NumberOfProbesToAttempt = myDefaultQosProbeCount;
qosMeasurement->TimeoutInMilliseconds = myDefaultQosMeasurementTimeout;

// Add secure addresses for each session member
for (const auto& member : session->GetMembers())
{
    if (!member->IsCurrentUser)
    {
        auto sda = member->SecureDeviceAddressBase64;

        if (!sda->IsEmpty())
        {
qosMeasurement->DeviceAddresses->Append(Windows::Networking::XboxLive::XboxLiveDeviceAddress::CreateFromSnapshotBase64(sda));
        }
    }
}

if (qosMeasurement->DeviceAddresses->Size > 0)
{
    qosMeasurement->MeasureAsync();
}

```

<span data-ttu-id="ab456-317">詳細な例については、NetRumble サンプルの **MatchmakingSession::MeasureQualityOfService()** 関数と **MatchmakingSession::ProcessQosMeasurements()** 関数を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-317">For more examples, see the **MatchmakingSession::MeasureQualityOfService()** and **MatchmakingSession::ProcessQosMeasurements()** functions in the NetRumble sample.</span></span>

### <a name="writing-game-events"></a><span data-ttu-id="ab456-318">ゲーム イベントの書き込み</span><span class="sxs-lookup"><span data-stu-id="ab456-318">Writing game events</span></span>

<span data-ttu-id="ab456-319">タイトルのサービス構成で構成されたゲーム イベントを送信する場合、UWP には異なる API があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-319">Sending game events that are configured in your title's Service Configuration has a different API in UWP.</span></span> <span data-ttu-id="ab456-320">Xbox Live SDK は、**EventsService** とプロパティ バッグ モデルを使用します。</span><span class="sxs-lookup"><span data-stu-id="ab456-320">The Xbox Live SDK uses the **EventsService** and a property bag model.</span></span>

<span data-ttu-id="ab456-321">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ab456-321">For example:</span></span>

```cpp
auto properties = ref new Windows::Foundation::Collections::PropertySet();
properties->Insert("RoundId", m_roundId);
properties->Insert("SectionId", safe_cast<Platform::Object^>(0));
properties->Insert("MultiplayerCorrelationId", m_multiplayerCorrelationId);
properties->Insert("GameplayModeId", safe_cast<Platform::Object^>(0));
properties->Insert("MatchTypeId", safe_cast<Platform::Object^>(0));
properties->Insert("DifficultyLevelId", safe_cast<Platform::Object^>(0));

auto measurements = ref new Windows::Foundation::Collections::PropertySet();

xblContext->EventsService->WriteInGameEvent("MultiplayerRoundStart", properties, measurements);

```

<span data-ttu-id="ab456-322">詳細については、Xbox Live SDK のドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-322">For more information, see the Xbox Live SDK documentation.</span></span>

<span data-ttu-id="ab456-323">**ヒント** Xbox Live SDK (Tools ディレクトリにあります) で提供される **xcetool.exe** を使用して、XDP からダウンロードした events.man ファイルを .h ヘッダー ファイルに変換することができます。</span><span class="sxs-lookup"><span data-stu-id="ab456-323">**Tip** You can use the **xcetool.exe** provided with the Xbox Live SDK (located in the Tools directory) to convert the events.man file that you downloaded from XDP into a .h header file.</span></span> <span data-ttu-id="ab456-324">新しい v2 プロパティ バッグ スキーマを使用してこの C++ ヘッダーを生成するには、'-x' オプションを使用します。</span><span class="sxs-lookup"><span data-stu-id="ab456-324">Use the '-x' option to generate this C++ header by using the new v2 property bag schema.</span></span> <span data-ttu-id="ab456-325">このヘッダーには、構成済みのイベントすべてに対して呼び出すことができる、**EventWriteMultiplayerRoundStart()** などの C++ 関数が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ab456-325">This header contains C++ functions that you can call for all of your configured events; for example, **EventWriteMultiplayerRoundStart()**.</span></span> <span data-ttu-id="ab456-326">WinRT インターフェイスを優先的に使用する場合でも、このヘッダー ファイルを参照して、それぞれのイベントに対してプロパティと測定がどのように構築されているかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="ab456-326">If you prefer to use a WinRT interface, you can still refer to this header file to see how the properties and measurements are constructed for each of your events.</span></span>

### <a name="game-chat"></a><span data-ttu-id="ab456-327">ゲーム チャット</span><span class="sxs-lookup"><span data-stu-id="ab456-327">Game chat</span></span>

<span data-ttu-id="ab456-328">UWP での GameChat は、Xbox Live SDK に NuGet パッケージ バイナリとして含まれています。</span><span class="sxs-lookup"><span data-stu-id="ab456-328">GameChat in UWP is included with the Xbox Live SDK as a NuGet package binary.</span></span> <span data-ttu-id="ab456-329">この NuGet パッケージをプロジェクトに追加する方法については、『Xbox Live プログラミング ガイド』の手順を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-329">See instructions in the Xbox Live Programming Guide for how to add this NuGet package to your project.</span></span>

<span data-ttu-id="ab456-330">基本的な使用方法は、XDK バージョンと UWP バージョンでほとんど同じです。</span><span class="sxs-lookup"><span data-stu-id="ab456-330">Basic usage is virtually identical between the XDK and the UWP versions.</span></span> <span data-ttu-id="ab456-331">API のいくつかの違いとしては、以下があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-331">A few differences in the API include:</span></span>

1.  <span data-ttu-id="ab456-332">**User::AudioDeviceAdded** イベントは、UWP タイトルによってフックされる必要はありません。</span><span class="sxs-lookup"><span data-stu-id="ab456-332">The **User::AudioDeviceAdded** event does not need to be hooked up by a UWP title.</span></span> <span data-ttu-id="ab456-333">基になっているチャット ライブラリーがデバイスの追加と削除を処理します。</span><span class="sxs-lookup"><span data-stu-id="ab456-333">The underlying chat library handles device adds and removes.</span></span>

2.  <span data-ttu-id="ab456-334">**ChatUser** は、**GameChatUser** と呼ばれるようになっています。</span><span class="sxs-lookup"><span data-stu-id="ab456-334">**ChatUser** is now called **GameChatUser**.</span></span>

3.  <span data-ttu-id="ab456-335">**Microsoft::Xbox::GameChat** 名前空間は同じままですが、**Windows::Xbox::Chat** 名前空間は **Microsoft::Xbox::ChatAudio** になっています。</span><span class="sxs-lookup"><span data-stu-id="ab456-335">**Microsoft::Xbox::GameChat** namespace remains the same, but the **Windows::Xbox::Chat** namespace has become **Microsoft::Xbox::ChatAudio**.</span></span>

4.  <span data-ttu-id="ab456-336">**AddLocalUserToChatChannelAsync()** は、**XboxUser** ではなく、XUID または **ChatAudio::IChatUser^** を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ab456-336">**AddLocalUserToChatChannelAsync()** takes either a XUID or a **ChatAudio::IChatUser^** instead of an **XboxUser**.</span></span>

5.  <span data-ttu-id="ab456-337">**RemoveLocalUserFromChatChannelAsync()** には、**XboxUser** ではなく **ChatAudio::IChatUser^** が必要です。</span><span class="sxs-lookup"><span data-stu-id="ab456-337">**RemoveLocalUserFromChatChannelAsync()** requires a **ChatAudio::IChatUser^** instead of an **XboxUser**.</span></span> <span data-ttu-id="ab456-338">**IChatUser** は、**GameChatUser**-&gt;**User** から取得できます。</span><span class="sxs-lookup"><span data-stu-id="ab456-338">You can get an **IChatUser** from a **GameChatUser**-&gt;**User**.</span></span>

### <a name="connected-storage"></a><span data-ttu-id="ab456-339">接続ストレージ</span><span class="sxs-lookup"><span data-stu-id="ab456-339">Connected storage</span></span>

<span data-ttu-id="ab456-340">接続ストレージ API は、別の [Xbox Live Platform Extensions SDK](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx) で提供されます。</span><span class="sxs-lookup"><span data-stu-id="ab456-340">The Connected Storage API is provided in the separate [Xbox Live Platform Extensions SDK](https://developer.xboxlive.com/en-us/live/development/Pages/Downloads.aspx).</span></span> <span data-ttu-id="ab456-341">ドキュメントは Xbox Live SDK ドキュメントに含まれています。</span><span class="sxs-lookup"><span data-stu-id="ab456-341">Documentation is included in the Xbox Live SDK docs.</span></span>

<span data-ttu-id="ab456-342">全体の流れは Xbox One での場合と同じですが、UWP バージョンには **ContainersChangedSinceLastSync** プロパティが追加されています。</span><span class="sxs-lookup"><span data-stu-id="ab456-342">The overall flow is the same as on Xbox One, with the addition of the **ContainersChangedSinceLastSync** property in the UWP version.</span></span> <span data-ttu-id="ab456-343">このプロパティは、タイトルが再開イベントを処理するとき、**GetForUserAsync()** をもう一度呼び出した後に、タイトルが一時停止されていた間にクラウドでどのコンテナーに変更があったかを確認するために調べる必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-343">This property should be checked when your title handles a resume event, after calling **GetForUserAsync()** again, to see what containers changed in the cloud while your title was suspended.</span></span> <span data-ttu-id="ab456-344">変更があったいずれかのコンテナーからメモリーにロードされたデータがある場合は、おそらく、データを再度読み込んで何が変わったかを確認し、それに応じて変更を処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab456-344">If you have data loaded in memory from one of the containers that changed, you probably want to read in the data again to see what changed and handle the changes accordingly.</span></span>

<span data-ttu-id="ab456-345">UWP バージョンでその他に注目すべき相違点には以下のものがあります。</span><span class="sxs-lookup"><span data-stu-id="ab456-345">Other notable differences in the UWP version include:</span></span>

1.  <span data-ttu-id="ab456-346">**Windows::Xbox::Storage** から **Windows::Gaming::XboxLive::Storage** への名前空間の変更。</span><span class="sxs-lookup"><span data-stu-id="ab456-346">Namespace change from **Windows::Xbox::Storage** to **Windows::Gaming::XboxLive::Storage**.</span></span>

2.  <span data-ttu-id="ab456-347">**ConnectedStorageSpace** は、**GameSaveProvider** に名前が変更されています。</span><span class="sxs-lookup"><span data-stu-id="ab456-347">**ConnectedStorageSpace** is renamed **GameSaveProvider**.</span></span>

3.  <span data-ttu-id="ab456-348">**GetForUserAsync()** では、**XboxUser** の代わりに **Windows::System::User** が使用され、SCID が必要になっています。</span><span class="sxs-lookup"><span data-stu-id="ab456-348">**Windows::System::User** is used in **GetForUserAsync()** instead of an **XboxUser**, and the SCID is now required.</span></span>

4.  <span data-ttu-id="ab456-349">ローカルの "マシン" ストレージはありません (つまり、**GetForMachineAsync()** が削除されました)。</span><span class="sxs-lookup"><span data-stu-id="ab456-349">No local "machine" storage (that is, **GetForMachineAsync()** has been removed).</span></span> <span data-ttu-id="ab456-350">ローミングされないローカル セーブ データの代わりに **Windows::Storage::ApplicationData** を使用することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-350">Consider using **Windows::Storage::ApplicationData** instead for your non-roaming, local save data.</span></span>

5.  <span data-ttu-id="ab456-351">例外が発生しない \*Result-type オブジェクト (たとえば **GameSaveProviderGetResult**) では非同期の結果が返されます。この結果から、**Status** プロパティをチェックできます。そしてエラーがない場合は、返されたオブジェクトを **Value** プロパティから読み込みます。</span><span class="sxs-lookup"><span data-stu-id="ab456-351">Async results are returned in an exception-free \*Result-type object (for example, **GameSaveProviderGetResult**); from this you can check the **Status** property, and if there is no error, read the returned object from the **Value** property.</span></span>

6.  <span data-ttu-id="ab456-352">**ConnectedStorageErrorStatus 列挙型**は **GameSaveErrorStatus** に名前が変更され、Result の **Status** プロパティで返されます。</span><span class="sxs-lookup"><span data-stu-id="ab456-352">**ConnectedStorageErrorStatus enum** is renamed **GameSaveErrorStatus** and is returned in the **Status** property of a Result.</span></span> <span data-ttu-id="ab456-353">古い値はすべて存在しており、新しい値がいくつか追加されています。</span><span class="sxs-lookup"><span data-stu-id="ab456-353">All the old values exist, and a few new ones have been added:</span></span>

-   <span data-ttu-id="ab456-354">中止</span><span class="sxs-lookup"><span data-stu-id="ab456-354">Abort</span></span>

-   <span data-ttu-id="ab456-355">ObjectExpired</span><span class="sxs-lookup"><span data-stu-id="ab456-355">ObjectExpired</span></span>

-   <span data-ttu-id="ab456-356">OK</span><span class="sxs-lookup"><span data-stu-id="ab456-356">Ok</span></span>

-   <span data-ttu-id="ab456-357">UserHasNoXboxLiveInfo</span><span class="sxs-lookup"><span data-stu-id="ab456-357">UserHasNoXboxLiveInfo</span></span>

<span data-ttu-id="ab456-358">使い方の例については、GameSave サンプルや NetRumble サンプルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="ab456-358">Refer to the GameSave sample or the NetRumble sample for example usage.</span></span>

<span data-ttu-id="ab456-359">**注** Gamesaveutil.exe は xbstorage.exe (XDK 付属のデベロッパー向けコマンド ライン ユーティリティ) と同等です。</span><span class="sxs-lookup"><span data-stu-id="ab456-359">**Note** Gamesaveutil.exe is the equivalent to xbstorage.exe (the command-line developer utility included with the XDK).</span></span> <span data-ttu-id="ab456-360">Xbox Live Platform Extensions SDK のインストール後、このユーティリティは C:\\Program Files (x86)\\Windows Kits\\10\\Extension SDKs\\XboxLive\\1.0\\Bin\\x64 にあります。</span><span class="sxs-lookup"><span data-stu-id="ab456-360">After installing the Xbox Live Platform Extensions SDK, this utility can be found here: C:\\Program Files (x86)\\Windows Kits\\10\\Extension SDKs\\XboxLive\\1.0\\Bin\\x64</span></span>

## <a name="summary"></a><span data-ttu-id="ab456-361">まとめ</span><span class="sxs-lookup"><span data-stu-id="ab456-361">Summary</span></span>

<span data-ttu-id="ab456-362">このホワイト ペーパーで概要を説明した API の変更と新しい要件は、既存のゲーム コードを Xbox One XDK から新しい UWP に移植するときにかかわる可能性が高いものです。</span><span class="sxs-lookup"><span data-stu-id="ab456-362">The API changes and new requirements outlined in this white paper are ones that you are likely to encounter when porting existing game code from the Xbox One XDK to the new UWP.</span></span> <span data-ttu-id="ab456-363">特に、アプリケーションと環境の設定に加えて、マルチプレイヤーや接続ストレージなど、Xbox Live サービスに関連する機能領域を重点的に取り上げました。</span><span class="sxs-lookup"><span data-stu-id="ab456-363">Particular emphasis has been given to application and environment setup, as well as feature areas related to Xbox Live services, such as multiplayer and connected storage.</span></span> <span data-ttu-id="ab456-364">詳細については、このホワイトペーパー全体を通して提供したリンクと、次の参考文献のリンクを利用してください。また、さらに多くの助け、疑問への答え、最新情報については、[デベロッパー フォーラム](https://forums.xboxlive.com)の「Windows 10」セクションにアクセスしてください。</span><span class="sxs-lookup"><span data-stu-id="ab456-364">For more information, follow the links provided throughout this article and in the following references, and be sure to visit the “Windows 10” section of the [developer forums](https://forums.xboxlive.com) for more help, answers, and news.</span></span>

## <a name="references"></a><span data-ttu-id="ab456-365">参考資料</span><span class="sxs-lookup"><span data-stu-id="ab456-365">References</span></span>

-   [<span data-ttu-id="ab456-366">Xbox One から Windows 10 への移植</span><span class="sxs-lookup"><span data-stu-id="ab456-366">Porting from Xbox One to Windows 10</span></span>](https://developer.xboxlive.com/en-us/platform/development/education/Documents/Porting%20from%20Xbox%20One%20to%20Windows%2010.aspx)

-   [<span data-ttu-id="ab456-367">Xbox One のホワイト ペーパー</span><span class="sxs-lookup"><span data-stu-id="ab456-367">Xbox One White Papers</span></span>](https://developer.xboxlive.com/en-us/platform/development/education/Pages/WhitePapers.aspx)

-   [<span data-ttu-id="ab456-368">サンプル</span><span class="sxs-lookup"><span data-stu-id="ab456-368">Samples</span></span>](https://developer.xboxlive.com/en-us/platform/development/education/Pages/Samples.aspx)
