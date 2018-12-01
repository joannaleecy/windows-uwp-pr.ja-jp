---
Description: If your app doesn't have resources that match the particular settings of a customer device, then the app's default resources are used. This topic explains how to specify what those default resources are.
title: アプリで使用する既定のリソースを指定する
template: detail.hbs
ms.date: 11/14/2017
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: f18a1db19c3a8c6632a8cbc3104dc1328f97fdb4
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8350267"
---
# <a name="specify-the-default-resources-that-your-app-uses"></a>アプリで使用する既定のリソースを指定する

アプリにユーザーのデバイスの特定の設定に一致するリソースがない場合、アプリの既定のリソースが使用されます。 このトピックでは、これらの既定のリソースの内容を指定する方法について説明します。

ユーザーが Microsoft Store からアプリをインストールするときに、ユーザーのデバイスの設定は、アプリの利用可能なリソースと照合されます。 この照合は、適切なリソースのみがそのユーザーに対してダウンロードおよびインストールされる必要があるようにするために行われます。 たとえば、ユーザーの言語の優先順位の最も適切な文字列とイメージ、およびデバイスの解像度と DPI 設定が使用されます。 たとえば、`200` は `scale` の既定値ですが、必要な場合はその既定値を上書きできます。

自分のリソース パックに移動しないリソース (ハイ コントラスト設定に合わせたイメージなど) でも、ユーザーの設定に一致するリソースが見つからない場合に実行時にアプリで使用する必要がある既定のリソースを指定できます。 たとえば、`standard` は `contrast` の既定値ですが、必要な場合はその既定値を上書きできます。

