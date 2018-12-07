---
title: サイド ローディングされた UWP アプリのための Windows ランタイム コンポーネント ブローカー
description: このホワイト ペーパーでは、タッチ対応の .NET アプリの主要なビジネス クリティカルな操作を担当する既存のコードを使用できる windows 10 でサポートされているエンタープライズ対象の機能について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 81b3930c-6af9-406d-9d1e-8ee6a13ec38a
ms.localizationpriority: medium
ms.openlocfilehash: d9665ba3af10091ddc652198d5340e00456a65a7
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8796161"
---
# <a name="brokered-windows-runtime-components-for-a-side-loaded-uwp-app"></a><span data-ttu-id="6ebbe-104">サイド ローディングされた UWP アプリのための Windows ランタイム コンポーネント ブローカー</span><span class="sxs-lookup"><span data-stu-id="6ebbe-104">Brokered Windows Runtime Components for a side-loaded UWP app</span></span>

<span data-ttu-id="6ebbe-105">この記事では、タッチ対応の .NET アプリの主要なビジネス クリティカルな操作を担当する既存のコードを使用できる windows 10 でサポートされているエンタープライズ対象の機能について説明します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-105">This article discusses an enterprise-targeted feature supported by Windows10, which allows touch-friendly .NET apps to use the existing code responsible for key business-critical operations.</span></span>

## <a name="introduction"></a><span data-ttu-id="6ebbe-106">はじめに</span><span class="sxs-lookup"><span data-stu-id="6ebbe-106">Introduction</span></span>

