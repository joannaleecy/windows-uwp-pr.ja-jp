---
Description: Some kinds of apps (multilingual dictionaries, translation tools, etc.) need to override the default behavior of an app bundle, and build resources into the app package instead of having them in separate resource packages. This topic explains how to do that.
title: リソースをリソース パックではなくアプリ パッケージに組み込む
template: detail.hbs
ms.date: 11/14/2017
ms.topic: article
keywords: Windows 10, UWP, リソース, 画像, アセット, MRT, 修飾子
ms.localizationpriority: medium
ms.openlocfilehash: 8bf2d34bc3dae20750f66c9116499a17444b798c
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8883219"
---
# <a name="build-resources-into-your-app-package-instead-of-into-a-resource-pack"></a>リソースをリソース パックではなくアプリ パッケージに組み込む

一部の種類のアプリ (多言語の辞書、翻訳ツールなど) は、アプリ バンドルの既定の動作をオーバーライドし、別のリソース パッケージ (またはリソース パック) ではなくアプリ パッケージにリソースを組み込む必要があります。 このトピックでは、その方法について説明します。

既定では、[アプリ バンドル (.appxbundle)](../packaging/packaging-uwp-apps.md) の作成時に、言語、スケール、DirectX 機能レベルに応じた既定のリソースのみがアプリ パッケージに組み込まれます。 翻訳済みのリソースおよび既定以外のスケールまたは DirectX 機能レベルに合わせてカスタマイズされたリソースは、リソース パッケージに組み込まれ、それを必要とするデバイスにのみダウンロードされます。 ユーザーが言語の優先順位がスペイン語に設定されたデバイスを使用して Microsoft Store からアプリを購入する場合、アプリとスペイン語のリソース パッケージのみがダウンロードおよびインストールされます。 同じユーザーが後から **[設定]** で言語の優先順位をフランス語に変更した場合は、アプリのフランス語のリソース パッケージがダウンロードおよびインストールされます。 スケールおよび DirectX 機能レベルに対して修飾されたリソースでも同様のことが行われます。 ほとんどのアプリで、この動作は有益な効率性をもたらします。これはまさに開発者とユーザーが*必要としている*ことです。

ただし、(**[設定]** からではなく) アプリ内ですぐにユーザーが言語を変更できるようにしている場合、その既定の動作は適切ではありません。 実際にはすべての言語リソースがアプリと一緒に一度に無条件にダウンロードおよびインストールされ、デバイスに残る必要があります。 別のリソース パッケージではなく、アプリ パッケージにこれらのリソースをすべて組み込む必要があります。

**メモ** アプリ パッケージにリソースを含めると、基本的にアプリのサイズが増加します。 そのため、アプリの特性によりそれが必要とされる場合にのみ実行する価値があります。 それ以外の場合は、通常のアプリ バンドルを通常どおりにビルドする以外は何も処理を行う必要はありません。

Visual Studio を構成して、2 つの方法のいずれかでアプリ パッケージにリソースを組み込むことができます。 構成ファイルをプロジェクトに追加するか、またはプロジェクト ファイルを直接編集することができます。 これらのうち使いやすいオプション、またはビルド システムで最適に機能するオプションを使用してください。

## <a name="option-1-use-priconfigpackagingxml-to-build-resources-into-your-app-package"></a>オプション 1. priconfig.packaging.xml を使用して、アプリ パッケージにリソースを組み込む

1. Visual Studio で、新しい項目をプロジェクトに追加します。 XML ファイルを選択し、ファイルに `priconfig.packaging.xml` という名前を付けます。
2. ソリューション エクスプローラーで、`priconfig.packaging.xml` を選択し、[プロパティ] ウィンドウを確認します。 ファイルの [ビルド アクション] を [なし] に設定し、[出力ディレクトリにコピー] を [コピーしない] に設定します。
3. ファイルの内容をこの XML に置き換えます。
   ```xml
   <packaging>
      <autoResourcePackage qualifier="Language" />
      <autoResourcePackage qualifier="Scale" />
      <autoResourcePackage qualifier="DXFeatureLevel" />
   </packaging>
   ```
4. 各 `<autoResourcePackage>` 要素は Visual Studio に対して、特定の修飾子名のリソースを別のリソース パッケージに自動的に分割するように指示します。 これは*自動分割*と呼ばれます。 ファイルの内容はこれまでのものであり、Visual Studio の動作を実際には変更していません。 つまり、これらの内容が既定値であるため、Visual Studio はこれらの内容を持つファイルが存在しているかのように*既に動作しました*。 Visual Studio で修飾子名に対して自動分割を行わない場合は、ファイルから `<autoResourcePackage>` 要素を削除します。 すべての言語リソースが別のリソース パッケージに自動分割されるのではなくアプリ パッケージに組み込まれるようにする場合、ファイルの外観は次のようになります。
   ```xml
   <packaging>
      <autoResourcePackage qualifier="Scale" />
      <autoResourcePackage qualifier="DXFeatureLevel" />
   </packaging>
   ```
