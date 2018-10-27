---
title: XDK プロジェクトに Xbox Live を追加する
author: KevinAsgari
description: 新規または既存の Xbox 開発キット (XDK) プロジェクトに Xbox Live を追加する方法について説明します。
ms.assetid: fc6f987c-1a87-4ff5-b063-891591aa6653
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, XDK
ms.localizationpriority: medium
ms.openlocfilehash: 8b6821579e9ba96c679a6cace19e65645ae79455
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5708312"
---
# <a name="add-xbox-live-to-a-new-or-existing-xdk-project"></a><span data-ttu-id="04d73-104">新規または既存の XDK プロジェクトに Xbox Live を追加する</span><span class="sxs-lookup"><span data-stu-id="04d73-104">Add Xbox Live to a new or existing XDK project</span></span>

<span data-ttu-id="04d73-105">このトピックでは、新規または既存の XDK プロジェクトに Xbox Live を追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="04d73-105">This topic outlines how to add Xbox Live to a new or existing XDK project.</span></span>

<span data-ttu-id="04d73-106">手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="04d73-106">The process is:</span></span>

- <span data-ttu-id="04d73-107">Xbox One 開発環境をセットアップする</span><span class="sxs-lookup"><span data-stu-id="04d73-107">Setup Up Your Xbox One Development Environment</span></span>
- <span data-ttu-id="04d73-108">ID を取得する</span><span class="sxs-lookup"><span data-stu-id="04d73-108">Get your IDs</span></span>
- <span data-ttu-id="04d73-109">開発機本体を構成する</span><span class="sxs-lookup"><span data-stu-id="04d73-109">Configure your development console</span></span>
- <span data-ttu-id="04d73-110">タイトル ID と SCID をバイナリに追加する</span><span class="sxs-lookup"><span data-stu-id="04d73-110">Add the TitleID and SCID to your binary</span></span>


## <a name="setup-up-your-xbox-one-development-environment"></a><span data-ttu-id="04d73-111">Xbox One 開発環境をセットアップする</span><span class="sxs-lookup"><span data-stu-id="04d73-111">Setup Up Your Xbox One Development Environment</span></span>
<span data-ttu-id="04d73-112">最初に、XDK ドキュメントの「Xbox One 開発環境のセットアップ」セクションに従って本体をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="04d73-112">First, setup the console by following "Setting Up Your Xbox One Development Environment" section in the XDK documentation</span></span>

## <a name="get-your-ids"></a><span data-ttu-id="04d73-113">ID を取得する</span><span class="sxs-lookup"><span data-stu-id="04d73-113">Get your IDs</span></span>

<span data-ttu-id="04d73-114">Xbox Live サービスを有効にするには、開発キットとタイトルを構成するためのいくつかの ID を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="04d73-114">To enable Xbox Live services, you will need to obtain several IDs to configure your development kit and your title.</span></span> <span data-ttu-id="04d73-115">これらは同じプロセスで行うことができます。</span><span class="sxs-lookup"><span data-stu-id="04d73-115">These can be done with the same process.</span></span>

<span data-ttu-id="04d73-116">ID を取得するには、「[Xbox Live サービス構成](../xbox-live-service-configuration.md)」の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="04d73-116">You will obtain your IDs by doing the process of [Xbox Live service configuration](../xbox-live-service-configuration.md)</span></span>

## <a name="configure-your-development-console"></a><span data-ttu-id="04d73-117">開発機本体を構成する</span><span class="sxs-lookup"><span data-stu-id="04d73-117">Configure your development console</span></span>

<span data-ttu-id="04d73-118">ID を取得した後、「[開発本体を構成する](configure-your-development-console.md)」のガイドに従って開発本体をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="04d73-118">Once you have your IDs, follow the [Configure your development console](configure-your-development-console.md) guide to setup your development console.</span></span>

## <a name="add-the-titleid-and-scid-to-your-binary"></a><span data-ttu-id="04d73-119">タイトル ID と SCID をバイナリに追加する</span><span class="sxs-lookup"><span data-stu-id="04d73-119">Add the TitleID and SCID to your binary</span></span>
<span data-ttu-id="04d73-120">サンドボックスは開発キットごとにプラットフォーム レベルで構成されますが、タイトル ID と SCID は特定のバイナリにバインドされます。</span><span class="sxs-lookup"><span data-stu-id="04d73-120">While the Sandbox is configured on a platform level for each Development Kit, the TitleID and SCID are bound to a specific binary.</span></span> <span data-ttu-id="04d73-121">タイトル ID と SCID をバイナリに追加するには、次のように、<Extensions> ノードに新しいノードを追加して、そのバイナリの Package.appxmanifest を修正します。</span><span class="sxs-lookup"><span data-stu-id="04d73-121">To add a TitleID and SCID to your binary, modify the Package.appxmanifest for that binary by adding a new node in the <Extensions> node as follows:</span></span>

```
<Applications>
    ...
    <Application ...>
      ...
      <Extensions>
        <mx:Extension Category="xbox.live">
           <mx:XboxLive TitleId="<your titleID>" PrimaryServiceConfigId="<your SCID>" RequireXboxLive="<boolean indicating Live requirement>" />
        </mx:Extension>
      </Extensions>
   </Application>
</Applications>
```

<span data-ttu-id="04d73-122">AppxManifest.xml ファイルについて詳しくは、Visual Studio で Xbox One 開発用のプロジェクト テンプレートを参照してください。</span><span class="sxs-lookup"><span data-stu-id="04d73-122">For more information on the AppxManifest.xml file, refer to Project Templates in Visual Studio for Xbox One Development.</span></span>

<span data-ttu-id="04d73-123">アプリケーション マニフェスト スキーマについては、「アプリケーション マニフェスト スキーマ」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="04d73-123">See Application Manifest Schema for a description of the application manifest schema.</span></span>

<span data-ttu-id="04d73-124">**RequireXboxLive フラグ** RequireXboxLive フラグが true に設定されている場合は、Windows.Networking.Connectivity 接続レベルが XboxLiveAccess として返され、タイトルが Xbox Live の認証に合格しない限り、タイトルは起動しません。</span><span class="sxs-lookup"><span data-stu-id="04d73-124">**The RequireXboxLive Flag** If the RequireXboxLive flag is set to true, the title will not launch unless the Windows.Networking.Connectivity Connection Level returns as XboxLiveAccess and the title clears authentication with Xbox Live.</span></span> <span data-ttu-id="04d73-125">この認証により、タイトルが最新のコンテンツ アップデートを取得したことが保証されます。</span><span class="sxs-lookup"><span data-stu-id="04d73-125">This insures the title has taken the latest content updates.</span></span> <span data-ttu-id="04d73-126">タイトルの実行中に接続が失われた場合、タイトルは一時停止されます。</span><span class="sxs-lookup"><span data-stu-id="04d73-126">If connectivity is lost while the title is running, the title is suspended.</span></span>

<span data-ttu-id="04d73-127">"インターネットが必要" なタイトルのみが RequireXboxLive を true としてマークする必要があります。ただし、この方法でタイトルをマークしても、タイトルに必要なサービスが起動して稼働中であることは保証されないので、ご注意ください。</span><span class="sxs-lookup"><span data-stu-id="04d73-127">Only "Internet Required" titles should mark RequireXboxLive as true, and note that marking your title in this way does not guarantee the required services for the title are up and running.</span></span>
