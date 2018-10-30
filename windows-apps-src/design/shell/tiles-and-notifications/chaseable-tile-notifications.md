---
author: andrewleader
Description: Use chaseable tile notifications to find out what your app displayed on its Live Tile when the user clicked it.
title: 追跡可能なタイル通知
ms.assetid: E9AB7156-A29E-4ED7-B286-DA4A6E683638
label: Chaseable tile notifications
template: detail.hbs
ms.author: mijacobs
ms.date: 06/13/2017
ms.topic: article
keywords: Windows 10, UWP, 追跡可能なタイル, ライブ タイル, 追跡可能なタイル通知
ms.localizationpriority: medium
ms.openlocfilehash: 8126755dfb6f5f0e117d10daef85a83e8a171f1f
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5752242"
---
# <a name="chaseable-tile-notifications"></a>追跡可能なタイル通知

追跡可能なタイル通知を使用すると、ユーザーがライブ タイルをクリックしたときに、アプリのライブ タイルに表示されるタイル通知を特定することができます。  
たとえば、新しいアプリでこの機能を使用して、ユーザーがライブ タイルを起動したときにそのタイルに表示される新しいストーリーを特定することができます。これにより、ユーザーが見つけることができるように、ストーリーを目立たせて表示することができます。 

> [!IMPORTANT]
> **Anniversary Update が必要**: C#、C++、または VB ベースの UWP アプリで追跡可能なタイル通知を使用するには、SDK 14393 以降をターゲットとし、ビルド 14393 以降を実行している必要があります。 JavaScript ベースの UWP アプリの場合は、SDK 17134 以降をターゲットとし、ビルド 17134 以降を実行している必要があります。 


> **重要な API**: [LaunchActivatedEventArgs.TileActivatedInfo プロパティ](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs.TileActivatedInfo)、[TileActivatedInfo クラス](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo)


## <a name="how-it-works"></a>動作のしくみ

追跡可能なタイル通知を有効にするには、タイル通知ペイロードで **Arguments** プロパティ (トースト通知ペイロードの起動プロパティに類似) を使用して、タイル通知のコンテンツに関する情報を埋め込みます。

アプリがライブ タイル経由で起動されると、システムは、現在または最後に表示されたタイル通知を基に引数の一覧を返します。


## <a name="when-to-use-chaseable-tile-notifications"></a>追跡可能なタイル通知を使用する状況

通常、追跡可能なタイル通知は、ライブ タイルで通知キューを使っているとき (つまり、最大 5 件の異なる通知を循環しているとき) に使用されます。 追跡可能なタイル通知は、ライブ タイルのコンテンツがアプリの最新のコンテンツと同期されていないと考えられる場合にも役立ちます。 たとえば、ニュース アプリでは 30 分ごとにライブ タイルが更新されますが、アプリが起動すると、最新のニュースが読み込まれます (前回のポーリング間隔でタイルに表示されていた情報が含まれなくなる可能性があります)。 この場合、ライブ タイルに表示されていたストーリーを見つけることができなくなり、ユーザーが不満を感じる可能性があります。 こうした問題に対応する際に追跡可能なタイル通知が役立ちます。このタイル通知によって、タイルでユーザーに表示されていた情報を簡単に見つけることができます。

## <a name="what-to-do-with-a-chaseable-tile-notifications"></a>追跡可能なタイル通知で実行できること

注意が必要な最も重要なことは、ほとんどのシナリオでは、ユーザーがクリックしたときにタイルに表示されていた**特定の通知に直接移動しない**ということです。 ライブ タイルは、アプリケーションへのエントリ ポイントとして使用されます。 ユーザーがライブ タイルをクリックする場合は、次の 2 つのシナリオが考えられます。(1) アプリを通常どおりに起動する場合、(2) ライブ タイルに表示されていた特定の通知についてさらに詳しい情報を表示する場合。 必要な動作をユーザーが明示的に指定する方法がないため、理想的なエクスペリエンスは、**ユーザーに表示されていた通知を簡単に検出できるようにしながら、アプリを通常どおりに起動する**というものになります。

たとえば、MSN ニュース アプリのライブ タイルをクリックしてアプリを通常どおりに起動したときに、ホーム ページを表示するか、またはユーザーが前に読んでいたいずれかの記事を表示するようにします。 ただしホーム ページを表示した場合は、アプリでライブ タイルのストーリーを簡単に検出できるようにします。 これにより、両方のシナリオ (単純にアプリを起動/再開するシナリオと特定のストーリーを表示するシナリオ) がサポートされます。


## <a name="how-to-include-the-arguments-property-in-your-tile-notification-payload"></a>タイル通知ペイロードに Arguments プロパティを含める方法

通知ペイロードで引数プロパティを使用することで、アプリは、後で通知を識別する際に使用できるデータを提供することができます。 たとえば、引数にストーリーの ID を含めて、起動時にストーリーを取得し表示することができます。 プロパティは、シリアル化することができる文字列であればどのような文字列でも受け入れます (クエリ文字列、JSON など)。ただし、通常はクエリ文字列の形式を使用することをお勧めします。これは、クエリ文字列は軽量であり、適切に XML エンコードされるためです。