><span data-ttu-id="6ebbe-107">**注:**[Visual Studio 2015 および 2017](https://aka.ms/brokeredsample)のこのホワイト ペーパーで取り上げるサンプル コードをダウンロードすることができます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-107">**Note**The sample code that accompanies this paper may be downloaded for[Visual Studio 2015 & 2017](https://aka.ms/brokeredsample).</span></span> <span data-ttu-id="6ebbe-108">Windows ランタイム コンポーネント ブローカーをビルドするための Microsoft Visual Studio テンプレートは、「[Visual Studio 2015 template targeting Universal Windows Apps for Windows 10](https://visualstudiogallery.msdn.microsoft.com/10be07b3-67ef-4e02-9243-01b78cd27935)」(Windows 10 用のユニバーサル Windows アプリをターゲットとする Visual Studio 2015 テンプレート) でダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-108">The Microsoft Visual Studio template to build Brokered Windows Runtime Components can be downloaded here: [Visual Studio 2015 template targeting Universal Windows Apps for Windows 10](https://visualstudiogallery.msdn.microsoft.com/10be07b3-67ef-4e02-9243-01b78cd27935)</span></span>

<span data-ttu-id="6ebbe-109">Windows には、*サイドロード アプリケーションの Windows ランタイム コンポーネント ブローカー*と呼ばれる新しい機能が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-109">Windows includes a new feature called*Brokered Windows Runtime Components for side-loaded applications*.</span></span> <span data-ttu-id="6ebbe-110">既存のデスクトップ ソフトウェア資産を 1 つのプロセス (デスクトップ コンポーネント) 内で実行しつつ、UWP アプリからこのコードとやり取りできるようにする機能は、IPC (プロセス間通信) と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-110">We use the term IPC (inter-process communication) to describe the ability to run existing desktop software assets in one process (desktop component) while interacting with this code in a UWP App.</span></span> <span data-ttu-id="6ebbe-111">これはエンタープライズ開発者には馴染みのあるモデルです。同様のマルチプロセス アーキテクチャは、データベース アプリケーションや、Windows で NT サービスを利用するアプリケーションでも使用されているためです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-111">This is a familiar model to enterprise developers as database applications and applications utilizing NT Services in Windows share a similar multi-process architecture.</span></span>

<span data-ttu-id="6ebbe-112">アプリのサイドローディングは、この機能を構成する重要な要素です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-112">Side-loading of the app is a critical component of this feature.</span></span>
<span data-ttu-id="6ebbe-113">エンタープライズ独自のアプリケーションは、一般的なコンシューマー向け Microsoft Store に公開することはできません。各企業には、セキュリティ、プライバシー、配布、セットアップ、サービス提供に関して固有の要件があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-113">Enterprise-specific applications have no place in the general consumer Microsoft Store and corporations have very specific requirements around security, privacy, distribution, setup, and servicing.</span></span> <span data-ttu-id="6ebbe-114">したがって、サイドローディング モデルは、この機能を使うユーザーの要件であり、重要な実装の構成要素でもあります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-114">As such, the side-loading model is both a requirement of those who would use this feature and a critical implementation detail.</span></span>

<span data-ttu-id="6ebbe-115">このアプリケーション アーキテクチャが主に対象としているのが、データ中心のアプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-115">Data-centric applications are a key target for this application architecture.</span></span> <span data-ttu-id="6ebbe-116">たとえば SQL Server に格納されている既存のビジネス ルールは、デスクトップ コンポーネントの共通の構成要素になります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-116">It is envisioned that existing business rules ensconced, for example, in SQL Server, will be a common part of the desktop component.</span></span> <span data-ttu-id="6ebbe-117">デスクトップ コンポーネントが提供できるのは、この種類の機能だけではありません。この機能に対する要求のほとんどが既存のデータとビジネス ロジックに関連していることは確かなことです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-117">This is certainly not the only type of functionality that can be proffered by the desktop component, but a large part of the demand for this feature is related to existing data and business logic.</span></span>

<span data-ttu-id="6ebbe-118">最後に、エンタープライズ開発では .NET ランタイムと C\# 言語の普及が圧倒的に進んでいることから、この機能は、UWP アプリとデスクトップ コンポーネントの両方で .NET を使うことを重視して開発されています。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-118">Lastly, given the overwhelming penetration of the .NET runtime and the C\# language in enterprise development, this feature was developed with an emphasis on using .NET for both the UWP app and the desktop component sides.</span></span> <span data-ttu-id="6ebbe-119">UWP アプリで使用できる言語やランタイムは他にもありますが、関連するサンプルでは C\# のみを取り上げ、.NET ランタイムのみに制限しています。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-119">While there are other languages and runtimes possible for the UWP app, the accompanying sample only illustrates C\#, and is restricted to the .NET runtime exclusively.</span></span>

## <a name="application-components"></a><span data-ttu-id="6ebbe-120">アプリケーション コンポーネント</span><span class="sxs-lookup"><span data-stu-id="6ebbe-120">Application components</span></span>

><span data-ttu-id="6ebbe-121">**注:** この機能は、専用の .NET を使用します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-121">**Note**This feature is exclusively for the use of .NET.</span></span> <span data-ttu-id="6ebbe-122">クライアント アプリとデスクトップ コンポーネントの両方が、.NET を使って作成されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-122">Both client app and the desktop component must be authored using .NET.</span></span>

**<span data-ttu-id="6ebbe-123">アプリケーション モデル</span><span class="sxs-lookup"><span data-stu-id="6ebbe-123">Application model</span></span>**

<span data-ttu-id="6ebbe-124">この機能は、MVVM (モデル ビュー ビュー モデル) と呼ばれる一般的なアプリケーション アーキテクチャを中心に構築されています。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-124">This feature is built around the general application architecture known as MVVM (Model View View-Model).</span></span> <span data-ttu-id="6ebbe-125">また、"モデル" は完全にデスクトップ コンポーネントに含まれると見なされます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-125">As such, it is assumed that the "model" is housed entirely in the desktop component.</span></span> <span data-ttu-id="6ebbe-126">したがって、デスクトップ コンポーネントが "ヘッドレス" になる (UI が含まれない) ことは明らかです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-126">Therefore, it should be immediately obvious that the desktop component will be "headless" (i.e. contains no UI).</span></span> <span data-ttu-id="6ebbe-127">ビューは、サイドロードされたエンタープライズ アプリケーションに完全に含まれます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-127">The view will be entirely contained in the side-loaded enterprise application.</span></span> <span data-ttu-id="6ebbe-128">このアプリケーションを "ビュー モデル" 構造で構築しなければならないという要件はありませんが、このパターンを使うのが一般的とされます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-128">While there is no requirement that this application be built with the "view-model" construct, we anticipate that usage of this pattern will be common.</span></span>

**<span data-ttu-id="6ebbe-129">デスクトップ コンポーネント</span><span class="sxs-lookup"><span data-stu-id="6ebbe-129">Desktop component</span></span>**

<span data-ttu-id="6ebbe-130">この機能のデスクトップ コンポーネントは、この機能の一部として導入された新しい種類のアプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-130">The desktop component in this feature is a new application type being introduced as part of this feature.</span></span> <span data-ttu-id="6ebbe-131">このデスクトップ コンポーネントは C\# でのみ記述でき、Windows 10 用の .NET 4.6 以降をターゲットとする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-131">This desktop component can only be written in C\# and must target .NET 4.6 or greater for Windows 10.</span></span> <span data-ttu-id="6ebbe-132">プロジェクトの種類は、UWP をターゲットとする CLR のハイブリッドで、プロセス間通信の形式は UWP の型とクラスで構成されます。一方、デスクトップ コンポーネントは、.NET ランタイム クラス ライブラリのすべてを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-132">The project type is a hybrid between the CLR targeting UWP as the inter-process communication format comprises UWP types and classes, while the desktop component is allowed to call all parts of the .NET runtime class library.</span></span> <span data-ttu-id="6ebbe-133">Visual Studio プロジェクトに対する影響については、後で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-133">The impact on the Visual Studio project will be described in detail later.</span></span> <span data-ttu-id="6ebbe-134">このハイブリッド構成により、デスクトップ コンポーネントに構築されたアプリケーションとの間で UWP の型をマーシャリングしながら、デスクトップ CLR コードをデスクトップ コンポーネントの実装内で呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-134">This hybrid configuration allows marshaling UWP types between the application built on the desktop components while allowing desktop CLR code to be called inside the desktop component implementation.</span></span>

**<span data-ttu-id="6ebbe-135">コントラクト</span><span class="sxs-lookup"><span data-stu-id="6ebbe-135">Contract</span></span>**

<span data-ttu-id="6ebbe-136">サイドロード アプリケーションとデスクトップ コンポーネントの間のコントラクトは、UWP 型システムの観点から記述されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-136">The contract between the side-loaded application and the desktop component is described in terms of the UWP type system.</span></span> <span data-ttu-id="6ebbe-137">これには、UWP を表すことができる 1 つ以上の C\# クラスを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-137">This involves declaring one or more C\# classes that can represent a UWP.</span></span> <span data-ttu-id="6ebbe-138">C\# を使って Windows ランタイム クラスを作成する場合の固有の要件については、MSDN のトピック「[C\# および Visual Basic での Windows ランタイム コンポーネントの作成](https://msdn.microsoft.com/library/br230301.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-138">See MSDN topic [Creating Windows Runtime Components in C\# and Visual Basic](https://msdn.microsoft.com/library/br230301.aspx) for specific requirement of creating Windows Runtime Class using C\#.</span></span>

><span data-ttu-id="6ebbe-139">**注:** デスクトップ コンポーネントと、この時点で、サイドロード アプリケーションの間での Windows ランタイム コンポーネント コントラクトでは、列挙型はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-139">**Note**Enums are not supported in the Windows Runtime Components Contract between desktop component and side-loaded application at this time.</span></span>

**<span data-ttu-id="6ebbe-140">サイドロード アプリケーション</span><span class="sxs-lookup"><span data-stu-id="6ebbe-140">Side-loaded application</span></span>**

<span data-ttu-id="6ebbe-141">サイドロード アプリケーションは、Microsoft Store 経由でインストールされるのではなくサイドロードされるという 1 点を除けば、あらゆる点で通常の UWP アプリと変わりません。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-141">The side-loaded application is a normal UWP app in every respect except one: it is side-loaded instead of installed via the Microsoft Store.</span></span> <span data-ttu-id="6ebbe-142">インストール メカニズムのほとんどは同じであり、マニフェストとアプリケーションのパッケージも似ています (マニフェストには追加点が 1 つありますが、これについては後で詳しく説明します)。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-142">Most of the installation mechanisms are identical: the manifest and application packaging are similar (one addition to the manifest is described in detail later).</span></span> <span data-ttu-id="6ebbe-143">いったんサイドローディングを有効にしたら、簡単な PowerShell スクリプトで、必要な証明書とアプリケーション自体をインストールできます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-143">Once side-loading is enabled, a simple PowerShell script can install the necessary certificates and the application itself.</span></span> <span data-ttu-id="6ebbe-144">一般的なベスト プラクティスとして、サイドロード アプリケーションでは、Visual Studio の [プロジェクト] メニューの [ストア] に含まれる WACK 認定テストを実行することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-144">It is the normal best practice that the side-loaded application passes the WACK certification test that is included in the Project / Store menu in Visual Studio</span></span>

><span data-ttu-id="6ebbe-145">**注:** サイドローディングを設定で有効にできる&gt;更新とセキュリティ&gt;開発者向けです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-145">**Note**Side-loading can be turned on in Settings-&gt; Update & security -&gt; For developers.</span></span>

<span data-ttu-id="6ebbe-146">重要な点として、Windows 10 に搭載されているアプリ ブローカー メカニズムは 32 ビット専用であることに注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-146">One important point to note is that the App Broker mechanism shipped as part of Windows 10 is 32-bit only.</span></span> <span data-ttu-id="6ebbe-147">デスクトップ コンポーネントは 32 ビットである必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-147">The desktop component must be 32-bit.</span></span>
<span data-ttu-id="6ebbe-148">サイドロード アプリケーションは 64 ビットにできますが (64 ビットと 32 ビットの両方のプロキシが登録されている場合)、これは特殊なアプリケーションになります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-148">Side-loaded applications can be 64-bit (provided there is both a 64-bit and 32-bit proxies registered), but this will be atypical.</span></span> <span data-ttu-id="6ebbe-149">サイドロードされるアプリケーションを、通常の "ニュートラル" 構成と "32 ビットを優先" の既定値を使って C\# でビルドすると、必然的に 32 ビットのサイドロード アプリケーションが作成されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-149">Building the side-loaded application in C\# using the normal "neutral" configuration and the "prefer 32-bit" default naturally creates 32-bit side-loaded applications.</span></span>

**<span data-ttu-id="6ebbe-150">サーバーのインスタンス化と AppDomain</span><span class="sxs-lookup"><span data-stu-id="6ebbe-150">Server instancing and AppDomains</span></span>**

<span data-ttu-id="6ebbe-151">サイドロードされたアプリケーションはそれぞれ、アプリ ブローカー サーバーの独自のインスタンスを受け取ります (いわゆる "マルチインスタンス化" が行われます)。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-151">Each sided-loaded application receives its own instance of an App Broker server (so-called "multi-instancing").</span></span> <span data-ttu-id="6ebbe-152">サーバー コードは、1 つの AppDomain 内で実行されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-152">The server code runs inside of a single AppDomain.</span></span> <span data-ttu-id="6ebbe-153">これにより、複数のバージョンのライブラリを個別のインスタンスで実行できます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-153">This allows for having multiple version of libraries run in separate instances.</span></span> <span data-ttu-id="6ebbe-154">たとえば、アプリケーション A には V1.1 のコンポーネントが必要で、アプリケーション B には V2 が必要であるとします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-154">For example, application A needs V1.1 of a component and application B needs V2.</span></span> <span data-ttu-id="6ebbe-155">これを明確に区別するには、V1.1 コンポーネントと V2 コンポーネントをそれぞれ別のサーバー ディレクトリに分けて、各アプリケーションが、必要なバージョンをサポートするサーバーに接続するように指定します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-155">These are cleanly separated by having V1.1 and V2 components in separate server directories and pointing the application to whichever server supports the correct version desired.</span></span>

<span data-ttu-id="6ebbe-156">サーバー コードの実装を複数のアプリ ブローカー サーバー インスタンスで共有するには、複数のアプリケーションが同じサーバー ディレクトリに接続するように指定します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-156">Server code implementation can be shared amongst multiple App Broker server instance by pointing multiple applications to the same server directory.</span></span> <span data-ttu-id="6ebbe-157">それでもアプリ ブローカー サーバーのインスタンスは複数存在することになりますが、各インスタンスでは同じコードが実行されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-157">There will still be multiple instances of the App Broker server but they will be running identical code.</span></span> <span data-ttu-id="6ebbe-158">1 つのアプリケーションで使われる実装コンポーネントはすべて、同じパスに存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-158">All implementation components used in a single application should be present in the same path.</span></span>

## <a name="defining-the-contract"></a><span data-ttu-id="6ebbe-159">コントラクトの定義</span><span class="sxs-lookup"><span data-stu-id="6ebbe-159">Defining the contract</span></span>

<span data-ttu-id="6ebbe-160">この機能を使ってアプリケーションを作成するには、まず、サイドロード アプリケーションとデスクトップ コンポーネントの間のコントラクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-160">The first step in creating an application using this feature is to create the contract between the side-loaded application and the desktop component.</span></span> <span data-ttu-id="6ebbe-161">これは、Windows ランタイム型だけを使用して行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-161">This must be done exclusively using Windows Runtime types.</span></span>
<span data-ttu-id="6ebbe-162">これらは C\# クラスを使って簡単に宣言できます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-162">Fortunately, these are easy to declare using C\# classes.</span></span> <span data-ttu-id="6ebbe-163">ただし、このような通信を定義するときは、パフォーマンスについて考慮することが重要です。これについては後で説明します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-163">There are important performance considerations, however, when defining these conversations, which is covered in a later section.</span></span>

<span data-ttu-id="6ebbe-164">コントラクトを定義する流れは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-164">The sequence to define the contract is introduced as following:</span></span>

<span data-ttu-id="6ebbe-165">**手順 1:** Visual Studio で新しいクラス ライブラリを作成します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-165">**Step 1:** Create a new class library in Visual Studio.</span></span> <span data-ttu-id="6ebbe-166">プロジェクトの作成時には、Windows ランタイム コンポーネント テンプレートではなく、クラス ライブラリ テンプレートを使います。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-166">Make sure to create the project using Class Library template not Windows Runtime Component template</span></span>

<span data-ttu-id="6ebbe-167">この後には実装が続きますが、このセクションでは、プロセス間のコントラクトの定義についてのみ説明します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-167">An implementation obviously follows, but this section is only covering the definition of the inter-process contract.</span></span> <span data-ttu-id="6ebbe-168">関連するサンプルには次のクラス (EnterpriseServer.cs) が含まれ、先頭部分は次のようになっています。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-168">The accompanying sample includes the following class (EnterpriseServer.cs), the beginning shape of which looks like:</span></span>

```csharp
namespace Fabrikam
{
    public sealed class EnterpriseServer
    {

        public ILis<String> TestMethod(String input)
        {
            throw new NotImplementedException();
        }
        
        public IAsyncOperation<int> FindElementAsync(int input)
        {
            throw new NotImplementedException();
        }
        
        public string[] RetrieveData()
        {
            throw new NotImplementedException();
        }
        
        public event EventHandler<string> PeriodicEvent;
    }
}
```

<span data-ttu-id="6ebbe-169">これにより、サイドロード アプリケーションからインスタンス化できる "EnterpriseServer" クラスが定義されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-169">This defines a class "EnterpriseServer" that can be instantiated from the side-loaded application.</span></span> <span data-ttu-id="6ebbe-170">このクラスは、RuntimeClass で保障された機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-170">This class provides the functionality promised in the RuntimeClass.</span></span> <span data-ttu-id="6ebbe-171">RuntimeClass は、サイドロード アプリケーションに含める参照用の winmd を生成するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-171">The RuntimeClass can be used to generate the reference winmd that will be included in the side-loaded application.</span></span>

<span data-ttu-id="6ebbe-172">**手順 2:** プロジェクト ファイルを手動で編集して、プロジェクトの出力の種類を Windows ランタイム コンポーネントに変更します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-172">**Step 2:** Edit the project file manually to change the output type of project to Windows Runtime Component</span></span>

<span data-ttu-id="6ebbe-173">これを Visual Studio で実行するには、新しく作成されたプロジェクトを右クリックし、[プロジェクトのアンロード] を選択します。もう一度右クリックし、[Edit EnterpriseServer.csproj の編集] を選択して、プロジェクト ファイル (XML ファイル) を編集用に開きます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-173">To do this in Visual Studio, right click on the newly created project and select “Unload Project”, then right click again and select “Edit EnterpriseServer.csproj” to open the project file, an XML file, for editing.</span></span>

<span data-ttu-id="6ebbe-174">開かれたファイルで \<OutputType\> タグを検索し、その値を "winmdobj" に変更します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-174">In the opened file, search for the \<OutputType\> tag and change its value to “winmdobj”.</span></span>

<span data-ttu-id="6ebbe-175">**手順 3:** "参照" 用の Windows メタデータ ファイル (.winmd ファイル) を作成するビルド規則を作ります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-175">**Step 3:** Create a build rule that creates a "reference" Windows metadata file (.winmd file).</span></span> <span data-ttu-id="6ebbe-176">つまり、実装は含まれません。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-176">i.e. has no implementation.</span></span>

<span data-ttu-id="6ebbe-177">**手順 4:** "実装" 用の Windows メタデータ ファイルを作成するビルド規則を作ります。つまり、同じメタデータ情報に加えて、実装も含まれます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-177">**Step 4:** Create a build rule that creates an "implementation" Windows metadata file, i.e. has the same metadata information, but also includes the implementation.</span></span>

<span data-ttu-id="6ebbe-178">これは次のスクリプトによって実行されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-178">This will is done by the following scripts.</span></span> <span data-ttu-id="6ebbe-179">プロジェクトの **[プロパティ]** > **[ビルド イベント]** で、ビルド後のイベントのコマンド ラインにこれらのスクリプトを追加します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-179">Add the scripts to the Post-build event command line, in project **Properties** > **Build Events**.</span></span>

> <span data-ttu-id="6ebbe-180">**注** このスクリプトは、ターゲットとする Windows のバージョン (Windows 10) と、使用中の Visual Studio のバージョンによって異なります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-180">**Note** the script is different based on the version of Windows you are targeting (Windows 10) and the version of Visual Studio in use.</span></span>

**<span data-ttu-id="6ebbe-181">Visual Studio 2015</span><span class="sxs-lookup"><span data-stu-id="6ebbe-181">Visual Studio 2015</span></span>**
```cmd
    call "$(DevEnvDir)..\..\vc\vcvarsall.bat" x86 10.0.14393.0

    md "$(TargetDir)"\impl    md "$(TargetDir)"\reference

    erase "$(TargetDir)\impl\*.winmd"
    erase "$(TargetDir)\impl\*.pdb"
    rem erase "$(TargetDir)\reference\*.winmd"

    xcopy /y "$(TargetPath)" "$(TargetDir)impl"
    xcopy /y "$(TargetDir)*.pdb" "$(TargetDir)impl"

    winmdidl /nosystemdeclares /metadata_dir:C:\Windows\System32\Winmetadata "$(TargetPath)"

    midl /metadata_dir "%WindowsSdkDir%UnionMetadata" /iid "$(SolutionDir)BrokeredProxyStub\$(TargetName)_i.c" /env win32 /x86 /h   "$(SolutionDir)BrokeredProxyStub\$(TargetName).h" /winmd "$(TargetName).winmd" /W1 /char signed /nologo /winrt /dlldata "$(SolutionDir)BrokeredProxyStub\dlldata.c" /proxy "$(SolutionDir)BrokeredProxyStub\$(TargetName)_p.c"  "$(TargetName).idl"
    mdmerge -n 1 -i "$(ProjectDir)bin\$(ConfigurationName)" -o "$(TargetDir)reference" -metadata_dir "%WindowsSdkDir%UnionMetadata" -partial

    rem erase "$(TargetPath)"

```


**<span data-ttu-id="6ebbe-182">Visual Studio 2017</span><span class="sxs-lookup"><span data-stu-id="6ebbe-182">Visual Studio 2017</span></span>**
```cmd
    call "$(DevEnvDir)..\..\vc\auxiliary\build\vcvarsall.bat" x86 10.0.16299.0

    md "$(TargetDir)"\impl
    md "$(TargetDir)"\reference

    erase "$(TargetDir)\impl\*.winmd"
    erase "$(TargetDir)\impl\*.pdb"
    rem erase "$(TargetDir)\reference\*.winmd"

    xcopy /y "$(TargetPath)" "$(TargetDir)impl"
    xcopy /y "$(TargetDir)*.pdb" "$(TargetDir)impl"

    winmdidl /nosystemdeclares /metadata_dir:C:\Windows\System32\Winmetadata "$(TargetPath)"

    midl /metadata_dir "%WindowsSdkDir%UnionMetadata" /iid "$(SolutionDir)BrokeredProxyStub\$(TargetName)_i.c" /env win32 /x86 /h "$(SolutionDir)BrokeredProxyStub\$(TargetName).h" /winmd "$(TargetName).winmd" /W1 /char signed /nologo /winrt /dlldata "$(SolutionDir)BrokeredProxyStub\dlldata.c" /proxy "$(SolutionDir)BrokeredProxyStub\$(TargetName)_p.c"  "$(TargetName).idl"
    mdmerge -n 1 -i "$(ProjectDir)bin\$(ConfigurationName)" -o "$(TargetDir)reference" -metadata_dir "%WindowsSdkDir%UnionMetadata" -partial

    rem erase "$(TargetPath)"
```

<span data-ttu-id="6ebbe-183">参照**用の winmd**1 回が作成されます ([フォルダー、プロジェクトのターゲット フォルダーの下には、「参照」) が手動で各使用するサイドロード アプリケーション プロジェクトに転送 (コピー) され、参照します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-183">Once the reference**winmd**is created (in folder “reference” under the project’s Target folder), it is hand carried (copied) to each consuming side-loaded application project and referenced.</span></span> <span data-ttu-id="6ebbe-184">これについては、次のセクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-184">This will be described further in the next section.</span></span> <span data-ttu-id="6ebbe-185">上のビルド規則で使われているプロジェクト構造確実に実装して、参照**用の winmd**が混乱を避けるためビルド階層内のディレクトリを明確に分離します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-185">The project structure embodied in the build rules above ensure that the implementation and the reference**winmd**are in clearly segregated directories in the build hierarchy to avoid confusion.</span></span>

## <a name="side-loaded-applications-in-detail"></a><span data-ttu-id="6ebbe-186">サイドロード アプリケーションの詳細</span><span class="sxs-lookup"><span data-stu-id="6ebbe-186">Side-loaded applications in detail</span></span>
<span data-ttu-id="6ebbe-187">既に説明したとおり、サイドロード アプリケーションは他の UWP アプリと同じようにビルドされますが、追加の作業が 1 つあります。つまり、サイドロード アプリケーションのマニフェストで、RuntimeClass の利用を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-187">As stated previously, the side-loaded application is built like any other UWP app, but there is one additional detail: declaring the availability of the RuntimeClass (es) in the side-loaded application's manifest.</span></span> <span data-ttu-id="6ebbe-188">これにより、アプリケーションでは、new 演算子を記述するだけでデスクトップ コンポーネントの機能にアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-188">This allows the application to simply write new to access the functionality in the desktop component.</span></span> <span data-ttu-id="6ebbe-189"><Extension> セクション内の新しいマニフェスト エントリに、デスクトップ コンポーネントで実装される RuntimeClass とその場所に関する情報を記述します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-189">A new manifest entry in the <Extension> section describes the RuntimeClass implemented in the desktop component and information on where it is located.</span></span> <span data-ttu-id="6ebbe-190">これらを宣言するアプリケーション マニフェスト内のコンテンツは、Windows 10 をターゲットとするアプリと同じです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-190">These declaration content in application’s manifest is the same for apps targeting Windows 10.</span></span> <span data-ttu-id="6ebbe-191">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-191">For example:</span></span>

```XML
<Extension Category="windows.activatableClass.inProcessServer">
    <InProcessServer>
        <Path>clrhost.dll</Path>
        <ActivatableClass ActivatableClassId="Fabrikam.EnterpriseServer" ThreadingModel="both">
            <ActivatableClassAttribute Name="DesktopApplicationPath" Type="string" Value="c:\test" />
        </ActivatableClass>
    </InProcessServer>
</Extension>
```

<span data-ttu-id="6ebbe-192">カテゴリは inProcessServer です。outOfProcessServer カテゴリには、このアプリケーション構成に適用できないエントリが複数あるためです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-192">The category is inProcessServer because there are several entries in the outOfProcessServer category that are not applicable to this application configuration.</span></span> <span data-ttu-id="6ebbe-193">注意、<Path>コンポーネントが clrhost.dll を含める必要があります常に (ただし現時点では**ない**適用され、別の値を指定することは未定義の方法で失敗します)。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-193">Note that the <Path> component must always contain clrhost.dll (however this is**not**enforced and specifying a different value will fail in undefined ways).</span></span>

<span data-ttu-id="6ebbe-194"><ActivatableClass> セクションは、アプリ パッケージ内の Windows ランタイム コンポーネントによって優先される実際のインプロセス RuntimeClass と同じです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-194">The <ActivatableClass> section is the same as a true in-process RuntimeClass preferred by a Windows Runtime component in the app's package.</span></span> <ActivatableClassAttribute> <span data-ttu-id="6ebbe-195"> は新しい要素であり、Name="DesktopApplicationPath" 属性と Type="string" 属性は必須かつ不変です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-195">is a new element, and the attributes Name="DesktopApplicationPath" and Type="string" are mandatory and invariant.</span></span> <span data-ttu-id="6ebbe-196">Value 属性では、デスクトップ コンポーネントの実装用の winmd の場所を指定します (詳しくは、次のセクションを参照)。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-196">The Value attribute points to the location where the desktop component's implementation winmd resides (more detail on this in the next section).</span></span> <span data-ttu-id="6ebbe-197">デスクトップ コンポーネントによって優先される各 RuntimeClass には、独自の <ActivatableClass> 要素ツリーが必要です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-197">Each RuntimeClass preferred by the desktop component should have its own <ActivatableClass> element tree.</span></span> <span data-ttu-id="6ebbe-198">ActivatableClassId は、RuntimeClass の完全な名前空間修飾名と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-198">The ActivatableClassId must match the fully namespace-qualified name of the RuntimeClass.</span></span>

<span data-ttu-id="6ebbe-199">「コントラクトの定義」で説明したように、プロジェクトの参照先は、デスクトップ コンポーネントの参照用の winmd にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-199">As mentioned in the section "Defining the contract", a project reference must be made to the desktop component's reference winmd.</span></span> <span data-ttu-id="6ebbe-200">Visual Studio のプロジェクト システムでは、通常、同じ名前で 2 レベルのディレクトリ構造が作成されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-200">The Visual Studio project system normally creates a two level directory structure with the same name.</span></span> <span data-ttu-id="6ebbe-201">このサンプルでは、EnterpriseIPCApplication\\EnterpriseIPCApplication になります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-201">In the sample it is EnterpriseIPCApplication\\EnterpriseIPCApplication.</span></span> <span data-ttu-id="6ebbe-202">参照**用の winmd**は、この第 2 レベルのディレクトリとし、ダイアログ ボックスを使用するプロジェクトの参照を手動でコピーされます (クリックして、**参照.** ボタン) を見つけてこの**winmd**を参照します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-202">The reference **winmd**is manually copied to this second level directory and then the Project References dialog is used (click the**Browse..** button) to locate and reference this **winmd**.</span></span> <span data-ttu-id="6ebbe-203">完了すると、デスクトップ コンポーネントの最上位の名前空間 (たとえば Fabrikam) が、プロジェクトの [参照] 部分の最上位ノードとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-203">After this, the top level namespace of the desktop component (e.g. Fabrikam) should appear as a top level node in the References part of the project.</span></span>

><span data-ttu-id="6ebbe-204">**注:\*\*\*\*参照用の winmd**を使用する非常に重要サイドロード アプリケーションでします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-204">**Note** It is very important to use the**reference winmd**in the side-loaded application.</span></span> <span data-ttu-id="6ebbe-205">**実装用の winmd**経由で実行かどうか誤ってアプリのサイド ローディング ディレクトリを参照して、発生する可能性が「IStringable が見つからない」に関連するエラー。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-205">If you accidentally carry over the**implementation winmd**to the side-loaded app directory and reference it, you will likely receive an error related to "cannot find IStringable".</span></span> <span data-ttu-id="6ebbe-206">これは 1 つことを確認する署名間違った**winmd**が参照されています。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-206">This is one sure sign that the wrong**winmd**has been referenced.</span></span> <span data-ttu-id="6ebbe-207">IPC サーバー アプリ (次のセクションで詳細) 慎重にビルド後の規則は、これら 2 つの**winmd**を分離別々 のディレクトリにします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-207">The post-build rules in the IPC server app (detailed in the next section) carefully segregate these two**winmd**into separate directories.</span></span>

<span data-ttu-id="6ebbe-208"><ActivatableClassAttribute Value="path"> では、環境変数 (特に %ProgramFiles%) を使うことができます。既に説明したように、アプリ ブローカーがサポートするのは 32 ビットだけであるため、アプリケーションが 64 ビット OS で実行されている場合、%ProgramFiles% は C:\\Program Files (x86) に解決されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-208">Environment variables (especially %ProgramFiles%) can be used in <ActivatableClassAttribute Value="path"> .As noted earlier, the App Broker only supports 32-bit so %ProgramFiles% will resolve to C:\\Program Files (x86) if the application is run on a 64-bit OS.</span></span>

## <a name="desktop-ipc-server-detail"></a><span data-ttu-id="6ebbe-209">デスクトップ IPC サーバーの詳細</span><span class="sxs-lookup"><span data-stu-id="6ebbe-209">Desktop IPC server detail</span></span>

<span data-ttu-id="6ebbe-210">前の 2 つのセクションは、クラスの宣言と参照**用の winmd**を転送するしくみについて説明します。サイドロード アプリケーション プロジェクトにします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-210">The previous two sections describe declaration of the class and the mechanics of transporting the reference**winmd**to the side-loaded application project.</span></span> <span data-ttu-id="6ebbe-211">デスクトップ コンポーネント側の残りの作業は、ほとんどが実装にかかわるものです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-211">The bulk of the remaining work in the desktop component involves implementation.</span></span> <span data-ttu-id="6ebbe-212">デスクトップ コンポーネントで肝心なのは、デスクトップ コードを呼び出せるようにするという点です (通常は、既にあるコード資産を再利用するのが目的)。このため、プロジェクトは、特別な方法で構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-212">Since the whole point of the desktop component is to be able to call desktop code (usually to re-utilize existing code assets), the project must be configured in a special way.</span></span>
<span data-ttu-id="6ebbe-213">通常、.NET を使う Visual Studio プロジェクトでは、2 つの "プロファイル" のいずれかが使われます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-213">Normally, a Visual Studio project using .NET uses one of two "profiles".</span></span>
<span data-ttu-id="6ebbe-214">1 つはデスクトップ用プロファイル (".NetFramework")、もう 1 つは CLR の UWP アプリ部分をターゲットとするプロファイル (".NetCore") です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-214">One is for desktop (".NetFramework") and one is targeting the UWP app portion of the CLR (".NetCore").</span></span> <span data-ttu-id="6ebbe-215">この機能のデスクトップ コンポーネントは、この 2 つのハイブリッドです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-215">A desktop component in this feature is a hybrid between these two.</span></span> <span data-ttu-id="6ebbe-216">その結果、参照セクションは、これら 2 つのプロファイルがうまく調和するように注意深く構成されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-216">As a result, the references section is very carefully constructed to blend these two profiles.</span></span>

<span data-ttu-id="6ebbe-217">通常の UWP アプリ プロジェクトでは、Windows ランタイム API サーフェス全体が暗黙的に含まれるため、明示的なプロジェクト参照は含まれません。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-217">A normal UWP app project contains no explicit project references because the entirety of the Windows Runtime API surface is implicitly included.</span></span>
<span data-ttu-id="6ebbe-218">通常は、他のプロジェクト間でのみ参照が行われます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-218">Normally only other inter-project references are made.</span></span> <span data-ttu-id="6ebbe-219">これに対してデスクトップ コンポーネント プロジェクトには、きわめて特殊な一連の参照が含まれます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-219">However, a desktop component project has a very special set of references.</span></span> <span data-ttu-id="6ebbe-220">これは "クラシック デスクトップ\\クラス ライブラリ" プロジェクトとして作成されるため、デスクトップ プロジェクトになります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-220">It starts life as a "Classic Desktop\\Class Library" project and therefore is a desktop project.</span></span> <span data-ttu-id="6ebbe-221">Windows ランタイム API を明示的に参照 (への参照**用の winmd**を経由でファイル) 行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-221">So explicit references to the Windows Runtime API (via references to**winmd**files) must be made.</span></span> <span data-ttu-id="6ebbe-222">次に示すように、適切な参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-222">Add proper references as shown below.</span></span>

```XML
<ItemGroup>
    <!-- These reference are added by VS automatically when you create a Class Library project-->
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Net.Http" />
<Reference Include="System.Xml" />
    <!-- These reference should be added manually by editing .csproj file-->

    <Reference Include="System.Runtime.WindowsRuntime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL">
      <HintPath>$(MSBuildProgramFiles32)\Microsoft SDKs\NETCoreSDK\System.Runtime.WindowsRuntime\4.0.10\lib\netcore50\System.Runtime.WindowsRuntime.dll</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows">
      <HintPath>$(MSBuildProgramFiles32)\Windows Kits\10\UnionMetadata\Facade\Windows.WinMD</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Foundation.FoundationContract">
      <HintPath>$(MSBuildProgramFiles32)\Windows Kits\10\References\Windows.Foundation.FoundationContract\1.0.0.0\Windows.Foundation.FoundationContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Foundation.UniversalApiContract">
      <HintPath>$(MSBuildProgramFiles32)\Windows Kits\10\References\Windows.Foundation.UniversalApiContract\1.0.0.0\Windows.Foundation.UniversalApiContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Networking.Connectivity.WwanContract">
      <HintPath>$(MSBuildProgramFiles32)\Windows Kits\10\References\Windows.Networking.Connectivity.WwanContract\1.0.0.0\Windows.Networking.Connectivity.WwanContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Activation.ActivatedEventsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Activation.ActivatedEventsContract\1.0.0.0\Windows.ApplicationModel.Activation.ActivatedEventsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Activation.ActivationCameraSettingsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Activation.ActivationCameraSettingsContract\1.0.0.0\Windows.ApplicationModel.Activation.ActivationCameraSettingsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Activation.ContactActivatedEventsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Activation.ContactActivatedEventsContract\1.0.0.0\Windows.ApplicationModel.Activation.ContactActivatedEventsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Activation.WebUISearchActivatedEventsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Activation.WebUISearchActivatedEventsContract\1.0.0.0\Windows.ApplicationModel.Activation.WebUISearchActivatedEventsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Background.BackgroundAlarmApplicationContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Background.BackgroundAlarmApplicationContract\1.0.0.0\Windows.ApplicationModel.Background.BackgroundAlarmApplicationContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Calls.LockScreenCallContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Calls.LockScreenCallContract\1.0.0.0\Windows.ApplicationModel.Calls.LockScreenCallContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Resources.Management.ResourceIndexerContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Resources.Management.ResourceIndexerContract\1.0.0.0\Windows.ApplicationModel.Resources.Management.ResourceIndexerContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Search.Core.SearchCoreContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Search.Core.SearchCoreContract\1.0.0.0\Windows.ApplicationModel.Search.Core.SearchCoreContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Search.SearchContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Search.SearchContract\1.0.0.0\Windows.ApplicationModel.Search.SearchContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Wallet.WalletContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Wallet.WalletContract\1.0.0.0\Windows.ApplicationModel.Wallet.WalletContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Custom.CustomDeviceContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Custom.CustomDeviceContract\1.0.0.0\Windows.Devices.Custom.CustomDeviceContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Portable.PortableDeviceContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Portable.PortableDeviceContract\1.0.0.0\Windows.Devices.Portable.PortableDeviceContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Printers.Extensions.ExtensionsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Printers.Extensions.ExtensionsContract\1.0.0.0\Windows.Devices.Printers.Extensions.ExtensionsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Printers.PrintersContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Printers.PrintersContract\1.0.0.0\Windows.Devices.Printers.PrintersContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Scanners.ScannerDeviceContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Scanners.ScannerDeviceContract\1.0.0.0\Windows.Devices.Scanners.ScannerDeviceContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Sms.LegacySmsApiContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Sms.LegacySmsApiContract\1.0.0.0\Windows.Devices.Sms.LegacySmsApiContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Gaming.Preview.GamesEnumerationContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Gaming.Preview.GamesEnumerationContract\1.0.0.0\Windows.Gaming.Preview.GamesEnumerationContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Globalization.GlobalizationJapanesePhoneticAnalyzerContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Globalization.GlobalizationJapanesePhoneticAnalyzerContract\1.0.0.0\Windows.Globalization.GlobalizationJapanesePhoneticAnalyzerContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Graphics.Printing3D.Printing3DContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Graphics.Printing3D.Printing3DContract\1.0.0.0\Windows.Graphics.Printing3D.Printing3DContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Management.Deployment.Preview.DeploymentPreviewContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Management.Deployment.Preview.DeploymentPreviewContract\1.0.0.0\Windows.Management.Deployment.Preview.DeploymentPreviewContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Management.Workplace.WorkplaceSettingsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Management.Workplace.WorkplaceSettingsContract\1.0.0.0\Windows.Management.Workplace.WorkplaceSettingsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.Capture.AppCaptureContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.Capture.AppCaptureContract\1.0.0.0\Windows.Media.Capture.AppCaptureContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.Capture.CameraCaptureUIContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.Capture.CameraCaptureUIContract\1.0.0.0\Windows.Media.Capture.CameraCaptureUIContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.Devices.CallControlContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.Devices.CallControlContract\1.0.0.0\Windows.Media.Devices.CallControlContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.MediaControlContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.MediaControlContract\1.0.0.0\Windows.Media.MediaControlContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.Playlists.PlaylistsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.Playlists.PlaylistsContract\1.0.0.0\Windows.Media.Playlists.PlaylistsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.Protection.ProtectionRenewalContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.Protection.ProtectionRenewalContract\1.0.0.0\Windows.Media.Protection.ProtectionRenewalContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Networking.NetworkOperators.LegacyNetworkOperatorsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Networking.NetworkOperators.LegacyNetworkOperatorsContract\1.0.0.0\Windows.Networking.NetworkOperators.LegacyNetworkOperatorsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Networking.Sockets.ControlChannelTriggerContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Networking.Sockets.ControlChannelTriggerContract\1.0.0.0\Windows.Networking.Sockets.ControlChannelTriggerContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Security.EnterpriseData.EnterpriseDataContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Security.EnterpriseData.EnterpriseDataContract\1.0.0.0\Windows.Security.EnterpriseData.EnterpriseDataContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Security.ExchangeActiveSyncProvisioning.EasContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Security.ExchangeActiveSyncProvisioning.EasContract\1.0.0.0\Windows.Security.ExchangeActiveSyncProvisioning.EasContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Services.Maps.GuidanceContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Services.Maps.GuidanceContract\1.0.0.0\Windows.Services.Maps.GuidanceContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Services.Maps.LocalSearchContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Services.Maps.LocalSearchContract\1.0.0.0\Windows.Services.Maps.LocalSearchContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.System.Profile.SystemManufacturers.SystemManufacturersContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.System.Profile.SystemManufacturers.SystemManufacturersContract\1.0.0.0\Windows.System.Profile.SystemManufacturers.SystemManufacturersContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.System.Profile.ProfileHardwareTokenContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.System.Profile.ProfileHardwareTokenContract\1.0.0.0\Windows.System.Profile.ProfileHardwareTokenContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.System.Profile.ProfileRetailInfoContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.System.Profile.ProfileRetailInfoContract\1.0.0.0\Windows.System.Profile.ProfileRetailInfoContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.System.UserProfile.UserProfileContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.System.UserProfile.UserProfileContract\1.0.0.0\Windows.System.UserProfile.UserProfileContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.System.UserProfile.UserProfileLockScreenContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.System.UserProfile.UserProfileLockScreenContract\1.0.0.0\Windows.System.UserProfile.UserProfileLockScreenContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.UI.ApplicationSettings.ApplicationsSettingsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.UI.ApplicationSettings.ApplicationsSettingsContract\1.0.0.0\Windows.UI.ApplicationSettings.ApplicationsSettingsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.UI.Core.AnimationMetrics.AnimationMetricsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.UI.Core.AnimationMetrics.AnimationMetricsContract\1.0.0.0\Windows.UI.Core.AnimationMetrics.AnimationMetricsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.UI.Core.CoreWindowDialogsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.UI.Core.CoreWindowDialogsContract\1.0.0.0\Windows.UI.Core.CoreWindowDialogsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.UI.Xaml.Hosting.HostingContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.UI.Xaml.Hosting.HostingContract\1.0.0.0\Windows.UI.Xaml.Hosting.HostingContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Web.Http.Diagnostics.HttpDiagnosticsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Web.Http.Diagnostics.HttpDiagnosticsContract\1.0.0.0\Windows.Web.Http.Diagnostics.HttpDiagnosticsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
</ItemGroup>
```

<span data-ttu-id="6ebbe-223">上の参照では、このハイブリッド サーバーを適切に動作させるために欠かせない参照が慎重に組み合わされています。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-223">The references above are a careful mix of eferences that are critical to the proper operation of this hybrid server.</span></span> <span data-ttu-id="6ebbe-224">手順としては、(プロジェクトの OutputType を編集する手順で説明したように) .csproj ファイルを開き、これらの参照を必要に応じて追加します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-224">The protocol is to open the .csproj file (as described in how to edit the project OutputType) and add these references as necessary.</span></span>

<span data-ttu-id="6ebbe-225">参照が適切に構成されたら、次は、サーバーの機能を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-225">Once the references are properly configured, the next task is to implement the server's functionality.</span></span> <span data-ttu-id="6ebbe-226">MSDN トピックの「[Windows ランタイム コンポーネント (C \# #/vb/c + + と XAML を使用して UWP アプリ) との相互運用性のベスト プラクティス](https://msdn.microsoft.com/library/windows/apps/hh750311.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-226">See the MSDN topic[Best practices for interoperability with Windows Runtime Components (UWP apps using C\#/VB/C++ and XAML)](https://msdn.microsoft.com/library/windows/apps/hh750311.aspx).</span></span>
<span data-ttu-id="6ebbe-227">この作業では、実装の一部として、デスクトップ コードを呼び出すことができる Windows ランタイム コンポーネント dll を作成します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-227">The task is to create a Windows Runtime component dll that is able to call desktop code as part of its implementation.</span></span> <span data-ttu-id="6ebbe-228">関連するサンプルには、Windows ランタイムで使われる主なパターンが含まれます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-228">The accompanying sample includes the major patterns used in Windows Runtime:</span></span>

-   <span data-ttu-id="6ebbe-229">メソッド呼び出し</span><span class="sxs-lookup"><span data-stu-id="6ebbe-229">Method calls</span></span>

-   <span data-ttu-id="6ebbe-230">デスクトップ コンポーネントによる Windows ランタイム イベント ソース</span><span class="sxs-lookup"><span data-stu-id="6ebbe-230">Windows Runtime Events sources by the desktop component</span></span>

-   <span data-ttu-id="6ebbe-231">Windows ランタイムの非同期操作</span><span class="sxs-lookup"><span data-stu-id="6ebbe-231">Windows Runtime Async operations</span></span>

-   <span data-ttu-id="6ebbe-232">基本的な種類の配列を返す</span><span class="sxs-lookup"><span data-stu-id="6ebbe-232">Returning arrays of basic types</span></span>

**<span data-ttu-id="6ebbe-233">インストール</span><span class="sxs-lookup"><span data-stu-id="6ebbe-233">Install</span></span>**

<span data-ttu-id="6ebbe-234">アプリをインストールするには、実装**用の winmd**をコピー関連付けられているサイドロード アプリケーションのマニフェストで指定された正しいディレクトリに:<ActivatableClassAttribute>の Value =「パス」します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-234">To install the app, copy the implementation**winmd**to the correct directory specified in the associated side-loaded application's manifest: <ActivatableClassAttribute>'s Value="path".</span></span> <span data-ttu-id="6ebbe-235">また、関連付けられているすべてのサポート ファイルと、プロキシ/スタブ dll もコピーします (後者については後で詳しく説明します)。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-235">Also copy any associated support files and the proxy/stub dll (this latter detail is covered below).</span></span> <span data-ttu-id="6ebbe-236">実装**用の winmd**をコピーに失敗するとをサーバー ディレクトリの場所は、すべてのサイドロード、RuntimeClass で新しいアプリケーションの呼び出しを"クラスは登録されていない"というエラーがスローされます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-236">Failing to copy the implementation**winmd**to the server directory location will cause all of the side-loaded application's calls to new on the RuntimeClass will throw a "class not registered" error.</span></span> <span data-ttu-id="6ebbe-237">プロキシ/スタブをインストールできない (または登録できない) 場合は、すべての呼び出しが戻り値なしで失敗します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-237">Failure to install the proxy/stub (or failure to register) will cause all calls to fail with no return values.</span></span> <span data-ttu-id="6ebbe-238">後者のエラーが**ない場合**がよく表示される例外に関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-238">This latter error is frequently**not**associated with visible exceptions.</span></span>
<span data-ttu-id="6ebbe-239">この構成エラーが原因で発生する例外は、"無効なキャスト" を参照する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-239">If exceptions are observed due to this configuration error, they may refer to "invalid cast".</span></span>

**<span data-ttu-id="6ebbe-240">サーバーの実装に関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="6ebbe-240">Server implementation considerations</span></span>**

<span data-ttu-id="6ebbe-241">デスクトップ Windows ランタイム サーバーは、"ワーカー" または "タスク" に基づいていると考えることができます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-241">The desktop Windows Runtime server can be thought of as "worker" or "task" based.</span></span> <span data-ttu-id="6ebbe-242">サーバーへのすべての呼び出しが UI スレッド以外で動作し、すべてのコードがマルチスレッドに対して安全である必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-242">Every call into the server operates on a non-UI thread and all code must be multi-thread aware and safe.</span></span> <span data-ttu-id="6ebbe-243">また、サイドロード アプリケーションのどの部分が、サーバーの機能を呼び出してしているかも重要です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-243">Which part of the side-loaded application is calling the server's functionality is also important.</span></span> <span data-ttu-id="6ebbe-244">サイドロード アプリケーションでは、実行に時間のかかるコードを UI スレッドから呼び出すことは必ず避けてください。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-244">It is critical to always avoid calling long-running code from any UI thread in the side-loaded application.</span></span> <span data-ttu-id="6ebbe-245">それには、主に次の 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-245">There are two main ways to accomplish this:</span></span>

1.  <span data-ttu-id="6ebbe-246">UI スレッドからサーバーの機能を呼び出す場合、サーバーの公開サーフェス領域および実装では必ず非同期パターンを使います。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-246">If calling server functionality from a UI thread, always use an async pattern in the server's public surface area and implementation.</span></span>

2.  <span data-ttu-id="6ebbe-247">サイドロード アプリケーションのバックグラウンド スレッドからサーバーの機能を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-247">Call the server's functionality from a background thread in the side-loaded application.</span></span>

**<span data-ttu-id="6ebbe-248">サーバーにおける Windows ランタイムの非同期処理</span><span class="sxs-lookup"><span data-stu-id="6ebbe-248">Windows Runtime async in the server</span></span>**

<span data-ttu-id="6ebbe-249">アプリケーション モデルのプロセス間通信の特性を考えると、サーバーを呼び出す場合のオーバーヘッドは、イン プロセスで占有的に実行されるコードよりも大きくなります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-249">Given the cross-process nature of the application model, calls to the server have more overhead than code that runs exclusively in-process.</span></span> <span data-ttu-id="6ebbe-250">一般的に、インメモリの値を返す単純なプロパティを呼び出す操作はすばやく実行できて安全なのは、UI スレッドをブロックする心配がないからです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-250">It is normally safe to call a simple property that returns an in-memory value because it will execute quickly enough that blocking the UI thread is not a concern.</span></span> <span data-ttu-id="6ebbe-251">ただし、どのような種類でも I/O がかかわる呼び出しは (すべてのファイル処理やデータベース検索を含む)、UI スレッドの呼び出しをブロックする可能性があり、無応答が原因でアプリケーションが停止することがあります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-251">However, any call that involves I/O of any sort (this includes all file handling and database retrievals) can potentially block the calling UI thread and cause the application to be terminated due to unresponsiveness.</span></span> <span data-ttu-id="6ebbe-252">さらに、オブジェクトに対するプロパティの呼び出しは、パフォーマンス上の理由から、アプリケーション アーキテクチャとしてはお勧めできません。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-252">In addition, property calls on objects are discouraged in this application architecture for performance reasons.</span></span>
<span data-ttu-id="6ebbe-253">これについては、次のセクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-253">This is covered in more depth in the following section.</span></span>

<span data-ttu-id="6ebbe-254">適切に実装されたサーバーでは、通常、Windows ランタイム非同期パターンを使って、UI スレッドから直接行われた呼び出しが実装されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-254">A properly implemented server will normally implement calls made directly from UI threads via the Windows Runtime async pattern.</span></span> <span data-ttu-id="6ebbe-255">これは、次のパターンに従って実装できます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-255">This can be implemented by following this pattern.</span></span> <span data-ttu-id="6ebbe-256">まずは、宣言です (ここでも、関連するサンプルから)。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-256">First, the declaration (again, from the accompanying sample):</span></span>

```csharp
public IAsyncOperation<int> FindElementAsync(int input)
```

<span data-ttu-id="6ebbe-257">これは整数を返す Windows ランタイム非同期操作を宣言します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-257">This declares a Windows Runtime async operation that returns an integer.</span></span>
<span data-ttu-id="6ebbe-258">非同期操作の実装は、通常、次のような形になります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-258">The implementation of the async operation normally takes the form:</span></span>

```csharp
return Task<int>.Run( () =>
{
    int retval = ...
    // execute some potentially long-running code here 
}).AsAsyncOperation<int>();

```

><span data-ttu-id="6ebbe-259">**注** この実装では、実行に時間がかかる可能性のある他の操作を待機するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-259">**Note** It is common to await some other potentially long running operations while writing the implementation.</span></span> <span data-ttu-id="6ebbe-260">その場合は、**Task.Run**コードを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-260">If so, the**Task.Run**code needs to be declared:</span></span>

```csharp
return Task<int>.Run(async () =>
{
    int retval = ...
    // execute some potentially long-running code here 
    await ... // some other WinRT async operation or Task
}).AsAsyncOperation<int>();
```

<span data-ttu-id="6ebbe-261">この非同期メソッドのクライアントは、他の Windows ランタイム非同期操作と同じようにこの操作を待つことができます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-261">Clients of this async method can await this operation like any other Windows Runtime aysnc operation.</span></span>

**<span data-ttu-id="6ebbe-262">アプリケーション バックグラウンド スレッドからのサーバー機能の呼び出し</span><span class="sxs-lookup"><span data-stu-id="6ebbe-262">Call server functionality from an application background thread</span></span>**

<span data-ttu-id="6ebbe-263">通常、クライアントとサーバーは両方とも同じ組織によって作成されるため、サーバーへのすべての呼び出しをサイドロード アプリケーションのバックグラウンド スレッドから行うというプログラミング手法を採用できます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-263">Since it is typical that both client and server will be written by the same organization, a programming practice can be adopted that all calls to the server will be made by a background thread in the side-loaded application.</span></span> <span data-ttu-id="6ebbe-264">サーバーから 1 つ以上のバッチ データを収集する呼び出しは、バックグラウンド スレッドから直接行うことができます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-264">A direct call that collects one or more batches of data from the server can be made from a background thread.</span></span> <span data-ttu-id="6ebbe-265">結果の取得が完了したら、アプリケーション プロセスのインメモリにあるバッチ データは、一般的に UI スレッドから直接取得できます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-265">When the result(s) are completely retrieved, the batch of data that is in-memory in the application process can usually be directly retrieved from the UI thread.</span></span> <span data-ttu-id="6ebbe-266">C\# オブジェクトはバックグラウンド スレッドと UI スレッドに対する依存性がないため、この種類の呼び出しパターンで特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-266">C\# objects are naturally agile between background threads and UI threads so are especially useful for this kind of calling pattern.</span></span>

## <a name="creating-and-deploying-the-windows-runtime-proxy"></a><span data-ttu-id="6ebbe-267">Windows ランタイム プロキシの作成と展開</span><span class="sxs-lookup"><span data-stu-id="6ebbe-267">Creating and deploying the Windows Runtime proxy</span></span>

<span data-ttu-id="6ebbe-268">IPC アプローチには 2 つのプロセス間の Windows ランタイム インターフェイスのマーシャリングが伴うため、グローバルに登録された Windows ランタイム プロキシとスタブを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-268">Since the IPC approach involves marshaling Windows Runtime interfaces between two processes, a globally registered Windows Runtime proxy and stub must be used.</span></span>

**<span data-ttu-id="6ebbe-269">Visual Studio でのプロキシの作成</span><span class="sxs-lookup"><span data-stu-id="6ebbe-269">Creating the proxy in Visual Studio</span></span>**

<span data-ttu-id="6ebbe-270">作成と登録プロキシとスタブが通常の UWP アプリ パッケージ内で使うためのプロセスは[Windows ランタイム コンポーネントでイベントを発生させる](https://msdn.microsoft.com/library/windows/apps/dn169426.aspx)トピックで説明します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-270">The process for creating and registering proxies and stubs for use inside a regular UWP app package are described in the topic[Raising Events in Windows Runtime Components](https://msdn.microsoft.com/library/windows/apps/dn169426.aspx).</span></span>
<span data-ttu-id="6ebbe-271">この記事で説明されている手順には、アプリケーション パッケージ内でのプロキシ/スタブの登録プロセスが含まれているため、次に示すプロセスよりも複雑です (グローバル登録とは異なります)。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-271">The steps described in this article are more complicated than the process described below because it involves registering the proxy/stub inside the application package (as opposed to registering it globally).</span></span>

<span data-ttu-id="6ebbe-272">**手順 1:** デスクトップ コンポーネント プロジェクトのソリューションを使って、Visual Studio でプロキシ/スタブ プロジェクトを作ります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-272">**Step 1:** Using the solution for the desktop component project, create a Proxy/Stub project in Visual Studio:</span></span>

**<span data-ttu-id="6ebbe-273">ソリューション > [追加] > [新しいプロジェクト] > [Visual C++] > [Win32 コンソール アプリケーション]: [DLL] オプションを選択</span><span class="sxs-lookup"><span data-stu-id="6ebbe-273">Solution > Add > Project > Visual C++ > Win32 Console Select DLL option.</span></span>**

<span data-ttu-id="6ebbe-274">次の手順については、サーバー コンポーネントは**MyWinRTComponent**と呼ばれるものとします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-274">For the steps below, we assume the server component is called**MyWinRTComponent**.</span></span>

<span data-ttu-id="6ebbe-275">**手順 3:** プロジェクトからすべての CPP/H ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-275">**Step 3:** Delete all the CPP/H files from the project.</span></span>

<span data-ttu-id="6ebbe-276">**手順 4:** 前のセクションでは、"コントラクトの定義には、**winmdidl.exe**、**midl.exe**、**mdmerge.exe**、およびなどを実行するビルド後のコマンドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-276">**Step 4:** The previous section "Defining the Contract" contains a Post-Build command that runs**winmdidl.exe**,**midl.exe**,**mdmerge.exe**, and so on.</span></span> <span data-ttu-id="6ebbe-277">このビルド後のコマンドの midl 手順による出力の 1 つから、次の 4 つの重要な出力が生成されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-277">One of the outputs from the midl step of this post-build command generates four important outputs:</span></span>

<span data-ttu-id="6ebbe-278">a) Dlldata.c</span><span class="sxs-lookup"><span data-stu-id="6ebbe-278">a) Dlldata.c</span></span>

<span data-ttu-id="6ebbe-279">b) ヘッダー ファイル (例: MyWinRTComponent.h)</span><span class="sxs-lookup"><span data-stu-id="6ebbe-279">b) A header file (e.g. MyWinRTComponent.h)</span></span>

<span data-ttu-id="6ebbe-280">c) \*\_i.c ファイル (例: MyWinRTComponent\_i.c)</span><span class="sxs-lookup"><span data-stu-id="6ebbe-280">c) A \*\_i.c file (e.g. MyWinRTComponent\_i.c)</span></span>

