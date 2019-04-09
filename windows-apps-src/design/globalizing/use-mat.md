---
Description: Microsoft Visual Studio 2017 には多言語アプリ ツールキット (MAT) 4.0 が統合されています。そのため、UWP アプリで翻訳がサポートされ、翻訳ファイルを管理したり、エディター ツールを利用したりできます。
title: 多言語アプリ ツールキットの使用
template: detail.hbs
ms.date: 01/23/2018
ms.topic: article
keywords: Windows 10, UWP, グローバリゼーション, ローカライズの可否, ローカライズ
ms.localizationpriority: medium
ms.openlocfilehash: c6dc07ff35cdd90deaddff06f89aa585aa63156a
ms.sourcegitcommit: 6a7dd4da2fc31ced7d1cdc6f7cf79c2e55dc5833
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/21/2019
ms.locfileid: "58335030"
---
# <a name="use-the-multilingual-app-toolkit-40"></a>多言語アプリ ツールキット 4.0 の使用

Microsoft Visual Studio 2017 には多言語アプリ ツールキット (MAT) 4.0 が統合されています。そのため、UWP アプリで翻訳がサポートされ、翻訳ファイルを管理したり、エディター ツールを利用したりできます。 ツールキットの価値提案の一部を次に示します。

- 開発時のリソースの変更や翻訳の状態を管理できます。
- 構成済みの翻訳プロバイダーに基づいて言語を選ぶための UI を提供します。
- ローカライズ業界標準 XLIFF ファイル形式をサポートしています。
- 擬似言語エンジンを使って、開発中に翻訳の問題点を見つけだすことができます。
- Microsoft Language Portal に接続して、翻訳された文字列や用語に容易にアクセスできます。
- Microsoft Translator に接続して、翻訳候補をすばやく調べることができます。

## <a name="how-to-use-the-toolkit"></a>ツールの使用方法

### <a name="step-1-design-your-app-for-globalization-and-localization"></a>手順 1. グローバリゼーションとローカライズのためのアプリの設計

多言語アプリ ツールキットを効果的に使用する前に、まずアプリをローカライズする必要があります。 具体的には、プロジェクトには、既定の言語でのアプリの文字列を含む 1 つまたは複数のリソース ファイル (.resw) を含める必要があります。 詳細については、「[UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](../../app-resources/localize-strings-ui-manifest.md)」を参照してください。 処理が完了したら、ツールキットにより、言語を迅速かつ簡単に追加できます。

グローバリゼーションとローカリゼーションの価値提案の&mdash;、用語の定義と**グローバリゼーション**、**ローカライズ**、および**ローカリゼーション**&mdash;を参照してください[グローバリゼーションとローカリゼーション](globalizing-portal.md)します。

「[グローバリゼーションのガイドライン](guidelines-and-checklist-for-globalizing-your-app.md)」と「[アプリをローカライズ可能にする](prepare-your-app-for-localization.md)」も参照してください。

### <a name="step-2-download-and-install-the-multilingual-app-toolkit-40"></a>手順 2.  多言語アプリ ツールキット 4.0 のダウンロードおよびインストール

多言語アプリ ツールキット 4.0 (MAT 4.0) は 2 つの部分から構成され、それぞれ独自のインストーラーがあります。

