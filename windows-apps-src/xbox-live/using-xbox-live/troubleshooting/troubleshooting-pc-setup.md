---
title: Windows PC での Xbox Live セットアップのトラブルシューティング
description: Windows PC で Xbox Live 開発環境をトラブルシューティングする方法について説明します。
ms.assetid: 9cfebdcd-0c1c-4fc2-9457-e7e434b6374c
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: c1f055a49fe34be35335e50dc8b1efbfb7b9b922
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57647737"
---
# <a name="troubleshooting-xbox-live-setup-on-windows-pc"></a><span data-ttu-id="b334a-104">Windows PC での Xbox Live セットアップのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="b334a-104">Troubleshooting Xbox Live setup on Windows PC</span></span>

<span data-ttu-id="b334a-105">Windows 10 pc で、コンピューターは、次の手順を使用して正しくセットアップを確認することができます。</span><span class="sxs-lookup"><span data-stu-id="b334a-105">On Windows 10 PC, you can ensure your machine is setup correctly with these steps:</span></span>

1. <span data-ttu-id="b334a-106">サンプルを実行するもので、XDKS.1 サンド ボックス をポイントするためにコンピューターを変更します。</span><span class="sxs-lookup"><span data-stu-id="b334a-106">Change your machine to point to the XDKS.1 sandbox where samples are designed to run.</span></span>  <span data-ttu-id="b334a-107">それには次のスクリプトを実行します。</span><span class="sxs-lookup"><span data-stu-id="b334a-107">Do this by running this script:</span></span>

        {*SDK source root*}\Tools\SwitchSandbox.cmd XDKS.1

1. <span data-ttu-id="b334a-108">SDK に含まれる zip ファイル "SourcesAndSamples.zip" の内容を抽出します。</span><span class="sxs-lookup"><span data-stu-id="b334a-108">Extract the contents of the zip file "SourcesAndSamples.zip" found inside the SDK.</span></span>
1. <span data-ttu-id="b334a-109">サンプルのソリューションを開きます。</span><span class="sxs-lookup"><span data-stu-id="b334a-109">Open a sample solution:</span></span>
    1. <span data-ttu-id="b334a-110">C++ API の場合: {*SDK ソース ルート*}\Samples\Social\UWP\Cpp\Social.Cpp.140.sln</span><span class="sxs-lookup"><span data-stu-id="b334a-110">For C++ API: {*SDK source root*}\Samples\Social\UWP\Cpp\Social.Cpp.140.sln</span></span>
    1. <span data-ttu-id="b334a-111">C# の WinRT API 場合: {*SDK ソース ルート*}\Samples\Social\UWP\CSharp\Social.CSharp.140.sln</span><span class="sxs-lookup"><span data-stu-id="b334a-111">For WinRT API with C#: {*SDK source root*}\Samples\Social\UWP\CSharp\Social.CSharp.140.sln</span></span>
    1. <span data-ttu-id="b334a-112">C++/CX の WinRT API の場合: {*SDK ソース ルート*}\Samples\TitleStorage\UWP\CppCx\TitleStorageUniversal.sln</span><span class="sxs-lookup"><span data-stu-id="b334a-112">For WinRT API with C++/CX:  {*SDK source root*}\Samples\TitleStorage\UWP\CppCx\TitleStorageUniversal.sln</span></span>
1. <span data-ttu-id="b334a-113">ビルド対象のプラットフォームを、"Win32" または "x64" に変更します。</span><span class="sxs-lookup"><span data-stu-id="b334a-113">Change the build target platform to either "Win32" or "x64".</span></span>
1. <span data-ttu-id="b334a-114">ソリューションを右クリックして、すべてのものを再ビルドします。</span><span class="sxs-lookup"><span data-stu-id="b334a-114">Right click the solution and re-build everything.</span></span>
1. <span data-ttu-id="b334a-115">デバッガーでアプリを起動します。</span><span class="sxs-lookup"><span data-stu-id="b334a-115">Launch the app in the debugger.</span></span>
1. <span data-ttu-id="b334a-116">上に作成した開発アカウントでサインイン、 [Xbox 開発者ポータル](https://xdp.xboxlive.com)、またはで承認されている小売開発者アカウントで[パートナー センター](https://partner.microsoft.com/dashboard)します。</span><span class="sxs-lookup"><span data-stu-id="b334a-116">Sign-in with the development account that you created on the [Xbox Developer Portal](https://xdp.xboxlive.com), or with a retail developer account authorized in [Partner Center](https://partner.microsoft.com/dashboard).</span></span>
1. <span data-ttu-id="b334a-117">Xbox Live の情報にアクセスする権限をアプリに付与します。</span><span class="sxs-lookup"><span data-stu-id="b334a-117">Grant the app permission to access your Xbox Live information.</span></span>
1. <span data-ttu-id="b334a-118">アプリが情報を取得できること、およびゲーマータグが表示されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b334a-118">Verify that the app can retrieve your information and you can see your gamertag.</span></span>