---
title: ARM32 UWP アプリのトラブルシューティング
description: ARM で実行する際の ARM32 アプリの一般的な問題とその解決方法。
ms.date: 01/03/2019
ms.topic: article
keywords: windows 10 s, 常時接続, ARM での ARM32 アプリ, ARM 版 windows 10, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: 75019df4b7d70dad20aea1a256abac05c93a481d
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661547"
---
# <a name="troubleshooting-arm-uwp-apps"></a><span data-ttu-id="ed1bf-104">UWP アプリを ARM のトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="ed1bf-104">Troubleshooting ARM UWP apps</span></span>

<span data-ttu-id="ed1bf-105">場合は、ARM32 または ARM64 UWP アプリは、ARM で正しく機能していない、役立つ可能性のあるいくつかのガイダンスを示します。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-105">If your ARM32 or ARM64 UWP app isn't working correctly on ARM, here's some guidance that may help.</span></span>

>[!NOTE]
> <span data-ttu-id="ed1bf-106">ネイティブ ARM64 プラットフォームを対象とする UWP アプリケーションを構築するには、Visual Studio 2017 バージョン 15.9 以降が必要です。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-106">To build your UWP application to natively target the ARM64 platform, you must have Visual Studio 2017 version 15.9 or later.</span></span> <span data-ttu-id="ed1bf-107">詳細については、次を参照してください。[このブログの投稿](https://blogs.windows.com/buildingapps/2018/11/15/official-support-for-windows-10-on-arm-development)します。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-107">For more information, see [this blog post](https://blogs.windows.com/buildingapps/2018/11/15/official-support-for-windows-10-on-arm-development).</span></span>

## <a name="common-issues"></a><span data-ttu-id="ed1bf-108">一般的な問題</span><span class="sxs-lookup"><span data-stu-id="ed1bf-108">Common issues</span></span>
<span data-ttu-id="ed1bf-109">ここでは、一般的な問題がいくつか ARM32 および ARM64 のアプリのトラブルシューティングを行うときに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-109">Here are some common issues to keep in mind when troubleshooting ARM32 and ARM64 apps.</span></span>

### <a name="using-windows-10-mobile-only-apis-on-arm-based-processors"></a><span data-ttu-id="ed1bf-110">ARM ベースのプロセッサでの Windows 10 Mobile 専用 API の使用</span><span class="sxs-lookup"><span data-stu-id="ed1bf-110">Using Windows 10 Mobile-only APIs on ARM-based processors</span></span>
<span data-ttu-id="ed1bf-111">モバイル専用の Api を使用する場合、問題に ARM アプリが実行可能性があります (たとえば、 **HardwareButtons**)。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-111">ARM apps may run into problems when using mobile-only APIs (for example, **HardwareButtons**).</span></span> <span data-ttu-id="ed1bf-112">これを軽減するには、それらの API を呼び出す前に Windows 10 Mobile でアプリが実行されているかどうかを動的に検出します。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-112">To mitigate this, you can dynamically detect whether your app is running on Windows 10 Mobile before calling these APIs.</span></span> <span data-ttu-id="ed1bf-113">[API コントラクトを使った機能の動的な検出](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)に関するブログ投稿のガイダンスに従います。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-113">Follow the guidance in the blog post, [Dynamically detecting features with API contracts](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/).</span></span>

### <a name="including-dependencies-not-supported-by-uwp-apps"></a><span data-ttu-id="ed1bf-114">UWP アプリによりサポートされていない依存関係の追加</span><span class="sxs-lookup"><span data-stu-id="ed1bf-114">Including dependencies not supported by UWP apps</span></span>
<span data-ttu-id="ed1bf-115">Visual Studio と UWP SDK に組み込まれていない正しくユニバーサル Windows プラットフォーム (UWP) アプリによっては、ARM64 のシステムで実行されている ARM アプリを使用できない OS コンポーネントに依存関係があります。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-115">Universal Windows Platform (UWP) apps that aren't properly built with Visual Studio and the UWP SDK may have dependencies on OS components that aren't available to ARM apps running on an ARM64 system.</span></span> <span data-ttu-id="ed1bf-116">そのような依存関係の例は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-116">Examples of these dependencies include:</span></span>

- <span data-ttu-id="ed1bf-117">.NET Framework の一部が使用可能であることが期待される。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-117">Expecting parts of the .NET Framework to be available.</span></span>
- <span data-ttu-id="ed1bf-118">UWP と互換性のないサード パーティの .NET コンポーネントを参照している。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-118">Referencing third-party .NET components that aren't compatible with UWP.</span></span>

<span data-ttu-id="ed1bf-119">これらの問題を解決できます: 利用不可の依存関係を削除して、最新の Microsoft Visual Studio と UWP SDK バージョンの; を使用して、アプリを再構築または、Microsoft Store から ARM アプリを削除する最後の手段としてように x86 (該当する場合)、アプリのバージョンは、ユーザーの Pc にダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-119">These issues can be resolved by: removing the unavailable dependencies and rebuilding the app by using the latest Microsoft Visual Studio and UWP SDK versions; or as a last resort, removing the ARM app from the Microsoft Store, so that the x86 version of the app (if available) is downloaded to users’ PCs.</span></span>

<span data-ttu-id="ed1bf-120">UWP アプリに使用可能な .NET API について詳しくは、「[UWP アプリの .NET](https://msdn.microsoft.com/library/windows/apps/mt185501.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-120">For more info on .NET APIs available for UWP apps, see [.NET for UWP apps](https://msdn.microsoft.com/library/windows/apps/mt185501.aspx)</span></span>

### <a name="compiling-an-app-with-an-older-version-of-visual-studio-and-sdk"></a><span data-ttu-id="ed1bf-121">以前のバージョンの Visual Studio と SDK を使ったアプリのコンパイル</span><span class="sxs-lookup"><span data-stu-id="ed1bf-121">Compiling an app with an older version of Visual Studio and SDK</span></span>
<span data-ttu-id="ed1bf-122">問題が発生した場合、最新バージョンの Microsoft Visual Studio と Windows SDK を使ってアプリをコンパイルしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-122">If you're running into issues, be sure to use the latest versions of Microsoft Visual Studio and the Windows SDK to compile your app.</span></span> <span data-ttu-id="ed1bf-123">以前のバージョンの Visual Studio と SDK でコンパイルされたアプリでは、以降のバージョンで修正された問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-123">Apps compiled with an earlier version of Visual Studio and the SDK may have issues that have been fixed in later versions.</span></span>

## <a name="debugging"></a><span data-ttu-id="ed1bf-124">デバッグ</span><span class="sxs-lookup"><span data-stu-id="ed1bf-124">Debugging</span></span>
<span data-ttu-id="ed1bf-125">ARM プラットフォーム向けのアプリを開発するため、既存のツールを使用できます。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-125">You can use existing tools for developing apps for the ARM platform.</span></span> <span data-ttu-id="ed1bf-126">便利なリソースを次に示します。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-126">Here are some helpful resources.</span></span>

- <span data-ttu-id="ed1bf-127">Visual Studio 15.5 Preview 1 以降では、ユニバーサル認証モードを使った ARM32 アプリの実行がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-127">Visual Studio 15.5 Preview 1 and later supports running ARM32 apps by using Universal Authentication mode.</span></span> <span data-ttu-id="ed1bf-128">これにより、必要なリモート デバッグ ツールが自動的にブートストラップされます。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-128">This automatically bootstraps the necessary remote debugging tools.</span></span>
- <span data-ttu-id="ed1bf-129">ARM でデバッグを行うためのツールと戦略について詳しくは、[ARM64 でのデバッグに関するページ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed1bf-129">See [Debugging on ARM64](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64) to learn more about tools and strategies for debugging on ARM.</span></span>