<span data-ttu-id="6ebbe-281">d) \*\_p.c ファイル (例: MyWinRTComponent\_p.c)</span><span class="sxs-lookup"><span data-stu-id="6ebbe-281">d) A \*\_p.c file (e.g. MyWinRTComponent\_p.c)</span></span>

<span data-ttu-id="6ebbe-282">**手順 5:** これらの生成された 4 つのファイルを "MyWinRTProxy" プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-282">**Step 5:** Add these four generated files to the "MyWinRTProxy" project.</span></span>

<span data-ttu-id="6ebbe-283">**手順 6:** 定義ファイルを"MyWinRTProxy"プロジェクトに追加 **(プロジェクト > 新しい項目の追加 > コード > モジュール定義ファイル**) および更新する内容。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-283">**Step 6:** Add a def file to "MyWinRTProxy" project **(Project > Add New Item > Code > Module-Definition File**) and update the contents to be:</span></span>

<span data-ttu-id="6ebbe-284">LIBRARY MyWinRTComponent.Proxies.dll</span><span class="sxs-lookup"><span data-stu-id="6ebbe-284">LIBRARY MyWinRTComponent.Proxies.dll</span></span>

<span data-ttu-id="6ebbe-285">EXPORTS</span><span class="sxs-lookup"><span data-stu-id="6ebbe-285">EXPORTS</span></span>

