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
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7297674"
---
# <a name="multilingual-app-toolkit-40-faq--troubleshooting"></a>多言語アプリ ツールキット 4.0 に関する FAQ とトラブルシューティング

このトピックでは、多言語アプリ ツールキット (MAT) 4.0 に関連したよくある質問と問題の回答を示します。

「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」も参照してください。

**注** ツールキットは、.resw (XAML) と .resjson (JavaScript) ファイルの両方をサポートします。 ただし、このトピックでは、.resw ファイルのみを参照します。 .resw ファイルは、リソース ファイルと呼ばれます。 このファイルには、既定の言語または別の言語に翻訳された言語の文字列が含まれます。 .resw ファイルを含むフォルダーは通常、言語タグの値に基づく名前が付けられます。

## <a name="do-i-need-resw-files-in-multiple-languages"></a>多言語の .resw ファイルは必要ですか。

いいえ。 このツールキットの主な利点の 1 つは、多言語の .resw ファイルを必要としないことです。 このツールキットでは、.xlf ファイルを使ってアプリのリソースを管理し同期します。 これにより、複数の .resw ファイル間でのコンテンツの同期維持に関連付けられた変更は削除されます。

一致する .resw ファイルと .xlf ファイルを含むプロジェクトでは、.xlf ファイルの翻訳は無視されます。 この場合、.xlf の翻訳が最終的なアプリには含まれないことを通知する警告がビルド処理中に表示されます。 .resw ファイルと .xlf ファイルのターゲット言語が同じ言語コードの場合に、これらのファイルが一致します。 一致する組の例としては、`Strings\de-DE\Resources.resw` および `<project-name>.de-DE.xlf` ファイル (`target-language="de-DE"` を含む) があります。

## <a name="can-i-have-resw-files-in-multiple-languages"></a>多言語の .resw ファイルを含めることができますか。

できます。ただし、お勧めできません。 多言語の .resw ファイルをプロジェクトに含める場合にこのツールキットを使うときは、一致する .resw ファイルと .xlf ファイルがないようにしてください。

## <a name="i-dont-see-an-option-in-the-tools-menu-to-enable-the-multilingual-app-toolkit"></a>多言語アプリ ツールキットを有効にするオプションが [ツール] メニューに表示されません。

次の手順を試してください。

- **[ツール]** を開く前に、ソリューション ノードではなくプロジェクト ノードを選ぶようにしてください。
- Visual Studio 拡張機能マネージャーを使ってツールキット拡張機能がインストールされていることを確認します。
- プロジェクトが UWP プロジェクトであることを確認します。

## <a name="when-i-build-my-project-i-dont-see-a-message-saying-that-a-multilingual-app-toolkit-build-has-started"></a>プロジェクトのビルド時に、"多言語アプリ ツールキットでビルドが開始されました" というメッセージが表示されません。

プロジェクトの MAT を有効にしたことを確認します。 **[ツール]** メニューで、**[多言語アプリ ツールキット]** > **[選択を有効にする]** の順に選択します。 以前のバージョンでプロジェクトを有効にした場合は、無効にしたうえで、**[ツール]** メニューを使って多言語アプリ ツールキットをもう一度有効にする必要があります。 これにより、プロジェクトが更新されて、新しいバージョンのツールキットで作業できるようになります。

"Visual Studio のすべてのエディションのビルド タスク" に対応するコンポーネントがインストールされていることを確認してください。 このビルド コンポーネントのインストール処理中には拡張機能もインストールされますが、その際にこれを手動で選択解除することができます。 このコンポーネントは、.xlf ファイルを更新し、PRI ファイルに翻訳を追加するために必要です。 このコンポーネントがインストールされて正常に機能している場合は、次のビルド メッセージが表示されます。

```dosbatch
1> Multilingual App Toolkit build started.
1> Multilingual App Toolkit build completed successfully.
```

## <a name="the-toolkit-is-reporting-that-it-didnt-locate-any-xliff-language-files-during-the-build"></a>ツールキットで、ビルド処理中に XLIFF 言語ファイルが見つからないことが報告されました。

```dosbatch
No XLIFF language files were found. The app will not contain any localized resources.
```

このメッセージは、拡張子が .xlf のプロジェクトのファイルが見つからなかったときに表示されます。 ツールキットによりこれらのファイルが生成され、既定で `MultilingualResources` フォルダーに保存されます。 これらのファイルは移動できますが、このフォルダーに配置したままにしておくことをお勧めします。そうすれば、多言語エディターで関連するメタデータ ファイルを見つけることができます。

## <a name="my-xlf-file-is-not-included-in-the-list-of-files-processed-by-the-toolkit-during-build"></a>使用する .xlf ファイルが、ビルド時にツールキットで処理されるファイルの一覧に含まれていません。

