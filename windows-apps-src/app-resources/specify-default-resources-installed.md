---
author: stevewhims
Description: If your app doesn't have resources that match the particular settings of a customer device, then the app's default resources are used. This topic explains how to specify what those default resources are.
title: アプリで使用する既定のリソースを指定する
template: detail.hbs
ms.author: stwhi
ms.date: 11/14/2017
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: daa40656c72812e19c7f6f5fa71e50c2206670af
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7286110"
---
# <a name="specify-the-default-resources-that-your-app-uses"></a><span data-ttu-id="e836e-103">アプリで使用する既定のリソースを指定する</span><span class="sxs-lookup"><span data-stu-id="e836e-103">Specify the default resources that your app uses</span></span>

<span data-ttu-id="e836e-104">アプリにユーザーのデバイスの特定の設定に一致するリソースがない場合、アプリの既定のリソースが使用されます。</span><span class="sxs-lookup"><span data-stu-id="e836e-104">If your app doesn't have resources that match the particular settings of a customer device, then the app's default resources are used.</span></span> <span data-ttu-id="e836e-105">このトピックでは、これらの既定のリソースの内容を指定する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="e836e-105">This topic explains how to specify what those default resources are.</span></span>

<span data-ttu-id="e836e-106">ユーザーが Microsoft Store からアプリをインストールするときに、ユーザーのデバイスの設定は、アプリの利用可能なリソースと照合されます。</span><span class="sxs-lookup"><span data-stu-id="e836e-106">When a customer installs your app from the Microsoft Store, settings on the customer's device are matched against the app's available resources.</span></span> <span data-ttu-id="e836e-107">この照合は、適切なリソースのみがそのユーザーに対してダウンロードおよびインストールされる必要があるようにするために行われます。</span><span class="sxs-lookup"><span data-stu-id="e836e-107">This matching is done so that only the appropriate resources need to be downloaded and installed for that user.</span></span> <span data-ttu-id="e836e-108">たとえば、ユーザーの言語の優先順位の最も適切な文字列とイメージ、およびデバイスの解像度と DPI 設定が使用されます。</span><span class="sxs-lookup"><span data-stu-id="e836e-108">For example, the most appropriate strings and images for the user's language preferences, and the device's resolution and DPI settings, are used.</span></span> <span data-ttu-id="e836e-109">たとえば、`200` は `scale` の既定値ですが、必要な場合はその既定値を上書きできます。</span><span class="sxs-lookup"><span data-stu-id="e836e-109">For example, `200` is the default value for `scale`, but you can override that default if you wish.</span></span>

<span data-ttu-id="e836e-110">自分のリソース パックに移動しないリソース (ハイ コントラスト設定に合わせたイメージなど) でも、ユーザーの設定に一致するリソースが見つからない場合に実行時にアプリで使用する必要がある既定のリソースを指定できます。</span><span class="sxs-lookup"><span data-stu-id="e836e-110">Even for resources that don't go into their own resource packs (such as images tailored for high contrast settings), you can specify what default resources the app should use at run time if a resource that matches the user's settings can't be found.</span></span> <span data-ttu-id="e836e-111">たとえば、`standard` は `contrast` の既定値ですが、必要な場合はその既定値を上書きできます。</span><span class="sxs-lookup"><span data-stu-id="e836e-111">For example, `standard` is the default value for `contrast`, but you can override that default if you wish.</span></span>

