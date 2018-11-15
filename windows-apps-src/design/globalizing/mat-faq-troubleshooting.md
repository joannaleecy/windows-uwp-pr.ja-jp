---
author: stevewhims
Description: This topic provides answers to frequently-asked questions and issues related to the Multilingual App Toolkit (MAT) 4.0.
title: 多言語アプリ ツールキットに関する FAQ とトラブルシューティング
template: detail.hbs
ms.author: stwhi
ms.date: 11/13/2017
ms.topic: article
keywords: Windows 10, UWP, グローバリゼーション, ローカライズの可否, ローカライズ
ms.localizationpriority: medium
ms.openlocfilehash: 320445022fa836e05d04e93b85d333ef1ad40a53
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6471608"
---
# <a name="multilingual-app-toolkit-40-faq--troubleshooting"></a><span data-ttu-id="b996f-103">多言語アプリ ツールキット 4.0 に関する FAQ とトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="b996f-103">Multilingual App Toolkit 4.0 FAQ & troubleshooting</span></span>

<span data-ttu-id="b996f-104">このトピックでは、多言語アプリ ツールキット (MAT) 4.0 に関連したよくある質問と問題の回答を示します。</span><span class="sxs-lookup"><span data-stu-id="b996f-104">This topic provides answers to frequently-asked questions and issues related to the Multilingual App Toolkit (MAT) 4.0.</span></span>

<span data-ttu-id="b996f-105">「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」も参照してください。</span><span class="sxs-lookup"><span data-stu-id="b996f-105">Also see [Use the Multilingual App Toolkit 4.0](use-mat.md).</span></span>

<span data-ttu-id="b996f-106">**注** ツールキットは、.resw (XAML) と .resjson (JavaScript) ファイルの両方をサポートします。</span><span class="sxs-lookup"><span data-stu-id="b996f-106">**Note** The toolkit supports both .resw (XAML) and .resjson (JavaScript) files.</span></span> <span data-ttu-id="b996f-107">ただし、このトピックでは、.resw ファイルのみを参照します。</span><span class="sxs-lookup"><span data-stu-id="b996f-107">But in this topic we'll refer only to .resw files.</span></span> <span data-ttu-id="b996f-108">.resw ファイルは、リソース ファイルと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="b996f-108">A .resw file is known as a Resources File.</span></span> <span data-ttu-id="b996f-109">このファイルには、既定の言語または別の言語に翻訳された言語の文字列が含まれます。</span><span class="sxs-lookup"><span data-stu-id="b996f-109">It contains strings, either in the default language or translated into another language.</span></span> <span data-ttu-id="b996f-110">.resw ファイルを含むフォルダーは通常、言語タグの値に基づく名前が付けられます。</span><span class="sxs-lookup"><span data-stu-id="b996f-110">The folder that contains a .resw file is typically named for the value of a language tag.</span></span>

## <a name="do-i-need-resw-files-in-multiple-languages"></a><span data-ttu-id="b996f-111">多言語の .resw ファイルは必要ですか。</span><span class="sxs-lookup"><span data-stu-id="b996f-111">Do I need .resw files in multiple languages?</span></span>

<span data-ttu-id="b996f-112">いいえ。</span><span class="sxs-lookup"><span data-stu-id="b996f-112">No.</span></span> <span data-ttu-id="b996f-113">このツールキットの主な利点の 1 つは、多言語の .resw ファイルを必要としないことです。</span><span class="sxs-lookup"><span data-stu-id="b996f-113">One of the key benefits of the Toolkit is that .resw files in multiple languages are not required.</span></span> <span data-ttu-id="b996f-114">このツールキットでは、.xlf ファイルを使ってアプリのリソースを管理し同期します。</span><span class="sxs-lookup"><span data-stu-id="b996f-114">The Toolkit manages and synchronizes your app's resources by using .xlf files.</span></span> <span data-ttu-id="b996f-115">これにより、複数の .resw ファイル間でのコンテンツの同期維持に関連付けられた変更は削除されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-115">This removes the challenges associated with keeping content synchronized across multiple .resw files.</span></span>

