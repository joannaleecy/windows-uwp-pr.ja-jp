---
author: jwmsft
description: Sets UI で最適なエクスペリエンスを提供するためにアプリを最適化する方法について説明します。
title: Sets の設計
template: detail.hbs
ms.author: jimwalk
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, タイトル バー
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 7c3e0e6ec7331e860c9153e2a2e29a51fb5848bd
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "4964273"
---
# <a name="designing-for-sets"></a>Sets の設計

> [!IMPORTANT]
> この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。

Windows Insider Preview 以降では、Sets 機能をアプリのユーザーが利用できます。 Sets を使用すると、他のアプリと共有される可能性があるウィンドウにアプリが表示され、各アプリでタイトル バーに専用のタブが表示されます。

この記事では、Sets UI で最適なエクスペリエンスを提供するためにアプリを最適化する必要がある領域について説明します。

> [!TIP]
> Sets の詳細については、[Sets の概要](https://insider.windows.com/en-us/articles/introducing-sets/)に関するブログ記事と[Sets の開発](https://developer.microsoft.com/events/build/content/developing-for-sets-on-windows-10)に関する Microsoft Build 2018 での講演を参照してください。

## <a name="customizing-tab-visuals"></a>タブの視覚効果のカスタマイズ

既定では、システムはアプリのタブがアクティブであるときにタブのテキストとアイコンの適切な色を選択するよう試みます。 これにより、アプリのタブは開発者側で最小限の労力で、または Sets の最適化を行わない場合でも適切に表示されるようになります。

ただし、アプリのタブの色をカスタマイズすることが最適である場合もあります。 このセクションでは、既定のタブの動作について説明し、アプリのタブを変更する必要がある場合と必要がない場合について説明します。

### <a name="tab-states"></a>タブの状態

アプリが Set 内にある場合は、アプリのタブは、選択済みでアクティブ、選択済みで非アクティブ、または未選択で非アクティブの 3 つの状態のいずれかになります。

- **Selected-Active (選択済みでアクティブ)**: グループ化されたウィンドウのセット内から選択され、アクティブなフォアグラウンド ウィンドウ内にあるタブ。

    (このドキュメントでは、_アクティブな_タブとはタブが選択済みでアクティブという意味です。)
- **Selected-Inactive (選択済みで非アクティブ)**: グループ化されたウィンドウのセット内から選択され、アクティブなフォアグラウンド ウィンドウ内にないタブ。
- **Unselected-Inactive (未選択で非アクティブ)**: グループ化されたウィンドウのセット内から選択されていないタブ。

非アクティブなタブの色がシステムのテーマに基づいて、システムによって更新および維持されます。 アプリから影響を与えることはできません。

既定では、選択されたアクティブなタブでは Windows の設定でユーザーが指定したシステム テーマ カラーが適用されます。 タブがアクティブな場合にのみ、アプリのタブの色をカスタマイズできます。

![Sets のタブの状態](images/sets-tab-states.jpg)

### <a name="coloring-of-active-tabs"></a>アクティブなタブの色

アクティブなタブの色は、アプリで設定した値によって、またはシステム設定によって決まります。 アプリがアクティブなときに使用されるタブの色は、次のように決定されます。

- アプリでタブの色を指定すると、その色の優先順位が最も高くなります。 アプリで指定したタブの色は、システム設定に関係なくアプリがアクティブなときに使用されます。
- それ以外の場合、タイトル バーにアクセント カラーを表示するためにユーザーが Windows の設定でオプションを選択すると、システムのアクセント カラーが使用されます。
  - この設定は、Windows 設定アプリの [パーソナル設定] > [色] > [以下の場所にアクセント カラーを表示します] の [タイトル バー] にあります。
- 最後に、アプリまたはユーザーの設定が適用されていない場合、タブは、現在のシステム テーマの色を使用します。

### <a name="considerations-when-you-modify-tab-colors"></a>タブの色を変更する場合の考慮事項

ここでは、アプリのタブの色を変更する可能性がある状況、およびそのような場合に考慮する必要がある事項について説明します。 タブの色を変更しないことをお勧めする状況についても説明しますが、それはシステムで管理するようにします。

#### <a name="match-your-brand-colors"></a>ブランドの色を一致させる

通常、タブの色を変更するかどうかを決定する最も重要な要素は、ブランドの色と一致させたいという要望です。 ブランドの色と一致するようにアプリのタブを変更する場合、アプリのレイアウトや異なるシステム テーマの色など、このセクションで説明されているその他の考慮事項を踏まえて外観をテストする必要があります。

#### <a name="horizontal-layout"></a>水平方向のレイアウト

アプリのレイアウトに、上部で水平方向に伸びる単色 (アクリル以外) のブランド色が含まれる場合、通常、一致する色を使用して、アプリをタブとつなげるのが適切です。 できればアプリの上部で使用されている色につながりをもたせることで、アプリと関係があると感じられる単色をタブに選択します。

#### <a name="horizontal-layout-with-acrylic"></a>アクリルを使用した横長のレイアウト

アプリで、上部で水平方向に伸びるアクリル素材のブランドが使用されている場合、システムにタブの色を決定させることをお勧めします。

また、背景アクリルではなく、アプリ内アクリルをここで使用することをお勧めします。これにより、このブランドの背後でアプリケーションまたはデスクトップを通じて表示される縞模様の効果を作成するのではなく、アプリケーション バックグラウンドがこの領域に流れるようにします。

この場合、ユーザーはこれらのタブを設定してアクセント カラーを使用し、タブが淡色/濃色のテーマまたはアクセント カラーで表示されるようにすることができます。

#### <a name="vertical-layout"></a>縦方向のレイアウト

垂直方向に伸びる単色の縦のウィンドウがアプリ レイアウトに含まれる場合は、タブの色をカスタマイズしないことをお勧めします。 アプリ上のタブの位置はユーザーがいつでも変更できるため、アプリの上部とタブの間の色の連続性を利用することはできません。システムでは、タブをアプリとつなげるために、影などのその他の視覚的な合図を使用します。

### <a name="how-to-modify-tab-colors"></a>タブの色を変更する方法

アクティブなタブの色は、既存のタイトル バーのカスタマイズ用 API を使用します。 既にアプリのタイトル バーの色をカスタマイズした場合は、アプリが Set 内にあるときにその変更がアプリのタブにも適用されます。

タブの色を変更するには、[ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar) プロパティを設定して次の内容を指定します。

- タブに対する単色の背景色。
- タブのテキストに対する単色の前景色。

この例では、ApplicationViewTitleBar のインスタンスを取得し、色のプロパティを設定する方法を示しています。

```csharp
// using Windows.UI.ViewManagement;
var titleBar = ApplicationView.GetForCurrentView().TitleBar;

// Set active window colors
titleBar.ForegroundColor = Windows.UI.Colors.White;
titleBar.BackgroundColor = Windows.UI.Colors.Green;
```

詳細については、「[タイトル バーのカスタマイズ](title-bar.md#simple-color-customization)」の記事と「[タイトル バーのカスタマイズのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620613)」の「_単純な色のカスタマイズ_」のセクションを参照してください。

### <a name="considerations-for-full-title-bar-customization"></a>タイトル バーの全面的なカスタマイズに関する考慮事項

「[タイトル バーのカスタマイズ](title-bar.md#full-customization)」の記事の「_全面的なカスタマイズ_」のセクションに示されているように、アプリのタイトル バーを完全にカスタマイズすることもできます。 通常これは、[アクリルをタイトル バーに拡張する](../style/acrylic.md#extend-acrylic-into-the-title-bar)か、またはカスタム コンテンツをタイトル バーに配置するために行います。 これを行う場合は、必ず全画面表示とタブレット モードのガイダンスに従い、[CoreApplicationViewTitleBar.IsVisible](/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.isvisible) が **true** の場合は、カスタム タイトル バーのコンテンツのみ表示するようにしてください。

アプリが Set で実行され、CoreApplicationViewTitleBar.IsVisible が **false** の場合は、タイトル バーのコンテンツが表示されないようにします。 ただし、このガイダンスに従ってカスタム タイトル バーのコンテンツを非表示にしない場合は、カスタム タイトル バーはタイトル バー領域ではなくアプリのタブの下に表示されます。

カスタム タイトル バーの UI にコンテンツや機能を配置した場合は、アプリの別の UI サーフェスでそれが利用できるようにすることを考慮してください。

### <a name="how-to-modify-the-tab-icon"></a>タブのアイコンを変更する方法

アプリ アイコンが Set 内で最適に表示されるようにするには、アプリの代替のプレートなしのアイコンを指定する必要があります  (アプリのタブで使用されるアプリ アイコンは、タスク バーで使用されるのと同じアイコンです)。代替のアイコンの目的は、任意の背景色に対して最適に表示されることです。 代替のアイコンは、利用可能な場合に使用されます。

アプリ マニフェストでは、通常のアイコンだけでなく、代替フォームのプレートなしのアイコンを指定します。 詳細については、[アプリのアイコンとロゴ](/windows/uwp/design/style/app-icons-and-logos)を参照してください。 指定するアイコンは、「プレートなしのターゲット サイズの一覧のアセット」として」の記事の[アプリ アイコン アセットの詳細](/windows/uwp/design/style/app-icons-and-logos#more-about-app-icon-assets)セクションに記載されています。

アプリ マニフェストで代替のアイコンを指定しない場合、システムはタイル アイコンをタブの色で再プレートし、それを使用します。

![Sets で使用されるアイコン](images/sets-icons.png)

> タスク バーとアプリ タブで、同じアイコンが使用されます。

## <a name="restore-previous-sets-with-user-activities"></a>ユーザー アクティビティによる前の Sets の復元

Sets の利点は、ユーザーがアプリを起動したときやドキュメントを開いたときに、アプリや Web コンテンツの以前に開いたタブを復元できることです  (詳細については、[Sets の概要](https://insider.windows.com/en-us/articles/introducing-sets/)に関するブログ記事にあるビデオを参照してください)。これは、_ユーザー アクティビティ_によって有効になります。

既定では、システムはアプリの代わりにユーザー アクティビティを作成します。これによりユーザーがアプリを起動したときやドキュメントを開いたときにアプリがタブに復元されます。 ただし、システムによって作成された既定のユーザー アクティビティでは、既定の状態でのみアプリを起動できます。 Set の一部として以前の状態にアプリを復元することはできません。

カスタム ユーザー アクティビティを提供することで、Sets のアプリを最適化できます。 指定するユーザー アクティビティはアプリにディープ リンクし、復元されている Set の一部として前回の状態にアプリを復元します。

カスタム ユーザー アクティビティを指定するには:

- OS により開始された [UserActivityRequest](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityrequest) に適切な [UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity) で応答します。
- UserActivity には、システムが特定のコンテキストでアプリを起動するために使用するアクティブ化のディープ リンク URI が含まれます。

詳細については、「[UserActivityRequestManager.UserActivityRequested イベント](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityrequestmanager.useractivityrequested)」、「[URI のアクティブ化の処理](https://docs.microsoft.com/windows/uwp/launch-resume/handle-uri-activation)」、「[デバイス間でもユーザーのアクティビティを継続する](https://docs.microsoft.com/windows/uwp/launch-resume/useractivities)」を参照してください。

## <a name="enable-multi-instance-for-uwp-apps"></a>UWP アプリ用のマルチインスタンスを有効にします。

Windows 10 Version 1803 以降、UWP アプリはマルチインスタンスをサポートします。 UWP は既定でまだ単一インスタンスであり、マルチインスタンス化する各アプリを明示的に選択する必要があります。

アプリをマルチインスタンスにする場合は、ユーザーが一度に複数の Set でアプリを実行するようにできるメリットがあります。 単一インスタンスのアプリは一度に 1 つの Set でしか実行できません。

UWP アプリのマルチインスタンスを有効にする方法の詳細については、「[マルチインスタンスのユニバーサル Windows アプリの作成](https://docs.microsoft.com/windows/uwp/launch-resume/multi-instance-uwp)」を参照してください。

## <a name="use-an-in-app-back-button"></a>アプリ内の戻るボタンの使用

アプリに前に戻る移動を実装するには、「[戻るボタンのガイダンス](../basics/navigation-history-and-backwards-navigation.md)」に従って、アプリの UI に戻るボタンを配置することをお勧めします。 アプリで NavigationView コントロールを使用する場合は、NavigationView の組み込みの戻るボタンを使用する必要があります。

アプリでシステムの戻るボタンを使用している場合は、代わりにアプリ内の戻るボタンで置き換える必要があります。 これにより、アプリが Set で実行されているかどうかにかかわらず、ユーザーに一貫性のある戻るボタンのエクスペリエンスが提供されます。また、アプリ間で戻るボタンの視覚効果の一貫性が維持されるようになります。

アプリ内の戻るボタンの統合に関する詳細なガイダンスについては、「[ナビゲーション履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」を参照してください。

### <a name="support-for-the-system-back-button-in-sets"></a>Sets 内のシステムの戻るボタンのサポート

アプリでアプリ内ボタンではなくシステムの戻るボタンを使用している場合、下位互換性を確保するためにシステム UI には引き続きシステムの戻るボタンがレンダリングされます。

- アプリが Set 内にない場合は、戻るボタンはタイトル バーの内部にレンダリングされます。 戻るボタンの視覚エクスペリエンスとユーザー操作は変更されません。
- アプリが Set 内にある場合は、戻るボタンはシステムの戻るバーの内部にレンダリングされます。

システムの戻るバーは、タブ バンドとアプリのコンテンツ領域の間に挿入されている "バンド" です。 バンドは、アプリの幅に沿って表示され、左端に戻るボタンが配置されます。 バンドには、戻るボタンの適切なタッチ ターゲットのサイズを確保するために十分な高さがあります。

![Sets 内のシステムの戻るバー](images/sets-system-back-bar.png)

> アプリに表示されたシステムの戻るバー。

システムの戻るバーは、戻るボタンの可視性に基づいて動的に表示されます。 戻るボタンが表示されている場合、システムの戻るバーが挿入され、アプリのコンテンツがタブ バンドの下に移動します。 戻るボタンが非表示の場合、システムの戻るバーは動的に削除され、アプリのコンテンツがタブ バンドに合うように移動します。

アプリの UI が上下に移動するのを避けるために、システムの戻るボタンの代わりに、アプリ内の戻るボタンを使用することをお勧めします。

タイトル バーのカスタマイズは、アプリ タブとシステムの戻るバーの両方に引き継がれます。 ApplicationViewTitleBar API を使用して背景色と前景色のプロパティを指定する場合は、色がタブとシステムの戻るバーに適用されます。

## <a name="related-articles"></a>関連記事

- [タイトル バーのカスタマイズ](title-bar.md)
- [ナビゲーション履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)
- [色](../style/color.md)
