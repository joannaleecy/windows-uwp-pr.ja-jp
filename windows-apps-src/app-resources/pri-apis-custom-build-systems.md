---
author: stevewhims
Description: With the package resource indexing (PRI) APIs, you can develop a custom build system for your UWP app's resources. The build system will be able to create, version, and dump PRI files to whatever level of complexity your UWP app needs.
title: パッケージ リソース インデックス (PRI) API とカスタム ビルド システム
template: detail.hbs
ms.author: stwhi
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: 9b85f40fc391df764515d21ba3b334bfe068725c
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5694158"
---
# <a name="package-resource-indexing-pri-apis-and-custom-build-systems"></a><span data-ttu-id="913d6-103">パッケージ リソース インデックス (PRI) API とカスタム ビルド システム</span><span class="sxs-lookup"><span data-stu-id="913d6-103">Package resource indexing (PRI) APIs and custom build systems</span></span>
<span data-ttu-id="913d6-104">[パッケージ リソース インデックス (PRI) API](https://msdn.microsoft.com/library/windows/desktop/mt845690) を使用すると、UWP アプリのリソース用にカスタム ビルド システムを開発することができます。</span><span class="sxs-lookup"><span data-stu-id="913d6-104">With the [package resource indexing (PRI) APIs](https://msdn.microsoft.com/library/windows/desktop/mt845690), you can develop a custom build system for your UWP app's resources.</span></span> <span data-ttu-id="913d6-105">ビルド システムでは、UWP アプリが必要とする複雑さのレベルにかかわらず、パッケージ リソース インデックス (PRI) ファイルを (XML として) 作成、バージョン管理、ダンプすることができます。</span><span class="sxs-lookup"><span data-stu-id="913d6-105">The build system will be able to create, version, and dump (as XML) package resource index (PRI) files to whatever level of complexity your UWP app needs.</span></span> <span data-ttu-id="913d6-106">現在 MakePri.exe コマンド ライン ツールを使用しているカスタム ビルド システムがある場合 (「[MakePri.exe を使用して手動でリソースをコンパイルする](makepri-exe-command-options.md)」を参照)、パフォーマンスと制御を向上させるために、MakePri.exe の呼び出しではなく、PRI API の呼び出しに切り替えることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="913d6-106">If you have a custom build system that currently uses the MakePri.exe command-line tool (see [Compile resources manually with MakePri.exe](makepri-exe-command-options.md)) then, for increased performance and control, we recommend that you switch over to calling the PRI APIs instead of calling MakePri.exe.</span></span>

<span data-ttu-id="913d6-107">PRI API は、Windows 10 向け Windows SDK のバージョン 1803 で導入されました。</span><span class="sxs-lookup"><span data-stu-id="913d6-107">The PRI APIs were introduced in the Windows SDK for Windows 10, version 1803.</span></span> <span data-ttu-id="913d6-108">API は、Win32 Windows API の形式になります。つまり、それらを呼び出すオプションがいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="913d6-108">The APIs take the form of Win32 Windows APIs, which means that you have a few options for calling them.</span></span> <span data-ttu-id="913d6-109">Win32 アプリから直接それらを呼び出すか、または .NET アプリ、さらには UWP アプリからでも [platform invoke](/dotnet/framework/interop/consuming-unmanaged-dll-functions?branch=live) を介してそれらを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="913d6-109">You can call them directly from a Win32 app, or you can call them via [platform invoke](/dotnet/framework/interop/consuming-unmanaged-dll-functions?branch=live) from a .NET app or even from a UWP app.</span></span>

<span data-ttu-id="913d6-110">このトピックのシナリオでは、Win32 Visual C++ Windows Console Application プロジェクトからの PRI API の呼び出しを示します。</span><span class="sxs-lookup"><span data-stu-id="913d6-110">The scenarios in this topic demonstrate calling PRI APIs from a Win32 Visual C++ Windows Console Application project.</span></span> <span data-ttu-id="913d6-111">背景情報については、「[リソース管理システム](resource-management-system.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="913d6-111">For background info, see [Resource Management System](resource-management-system.md).</span></span>

<span data-ttu-id="913d6-112">PRI ファイルのサイズ制限は、64 キロバイトです。</span><span class="sxs-lookup"><span data-stu-id="913d6-112">The size limit on a PRI file is 64 kilobytes.</span></span>

> [!NOTE]
> <span data-ttu-id="913d6-113">おそらくカスタム ビルド システム アプリを Microsoft Store に提出する必要はないため、この注意事項が問題になることはあまりありません。。</span><span class="sxs-lookup"><span data-stu-id="913d6-113">This caveat is unlikely to be an issue, since you probably won't want to submit your custom build system app to the Microsoft Store.</span></span> <span data-ttu-id="913d6-114">ただし、UWP アプリの形式でカスタム ビルド システムを開発するオプションを選択する場合、そのアプリは Microsoft Store に提出することができないという点で通常とは異なる UWP アプリになります。</span><span class="sxs-lookup"><span data-stu-id="913d6-114">But, if you choose the option to develop your custom build system in the form of a UWP app, then it will be an unusual UWP app in that you won't be able to submit it to the Microsoft Store.</span></span> <span data-ttu-id="913d6-115">これは、プラットフォーム呼び出しを使用する UWP アプリが Microsoft Store 認定に失敗するためです。</span><span class="sxs-lookup"><span data-stu-id="913d6-115">That's because a UWP app that uses platform invoke fails Microsoft Store certification.</span></span> <span data-ttu-id="913d6-116">この場合、プラットフォームの起動呼び出しは、配布する UWP アプリ (PRI ファイルを作成しているアプリ) *ではなく*、*カスタム ビルド システムでのみ行われる*点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="913d6-116">Note that, in this case, platform invoke calls *will exist only in your custom build system*; *not* in your shipping UWP app (the one you're building PRI files for).</span></span>

## <a name="scenario-walkthroughs"></a><span data-ttu-id="913d6-117">シナリオのチュートリアル</span><span class="sxs-lookup"><span data-stu-id="913d6-117">Scenario walkthroughs</span></span>
|<span data-ttu-id="913d6-118">トピック</span><span class="sxs-lookup"><span data-stu-id="913d6-118">Topic</span></span>|<span data-ttu-id="913d6-119">説明</span><span class="sxs-lookup"><span data-stu-id="913d6-119">Description</span></span>|
|-|-|
|[<span data-ttu-id="913d6-120">シナリオ 1: 文字列リソースとアセット ファイルから PRI ファイルを生成する</span><span class="sxs-lookup"><span data-stu-id="913d6-120">Scenario 1: Generate a PRI file from string resources and asset files</span></span>](pri-apis-scenario-1.md)|<span data-ttu-id="913d6-121">このシナリオでは、カスタム ビルド システムを表す新しいアプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="913d6-121">In this scenario, we'll make a new app to represent our custom build system.</span></span> <span data-ttu-id="913d6-122">リソース インデクサーを作成し、文字列とその他の種類のリソースを追加します。</span><span class="sxs-lookup"><span data-stu-id="913d6-122">We'll create a resource indexer and add strings and other kinds of resources to it.</span></span> <span data-ttu-id="913d6-123">次に、PRI ファイルを生成してダンプします。</span><span class="sxs-lookup"><span data-stu-id="913d6-123">Then we'll generate and dump a PRI file.</span></span>|

## <a name="important-apis"></a><span data-ttu-id="913d6-124">重要な API</span><span class="sxs-lookup"><span data-stu-id="913d6-124">Important APIs</span></span>
* [<span data-ttu-id="913d6-125">パッケージ リソース インデックス (PRI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="913d6-125">Package resource indexing (PRI) reference</span></span>](https://msdn.microsoft.com/library/windows/desktop/mt845690)

## <a name="related-topics"></a><span data-ttu-id="913d6-126">関連トピック</span><span class="sxs-lookup"><span data-stu-id="913d6-126">Related topics</span></span>
* [<span data-ttu-id="913d6-127">MakePri.exe を使用して手動でリソースをコンパイルする</span><span class="sxs-lookup"><span data-stu-id="913d6-127">Compile resources manually with MakePri.exe</span></span>](makepri-exe-command-options.md)
* [<span data-ttu-id="913d6-128">アンマネージ DLL 関数の使用</span><span class="sxs-lookup"><span data-stu-id="913d6-128">Consuming Unmanaged DLL Functions</span></span>](/dotnet/framework/interop/consuming-unmanaged-dll-functions?branch=live)
* [<span data-ttu-id="913d6-129">リソース管理システム</span><span class="sxs-lookup"><span data-stu-id="913d6-129">Resource Management System</span></span>](resource-management-system.md)