<span data-ttu-id="b996f-116">一致する .resw ファイルと .xlf ファイルを含むプロジェクトでは、.xlf ファイルの翻訳は無視されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-116">Projects that contain matching .resw and .xlf files cause the translations from the .xlf file to be ignored.</span></span> <span data-ttu-id="b996f-117">この場合、.xlf の翻訳が最終的なアプリには含まれないことを通知する警告がビルド処理中に表示されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-117">When this happens, a warning is displayed during the build to let you know that the .xlf translations are not included in the final app.</span></span> <span data-ttu-id="b996f-118">.resw ファイルと .xlf ファイルのターゲット言語が同じ言語コードの場合に、これらのファイルが一致します。</span><span class="sxs-lookup"><span data-stu-id="b996f-118">A .resw file and .xlf file match when they have a target language with the same language code.</span></span> <span data-ttu-id="b996f-119">一致する組の例としては、`Strings\de-DE\Resources.resw` および `<project-name>.de-DE.xlf` ファイル (`target-language="de-DE"` を含む) があります。</span><span class="sxs-lookup"><span data-stu-id="b996f-119">An example of a matching pair would be `Strings\de-DE\Resources.resw` and an `<project-name>.de-DE.xlf` file (containing `target-language="de-DE"`).</span></span>

## <a name="can-i-have-resw-files-in-multiple-languages"></a><span data-ttu-id="b996f-120">多言語の .resw ファイルを含めることができますか。</span><span class="sxs-lookup"><span data-stu-id="b996f-120">Can I have .resw files in multiple languages?</span></span>

<span data-ttu-id="b996f-121">できます。ただし、お勧めできません。</span><span class="sxs-lookup"><span data-stu-id="b996f-121">You can, but we don't recommend it.</span></span> <span data-ttu-id="b996f-122">多言語の .resw ファイルをプロジェクトに含める場合にこのツールキットを使うときは、一致する .resw ファイルと .xlf ファイルがないようにしてください。</span><span class="sxs-lookup"><span data-stu-id="b996f-122">If you want to include .resw files in multiple languages in your project and use the Toolkit, make sure you don't have matching .resw and .xlf files.</span></span>

## <a name="i-dont-see-an-option-in-the-tools-menu-to-enable-the-multilingual-app-toolkit"></a><span data-ttu-id="b996f-123">多言語アプリ ツールキットを有効にするオプションが [ツール] メニューに表示されません。</span><span class="sxs-lookup"><span data-stu-id="b996f-123">I don't see an option in the Tools menu to enable the Multilingual App Toolkit</span></span>

<span data-ttu-id="b996f-124">次の手順を試してください。</span><span class="sxs-lookup"><span data-stu-id="b996f-124">Try these steps.</span></span>

- <span data-ttu-id="b996f-125">**[ツール]** を開く前に、ソリューション ノードではなくプロジェクト ノードを選ぶようにしてください。</span><span class="sxs-lookup"><span data-stu-id="b996f-125">Make sure you select the project node, not the solution node, before opening the **Tools** menu.</span></span>
- <span data-ttu-id="b996f-126">Visual Studio 拡張機能マネージャーを使ってツールキット拡張機能がインストールされていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b996f-126">Confirm that the toolkit extension is installed by using the Visual Studio Extension Manager.</span></span>
- <span data-ttu-id="b996f-127">プロジェクトが UWP プロジェクトであることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b996f-127">Confirm that your project is a UWP project.</span></span>

## <a name="when-i-build-my-project-i-dont-see-a-message-saying-that-a-multilingual-app-toolkit-build-has-started"></a><span data-ttu-id="b996f-128">プロジェクトのビルド時に、"多言語アプリ ツールキットでビルドが開始されました" というメッセージが表示されません。</span><span class="sxs-lookup"><span data-stu-id="b996f-128">When I build my project, I don't see a message saying that a Multilingual App Toolkit build has started</span></span>

<span data-ttu-id="b996f-129">プロジェクトの MAT を有効にしたことを確認します。</span><span class="sxs-lookup"><span data-stu-id="b996f-129">Confirm that you've enabled the MAT for your project.</span></span> <span data-ttu-id="b996f-130">**[ツール]** メニューで、**[多言語アプリ ツールキット]** > **[選択を有効にする]** の順に選択します。</span><span class="sxs-lookup"><span data-stu-id="b996f-130">On the **Tools** menu, select **Multilingual App Toolkit** > **Enable selection**.</span></span> <span data-ttu-id="b996f-131">以前のバージョンでプロジェクトを有効にした場合は、無効にしたうえで、**[ツール]** メニューを使って多言語アプリ ツールキットをもう一度有効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b996f-131">If your project was enabled with a previous version, then disable and re-enable the MAT by using the **Tools** menu.</span></span> <span data-ttu-id="b996f-132">これにより、プロジェクトが更新されて、新しいバージョンのツールキットで作業できるようになります。</span><span class="sxs-lookup"><span data-stu-id="b996f-132">This updates the project to work with the new version of the Toolkit.</span></span>

