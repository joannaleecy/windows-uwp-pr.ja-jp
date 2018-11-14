---
title: Windows PC での Xbox Live セットアップのトラブルシューティング
author: KevinAsgari
description: Windows PC で Xbox Live 開発環境をトラブルシューティングする方法について説明します。
ms.assetid: 9cfebdcd-0c1c-4fc2-9457-e7e434b6374c
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: 9484a324b060bbbf3e31dab0ace915bd4c551ebb
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6192403"
---
# <a name="troubleshooting-xbox-live-setup-on-windows-pc"></a><span data-ttu-id="161aa-104">Windows PC での Xbox Live セットアップのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="161aa-104">Troubleshooting Xbox Live setup on Windows PC</span></span>

<span data-ttu-id="161aa-105">Windows 10 PC で、コンピューターは、次の手順を使用して正しくセットアップを確保できます。</span><span class="sxs-lookup"><span data-stu-id="161aa-105">On Windows 10 PC, you can ensure your machine is setup correctly with these steps:</span></span>

1. <span data-ttu-id="161aa-106">コンピューターにサンプルを実行するもので、XDKS.1 サンド ボックスを変更します。</span><span class="sxs-lookup"><span data-stu-id="161aa-106">Change your machine to point to the XDKS.1 sandbox where samples are designed to run.</span></span>  <span data-ttu-id="161aa-107">それには次のスクリプトを実行します。</span><span class="sxs-lookup"><span data-stu-id="161aa-107">Do this by running this script:</span></span>

        {*SDK source root*}\Tools\SwitchSandbox.cmd XDKS.1

1. <span data-ttu-id="161aa-108">SDK に含まれる zip ファイル "SourcesAndSamples.zip" の内容を抽出します。</span><span class="sxs-lookup"><span data-stu-id="161aa-108">Extract the contents of the zip file "SourcesAndSamples.zip" found inside the SDK.</span></span>
1. <span data-ttu-id="161aa-109">サンプルのソリューションを開きます。</span><span class="sxs-lookup"><span data-stu-id="161aa-109">Open a sample solution:</span></span>
    1. <span data-ttu-id="161aa-110">C++ API の場合: {*SDK ソース ルート*}\Samples\Social\UWP\Cpp\Social.Cpp.140.sln</span><span class="sxs-lookup"><span data-stu-id="161aa-110">For C++ API: {*SDK source root*}\Samples\Social\UWP\Cpp\Social.Cpp.140.sln</span></span>
    1. <span data-ttu-id="161aa-111">C# の WinRT API 場合: {*SDK ソース ルート*}\Samples\Social\UWP\CSharp\Social.CSharp.140.sln</span><span class="sxs-lookup"><span data-stu-id="161aa-111">For WinRT API with C#: {*SDK source root*}\Samples\Social\UWP\CSharp\Social.CSharp.140.sln</span></span>
    1. <span data-ttu-id="161aa-112">C++/CX の WinRT API の場合: {*SDK ソース ルート*}\Samples\TitleStorage\UWP\CppCx\TitleStorageUniversal.sln</span><span class="sxs-lookup"><span data-stu-id="161aa-112">For WinRT API with C++/CX:  {*SDK source root*}\Samples\TitleStorage\UWP\CppCx\TitleStorageUniversal.sln</span></span>
1. <span data-ttu-id="161aa-113">ビルド対象のプラットフォームを、"Win32" または "x64" に変更します。</span><span class="sxs-lookup"><span data-stu-id="161aa-113">Change the build target platform to either "Win32" or "x64".</span></span>
1. <span data-ttu-id="161aa-114">ソリューションを右クリックして、すべてのものを再ビルドします。</span><span class="sxs-lookup"><span data-stu-id="161aa-114">Right click the solution and re-build everything.</span></span>
1. <span data-ttu-id="161aa-115">デバッガーでアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="161aa-115">Launch the app in the debugger.</span></span>
1. <span data-ttu-id="161aa-116">サインイン[Xbox デベロッパー ポータル](https://xdp.xboxlive.com)で、作成した開発アカウントまたは[パートナー センター](https://partner.microsoft.com/dashboard)で承認されて製品版の開発者アカウントを使用します。</span><span class="sxs-lookup"><span data-stu-id="161aa-116">Sign-in with the development account that you created on the [Xbox Developer Portal](https://xdp.xboxlive.com), or with a retail developer account authorized in [Partner Center](https://partner.microsoft.com/dashboard).</span></span>
1. <span data-ttu-id="161aa-117">Xbox Live の情報にアクセスする権限をアプリに付与します。</span><span class="sxs-lookup"><span data-stu-id="161aa-117">Grant the app permission to access your Xbox Live information.</span></span>
1. <span data-ttu-id="161aa-118">アプリが情報を取得できること、およびゲーマータグが表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="161aa-118">Verify that the app can retrieve your information and you can see your gamertag.</span></span>