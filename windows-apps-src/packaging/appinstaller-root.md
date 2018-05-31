---
author: laurenhughes
title: アプリ インストーラーで UWP アプリをインストールする
description: このセクションには、アプリ インストーラーに関する記事とアプリ インストーラーの機能を使用する方法に関する記事へのリンクが含まれています。
ms.author: lahugh
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング, 関連セット, オプション パッケージ
ms.localizationpriority: medium
ms.openlocfilehash: 06ccb50e3c1a97a69041ca2d3b4de59a550e3399
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1831806"
---
# <a name="install-uwp-apps-with-app-installer"></a><span data-ttu-id="db5d3-104">アプリ インストーラーで UWP アプリをインストールする</span><span class="sxs-lookup"><span data-stu-id="db5d3-104">Install UWP apps with App Installer</span></span>

## <a name="purpose"></a><span data-ttu-id="db5d3-105">目的</span><span class="sxs-lookup"><span data-stu-id="db5d3-105">Purpose</span></span>
<span data-ttu-id="db5d3-106">このセクションには、アプリ インストーラーに関する記事とアプリ インストーラーの機能を使用する方法に関する記事へのリンクが含まれています。</span><span class="sxs-lookup"><span data-stu-id="db5d3-106">This section contains or links to articles about App Installer and how to use the features of App Installer.</span></span> 

<span data-ttu-id="db5d3-107">アプリ インストーラーを使用すると、アプリ パッケージをダブルクリックして UWP アプリをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="db5d3-107">App Installer allows for UWP apps to be installed by double clicking the app package.</span></span> <span data-ttu-id="db5d3-108">これは、ユーザーが UWP アプリを展開するために PowerShell またはその他の開発者ツールを使用する必要がないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="db5d3-108">This means that users don't need to use PowerShell or other developer tools to deploy UWP apps.</span></span> <span data-ttu-id="db5d3-109">また、アプリ インストーラーでは、Web、オプション パッケージ、関連セットからアプリをインストールすることもできます。</span><span class="sxs-lookup"><span data-stu-id="db5d3-109">The App Installer can also install an app from the web, optional packages, and related sets.</span></span> <span data-ttu-id="db5d3-110">アプリ インストーラーを使用してアプリをインストールする方法については、表に示されているトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="db5d3-110">To learn how to use the App Installer to install your app, see the topics in the table.</span></span>

| <span data-ttu-id="db5d3-111">トピック</span><span class="sxs-lookup"><span data-stu-id="db5d3-111">Topic</span></span> | <span data-ttu-id="db5d3-112">説明</span><span class="sxs-lookup"><span data-stu-id="db5d3-112">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="db5d3-113">Visual Studio を使ったアプリ インストーラー ファイルの作成</span><span class="sxs-lookup"><span data-stu-id="db5d3-113">Create App Installer file with Visual Studio</span></span>](create-appinstallerfile-vs.md)| <span data-ttu-id="db5d3-114">Visual Studio を使い、.appinstaller ファイルを使って自動更新を有効にする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="db5d3-114">Learn how to use Visual Studio to enable automatic updates using the .appinstaller file.</span></span> |
| [<span data-ttu-id="db5d3-115">Web ページから UWP アプリをインストールする</span><span class="sxs-lookup"><span data-stu-id="db5d3-115">Install UWP apps from a web page</span></span>](installing-UWP-apps-web.md) | <span data-ttu-id="db5d3-116">このセクションでは、ユーザーが直接 Web ページからアプリをインストールできるようにするために必要な手順を確認します。</span><span class="sxs-lookup"><span data-stu-id="db5d3-116">In this section, we will review the steps you need to take to allow users to install your apps directly from the web page.</span></span> |
| [<span data-ttu-id="db5d3-117">アプリ インストーラー ファイルを使用して関連セットをインストールする</span><span class="sxs-lookup"><span data-stu-id="db5d3-117">Install a related set using an App Installer file</span></span>](install-related-set.md) | <span data-ttu-id="db5d3-118">このセクションでは、アプリ インストーラーで関連セットをインストールできるようにする方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="db5d3-118">In this section, learn how to allow the installation of a related set via App Installer.</span></span> <span data-ttu-id="db5d3-119">関連セットを定義するアプリ インストーラー ファイルを作成する手順についても確認します。</span><span class="sxs-lookup"><span data-stu-id="db5d3-119">We will also go through the steps to construct an App Installer file that will define your related set.</span></span> |
| [<span data-ttu-id="db5d3-120">アプリ インストーラー ファイルを使ったインストールに関する問題のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="db5d3-120">Troubleshoot installation issues with the App Installer file</span></span>](troubleshoot-appinstaller-issues.md) | <span data-ttu-id="db5d3-121">アプリ インストーラー ファイルを使ってアプリケーションをサイドローディングするときの一般的な問題と解決策。</span><span class="sxs-lookup"><span data-stu-id="db5d3-121">Common issues and solutions when sideloading applications with the App Installer file.</span></span> |
| [<span data-ttu-id="db5d3-122">アプリ インストーラー ファイル (.appinstaller) リファレンス</span><span class="sxs-lookup"><span data-stu-id="db5d3-122">App Installer file (.appinstaller) reference</span></span>](https://docs.microsoft.com/uwp/schemas/appinstallerschema/app-installer-file) | <span data-ttu-id="db5d3-123">アプリ インストーラー ファイルの完全な XML スキーマを確認できます。</span><span class="sxs-lookup"><span data-stu-id="db5d3-123">View the full XML schema for the App Installer file.</span></span> |