<span data-ttu-id="b996f-133">"Visual Studio のすべてのエディションのビルド タスク" に対応するコンポーネントがインストールされていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="b996f-133">Ensure that the "Build Task for all Visual Studio editions" component was installed.</span></span> <span data-ttu-id="b996f-134">このビルド コンポーネントのインストール処理中には拡張機能もインストールされますが、その際にこれを手動で選択解除することができます。</span><span class="sxs-lookup"><span data-stu-id="b996f-134">This build component is installed with the extension, but it can be manually deselected during the installation.</span></span> <span data-ttu-id="b996f-135">このコンポーネントは、.xlf ファイルを更新し、PRI ファイルに翻訳を追加するために必要です。</span><span class="sxs-lookup"><span data-stu-id="b996f-135">This component is required to update the .xlf files and add the translation into the PRI file.</span></span> <span data-ttu-id="b996f-136">このコンポーネントがインストールされて正常に機能している場合は、次のビルド メッセージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-136">When this component is installed and working correctly, you will see these build messages.</span></span>

```dosbatch
1> Multilingual App Toolkit build started.
1> Multilingual App Toolkit build completed successfully.
```

## <a name="the-toolkit-is-reporting-that-it-didnt-locate-any-xliff-language-files-during-the-build"></a><span data-ttu-id="b996f-137">ツールキットで、ビルド処理中に XLIFF 言語ファイルが見つからないことが報告されました。</span><span class="sxs-lookup"><span data-stu-id="b996f-137">The toolkit is reporting that it didn't locate any XLIFF language files during the build</span></span>

```dosbatch
No XLIFF language files were found. The app will not contain any localized resources.
```

<span data-ttu-id="b996f-138">このメッセージは、拡張子が .xlf のプロジェクトのファイルが見つからなかったときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-138">This message is displayed when the toolkit doesn't find any files in the project with an extension of .xlf.</span></span> <span data-ttu-id="b996f-139">ツールキットによりこれらのファイルが生成され、既定で `MultilingualResources` フォルダーに保存されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-139">The toolkit generates and keeps these files in the `MultilingualResources` folder by default.</span></span> <span data-ttu-id="b996f-140">これらのファイルは移動できますが、このフォルダーに配置したままにしておくことをお勧めします。そうすれば、多言語エディターで関連するメタデータ ファイルを見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="b996f-140">They can be moved; but it's best to leave them in that folder because that allows the Multilingual Editor to locate the related metadata files.</span></span>

## <a name="my-xlf-file-is-not-included-in-the-list-of-files-processed-by-the-toolkit-during-build"></a><span data-ttu-id="b996f-141">使用する .xlf ファイルが、ビルド時にツールキットで処理されるファイルの一覧に含まれていません。</span><span class="sxs-lookup"><span data-stu-id="b996f-141">My .xlf file is not included in the list of files processed by the toolkit during build</span></span>

<span data-ttu-id="b996f-142">.xlf ファイルを手動でプロジェクトから除外した後にもう一度含めた場合、そのファイルの種類の要素は正常に設定されていない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b996f-142">If you manually exclude an .xlf file from the project, and then re-include it, the file type element may not be set correctly.</span></span> <span data-ttu-id="b996f-143">Visual Studio で、ファイルを選択し、[プロパティ] ウィンドウを確認します。</span><span class="sxs-lookup"><span data-stu-id="b996f-143">In Visual Studio, select the file and check the Properties window.</span></span> <span data-ttu-id="b996f-144">ファイルの [ビルド アクション] が [XliffResource] に設定され、[出力ディレクトリにコピー] が [コピーしない] に設定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="b996f-144">The file's Build Action should be set to XliffResource and Copy to Output Directory should be set to Do not copy.</span></span> <span data-ttu-id="b996f-145">プロジェクト ファイルで参照は次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-145">This is how the reference should look in your project file.</span></span>

```xml
<XliffResource Include="MultilingualResources\<project-name>.fr-FR.xlf" />
```

## <a name="ive-added-xlf-based-languages-where-are-my-strings"></a><span data-ttu-id="b996f-146">.xlf ベースの言語を追加しました。</span><span class="sxs-lookup"><span data-stu-id="b996f-146">I've added .xlf-based languages.</span></span> <span data-ttu-id="b996f-147">文字列の場所を教えてください。</span><span class="sxs-lookup"><span data-stu-id="b996f-147">Where are my strings?</span></span>