.xlf ファイルを手動でプロジェクトから除外した後にもう一度含めた場合、そのファイルの種類の要素は正常に設定されていない可能性があります。 Visual Studio で、ファイルを選択し、[プロパティ] ウィンドウを確認します。 ファイルの [ビルド アクション] が [XliffResource] に設定され、[出力ディレクトリにコピー] が [コピーしない] に設定されている必要があります。 プロジェクト ファイルで参照は次のように表示されます。

```xml
<XliffResource Include="MultilingualResources\<project-name>.fr-FR.xlf" />
```

## <a name="ive-added-xlf-based-languages-where-are-my-strings"></a>.xlf ベースの言語を追加しました。 文字列の場所を教えてください。

既定の言語のリソース ファイル (.resw) は、アプリで使用する文字列の正規の "スキーマ" です。 翻訳済みのリソース ファイルには、これらの文字列のすべて、またはサブセットが含まれます。

プロジェクトをビルドすると、リソース ファイルと .xlf が同期されます。

- .xlf ファイルは、追加または削除された文字列、または追加または削除されたリソース ファイルを反映するように更新されます。
- リソース ファイルは、.xlf ファイル内の翻訳された文字列を反映するように更新されます。

これは、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」で詳しく説明します。

## <a name="when-i-build-my-project-the-xlf-files-remain-empty"></a>プロジェクトをビルドするときに .xlf ファイルが空のままです。

多言語アプリ ツールキットを効果的に使用する前に、まずアプリをローカライズする必要があります。 これは、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」で詳しく説明します。

## <a name="what-is-microsoft-translator"></a>Microsoft Translator とは何ですか。

