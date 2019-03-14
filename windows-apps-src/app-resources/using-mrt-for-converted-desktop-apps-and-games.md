---
title: 変換されたデスクトップ アプリとゲームに MRT を使用する
description: .NET または Win32 アプリやゲームを AppX パッケージとしてパッケージ化することにより、リソース管理システムを活用して実行時のコンテキストに合わせたアプリ リソースを読み込むことができます。 この詳細なトピックでは、この手法について説明します。
ms.date: 10/25/2017
ms.topic: article
keywords: Windows 10、UWP、MRT、PRI。 リソース、ゲーム、Centennial、Desktop App Converter、MUI、サテライト アセンブリ
ms.localizationpriority: medium
ms.openlocfilehash: 287c22cbd50f1b69f505bbddd445740fe9422c31
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57597017"
---
# <a name="use-the-windows-10-resource-management-system-in-a-legacy-app-or-game"></a>レガシ アプリやゲームで Windows 10 のリソース管理システムを使用する

## <a name="overview"></a>概要

.NET アプリや Win32 アプリは多くの場合、対象市場を拡大するため、さまざまな言語にローカライズされます。 アプリのローカライズの価値提案の詳細については、「[グローバリゼーションとローカライズ](../design/globalizing/globalizing-portal.md)」をご覧ください。 .NET または Win32 アプリやゲームを AppX パッケージとしてパッケージ化することにより、リソース管理システムを活用して実行時のコンテキストに合わせたアプリ リソースを読み込むことができます。 この詳細なトピックでは、この手法について説明します。