<span data-ttu-id="b996f-148">既定の言語のリソース ファイル (.resw) は、アプリで使用する文字列の正規の "スキーマ" です。</span><span class="sxs-lookup"><span data-stu-id="b996f-148">Your default language Resources File (.resw) is your canonical "schema" of the strings that your app uses.</span></span> <span data-ttu-id="b996f-149">翻訳済みのリソース ファイルには、これらの文字列のすべて、またはサブセットが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b996f-149">Translated Resources Files can contain all, or a subset of, these strings.</span></span>

<span data-ttu-id="b996f-150">プロジェクトをビルドすると、リソース ファイルと .xlf が同期されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-150">When you build your project, your Resources Files and your .xlf files are synchronized.</span></span>

- <span data-ttu-id="b996f-151">.xlf ファイルは、追加または削除された文字列、または追加または削除されたリソース ファイルを反映するように更新されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-151">The .xlf files are updated to reflect any added or removed string, or added or removed Resources Files.</span></span>
- <span data-ttu-id="b996f-152">リソース ファイルは、.xlf ファイル内の翻訳された文字列を反映するように更新されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-152">The Resources Files are updated to reflected any translated strings in the .xlf files.</span></span>

<span data-ttu-id="b996f-153">これは、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="b996f-153">This is explained in detail in [Use the Multilingual App Toolkit 4.0](use-mat.md).</span></span>

## <a name="when-i-build-my-project-the-xlf-files-remain-empty"></a><span data-ttu-id="b996f-154">プロジェクトをビルドするときに .xlf ファイルが空のままです。</span><span class="sxs-lookup"><span data-stu-id="b996f-154">When I build my project, the .xlf files remain empty</span></span>

<span data-ttu-id="b996f-155">多言語アプリ ツールキットを効果的に使用する前に、まずアプリをローカライズする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b996f-155">Before you can use the MAT effectively, your app needs to be localizable.</span></span> <span data-ttu-id="b996f-156">これは、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="b996f-156">This is explained in detail in [Use the Multilingual App Toolkit 4.0](use-mat.md).</span></span>

## <a name="what-is-microsoft-translator"></a><span data-ttu-id="b996f-157">Microsoft Translator とは何ですか。</span><span class="sxs-lookup"><span data-stu-id="b996f-157">What is Microsoft Translator?</span></span>

<span data-ttu-id="b996f-158">Microsoft Translator は、機械ベースの翻訳に対応するクラウドベースのサービスです。</span><span class="sxs-lookup"><span data-stu-id="b996f-158">Microsoft Translator is a cloud-based service that provides machine-based translation.</span></span> <span data-ttu-id="b996f-159">人の手による翻訳を手軽に利用できない場合は、機械翻訳が翻訳を利用する手段として適しています。</span><span class="sxs-lookup"><span data-stu-id="b996f-159">Machine translation is ideal for gaining access to translation when human translation is not reasonable to obtain.</span></span> <span data-ttu-id="b996f-160">詳しくは、[Microsoft Translator に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=258220)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b996f-160">You can learn more at [Microsoft Translator](http://go.microsoft.com/fwlink/p/?LinkId=258220).</span></span>

<span data-ttu-id="b996f-161">このツールキットでは、Microsoft Translator サービスを使って、翻訳候補をユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="b996f-161">The Toolkit uses the Microsoft Translator service to provide translation suggestions to you.</span></span> <span data-ttu-id="b996f-162">Microsoft Translator アイコンが [Translation Languages] (翻訳言語) ダイアログに表示されているときに、Microsoft Translator でサポートされている言語を確認できます。</span><span class="sxs-lookup"><span data-stu-id="b996f-162">You can see which languages are supported by Microsoft Translator when the Microsoft Translator icon is present in the Translation Languages dialog.</span></span>

<span data-ttu-id="b996f-163">文字列を選んで **[翻訳]** をクリックすることにより、多言語エディター内から Microsoft Translator を使ってアプリをすばやく翻訳できます。</span><span class="sxs-lookup"><span data-stu-id="b996f-163">You can quickly translate your app using Microsoft Translator from within the Multilingual Editor by selecting a string and clicking **Translate**.</span></span>

