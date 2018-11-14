---
author: stevewhims
Description: Some kinds of apps (multilingual dictionaries, translation tools, etc.) need to override the default behavior of an app bundle, and build resources into the app package instead of having them in separate resource packages. This topic explains how to do that.
title: リソースをリソース パックではなくアプリ パッケージに組み込む
template: detail.hbs
ms.author: stwhi
ms.date: 11/14/2017
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: 61b526cd7aa2da8733457b16dd0487ef4ead9cca
ms.sourcegitcommit: bdc40b08cbcd46fc379feeda3c63204290e055af
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/08/2018
ms.locfileid: "6153224"
---
# <a name="build-resources-into-your-app-package-instead-of-into-a-resource-pack"></a><span data-ttu-id="1dd7a-103">リソースをリソース パックではなくアプリ パッケージに組み込む</span><span class="sxs-lookup"><span data-stu-id="1dd7a-103">Build resources into your app package, instead of into a resource pack</span></span>

<span data-ttu-id="1dd7a-104">一部の種類のアプリ (多言語の辞書、翻訳ツールなど) は、アプリ バンドルの既定の動作をオーバーライドし、別のリソース パッケージ (またはリソース パック) ではなくアプリ パッケージにリソースを組み込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-104">Some kinds of apps (multilingual dictionaries, translation tools, etc.) need to override the default behavior of an app bundle, and build resources into the app package instead of having them in separate resource packages (or resource packs).</span></span> <span data-ttu-id="1dd7a-105">このトピックでは、その方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-105">This topic explains how to do that.</span></span>

<span data-ttu-id="1dd7a-106">既定では、[アプリ バンドル (.appxbundle)](../packaging/packaging-uwp-apps.md) の作成時に、言語、スケール、DirectX 機能レベルに応じた既定のリソースのみがアプリ パッケージに組み込まれます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-106">By default when you build an [app bundle (.appxbundle)](../packaging/packaging-uwp-apps.md), only your default resources for language, scale, and DirectX feature level are built into the app package.</span></span> <span data-ttu-id="1dd7a-107">翻訳済みのリソースおよび既定以外のスケールまたは DirectX 機能レベルに合わせてカスタマイズされたリソースは、リソース パッケージに組み込まれ、それを必要とするデバイスにのみダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-107">Your translated resources&mdash;and your resources tailored for non-default scales and/or DirectX feature levels&mdash;are built into resource packages and they are only downloaded onto devices that need them.</span></span> <span data-ttu-id="1dd7a-108">ユーザーが言語の優先順位がスペイン語に設定されたデバイスを使用して Microsoft Store からアプリを購入する場合、アプリとスペイン語のリソース パッケージのみがダウンロードおよびインストールされます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-108">If a customer is buying your app from the Microsoft Store using a device with a language preference set to Spanish, then only your app plus the Spanish resource package are downloaded and installed.</span></span> <span data-ttu-id="1dd7a-109">同じユーザーが後から **[設定]** で言語の優先順位をフランス語に変更した場合は、アプリのフランス語のリソース パッケージがダウンロードおよびインストールされます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-109">If that same user later changes their language preference to French in **Settings**, then your app's French resource package is downloaded and installed.</span></span> <span data-ttu-id="1dd7a-110">スケールおよび DirectX 機能レベルに対して修飾されたリソースでも同様のことが行われます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-110">Similar things happen with your resources qualified for scale and for DirectX feature level.</span></span> <span data-ttu-id="1dd7a-111">ほとんどのアプリで、この動作は有益な効率性をもたらします。これはまさに開発者とユーザーが*必要としている*ことです。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-111">For the majority of apps, this behavior constitutes a valuable efficiency, and it's exactly what you and the customer *want* to happen.</span></span>

<span data-ttu-id="1dd7a-112">ただし、(**[設定]** からではなく) アプリ内ですぐにユーザーが言語を変更できるようにしている場合、その既定の動作は適切ではありません。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-112">But if your app allows the user to change the language on the fly from within the app (instead of via **Settings**), then that default behavior is not appropriate.</span></span> <span data-ttu-id="1dd7a-113">実際にはすべての言語リソースがアプリと一緒に一度に無条件にダウンロードおよびインストールされ、デバイスに残る必要があります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-113">You actually want all of your language resources to be unconditionally downloaded and installed along with the app one time, and then remain on the device.</span></span> <span data-ttu-id="1dd7a-114">別のリソース パッケージではなく、アプリ パッケージにこれらのリソースをすべて組み込む必要があります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-114">You want to build all of those resources into your app package instead of into separate resource packages.</span></span>