<span data-ttu-id="6ebbe-286">DllCanUnloadNow PRIVATE</span><span class="sxs-lookup"><span data-stu-id="6ebbe-286">DllCanUnloadNow PRIVATE</span></span>

<span data-ttu-id="6ebbe-287">DllGetClassObject PRIVATE</span><span class="sxs-lookup"><span data-stu-id="6ebbe-287">DllGetClassObject PRIVATE</span></span>

<span data-ttu-id="6ebbe-288">DllRegisterServer PRIVATE</span><span class="sxs-lookup"><span data-stu-id="6ebbe-288">DllRegisterServer PRIVATE</span></span>

<span data-ttu-id="6ebbe-289">DllUnregisterServer PRIVATE</span><span class="sxs-lookup"><span data-stu-id="6ebbe-289">DllUnregisterServer PRIVATE</span></span>

<span data-ttu-id="6ebbe-290">**手順 7:** "MyWinRTProxy" プロジェクトのプロパティを開きます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-290">**Step 7:** Open properties for the "MyWinRTProxy" project:</span></span>

**<span data-ttu-id="6ebbe-291">[構成プロパティ] > [全般] > [ターゲット名]</span><span class="sxs-lookup"><span data-stu-id="6ebbe-291">Comfiguration Properties > General > Target Name :</span></span>**