## <a name="what-is-pseudo-language-and-what-are-pseudo-resource-trackers"></a><span data-ttu-id="b996f-164">擬似言語、および擬似リソースのトラッカーとは何ですか。</span><span class="sxs-lookup"><span data-stu-id="b996f-164">What is pseudo language, and what are pseudo resource trackers?</span></span>

<span data-ttu-id="b996f-165">擬似言語とは、実際の言語翻訳をシミュレートすることを目的としてソフトウェア製品に加えられる人為的な変更のことです。</span><span class="sxs-lookup"><span data-stu-id="b996f-165">Pseudo language is an artificial modification of the software product intended to simulate real language localization.</span></span> <span data-ttu-id="b996f-166">擬似言語および擬似リソースのトラッカーの詳細は、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」で確認できます。</span><span class="sxs-lookup"><span data-stu-id="b996f-166">You can find more details about pseudo language and pseudo resource trackers in [Use the Multilingual App Toolkit 4.0](use-mat.md).</span></span>

## <a name="how-do-i-set-my-language-preference-to-pseudo-language-so-that-i-can-test-my-pseudo-locd-strings"></a><span data-ttu-id="b996f-167">擬似言語でローカライズされた文字列をテストできるように、言語の優先順位を擬似言語に設定するにはどうすればよいですか。</span><span class="sxs-lookup"><span data-stu-id="b996f-167">How do I set my language preference to pseudo language, so that I can test my pseudo-loc'd strings?</span></span>

<span data-ttu-id="b996f-168">これは、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="b996f-168">This is explained in [Use the Multilingual App Toolkit 4.0](use-mat.md).</span></span>

## <a name="what-kind-of-localizability-issues-can-i-find-using-pseudo-language"></a><span data-ttu-id="b996f-169">擬似言語を使って発見できるローカライズの可否に関する問題を教えてください。</span><span class="sxs-lookup"><span data-stu-id="b996f-169">What kind of localizability issues can I find using pseudo language?</span></span>

<span data-ttu-id="b996f-170">これは、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="b996f-170">This is explained in [Use the Multilingual App Toolkit 4.0](use-mat.md).</span></span>

## <a name="im-not-seeing-any-translations-when-i-launch-my-app-or-my-app-is-only-partially-translated"></a><span data-ttu-id="b996f-171">アプリを起動したときに翻訳が何も表示されません。または、アプリが一部分しか翻訳されていません。</span><span class="sxs-lookup"><span data-stu-id="b996f-171">I'm not seeing any translations when I launch my app, or my app is only partially translated</span></span>

<span data-ttu-id="b996f-172">多言語エディターで .xlf ファイルを開き、翻訳が存在するかどうか確認します。</span><span class="sxs-lookup"><span data-stu-id="b996f-172">Open the .xlf file in the Multilingual Editor to see whether the translations are present.</span></span> <span data-ttu-id="b996f-173">既定の言語の .resw ファイルの文字列が明示的に変更されたとき、対応する翻訳は .xlf ファイルから削除されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-173">When strings in the default language .resw file are changed explicitly, any corresponding translations are removed from .xlf files.</span></span> <span data-ttu-id="b996f-174">これは、翻訳がソース文字列と一致するようにするためです。</span><span class="sxs-lookup"><span data-stu-id="b996f-174">This is to ensure that a translation matches its source string.</span></span> <span data-ttu-id="b996f-175">.xlf ファイル内の文字列を翻訳し、リビルドして既定以外の言語の .resw ファイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="b996f-175">Translate the string(s) in the .xlf file(s), and rebuild to update the non-default language .resw file(s).</span></span>

<span data-ttu-id="b996f-176">.xlf ファイルで翻訳されている文字列がアプリ内に表示されない場合は、プロジェクトをリビルドして既定以外の言語の .resw ファイルを更新します。</span><span class="sxs-lookup"><span data-stu-id="b996f-176">If your strings are translated in the .xlf file(s), but they're not appearing in your app, then rebuild your project to update the non-default language .resw file(s).</span></span> <span data-ttu-id="b996f-177">Visual Studio では、ビルド コマンドを最適化して、最後のビルド以降に変更されたファイルだけをビルドします。</span><span class="sxs-lookup"><span data-stu-id="b996f-177">Visual Studio optimizes the Build command to build only files that have changed since the last Build.</span></span>

<span data-ttu-id="b996f-178">言語の優先順位を確認します。</span><span class="sxs-lookup"><span data-stu-id="b996f-178">Check your language preference order.</span></span> <span data-ttu-id="b996f-179">テスト対象の言語が、**[設定]** の言語の優先順位一覧の一番上に表示されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="b996f-179">Ensure that the language you want to test is listed at the top of your language preference list in **Settings**.</span></span>