<span data-ttu-id="1dd7a-115">**メモ** アプリ パッケージにリソースを含めると、基本的にアプリのサイズが増加します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-115">**Note** Including resources in an app package essentially increases the size of the app.</span></span> <span data-ttu-id="1dd7a-116">そのため、アプリの特性によりそれが必要とされる場合にのみ実行する価値があります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-116">That's why it's only worth doing if the nature of the app demands it.</span></span> <span data-ttu-id="1dd7a-117">それ以外の場合は、通常のアプリ バンドルを通常どおりにビルドする以外は何も処理を行う必要はありません。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-117">If not, then you don't need to do anything except build a regular app bundle as usual.</span></span>

<span data-ttu-id="1dd7a-118">Visual Studio を構成して、2 つの方法のいずれかでアプリ パッケージにリソースを組み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-118">You can configure Visual Studio to build resources into your app package in one of two ways.</span></span> <span data-ttu-id="1dd7a-119">構成ファイルをプロジェクトに追加するか、またはプロジェクト ファイルを直接編集することができます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-119">You can either add a configuration file to your project, or you can edit your project file directly.</span></span> <span data-ttu-id="1dd7a-120">これらのうち使いやすいオプション、またはビルド システムで最適に機能するオプションを使用してください。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-120">Use whichever of these options you're most comfortable with, or whichever works best with your build system.</span></span>

## <a name="option-1-use-priconfigpackagingxml-to-build-resources-into-your-app-package"></a><span data-ttu-id="1dd7a-121">オプション 1.</span><span class="sxs-lookup"><span data-stu-id="1dd7a-121">Option 1.</span></span> <span data-ttu-id="1dd7a-122">priconfig.packaging.xml を使用して、アプリ パッケージにリソースを組み込む</span><span class="sxs-lookup"><span data-stu-id="1dd7a-122">Use priconfig.packaging.xml to build resources into your app package</span></span>

1. <span data-ttu-id="1dd7a-123">Visual Studio で、新しい項目をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-123">In Visual Studio, add a new item to your project.</span></span> <span data-ttu-id="1dd7a-124">XML ファイルを選択し、ファイルに `priconfig.packaging.xml` という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-124">Choose XML File, and name the file `priconfig.packaging.xml`.</span></span>
2. <span data-ttu-id="1dd7a-125">ソリューション エクスプローラーで、`priconfig.packaging.xml` を選択し、[プロパティ] ウィンドウを確認します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-125">In Solution Explorer, select `priconfig.packaging.xml` and check the Properties window.</span></span> <span data-ttu-id="1dd7a-126">ファイルの [ビルド アクション] を [なし] に設定し、[出力ディレクトリにコピー] を [コピーしない] に設定します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-126">The file's Build Action should be set to None, and Copy to Output Directory should be set to Do not copy.</span></span>
3. <span data-ttu-id="1dd7a-127">ファイルの内容をこの XML に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-127">Replace the contents of the file with this XML.</span></span>
   ```xml
   <packaging>
      <autoResourcePackage qualifier="Language" />
      <autoResourcePackage qualifier="Scale" />
      <autoResourcePackage qualifier="DXFeatureLevel" />
   </packaging>
   ```
4. <span data-ttu-id="1dd7a-128">各 `<autoResourcePackage>` 要素は Visual Studio に対して、特定の修飾子名のリソースを別のリソース パッケージに自動的に分割するように指示します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-128">Each `<autoResourcePackage>` element tells Visual Studio to automatically split the resources for the given qualifier name out into separate resource packages.</span></span> <span data-ttu-id="1dd7a-129">これは*自動分割*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-129">This is called *auto-splitting*.</span></span> <span data-ttu-id="1dd7a-130">ファイルの内容はこれまでのものであり、Visual Studio の動作を実際には変更していません。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-130">With the file contents you have so far, you haven't actually changed Visual Studio's behavior.</span></span> <span data-ttu-id="1dd7a-131">つまり、これらの内容が既定値であるため、Visual Studio はこれらの内容を持つファイルが存在しているかのように*既に動作しました*。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-131">In other words, Visual Studio *already behaved as if* this file were present with these contents, because these are the defaults.</span></span> <span data-ttu-id="1dd7a-132">Visual Studio で修飾子名に対して自動分割を行わない場合は、ファイルから `<autoResourcePackage>` 要素を削除します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-132">If you don't want Visual Studio to auto-split on a qualifier name then delete that `<autoResourcePackage>` element from the file.</span></span> <span data-ttu-id="1dd7a-133">すべての言語リソースが別のリソース パッケージに自動分割されるのではなくアプリ パッケージに組み込まれるようにする場合、ファイルの外観は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-133">Here's how the file would look if you wanted all of your language resources to be built into the app package instead of being auto-split out into separate resource packages.</span></span>
   ```xml
   <packaging>
      <autoResourcePackage qualifier="Scale" />
      <autoResourcePackage qualifier="DXFeatureLevel" />
   </packaging>
   ```
