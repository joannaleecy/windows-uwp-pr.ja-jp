---
author: andrewleader
Description: The following article describes all of the properties and elements within toast content.
title: トーストのコンテンツのスキーマ
ms.assetid: 7CBC3BD5-D9C3-4781-8BD0-1F28039E1FA8
label: Toast content schema
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: ad1700d58ab3568aa3aefa46b5950d0a8bf3c320
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3933935"
---
# <a name="toast-content-schema"></a>トーストのコンテンツのスキーマ

 

ここでは、トーストのコンテンツ内のすべてのプロパティと要素を説明します。

[Notifications ライブラリ](https://www.nuget.org/packages/Microsoft.Toolkit.Uwp.Notifications/)ではなく生の XML を使う場合は、「[XML スキーマ](toast-xml-schema.md)」をご覧ください。

[ToastContent](#toastcontent)
* [ToastVisual](#toastvisual)
  * [ToastBindingGeneric](#toastbindinggeneric)
    * [IToastBindingGenericChild](#itoastbindinggenericchild)
    * [ToastGenericAppLogo](#toastgenericapplogo)
    * [ToastGenericHeroImage](#toastgenericheroimage)
    * [ToastGenericAttributionText](#toastgenericattributiontext)
* [IToastActions](#itoastactions)
* [ToastAudio](#toastaudio)
* [ToastHeader](#toastheader)


## <a name="toastcontent"></a>ToastContent
ToastContent は、視覚効果、アクション、オーディオなどの通知のコンテンツを説明する最上位のオブジェクトです。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Launch**| string | false | トーストによってアプリケーションがアクティブ化されるときにアプリケーションに渡される文字列です。 この文字列の形式とコンテンツは、アプリ独自の使用方法に合わせて、アプリによって定義されます。 ユーザーがトーストをタップまたはクリックして関連するアプリを起動すると、そのアプリは既定の方法では起動されません。起動文字列によってコンテキストがアプリに渡され、トーストのコンテンツに関連するビューがユーザーに表示されます。 |
| **Visual** | [ToastVisual](#toastvisual) | true | トースト通知の視覚的な部分について説明します。 |
| **Actions** | [IToastActions](#itoastactions) | false | 必要に応じて、ボタンや入力によってカスタム動作を作成します。 |
| **Audio** | [ToastAudio](#toastaudio) | false | トースト通知のオーディオ部分について説明します。 |
| **ActivationType** | [ToastActivationType](#toastactivationtype) | false | ユーザーがトーストの本文をクリックしたときに使用されるアクティブ化の種類を指定します。 |
| **ActivationOptions** | [ToastActivationOptions](#toastactivationoptions) | false | Creators Update の新機能: トースト通知のアクティブ化に関する追加オプションです。 |
| **Scenario** | [ToastScenario](#toastscenario) | false | アラームやリマインダーなど、トーストが使用されるシナリオを宣言します。 |
| **DisplayTimestamp** | DateTimeOffset? | false | Creators Update の新機能: 通知のコンテンツが Windows プラットフォームで受信されたときではなく実際に配信されたときを表すカスタムのタイムスタンプによって、既定のタイムスタンプを上書きします。 |
| **Header** | [ToastHeader](#toastheader) | false | Creators Update の新機能: 通知にカスタム ヘッダーを追加して、アクション センターで複数の通知をグループ化します。 |


### <a name="toastscenario"></a>ToastScenario
トーストが表すシナリオを指定します。

| 値 | 意味 |
|---|---|
| **Default** | 通常のトーストの動作です。 |
| **Reminder** | リマインダー通知です。 既に展開された状態で表示され、無視されるまでユーザーの画面に表示されます。 |
| **Alarm** | アラーム通知です。 既に展開された状態で表示され、無視されるまでユーザーの画面に表示されます。 オーディオは既定でループするようになっていて、アラームのオーディオを使用します。 |
| **IncomingCall** | 着信通知です。 既に展開された状態で、特殊な呼び出しの形式で表示され、無視されるまでユーザーの画面に表示されます。 オーディオは既定でループするようになっていて、着信音のオーディオを使用します。 |


## <a name="toastvisual"></a>ToastVisual
トーストの視覚的な部分です。テキスト、画像、アダプティブ コンテンツなどを含むバインディングが含まれます。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **BindingGeneric** | [ToastBindingGeneric](#toastbindinggeneric) | true | すべてのデバイスでレンダリングすることができる、汎用的なトーストのバインディングです。 このバインディングは必須で、null にすることはできません。 |
| **BaseUri** | Uri | false | 画像ソースの属性において相対 URL と組み合わされる、既定のベース URL です。 |
| **AddImageQuery** | bool? | false | true に設定すると、トースト通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |
| **Language**| string | false | ローカライズされたリソースを使用する際の視覚的なペイロードの対象ロケールです。"en-US" や "fr-FR" のように BCP-47 言語タグとして指定されます。 このロケールは、バインディングかテキストで指定されるあらゆるロケールによって上書きされます。 未指定の場合は、システム ロケールが代わりに使用されます。 |


## <a name="toastbindinggeneric"></a>ToastBindingGeneric
汎用のバインディングは、トーストの既定のバインディングです。ここでテキスト、画像、アダプティブ コンテンツなどを指定します。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Children** | IList<[IToastBindingGenericChild](#itoastbindinggenericchild)> | false | トーストの本文のコンテンツです。テキスト、画像、および (Anniversary Update で追加された) グループを含めることができます。 テキスト要素は他の要素よりも上に表示される必要があります。サポートされるテキスト要素は 3 つのみです。 テキスト要素が他の要素の後ろに配置されると、最上位にされるか、削除されます。 また、HintStyle などの特定のテキスト プロパティは、ルートの子テキスト要素ではサポートされず AdaptiveSubgroup 内でのみ機能します。 Anniversary Update を行っていないデバイスで AdaptiveGroup を使用する場合、グループのコンテンツは単に削除されます。 |
| **AppLogoOverride** | [ToastGenericAppLogo](#toastgenericapplogo) | false | アプリ ロゴを上書きするロゴです (省略可能)。 |
| **HeroImage** | [ToastGenericHeroImage](#toastgenericheroimage) | false | トーストとアクション センターで表示される、特色となるヒーロー画像です (省略可能)。 |
| **Attribution** | [ToastGenericAttributionText](#toastgenericattributiontext) | false | トースト通知の下部に表示される属性のテキストです (省略可能)。 |
| **BaseUri** | Uri | false | 画像ソースの属性において相対 URL と組み合わされる、既定のベース URL です。 |
| **AddImageQuery** | bool? | false | true に設定すると、トースト通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |
| **Language**| string | false | ローカライズされたリソースを使用する際の視覚的なペイロードの対象ロケールです。"en-US" や "fr-FR" のように BCP-47 言語タグとして指定されます。 このロケールは、バインディングかテキストで指定されるあらゆるロケールによって上書きされます。 未指定の場合は、システム ロケールが代わりに使用されます。 |


## <a name="itoastbindinggenericchild"></a>IToastBindingGenericChild
テキスト、画像、グループなどを含むトーストの子要素のマーカー インターフェイスです。

| Implementations |
| --- |
| [AdaptiveText](#adaptivetext) |
| [AdaptiveImage](#adaptiveimage) |
| [AdaptiveGroup](#adaptivegroup) |
| [AdaptiveProgressBar](#adaptiveprogressbar) |


## <a name="adaptivetext"></a>AdaptiveText
アダプティブなテキスト要素です。 最上位の ToastBindingGeneric.Children に配置すると HintMaxLines のみが適用されます。 ただし、グループ/サブグループの子として配置される場合、フル テキストのスタイル設定がサポートされます。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Text** | string または [BindableString](#bindablestring) | false | 表示するテキストです。 Creators Update で追加されたデータ バインディングのサポートは、最上位のテキスト要素に対してのみ機能します。 |
| **HintStyle** | [AdaptiveTextStyle](#adaptivetextstyle) | false | このスタイルは、テキストのフォント サイズ、太さ、および不透明度を制御します。 グループ/サブグループ内のテキスト要素に対してのみ機能します。 |
| **HintWrap** | bool? | false | true に設定すると、テキストの折り返しが有効になります。 最上位のテキスト要素はこのプロパティを無視し、常に折り返します (最上位のテキスト要素の折り返しを無効にするには HintMaxLines = 1 を使用します)。 グループ/サブグループ内のテキスト要素では、折り返しは既定で false に設定されています。 |
| **HintMaxLines** | int? | false | 表示が許可される、テキスト要素の最大行数です。 |
| **HintMinLines** | int? | false | 表示する必要のある、テキスト要素の最小行数です。 グループ/サブグループ内のテキスト要素に対してのみ機能します。 |
| **HintAlign** | [AdaptiveTextAlign](#adaptivetextalign) | false | テキストの水平方向の配置です。 グループ/サブグループ内のテキスト要素に対してのみ機能します。 |
| **Language** | string | false | XML ペイロードの対象ロケールです。"en-US" や "fr-FR" のように BCP-47 言語タグとして指定されます。 ここで指定されたロケールは、バインディングか視覚的な要素で指定されたその他のあらゆるロケールを上書きします。 この値がリテラル文字列の場合、この属性の既定値はユーザーの UI 言語になります。 この値が文字列リファレンスの場合、この属性の既定値は、文字列を解決する際に Windows ランタイムで選択されたロケールになります。 |


### <a name="bindablestring"></a>BindableString
文字列のバインディング値です。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **BindingName** | string | true | バインディング データ値に対してマップする名前を取得または設定します。 |


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
| **HintCrop** | [AdaptiveImageCrop](#adaptiveimagecrop) | false | Anniversary Update の新機能: 必要な画像トリミングを制御します。 |
| **HintRemoveMargin** | bool? | false | 既定では、グループ/サブグループ内の画像には周囲に 8 ピクセルの余白があります。 このプロパティを true に設定することで余白を削除できます。 |
| **HintAlign** | [AdaptiveImageAlign](#adaptiveimagealign) | false | 画像の水平方向の配置です。 グループ/サブグループ内の画像に対してのみ機能します。 |
| **AlternateText** | string | false | アクセシビリティ対応目的で使用される、画像を説明する代替テキストです。 |
| **AddImageQuery** | bool? | false | true に設定すると、トースト通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |


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
Anniversary Update の新機能: グループは、グループ内のコンテンツについて、全体を表示すべきか、収まりきらない場合は全体を表示すべきでないか意味的に識別します。 複数の列を作成することも可能にします。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Children** | IList<[AdaptiveSubgroup](#adaptivesubgroup)> | false | サブグループが垂直方向の列として表示されます。 AdaptiveGroup 内の任意のコンテンツを提供するにはサブグループを使用する必要があります。 |


## <a name="adaptivesubgroup"></a>AdaptiveSubgroup
Anniversary Update の新機能: サブグループは垂直方向の列で、テキストと画像を含めることができます。

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


## <a name="adaptiveprogressbar"></a>AdaptiveProgressBar
Creators Update の新機能: 進行状況バーです。 デスクトップ版、ビルド 15063 以降のトースト通知でのみサポートされます。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Title** | string または [BindableString](#bindablestring) | false | タイトルの文字列 (オプション) を取得または設定します。 データ バインディングをサポートしています。 |
| **Value** | double または [AdaptiveProgressBarValue](#adaptiveprogressbarvalue) か [BindableProgressBarValue](#bindableprogressbarvalue) | false | 進行状況バーの値を取得または設定します。 データ バインディングをサポートしています。 既定値は 0 です。 |
| **ValueStringOverride** | string または [BindableString](#bindablestring) | false | 割合を示す既定の文字列に代わって表示される文字列 (オプション) を取得または設定します。 これを指定しない場合は、"70%" などの文字が表示されます。 |
| **Status** | string または [BindableString](#bindablestring) | true | 進行状況バーの下の左側に表示されるステータス文字列 (必須) を取得または設定します。 この文字列は、"ダウンロード中..." や "インストール中..." などのように、操作の状態を反映する必要があります。 |


### <a name="adaptiveprogressbarvalue"></a>AdaptiveProgressBarValue
進行状況バーの値を表すクラスです。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Value** | double | false | 完了率を表す値 (0.0 ～ 1.0) を取得または設定します。 |
| **IsIndeterminate** | bool | false | 進行状況バーが不確定型かどうかを示す値を取得または設定します。 true の場合、**Value** は無視されます。 |


### <a name="bindableprogressbarvalue"></a>BindableProgressBarValue
バインディング可能な進行状況バーの値。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **BindingName** | string | true | バインディング データ値に対してマップする名前を取得または設定します。 |


## <a name="toastgenericapplogo"></a>ToastGenericAppLogo
アプリ ロゴの代わりに表示されるロゴです。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Source** | string | true | 画像への URL です。 ms-appx、ms-appdata、および http がサポートされます。 http の画像は、サイズを 200 KB 以下にする必要があります。 |
| **HintCrop** | [ToastGenericAppLogoCrop](#toastgenericapplogocrop) | false | 画像をトリミングする方法を指定します。 |
| **AlternateText** | string | false | アクセシビリティ対応目的で使用される、画像を説明する代替テキストです。 |
| **AddImageQuery** | bool? | false | true に設定すると、トースト通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |


### <a name="toastgenericapplogocrop"></a>ToastGenericAppLogoCrop
アプリ ロゴの画像のトリミングを制御します。

| 値 | 意味 |
|---|---|
| **Default** | トリミングがレンダラーの既定の動作を使用します。 |
| **None** | 画像がトリミングされず、正方形で表示されます。 |
| **Circle** | 画像が円形にトリミングされます。 |


## <a name="toastgenericheroimage"></a>ToastGenericHeroImage
トーストとアクション センターで表示される、特色となるヒーロー画像です。

| プロパティ | 型 | 必須かどうか |説明 |
|---|---|---|---|
| **Source** | string | true | 画像への URL です。 ms-appx、ms-appdata、および http がサポートされます。 http の画像は、サイズを 200 KB 以下にする必要があります。 |
| **AlternateText** | string | false | アクセシビリティ対応目的で使用される、画像を説明する代替テキストです。 |
| **AddImageQuery** | bool? | false | true に設定すると、トースト通知で指定された画像 URL に Windows がクエリ文字列を追加できるようになります。 この属性は、サーバーが画像をホストしていてクエリ文字列を処理できる場合に使用します。サーバーがこのために、クエリ文字列に基づいて画像の変化形を取得しているか、またはクエリ文字列を無視して使わずに指定の画像を返しているかどうかは問いません。 このクエリ文字列は、スケール、コントラスト設定、および言語を指定するものです。たとえば、通知で指定されている値 "www.website.com/images/hello.png" は "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us" になります。 |


## <a name="toastgenericattributiontext"></a>ToastGenericAttributionText
トースト通知の下部に表示される属性のテキストです。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Text** | string | true | 表示するテキストです。 |
| **Language** | string | false | ローカライズされたリソースを使用する際の視覚的なペイロードの対象ロケールです。"en-US" や "fr-FR" のように BCP-47 言語タグとして指定されます。 未指定の場合は、システム ロケールが代わりに使用されます。 |


## <a name="itoastactions"></a>IToastActions
トーストの操作/入力のマーカー インターフェイスです。

| Implementations |
| --- |
| [ToastActionsCustom](#toastactionscustom) |
| [ToastActionsSnoozeAndDismiss](#toastactionssnoozeanddismiss) |


## <a name="toastactionscustom"></a>ToastActionsCustom
*Implements [IToastActions](#itoastactions)*

ボタン、テキスト ボックス、選択入力などのコントロールを使用して、カスタムの操作や入力を独自に作成します。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Inputs** | IList<[IToastInput](#itoastinput)> | false | テキスト ボックスや選択入力などの入力です。 最大 5 つの入力が許可されます。 |
| **Buttons** | IList<[IToastButton](#itoastbutton)> | false | ボタンが、すべての入力の後ろに表示されます (または、ボタンがクイック返信ボタンとして使用されている場合は入力の隣に表示されます)。 最大 5 つのボタンが許可されます (コンテキスト メニュー項目もある場合はこれより少なくなります)。 |
| **ContextMenuItems** | IList<[ToastContextMenuItem](#toastcontextmenuitem)> | false | Anniversary Update の新機能: ユーザーが通知を右クリックした場合に追加の操作を提供する、カスタムのコンテキスト メニュー項目です。 ボタンとコンテキスト メニュー項目の数は、最大で*合わせて* 5 つに制限されます。 |


## <a name="itoastinput"></a>IToastInput
トーストの入力のマーカー インターフェイスです。

| Implementations |
| --- |
| [ToastTextBox](#toasttextbox) |
| [ToastSelectionBox](#toastselectionbox) |


## <a name="toasttextbox"></a>ToastTextBox
*Implements [IToastInput](#itoastinput)*

ユーザーがテキストを入力できるテキスト ボックス コントロールです。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Id** | string | true | この Id は必須です。ユーザーが入力したテキストを、アプリが後に使用するキー/値のペアである id/値にマップします。 |
| **Title** | string | false | テキスト ボックスの上部に表示されるタイトル テキストです。 |
| **PlaceholderContent** | string | false | ユーザーがまだテキストを入力していない場合にテキスト ボックスに表示されるプレースホルダー テキストです。 |
| **DefaultInput** | string | false | テキスト ボックスに配置される最初のテキストです。 テキスト ボックスを空白にするには null のままにします。 |


## <a name="toastselectionbox"></a>ToastSelectionBox
*Implements [IToastInput](#itoastinput)*

ユーザーがドロップダウン リストから選択できるようにする、選択ボックス コントロールです。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Id** | string | true | この Id は必須です。 ユーザーがこの項目を選択すると、この Id がアプリのコードに戻されて、ユーザーが選択したものを表します。 |
| **Content** | string | true | Content は必須です。選択項目に表示される文字列です。 |


### <a name="toastselectionboxitem"></a>ToastSelectionBoxItem
選択ボックス項目 (ユーザーがドロップダウン リストから選択できる項目) です。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Id** | string | true | この Id は必須です。ユーザーが入力したテキストを、アプリが後に使用するキー/値のペアである id/値にマップします。 |
| **Title** | string | false | 選択ボックスの上部に表示されるタイトル テキストです。 |
| **DefaultSelectionBoxItemId** | string | false | 既定で選択される項目を制御し、[ToastSelectionBoxItem](#toastselectionboxitem) の Id プロパティを参照します。 未指定の場合、既定の選択が空になります (ユーザーに何も表示されません)。 |
| **Items** | IList<[ToastSelectionBoxItem](#toastselectionboxitem)> | false | この SelectionBox からユーザーが選択できる選択項目です。 追加できる項目数は 5 個のみです。 |


## <a name="itoastbutton"></a>IToastButton
トースト ボタンのマーカー インターフェイスです。

| Implementations |
| --- |
| [ToastButton](#toastbutton) |
| [ToastButtonSnooze](#toastbuttonsnooze) |
| [ToastButtonDismiss](#toastbuttondismiss) |


## <a name="toastbutton"></a>ToastButton
*Implements [IToastButton](#itoastbutton)*

ユーザーがクリックするボタンです。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Content** | string | true | 必須です。 ボタンに表示されるテキストです。 |
| **Arguments** | string | true | 必須です。 ユーザーがこのボタンをクリックした場合にアプリが後から受け取る、アプリで定義された引数の文字列です。 |
| **ActivationType** | [ToastActivationType](#toastactivationtype) | false | ユーザーがクリックしたときにこのボタンが使用するアクティブ化の種類を制御します。 既定では Foreground に設定されます。 |
| **ActivationOptions** | [ToastActivationOptions](#toastactivationoptions) | false | Creators Update の新機能: トースト通知のボタンのアクティブ化に関する追加オプションを取得または設定します。 |


### <a name="toastactivationtype"></a>ToastActivationType
ユーザーが特定の操作を行った際に使用されるアクティブ化の種類を決定します。

| 値 | 意味 |
|---|---|
| **Foreground** | 既定値です。 フォアグラウンド アプリが起動します。 |
| **Background** | (すべての設定が完了したと想定して) 対応するバックグラウンド タスクがトリガーされ、ユーザーの作業を中断することなくバックグラウンドでコードを実行できます (ユーザーのクイック返信メッセージの送信など)。 |
| **Protocol** | プロトコルのアクティブ化を使用して別のアプリを起動します。 |


### <a name="toastactivationoptions"></a>ToastActivationOptions
Creators Update の新機能: アクティブ化に関する追加オプションです。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **AfterActivationBehavior** | [ToastAfterActivationBehavior](#toastafteractivationbehavior) | false | Fall Creators Update の新機能: ユーザーがこの操作を起動したときに、トーストが使用する動作を取得または設定します。 デスクトップで、[ToastButton](#toastbutton) と [ToastContextMenuItem](#toastcontextmenuitem) についてのみ機能します。 |
| **ProtocolActivationTargetApplicationPfn** | string | false | *ToastActivationType.Protocol* を使用している場合、対象の PFN を指定することもできます。こうすると、複数のアプリが同じプロトコル URI を処理するように登録されているかどうかに関係なく、常に目的のアプリが起動します。 |


### <a name="toastafteractivationbehavior"></a>ToastAfterActivationBehavior
ユーザーがトーストに対して操作を行ったときに、トーストが使用する動作を指定します。

| 値 | 意味 |
|---|---|
| **Default** | 既定の動作。 ユーザーがトーストに対して操作を行うと、トーストが無視されます。 |
| **PendingUpdate** | ユーザーがトースト上のボタンをクリックすると、通知が "更新の保留中" の表示状態で表示されたままになります。 この "更新の保留中" の表示状態が長時間続くことを避けるため、バックグラウンド タスクから即座にトーストを更新する必要があります。 |


## <a name="toastbuttonsnooze"></a>ToastButtonSnooze
*Implements [IToastButton](#itoastbutton)*

システムによって処理される "再通知" ボタンです。通知の再通知を自動的に処理します。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **CustomContent** | string | false | ボタンに表示される、省略可能なカスタム テキストです。既定のローカライズされた "再通知" テキストを上書きします。 |


## <a name="toastbuttondismiss"></a>ToastButtonDismiss
*Implements [IToastButton](#itoastbutton)*

システムによって処理される "無視" ボタンです。クリックすると通知が閉じます。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **CustomContent** | string | false | ボタンに表示される、省略可能なカスタム テキストです。既定のローカライズされた "無視" テキストを上書きします。 |


## <a name="toastactionssnoozeanddismiss"></a>ToastActionsSnoozeAndDismiss
*Implements [IToastActions](#itoastactions)

再通知の間隔を選択するボックスが自動的に作成されます。また、[snooze] (一時停止する) /[dismiss] (無視) ボタンがすべて自動的にローカライズされます。さらに、再通知ロジックがシステムによって自動的に処理されます。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **ContextMenuItems** | IList<[ToastContextMenuItem](#toastcontextmenuitem)> | false | Anniversary Update の新機能: ユーザーが通知を右クリックした場合に追加の操作を提供する、カスタムのコンテキスト メニュー項目です。 項目の数は最大 5 つに制限されます。 |


## <a name="toastcontextmenuitem"></a>ToastContextMenuItem
コンテキスト メニュー項目のエントリです。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Content** | string | true | 必須です。 表示するテキストです。 |
| **Arguments** | string | true | 必須です。 アプリで定義された引数の文字列です。ユーザーがメニュー項目をクリックしたときにアクティブ化されたら、アプリが後から取得することが可能になります。 |
| **ActivationType** | [ToastActivationType](#toastactivationtype) | false | ユーザーがクリックしたときにこのメニュー項目が使用するアクティブ化の種類を制御します。 既定では Foreground に設定されます。 |
| **ActivationOptions** | [ToastActivationOptions](#toastactivationoptions) | false | Creators Update の新機能: トーストのコンテキスト メニュー項目のアクティブ化に関する追加オプションです。 |


## <a name="toastaudio"></a>ToastAudio
トースト通知を受け取ったときに再生するオーディオを指定します。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Src** | uri | false | 既定のサウンドの代わりに再生するメディア ファイルです。 ms-appx と ms-appdata のみがサポートされます。 |
| **Loop** | boolean | false | トーストが表示されている間サウンドを繰り返す必要がある場合は true に、一度だけ再生する場合 (既定) は false に設定します。 |
| **Silent** | boolean | false | true に設定するとサウンドがミュートされ、false に設定するとトースト通知のサウンドが再生されます (既定)。 |


## <a name="toastheader"></a>ToastHeader
Creators Update の新機能: アクション センターで複数の通知をグループ化するカスタム ヘッダーです。

| プロパティ | 型 | 必須かどうか | 説明 |
|---|---|---|---|
| **Id** | string | true | 開発者が作成した識別子です。このヘッダーを一意に識別します。 2 つの通知が同じヘッダー ID を持つ場合、アクション センターで同じヘッダーの下に表示されます。 |
| **Title** | string | true | ヘッダーのタイトルです。 |
| **Arguments**| string | true | ユーザーがこのヘッダーをクリックすると、アプリに返された引数の開発者によって定義された文字列を取得または設定します。 null に設定することはできません。 |
| **ActivationType** | [ToastActivationType](#toastactivationtype) | false | ユーザーがクリックしたときにこのヘッダーが使用するアクティブ化の種類を取得または設定します。 既定では Foreground に設定されます。 サポートされる値は、Foreground と Protocol のみです。 |
| **ActivationOptions** | [ToastActivationOptions](#toastactivationoptions) | false | トースト ヘッダーのアクティブ化に関する追加オプションを取得または設定します。 |


## <a name="related-topics"></a>関連トピック

* [Quickstart: Send a local toast and handle activation (クイックスタート: ローカル トースト通知の送信とアクティブ化の処理)](http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/07/08/quickstart-sending-a-local-toast-notification-and-handling-activations-from-it-windows-10.aspx)
* [GitHub の Notifications ライブラリ](https://github.com/Microsoft/UWPCommunityToolkit/tree/dev/Notifications)