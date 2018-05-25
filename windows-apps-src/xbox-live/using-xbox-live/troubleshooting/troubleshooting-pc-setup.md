---
title: Windows PC での Xbox Live セットアップのトラブルシューティング
author: KevinAsgari
description: Windows PC で Xbox Live 開発環境をトラブルシューティングする方法について説明します。
ms.assetid: 9cfebdcd-0c1c-4fc2-9457-e7e434b6374c
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, トラブルシューティング
ms.localizationpriority: low
ms.openlocfilehash: 13597552c5440023cffde8fc97226d9d23e845ad
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="troubleshooting-xbox-live-setup-on-windows-pc"></a><span data-ttu-id="73960-104">Windows PC での Xbox Live セットアップのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="73960-104">Troubleshooting Xbox Live setup on Windows PC</span></span>

<span data-ttu-id="73960-105">Windows 10 PC では、以下の手順を使用して、コンピューターが正しくセットアップされていることを確認できます。</span><span class="sxs-lookup"><span data-stu-id="73960-105">On Windows 10 PC, you can ensure you machine is setup correct with these steps:</span></span>

1. <span data-ttu-id="73960-106">対象のコンピューターに移動し、サンプルを実行するように設計されている XDKS.1 サンドボックスを参照します。</span><span class="sxs-lookup"><span data-stu-id="73960-106">Change to your machine to point to the XDKS.1 sandbox where samples are designed to run.</span></span>  <span data-ttu-id="73960-107">それには次のスクリプトを実行します。</span><span class="sxs-lookup"><span data-stu-id="73960-107">Do this by running this script:</span></span>

        {*SDK source root*}\Tools\SwitchSandbox.cmd XDKS.1

1. <span data-ttu-id="73960-108">SDK に含まれる zip ファイル "SourcesAndSamples.zip" の内容を抽出します。</span><span class="sxs-lookup"><span data-stu-id="73960-108">Extract the contents of the zip file "SourcesAndSamples.zip" found inside the SDK.</span></span>
1. <span data-ttu-id="73960-109">サンプルのソリューションを開きます。</span><span class="sxs-lookup"><span data-stu-id="73960-109">Open a sample solution:</span></span>
    1. <span data-ttu-id="73960-110">C++ API の場合: {*SDK ソース ルート*}\Samples\Social\UWP\Cpp\Social.Cpp.140.sln</span><span class="sxs-lookup"><span data-stu-id="73960-110">For C++ API: {*SDK source root*}\Samples\Social\UWP\Cpp\Social.Cpp.140.sln</span></span>
    1. <span data-ttu-id="73960-111">C# の WinRT API 場合: {*SDK ソース ルート*}\Samples\Social\UWP\CSharp\Social.CSharp.140.sln</span><span class="sxs-lookup"><span data-stu-id="73960-111">For WinRT API with C#: {*SDK source root*}\Samples\Social\UWP\CSharp\Social.CSharp.140.sln</span></span>
    1. <span data-ttu-id="73960-112">C++/CX の WinRT API の場合: {*SDK ソース ルート*}\Samples\TitleStorage\UWP\CppCx\TitleStorageUniversal.sln</span><span class="sxs-lookup"><span data-stu-id="73960-112">For WinRT API with C++/CX:  {*SDK source root*}\Samples\TitleStorage\UWP\CppCx\TitleStorageUniversal.sln</span></span>
1. <span data-ttu-id="73960-113">ビルド対象のプラットフォームを、"Win32" または "x64" に変更します。</span><span class="sxs-lookup"><span data-stu-id="73960-113">Change the build target platform to either "Win32" or "x64".</span></span>
1. <span data-ttu-id="73960-114">ソリューションを右クリックして、すべてのものを再ビルドします。</span><span class="sxs-lookup"><span data-stu-id="73960-114">Right click the solution and re-build everything.</span></span>
1. <span data-ttu-id="73960-115">デバッガーでアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="73960-115">Launch the app in the debugger.</span></span>
1. <span data-ttu-id="73960-116">作成した開発アカウントを使用して https://xdp.xboxlive.com にサインインします</span><span class="sxs-lookup"><span data-stu-id="73960-116">Sign-in with the development account that you created in at https://xdp.xboxlive.com</span></span>
1. <span data-ttu-id="73960-117">Xbox Live の情報にアクセスする権限をアプリに付与します。</span><span class="sxs-lookup"><span data-stu-id="73960-117">Grant the app permission to access your Xbox Live information.</span></span>
1. <span data-ttu-id="73960-118">アプリが情報を取得できること、およびゲーマータグが表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="73960-118">Verify that the app can retrieve your information and you can see your gamertag.</span></span>