<span data-ttu-id="6ebbe-292">MyWinRTComponent.Proxies</span><span class="sxs-lookup"><span data-stu-id="6ebbe-292">MyWinRTComponent.Proxies</span></span>

**<span data-ttu-id="6ebbe-293">[C/C++] > [プリプロセッサの定義] > [追加]</span><span class="sxs-lookup"><span data-stu-id="6ebbe-293">C/C++ > Preprocessor Definitions > Add</span></span>**

<span data-ttu-id="6ebbe-294">"WIN32;\_WINDOWS;REGISTER\_PROXY\_DLL"</span><span class="sxs-lookup"><span data-stu-id="6ebbe-294">"WIN32;\_WINDOWS;REGISTER\_PROXY\_DLL"</span></span>

**<span data-ttu-id="6ebbe-295">[C/C++] > [プリコンパイル済みヘッダー]: [プリコンパイル済みヘッダーを使用しない] を選択</span><span class="sxs-lookup"><span data-stu-id="6ebbe-295">C/C++ > Precompiled Header : Select "Not Using Precompiled Header"</span></span>**

**<span data-ttu-id="6ebbe-296">[リンカー] > [全般] > [インポート ライブラリの無視]: [はい] を選択</span><span class="sxs-lookup"><span data-stu-id="6ebbe-296">Linker > General > Ignore Import Library : Select "Yes"</span></span>**