これらの既定値は、既定のリソース修飾子の値の形式で指定します。 リソース修飾子の内容については、「[言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」を参照してください。

これらの既定値の内容は、2 つの方法のいずれかで構成できます。 構成ファイルをプロジェクトに追加するか、またはプロジェクト ファイルを直接編集することができます。 これらのうち使いやすいオプション、またはビルド システムで最適に機能するオプションを使用してください。

## <a name="option-1-use-priconfigdefaultxml-to-specify-default-qualifier-values"></a>オプション 1. priconfig.default.xml を使用して、既定の修飾子の値を指定する

1. Visual Studio で、新しい項目をプロジェクトに追加します。 XML ファイルを選択し、ファイルに `priconfig.default.xml` という名前を付けます。
2. ソリューション エクスプローラーで、`priconfig.default.xml` を選択し、[プロパティ] ウィンドウを確認します。 ファイルの [ビルド アクション] を [なし] に設定し、[出力ディレクトリにコピー] を [コピーしない] に設定します。
3. ファイルの内容をこの XML に置き換えます
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
   
   **メモ** 値 `LANGUAGE-TAG(S)` は、アプリの既定の言語と同期する必要があります。 それが単一の [BCP-47 言語タグ](http://go.microsoft.com/fwlink/p/?linkid=227302) である場合は、アプリの既定の言語は同じタグである必要があります。 それが言語タグのコンマ区切りのリストである場合、アプリの既定の言語はリストの最初のタグである必要があります。 アプリ パッケージ マニフェスト ソース ファイル (`Package.appxmanifest`) の **[アプリケーション]** タブの **[既定の言語]** フィールドでアプリの既定の言語を設定します。

4. 各 `<qualifier>` 要素は Visual Studio に対して、各修飾子名の既定値として使用する値を指示します。 ファイルの内容はこれまでのものであり、Visual Studio の動作を実際には変更していません。 つまり、これらの内容が既定値であるため、Visual Studio はこれらの内容を持つファイルが存在しているかのように*既に動作しました*。 そのため、既定値を独自の既定値で上書きするには、ファイル内の値を変更する必要があります。 最初の 3 つの値を編集した場合、ファイルの外観は次のようになります。
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
5. ファイルを保存して閉じ、プロジェクトをリビルドします。

上書きされた既定値が適用されていることを確認するには、`<ProjectFolder>\obj\<ReleaseConfiguration folder>\priconfig.xml` ファイルを探し、その内容が上書き値に一致することを確認します。 一致する場合は、アプリが既定で使用するリソースの修飾子の値を正常に構成したことになります。 ユーザーの設定の一致対象が見つからない場合は、フォルダー名またはファイル名にここで設定した既定の修飾子の値が含まれているリソースが使用されます。

### <a name="how-does-this-work"></a>この処理のしくみ

バックグラウンドで、Visual Studio は `MakePri.exe` というツールを起動し、パッケージ リソース インデックス (PRI) と呼ばれるファイルを生成します。このファイルには、既定のリソースを示すなど、アプリのすべてのリソースについての情報を記述しています。 このツールの詳細については、「[MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)」を参照してください。 Visual Studio は、構成ファイルを `MakePri.exe` に渡します。 `priconfig.default.xml` ファイルの内容が、その構成ファイルの `<default>` 要素として使用されます。この要素は、既定値と見なされる修飾子の値のセットを指定する部分です。 そのため、最終的には `priconfig.default.xml` を追加および編集すると、Visual Studio がアプリに対して生成し、そのアプリ パッケージに含めるパッケージ リソース インデックス ファイルの内容に影響します。

**メモ** `<qualifier name="Language" ... />` 要素の値を変更するときは、その変更をアプリの既定の言語で同期する必要があります。 これは、アプリの PRI ファイルでインデックスが作成された言語リソースがアプリのマニフェストの既定の言語に一致するようにするためです。 `<qualifier name="Language" ... />` 要素の値は、`<ProjectFolder>\obj\<ReleaseConfiguration folder>\priconfig.xml` の内容に関してマニフェストの値を上書きしますが、そのファイルとアプリのマニフェストは一致する必要があります。

### <a name="using-a-different-file-name-than-priconfigdefaultxml"></a>`priconfig.default.xml` とは異なるファイル名の使用

ファイルに `priconfig.default.xml` という名前を付けると、Visual Studio はそれを自動的に認識して使用します。 異なる名前を付けた場合、Visual Studio がそれを認識できるようにする必要があります。 プロジェクト ファイルで、`<PropertyGroup>` 要素の開始タグと終了タグの間にこの XML を追加します。

```xml
<AppxPriConfigXmlDefaultSnippetPath>FILE-PATH-AND-NAME</AppxPriConfigXmlDefaultSnippetPath>
```

`FILE-PATH-AND-NAME` をファイルのパスおよび名前に置き換えます。

## <a name="option-2-use-your-project-file-to-specify-default-qualifier-values"></a>オプション 2. プロジェクト ファイルを使用して、既定の修飾子の値を指定する

これは、オプション 1 に代わる方法です。 オプション 1 のしくみを理解したら、オプション 2 の方が開発またはビルドのワークフローに最適である場合、オプション 2 を代わりに選択することができます。

プロジェクト ファイルで、`<PropertyGroup>` 要素の開始タグと終了タグの間にこの XML を追加します。

```xml
<AppxDefaultResourceQualifiers>Language=LANGUAGE-TAG(S)|Contrast=standard|Scale=200|HomeRegion=001|TargetSize=256|LayoutDirection=LTR|DXFeatureLevel=DX9|Configuration=|AlternateForm=</AppxDefaultResourceQualifiers>
```

最初の 3 つの値を編集したら、次のようになります。

```xml
<AppxDefaultResourceQualifiers>Language=de-DE|Contrast=black|Scale=400|HomeRegion=001|TargetSize=256|LayoutDirection=LTR|DXFeatureLevel=DX9|Configuration=|AlternateForm=</AppxDefaultResourceQualifiers>
```

ファイルを保存して閉じ、プロジェクトをリビルドします。

**メモ** `Language=` 値を変更するときは、マニフェスト デザイナーで (`Package.appxmanifest` を開いて) その変更をアプリの既定の言語に同期する必要があります)。

## <a name="related-topics"></a>関連トピック

* [言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)
* [BCP-47 言語タグ](http://go.microsoft.com/fwlink/p/?linkid=227302)
* [MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)
