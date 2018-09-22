---
author: andrewleader
Description: The following article describes all of the properties and elements within tile content.
title: タイルのコンテンツのスキーマ
ms.assetid: 7CBC3BD5-D9C3-4781-8BD0-1F28039E1FA8
label: Tile content schema
template: detail.hbs
ms.author: mijacobs
ms.date: 07/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, タイル, タイル通知, タイルのコンテンツ, スキーマ, タイルのペイロード
ms.localizationpriority: medium
ms.openlocfilehash: d2baa2e2d7b8d68505159eb480ea3be78750f507
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4127885"
---
# <a name="tile-content-schema"></a>タイルのコンテンツのスキーマ

 

ここでは、タイルのコンテンツ内にあるすべてのプロパティと要素について説明します。

[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)ではなく生の XML を使う場合は、「[XML スキーマ](../tiles-and-notifications/adaptive-tiles-schema.md)」をご覧ください。

[TileContent](#tilecontent)
* [TileVisual](#tilevisual)
  * [TileBinding](#tilebinding)
    * [TileBindingContentAdaptive](#TileBindingContentAdaptive)
    * [TileBindingContentIconic](#TileBindingContentIconic)
    * [TileBindingContentContact](#TileBindingContentContact)
    * [TileBindingContentPeople](#TileBindingContentPeople)
    * [TileBindingContentPhotos](#TileBindingContentPhotos)


## <a name="tilecontent"></a>TileContent
TileContent は、視覚効果などのタイル通知のコンテンツを説明する最上位のオブジェクトです。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Visual** | [ToastVisual](#tilevisual) | true | タイル通知の視覚的な部分について説明します。 |


## <a name="tilevisual"></a>TileVisual
タイルの視覚的な部分には、すべてのタイルのサイズを対象とした視覚的な仕様、および視覚に関連するプロパティが含まれています。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **TileSmall** | [TileBinding](#tilebinding) | false | 小さいタイルのサイズに対応したコンテンツを指定するための、小さいバインディングが提供されます (オプション)。 |
| **TileMedium** | [TileBinding](#tilebinding) | false | 中型のタイルのサイズに対応したコンテンツを指定するための、中型のバインディングが提供されます (オプション)。 |
| **TileWide** | [TileBinding](#tilebinding) | false | ワイドなタイルのサイズに対応したコンテンツを指定するための、ワイド サイズのバインディングが提供されます (オプション)。 |
| **TileLarge** | [TileBinding](#tilebinding) | false | 大きいタイルのサイズに対応したコンテンツを指定するための、大きいバインディングが提供されます (オプション)。 |
| **Branding** | [TileBranding](#tilebranding) | false | アプリのブランドを表示するためにタイルで使用されるフォームです。 既定では、既定のタイルからブランド化を継承します。 |
| **DisplayName** | string | false | この通知が表示されているときにタイルの表示名を上書きする文字列です (オプション)。 |
| **Arguments** | string | false | Anniversary Update の新機能: アプリで定義されたデータです。ユーザーがライブ タイルからアプリを起動したときに、LaunchActivatedEventArgs の TileActivatedInfo プロパティを使用してアプリに戻されます。 これにより、ユーザーがライブ タイルをタップしたときに表示されたタイル通知がどれであるかがわかります。 Anniversary Update が適用されていないデバイスでは、このプロパティは無視されるだけです。 |
| **LockDetailedStatus1** | string | false | これを指定する場合は、TileWide バインディングも指定する必要があります。 このプロパティは、ユーザーがタイルを状態の詳細を表示するアプリとして選択した場合に、ロック画面に表示されるテキストの最初の行に該当します。 |
| **LockDetailedStatus2** | string | false | これを指定する場合は、TileWide バインディングも指定する必要があります。 このプロパティは、ユーザーがタイルを状態の詳細を表示するアプリとして選択した場合に、ロック画面に表示されるテキストの 2 行目に該当します。 |
| **LockDetailedStatus3** | string | false | これを指定する場合は、TileWide バインディングも指定する必要があります。 このプロパティは、ユーザーがタイルを状態の詳細を表示するアプリとして選択した場合に、ロック画面に表示されるテキストの 3 行目に該当します。 |
| **BaseUri** | Uri | false | 画像ソースの属性において相対 URL と組み合わされる、既定のベース URL です。 |
| **AddImageQuery** | bool? | false | true に設定すると、トースト通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |
| **Language**| string | false | ローカライズされたリソースを使用する際の視覚的なペイロードの対象ロケールです。"en-US" や "fr-FR" のように BCP-47 言語タグとして指定されます。 このロケールは、バインディングかテキストで指定されるあらゆるロケールによって上書きされます。 未指定の場合は、システム ロケールが代わりに使用されます。 |


## <a name="tilebinding"></a>TileBinding
バインディング オブジェクトには、特定のタイルのサイズに対応した視覚的なコンテンツが含まれています。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Content** | [ITileBindingContent](#itilebindingcontent) | false | タイルに表示される視覚的なコンテンツです。 [TileBindingContentAdaptive](#tilebindingcontentadaptive)、[TileBindingContentIconic](#TileBindingContentIconic)、[TileBindingContentContact](#TileBindingContentContact)、[TileBindingContentPeople](#TileBindingContentPeople)、または [TileBindingContentPhotos](#TileBindingContentPhotos) のいずれかです。 |
| **Branding** | [TileBranding](#tilebranding) | false | アプリのブランドを表示するためにタイルで使用されるフォームです。 既定では、既定のタイルからブランド化を継承します。 |
| **DisplayName** | string | false | このタイルのサイズに対応したタイルの表示名を上書きする文字列です (オプション)。 |
| **Arguments** | string | false | Anniversary Update の新機能: アプリで定義されたデータです。ユーザーがライブ タイルからアプリを起動したときに、LaunchActivatedEventArgs の TileActivatedInfo プロパティを使用してアプリに戻されます。 これにより、ユーザーがライブ タイルをタップしたときに表示されたタイル通知がどれであるかがわかります。 Anniversary Update が適用されていないデバイスでは、このプロパティは無視されるだけです。 |
| **BaseUri** | Uri | false | 画像ソースの属性において相対 URL と組み合わされる、既定のベース URL です。 |
| **AddImageQuery** | bool? | false | true に設定すると、トースト通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |
| **Language**| string | false | ローカライズされたリソースを使用する際の視覚的なペイロードの対象ロケールです。"en-US" や "fr-FR" のように BCP-47 言語タグとして指定されます。 このロケールは、バインディングかテキストで指定されるあらゆるロケールによって上書きされます。 未指定の場合は、システム ロケールが代わりに使用されます。 |


## <a name="itilebindingcontent"></a>ITileBindingContent
タイルのバインディング コンテンツのマーカー インターフェイスです。 これらを使用することで、タイルをどのように表示するかを選択できます。アダプティブ、または特別なテンプレートのいずれかを選択できます。

| 実装 |
| --- |
| [TileBindingContentAdaptive](#TileBindingContentAdaptive) |
| [TileBindingContentIconic](#TileBindingContentIconic) |
| [TileBindingContentContact](#TileBindingContentContact) |
| [TileBindingContentPeople](#TileBindingContentPeople) |
| [TileBindingContentPhotos](#TileBindingContentPhotos) |


## <a name="tilebindingcontentadaptive"></a>TileBindingContentAdaptive
すべてのサイズでサポートされます。 タイルのコンテンツを指定する場合に推奨される方法です。 アダプティブ タイル テンプレートは Windows 10 の新機能で、アダプティブなプロパティを利用してさまざまなカスタム タイルを作成できます。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Children** | IList<[ITileBindingContentAdaptiveChild](#ITileBindingContentAdaptiveChild)> | false | インラインの視覚要素です。 [AdaptiveText](#adaptivetext)、[AdaptiveImage](#adaptiveimage)、および [AdaptiveGroup](#adaptivegroup) の各オブジェクトを追加することができます。 子は、垂直方向の StackPanel 形式で表示されます。 |
| **BackgroundImage** | [TileBackgroundImage](#tilebackgroundimage) | false | すべてのタイルのコンテンツの後ろに表示される背景画像です (オプション)。フルブリードで表示されます。 |
| **PeekImage** | [TilePeekImage](#tilepeekimage) | false | タイルでアニメーション化されるプレビュー画像です (オプション)。 |
| **TextStacking** | [TileTextStacking](#tiletextstacking) | false | 子のコンテンツ全体を対象としたテキストの積み重ね (縦方向の配置) を制御します。 |


## <a name="adaptivetext"></a>AdaptiveText
アダプティブなテキスト要素です。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Text** | string | false | 表示するテキストです。 |
| **HintStyle** | [AdaptiveTextStyle](#adaptivetextstyle) | false | このスタイルは、テキストのフォント サイズ、太さ、および不透明度を制御します。 |
| **HintWrap** | bool? | false | true に設定すると、テキストの折り返しが有効になります。 既定は false です。 |
| **HintMaxLines** | int? | false | 表示が許可される、テキスト要素の最大行数です。 |
| **HintMinLines** | int? | false | 表示する必要のある、テキスト要素の最小行数です。 |
| **HintAlign** | [AdaptiveTextAlign](#adaptivetextalign) | false | テキストの水平方向の配置です。 |
| **Language** | string | false | XML ペイロードの対象ロケールです。"en-US" や "fr-FR" のように BCP-47 言語タグとして指定されます。 ここで指定されたロケールは、バインディングか視覚的な要素で指定されたその他のあらゆるロケールを上書きします。 この値がリテラル文字列の場合、この属性の既定値はユーザーの UI 言語になります。 この値が文字列リファレンスの場合、この属性の既定値は、文字列を解決する際に Windows ランタイムで選択されたロケールになります。 |


### <a name="adaptivetextstyle"></a>AdaptiveTextStyle
テキスト スタイルは、フォント サイズ、太さ、および不透明度を制御します。 "Subtle" の不透明度は 60% の不透明度になります。

| 値 | 意味 |
|---|---|
| **Default** | 既定値です。 スタイルがレンダラーによって決定されます。 |
| **Caption** | 段落のフォント サイズより小さいサイズです。 |
| **CaptionSubtle** | Caption と同じですが、不透明度が Subtle です。 |
| **Body** | 段落本文のフォント サイズです。 |
| **BodySubtle** | Body と同じですが、不透明度が Subtle です。 |
| **Base** | 段落本文のフォント サイズで、太字です。 基本的には、Body の太字バージョンと言えます。 |
| **BaseSubtle** | Base と同じですが、不透明度が Subtle です。 |
| **Subtitle** | H4 のフォント サイズです。 |
| **SubtitleSubtle** | Subtitle と同じですが、不透明度が Subtle です。 |
| **Title** | H3 のフォント サイズです。 |
| **TitleSubtle** | Title と同じですが、不透明度が Subtle です。 |
| **TitleNumeral** | Title と同じですが、上/下のパディングが削除されます。 |
| **Subheader** | H2 のフォント サイズです。 |
| **SubheaderSubtle** | Subheader と同じですが、不透明度が Subtle です。 |
| **SubheaderNumeral** | Subheader と同じですが、上/下のパディングが削除されます。 |
| **Header** | H1 のフォント サイズです。 |
| **HeaderSubtle** | Header と同じですが、不透明度が Subtle です。 |
| **HeaderNumeral** | Header と同じですが、上/下のパディングが削除されます。 |


### <a name="adaptivetextalign"></a>AdaptiveTextAlign
テキストの水平方向の配置を制御します。

| 値 | 意味 |
|---|---|
| **Default** | 既定値です。 配置がレンダラーによって自動的に決定されます。 |
| **Auto** | 配置が現在の言語とカルチャによって決定されます。 |
| **Left** | テキストを左側に水平方向に配置します。 |
| **Center** | テキストを中央に水平方向に配置します。 |
| **Right** | テキストを右側に水平方向に配置します。 |


## <a name="adaptiveimage"></a>AdaptiveImage
インライン画像です。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Source** | string | true | 画像への URL です。 ms-appx、ms-appdata、および http がサポートされます。 Fall Creators Update の時点で、Web 画像の上限は通常の接続で 3 MB、従量制課金接続で 1 MB です。 まだ Fall Creators Update を実行していないデバイスでは、Web イメージは 200 KB を上限とします。 |
| **HintCrop** | [AdaptiveImageCrop](#adaptiveimagecrop) | false | 必要な画像トリミングを制御します。 |
| **HintRemoveMargin** | bool? | false | 既定では、グループ/サブグループ内の画像には周囲に 8 ピクセルの余白があります。 このプロパティを true に設定することで余白を削除できます。 |
| **HintAlign** | [AdaptiveImageAlign](#adaptiveimagealign) | false | 画像の水平方向の配置です。 |
| **AlternateText** | string | false | アクセシビリティ対応目的で使用される、画像を説明する代替テキストです。 |
| **AddImageQuery** | bool? | false | "true" に設定すると、タイル通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |


### <a name="adaptiveimagecrop"></a>AdaptiveImageCrop
必要な画像トリミングを指定します。

| 値 | 意味 |
|---|---|
| **Default** | 既定値です。 トリミングの動作がレンダラーによって決定されます。 |
| **None** | 画像がトリミングされません。 |
| **Circle** | 画像が円形にトリミングされます。 |


### <a name="adaptiveimagealign"></a>AdaptiveImageAlign
画像の水平方向の配置を指定します。

| 値 | 意味 |
|---|---|
| **Default** | 既定値です。 配置の動作がレンダラーによって決定されます。 |
| **Stretch** | 利用可能な幅いっぱいに画像が拡大されます (また同時に、画像が配置される位置に応じて、利用可能な高さいっぱいに拡大されることもあります)。 |
| **Left** | 画像を左側に配置し、ネイディブの解像度で表示します。 |
| **Center** | 画像を中央に水平方向に配置し、ネイティブの解像度で表示します。 |
| **Right** | 画像を右側に配置し、ネイディブの解像度で表示します。 |


## <a name="adaptivegroup"></a>AdaptiveGroup
グループは、グループ内のコンテンツについて、全体を表示すべきか、収まりきらない場合は全体を表示すべきでないかを意味的に識別します。 複数の列を作成することも可能にします。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Children** | IList<[AdaptiveSubgroup](#adaptivesubgroup)> | false | サブグループが垂直方向の列として表示されます。 AdaptiveGroup 内の任意のコンテンツを提供するにはサブグループを使用する必要があります。 |


## <a name="adaptivesubgroup"></a>AdaptiveSubgroup
サブグループは垂直方向の列で、テキストと画像を含めることができます。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Children** | IList<[IAdaptiveSubgroupChild](#iadaptivesubgroupchild)> | false | [AdaptiveText](#adaptivetext) と [AdaptiveImage](#adaptiveimage) は、サブグループの有効な子です。 |
| **HintWeight** | int? | false | 別のサブグループを基準として太さを指定することで、このサブグループの列の幅を制御します。 |
| **HintTextStacking** | [AdaptiveSubgroupTextStacking](#adaptivesubgrouptextstacking) | false | このサブグループのコンテンツの垂直方向の配置を制御します。 |


### <a name="iadaptivesubgroupchild"></a>IAdaptiveSubgroupChild
サブグループの子のマーカー インターフェイスです。

| Implementations |
| --- |
| [AdaptiveText](#adaptivetext) |
| [AdaptiveImage](#adaptiveimage) |


### <a name="adaptivesubgrouptextstacking"></a>AdaptiveSubgroupTextStacking
TextStacking は、コンテンツの垂直方向の配置を指定します。

| 値 | 意味 |
|---|---|
| **Default** | 既定値です。 レンダラーが既定の垂直方向の配置を自動的に選択します。 |
| **Top** | 上に合わせて垂直に配置されます。 |
| **Center** | 中央に合わせて垂直に配置されます。 |
| **Bottom** | 下に合わせて垂直に配置されます。 |


## <a name="tilebackgroundimage"></a>TileBackgroundImage
タイルにフルブリードで表示される背景画像です。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Source** | string | true | 画像への URL です。 ms-appx、ms-appdata、および http(s) がサポートされます。 http の画像は、サイズを 200 KB 以下にする必要があります。 |
| **HintOverlay** | int? | false | 背景画像での黒のオーバーレイです。 この値は、黒のオーバーレイの不透明度を制御します。0 ではオーバーレイなし、100 は完全な黒を表します。 既定値は 20 です。 |
| **HintCrop** | [TileBackgroundImageCrop](#tilebackgroundimagecrop) | false | 1511 の新着機能: 画像をトリミングする方法を指定します。 1511 よりも前のバージョンでは、このプロパティは無視され、背景画像はトリミングなしで表示されます。 |
| **AlternateText** | string | false | アクセシビリティ対応目的で使用される、画像を説明する代替テキストです。 |
| **AddImageQuery** | bool? | false | "true" に設定すると、タイル通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |


### <a name="tilebackgroundimagecrop"></a>TileBackgroundImageCrop
背景画像のトリミングを制御します。

| 値 | 意味 |
|---|---|
| **Default** | トリミングがレンダラーの既定の動作を使用します。 |
| **None** | 画像がトリミングされず、正方形で表示されます。 |
| **Circle** | 画像が円形にトリミングされます。 |


## <a name="tilepeekimage"></a>TilePeekImage
タイルでアニメーション化されるプレビュー画像です。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Source** | string | true | 画像への URL です。 ms-appx、ms-appdata、および http(s) がサポートされます。 http の画像は、サイズを 200 KB 以下にする必要があります。 |
| **HintOverlay** | int? | false | 1511 の新機能: プレビュー画像上に設定される黒のオーバーレイです。 この値は、黒のオーバーレイの不透明度を制御します。0 ではオーバーレイなし、100 は完全な黒を表します。 既定値は 20 です。 以前のバージョンでは、このプロパティは無視され、プレビュー画像は値 0 (オーバーレイなし) で表示されます。 |
| **HintCrop** | [TilePeekImageCrop](#tilepeekimagecrop) | false | 1511 の新着機能: 画像をトリミングする方法を指定します。 1511 よりも前のバージョンでは、このプロパティは無視され、プレビュー画像はトリミングなしで表示されます。 |
| **AlternateText** | string | false | アクセシビリティ対応目的で使用される、画像を説明する代替テキストです。 |
| **AddImageQuery** | bool? | false | "true" に設定すると、タイル通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |


### <a name="tilepeekimagecrop"></a>TilePeekImageCrop
プレビュー画像のトリミングを制御します。

| 値 | 意味 |
|---|---|
| **Default** | トリミングがレンダラーの既定の動作を使用します。 |
| **None** | 画像がトリミングされず、正方形で表示されます。 |
| **Circle** | 画像が円形にトリミングされます。 |


### <a name="tiletextstacking"></a>TileTextStacking
テキストの積み重ねは、コンテンツの垂直方向の配置を指定します。

| 値 | 意味 |
|---|---|
| **Default** | 既定値です。 レンダラーが既定の垂直方向の配置を自動的に選択します。 |
| **Top** | 上に合わせて垂直に配置されます。 |
| **Center** | 中央に合わせて垂直に配置されます。 |
| **Bottom** | 下に合わせて垂直に配置されます。 |


## <a name="tilebindingcontenticonic"></a>TileBindingContentIconic
小さいサイズおよび中型のサイズでサポートされます。 アイコン タイル テンプレートを有効にします。このテンプレートを利用すると、Windows Phone のクラシック スタイルのように、タイル上でアイコンとバッジを並べて表示することができます。 アイコンの横に示される番号の設定は、個別のバッジ通知に基づいて行われます。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Icon** | [TileBasicImage](#tilebasicimage) | true | 少なくとも、デスクトップとモバイル、および小さいタイルと中型のタイルの両方をサポートするために、縦横比が正方形となる画像を、解像度 200 x 200、PNG 形式で指定します。また、不透明度と色 (白のみ) も指定します。 詳しくは、「[特別なタイル テンプレート](../tiles-and-notifications/special-tile-templates-catalog.md)」をご覧ください。 |


## <a name="tilebindingcontentcontact"></a>TileBindingContentContact
モバイルのみに使用できます。 小さいサイズ、中型のサイズ、ワイド サイズでサポートされます。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Image** | [TileBasicImage](#tilebasicimage) | true | 表示する画像です。 |
| **Text** | [TileBasicText](#tilebasictext) | false | 表示されるテキストの行です。 小さいタイルには表示されません。 |


## <a name="tilebindingcontentpeople"></a>TileBindingContentPeople
1511 の新機能: 中型のサイズ、ワイド サイズ、大きいサイズでサポートされます (デスクトップおよびモバイル)。 以前、このプロパティはモバイルのみに対応しており、中型のサイズとワイド サイズでサポートされていました。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Images** | IList<[TileBasicImage](#tilebasicimage)> | true | 円形に表示される画像です。 |


## <a name="tilebindingcontentphotos"></a>TileBindingContentPhotos
写真のスライドショーを使用してアニメーション化します。 すべてのサイズでサポートされます。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Images** | IList<[TileBasicImage](#tilebasicimage)> | true | 最大で 12 枚の画像を指定できます (モバイルの場合は 9 枚まで表示できます)。これらの画像はスライドショーに使用されます。 12 枚を超える画像を指定すると、例外がスローされます。 |


### <a name="tilebasicimage"></a>TileBasicImage
さまざまな特別なテンプレートで使用される画像です。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Source** | string | true | 画像への URL です。 ms-appx、ms-appdata、および http(s) がサポートされます。 http の画像は、サイズを 200 KB 以下にする必要があります。 |
| **AlternateText** | string | false | アクセシビリティ対応目的で使用される、画像を説明する代替テキストです。 |
| **AddImageQuery** | bool? | false | "true" に設定すると、タイル通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |


### <a name="tilebasictext"></a>TileBasicText
さまざまな特別なテンプレートで使用される基本的なテキスト要素です。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Text** | string | false | 表示するテキストです。 |
| **Language** | string | false | XML ペイロードの対象ロケールです。"en-US" や "fr-FR" のように BCP-47 言語タグとして指定されます。 ここで指定されたロケールは、バインディングか視覚的な要素で指定されたその他のあらゆるロケールを上書きします。 この値がリテラル文字列の場合、この属性の既定値はユーザーの UI 言語になります。 この値が文字列リファレンスの場合、この属性の既定値は、文字列を解決する際に Windows ランタイムで選択されたロケールになります。 |


## <a name="related-topics"></a>関連トピック

* [Quickstart: Send a local tile notification (クイックスタート: ローカル タイル通知の送信)](../tiles-and-notifications/sending-a-local-tile-notification.md)
* [GitHub の Notifications ライブラリ](https://github.com/Microsoft/UWPCommunityToolkit/tree/dev/Notifications)