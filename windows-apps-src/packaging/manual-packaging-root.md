---
ms.assetid: ee51eae3-ed55-419e-ad74-6adf1e1fb8b9
title: 手動でのアプリのパッケージ化
description: このセクションには、ユニバーサル Windows プラットフォーム (UWP) アプリの手動でのパッケージ化に関する記事または記事へのリンクが記載されています。
ms.date: 04/30/2018
ms.topic: article
keywords: Windows 10, UWP, パッケージ化
ms.localizationpriority: medium
ms.openlocfilehash: 5c429c3c88b0ae23cb518a59cab2e5a3c4f380a2
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8889272"
---
# <a name="manual-app-packaging"></a><span data-ttu-id="e41d2-104">手動でのアプリのパッケージ化</span><span class="sxs-lookup"><span data-stu-id="e41d2-104">Manual app packaging</span></span>

<span data-ttu-id="e41d2-105">アプリ パッケージを作成して署名するときに、Visual Studio を使ってアプリを開発していない場合は、手動でのアプリのパッケージ化ツールを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e41d2-105">If you want to create and sign an app package, but you didn't use Visual Studio to develop your app, you'll need to use the manual app packaging tools.</span></span>

> [!IMPORTANT] 
> <span data-ttu-id="e41d2-106">Visual Studio を使用してアプリを開発する場合は、Visual Studio のウィザードを使ってアプリ パッケージを作成し、署名することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e41d2-106">If you used Visual Studio to develop your app, it's recommended that you use the Visual Studio wizard to create and sign your app package.</span></span> <span data-ttu-id="e41d2-107">詳しくは、「[Visual Studio での UWP アプリのパッケージ化](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e41d2-107">For more information, see [Package a UWP app with Visual Studio](https://msdn.microsoft.com/windows/uwp/packaging/packaging-uwp-apps).</span></span>

## <a name="purpose"></a><span data-ttu-id="e41d2-108">目的</span><span class="sxs-lookup"><span data-stu-id="e41d2-108">Purpose</span></span>

<span data-ttu-id="e41d2-109">このセクションには、ユニバーサル Windows プラットフォーム (UWP) アプリの手動でのパッケージ化に関する記事または記事へのリンクが記載されています。</span><span class="sxs-lookup"><span data-stu-id="e41d2-109">This section contains or links to articles about manually packaging Universal Windows Platform (UWP) apps.</span></span>

| <span data-ttu-id="e41d2-110">トピック</span><span class="sxs-lookup"><span data-stu-id="e41d2-110">Topic</span></span> | <span data-ttu-id="e41d2-111">説明</span><span class="sxs-lookup"><span data-stu-id="e41d2-111">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="e41d2-112">MakeAppx.exe ツールを使ったアプリ パッケージの作成</span><span class="sxs-lookup"><span data-stu-id="e41d2-112">Create an app package with the MakeAppx.exe tool</span></span>](create-app-package-with-makeappx-tool.md) | <span data-ttu-id="e41d2-113">MakeAppx.exe は、アプリ パッケージとバンドルからのファイルの作成、暗号化、暗号化解除、抽出を行います。</span><span class="sxs-lookup"><span data-stu-id="e41d2-113">MakeAppx.exe creates, encrypts, decrypts, and extracts files from app packages and bundles.</span></span> |
| [<span data-ttu-id="e41d2-114">パッケージ署名用証明書を作成する</span><span class="sxs-lookup"><span data-stu-id="e41d2-114">Create a certificate for package signing</span></span>](create-certificate-package-signing.md) | <span data-ttu-id="e41d2-115">PowerShell ツールを使ってアプリ パッケージ署名用を作成し、エクスポートします。</span><span class="sxs-lookup"><span data-stu-id="e41d2-115">Create and export a certificate for app package signing with PowerShell tools.</span></span> |
| [<span data-ttu-id="e41d2-116">SignTool を使ってアプリ パッケージに署名する</span><span class="sxs-lookup"><span data-stu-id="e41d2-116">Sign an app package using SignTool</span></span>](sign-app-package-using-signtool.md) | <span data-ttu-id="e41d2-117">SignTool を使って手動でアプリ パッケージに証明書による署名を行います。</span><span class="sxs-lookup"><span data-stu-id="e41d2-117">Use SignTool to manually sign an app package with a certificate.</span></span> |