Microsoft Translator は、機械ベースの翻訳に対応するクラウドベースのサービスです。 人の手による翻訳を手軽に利用できない場合は、機械翻訳が翻訳を利用する手段として適しています。 詳しくは、[Microsoft Translator に関するページ](http://go.microsoft.com/fwlink/p/?LinkId=258220)をご覧ください。

このツールキットでは、Microsoft Translator サービスを使って、翻訳候補をユーザーに提供します。 Microsoft Translator アイコンが [Translation Languages] (翻訳言語) ダイアログに表示されているときに、Microsoft Translator でサポートされている言語を確認できます。

文字列を選んで **[翻訳]** をクリックすることにより、多言語エディター内から Microsoft Translator を使ってアプリをすばやく翻訳できます。

## <a name="what-is-pseudo-language-and-what-are-pseudo-resource-trackers"></a>擬似言語、および擬似リソースのトラッカーとは何ですか。

擬似言語とは、実際の言語翻訳をシミュレートすることを目的としてソフトウェア製品に加えられる人為的な変更のことです。 擬似言語および擬似リソースのトラッカーの詳細は、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」で確認できます。

## <a name="how-do-i-set-my-language-preference-to-pseudo-language-so-that-i-can-test-my-pseudo-locd-strings"></a>擬似言語でローカライズされた文字列をテストできるように、言語の優先順位を擬似言語に設定するにはどうすればよいですか。

これは、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」で詳しく説明します。

## <a name="what-kind-of-localizability-issues-can-i-find-using-pseudo-language"></a>擬似言語を使って発見できるローカライズの可否に関する問題を教えてください。

これは、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」で詳しく説明します。

## <a name="im-not-seeing-any-translations-when-i-launch-my-app-or-my-app-is-only-partially-translated"></a>アプリを起動したときに翻訳が何も表示されません。または、アプリが一部分しか翻訳されていません。

多言語エディターで .xlf ファイルを開き、翻訳が存在するかどうか確認します。 既定の言語の .resw ファイルの文字列が明示的に変更されたとき、対応する翻訳は .xlf ファイルから削除されます。 これは、翻訳がソース文字列と一致するようにするためです。 .xlf ファイル内の文字列を翻訳し、リビルドして既定以外の言語の .resw ファイルを更新します。

.xlf ファイルで翻訳されている文字列がアプリ内に表示されない場合は、プロジェクトをリビルドして既定以外の言語の .resw ファイルを更新します。 Visual Studio では、ビルド コマンドを最適化して、最後のビルド以降に変更されたファイルだけをビルドします。

言語の優先順位を確認します。 テスト対象の言語が、**[設定]** の言語の優先順位一覧の一番上に表示されていることを確認します。

## <a name="the-toolkit-is-reporting-error--0x80004004-in-the-build-output"></a>ツールキットで、ビルドの出力に 0x80004004 エラーが報告されています。

```dosbatch
Merge of Loc PRI file failed calling makepri.exe: "0x80004004"
```

このメッセージは、地域の形式がツールキットでのビルド操作と競合する場合に表示されることがあります。 回避策としては、ビルド時に **[設定]** で言語を en-US に変更します。


## <a name="the-toolkit-is-reporting-error--0x80004005-in-the-build-output"></a>ツールキットで、ビルドの出力に 0x80004005 エラーが報告されています。

```dosbatch
Merge of Loc PRI file failed calling makepri.exe: "0x80004005"
```

このメッセージは、サポートされていないターゲット言語が .xlf ファイルに含まれている場合に表示されることがあります。 たとえば、"zh-cht" と "zh-chs" は正しくありません (それぞれ、"zh-hant" と "zh-hans" に変更します)。

## <a name="is-there-a-way-to-find-out-more-information-about-the-errors-im-seeing"></a>表示されるエラーについてさらに詳しい情報を確認する方法はありますか。

はい、Visual Studio で詳しいログを有効にすることができます。 **[ツール]** > **[オプション]** > **[プロジェクトおよびソリューション]** > ** [ビルド/実行]** の順にクリックします。 **[MSBuild プロジェクト ビルドの出力の詳細]**  を [最小] から [標準] またはそれ以上に変更します。

MSBuild をコマンド ラインから実行した場合も、追加のメッセージが表示されることがあります。

```dosbatch
msbuild /t:rebuild <project-name>
```

## <a name="import-translation-failed"></a>翻訳のインポートに失敗しました。

インポート前にはインポート プロセスによって基本事項が検証されます。 これは、インポートするファイル内の対象となるカルチャ情報が現在の .xlf ファイルのカルチャ情報と一致することを確認するためのものです。 多言語エディターで .xlf ファイルを開き、カルチャ情報が一致することを確認します。

## <a name="what-if-my-translator-doesnt-have-windows-10-andor-visual-studio-andor-the-multilingual-app-toolkit-installed"></a>翻訳者が Windows10、Visual Studio、多言語アプリ ツールキットをインストールしていない場合、どうなりますか。

[エクスポート] 文字列リソース ダイアログで **[Output: Mail recipient]** (出力: メール受信者) を選択すると、メールには多言語アプリ ツールキット (MAT) 4.0 をダウンロードしてインストールするためのリンクが含まれます。 翻訳者は、Windows 10 や Visual Studio がなくても、スタンドアロンの多言語アプリ ツールキット 4.0 多言語エディター ツールをインストールできます。

詳細については、「[多言語アプリ ツールキット 4.0 の使用](use-mat.md)」を参照してください。

## <a name="what-happened-to-the-markuprulesxml-and-resourceslocksxml-files"></a>`MarkupRules.xml` および `ResourcesLocks.xml` ファイルはどうなりましたか。

多言語アプリ ツールキット 4.0 では、独自のリソース ロック ファイルは使われません。 代わりに、XLIFF 1.2 タグ `<mrk>` が .xlf ファイルに直接追加されて、機械翻訳時に変更されない文字列を識別します。 これにより、XLIFF ファイルでは、自己完結が可能になり、ファイルごとのリソース ロックもできます。

これらの余分なサポート ファイルは不要です。これらのファイルがある場合は安全に削除できます。

## <a name="what-happened-to-the-tpx-file"></a>.tpx ファイルはどうなりましたか。

.tpx ファイルは、翻訳のために .xlf ファイルを送信するときに、`MarkupRules.xml` ファイルと  `ResourcesLocks.xml` ファイルを簡単に含めることができるようにするためのものでした。 この機能は不要となりました。

.tpx ファイル内に取得する必要のある翻訳が含まれている場合は、.tpx ファイルの拡張子を .zip に変更します。 これにより、エクスプローラーまたは .zip と互換性があるツールを使ってコンテンツを開き、抽出できるようになります。

## <a name="i-think-ive-done-everything-right-but-it-still-isnt-working"></a>すべて正しく処理したつもりですが、まだ正常に機能しません。

次の手順を試してください。

1. 前に説明した方法のいずれかを使って、翻訳を追加します。
2. .pri ファイル (「[MakePri.exe のコマンド ライン オプション](../../app-resources/makepri-exe-command-options.md)」を参照) を出力して、翻訳が .pri ファイルに含まれているかどうか確認します。 翻訳は、言語コードおよび翻訳済みの値と一緒に次のように表示されます。
   ```xml
   <Candidate qualifiers="Language-QPS-PLOC" type="String">
       <Value>[!!_Ŝéãřćĥ_!!]</Value>
   </Candidate>
   ```
3. コマンド プロンプトからビルドします。エラーが表示された場合、そこにはビルド出力で報告された内容よりも詳しい情報が示されています。

## <a name="my-app-failed-certification-to-the-microsoft-store"></a>アプリが Microsoft Store での認定に合格しなかった

Microsoft Store の認定プロセスを開始する前に、`<project-name>.qps-ploc.xlf` ファイルをプロジェクトから除外する必要があります。 擬似言語を使うと、ローカライズの可否に関して起きる可能性のある問題やバグを検出できますが、擬似言語は有効な Microsoft Store の言語ではありません。 除外しなかった場合、Microsoft Store の認定プロセスでアプリが不合格になります。

## <a name="related-topics"></a>関連トピック

* [多言語アプリ ツールキット 4.0 の使用](use-mat.md)
* [Microsoft Translator ](http://go.microsoft.com/fwlink/p/?LinkId=258220)
* [MakePri.exe のコマンド ライン オプション](../../app-resources/makepri-exe-command-options.md)