## <a name="the-toolkit-is-reporting-error--0x80004004-in-the-build-output"></a><span data-ttu-id="b996f-180">ツールキットで、ビルドの出力に 0x80004004 エラーが報告されています。</span><span class="sxs-lookup"><span data-stu-id="b996f-180">The toolkit is reporting error  0x80004004 in the build output</span></span>

```dosbatch
Merge of Loc PRI file failed calling makepri.exe: "0x80004004"
```

<span data-ttu-id="b996f-181">このメッセージは、地域の形式がツールキットでのビルド操作と競合する場合に表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="b996f-181">This message can be displayed when the region format conflicts with the toolkit build operation.</span></span> <span data-ttu-id="b996f-182">回避策としては、ビルド時に **[設定]** で言語を en-US に変更します。</span><span class="sxs-lookup"><span data-stu-id="b996f-182">The workaround is to change your language in **Settings** to en-US while building.</span></span>


## <a name="the-toolkit-is-reporting-error--0x80004005-in-the-build-output"></a><span data-ttu-id="b996f-183">ツールキットで、ビルドの出力に 0x80004005 エラーが報告されています。</span><span class="sxs-lookup"><span data-stu-id="b996f-183">The toolkit is reporting error  0x80004005 in the build output</span></span>

```dosbatch
Merge of Loc PRI file failed calling makepri.exe: "0x80004005"
```

<span data-ttu-id="b996f-184">このメッセージは、サポートされていないターゲット言語が .xlf ファイルに含まれている場合に表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="b996f-184">This message can be displayed when the .xlf file contains an unsupported target language.</span></span> <span data-ttu-id="b996f-185">たとえば、"zh-cht" と "zh-chs" は正しくありません (それぞれ、"zh-hant" と "zh-hans" に変更します)。</span><span class="sxs-lookup"><span data-stu-id="b996f-185">For example, "zh-cht" is incorrect (change it to "zh-hant"), and "zh-chs" is incorrect (change it to "zh-hans").</span></span>

## <a name="is-there-a-way-to-find-out-more-information-about-the-errors-im-seeing"></a><span data-ttu-id="b996f-186">表示されるエラーについてさらに詳しい情報を確認する方法はありますか。</span><span class="sxs-lookup"><span data-stu-id="b996f-186">Is there a way to find out more information about the errors I'm seeing?</span></span>

<span data-ttu-id="b996f-187">はい、Visual Studio で詳しいログを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="b996f-187">Yes, you can turn on verbose logging in Visual Studio.</span></span> <span data-ttu-id="b996f-188">**[ツール]** > **[オプション]** > **[プロジェクトおよびソリューション]** > \*\* [ビルド/実行]\*\* の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="b996f-188">Click **Tools** > **Options** > **Projects and Solutions** > **Build and Run**.</span></span> <span data-ttu-id="b996f-189">**[MSBuild プロジェクト ビルドの出力の詳細]**  を [最小] から [標準] またはそれ以上に変更します。</span><span class="sxs-lookup"><span data-stu-id="b996f-189">Change **MSBuild project build output verbosity** from Minimal to Normal or higher.</span></span>

<span data-ttu-id="b996f-190">MSBuild をコマンド ラインから実行した場合も、追加のメッセージが表示されることがあります。</span><span class="sxs-lookup"><span data-stu-id="b996f-190">Running MSBuild from the command line can also produce additional messages.</span></span>

```dosbatch
msbuild /t:rebuild <project-name>
```

## <a name="import-translation-failed"></a><span data-ttu-id="b996f-191">翻訳のインポートに失敗しました。</span><span class="sxs-lookup"><span data-stu-id="b996f-191">Import translation failed</span></span>

<span data-ttu-id="b996f-192">インポート前にはインポート プロセスによって基本事項が検証されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-192">The import process performs basic validation before importing.</span></span> <span data-ttu-id="b996f-193">これは、インポートするファイル内の対象となるカルチャ情報が現在の .xlf ファイルのカルチャ情報と一致することを確認するためのものです。</span><span class="sxs-lookup"><span data-stu-id="b996f-193">This ensures that the target culture information in the files being imported matches that in the existing .xlf files.</span></span> <span data-ttu-id="b996f-194">多言語エディターで .xlf ファイルを開き、カルチャ情報が一致することを確認します。</span><span class="sxs-lookup"><span data-stu-id="b996f-194">Open the .xlf files in the Multilingual Editor and make sure that the culture information matches.</span></span>