- [Microsoft Visual Studio 2017 向け多言語アプリ ツールキット 4.0](https://marketplace.visualstudio.com/items?itemName=MultilingualAppToolkit.MultilingualAppToolkit-18308). これにより、.vsix インストーラーの形式で、Visual Studio 2017 の MAT 4.0 の拡張子が含まれます。
- [多言語アプリ ツールキット 4.0 エディター](https://developer.microsoft.com/en-us/windows/develop/multilingual-app-toolkit). これには、.msi インストーラーの形式で、MAT 4.0 のスタンドアロン多言語エディター ツールが含まれています。 Visual Studio 2015 と Visual Studio 2013 の MAT 4.0 拡張機能も含まれます。

Visual Studio 2017 を使用している場合は、両方のインストーラーをダウンロードし、1 つずつ実行します。 Visual Studio 2015 または Visual Studio 2013 を使用している場合は、.msi インストーラーをダウンロードして実行します。

### <a name="step-3-enable-the-multilingual-app-toolkit-for-your-project"></a>手順 3. プロジェクトの多言語アプリ ツールキットを有効にします。

多言語アプリ ツールキットは、アプリをローカライズする前に、プロジェクトで使用できるようにする必要があります。 ツールキットを有効にするには、次の手順に従います。

- Visual Studio でプロジェクト ソリューションを開きます。
- ソリューション エクスプローラーで、目的のプロジェクトを選びます。
- **[ツール]** メニューで、**[多言語アプリ ツールキット]** > **[選択を有効にする]** の順に選択します。 

(多言語アプリ ツールキットからの出力を表示する) 出力ウィンドウで、`Project '<project-name>' was enabled. The project's source culture is '<language-tag>' <language-name>` というメッセージを監視します。 このメッセージが表示された場合、多言語アプリ ツールキットが使用可能です。

### <a name="step-4-add-languages-to-your-project"></a>手順 4. プロジェクトへの言語の追加

次の手順に従って、プロジェクトに言語を追加します。

1. ソリューション エクスプローラーでプロジェクト ノードを右クリックします。
2. **[多言語アプリ ツールキット]** > **[Add translation languages...]** (翻訳言語の追加) の順にクリックします。
3. [Translation Languages] (翻訳言語) ダイアログで、サポートする言語を選んで [OK] をクリックします。

ツールキットは、応答としてこれらを実行します。

- 追加した言語ごとに、言語の [BCP-47 言語タグ](https://go.microsoft.com/fwlink/p/?linkid=227302) の名前が付いた新しいフォルダーが作成されます。 そのフォルダー内に、既定の言語の文字列が含まれているものと一致する新しいリソース ファイル (.resw) が作成されます。
- 初めて言語を追加した場合は、`MultilingualResources` という名前の新しいフォルダーがプロジェクトに追加されます。 そのフォルダー内で、言語ごとに .xlf ファイルが追加されます。 .xlf ファイルには、プロジェクトの各リソース ファイル (.resw) 内の文字列ごとに翻訳単位が含まれます。
- 出力ウィンドウには、追加した言語の追加を確認するメッセージが表示されます。

既定の言語のリソース ファイル (.resw) を追加または削除するたびに、または既定の言語のリソース ファイル (.resw) 内の文字列を追加または削除するたびに、.xlf ファイルを再同期するようにプロジェクトをリビルドします。 これにより、.xlf ファイルに既定の言語の統合した文字列が含まれるようになります。

翻訳サービスがインストールされている&mdash;など、 [Microsoft ランゲージ ポータル](https://go.microsoft.com/fwlink/p/?LinkId=330295)と[Microsoft Translator](https://go.microsoft.com/fwlink/p/?LinkId=258220)&mdash;アプリのリソースを翻訳するために使用できます。 プロバイダーが特定の言語をサポートしている場合、プロバイダーのアイコンが [Translation Languages] (翻訳言語) ダイアログの言語名の横に表示されます。

[Translation Languages] (翻訳言語) ダイアログでは、ツールキットで検出可能な .xlf ベースの言語は、選択ボックスがあらかじめオンになり、その言語がプロジェクトに既に含まれていることを示しています。

プロジェクトに追加した言語は、[Translation Languages] (翻訳言語) ダイアログのチェック ボックスをオフにしても削除できません。 言語を削除するには、言語固有の .xlf ファイルを右クリックし、**[削除]** を選びます。 確定すると、対応するリソース ファイル (.resw) も削除されます。

### <a name="step-5-test-your-app-using-pseudo-language"></a>手順 5. 擬似言語を使ったアプリのテスト

擬似言語とは、実際の言語翻訳をシミュレートすることを目的としたソフトウェア製品に加えられる人為的な変更のことで、ネイティブ スピーカーはこれを読み取ることができます。 擬似言語を使うと、文字が置き換えられ、リソース文字列の長さが拡張されて、本格的にローカライズを始める前のプロジェクト サイクルの初期段階で、ローカライズの可否に関する問題やバグを検出できます。

次の手順に従って、プロジェクトを擬似言語でローカライズしてテストします。

1. [Translation Languages] (翻訳言語) ダイアログを使って 擬似言語 (Pseudo) [qps-ploc] をプロジェクトに追加します。
2. ソリューション エクスプローラーで `<project-name>.qps-ploc.xlf` ファイルを右クリックし、**[多言語アプリ ツールキット]** > **[Generate machine translations]** (機械翻訳の生成) の順にクリックします。
3. **[設定]** > **[時刻と言語]** > **[地域と言語]** > **[言語]** で、**[言語の追加]** をクリックします。
5. 検索ボックスに「`qps-ploc`」と入力します。
6. [`English (qps-ploc)`] をクリックして追加します。
7. 言語の一覧から [`English (qps-ploc)`] を選択し、**[既定に設定]** をクリックします。
8. 擬似言語でローカライズしたアプリをテストします。 たとえば、一部の文字列が表示されない (文字列が切り捨てられている) または文字列が翻訳されていない (代わりにハード コーディングされている) という UI レイアウトに関する問題を探します。

文字の置き換えと拡張だけでなく、擬似エンジンは各リソースに対して固有の追跡 ID を提供します。 このトラッカーは、各文字列の先頭に追加され、角かっこで囲まれます (`[xxxxx]`)。 これらのトラッカーは、視覚的な UI の検査テスト時に使うことができます。 これらのトラッカーは、特に複数のリソースに類似するテキストや重複するテキストが含まれている場合、製品の特定のリソースを調べるのに役立ちます。

次の "Hello, World!" という テキストの例では、擬似翻訳が画面の約 30% 広いスペースを占めるまで拡張され、リソース トラッカーが適用されます。

`"Hello World" -> "Ĥèĺļõ Ŵòŗłđ" -> "[!!_Ĥèĺļõ Ŵòŗłđ_!!]" -> "[hJ8s1][!!_Ĥèĺļõ Ŵòŗłđ_!!]"`

### <a name="step-6-translate-your-app-into-selected-languages"></a>手順 6. 選んだ言語へのアプリの翻訳

多言語アプリ ツールキットは、ビルド プロセスに統合されています。 ビルド時に、更新された文字列が各言語の .xlf ファイルに自動で追加されます。
擬似言語を使ってアプリをテストした後は、アプリをリリース用言語に翻訳します。その方法には 3 種類あります。

#### <a name="option-1-translate-the-strings-yourself"></a>オプション 1. 自分で文字列を翻訳する

多言語エディターを使用して、文字列を個別に翻訳することができます。 既に説明したように、これは [.msi インストーラー](https://developer.microsoft.com/en-us/windows/develop/multilingual-app-toolkit) に含まれています。

- 翻訳する .xlf ファイルを右クリックします。
- **[ファイルを開くアプリケーションの選択]** をクリックして多言語エディターを選択します。 必要に応じて、**[既定値として設定]** をクリックすることもできます。
- 各文字列名について、**[ソース]** には既定の言語での元の文字列が表示されます。 **[翻訳]** に、編集している .xlf ファイルの適切な言語に翻訳された文字列を入力します。
- 完了したら、ファイルを保存して閉じます。

翻訳された文字列が、編集していた .xlf ファイルに対応するリソース ファイル (.resw) にコピーされるようにプロジェクトをリビルドします。

次のように、多言語エディターを起動することもできます。 [スタート] に移動してすべてのアプリを表示し、多言語アプリ ツールキット フォルダーを開き、[Multilingual Editor] (多言語エディター) をクリックして起動します。

#### <a name="option-2-send-the-xlf-files-to-a-third-party-for-translation"></a>オプション 2. .xlf ファイルをサード パーティに送付して翻訳を依頼する

翻訳と編集の作業をローカライズ業者に委託するには、ソリューション エクスプローラーで必要な .xlf ファイルを選択して右クリックし、**[多言語アプリ ツールキット]** > **[Export translations...]** (翻訳をエクスポート...) をクリックします。

選択**出力。メールの宛先**エクスポート文字列リソースのダイアログ ボックスをクリックして、ok をクリックし、ファイルは圧縮し、新しいメールに添付します。 選択**出力。ファイル フォルダーの場所**、ブラウザー フォルダーとクリックを必要に応じて用に選択ファイルを圧縮するには、[ok] を再度クリックし、ファイル (zip 形式と)、プロジェクトの名前が付いた新しいフォルダーの中に、選択した場所に保存します。

ローカライズ担当者が翻訳作業を完了して翻訳済みの xlf ファイルが送られてきたら、それをプロジェクトにインポートすることができます。 ソリューション エクスプ ローラーで目的の .xlf ファイルを選択し、右クリック、をクリックして**Multilingual App Toolkit** > **翻訳のインポート/リサイクルしています.**.クリックして**追加**、.xlf または .zip ファイルに移動し、クリックして、**インポート**します。

**注** インポート前にはインポート プロセスによって基本事項が検証されます。 これは、インポートするファイル内の対象となるカルチャ情報が現在の .xlf ファイルのカルチャ情報と一致することを確認するためのものです。

翻訳された文字列が、インポートした .xlf ファイルに対応するリソース ファイル (.resw) にコピーされるようにプロジェクトをリビルドします。

次のサード パーティ プロバイダーはローカライズ サービスを提供していて、ユーザーを支援できる可能性があります。

- [Elanex](https://www.elanex.com/)
- [Keywords Studios](https://www.keywordsstudios.com/)
- [Lionbridge](https://www.lionbridge.com)
- [Moravia](https://www.moravia.com/)
- [SDL](https://www.sdl.com/languagecloud/managed-translation/ilp/instantquote)
- [Welocalize](https://www.welocalize.com/)

> [!NOTE]
> 上記のリストは情報提供のみを目的としており、推奨するものではありません。 Microsoft は、これらのベンダーやそのサービスに関し、いかなる表明および保証もするものではありません。また、どのような状況でも、Microsoft はそれらのベンダーやサービスの使用に関し、いかなる責任も負いません。 それらのベンダーまたはそのサービスに関する論争、苦情、請求については、それぞれのベンダーに問い合わせる必要があります。

#### <a name="option-3-use-the-integrated-translation-services"></a>オプション 3. 統合された翻訳サービスを使う

多言語エディターに加えて Visual Studio IDE にも翻訳サービスが統合されています。 これによって、リソースをローカライズするときだけではなく、製品の開発中にも翻訳サービスに容易にアクセスできます。 このサービスには、「[Microsoft Translator Moves to the Azure portal](https://multilingualapptoolkit.uservoice.com/knowledgebase/articles/1167898-microsoft-translator-moves-to-the-azure-portal) (Microsoft Translator が Azure portal に移行)」に記述されている Azure アカウントのサブスクリプションが必要になります。

Visual Studio 内で翻訳サービスにアクセスするには、ソリューション エクスプローラーで 1 つ以上の .xlf ファイルを選択して右クリックし、**[Generate machine translations]** (機械翻訳の生成) をクリックします。

多言語エディターを使用する場合も、対話形式で翻訳候補を追加する同様の翻訳サポートが提供され、リソース文字列に最適な翻訳を選ぶことができます。 翻訳候補が挿入されたら、各自の翻訳スタイルに合わせて文字列を調整することができます。

多言語アプリ ツールキットには、2 種類のプロバイダーが付属しています。

- [Microsoft Language Portal](https://go.microsoft.com/fwlink/p/?LinkId=330295) プロバイダーは、Microsoft の製品やサービスのユーザー インターフェイス テキストの翻訳に基づいて、翻訳のリサイクルおよび用語の検索を可能にします。
- [Microsoft Translator](https://go.microsoft.com/fwlink/p/?LinkId=258220) プロバイダーは、オンデマンドの機械翻訳サービスを実現します。

多言語エディターでは、翻訳に確信が持てない箇所を後で確認できるよう、翻訳の状態を管理することができます。 各文字列の状態を設定することができます、**プロパティ**タブ。状態値は次のとおりです。**新しい**、 **Needs review**、**翻訳**、**最終的な**、および**サインオフ**します。 行の左にあるインジゲーターに状態が示されます。 多言語エディターですべての行が緑色になれば、翻訳作業は終了となります。

翻訳された文字列が、編集した .xlf ファイルに対応するリソース ファイル (.resw) にコピーされるようにプロジェクトをリビルドします。

### <a name="step-7-upload-your-app-to-the-microsoft-store"></a>手順 7. Microsoft Store へのアプリのアップロード

Microsoft Store の認定プロセスを開始する前に、`<project-name>.qps-ploc.xlf` ファイルをプロジェクトから除外する必要があります。 擬似言語を使うと、ローカライズの可否に関して起きる可能性のある問題やバグを検出できますが、擬似言語は有効な Microsoft Store の言語ではありません。 除外しなかった場合、Microsoft Store の認定プロセスでアプリが不合格になります。

## <a name="related-topics"></a>関連トピック

* [UI とアプリ パッケージ マニフェスト内の文字列をローカライズする](../../app-resources/localize-strings-ui-manifest.md)
* [グローバリゼーションとローカライズ](globalizing-portal.md)
* [グローバル化するためのガイドライン](guidelines-and-checklist-for-globalizing-your-app.md)
* [ローカライズ可能なアプリを作成します。](prepare-your-app-for-localization.md)
* [Bcp-47 言語タグ](https://go.microsoft.com/fwlink/p/?linkid=227302)

## <a name="downloads"></a>ダウンロード

* [Multilingual App Toolkit 4.0 .vsix インストーラー](https://marketplace.visualstudio.com/items?itemName=MultilingualAppToolkit.MultilingualAppToolkit-18308)
* [Multilingual App Toolkit 4.0 .msi インストーラー](https://developer.microsoft.com/en-us/windows/develop/multilingual-app-toolkit)

## <a name="translation-services"></a>翻訳サービス

* [Microsoft ランゲージ ポータル](https://go.microsoft.com/fwlink/p/?LinkId=330295)
* [Microsoft Translator](https://go.microsoft.com/fwlink/p/?LinkId=258220)