5. <span data-ttu-id="1dd7a-134">ファイルを保存して閉じ、プロジェクトをリビルドします。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-134">Save and close the file and rebuild your project.</span></span>

<span data-ttu-id="1dd7a-135">自動分割の選択肢が適用されていることを確認するには、`<ProjectFolder>\obj\<ReleaseConfiguration folder>\split.priconfig.xml` ファイルを探し、その内容が選択内容に一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-135">To confirm that your auto-split choices are being taken into account, look for the file `<ProjectFolder>\obj\<ReleaseConfiguration folder>\split.priconfig.xml` and confirm that its contents match your choices.</span></span> <span data-ttu-id="1dd7a-136">一致する場合は、選択したリソースをアプリ パッケージに組み込むように Visual Studio を正常に構成したことになります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-136">If they do, then you have successfully configured Visual Studio to build the resources of your choice into the app package.</span></span>

<span data-ttu-id="1dd7a-137">実行する必要がある最後の手順が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-137">There is one final step that you need to do.</span></span> <span data-ttu-id="1dd7a-138">**ただし、`Language` 修飾子名** を削除した場合にのみ行います。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-138">**But only if you deleted the `Language` qualifier name**.</span></span> <span data-ttu-id="1dd7a-139">統合したすべてのアプリのサポートされている言語をアプリの言語の既定値として指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-139">You need to specify the union of all of your app's supported language as your app's default for language.</span></span> <span data-ttu-id="1dd7a-140">詳細については、「[アプリで使用する既定のリソースを指定する](specify-default-resources-installed.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-140">For details, see [Specify the default resources that your app uses](specify-default-resources-installed.md).</span></span> <span data-ttu-id="1dd7a-141">アプリ パッケージに英語、スペイン語、フランス語のリソースを含んでいる場合、`priconfig.default.xml` の内容は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-141">This is what your `priconfig.default.xml` would contain if you were including resources for English, Spanish, and French in your app package.</span></span>

```xml
   <default>
      <qualifier name="Language" value="en;es;fr" />
      ...
   </default>
```

### <a name="how-does-this-work"></a><span data-ttu-id="1dd7a-142">この処理のしくみ</span><span class="sxs-lookup"><span data-stu-id="1dd7a-142">How does this work?</span></span>

<span data-ttu-id="1dd7a-143">バックグラウンドで、Visual Studio は `MakePri.exe` というツールを起動し、パッケージ リソース インデックスと呼ばれるファイルを生成します。このファイルには、自動分割するリソース修飾子名を示すなど、アプリのすべてのリソースについての情報を記述しています。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-143">Behind the scenes, Visual Studio launches a tool named `MakePri.exe` to generate a file known as a Package Resource Index, which describes all of your app's resources, including indicating which resource qualifier names to auto-split on.</span></span> <span data-ttu-id="1dd7a-144">このツールの詳細については、「[MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-144">For details about this tool, see [Compile resources manually with MakePri.exe](compile-resources-manually-with-makepri.md).</span></span> <span data-ttu-id="1dd7a-145">Visual Studio は構成ファイルを `MakePri.exe` に渡します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-145">Visual Studio passes a configuration file to `MakePri.exe`.</span></span> <span data-ttu-id="1dd7a-146">`priconfig.packaging.xml` ファイルの内容はその構成ファイルの `<packaging>` 要素として使用され、これが自動分割を指定する部分となります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-146">The contents of your `priconfig.packaging.xml` file are used as the `<packaging>` element of that configuration file, which is the part that determines auto-splitting.</span></span> <span data-ttu-id="1dd7a-147">そのため、最終的には `priconfig.packaging.xml` を追加および編集すると、Visual Studio がアプリに対して生成するパッケージ リソース インデックス ファイルの内容だけでなく、アプリ バンドルのパッケージの内容に影響します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-147">So, adding and editing `priconfig.packaging.xml` ultimately influences the contents of the Package Resource Index file that Visual Studio generates for your app, as well as the contents of the packages in your app bundle.</span></span>

### <a name="using-a-different-file-name-than-priconfigpackagingxml"></a><span data-ttu-id="1dd7a-148">`priconfig.packaging.xml` とは異なるファイル名の使用</span><span class="sxs-lookup"><span data-stu-id="1dd7a-148">Using a different file name than `priconfig.packaging.xml`</span></span>

<span data-ttu-id="1dd7a-149">ファイルに `priconfig.packaging.xml` という名前を付けると、Visual Studio はそれを自動的に認識して使用します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-149">If you name your file `priconfig.packaging.xml`, then Visual Studio will recognize it and use it automatically.</span></span> <span data-ttu-id="1dd7a-150">異なる名前を付けた場合、Visual Studio がそれを認識できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-150">If you give it a different name, then you'll need to let Visual Studio know.</span></span> <span data-ttu-id="1dd7a-151">プロジェクト ファイルで、`<PropertyGroup>` 要素の開始タグと終了タグの間にこの XML を追加します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-151">In your project file, between the opening and closing tags of the first `<PropertyGroup>` element, add this XML.</span></span>