プロパティは **TileVisual** 要素と **TileBinding** 要素の両方に対して設定でき、カスケードが起こります。 すべてのタイル サイズで同じ引数が必要な場合は、引数を **TileVisual** 要素に対して設定するだけです。 特定のタイル サイズで特定の引数が必要な場合は、引数を個別の **TileBinding** 要素に対して設定することができます。

この例では、通知を後で識別するための引数プロパティを使用する通知ペイロードを作成します。 

```csharp
// Uses the following NuGet packages
// - Microsoft.Toolkit.Uwp.Notifications
// - QueryString.NET
 
TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        // These arguments cascade down to Medium and Wide
        Arguments = new QueryString()
        {
            { "action", "storyClicked" },
            { "story", "201c9b1" }
        }.ToString(),
 
 
        // Medium tile
        TileMedium = new TileBinding()
        {
            Content = new TileBindingContentAdaptive()
            {
                // Omitted
            }
        },
 
 
        // Wide tile is same as Medium
        TileWide = new TileBinding() { /* Omitted */ },
 
 
        // Large tile is an aggregate of multiple stories
        // and therefore needs different arguments
        TileLarge = new TileBinding()
        {
            Arguments = new QueryString()
            {
                { "action", "storiesClicked" },
                { "story", "43f939ag" },
                { "story", "201c9b1" },
                { "story", "d9481ca" }
            }.ToString(),
 
            Content = new TileBindingContentAdaptive() { /* Omitted */ }
        }
    }
};
```


## <a name="how-to-check-for-the-arguments-property-when-your-app-launches"></a>アプリの起動時に引数プロパティを確認する方法

ほとんどのアプリは App.xaml.cs を保持しており、このファイルには [OnLaunched](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) メソッドのオーバーライドが含まれています。 その名前が示すように、アプリは起動時にこのメソッドを呼び出します。 使用される引数は 1 つだけで、それは [LaunchActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs) オブジェクトです。

LaunchActivatedEventArgs オブジェクトには、追跡可能な通知を有効にするプロパティがあります。そのプロパティは、[TileActivatedInfo プロパティ](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs.TileActivatedInfo)で、[TileActivatedInfo オブジェクト](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo)へのアクセスを可能にします。 ユーザーがタイルからアプリを起動すると (アプリ一覧、検索、または他のエントリ ポイントから起動するのではありません)、アプリはこのプロパティを初期化します。

[TileActivatedInfo オブジェクト](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo)には [RecentlyShownNotifications](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo.RecentlyShownNotifications) と呼ばれるプロパティが含まれています。このプロパティは、過去 15 分以内にタイルに表示されていた通知の一覧を保持しています。 一覧の最初の項目はタイルの現在の通知を表しており、それ以降の項目は現在の通知よりも前に表示されていた通知を表しています。 タイルがクリアされた場合、この一覧は空になります。

各 ShownTileNotificationhas、Argumentsproperty します。 Argumentsproperty は、タイル通知ペイロードから argumentsstring に初期化されたか、ペイロードには、argumentsstring が含まれていない場合は null になります。

```csharp
protected override void OnLaunched(LaunchActivatedEventArgs args)
{
    // If the API is present (doesn't exist on 10240 and 10586)
    if (ApiInformation.IsPropertyPresent(typeof(LaunchActivatedEventArgs).FullName, nameof(LaunchActivatedEventArgs.TileActivatedInfo)))
    {
        // If clicked on from tile
        if (args.TileActivatedInfo != null)
        {
            // If tile notification(s) were present
            if (args.TileActivatedInfo.RecentlyShownNotifications.Count > 0)
            {
                // Get arguments from the notifications that were recently displayed
                string[] allArgs = args.TileActivatedInfo.RecentlyShownNotifications
                .Select(i => i.Arguments)
                .ToArray();
 
                // TODO: Highlight each story in the app
            }
        }
    }
 
    // TODO: Initialize app
}
```


## <a name="raw-xml-example"></a>生の XML の例

Notifications ライブラリではなく生の XML を使用する場合、XML は次のようになります。

```xml
<tile>
  <visual arguments="action=storyClicked&amp;story=201c9b1">
 
    <binding template="TileMedium">
       
      <text>Kitten learns how to drive a car...</text>
      ... (omitted)
     
    </binding>
 
    <binding template="TileWide">
      ... (same as Medium)
    </binding>
     
    <!--Large tile is an aggregate of multiple stories-->
    <binding
      template="TileLarge"
      arguments="action=storiesClicked&amp;story=43f939ag&amp;story=201c9b1&amp;story=d9481ca">
   
      <text>Can your dog understand what you're saying?</text>
      ... (another story)
      ... (one more story)
   
    </binding>
 
  </visual>
</tile>
```



## <a name="related-articles"></a>関連記事

- [LaunchActivatedEventArgs.TileActivatedInfo プロパティ](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.launchactivatedeventargs#Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_TileActivatedInfo_)
- [TileActivatedInfo クラス](https://docs.microsoft.com/uwp/api/windows.applicationmodel.activation.tileactivatedinfo)