<span data-ttu-id="e836e-112">これらの既定値は、既定のリソース修飾子の値の形式で指定します。</span><span class="sxs-lookup"><span data-stu-id="e836e-112">These defaults are specified in the form of default resource qualifier values.</span></span> <span data-ttu-id="e836e-113">リソース修飾子の内容については、「[言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e836e-113">For an explanation of what resource qualifiers are, their use, and purpose, see [Tailor your resources for language, scale, high contrast, and other qualifiers](tailor-resources-lang-scale-contrast.md).</span></span>

<span data-ttu-id="e836e-114">これらの既定値の内容は、2 つの方法のいずれかで構成できます。</span><span class="sxs-lookup"><span data-stu-id="e836e-114">You can configure what these defaults are in one of two ways.</span></span> <span data-ttu-id="e836e-115">構成ファイルをプロジェクトに追加するか、またはプロジェクト ファイルを直接編集することができます。</span><span class="sxs-lookup"><span data-stu-id="e836e-115">You can either add a configuration file to your project, or you can edit your project file directly.</span></span> <span data-ttu-id="e836e-116">これらのうち使いやすいオプション、またはビルド システムで最適に機能するオプションを使用してください。</span><span class="sxs-lookup"><span data-stu-id="e836e-116">Use whichever of these options you're most comfortable with, or whichever works best with your build system.</span></span>

## <a name="option-1-use-priconfigdefaultxml-to-specify-default-qualifier-values"></a><span data-ttu-id="e836e-117">オプション 1.</span><span class="sxs-lookup"><span data-stu-id="e836e-117">Option 1.</span></span> <span data-ttu-id="e836e-118">priconfig.default.xml を使用して、既定の修飾子の値を指定する</span><span class="sxs-lookup"><span data-stu-id="e836e-118">Use priconfig.default.xml to specify default qualifier values</span></span>

1. <span data-ttu-id="e836e-119">Visual Studio で、新しい項目をプロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="e836e-119">In Visual Studio, add a new item to your project.</span></span> <span data-ttu-id="e836e-120">XML ファイルを選択し、ファイルに `priconfig.default.xml` という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="e836e-120">Choose XML File, and name the file `priconfig.default.xml`.</span></span>
2. <span data-ttu-id="e836e-121">ソリューション エクスプローラーで、`priconfig.default.xml` を選択し、[プロパティ] ウィンドウを確認します。</span><span class="sxs-lookup"><span data-stu-id="e836e-121">In Solution Explorer, select `priconfig.default.xml` and check the Properties window.</span></span> <span data-ttu-id="e836e-122">ファイルの [ビルド アクション] を [なし] に設定し、[出力ディレクトリにコピー] を [コピーしない] に設定します。</span><span class="sxs-lookup"><span data-stu-id="e836e-122">The file's Build Action should be set to None, and Copy to Output Directory should be set to Do not copy.</span></span>
3. <span data-ttu-id="e836e-123">ファイルの内容をこの XML に置き換えます</span><span class="sxs-lookup"><span data-stu-id="e836e-123">Replace the contents of the file with this XML.</span></span>
   ```xml
   <default>
      <qualifier name="Language" value="LANGUAGE-TAG(S)" />
      <qualifier name="Contrast" value="standard" />
      <qualifier name="Scale" value="200" />
      <qualifier name="HomeRegion" value="001" />
      <qualifier name="TargetSize" value="256" />
      <qualifier name="LayoutDirection" value="LTR" />
      <qualifier name="DXFeatureLevel" value="DX9" />
      <qualifier name="Configuration" value="" />
      <qualifier name="AlternateForm" value="" />
   </default>
   ```
   
   <span data-ttu-id="e836e-124">**メモ** 値 `LANGUAGE-TAG(S)` は、アプリの既定の言語と同期する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e836e-124">**Note** The value `LANGUAGE-TAG(S)` needs to be synchronized with your app's default language.</span></span> <span data-ttu-id="e836e-125">それが単一の [BCP-47 言語タグ](http://go.microsoft.com/fwlink/p/?linkid=227302) である場合は、アプリの既定の言語は同じタグである必要があります。</span><span class="sxs-lookup"><span data-stu-id="e836e-125">If that's a single [BCP-47 language tag](http://go.microsoft.com/fwlink/p/?linkid=227302), then your app's default language needs to be the same tag.</span></span> <span data-ttu-id="e836e-126">それが言語タグのコンマ区切りのリストである場合、アプリの既定の言語はリストの最初のタグである必要があります。</span><span class="sxs-lookup"><span data-stu-id="e836e-126">If it's a comma-separated list of language tags, then your app's default language needs to be the first tag in the list.</span></span> <span data-ttu-id="e836e-127">アプリ パッケージ マニフェスト ソース ファイル (`Package.appxmanifest`) の **[アプリケーション]** タブの **[既定の言語]** フィールドでアプリの既定の言語を設定します。</span><span class="sxs-lookup"><span data-stu-id="e836e-127">You set your app's default language in the **Default language** field on the **Application** tab in your app package manifest source file (`Package.appxmanifest`).</span></span>

4. <span data-ttu-id="e836e-128">各 `<qualifier>` 要素は Visual Studio に対して、各修飾子名の既定値として使用する値を指示します。</span><span class="sxs-lookup"><span data-stu-id="e836e-128">Each `<qualifier>` element tells Visual Studio what value to use as the default for each qualifier name.</span></span> <span data-ttu-id="e836e-129">ファイルの内容はこれまでのものであり、Visual Studio の動作を実際には変更していません。</span><span class="sxs-lookup"><span data-stu-id="e836e-129">With the file contents you have so far, you haven't actually changed Visual Studio's behavior.</span></span> <span data-ttu-id="e836e-130">つまり、これらの内容が既定値であるため、Visual Studio はこれらの内容を持つファイルが存在しているかのように*既に動作しました*。</span><span class="sxs-lookup"><span data-stu-id="e836e-130">In other words, Visual Studio *already behaved as if* this file were present with these contents, because these are the default defaults.</span></span> <span data-ttu-id="e836e-131">そのため、既定値を独自の既定値で上書きするには、ファイル内の値を変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e836e-131">So to override a default with your own default value, you'll have to change a value in the file.</span></span> <span data-ttu-id="e836e-132">最初の 3 つの値を編集した場合、ファイルの外観は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e836e-132">Here's an example of how the file might look if you'd edited the first three values.</span></span>
   ```xml
   <default>
      <qualifier name="Language" value="de-DE" />
      <qualifier name="Contrast" value="black" />
      <qualifier name="Scale" value="400" />
      <qualifier name="HomeRegion" value="001" />
      <qualifier name="TargetSize" value="256" />
      <qualifier name="LayoutDirection" value="LTR" />
      <qualifier name="DXFeatureLevel" value="DX9" />
      <qualifier name="Configuration" value="" />
      <qualifier name="AlternateForm" value="" />
   </default>
   ```
5. <span data-ttu-id="e836e-133">ファイルを保存して閉じ、プロジェクトをリビルドします。</span><span class="sxs-lookup"><span data-stu-id="e836e-133">Save and close the file and rebuild your project.</span></span>

<span data-ttu-id="e836e-134">上書きされた既定値が適用されていることを確認するには、`<ProjectFolder>\obj\<ReleaseConfiguration folder>\priconfig.xml` ファイルを探し、その内容が上書き値に一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="e836e-134">To confirm that your overridden defaults are being taken into account, look for the file `<ProjectFolder>\obj\<ReleaseConfiguration folder>\priconfig.xml` and confirm that its contents match your overrides.</span></span> <span data-ttu-id="e836e-135">一致する場合は、アプリが既定で使用するリソースの修飾子の値を正常に構成したことになります。</span><span class="sxs-lookup"><span data-stu-id="e836e-135">If they do, then you have successfully configured the qualifier values of the resources that your app will use by default.</span></span> <span data-ttu-id="e836e-136">ユーザーの設定の一致対象が見つからない場合は、フォルダー名またはファイル名にここで設定した既定の修飾子の値が含まれているリソースが使用されます。</span><span class="sxs-lookup"><span data-stu-id="e836e-136">If a match for the user's settings is not found, then resources will be used whose folder or file names contain the default qualifer values that you've set here.</span></span>

### <a name="how-does-this-work"></a><span data-ttu-id="e836e-137">この処理のしくみ</span><span class="sxs-lookup"><span data-stu-id="e836e-137">How does this work?</span></span>

<span data-ttu-id="e836e-138">バックグラウンドで、Visual Studio は `MakePri.exe` というツールを起動し、パッケージ リソース インデックス (PRI) と呼ばれるファイルを生成します。このファイルには、既定のリソースを示すなど、アプリのすべてのリソースについての情報を記述しています。</span><span class="sxs-lookup"><span data-stu-id="e836e-138">Behind the scenes, Visual Studio launches a tool named `MakePri.exe` to generate a file known as a Package Resource Index (PRI), which describes all of your app's resources, including indicating which are the default resources.</span></span> <span data-ttu-id="e836e-139">このツールの詳細については、「[MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e836e-139">For details about this tool, see [Compile resources manually with MakePri.exe](compile-resources-manually-with-makepri.md).</span></span> <span data-ttu-id="e836e-140">Visual Studio は、構成ファイルを `MakePri.exe` に渡します。</span><span class="sxs-lookup"><span data-stu-id="e836e-140">Visual Studio passes a configuration file to `MakePri.exe`.</span></span> <span data-ttu-id="e836e-141">`priconfig.default.xml` ファイルの内容が、その構成ファイルの `<default>` 要素として使用されます。この要素は、既定値と見なされる修飾子の値のセットを指定する部分です。</span><span class="sxs-lookup"><span data-stu-id="e836e-141">The contents of your `priconfig.default.xml` file are used as the `<default>` element of that configuration file, which is the part that specifies the set of qualifier values that are considered to be default.</span></span> <span data-ttu-id="e836e-142">そのため、最終的には `priconfig.default.xml` を追加および編集すると、Visual Studio がアプリに対して生成し、そのアプリ パッケージに含めるパッケージ リソース インデックス ファイルの内容に影響します。</span><span class="sxs-lookup"><span data-stu-id="e836e-142">So, adding and editing `priconfig.default.xml` ultimately influences the contents of the Package Resource Index file that Visual Studio generates for your app and includes in its app package.</span></span>

<span data-ttu-id="e836e-143">**メモ** `<qualifier name="Language" ... />` 要素の値を変更するときは、その変更をアプリの既定の言語で同期する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e836e-143">**Note** Any time you change the value of the `<qualifier name="Language" ... />` element, you need to synchronize that change with your app's default language.</span></span> <span data-ttu-id="e836e-144">これは、アプリの PRI ファイルでインデックスが作成された言語リソースがアプリのマニフェストの既定の言語に一致するようにするためです。</span><span class="sxs-lookup"><span data-stu-id="e836e-144">This is so that the language resources indexed in your app's PRI file match your app's manifest default language.</span></span> <span data-ttu-id="e836e-145">`<qualifier name="Language" ... />` 要素の値は、`<ProjectFolder>\obj\<ReleaseConfiguration folder>\priconfig.xml` の内容に関してマニフェストの値を上書きしますが、そのファイルとアプリのマニフェストは一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e836e-145">The value in the `<qualifier name="Language" ... />` element overrides the value in the manifest with respect to the contents of `<ProjectFolder>\obj\<ReleaseConfiguration folder>\priconfig.xml`, but that file and your app's manifest should match.</span></span>

### <a name="using-a-different-file-name-than-priconfigdefaultxml"></a><span data-ttu-id="e836e-146">`priconfig.default.xml` とは異なるファイル名の使用</span><span class="sxs-lookup"><span data-stu-id="e836e-146">Using a different file name than `priconfig.default.xml`</span></span>

<span data-ttu-id="e836e-147">ファイルに `priconfig.default.xml` という名前を付けると、Visual Studio はそれを自動的に認識して使用します。</span><span class="sxs-lookup"><span data-stu-id="e836e-147">If you name your file `priconfig.default.xml`, then Visual Studio will recognize it and use it automatically.</span></span> <span data-ttu-id="e836e-148">異なる名前を付けた場合、Visual Studio がそれを認識できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e836e-148">If you give it a different name, then you'll need to let Visual Studio know.</span></span> <span data-ttu-id="e836e-149">プロジェクト ファイルで、`<PropertyGroup>` 要素の開始タグと終了タグの間にこの XML を追加します。</span><span class="sxs-lookup"><span data-stu-id="e836e-149">In your project file, between the opening and closing tags of the first `<PropertyGroup>` element, add this XML.</span></span>

```xml
<AppxPriConfigXmlDefaultSnippetPath>FILE-PATH-AND-NAME</AppxPriConfigXmlDefaultSnippetPath>
```

<span data-ttu-id="e836e-150">`FILE-PATH-AND-NAME` をファイルのパスおよび名前に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="e836e-150">Replace `FILE-PATH-AND-NAME` with the path to, and name of, your file.</span></span>

## <a name="option-2-use-your-project-file-to-specify-default-qualifier-values"></a><span data-ttu-id="e836e-151">オプション 2.</span><span class="sxs-lookup"><span data-stu-id="e836e-151">Option 2.</span></span> <span data-ttu-id="e836e-152">プロジェクト ファイルを使用して、既定の修飾子の値を指定する</span><span class="sxs-lookup"><span data-stu-id="e836e-152">Use your project file to specify default qualifier values</span></span>

<span data-ttu-id="e836e-153">これは、オプション 1 に代わる方法です。</span><span class="sxs-lookup"><span data-stu-id="e836e-153">This is an alternative to Option 1.</span></span> <span data-ttu-id="e836e-154">オプション 1 のしくみを理解したら、オプション 2 の方が開発またはビルドのワークフローに最適である場合、オプション 2 を代わりに選択することができます。</span><span class="sxs-lookup"><span data-stu-id="e836e-154">Once you understand how Option 1 works, you can choose to do Option 2 instead, if that suits your development and/or build workflow better.</span></span>

<span data-ttu-id="e836e-155">プロジェクト ファイルで、`<PropertyGroup>` 要素の開始タグと終了タグの間にこの XML を追加します。</span><span class="sxs-lookup"><span data-stu-id="e836e-155">In your project file, between the opening and closing tags of the first `<PropertyGroup>` element, add this XML.</span></span>

```xml
<AppxDefaultResourceQualifiers>Language=LANGUAGE-TAG(S)|Contrast=standard|Scale=200|HomeRegion=001|TargetSize=256|LayoutDirection=LTR|DXFeatureLevel=DX9|Configuration=|AlternateForm=</AppxDefaultResourceQualifiers>
```

<span data-ttu-id="e836e-156">最初の 3 つの値を編集したら、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="e836e-156">Here's an example of how that might look after you've edited the first three values.</span></span>

```xml
<AppxDefaultResourceQualifiers>Language=de-DE|Contrast=black|Scale=400|HomeRegion=001|TargetSize=256|LayoutDirection=LTR|DXFeatureLevel=DX9|Configuration=|AlternateForm=</AppxDefaultResourceQualifiers>
```

<span data-ttu-id="e836e-157">ファイルを保存して閉じ、プロジェクトをリビルドします。</span><span class="sxs-lookup"><span data-stu-id="e836e-157">Save and close, and rebuild your project.</span></span>

<span data-ttu-id="e836e-158">**メモ** `Language=` 値を変更するときは、マニフェスト デザイナーで (`Package.appxmanifest` を開いて) その変更をアプリの既定の言語に同期する必要があります)。</span><span class="sxs-lookup"><span data-stu-id="e836e-158">**Note** Any time you change the `Language=` value, you need to synchronize that change with your app's default language in the manifest designer (by opening `Package.appxmanifest`).</span></span>

## <a name="related-topics"></a><span data-ttu-id="e836e-159">関連トピック</span><span class="sxs-lookup"><span data-stu-id="e836e-159">Related topics</span></span>

* [<span data-ttu-id="e836e-160">言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する</span><span class="sxs-lookup"><span data-stu-id="e836e-160">Tailor your resources for language, scale, high contrast, and other qualifiers</span></span>](tailor-resources-lang-scale-contrast.md)
* [<span data-ttu-id="e836e-161">BCP-47 言語タグ</span><span class="sxs-lookup"><span data-stu-id="e836e-161">BCP-47 language tag</span></span>](http://go.microsoft.com/fwlink/p/?linkid=227302)
* [<span data-ttu-id="e836e-162">MakePri.exe を使用して手動でリソースをコンパイルする</span><span class="sxs-lookup"><span data-stu-id="e836e-162">Compile resources manually with MakePri.exe</span></span>](compile-resources-manually-with-makepri.md)