## <a name="what-if-my-translator-doesnt-have-windows-10-andor-visual-studio-andor-the-multilingual-app-toolkit-installed"></a><span data-ttu-id="b996f-195">翻訳者が Windows10、Visual Studio、多言語アプリ ツールキットをインストールしていない場合、どうなりますか。</span><span class="sxs-lookup"><span data-stu-id="b996f-195">What if my translator doesn't have Windows 10, and/or Visual Studio and/or the Multilingual App Toolkit installed?</span></span>

<span data-ttu-id="b996f-196">[エクスポート] 文字列リソース ダイアログで **[Output: Mail recipient]** (出力: メール受信者) を選択すると、メールには多言語アプリ ツールキット (MAT) 4.0 をダウンロードしてインストールするためのリンクが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b996f-196">When you select **Output: Mail recipient** in the Export string resources dialog, the email includes a link to download and install the Multilingual App Toolkit (MAT) 4.0.</span></span> <span data-ttu-id="b996f-197">翻訳者は、Windows 10 や Visual Studio がなくても、スタンドアロンの多言語アプリ ツールキット 4.0 多言語エディター ツールをインストールできます。</span><span class="sxs-lookup"><span data-stu-id="b996f-197">Your translator can still install the MAT 4.0 standalone Multilingual Editor tool even without Windows 10 nor Visual Studio.</span></span>

<span data-ttu-id="b996f-198">詳細については、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b996f-198">For more details, see [Use the Multilingual App Toolkit 4.0](use-mat.md).</span></span>

## <a name="what-happened-to-the-markuprulesxml-and-resourceslocksxml-files"></a><span data-ttu-id="b996f-199">`MarkupRules.xml` および `ResourcesLocks.xml` ファイルはどうなりましたか。</span><span class="sxs-lookup"><span data-stu-id="b996f-199">What happened to the `MarkupRules.xml` and `ResourcesLocks.xml` files?</span></span>

<span data-ttu-id="b996f-200">多言語アプリ ツールキット 4.0 では、独自のリソース ロック ファイルは使われません。</span><span class="sxs-lookup"><span data-stu-id="b996f-200">The Multilingual App Toolkit 4.0 doesn't use proprietary resource locking files.</span></span> <span data-ttu-id="b996f-201">代わりに、XLIFF 1.2 タグ `<mrk>` が .xlf ファイルに直接追加されて、機械翻訳時に変更されない文字列を識別します。</span><span class="sxs-lookup"><span data-stu-id="b996f-201">Instead, the XLIFF 1.2 tag `<mrk>` is added directly to the .xlf file to identify strings that are not modified during Machine Translation.</span></span> <span data-ttu-id="b996f-202">これにより、XLIFF ファイルでは、自己完結が可能になり、ファイルごとのリソース ロックもできます。</span><span class="sxs-lookup"><span data-stu-id="b996f-202">This enables the XLIFF file to be self-contained, and allows for per-file based resource locking.</span></span>

<span data-ttu-id="b996f-203">これらの余分なサポート ファイルは不要です。これらのファイルがある場合は安全に削除できます。</span><span class="sxs-lookup"><span data-stu-id="b996f-203">These extra support files are no longer needed and you can safely delete them if you have them.</span></span>

## <a name="what-happened-to-the-tpx-file"></a><span data-ttu-id="b996f-204">.tpx ファイルはどうなりましたか。</span><span class="sxs-lookup"><span data-stu-id="b996f-204">What happened to the .tpx file?</span></span>

<span data-ttu-id="b996f-205">.tpx ファイルは、翻訳のために .xlf ファイルを送信するときに、`MarkupRules.xml` ファイルと  `ResourcesLocks.xml` ファイルを簡単に含めることができるようにするためのものでした。</span><span class="sxs-lookup"><span data-stu-id="b996f-205">The .tpx file provided an easy way to include the `MarkupRules.xml` and `ResourcesLocks.xml` files when the .xlf file was sent out for translation.</span></span> <span data-ttu-id="b996f-206">この機能は不要となりました。</span><span class="sxs-lookup"><span data-stu-id="b996f-206">This functionality is no longer required.</span></span>