```xml
<AppxPriConfigXmlPackagingSnippetPath>FILE-PATH-AND-NAME</AppxPriConfigXmlPackagingSnippetPath>
```

<span data-ttu-id="1dd7a-152">`FILE-PATH-AND-NAME` をファイルのパスおよび名前に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-152">Replace `FILE-PATH-AND-NAME` with the path to, and name of, your file.</span></span>

## <a name="option-2-use-your-project-file-to-build-resources-into-your-app-package"></a><span data-ttu-id="1dd7a-153">オプション 2.</span><span class="sxs-lookup"><span data-stu-id="1dd7a-153">Option 2.</span></span> <span data-ttu-id="1dd7a-154">プロジェクト ファイルを使用して、アプリ パッケージにリソースを組み込む</span><span class="sxs-lookup"><span data-stu-id="1dd7a-154">Use your project file to build resources into your app package</span></span>

<span data-ttu-id="1dd7a-155">これは、オプション 1 に代わる方法です。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-155">This is an alternative to Option 1.</span></span> <span data-ttu-id="1dd7a-156">オプション 1 のしくみを理解したら、オプション 2 の方が開発またはビルドのワークフローに最適である場合、オプション 2 を代わりに選択することができます。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-156">Once you understand how Option 1 works, you can choose to do Option 2 instead, if that suits your development and/or build workflow better.</span></span>

<span data-ttu-id="1dd7a-157">プロジェクト ファイルで、`<PropertyGroup>` 要素の開始タグと終了タグの間にこの XML を追加します。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-157">In your project file, between the opening and closing tags of the first `<PropertyGroup>` element, add this XML.</span></span>

```xml
<AppxBundleAutoResourcePackageQualifiers>Language|Scale|DXFeatureLevel</AppxBundleAutoResourcePackageQualifiers>
```

<span data-ttu-id="1dd7a-158">最初の修飾子名を削除したら、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-158">Here's how that looks after you've delete the first qualifier name.</span></span>

```xml
<AppxBundleAutoResourcePackageQualifiers>Scale|DXFeatureLevel</AppxBundleAutoResourcePackageQualifiers>
```

<span data-ttu-id="1dd7a-159">ファイルを保存して閉じ、プロジェクトをリビルドします。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-159">Save and close, and rebuild your project.</span></span>

<span data-ttu-id="1dd7a-160">実行する必要がある最後の手順が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-160">There is one final step that you need to do.</span></span> <span data-ttu-id="1dd7a-161">**ただし、`Language` 修飾子名** を削除した場合にのみ行います。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-161">**But only if you deleted the `Language` qualifier name**.</span></span> <span data-ttu-id="1dd7a-162">統合したすべてのアプリのサポートされている言語をアプリの言語の既定値として指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-162">You need to specify the union of all of your app's supported language as your app's default for language.</span></span> <span data-ttu-id="1dd7a-163">詳細については、「[アプリで使用する既定のリソースを指定する](specify-default-resources-installed.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-163">For details, see [Specify the default resources that your app uses](specify-default-resources-installed.md).</span></span> <span data-ttu-id="1dd7a-164">アプリ パッケージに英語、スペイン語、フランス語のリソースを含んでいる場合、プロジェクト ファイルの内容は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="1dd7a-164">This is what your project file would contain if you were including resources for English, Spanish, and French in your app package.</span></span>

```xml
<AppxDefaultResourceQualifiers>Language=en;es;fr</AppxDefaultResourceQualifiers>
```

## <a name="related-topics"></a><span data-ttu-id="1dd7a-165">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1dd7a-165">Related topics</span></span>

* [<span data-ttu-id="1dd7a-166">Visual Studio で UWP アプリをパッケージ化する</span><span class="sxs-lookup"><span data-stu-id="1dd7a-166">Package a UWP app with Visual Studio</span></span>](../packaging/packaging-uwp-apps.md)
* [<span data-ttu-id="1dd7a-167">MakePri.exe を使用して手動でリソースをコンパイルする</span><span class="sxs-lookup"><span data-stu-id="1dd7a-167">Compile resources manually with MakePri.exe</span></span>](compile-resources-manually-with-makepri.md)
* [<span data-ttu-id="1dd7a-168">アプリで使用する既定のリソースを指定する</span><span class="sxs-lookup"><span data-stu-id="1dd7a-168">Specify the default resources that your app uses</span></span>](specify-default-resources-installed.md)