従来の Win32 アプリケーションをローカライズする方法はたくさんありますが、Windows 8 では[新しいリソース管理システム](https://msdn.microsoft.com/en-us/library/windows/apps/jj552947.aspx)が導入されました。このリソース管理システムは、さまざまなプログラミング言語やさまざまな種類のアプリケーションで動作し、ローカライズ機能を簡素化するだけでなく、さまざまな機能を提供します。 このトピックでは、このシステムを "MRT" と呼びます。 「モダン」という用語の使用は停止されましたが、MRT は従来 "Modern Resource Technology" を表していました。 リソース マネージャーは、MRM (モダン リソース マネージャー) または PRI (パッケージ リソース インデックス) としても知られています。

AppX ベースの展開 (Microsoft Store を使った展開など) と組み合わせることにより、MRT はユーザーとデバイスに最適なリソースを自動的に配布します。これにより、アプリケーションのダウンロードとインストールのサイズを最小化することができます。 ローカライズ コンテンツのサイズが大きなアプリケーションでは、これによって大きなサイズ削減効果があり、高度なゲームの場合では、数*ギガバイト*にも及ぶ削減効果となることがあります。 さらに、Windows シェルと Microsoft Store でローカライズされて表示されることや、ユーザーの使用言語と利用可能なリソースが一致しない場合の自動フォールバック ロジックなども、MRT によるメリットの例です。

このドキュメントでは、MRT のアーキテクチャの概要を説明し、レガシの Win32 アプリケーションを最小限のコード変更で MRT に移行するためのガイドを示します。 MRT への移行により、開発者にはさまざまなメリット (スケール ファクターやシステム テーマを使ったリソースのセグメント化など) があります。 MRT ベースのローカライズは、UWP アプリケーションと、デスクトップ ブリッジ ("Centennial") によって処理される Win32 アプリケーションの両方で動作します。

多くの場合、既存のローカライズ形式とソース コードを引き続き使用しながら、MRT との統合を行い、実行時にリソースを解決して、ダウンロード サイズを最小化することができます。これはオールオアナッシングのアプローチではありません。 各段階での作業とメリット、推定コストを次の表にまとめて示します。 この表には、高解像度またはハイ コントラストのアプリケーション アイコンの提供などの、ローカライズ以外のタスクは含まれていません。 タイル、アイコンなどへの複数のアセットの提供について詳しくは、「[言語、スケール、ハイ コントラスト、その他の修飾子用にリソースを調整する](tailor-resources-lang-scale-contrast.md)」をご覧ください。

<table>
<tr>
<th>仕事用</th>
<th>メリット</th>
<th>推定コスト</th>
</tr>
<tr>
<td>AppX マニフェストをローカライズする</td>
<td>Windows シェルと Microsoft Store でローカライズ コンテンツが表示されるために必要な最小限の作業</td>
<td>小</td>
</tr>
<tr>
<td>MRT を使ってリソースを識別して検索する</td>
<td>ダウンロードとインストールのサイズの最小化や、言語の自動フォールバックの前提条件</td>
<td>中</td>
</tr>
<tr>
<td>リソース パッケージをビルドする</td>
<td>ダウンロードとインストールのサイズを最小化するための最後の手順</td>
<td>小</td>
</tr>
<tr>
<td>MRT リソース形式と API へ移行する</td>
<td>大幅に小さなファイル サイズ (既存のリソース テクノロジによる)</td>
<td>大</td>
</tr>
</table>

## <a name="introduction"></a>概要

多くのアプリケーションには通常、アプリケーション コードから分離された、*リソース*と呼ばれるユーザー インターフェイス要素が含まれています (一方、値を*ハードコード*する場合は、ソース コード自体に記述されます)。 ハードコードしないで、リソースを使用することが好ましい理由はいろいろあります。たとえば、開発者以外でも編集が容易であることもその 1 つです。最も重要なメリットの 1 つは、アプリケーションが実行時に、同じ論理リソースの異なる表現を選択できることです。 たとえば、ボタンに表示するテキスト (またはアイコンに表示するイメージ) が、ユーザーの使用言語や、表示デバイスの種類、使用している支援技術などによって、異なる場合があります。

したがって、リソース管理テクノロジの主な目的は、実行時に、論理またはシンボリックな*リソース名* (`SAVE_BUTTON_LABEL`など) の要求を、一連の*候補* (たとえば、「Save」、「Speichern」、「保存」) の中から、実際に最適な*値* (たとえば「保存」) に変換することです。 MRT はそのための機能を提供し、アプリケーションは、*修飾子*と呼ばれる、ユーザーの言語、ディスプレイのスケール ファクター、ユーザーが選択したテーマ、その他の環境の要因などの、さまざまな属性を使って、リソースの候補を識別することができます。 さらに MRT は、アプリケーションが必要とする、カスタムの修飾子をサポートします (たとえば、アプリケーションが、ゲスト ユーザーとアカウントを使ってログインしたユーザーに対して、別のグラフィック アセットを提供することができます。これを、アプリケーションのあらゆる部分にチェックのロジックを追加することなく、行えます)。 MRT は、文字列リソースとファイル ベースのリソース (外部データ、つまりファイル自体への参照として実装されている場合) の両方で動作します。 

### <a name="example"></a>例

2 つのボタン (`openButton` と `saveButton`) 上のテキスト ラベルと、ロゴ (`logoImage`) に使用する PNG ファイルを持つアプリケーションでの、簡単な例を次に示します。 テキスト ラベルは英語とドイツ語にローカライズされ、ロゴは通常のデスクトップ (100% スケール ファクター) と高解像度の電話 (300% スケール ファクター) 用に最適化されています。 この図は、モデルの概念と概要を説明するためのものであり、実装に正確に対応するものではないことにご注意ください。

<p><img src="images\conceptual-resource-model.png"/></p>

この図で、アプリケーション コードは 3 つの論理リソース名を参照しています。 実行時に、擬似関数 `GetResource` は、MRT を使用して、リソース テーブル (PRI ファイルと呼ばれます) で、そのリソース名を検索し、環境条件 (ユーザーの言語とディスプレイのスケール ファクター) に基づいて、最適な候補を見つけます。 ラベルの場合は、文字列が直接使用されます。 ロゴ イメージの場合は、文字列がファイル名として解釈され、ファイルがディスクから読み取られます。 

ユーザーの言語が英語とドイツ語以外の場合、またディスプレイのスケール ファクターが 100% と 300% 以外の場合は、MRT はフォールバック規則のセットに基づいて、最も「近い」候補を選びます (詳しくは、[MSDN の**リソース管理システム**のトピック](https://msdn.microsoft.com/en-us/library/windows/apps/jj552947.aspx)をご覧ください)。 

ロゴのイメージにもローカライズするために必要な埋め込みのテキストが含まれている場合に、MRT がなどの 1 つ以上の修飾子に対応したリソースをサポートしているメモ、ロゴは、次の 4 つの候補があります。EN/スケール 100、DE/スケール 100、EN/スケール-300、300-DE/スケール。

### <a name="sections-in-this-document"></a>このドキュメントのセクション

以下のセクションでは、アプリケーションを MRT と統合するために必要なタスクの概要を説明します。

**フェーズ 0:アプリケーション パッケージをビルドします。**

このセクションでは、既存のデスクトップ アプリケーションを、アプリケーション パッケージとしてビルドする方法について説明します。 この段階では、MRT の機能は使用しません。

**フェーズ 1:アプリケーション マニフェストをローカライズします。**

このセクションでは、アプリケーションのマニフェストをローカライズする (これにより Windows Shell に正しく表示されるようになります) 方法について説明します。この段階では、引き続き、レガシのリソース形式と API を使用して、リソースのパッケージ化と検索を行っています。 

**フェーズ 2:MRT を使用して識別し、リソースの検索**

このセクションでは、アプリケーション コード (および場合によってリソース レイアウト) を変更し、MRT を使用してリソースを検索する方法について説明します。この段階では、引き続き、既存のリソース形式と API を使用して、リソースの読み込みと使用を行っています。 

**フェーズ 3:リソース パックを作成します。**

このセクションでは、リソースを別の*リソース パッケージ*に分離して、アプリのダウンロード (およびインストール) のサイズを最小化するために必要な、最終的な変更について説明します。

### <a name="not-covered-in-this-document"></a>このドキュメントで扱わない内容

フェーズ 0 ～ 3 を完了すると、Microsoft Store に提出できる、アプリケーション「バンドル」が作成されます。これにより、ユーザーは不要なリソース (たとえば、使用しない言語) を省略でき、ダウンロードとインストールのサイズを最小化できます。 次の最後の手順を実行すると、アプリケーションのサイズと機能をさらに向上することができます。 

**フェーズ 4:MRT リソース形式と Api への移行します。**

このフェーズは、このドキュメントの対象範囲外です。このフェーズでは、MUI DLL や .NET リソース アセンブリなどの、レガシのリソース形式から、PRI ファイルに、リソース (特に文字列) を移行します。 これにより、ダウンロードとインストールのサイズをさらに節約できます。 さらに、MRT の他の機能を活用でき、たとえば、スケール ファクターや、アクセシビリティ設定などに基づいて、イメージ ファイルのダウンロードとインストールを最小化できます。

- - -

## <a name="phase-0-build-an-application-package"></a>フェーズ 0:アプリケーション パッケージをビルドします。

アプリケーションのリソースへの変更を行う前にまず、現在使っているパッケージ化とインストールのテクノロジを、UWP の標準のパッケージ化と展開のテクノロジに置き換える必要があります。 これには 3 つの方法があります。

0. 複雑なインストーラーを備えた大規模なデスクトップ アプリケーションの場合、または多くの OS 拡張ポイントを利用している場合、Desktop App Converter ツールを使用して、既存のアプリ インストーラー (たとえば MSI) から、UWP ファイル レイアウトとマニフェスト情報を生成できます
0. 比較的少ないファイルを扱う小規模なデスクトップ アプリケーションの場合、または拡張フックを使用しないシンプルなインストーラーの場合、手動でファイル レイアウトとマニフェスト情報を作成できます
0. ソースからのリビルドを行って、アプリを「純粋な」UWP アプリケーションに更新する場合は、Visual Studio で新しいプロジェクトを作成し、IDE を活用して多くの作業を行うことができます

使用する場合、 [Desktop App Converter](https://aka.ms/converter)を参照してください[、 **UWP ブリッジにデスクトップ。Desktop App Converter** MSDN のトピック「](https://aka.ms/converterdocs)変換プロセスの詳細についてはします。 Desktop Converter のサンプルの完全なセットは、[GitHub リポジトリの **Desktop Bridge to UWP サンプル**](https://github.com/Microsoft/DesktopBridgeToUWP-Samples)にあります。

パッケージを手動で作成する場合は、すべてのアプリケーション ファイル (実行可能ファイルとコンテンツを含む、ソース コードは含まない) と `AppXManifest.xml` ファイルを含む、ディレクトリ構造を作成する必要があります。 例として [GitHub サンプルの **Hello, World**](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/blob/master/Samples/HelloWorldSample/CentennialPackage/AppxManifest.xml) をご覧ください。デスクトップの実行可能ファイル `ContosoDemo.exe` を実行する、基本的な `AppXManifest.xml` ファイルは次のとおりです。<span style="background-color: yellow">強調表示されているテキスト</span>を置き換えて使うことができます。

<blockquote>
<pre>
&lt;?xml version="1.0" encoding="utf-8" ?&gt;
&lt;Package xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
         xmlns:mp="http://schemas.microsoft.com/appx/2014/phone/manifest"
         xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
         xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
         IgnorableNamespaces="uap mp rescap"&gt;
    &lt;Identity Name="<span style="background-color: yellow">Contoso.Demo</span>"
              Publisher="<span style="background-color: yellow">CN=Contoso.Demo</span>"
              Version="<span style="background-color: yellow">1.0.0.0</span>" /&gt;
    &lt;Properties&gt;
    &lt;DisplayName&gt;<span style="background-color: yellow">Contoso App</span>&lt;/DisplayName&gt;
    &lt;PublisherDisplayName&gt;<span style="background-color: yellow">Contoso, Inc</span>&lt;/PublisherDisplayName&gt;
    &lt;Logo&gt;Assets\StoreLogo.png&lt;/Logo&gt;
  &lt;/Properties&gt;
    &lt;Dependencies&gt;
    &lt;TargetDeviceFamily Name="Windows.Desktop" MinVersion="10.0.14393.0" 
                        MaxVersionTested="10.0.14393.0" /&gt;
  &lt;/Dependencies&gt;
    &lt;Resources&gt;
    &lt;Resource Language="<span style="background-color: yellow">en-US</span>" /&gt;
  &lt;/Resources&gt;
    &lt;Applications&gt;
    &lt;Application Id="<span style="background-color: yellow">ContosoDemo</span>" Executable="<span style="background-color: yellow">ContosoDemo.exe</span>" 
                 EntryPoint="Windows.FullTrustApplication"&gt;
    &lt;uap:VisualElements DisplayName="<span style="background-color: yellow">Contoso Demo</span>" BackgroundColor="#777777" 
                        Square150x150Logo="Assets\Square150x150Logo.png" 
                        Square44x44Logo="Assets\Square44x44Logo.png" 
        Description="<span style="background-color: yellow">Contoso Demo</span>"&gt;
      &lt;/uap:VisualElements&gt;
    &lt;/Application&gt;
  &lt;/Applications&gt;
    &lt;Capabilities&gt;
    &lt;rescap:Capability Name="runFullTrust" /&gt;
  &lt;/Capabilities&gt;
&lt;/Package&gt;
</pre>
</blockquote>

`AppXManifest.xml` ファイルとパッケージ レイアウトについて詳しくは、[MSDN の**アプリ パッケージ マニフェスト**のトピック](https://msdn.microsoft.com/en-us/library/windows/apps/br211474.aspx)をご覧ください。

最後に、Visual Studio を使って新しいプロジェクトを作成し、既存のコード全体を移行するには、[新しい UWP プロジェクトをビルドするための MSDN ドキュメント](https://msdn.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)をご覧ください。 既存のコードを新しいプロジェクトに含めることはできますが、「純粋な」UWP として実行するためには、相当なコードの変更 (特にユーザー インターフェイス) が必要となる場合があります。 それらの変更は、このドキュメントの対象範囲外です。

---

## <a name="phase-1-localize-the-application-manifest"></a>フェーズ 1:アプリケーション マニフェストをローカライズします。

### <a name="step-11-update-strings--assets-in-the-appxmanifest"></a>手順 1.1:文字列の更新 (&)、AppXManifest で資産

フェーズ 0 でアプリケーションのための、基本的な `AppXManifest.xml` ファイルを (コンバーターに提供された値に基づき、または MSI ファイルから抽出し、またはマニフェストに手動で入力して) 作成しましたが、これにはローカライズされた情報は含まれていません。また、高解像度用のスタート画面のタイルのアセットなど、追加機能のサポートも含まれません。 

アプリケーションの名前と説明が正しくローカライズされるためには、リソース ファイルのセットでリソースを定義し、AppX マニフェストを更新して、それらを参照する必要があります。

**既定のリソース ファイルを作成します。**

最初の手順では、既定の言語 (たとえば、英語 (米国)) で既定のリソース ファイルを作成します。 これは、テキスト エディターを使って手動で作成するか、または Visual Studio のリソース デザイナーによって行うことができます。

リソースを手動で作成する場合には:

0. `resources.resw` という XML ファイルを作成して、プロジェクトの `Strings\en-us` サブフォルダーに配置します。 
 * 既定の言語が英語 (米国) 以外の場合には、適切な BCP-47 コードを使用します。 
0. XML ファイルに次のコンテンツを追加します。使用する既定の言語で、<span style="background-color: yellow">強調表示されたテキスト</span>を、アプリのために適切なテキストに置き換えます。

[!Note] これらの文字列の一部の長の制限があります。 詳しくは、「[VisualElements](/uwp/schemas/appxpackage/appxmanifestschema/element-visualelements?branch=live)」をご覧ください。

<blockquote>
<pre>
&lt;?xml version="1.0" encoding="utf-8"?&gt;
&lt;root&gt;
  &lt;data name="ApplicationDescription"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo app with localized resources (English)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="ApplicationDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo Sample (English)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="PackageDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo Package (English)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="PublisherDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Samples, USA</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="TileShortName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso (EN)</span>&lt;/value&gt;
  &lt;/data&gt;
&lt;/root&gt;
</pre>
</blockquote>

Visual Studio でデザイナーを使用する場合は:

0. 作成、`Strings\en-us`プロジェクトのフォルダー (またはその他の言語は、必要に応じて) を追加し、**新しい項目の**プロジェクトのルート フォルダーの既定の名前を使用 `resources.resw`
 * **リソース ディクショナリ**ではなく、必ず**リソース ファイル (.resw)** を選択します。リソース ディクショナリは、XAML アプリケーションで使われるファイルです。
0. デザイナーを使って次の文字列を入力します (同じ `Names` を使用し、`Values` をアプリケーションのために適切なテキストに置き換えます)。

<img src="images\editing-resources-resw.png"/>

注: Visual Studio デザイナーで開始する場合は、`F7` キーを押すと、いつでも XML を直接編集できます。 ただし、最小限の XML ファイルで開始する場合、さまざまな追加のメタデータが含まれていないため、*デザイナーは、ファイルを認識しません*。手動で編集する XML ファイルに、デザイナーが生成したファイルからスケルトンの XSD 情報をコピーすると、この問題を解決できます。 

**リソースを参照するマニフェストを更新します。**

`.resw`ファイルで値を定義したら、次にマニフェストを更新して、文字列リソースを参照します。 ここでも、XML ファイルを直接編集するか、Visual Studio のマニフェスト デザイナーを利用できます。

XML を直接編集する場合は、`AppxManifest.xml` ファイルを開き、<span style="background-color: lightgreen">強調表示された値</span>に次の変更を行います。これは、アプリケーション固有ではなく、このテキストを*そのまま*使用します。 これらのリソース名をそのまま使用する必要はありません。独自の名前を使用できますが、それは `.resw` ファイル内の名前と正確に一致する必要があります。 これらの名前は `.resw` ファイルで作成した `Names` と一致し、`ms-resource:` スキームと `Resources/` 名前空間のプレフィックスが付く必要があります。 

*注: マニフェストの多くの要素は次のスニペットから除外されていますが - 何も削除しないでください。*

<blockquote>
<pre>
&lt;?xml version="1.0" encoding="utf-8"?&gt;
&lt;Package&gt;
  &lt;Properties&gt;
    &lt;DisplayName&gt;<span style="background-color: lightgreen">ms-resource:Resources/PackageDisplayName</span>&lt;/DisplayName&gt;
    &lt;PublisherDisplayName&gt;<span style="background-color: lightgreen">ms-resource:Resources/PublisherDisplayName</span>&lt;/PublisherDisplayName&gt;
  &lt;/Properties&gt;
  &lt;Applications&gt;
    &lt;Application&gt;
      &lt;uap:VisualElements DisplayName="<span style="background-color: lightgreen">ms-resource:Resources/ApplicationDisplayName</span>"
        Description="<span style="background-color: lightgreen">ms-resource:Resources/ApplicationDescription</span>"&gt;
        &lt;uap:DefaultTile ShortName="<span style="background-color: lightgreen">ms-resource:Resources/TileShortName</span>"&gt;
          &lt;uap:ShowNameOnTiles&gt;
            &lt;uap:ShowOn Tile="square150x150Logo" /&gt;
          &lt;/uap:ShowNameOnTiles&gt;
        &lt;/uap:DefaultTile&gt;
      &lt;/uap:VisualElements&gt;
    &lt;/Application&gt;
  &lt;/Applications&gt;
&lt;/Package&gt;
</pre>
</blockquote>

Visual Studio のマニフェスト デザイナーを使っている場合は、`Package.appxmanifest` ファイルを開き、`Application` タブと `Packaging` タブ で、<span style="background-color: lightgreen">強調表示された値</span>を変更します。

<img src="images\editing-application-info.png"/>
<img src="images\editing-packaging-info.png"/>

### <a name="step-12-build-pri-file-make-an-appx-package-and-verify-its-working"></a>手順 1.2:PRI ファイルをビルド、AppX パッケージを行い、確認することが動作

`.pri` ファイルをビルドし、アプリケーションを展開して、(既定の言語で) 正しい情報がスタート メニューに表示されることを確認します。 

Visual Studio でビルドを行う場合は、`Ctrl+Shift+B` を押すとプロジェクトをビルドできます。次にプロジェクトを右クリックして、コンテキスト メニューから `Deploy` を選択します。 

手動でビルドを行う場合は、次の手順に従って、`MakePRI` ツールの構成ファイルを作成し、`.pri` ファイル自体を生成します (詳しくは、[MSDN の**手動によるアプリのパッケージ化**のトピック](https://docs.microsoft.com/en-us/windows/uwp/packaging/manual-packaging-root)をご覧ください)。

0. スタート メニューの `Visual Studio 2015` フォルダーで、開発者用コマンド プロンプトを開きます
0. プロジェクトのルート ディレクトリに切り替えます (`AppxManifest.xml` ファイルと `Strings` フォルダーが含まれます)
0. "Contoso_demo.xml" をプロジェクトに適した名前に置き換え、"en-US" をアプリの既定の言語に置き換えて (または必要に応じて "en-US" のままとして)、次のコマンドを入力します。 xml ファイルは (プロジェクト ディレクトリ**ではなく**) 親ディレクトリに作成されることに注意してください。これはアプリケーションの一部ではないためです (他の任意のディレクトリを選択できますが、それ以降のコマンドで必ず、名前を変更してください)。

```CMD
    makepri createconfig /cf ..\contoso_demo.xml /dq en-US /pv 10.0 /o
```

0. 「`makepri createconfig /?`」と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです。
 * `/cf` 構成ファイル名 (このコマンドの出力) を設定します。
 * `/dq` ここでは、言語、既定の修飾子を設定します。 `en-US`
 * `/pv` このケースの Windows 10 では、プラットフォームのバージョンを設定します。
 * `/o` 存在する場合は、出力ファイルを上書きするように設定します。
0. 構成ファイルが作成されました。`MakePRI` を再度実行して、ディスクにあるリソースを検索し、それを PRI ファイルにパッケージ化します。 "Contoso_demop.xml" を、前の手順で使った XML ファイル名に置き換えます。入力と出力の両方に、必ず親ディレクトリを指定します。 

    `makepri new /pr . /cf ..\contoso_demo.xml /of ..\resources.pri /mf AppX /o`
0. `makepri new /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:
 * `/pr` (この例では、現在のディレクトリ) では、プロジェクトのルートを設定します。
 * `/cf` 前の手順で作成、構成ファイル名を設定します。
 * `/of` 出力ファイルを設定します。 
 * `/mf` マッピング ファイルを作成します (そのため、後の手順でパッケージ内のファイルを除外しましたできます)
 * `/o` 存在する場合は、出力ファイルを上書きするように設定します。
0. 既定の言語リソース (たとえば en-US) を持つ `.pri` が作成されました。 次のコマンドを実行して、正しく動作することを確認します。

    `makepri dump /if ..\resources.pri /of ..\resources /o`
0. `makepri dump /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:
 * `/if` 入力ファイル名を設定します。 
 * `/of` 出力ファイル名を設定 (`.xml`が自動的に追加されます)
 * `/o` 存在する場合は、出力ファイルを上書きするように設定します。
0. 最後に、 `.\resources.xml` をテキスト エディターで開き、`<NamedResource>` の値 (`ApplicationDescription` や `PublisherDisplayName` など) が含まれること、さらに選択した既定の言語の `<Candidate>` が含まれることを確認します (ファイルの先頭には、その他のコンテンツがありますが、ここでは無視してください)。

必要な場合は、マッピング ファイル `.\resources.map.txt` を開いて、プロジェクトに必要なファイル (PRI ファイルを含みます。これはプロジェクトのディレクトリの一部ではありません) が含まれていることを確認します。 マッピング ファイルには、 `resources.resw` ファイルへの参照は含まれて*いません*。これは重要です。そのファイルの内容は既に PRI ファイルに埋め込まれているためです。 ただし、イメージのファイル名などの他のリソースは含まれています。

**ビルドとパッケージに署名します**

PRI ファイルがビルドされました。次はパッケージをビルドして署名します。

0. アプリ パッケージを作成するには、作成する AppX ファイルの名前で `contoso_demo.appx` を置き換えて、次のコマンドを実行します。`.AppX` ファイルに別のディレクトリを選択するようにします (このサンプルでは親ディレクトリを使用しています。任意のディレクトリを指定できますが、プロジェクト ディレクトリ **以外** を指定する必要があります)。

    `makeappx pack /m AppXManifest.xml /f ..\resources.map.txt /p ..\contoso_demo.appx /o`
0. `makeappx pack /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:
 * `/m` 使用するマニフェスト ファイルを設定します。
 * `/f` (前の手順で作成) を使用するファイルのマッピングを設定します。 
 * `/p` 出力を設定するパッケージ名
 * `/o` 存在する場合は、出力ファイルを上書きするように設定します。
0. パッケージが作成されたら、それに署名する必要があります。 署名証明書を取得する最も簡単な方法は、Visual Studio で空のユニバーサル Windows プロジェクトを作成し、コピーは、`.pfx`が作成されるファイルを使用して手動で作成できます、`MakeCert`と`Pvk2Pfx` 」の説明に従ってユーティリティ<a href="https://msdn.microsoft.com/en-us/library/windows/desktop/jj835832.aspx">アプリ パッケージが署名証明書を作成する方法</a>MSDN のトピックです。 
 * 概要署名証明書を手動で作成する場合は、ソース プロジェクトや、パッケージのソース、それ以外の場合、秘密キーを含む、パッケージの一部として含める取得可能性がありますよりも、別のディレクトリに、ファイルを配置することを確認してください!
0. パッケージに署名するには、次のコマンドを使用します。 `AppxManifest.xml` の `Identity` 要素で指定されている `Publisher` は、証明書の `Subject` と一致する必要があります (これは `<PublisherDisplayName>` 要素では**ありません**。それはユーザーに表示されるローカライズされた表示名です)。 通常と同様に、`contoso_demo...` のファイル名をプロジェクトに適した名前で置き換えます。さらに `.pfx` ファイルが現在のディレクトリにないことを確認します (**これは非常に重要です**。そうしない場合、プライベート署名キーを含めて、パッケージの一部として作成されてしまいます)。

    `signtool sign /fd SHA256 /a /f ..\contoso_demo_key.pfx ..\contoso_demo.appx`
0. `signtool sign /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:
 * `/fd` ファイルのダイジェスト アルゴリズム (SHA256 は AppX の既定値) を設定します。
 * `/a` 最適な証明書が自動的に選択します。
 * `/f` 署名証明書を含む入力ファイルを指定します

最後に、`.appx` ファイルをダブルクリックしてインストールします。またはコマンド ラインを使用する場合には、PowerShell プロンプトを開き、パッケージを含むディレクトリへ移動し、次のように入力します (`contoso_demo.appx` を使用するパッケージ名に置き換えます)。

```CMD
    add-appxpackage contoso_demo.appx
```

証明書が信頼されていないというエラーが発生した場合、証明書が (ユーザー ストア**ではなく**) コンピューターのストアに追加されていることを確認します。 コンピューターのストアに証明書を追加するには、コマンドライン、または Windows エクスプローラーを使用します。

コマンドラインを使用する場合:

0. Visual Studio 2015 コマンド プロンプトを管理者として実行します。
0. `.cer` ファイルを含むディレクトリに移動します (このディレクトリが、ソース ディレクトリまたはプロジェクト ディレクトリではないことを確認してください)
0. `contoso_demo.cer` を使用するファイル名と置き換えて、次のコマンドを入力します。

    `certutil -addstore TrustedPeople contoso_demo.cer`
0. `certutil -addstore /?` と入力すると、各パラメーターの意味が表示されますが、主なパラメーターは次のとおりです:
 * `-addstore` 証明書ストアに証明書を追加します。
 * `TrustedPeople` ストアの証明書を配置することを示します

Windows エクスプローラーを使用する場合:

0. `.pfx` ファイルが含まれているフォルダーに移動します
0. `.pfx` ファイルをダブルクリックすると、**証明書インポート ウィザード**が表示されます
0. 選択`Local Machine` をクリック `Next`
0. 表示されたら、クリックすると、ユーザー アカウント制御管理者の昇格時のプロンプトを受け入れる `Next`
0. 、1 つを使用する必要がある場合は、秘密キーのパスワードを入力し、をクリックしてください `Next`
0. 選択します `Place all certificates in the following store`
0. `Browse` をクリックして、(「信頼された発行元」**ではなく**) `Trusted People` フォルダーを選択します
0. クリック`Next`し `Finish`

`Trusted People` ストアに証明書を追加したら、もう一度パッケージをインストールします。

これでアプリは、`.resw` / `.pri` ファイルの正しい情報を使って、スタート メニューの [すべてのアプリ] のリストに表示されます。 空の文字列または `ms-resource:...` の文字列が表示された場合には、何かが間違っています。編集を再度確認し、すべて正しいかどうか確認します。 スタート メニューでアプリを右クリックすると、タイルとしてピン留めすることができ、さらに適切な情報が表示されることを確認できます。

### <a name="step-13-add-more-supported-languages"></a>手順 1.3:サポートされている複数の言語を追加します。

AppX マニフェストに変更が加えられ、初期の `resources.resw` ファイルが作成されたら、追加の言語を容易に追加できます。

**その他のローカライズされたリソースを作成します。**

最初に、追加のローカライズ リソースの値を作成します。 

`Strings` フォルダーで、適切な BCP-47 コードを使って、サポートする各言語のための、追加のフォルダーを作成します (たとえば、`Strings\de-DE`)。 各フォルダー内に、(XML エディターまたは Visual Studio デザイナーを使用して) 翻訳されたリソースの値を含む `resources.resw` ファイルを作成します。 ここでは、既にローカライズされた文字列が利用可能であり、それを `.resw` ファイルにコピーして利用できるものと想定します。このドキュメントでは、翻訳の手順そのものは扱いません。 

たとえば、`Strings\de-DE\resources.resw`ファイルは、次のようになります。<span style="background-color: yellow">強調表示されたテキスト</span>は `en-US` から変更されました。

<blockquote>
<pre>
&lt;?xml version="1.0" encoding="utf-8"?&gt;
&lt;root&gt;
  &lt;data name="ApplicationDescription"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo app with localized resources (German)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="ApplicationDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo Sample (German)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="PackageDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Demo Package (German)</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="PublisherDisplayName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso Samples, DE</span>&lt;/value&gt;
  &lt;/data&gt;
  &lt;data name="TileShortName"&gt;
    &lt;value&gt;<span style="background-color: yellow">Contoso (DE)</span>&lt;/value&gt;
  &lt;/data&gt;
&lt;/root&gt;
</pre>
</blockquote>

次の手順では、`de-DE` と `fr-FR` の両方のリソースを追加したものと想定します。他の言語でも同じパターンで行うことができます。

**AppX マニフェストの言語のサポートされている一覧を更新します。**

AppX マニフェストを更新して、アプリがサポートする言語をリストする必要があります。 Desktop App Converter は、既定の言語を追加しますが、他の言語は明示的に追加する必要があります。 `AppxManifest.xml` ファイルを直接編集する場合、`Resources` ノードを次のように更新します。必要な要素を追加し、<span style="background-color: yellow">サポートする適切な言語</span>を置き換え、一覧の最初のエントリが既定の (フォールバック) 言語となるようにします。 この例では、既定値は英語 (米国) で、ドイツ語 (ドイツ)、フランス語 (フランス) が追加でサポートされます。

<blockquote>
<pre>
&lt;Resources&gt;
  &lt;Resource Language="<span style="background-color: yellow">EN-US</span>" /&gt;
  &lt;Resource Language="<span style="background-color: yellow">DE-DE</span>" /&gt;
  &lt;Resource Language="<span style="background-color: yellow">FR-FR</span>" /&gt;
&lt;/Resources&gt;
</pre>
</blockquote>

Visual Studio を使っている場合、何もする必要はありません。`Package.appxmanifest` には、特別な <span style="background-color: yellow">x-generate</span> 値が含まれます。これによってビルド プロセスで、プロジェクトに含まれる (BCP-47 コードを使った名前のフォルダーに基づく) 言語が挿入されます。 これは実際の Appx マニフェストでは有効な値ではないことに注意してください。これは Visual Studio プロジェクトでのみ動作します。

<blockquote>
<pre>
&lt;Resources&gt;
  &lt;Resource Language="<span style="background-color: yellow">x-generate</span>" /&gt;
&lt;/Resources&gt;
</pre>
</blockquote>

**ローカライズされた値を再構築します。**

ここで再度、アプリケーションのビルドを行ってデプロイすることができます。Windows で言語の選択を変更すると、新たにローカライズされた値がスタート メニューに表示されます (言語を変更する方法については、以下で説明します)。

ここでも、Visual Studio では `Ctrl+Shift+B` を使ってビルドを行い、プロジェクトで右クリックして `Deploy` できます。

プロジェクトを手動でビルドする場合は、上記と同じ手順に従いますが、構成ファイルを作成する際に、既定の修飾子の一覧 (`/dq`) にアンダー スコアで区切られた追加の言語を追加します。 たとえば、前の手順で追加された、英語、ドイツ語、フランス語のリソースをサポートするには:

```CMD
    makepri createconfig /cf ..\contoso_demo.xml /dq en-US_de-DE_fr-FR /pv 10.0 /o
```

これにより、指定されたすべての言語を含む PRI ファイルが作成され、それをテスト用に簡単に使用できます。 リソースの合計サイズが小さい場合、または少数の言語のみをサポートする場合は、配布するアプリとしてこれで十分である場合もあります。リソースのインストールとダウンロードのサイズを最小化するメリットを必要とする場合のみ、言語ごとの個別の言語パックをビルドする追加の作業を行います。

**ローカライズされた値をテストします**

新しくローカライズされた変更をテストするには、使用する新しい UI 言語を Windows に追加します。 言語パックをダウンロードしたり、システムを再起動したり、Windows UI 全体を他言語で表示させたりする必要はありません。 

0. `Settings` アプリを実行します (`Windows + I`)
0. 行きます `Time & language`
0. 行きます `Region & language`
0. をクリックします。 `Add a language`
0. 必要な言語を入力 (または選択) します (たとえば `Deutsch` または `German`)
 * サブ言語がある場合は、必要なものを選びます (たとえば `Deutsch / Deutschland`)
0. 言語の一覧で新しい言語を選択します
0. をクリックします。 `Set as default`

スタート メニューを開き、作成したアプリケーションを検索します。選択した言語のローカライズされた値が表示されます (他のアプリもローカライズされて表示される場合があります)。 ローカライズされた名前がすぐに表示されない場合は、スタート メニューのキャッシュが更新されるまで、数分待機します。 元の言語に戻すには、言語の一覧で既定の言語を変更します。 

### <a name="step-14-localizing-more-parts-of-the-appx-manifest-optional"></a>手順 1.4:(省略可能) の AppX マニフェストの他のパーツをローカライズします。

AppX マニフェストの他のセクションをローカライズすることができます。 たとえば、アプリがファイル拡張子を処理する場合、マニフェストに `windows.fileTypeAssociation` 拡張があります。<span style="background-color: lightgreen">緑の強調表示のテキスト</span>を表示されているとおりに使い (これはリソースの参照です)、<span style="background-color: yellow">黄色の強調表示のテキスト</span>をアプリに固有の情報で置き換えます。

<blockquote>
<pre>
&lt;Extensions&gt;
  &lt;uap:Extension Category="windows.fileTypeAssociation"&gt;
    &lt;uap:FileTypeAssociation Name="default"&gt;
      &lt;uap:DisplayName&gt;<span style="background-color: lightgreen">ms-resource:Resources/FileTypeDisplayName</span>&lt;/uap:DisplayName&gt;
      &lt;uap:Logo&gt;<span style="background-color: yellow">Assets\StoreLogo.png</span>&lt;/uap:Logo&gt;
      &lt;uap:InfoTip&gt;<span style="background-color: lightgreen">ms-resource:Resources/FileTypeInfoTip</span>&lt;/uap:InfoTip&gt;
      &lt;uap:SupportedFileTypes&gt;
        &lt;uap:FileType ContentType="<span style="background-color: yellow">application/x-contoso</span>"&gt;<span style="background-color: yellow">.contoso</span>&lt;/uap:FileType&gt;
      &lt;/uap:SupportedFileTypes&gt;
    &lt;/uap:FileTypeAssociation&gt;
  &lt;/uap:Extension&gt;
&lt;/Extensions&gt;
</pre>
</blockquote>

Visual Studio のマニフェスト デザイナーを使って、この情報を追加することもできます。`Declarations` タブを使い、<span style="background-color: lightgreen">強調表示の値</span>を記録します。

<p><img src="images\editing-declarations-info.png"/></p>

対応するリソース名を、各 `.resw` ファイルに追加し、<span style="background-color: yellow">強調表示のテキスト</span>をアプリに適切なテキストで置き換えます (*サポートされているそれぞれの言語*で行います)。

<blockquote>
<pre>
... existing content...

&lt;data name="FileTypeDisplayName"&gt;
  &lt;value&gt;<span style="background-color: yellow">Contoso Demo File</span>&lt;/value&gt;
&lt;/data&gt;
&lt;data name="FileTypeInfoTip"&gt;
  &lt;value&gt;<span style="background-color: yellow">Files used by Contoso Demo App</span>&lt;/value&gt;
&lt;/data&gt;
</pre>
</blockquote>

これは、エクスプローラーなどの Windows シェルの一部で表示されます。

<p><img src="images\file-type-tool-tip.png"/></p>

再び、ビルドを行い、パッケージをテストして、新しい UI 文字列が表示される新しいシナリオを試します。

- - -

## <a name="phase-2-use-mrt-to-identify-and-locate-resources"></a>フェーズ 2:MRT を使ってリソースを識別して検索する

前のセクションでは、MRT を使用してアプリのマニフェスト ファイルをローカライズする方法を紹介しました。これによって、Windows シェルに、アプリの名前とその他のメタデータを正しく表示できるようになりました。 これにはコードの変更は必要なく、`.resw` ファイルとその他のいくつかのツールのみを必要としました。 このセクションでは、MRT を使用して、既存のリソース形式のリソースを検索し、既存のリソース処理コードを最小限の変更で使用する方法を説明します。

### <a name="assumptions-about-existing-file-layout--application-code"></a>既存のファイル レイアウトとアプリケーションのコードについての想定

Win32 デスクトップ アプリをローカライズする方法は多数あるため、このホワイトペーパーでは、既存のアプリケーションの構造について、いつかの簡単な想定を置きます。この想定と実際のアプリの環境をマッピングしながら利用してください。 MRT の要件に準拠するため、既存のコードベースやリソース レイアウトを変更する必要がある場合があります。それらの多くは、このドキュメントの対象範囲外となります。

**リソース ファイルのレイアウト**

このホワイト ペーパーでは、ローカライズされたリソースのすべてが同じファイル名を持ち (たとえば `contoso_demo.exe.mui`、`contoso_strings.dll`、`contoso.strings.xml`)、それらは BCP-47 名を持つ別のフォルダーに配置されている (`en-US`、`de-DE`など) と想定します。 問題があるリソース ファイルの数、その名前とは、どのようなファイルの形式ではありませんが、/Api が関連付けられているなど。すべての重要なことだけ*論理*リソースが同じファイル名 (別の配置が*物理*ディレクトリ)。 

反対の例として、アプリケーションがフラットなファイル構造を使用していて、1 つの `Resources` ディレクトリに、`english_strings.dll` と `french_strings.dll` が含まれている場合には、これは MRT にうまくマッピングされません。 望ましい構造は、`Resources` ディレクトリにサブディレクトリがあり、そこにファイルが配置されている (たとえば `en\strings.dll` や `fr\strings.dll`) 構造です。 `strings.lang-en.dll` や `strings.lang-fr.dll` などのように、同じ基本ファイル名を使用して、修飾子を埋め込むことも可能ですが、言語コードと同じディレクトリの使用がコンセプトとしてシンプルであり、ここではそれを使います。

**注** この名前付け規則に従わない場合でも、MRT を使って AppX パッケージのメリットを活用することは可能ですが、より多くの作業が必要となります。

たとえば、アプリケーションが、<span style="background-color: yellow">ui.txt</span> という名前の単純なテキスト ファイルに含まれる、(ボタンのラベルなどに使用される) カスタムの UI コマンドのセットを持ち、<span style="background-color: yellow">UICommands</span> フォルダーの下に配置される場合があります。

<blockquote>
<pre>
+ ProjectRoot
|--+ Strings
|  |--+ en-US
|  |  \--- resources.resw
|  \--+ de-DE
|     \--- resources.resw
|--+ <span style="background-color: yellow">UICommands</span>
|  |--+ en-US
|  |  \--- <span style="background-color: yellow">ui.txt</span>
|  \--+ de-DE
|     \--- <span style="background-color: yellow">ui.txt</span>
|--- AppxManifest.xml
|--- ...rest of project...
</pre>
</blockquote>

**リソースの読み込みコード**

このホワイトペーパーでは、コードの中のいずれかの時点で、ローカライズ リソースを含むファイルを検索し、読み込み、使用すると想定しています。 リソースを読み込むために使用する API や、リソースを抽出するために使用する API などは重要ではありません。 この疑似コードでは、基本的に 3 つの手順があります。

```
set userLanguage = GetUsersPreferredLanguage()
set resourceFile = FindResourceFileForLanguage(MY_RESOURCE_NAME, userLanguage)
set resource = LoadResource(resourceFile) 
    
// now use 'resource' however you want
```

MRT では、このプロセスの最初の 2 つの手順のみを変更する必要があります。つまり、必要なリソース候補の決定と、その検索です。 リソースの読み込みと使用については、変更する必要はありません (ただし、それらを活用する場合は、それを行える機能を提供しています)。
 
たとえば、アプリケーションは、Win32 API `GetUserPreferredUILanguages`、CRT 関数 `sprintf`、Win32 API `CreateFile` を使用して、上記の 3 つの疑似コードの関数を置き換え、次にテキスト ファイルを手動で解析して、`name=value` のペアを検索できます。 (この詳細は重要ではありません。MRT は、リソースが検索された後の、リソースの処理に使用する手法には影響がないことを示すために説明しました)。

### <a name="step-21-code-changes-to-use-mrt-to-locate-files"></a>手順 2.1:MRT を使用してファイルを検索するコードの変更

リソースの検索に MRT を使用するため、コードを切り替えることは難しくはありません。 いくつかの WinRT の種類と数行のコードを使う必要があります。 主に使用される種類は次のとおりです。

* [ResourceContext](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.ResourceContext) 現在アクティブな修飾子の値のセット (言語、スケール ファクターなど) をカプセル化します
* [ResourceManager](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcemanager) (.NETバージョンではなく、WinRT バージョン) PRI ファイルからすべてのリソースへのアクセスを実現します
* [ResourceMap](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcemap) PRI ファイル内のリソースの特定のサブセット (この例では、文字列リソースではなく、ファイル ベースのリソース) を表します
* [NamedResource](https://docs.microsoft.com/en-us/uwp/api/Windows.ApplicationModel.Resources.Core.NamedResource) 論理リソースとそのすべての候補を表します
* [ResourceCandidate](https://docs.microsoft.com/en-us/uwp/api/windows.applicationmodel.resources.core.resourcecandidate) 1 つの具体的な候補リソースを表す 

あるリソースのファイル名 (たとえば、上のサンプルの `UICommands\ui.txt` など) を解決する方法は、疑似コードでは、次のようになります。

```
// Get the ResourceContext that applies to this app
set resourceContext = ResourceContext.GetForViewIndependentUse()
    
// Get the current ResourceManager (there's one per app)
set resourceManager = ResourceManager.Current
    
// Get the "Files" ResourceMap from the ResourceManager
set fileResources = resourceManager.MainResourceMap.GetSubtree("Files")
    
// Find the NamedResource with the logical filename we're looking for,
// by indexing into the ResourceMap
set desiredResource = fileResources["UICommands\ui.txt"]
    
// Get the ResourceCandidate that best matches our ResourceContext
set bestCandidate = desiredResource.Resolve(resourceContext)
   
// Get the string value (the filename) from the ResourceCandidate
set absoluteFileName = bestCandidate.ValueAsString
```

このコードでは、(実際のディスク上のファイルの配置にかかわらず) 特定の言語のフォルダー (`UICommands\en-US\ui.txt` など) を要求して**いない**ことに、特に注意してください。 代わりに*論理*ファイル名 `UICommands\ui.txt` を要求して、ディスク上の言語ディレクトリからの適切なファイルの選択を MRT に依存しています。

これ以降、サンプル アプリは以前と同様に、`CreateFile` を使って `absoluteFileName` を読み込み、`name=value` ペアを解析できます。アプリ内のロジックの変更はまったく必要ありません。 C# または C++/CX で記述している場合、実際のコードは、この擬似コード以上にそれほど複雑になることはありません (さらに多くの中間変数は省略できます)。下記の **.NET リソースを読み込む**のセクションをご覧ください。 C++/WRL ベースのアプリケーションでは、WinRT API のアクティブ化と呼び出しに使用される低レベルの COM ベースの API によってより複雑になりますが、基本的な手順は同じです。下記の **Win32 MUI リソースを読み込む**のセクションをご覧ください。

**.NET リソースの読み込み**

.NET には、リソースを検索して読み込むための組み込みのメカニズム (「サテライト アセンブリ」と呼ばれます) があるため、上記の合成の例のように、明示的なコードの置き換えは必要ありません.NET では、適切なディレクトリにリソース DLL が存在することのみが必要であり、それらは自動的に検索されます。 リソース パッケージを使ってアプリが AppX としてパッケージ化された場合は、ディレクトリ構造はいくらか異なります。リソース ディレクトリは、メイン アプリケーション ディレクトリのサブディレクトリとして存在するのではなく、ピアとして存在します (または、ユーザーが使用する言語を指定していない場合には、まったく存在しません)。 

たとえば、次のレイアウトを持つ .NET アプリケーションを考えます。ここでは、すべてのファイルが `MainApp` フォルダーの下に存在しています。

<blockquote>
<pre>
+ MainApp
|--+ en-us
|  \--- MainApp.resources.dll
|--+ de-de
|  \--- MainApp.resources.dll
|--+ fr-fr
|  \--- MainApp.resources.dll
\--- MainApp.exe
</pre>
</blockquote>

AppX への変換後、レイアウトはこのようになります。ここでは、`en-US` が既定の言語で、言語リストにドイツ語とフランス語が記載されています。

<blockquote>
<pre>
+ WindowsAppsRoot
|--+ MainApp_neutral
|  |--+ en-us
|  |  \--- <span style="background-color: yellow">MainApp.resources.dll</span>
|  \--- MainApp.exe
|--+ MainApp_neutral_resources.language_de
|  \--+ de-de
|     \--- <span style="background-color: yellow">MainApp.resources.dll</span>
\--+ MainApp_neutral_resources.language_fr
   \--+ fr-fr
      \--- <span style="background-color: yellow">MainApp.resources.dll</span>
</pre>
</blockquote>

ローカライズ リソースが、メイン実行可能ファイルのインストール場所の下のサブディレクトリに存在しないため、組み込みの .NET リソースの解決が失敗します。 さいわい、.NET は、失敗したアセンブリの読み込みの試行を処理するための、明確に定義されたメカニズムである、`AssemblyResolve` イベントを備えています。 MRT を使用する .NET アプリは、このイベントに登録して、見つからなかったアセンブリを .NET リソース サブシステムに提供する必要があります。 

WinRT API を使用して、.NET で使われるサテライト アセンブリを検索する方法の簡単な例は次のとおりです。このコードは、最小限の実装を示すように、意図的に圧縮されていますが、上記の疑似コードによく対応しています。ここでは、渡されている `ResolveEventArgs` が検索する必要があるアセンブリの名前を提供します。 このコードの実行可能なバージョン (詳細なコメントとエラー処理を含む) は、[GitHub の **.NET アセンブリ リゾルバー** サンプル](https://aka.ms/fvgqt4) の `PriResourceRsolver.cs` にあります。

```C#
static class PriResourceResolver
{
  internal static Assembly ResolveResourceDll(object sender, ResolveEventArgs args)
  {
    var fullAssemblyName = new AssemblyName(args.Name);
    var fileName = string.Format(@"{0}.dll", fullAssemblyName.Name);

    var resourceContext = ResourceContext.GetForViewIndependentUse();
    resourceContext.Languages = new[] { fullAssemblyName.CultureName };

    var resource = ResourceManager.Current.MainResourceMap.GetSubtree("Files")[fileName];

    // Note use of 'UnsafeLoadFrom' - this is required for apps installed with AppX, but
    // in general is discouraged. The full sample provides a safer wrapper of this method
    return Assembly.UnsafeLoadFrom(resource.Resolve(resourceContext).ValueAsString);
  }
}
```

上記のクラスでは、次のコードを事前にアプリケーションのスタートアップ コードのどこかに (いずれかのローカライズ リソースを読み込む前に) 追加する必要があります。

```C#
void EnableMrtResourceLookup()
{
  AppDomain.CurrentDomain.AssemblyResolve += PriResourceResolver.ResolveResourceDll;
}
```

.NET ランタイムは、リソース DLL が見つからない場合には、`AssemblyResolve` イベントを発生させます。その場合、提供されたイベント ハンドラーは、MRT を使って必要なファイルを検索し、アセンブリを返します。

**注** アプリが既に `AssemblyResolve` ハンドラーを他の目的で使用している場合、リソース解決のコードを、既存のコードと統合する必要があります。

**MUI を Win32 リソースの読み込み**

Win32 MUI リソースの読み込みは、.NET サテライト アセンブリの読み込みと基本的には同じですが、C++/CX または C++/WRL コードを使います。 C++/CX を使うと、コードがよりシンプルになり、上記の C# にとても近くなりますが、C++ 言語拡張、コンパイラ スイッチ、その他のランタイム オーバーヘッドを使うため、これはあまり望ましくない場合があります。 その場合は、C++/WRL を使うと、コードは冗長になりますが、影響のより小さいソリューションとなります。 それでも、ATL プログラミング (または COM 一般) に慣れている場合には、WRL がなじみやすい選択となります。 

次のサンプル関数は、C++/WRL を使って、特定のリソース DLL を読み込み、`HINSTANCE` を返します。これにより、通常の Win32 リソース API を使って、さらにリソースを読み込むことができます。 .NET ランタイムに要求された言語を使って明示的に `ResourceContext` を初期化する C# のサンプルとは異なり、このコードはユーザーの現在の言語に依存しています。

```CPP
#include <roapi.h>
#include <wrl\client.h>
#include <wrl\wrappers\corewrappers.h>
#include <Windows.ApplicationModel.resources.core.h>
#include <Windows.Foundation.h>
   
#define IF_FAIL_RETURN(hr) if (FAILED((hr))) return hr;
    
HRESULT GetMrtResourceHandle(LPCWSTR resourceFilePath,  HINSTANCE* resourceHandle)
{
  using namespace Microsoft::WRL;
  using namespace Microsoft::WRL::Wrappers;
  using namespace ABI::Windows::ApplicationModel::Resources::Core;
  using namespace ABI::Windows::Foundation;
    
  *resourceHandle = nullptr;
  HRESULT hr{ S_OK };
  RoInitializeWrapper roInit{ RO_INIT_SINGLETHREADED };
  IF_FAIL_RETURN(roInit);
    
  // Get Windows.ApplicationModel.Resources.Core.ResourceManager statics
  ComPtr<IResourceManagerStatics> resourceManagerStatics;
  IF_FAIL_RETURN(GetActivationFactory(
    HStringReference(
    RuntimeClass_Windows_ApplicationModel_Resources_Core_ResourceManager).Get(),
    &resourceManagerStatics));
    
  // Get .Current property
  ComPtr<IResourceManager> resourceManager;
  IF_FAIL_RETURN(resourceManagerStatics->get_Current(&resourceManager));
    
  // get .MainResourceMap property
  ComPtr<IResourceMap> resourceMap;
  IF_FAIL_RETURN(resourceManager->get_MainResourceMap(&resourceMap));
    
  // Call .GetValue with supplied filename
  ComPtr<IResourceCandidate> resourceCandidate;
  IF_FAIL_RETURN(resourceMap->GetValue(HStringReference(resourceFilePath).Get(),
    &resourceCandidate));
    
  // Get .ValueAsString property
  HString resolvedResourceFilePath;
  IF_FAIL_RETURN(resourceCandidate->get_ValueAsString(
    resolvedResourceFilePath.GetAddressOf()));
    
  // Finally, load the DLL and return the hInst.
  *resourceHandle = LoadLibraryEx(resolvedResourceFilePath.GetRawBuffer(nullptr),
    nullptr, LOAD_LIBRARY_AS_DATAFILE | LOAD_LIBRARY_AS_IMAGE_RESOURCE);
    
  return S_OK;
}
```

## <a name="phase-3-building-resource-packs"></a>フェーズ 3:リソース パックの構築

これで、すべてのリソースを含む "ファット" パッケージができました。ダウンロードとインストールのサイズを最小化するために、メイン パッケージとリソース パッケージを分離してビルドするには、2 つの方法があります。

0. 既存のファット パッケージを使い、[Bundle Generator ツール](https://aka.ms/bundlegen)を実行して、自動的にリソース パッケージを作成します。 これは、既にファット パッケージを作成するビルド システムがあり、ポスト プロセスとしてリソース パッケージを生成する場合に、推奨されるアプローチです。
0. 直接、個々のリソース パッケージを作成し、それらをビルドしてバンドルを作成します。 これは、ビルド システムをより細かく制御して、パッケージを直接作成する場合に、推奨されるアプローチです。

### <a name="step-31-creating-the-bundle"></a>手順 3.1:バンドルの作成

**バンドル ジェネレーター ツールを使用します。**

Bundle Generator ツールを使用するには、パッケージ用に作成した PRI 構成ファイルを手動で更新して、`<packaging>` セクションを削除する必要があります。

Visual Studio を使っている場合には、`priconfig.packaging.xml` ファイルと `priconfig.default.xml` ファイルを作成して、すべての言語をメイン パッケージにビルドする方法について詳しくは、[MSDN の **Windows 8.1 ストア アプリ: デバイスにリソースが必要かどうかにかかわらず、必ずリソースをデバイスにインストールする**のトピック](https://msdn.microsoft.com/en-us/library/dn482043.aspx)をご覧ください。

ファイルを手動で編集する場合は、次の手順に従います。 

0. 正しいパス、ファイル名、言語を置き換えて、以前と同じ方法で構成ファイルを作成します。

    `makepri createconfig /cf ..\contoso_demo.xml /dq en-US_de-DE_es-MX /pv 10.0 /o`
0. 作成された `.xml` ファイルを手動で開き、`&lt;packaging&rt;` セクション全体を削除します (それ以外はそのまま残します)。

<blockquote>
<pre>
&lt;?xml version="1.0" encoding="UTF-8" standalone="yes" ?&gt; 
&lt;resources targetOsVersion="10.0.0" majorVersion="1"&gt;
  &lt;!-- Packaging section has been deleted... --&gt;
  &lt;index root="\" startIndexAt="\"&gt;
    &lt;default&gt;
    ...
    ...
</pre>
</blockquote>

0. 更新された構成ファイルと適切なディレクトリとファイル名を使って、以前と同じ方法で `.pri` ファイルと `.appx` パッケージをビルドします (これらのコマンドについて詳しくは上記をご覧ください)。

```CMD
makepri new /pr . /cf ..\contoso_demo.xml /of ..\resources.pri /mf AppX /o
makeappx pack /m AppXManifest.xml /f ..\resources.map.txt /p ..\contoso_demo.appx /o
```

0. パッケージが作成されたら、適切なディレクトリとファイル名を使用して、次のコマンドを使用してバンドルを作成します。

    `BundleGenerator.exe -Package ..\contoso_demo.appx -Destination ..\bundle -BundleName contoso_demo`

これで、最後の手順に進むことができます。最後の手順は署名です (下をご覧ください)。

**リソース パッケージを手動で作成します。**

リソース パッケージを手動で作成する場合は、やや異なるコマンドのセットを実行して、別の `.pri` ファイルと `.appx` ファイルをビルドする必要があります。これらはすべて、上でファット パッケージの作成に使用したコマンドに似ていますので、簡単な説明にとどめます。 注:すべてのコマンドは、現在のディレクトリにディレクトリがある前提としています格納している、`AppXManifest.xml`ファイルがすべてのファイルは、(を使用できますの別のディレクトリが必要に応じて、プロジェクト ディレクトリのいずれかを煩雑べきではない場合、親ディレクトリに配置されます。これらのファイル)。 いつもと同様に、"Contoso" のファイル名を独自のファイル名で置き換えます。

0. 次のコマンドを使用して、既定の言語**のみ**を既定の修飾子として命名する、構成ファイルを作成します。この場合では `en-US` です。

    `makepri createconfig /cf ..\contoso_demo.xml /dq en-US /pv 10.0 /o`
0. 次のコマンドを使って、メイン パッケージの既定の `.pri` ファイルと`.map.txt` ファイルを作成し、さらにプロジェクトの各言語の追加のファイルのセットを作成します。

    `makepri new /pr . /cf ..\contoso_demo.xml /of ..\resources.pri /mf AppX /o`
0. 次のコマンドを使って、メイン パッケージを作成します (これには実行可能コードと既定の言語リソースが含まれています)。 いつもと同様に、必要に応じて名前を変更します。後でバンドルの作成が容易になるように、パッケージは別のディレクトリに配置する必要があります (この例では、 `.\bundle` ディレクトリを使います)。

    `makeappx pack /m .\AppXManifest.xml /f ..\resources.map.txt /p ..\bundle\contoso_demo.main.appx /o`
0. メイン パッケージが作成されたら、次のコマンドを追加言語ごとに 1 回ずつ使います (つまり、前の手順で生成された各言語マップ ファイルに、このコマンドを繰り返します)。 ここでも、出力は別のディレクトリ (メイン パッケージと同じディレクトリ) にする必要があります。 言語が `/f` オプションと `/p` オプションの **両方** で指定されていることに注意してください。また、新しい `/r` 引数の使い方 (リソース パッケージが必要であることを指定します) に注意してください。

    `makeappx pack /r /m .\AppXManifest.xml /f ..\resources.language-de.map.txt /p ..\bundle\contoso_demo.de.appx /o`
0. バンドル ディレクトリからのすべてのパッケージをまとめて、1 つの `.appxbundle` ファイルを作成します。 新しい `/d` オプションは、バンドル内のすべてのファイルが使用するディレクトリを指定します (前の手順で `.appx` ファイルを別のディレクトリに配置したのはこのためです)。

    `makeappx bundle /d ..\bundle /p ..\contoso_demo.appxbundle /o`

パッケージのビルドの最後の手順は、署名です。

### <a name="step-32-signing-the-bundle"></a>手順 3.2:バンドルの署名

(Bundle Generator ツールを使うか、または手動で) `.appxbundle` を作成したら、メイン パッケージとすべてのリソース パッケージを含む、1 つのファイルが作成されます。  最後の手順は、ファイルに署名を行い、Windows がインストールできるようにすることです。

    signtool sign /fd SHA256 /a /f ..\contoso_demo_key.pfx ..\contoso_demo.appxbundle

これによって、メイン パッケージとすべての言語固有のリソース パッケージを含む、署名済みの `.appxbundle` ファイルが作成されます。 これはパッケージ ファイルと同様にダブルクリックでき、それによって、アプリに加えて、ユーザーの Windows の言語設定に基づく適切な言語をインストールすることができます。

## <a name="related-topics"></a>関連トピック

* [言語、スケール、ハイ コントラスト、およびその他の修飾子のためのリソースを調整します。](tailor-resources-lang-scale-contrast.md)