**<span data-ttu-id="6ebbe-297">[リンカー] > [入力] > [追加の依存ファイル]: rpcrt4.lib、runtimeobject.lib を追加</span><span class="sxs-lookup"><span data-stu-id="6ebbe-297">Linker > Input > Additional Dependencies : Add rpcrt4.lib;runtimeobject.lib</span></span>**

**<span data-ttu-id="6ebbe-298">[リンカー] > [Windows メタデータ] > [Windows メタデータの生成]: [いいえ] を選択</span><span class="sxs-lookup"><span data-stu-id="6ebbe-298">Linker > Windows Metadata > Generate Windows Metadata : Select "No"</span></span>**

<span data-ttu-id="6ebbe-299">**手順 8:** "MyWinRTProxy" プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-299">**Step 8:** Build the "MyWinRTProxy" project.</span></span>

**<span data-ttu-id="6ebbe-300">プロキシの展開</span><span class="sxs-lookup"><span data-stu-id="6ebbe-300">Deploying the proxy</span></span>**

<span data-ttu-id="6ebbe-301">プロキシは、グローバルに登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-301">The proxy must be globally registered.</span></span> <span data-ttu-id="6ebbe-302">最も簡単にこれを行うには、インストール プロセスによってプロキシ dll の DllRegisterServer が呼び出されるようにします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-302">The simplest way to do this is to have your install process call DllRegisterServer on the proxy dll.</span></span> <span data-ttu-id="6ebbe-303">この機能でサポートされるのは x86 用に構築されたサーバーだけなので (つまり 64 ビットはサポートされません)、最もシンプルな構成は、32 ビットのサーバー、32 ビットのプロキシ、32 ビットのサイドロード アプリケーションを使った構成となります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-303">Note that since the feature only supports servers built for x86 (i.e. no 64-bit support), the simplest configuration is to use a 32-bit server, a 32-bit proxy, and a 32-bit side-loaded application.</span></span> <span data-ttu-id="6ebbe-304">プロキシは通常の実装**用の winmd**と一緒に設置されますデスクトップ コンポーネントのします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-304">The proxy normally sits alongside the implementation**winmd**for the desktop component.</span></span>