### <a name="advanced-topics"></a><span data-ttu-id="e41d2-118">高度なトピック</span><span class="sxs-lookup"><span data-stu-id="e41d2-118">Advanced topics</span></span>

<span data-ttu-id="e41d2-119">このセクションには、より効率的なパッケージ化とインストールのために大規模なアプリや複雑なアプリをコンポーネント化する高度なトピックが含まれています。</span><span class="sxs-lookup"><span data-stu-id="e41d2-119">This section contains more advanced topics for componentizing a large and/or complex app for more efficient packaging and installation.</span></span> 

> [!IMPORTANT]
> <span data-ttu-id="e41d2-120">Microsoft Store にアプリを提出する予定がある場合、[Windows 開発者向けサポート](https://developer.microsoft.com/windows/support)に連絡してこのセクションの高度な機能を使う承認を得る必要があります。</span><span class="sxs-lookup"><span data-stu-id="e41d2-120">If you intend to submit your app to the Store, you need to contact [Windows developer support](https://developer.microsoft.com/windows/support) and get approval to use any of the advanced features in this section.</span></span>


| <span data-ttu-id="e41d2-121">トピック</span><span class="sxs-lookup"><span data-stu-id="e41d2-121">Topic</span></span> | <span data-ttu-id="e41d2-122">説明</span><span class="sxs-lookup"><span data-stu-id="e41d2-122">Description</span></span> |
|-------|-------------|
| [<span data-ttu-id="e41d2-123">アセット パッケージの概要</span><span class="sxs-lookup"><span data-stu-id="e41d2-123">Introduction to asset packages</span></span>](asset-packages.md) | <span data-ttu-id="e41d2-124">アセット パッケージは、アプリケーションの共通ファイルの一元的な場所として機能するパッケージの種類です。これにより、そのアーキテクチャ パッケージ全体で重複するファイルが事実上不要になります。</span><span class="sxs-lookup"><span data-stu-id="e41d2-124">Asset packages are a type of package that act as a centralized location for an application’s common files – effectively eliminating the necessity for duplicated files throughout its architecture packages.</span></span> |
| [<span data-ttu-id="e41d2-125">アセット パッケージとパッケージ圧縮を使った開発</span><span class="sxs-lookup"><span data-stu-id="e41d2-125">Developing with asset packages and package folding</span></span>](package-folding.md) | <span data-ttu-id="e41d2-126">アセット パッケージとパッケージ圧縮を使ってアプリケーションを効率的に整理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e41d2-126">Learn how to efficiently organize your app with asset packages and package folding.</span></span> |
| [<span data-ttu-id="e41d2-127">フラット バンドル アプリ パッケージ</span><span class="sxs-lookup"><span data-stu-id="e41d2-127">Flat bundle app packages</span></span>](flat-bundles.md) | <span data-ttu-id="e41d2-128">アプリのパッケージ ファイルのフラット バンドルを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e41d2-128">Describes how to create a flat bundle for your app’s package files.</span></span> |
| [<span data-ttu-id="e41d2-129">パッケージ レイアウトを使ったパッケージの作成</span><span class="sxs-lookup"><span data-stu-id="e41d2-129">Package creation with the packaging layout</span></span>](packaging-layout.md) | <span data-ttu-id="e41d2-130">パッケージ レイアウトは、アプリのパッケージ構造を記述する 1 つのドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="e41d2-130">The packaging layout is a single document that describes packaging structure of the app.</span></span> <span data-ttu-id="e41d2-131">アプリのバンドル (プライマリおよびオプション)、バンドル内のパッケージ、パッケージ内のファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="e41d2-131">It specifies the bundles of an app (primary and optional), the packages in the bundles, and the files in the packages.</span></span> |
