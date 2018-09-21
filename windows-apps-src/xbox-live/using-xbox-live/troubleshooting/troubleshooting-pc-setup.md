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
ms.localizationpriority: medium
ms.openlocfilehash: 3eabd83f9fc42f86fb1ec35bbce7d8b7b2359e0e
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4110195"
---
# <a name="troubleshooting-xbox-live-setup-on-windows-pc"></a><span data-ttu-id="696a8-104">Windows PC での Xbox Live セットアップのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="696a8-104">Troubleshooting Xbox Live setup on Windows PC</span></span>

<span data-ttu-id="696a8-105">Windows 10 PC で、コンピューターは、次の手順を使用して正しくセットアップを確保できます。</span><span class="sxs-lookup"><span data-stu-id="696a8-105">On Windows 10 PC, you can ensure your machine is setup correctly with these steps:</span></span>

1. <span data-ttu-id="696a8-106">コンピューターにサンプルを実行するもので、XDKS.1 サンド ボックスを変更します。</span><span class="sxs-lookup"><span data-stu-id="696a8-106">Change your machine to point to the XDKS.1 sandbox where samples are designed to run.</span></span>  <span data-ttu-id="696a8-107">それには次のスクリプトを実行します。</span><span class="sxs-lookup"><span data-stu-id="696a8-107">Do this by running this script:</span></span>

        {*SDK source root*}\Tools\SwitchSandbox.cmd XDKS.1

1. <span data-ttu-id="696a8-108">SDK に含まれる zip ファイル "SourcesAndSamples.zip" の内容を抽出します。</span><span class="sxs-lookup"><span data-stu-id="696a8-108">Extract the contents of the zip file "SourcesAndSamples.zip" found inside the SDK.</span></span>
1. <span data-ttu-id="696a8-109">サンプルのソリューションを開きます。</span><span class="sxs-lookup"><span data-stu-id="696a8-109">Open a sample solution:</span></span>
    1. <span data-ttu-id="696a8-110">C++ API の場合: {*SDK ソース ルート*}\Samples\Social\UWP\Cpp\Social.Cpp.140.sln</span><span class="sxs-lookup"><span data-stu-id="696a8-110">For C++ API: {*SDK source root*}\Samples\Social\UWP\Cpp\Social.Cpp.140.sln</span></span>
    1. <span data-ttu-id="696a8-111">C# の WinRT API 場合: {*SDK ソース ルート*}\Samples\Social\UWP\CSharp\Social.CSharp.140.sln</span><span class="sxs-lookup"><span data-stu-id="696a8-111">For WinRT API with C#: {*SDK source root*}\Samples\Social\UWP\CSharp\Social.CSharp.140.sln</span></span>
    1. <span data-ttu-id="696a8-112">C++/CX の WinRT API の場合: {*SDK ソース ルート*}\Samples\TitleStorage\UWP\CppCx\TitleStorageUniversal.sln</span><span class="sxs-lookup"><span data-stu-id="696a8-112">For WinRT API with C++/CX:  {*SDK source root*}\Samples\TitleStorage\UWP\CppCx\TitleStorageUniversal.sln</span></span>
1. <span data-ttu-id="696a8-113">ビルド対象のプラットフォームを、"Win32" または "x64" に変更します。</span><span class="sxs-lookup"><span data-stu-id="696a8-113">Change the build target platform to either "Win32" or "x64".</span></span>
1. <span data-ttu-id="696a8-114">ソリューションを右クリックして、すべてのものを再ビルドします。</span><span class="sxs-lookup"><span data-stu-id="696a8-114">Right click the solution and re-build everything.</span></span>
1. <span data-ttu-id="696a8-115">デバッガーでアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="696a8-115">Launch the app in the debugger.</span></span>
1. <span data-ttu-id="696a8-116">サインイン[Xbox デベロッパー ポータル](https://xdp.xboxlive.com)で、作成した開発アカウントまたは[Windows デベロッパー センター](https://developer.microsoft.com/dashboard/windows/overview)で承認小売開発者アカウントを使用します。</span><span class="sxs-lookup"><span data-stu-id="696a8-116">Sign-in with the development account that you created on the [Xbox Developer Portal](https://xdp.xboxlive.com), or with a retail developer account authorized on the [Windows Dev Center](https://developer.microsoft.com/dashboard/windows/overview).</span></span>
1. <span data-ttu-id="696a8-117">Xbox Live の情報にアクセスする権限をアプリに付与します。</span><span class="sxs-lookup"><span data-stu-id="696a8-117">Grant the app permission to access your Xbox Live information.</span></span>
1. <span data-ttu-id="696a8-118">アプリが情報を取得できること、およびゲーマータグが表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="696a8-118">Verify that the app can retrieve your information and you can see your gamertag.</span></span>