5. ファイルを保存して閉じ、プロジェクトをリビルドします。

自動分割の選択肢が適用されていることを確認するには、`<ProjectFolder>\obj\<ReleaseConfiguration folder>\split.priconfig.xml` ファイルを探し、その内容が選択内容に一致することを確認します。 一致する場合は、選択したリソースをアプリ パッケージに組み込むように Visual Studio を正常に構成したことになります。

実行する必要がある最後の手順が 1 つあります。 **ただし、`Language` 修飾子名** を削除した場合にのみ行います。 統合したすべてのアプリのサポートされている言語をアプリの言語の既定値として指定する必要があります。 詳細については、「[アプリで使用する既定のリソースを指定する](specify-default-resources-installed.md)」を参照してください。 アプリ パッケージに英語、スペイン語、フランス語のリソースを含んでいる場合、`priconfig.default.xml` の内容は次のようになります。

```xml
   <default>
      <qualifier name="Language" value="en;es;fr" />
      ...
   </default>
```

### <a name="how-does-this-work"></a>この処理のしくみ

バックグラウンドで、Visual Studio は `MakePri.exe` というツールを起動し、パッケージ リソース インデックスと呼ばれるファイルを生成します。このファイルには、自動分割するリソース修飾子名を示すなど、アプリのすべてのリソースについての情報を記述しています。 このツールの詳細については、「[MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)」を参照してください。 Visual Studio は構成ファイルを `MakePri.exe` に渡します。 `priconfig.packaging.xml` ファイルの内容はその構成ファイルの `<packaging>` 要素として使用され、これが自動分割を指定する部分となります。 そのため、最終的には `priconfig.packaging.xml` を追加および編集すると、Visual Studio がアプリに対して生成するパッケージ リソース インデックス ファイルの内容だけでなく、アプリ バンドルのパッケージの内容に影響します。

### <a name="using-a-different-file-name-than-priconfigpackagingxml"></a>`priconfig.packaging.xml` とは異なるファイル名の使用

ファイルに `priconfig.packaging.xml` という名前を付けると、Visual Studio はそれを自動的に認識して使用します。 異なる名前を付けた場合、Visual Studio がそれを認識できるようにする必要があります。 プロジェクト ファイルで、`<PropertyGroup>` 要素の開始タグと終了タグの間にこの XML を追加します。

```xml
<AppxPriConfigXmlPackagingSnippetPath>FILE-PATH-AND-NAME</AppxPriConfigXmlPackagingSnippetPath>
```

`FILE-PATH-AND-NAME` をファイルのパスおよび名前に置き換えます。

## <a name="option-2-use-your-project-file-to-build-resources-into-your-app-package"></a>オプション 2. プロジェクト ファイルを使用して、アプリ パッケージにリソースを組み込む

これは、オプション 1 に代わる方法です。 オプション 1 のしくみを理解したら、オプション 2 の方が開発またはビルドのワークフローに最適である場合、オプション 2 を代わりに選択することができます。

プロジェクト ファイルで、`<PropertyGroup>` 要素の開始タグと終了タグの間にこの XML を追加します。

```xml
<AppxBundleAutoResourcePackageQualifiers>Language|Scale|DXFeatureLevel</AppxBundleAutoResourcePackageQualifiers>
```

最初の修飾子名を削除したら、次のようになります。

```xml
<AppxBundleAutoResourcePackageQualifiers>Scale|DXFeatureLevel</AppxBundleAutoResourcePackageQualifiers>
```

ファイルを保存して閉じ、プロジェクトをリビルドします。

実行する必要がある最後の手順が 1 つあります。 **ただし、`Language` 修飾子名** を削除した場合にのみ行います。 統合したすべてのアプリのサポートされている言語をアプリの言語の既定値として指定する必要があります。 詳細については、「[アプリで使用する既定のリソースを指定する](specify-default-resources-installed.md)」を参照してください。 アプリ パッケージに英語、スペイン語、フランス語のリソースを含んでいる場合、プロジェクト ファイルの内容は次のようになります。

```xml
<AppxDefaultResourceQualifiers>Language=en;es;fr</AppxDefaultResourceQualifiers>
```

## <a name="related-topics"></a>関連トピック

* [Visual Studio で UWP アプリをパッケージ化する](../packaging/packaging-uwp-apps.md)
* [MakePri.exe を使用して手動でリソースをコンパイルする](compile-resources-manually-with-makepri.md)
* [アプリで使用する既定のリソースを指定する](specify-default-resources-installed.md)