<span data-ttu-id="b996f-207">.tpx ファイル内に取得する必要のある翻訳が含まれている場合は、.tpx ファイルの拡張子を .zip に変更します。</span><span class="sxs-lookup"><span data-stu-id="b996f-207">If you have translations in a .tpx file that you need to retrieve, simply rename the .tpx file extension to .zip.</span></span> <span data-ttu-id="b996f-208">これにより、エクスプローラーまたは .zip と互換性があるツールを使ってコンテンツを開き、抽出できるようになります。</span><span class="sxs-lookup"><span data-stu-id="b996f-208">This will allow you to open and extract the contents with File Explorer or any .zip compatible tool.</span></span>

## <a name="i-think-ive-done-everything-right-but-it-still-isnt-working"></a><span data-ttu-id="b996f-209">すべて正しく処理したつもりですが、まだ正常に機能しません。</span><span class="sxs-lookup"><span data-stu-id="b996f-209">I think I've done everything right, but it still isn't working</span></span>

<span data-ttu-id="b996f-210">次の手順を試してください。</span><span class="sxs-lookup"><span data-stu-id="b996f-210">Try these steps.</span></span>

1. <span data-ttu-id="b996f-211">前に説明した方法のいずれかを使って、翻訳を追加します。</span><span class="sxs-lookup"><span data-stu-id="b996f-211">Add translations using one of the methods already described.</span></span>
2. <span data-ttu-id="b996f-212">.pri ファイル (「[MakePri.exe のコマンド ライン オプション](../../app-resources/makepri-exe-command-options.md)」を参照) を出力して、翻訳が .pri ファイルに含まれているかどうか確認します。</span><span class="sxs-lookup"><span data-stu-id="b996f-212">Dump the .pri file (see [MakePri.exe command-line options](../../app-resources/makepri-exe-command-options.md)) to see whether your translations are in the .pri file.</span></span> <span data-ttu-id="b996f-213">翻訳は、言語コードおよび翻訳済みの値と一緒に次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="b996f-213">Translations will appear with language code and translated value like this.</span></span>
   ```xml
   <Candidate qualifiers="Language-QPS-PLOC" type="String">
       <Value>[!!_Ŝéãřćĥ_!!]</Value>
   </Candidate>
   ```
3. <span data-ttu-id="b996f-214">コマンド プロンプトからビルドします。エラーが表示された場合、そこにはビルド出力で報告された内容よりも詳しい情報が示されています。</span><span class="sxs-lookup"><span data-stu-id="b996f-214">Build from a Command Prompt; the resulting error may have more details than what is reported in the build output.</span></span>

## <a name="my-app-failed-certification-to-the-microsoft-store"></a><span data-ttu-id="b996f-215">アプリが Microsoft Store での認定に合格しなかった</span><span class="sxs-lookup"><span data-stu-id="b996f-215">My app failed certification to the Microsoft Store</span></span>

<span data-ttu-id="b996f-216">Microsoft Store の認定プロセスを開始する前に、`<project-name>.qps-ploc.xlf` ファイルをプロジェクトから除外する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b996f-216">Before you start the Microsoft Store Certification process, you must exclude the `<project-name>.qps-ploc.xlf` file from your project.</span></span> <span data-ttu-id="b996f-217">擬似言語を使うと、ローカライズの可否に関して起きる可能性のある問題やバグを検出できますが、擬似言語は有効な Microsoft Store の言語ではありません。</span><span class="sxs-lookup"><span data-stu-id="b996f-217">Pseudo language is used to detect potential localizability issues or bugs, but it is not a valid Microsoft Store language.</span></span> <span data-ttu-id="b996f-218">除外しなかった場合、Microsoft Store の認定プロセスでアプリが不合格になります。</span><span class="sxs-lookup"><span data-stu-id="b996f-218">If it is not removed then your app will fail during the Microsoft Store Certification process.</span></span>

## <a name="related-topics"></a><span data-ttu-id="b996f-219">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b996f-219">Related topics</span></span>

* [<span data-ttu-id="b996f-220">多言語アプリ ツールキット 4.0 の使用</span><span class="sxs-lookup"><span data-stu-id="b996f-220">Use the Multilingual App Toolkit 4.0</span></span>](use-mat.md)
* [<span data-ttu-id="b996f-221">Microsoft Translator </span><span class="sxs-lookup"><span data-stu-id="b996f-221">Microsoft Translator</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=258220)
* [<span data-ttu-id="b996f-222">MakePri.exe のコマンド ライン オプション</span><span class="sxs-lookup"><span data-stu-id="b996f-222">MakePri.exe command-line options</span></span>](../../app-resources/makepri-exe-command-options.md)