<span data-ttu-id="6ebbe-305">追加の構成手順を 1 つ実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-305">One additional configuration step must be performed.</span></span> <span data-ttu-id="6ebbe-306">サイドロード プロセスでプロキシを読み込んで実行できるようにうするには、ディレクトリが ALL_APPLICATION_PACKAGES に対して "読み取りと実行" としてマークされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-306">In order for the side-loaded process to load and execute the proxy, the directory must be marked "read / execute" for ALL_APPLICATION_PACKAGES.</span></span> <span data-ttu-id="6ebbe-307">これを行う**icacls.exe**経由でコマンド ライン ツールです。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-307">This is done via the**icacls.exe**command line tool.</span></span> <span data-ttu-id="6ebbe-308">ディレクトリに次のコマンドを実行する必要があります、実装**用の winmd**とプロキシ/スタブ dll が存在します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-308">This command should execute in the directory where the implementation**winmd**and proxy/stub dll resides:</span></span>

*<span data-ttu-id="6ebbe-309">icacls . </span><span class="sxs-lookup"><span data-stu-id="6ebbe-309">icacls .</span></span> <span data-ttu-id="6ebbe-310">/T /grant \*S-1-15-2-1:RX</span><span class="sxs-lookup"><span data-stu-id="6ebbe-310">/T /grant \*S-1-15-2-1:RX</span></span>*

## <a name="patterns-and-performance"></a><span data-ttu-id="6ebbe-311">パターンとパフォーマンス</span><span class="sxs-lookup"><span data-stu-id="6ebbe-311">Patterns and performance</span></span>

<span data-ttu-id="6ebbe-312">プロセス間のトランスポートのパフォーマンスを慎重に監視することは、非常に重要です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-312">It is very important that performance of the cross-process transport be carefully monitored.</span></span> <span data-ttu-id="6ebbe-313">プロセス間の呼び出しのコストは、インプロセスの呼び出しの 2 倍以上です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-313">A cross-process call is at least twice as expensive than an in-process call.</span></span> <span data-ttu-id="6ebbe-314">プロセス間で "頻繁な" 会話をしたり、ビットマップ イメージなどの大きなオブジェクトを繰り返し転送したりすると、アプリケーションのパフォーマンスが予想外に低下し、問題が生じることがあります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-314">Creating "chatty" conversations cross-process or performing repeated transfers of large objects like bitmap images, can cause unexpected and undesirable application performance.</span></span>

<span data-ttu-id="6ebbe-315">次の点を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-315">Here is a non-exhaustive list of things to consider:</span></span>

-   <span data-ttu-id="6ebbe-316">アプリケーションの UI スレッドからサーバーへの同期メソッド呼び出しは常に避けます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-316">Synchronous method calls from application's UI thread to the server should always be avoided.</span></span> <span data-ttu-id="6ebbe-317">メソッドをアプリケーションのバックグラウンド スレッドから呼び出し、必要に応じて CoreWindowDispatcher を使って、結果を UI スレッドに提供します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-317">Call the method from a background thread in the application and then use CoreWindowDispatcher to get the results onto the UI thread if necessary.</span></span>

-   <span data-ttu-id="6ebbe-318">アプリケーションの UI スレッドからの非同期操作の呼び出しは安全ですが、次に説明するパフォーマンス上の問題を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-318">Calling async operations from an application UI thread is safe, but consider the performance problems discussed below.</span></span>

