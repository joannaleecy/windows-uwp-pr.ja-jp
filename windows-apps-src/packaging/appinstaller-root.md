---
author: laurenhughes
title: アプリ インストーラーで UWP アプリをインストールする
description: このセクションには、アプリ インストーラーに関する記事とアプリ インストーラーの機能を使用する方法に関する記事へのリンクが含まれています。
ms.author: lahugh
ms.date: 06/05/2018
ms.topic: article
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング, 関連セット, オプション パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: f3da1f4f393eea1362b6e59d2ad7e9a2a97bc33b
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7565956"
---
# <a name="install-uwp-apps-with-app-installer"></a><span data-ttu-id="3a2d7-104">アプリ インストーラーで UWP アプリをインストールする</span><span class="sxs-lookup"><span data-stu-id="3a2d7-104">Install UWP apps with App Installer</span></span>

## <a name="purpose"></a><span data-ttu-id="3a2d7-105">目的</span><span class="sxs-lookup"><span data-stu-id="3a2d7-105">Purpose</span></span>
<span data-ttu-id="3a2d7-106">このセクションには、アプリ インストーラーに関する記事とアプリ インストーラーの機能を使用する方法に関する記事へのリンクが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-106">This section contains or links to articles about App Installer and how to use the features of App Installer.</span></span> 

<span data-ttu-id="3a2d7-107">アプリ インストーラーを使用すると、アプリ パッケージをダブルクリックして UWP アプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-107">App Installer allows for UWP apps to be installed by double clicking the app package.</span></span> <span data-ttu-id="3a2d7-108">これは、ユーザーが UWP アプリを展開するために PowerShell またはその他の開発者ツールを使用する必要がないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-108">This means that users don't need to use PowerShell or other developer tools to deploy UWP apps.</span></span> <span data-ttu-id="3a2d7-109">また、アプリ インストーラーでは、Web、オプション パッケージ、関連セットからアプリをインストールすることもできます。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-109">The App Installer can also install an app from the web, optional packages, and related sets.</span></span> <span data-ttu-id="3a2d7-110">アプリ インストーラーを使用してアプリをインストールする方法については、表に示されているトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-110">To learn how to use the App Installer to install your app, see the topics in the table.</span></span>

| <span data-ttu-id="3a2d7-111">トピック</span><span class="sxs-lookup"><span data-stu-id="3a2d7-111">Topic</span></span> | <span data-ttu-id="3a2d7-112">説明</span><span class="sxs-lookup"><span data-stu-id="3a2d7-112">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="3a2d7-113">Visual Studio を使ったアプリ インストーラー ファイルの作成</span><span class="sxs-lookup"><span data-stu-id="3a2d7-113">Create App Installer file with Visual Studio</span></span>](create-appinstallerfile-vs.md)| <span data-ttu-id="3a2d7-114">Visual Studio を使い、.appinstaller ファイルを使って自動更新を有効にする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-114">Learn how to use Visual Studio to enable automatic updates using the .appinstaller file.</span></span> |
| [<span data-ttu-id="3a2d7-115">Web ページから UWP アプリをインストールする</span><span class="sxs-lookup"><span data-stu-id="3a2d7-115">Install UWP apps from a web page</span></span>](installing-UWP-apps-web.md) | <span data-ttu-id="3a2d7-116">このセクションでは、ユーザーが直接 Web ページからアプリをインストールできるようにするために必要な手順を確認します。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-116">In this section, we will review the steps you need to take to allow users to install your apps directly from the web page.</span></span> |
| [<span data-ttu-id="3a2d7-117">アプリ インストーラー ファイルを使用して関連セットをインストールする</span><span class="sxs-lookup"><span data-stu-id="3a2d7-117">Install a related set using an App Installer file</span></span>](install-related-set.md) | <span data-ttu-id="3a2d7-118">このセクションでは、アプリ インストーラーで関連セットをインストールできるようにする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-118">In this section, learn how to allow the installation of a related set via App Installer.</span></span> <span data-ttu-id="3a2d7-119">関連セットを定義するアプリ インストーラー ファイルを作成する手順についても確認します。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-119">We will also go through the steps to construct an App Installer file that will define your related set.</span></span> |
| [<span data-ttu-id="3a2d7-120">アプリ インストーラー ファイルを使ったインストールに関する問題のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="3a2d7-120">Troubleshoot installation issues with the App Installer file</span></span>](troubleshoot-appinstaller-issues.md) | <span data-ttu-id="3a2d7-121">アプリ インストーラー ファイルを使ってアプリケーションをサイドローディングするときの一般的な問題と解決策。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-121">Common issues and solutions when sideloading applications with the App Installer file.</span></span> |
| [<span data-ttu-id="3a2d7-122">アプリ インストーラー ファイル (.appinstaller) リファレンス</span><span class="sxs-lookup"><span data-stu-id="3a2d7-122">App Installer file (.appinstaller) reference</span></span>](https://docs.microsoft.com/uwp/schemas/appinstallerschema/app-installer-file) | <span data-ttu-id="3a2d7-123">アプリ インストーラー ファイルの完全な XML スキーマを確認できます。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-123">View the full XML schema for the App Installer file.</span></span> |

## <a name="tutorials"></a><span data-ttu-id="3a2d7-124">チュートリアル</span><span class="sxs-lookup"><span data-stu-id="3a2d7-124">Tutorials</span></span> 

<span data-ttu-id="3a2d7-125">これらのチュートリアルに従って、さまざまな配布プラットフォームから UWP アプリをホストしてインストールする方法をご確認ください。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-125">Follow these tutorials and learn how to host and install a UWP app from various distribution platforms.</span></span> <span data-ttu-id="3a2d7-126">これらのチュートリアルは、アプリを Microsoft Store に公開する必要がないが、Windows 10 のパッケージおよび展開プラットフォームを活用したい企業や開発者にとって有用です。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-126">These tutorials are useful for enterprises and developers that don't want or need to publish their apps to the Store, but still want to take advantage of the Windows 10 packaging and deployment platform.</span></span>

| <span data-ttu-id="3a2d7-127">チュートリアル</span><span class="sxs-lookup"><span data-stu-id="3a2d7-127">Tutorial</span></span> | <span data-ttu-id="3a2d7-128">説明</span><span class="sxs-lookup"><span data-stu-id="3a2d7-128">Description</span></span> |
|----------|-------------|
| [<span data-ttu-id="3a2d7-129">Azure Web アプリからの UWP アプリのインストール</span><span class="sxs-lookup"><span data-stu-id="3a2d7-129">Install a UWP app from an Azure Web App</span></span>](web-install-azure.md) | <span data-ttu-id="3a2d7-130">Azure Web アプリを作成し、それを使用して UWP アプリ パッケージをホストして配布します。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-130">Create an Azure Web App and use it to host and distribute your UWP app package.</span></span> |
| [<span data-ttu-id="3a2d7-131">IIS サーバーからの UWP アプリのインストール</span><span class="sxs-lookup"><span data-stu-id="3a2d7-131">Install a UWP app from an IIS server</span></span>](web-install-IIS.md) | <span data-ttu-id="3a2d7-132">IIS サーバーをセットアップし、Web アプリがアプリ パッケージをホストできることを確認して、アプリ インストーラーを効果的に使用します。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-132">Set up an IIS server, verify that your web app can host app packages, and use App Installer effectively.</span></span> |
| [<span data-ttu-id="3a2d7-133">Web インストールのための UWP アプリ パッケージの AWS へのホスト</span><span class="sxs-lookup"><span data-stu-id="3a2d7-133">Hosting UWP app packages on AWS for web install</span></span>](web-install-aws.md) | <span data-ttu-id="3a2d7-134">Web サイトから、UWP アプリ パッケージをホストする、Amazon Simple Storage Service をセットアップする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3a2d7-134">Learn how to set up Amazon Simple Storage Service to host your UWP app package from a web site.</span></span> |