-   <span data-ttu-id="6ebbe-319">結果のバルク転送により、プロセス間の対話が減ります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-319">Bulk transfer of results reduces cross-process chattiness.</span></span> <span data-ttu-id="6ebbe-320">これは通常、Windows ランタイム配列を使って処理されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-320">This is normally performed by using the Windows Runtime Array construct.</span></span>

-   <span data-ttu-id="6ebbe-321">返す*一覧<T>*、*T*から非同期操作またはプロパティ取得されたオブジェクトは、多くのプロセス間の読み取りが発生します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-321">Returning*List<T>* where*T*is an object from an async operation or property fetch, will cause a lot of cross-process chattiness.</span></span> <span data-ttu-id="6ebbe-322">たとえば、返すこと、*一覧&lt;人&gt;* オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-322">For example, assume you return a*List&lt;People&gt;* objects.</span></span> <span data-ttu-id="6ebbe-323">このとき、各反復パスがプロセス間呼び出しになります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-323">Each iteration pass will be a cross-process call.</span></span> <span data-ttu-id="6ebbe-324">各*ユーザー*返されるオブジェクトは、プロキシと各メソッドの呼び出しで表されるまたはその個々 のオブジェクトのプロパティにプロセス間呼び出しになります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-324">Each*People*object returned is represented by a proxy and each call to a method or property on that individual object will result in a cross-process call.</span></span> <span data-ttu-id="6ebbe-325">ように「無害」*一覧&lt;人&gt;* オブジェクト場所*カウント*が大き多数の遅い呼び出しが発生します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-325">So an "innocent"*List&lt;People&gt;* object where*Count*is large will cause a large number of slow calls.</span></span> <span data-ttu-id="6ebbe-326">パフォーマンスを改善するには、コンテンツの構造体を配列に格納してバルク転送します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-326">Better performance results from bulk transfer of structs of the content in an array.</span></span> <span data-ttu-id="6ebbe-327">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-327">For example:</span></span>

```csharp
struct PersonStruct
{
    String LastName;
    String FirstName;
    int Age;
   // etc.
}
```

<span data-ttu-id="6ebbe-328">戻って*personstruct \ [\]* の代わりに*一覧&lt;PersonObject&gt;* します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-328">Then return*PersonStruct\[\]* instead of*List&lt;PersonObject&gt;*.</span></span>
<span data-ttu-id="6ebbe-329">これにより、プロセス間の "ホップ" を 1 回に抑えてすべてのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-329">This gets all the data across in one cross-process "hop"</span></span>

<span data-ttu-id="6ebbe-330">パフォーマンスに関する他のあらゆる考慮事項と同様に、ここでも測定とテストが重要になります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-330">As with all performance considerations, measurement and testing is critical.</span></span> <span data-ttu-id="6ebbe-331">利用統計情報をさまざまな操作に挿入して、所要時間を判断することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-331">Ideally telemetry should be inserted into the various operations to determine how long they take.</span></span> <span data-ttu-id="6ebbe-332">範囲全体を測定することが重要: たとえば、方法は実際にかかる時間をすべての*ユーザー*を利用するサイドロード アプリケーションの特定のクエリのオブジェクトかどうか。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-332">It is important to measure across a range: for example, how long does it actually take to consume all the*People*objects for a particular query in the side-loaded application?</span></span>

<span data-ttu-id="6ebbe-333">変数読み込みテストという手法もあります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-333">Another technique is variable load testing.</span></span> <span data-ttu-id="6ebbe-334">これを行うには、パフォーマンス テストのフックを、変数遅延の負荷をサーバー処理に組み込むアプリケーションに挿入します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-334">This can be done by putting performance test hooks into the application that introduce variable delay loads into the server processing.</span></span> <span data-ttu-id="6ebbe-335">これによりさまざまな負荷と、さまざまなサーバー パフォーマンスに対するアプリケーションの反応をシミュレートできます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-335">This can simulate various kinds of load and the application's reaction to varying server performance.</span></span>
<span data-ttu-id="6ebbe-336">サンプルは、適切な非同期手法を使って時間の遅延をコードに挿入する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-336">The sample illustrates how to put time delays into code using proper async techniques.</span></span> <span data-ttu-id="6ebbe-337">挿入する正確な遅延時間と、その意図的な負荷に含めるランダム化の範囲は、アプリケーションの設計と、そのアプリケーションが実行される予定の環境によって異なります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-337">The exact amount of delay to inject and the range of randomization to put into that artificial load will vary by application design and the anticipated environment in which the application will run.</span></span>

## <a name="development-process"></a><span data-ttu-id="6ebbe-338">開発プロセス</span><span class="sxs-lookup"><span data-stu-id="6ebbe-338">Development process</span></span>

<span data-ttu-id="6ebbe-339">サーバーを変更するときは、以前に実行されていたインスタンスがいずれも実行されていないことを確認することが必要です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-339">When you make changes to the server, it is necessary to make sure any previously running instances are no longer running.</span></span> <span data-ttu-id="6ebbe-340">COM は、最終的にはプロセスを清掃しますが、タイマーによる処理には時間がかかり、反復的な開発では効率的ではありません。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-340">COM will eventually scavenge the process, but the rundown timer takes longer than is efficient for iterative development.</span></span> <span data-ttu-id="6ebbe-341">そのため、前に実行されているインスタンスを強制終了することは、開発中に通常の手順です。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-341">Thus, killing a previously running instance is a normal step during development.</span></span> <span data-ttu-id="6ebbe-342">これには、どの dllhost のインスタンスがサーバーをホストしているかを開発者が追跡する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-342">This requires that the developer keep track of which dllhost instance is hosting the server.</span></span>

<span data-ttu-id="6ebbe-343">サーバー プロセスを見つけて強制終了するには、タスク マネージャーやその他のサード パーティ アプリを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-343">The server process can be found and killed using Task Manager or other third party apps.</span></span> <span data-ttu-id="6ebbe-344">**TaskList.exe**コマンド ライン ツールも含まれていると、柔軟な構文では、たとえば。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-344">The command line tool**TaskList.exe**is also included and has flexible syntax, for example:</span></span>

  
 | **<span data-ttu-id="6ebbe-345">コマンド</span><span class="sxs-lookup"><span data-stu-id="6ebbe-345">Command</span></span>** | **<span data-ttu-id="6ebbe-346">アクション</span><span class="sxs-lookup"><span data-stu-id="6ebbe-346">Action</span></span>** |
 | ------------| ---------- |
 | <span data-ttu-id="6ebbe-347">tasklist</span><span class="sxs-lookup"><span data-stu-id="6ebbe-347">tasklist</span></span> | <span data-ttu-id="6ebbe-348">実行中のすべてのプロセスをほぼ作成時刻の順序で一覧表示します。最後に作成されたプロセスは下の方に表示されます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-348">Lists all the running processes in approximate order of creation time, with the most recently created processes near the bottom.</span></span> |
 | <span data-ttu-id="6ebbe-349">tasklist /FI "IMAGENAME eq dllhost.exe" /M</span><span class="sxs-lookup"><span data-stu-id="6ebbe-349">tasklist /FI "IMAGENAME eq dllhost.exe" /M</span></span> | <span data-ttu-id="6ebbe-350">すべての dllhost.exe インスタンスの情報を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-350">Lists info on all the dllhost.exe instances.</span></span> <span data-ttu-id="6ebbe-351">/M スイッチは、読み込み済みのモジュールを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-351">The /M switch lists the modules that they have loaded.</span></span> |
 | <span data-ttu-id="6ebbe-352">tasklist /FI "PID eq 12564" /M</span><span class="sxs-lookup"><span data-stu-id="6ebbe-352">tasklist /FI "PID eq 12564" /M</span></span> | <span data-ttu-id="6ebbe-353">PID がわかっている場合に dllhost.exe を照会するには、このオプションを使用できます。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-353">You can use this option to query the dllhost.exe if you know its PID.</span></span> |

<span data-ttu-id="6ebbe-354">ブローカー サーバーのモジュールの一覧が*clrhost.dll*を一覧表示する必要があります読み込まれたモジュールの一覧にします。</span><span class="sxs-lookup"><span data-stu-id="6ebbe-354">The module list for a broker server should list*clrhost.dll*in its list of loaded modules.</span></span>

## <a name="resources"></a><span data-ttu-id="6ebbe-355">リソース</span><span class="sxs-lookup"><span data-stu-id="6ebbe-355">Resources</span></span>

-   [<span data-ttu-id="6ebbe-356">Windows 10 および VS 2015 用 WinRT コンポーネント ブローカー プロジェクト テンプレート</span><span class="sxs-lookup"><span data-stu-id="6ebbe-356">Brokered WinRT Component Project Templates for Windows 10 and VS 2015</span></span>](https://visualstudiogallery.msdn.microsoft.com/10be07b3-67ef-4e02-9243-01b78cd27935)

-   [<span data-ttu-id="6ebbe-357">NorthwindRT WinRT コンポーネント ブローカー サンプル</span><span class="sxs-lookup"><span data-stu-id="6ebbe-357">NorthwindRT Brokered WinRT Component Sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=397349)

-   [<span data-ttu-id="6ebbe-358">信頼性の高い Microsoft Store アプリの提供</span><span class="sxs-lookup"><span data-stu-id="6ebbe-358">Delivering reliable and trustworthy Microsoft Store apps</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=393644)

-   [<span data-ttu-id="6ebbe-359">アプリ コントラクトと拡張機能 (Microsoft Store アプリ)</span><span class="sxs-lookup"><span data-stu-id="6ebbe-359">App contracts and extensions (Windows Store apps)</span></span>](https://msdn.microsoft.com/library/windows/apps/hh464906.aspx)

-   [<span data-ttu-id="6ebbe-360">Windows 10 でアプリをサイドロードする方法</span><span class="sxs-lookup"><span data-stu-id="6ebbe-360">How to sideload apps on Windows 10</span></span>](https://msdn.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#GroupPolicy)

-   [<span data-ttu-id="6ebbe-361">企業への UWP アプリの展開</span><span class="sxs-lookup"><span data-stu-id="6ebbe-361">Deploying UWP apps to businesses</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=264770)

