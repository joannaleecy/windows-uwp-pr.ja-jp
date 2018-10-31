---
author: jwmsft
Description: Use content links to embed rich data in your text controls.
title: テキスト コントロールのコンテンツ リンク
label: Content links
template: detail.hbs
ms.author: jimwalk
ms.date: 03/07/2018
ms.topic: article
keywords: windows 10, UWP
pm-contact: miguelrb
design-contact: ''
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 5f8a63e91bd5415f33118294a03567bb5e670ae2
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5839823"
---
# <a name="content-links-in-text-controls"></a>テキスト コントロールのコンテンツ リンク

コンテンツ リンクを使用すると、テキスト コントロールにリッチ データを埋め込むことができます。これによってユーザーは、アプリのコンテキストから離れることなく、人物や場所に関する詳しい情報を見つけることができます。

RichEditBox でユーザーがアンパサンド (@) 記号を使用してエントリにプレフィックスを付けると、そのエントリに一致する人々および/または場所の候補のリストが表示されます。 次に、たとえば、ユーザーが場所を選択すると、その場所の ContentLink がテキストに挿入されます。 ユーザーが RichEditBox からコンテンツ リンクを呼び出すと、その場所に関する地図と追加情報を示したポップアップが表示されます。

> **重要な API**: [ContentLink クラス](/uwp/api/windows.ui.xaml.documents.contentlink)、[ContentLinkInfo クラス](/uwp/api/windows.ui.text.contentlinkinfo)、[RichEditTextRange クラス](/uwp/api/windows.ui.text.richedittextrange)

> [!NOTE]
> コンテンツ リンクの API は次の名前空間に拡散されます。 Windows.UI.Xaml.Controls、Windows.UI.Xaml.Documents、および Windows.UI.Text。



## <a name="content-links-in-rich-edit-vs-text-block-controls"></a>リッチ エディット コントロールとテキスト ブロック コントロールでのコンテンツ リンク

コンテンツ リンクを使用する方法には、以下の 2 種類があります。

1. [RichEditBox](/uwp/api/windows.ui.xaml.controls.richeditbox) では、ユーザーはピッカーを開いてテキストの先頭に @ 記号を付けて指定し、コンテンツ リンクを追加できます。 コンテンツ リンクは、リッチ テキスト コンテンツの一部として保存されます。
1. [TextBlock](/uwp/api/windows.ui.xaml.controls.textblock) または [RichTextBlock](/uwp/api/windows.ui.xaml.controls.richtextblock) では、コンテンツ リンクは、使用法や動作が[ハイパーリンク](/uwp/api/windows.ui.xaml.documents.hyperlink)とよく似たテキスト要素です。

既定でコンテンツ リンクが RichEditBox と TextBlock でどのように表示されるかを示します。

![リッチ エディット ボックスでのコンテンツ リンク](images/content-link-default-richedit.png)
![テキスト ブロックでのコンテンツ リンク](images/content-link-default-textblock.png)

使用状況、レンダリング、および動作の相違点については、次のセクションで詳しく説明します。 次の表は、RichEditBox のコンテンツ リンクとテキスト ブロックの主な相違点を比較した早見表です。

| 機能   | RichEditBox | テキスト ブロック |
| --------- | ----------- | ---------- |
| 使用状況 | ContentLinkInfo インスタンス | ContentLink テキスト要素 |
| Cursor | コンテンツ リンクの種類によって決まり、変更することはできません | Cursor プロパティによって決まります。既定では **null** です |
| ToolTip | 表示されません | セカンダリ テキストを表示します |

## <a name="enable-content-links-in-a-richeditbox"></a>RichEditBox でコンテンツ リンクを有効にします

コンテンツ リンクの最も一般的な用途は、ユーザーがテキスト内の人物または場所の名前の先頭にアンパサンド (@) 記号を付けることによって、情報をすばやく追加できるようにすることです。 [RichEditBox](/uwp/api/windows.ui.xaml.controls.richeditbox) で有効になっている場合、ピッカーが開き、ユーザーは有効にした内容に応じて、連絡先リストまたは近くの場所から人物を挿入できます。

コンテンツ リンクは、リッチ テキスト コンテンツで保存でき、抽出してアプリの他の部分で使用することができます。 たとえば、メール アプリで個人情報を抽出し、それを使用して [終了] ボックスにメール アドレスを設定することができます。

> [!NOTE]
> コンテンツ リンク ピッカーは、Windows の一部であるアプリであるため、アプリと別のプロセスで実行されます。

### <a name="content-link-providers"></a>コンテンツ リンク プロバイダー

RichEditBox でコンテンツ リンクを有効にするには、1 つまたは複数のコンテンツ リンク プロバイダーを [RichEditBox.ContentLinkProviders](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkProviders) コレクションに追加します。 XAML フレームワークに組み込まれているコンテンツ リンク プロバイダーが 2 つあります。

- [ContactContentLinkProvider](/uwp/api/windows.ui.xaml.documents.contactcontentlinkprovider) – **People**アプリを使用して連絡先を検索します。
- [PlaceContentLinkProvider](/uwp/api/windows.ui.xaml.documents.placecontentlinkprovider) – **Maps**アプリを使用して場所を検索します。

> [!IMPORTANT]
> RichEditBox.ContentLinkProviders プロパティの既定値は **null** であり、空のコレクションではありません。 コンテンツ リンク プロバイダーを追加する前に、[ContentLinkProviderCollection](/uwp/api/windows.ui.xaml.documents.contentlinkprovidercollection) を明示的に作成する必要があります。

XAML でコンテンツ リンク プロバイダーを追加する方法を示します。

```xaml
<RichEditBox>
    <RichEditBox.ContentLinkProviders>
        <ContentLinkProviderCollection>
            <ContactContentLinkProvider/>
            <PlaceContentLinkProvider/>
        </ContentLinkProviderCollection>
    </RichEditBox.ContentLinkProviders>
</RichEditBox>
```

スタイルにコンテンツ リンク プロバイダーを追加し、次のように複数の RichEditBoxes に適用することもできます。

```xaml
<Page.Resources>
    <Style TargetType="RichEditBox" x:Key="ContentLinkStyle">
        <Setter Property="ContentLinkProviders">
            <Setter.Value>
                <ContentLinkProviderCollection>
                    <PlaceContentLinkProvider/>
                    <ContactContentLinkProvider/>
                </ContentLinkProviderCollection>
            </Setter.Value>
        </Setter>
    </Style>
</Page.Resources>

<RichEditBox x:Name="RichEditBox01" Style="{StaticResource ContentLinkStyle}" />
<RichEditBox x:Name="RichEditBox02" Style="{StaticResource ContentLinkStyle}" />
```

コードでコンテンツ リンク プロバイダーを追加する方法を示します。

```csharp
RichEditBox editor = new RichEditBox();
editor.ContentLinkProviders = new ContentLinkProviderCollection
{
    new ContactContentLinkProvider(),
    new PlaceContentLinkProvider()
};
```

### <a name="content-link-colors"></a>コンテンツ リンクの色

コンテンツ リンクの外観は、フォアグラウンド、バックグラウンド、およびアイコンによって決まります。 RichEditBox で、[ContentLinkForegroundColor](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkForegroundColor) プロパティおよび [ContentLinkBackgroundColor](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkBackgroundColor) プロパティを設定して既定の色を変更できます。 

カーソルを設定することはできません。 カーソルは、コンテンツ リンクの種類に基づいて RichEditbox によって表示されます (ユーザー リンクの場合は[ユーザー](/uwp/api/windows.ui.core.corecursortype) カーソル、場所リンクの場合は[ピン](/uwp/api/windows.ui.core.corecursortype) カーソル)。

### <a name="the-contentlinkinfo-object"></a>ContentLinkInfo オブジェクト

ユーザーがユーザー ピッカーまたは場所ピッカーから選択すると、システムは [ContentLinkInfo](/uwp/api/windows.ui.text.contentlinkinfo) オブジェクトを作成し、それを現在の [RichEditTextRange](/uwp/api/windows.ui.text.richedittextrange) の **ContentLinkInfo** プロパティに追加します。

ContentLinkInfo オブジェクトには、コンテンツ リンクを表示、起動、および管理するための情報が含まれています。

- **DisplayText**– これは、コンテンツ リンクが表示されるときに表示される文字列です。 RichEditBox では、ユーザーはコンテンツ リンクを作成後にそのテキストを編集することができます。これにより、このプロパティの値が変更されます。
- **SecondaryText** – この文字列は、表示されたコンテンツ リンクのヒントに表示されます。
  - ピッカーによって作成された Place コンテンツ リンクでは、使用可能な場合、この文字列に場所の住所が含まれます。
- **Uri** – コンテンツ リンクのサブジェクトの詳細へのリンク。 この Uri は、インストール済みのアプリまたは Web サイトを開くことができます。
- **Id** - これは、RichEditBox コントロールによって作成されたコントロールごとの読み取り専用カウンタです。 これは、削除または編集などの操作中にこの ContentLinkInfo を追跡するために使用します。 ContentLinkInfo が切り取られてコントロールに貼り付けられると、新しい Id が取得されます。Id の値は増加します。
- **LinkContentKind** – コンテンツ リンクの種類を説明する文字列。 組み込みのコンテンツの種類は_場所_と_連絡先_です。 この値では、大文字と小文字を区別します。

#### <a name="link-content-kind"></a>リンク コンテンツの種類

LinkContentKind が重要になることがあります。

- ユーザーが RichEditBox からコンテンツ リンクをコピーし、別の RichEditBox に貼り付けると、両方のコントロールにそのコンテンツの種類の ContentLinkProvider が必要になります。 存在しない場合、リンクはテキストとして貼り付けられます。
- [ContentLinkChanged](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkChanged) イベント ハンドラーで LinkContentKind を使用して、アプリの他の部分で使用する場合のコンテンツ リンクに対する処理を決定することができます。 詳しくは、「例」セクションをご覧ください。
- LinkContentKind は、リンクが呼び出されたときにシステムが Uri を開く方法に影響します。 これについては、次に起動される Uri のディスカッションで説明します。

#### <a name="uri-launching"></a>Uri の起動

Uri プロパティは、ハイパーリンクの NavigateUri プロパティと同様に機能します。 ユーザーがクリックすると、既定のブラウザーで、または Uri 値で指定された特定のプロトコルに登録されているアプリで Uri を起動します。

ここでは、2 種類の組み込みリンク コンテンツの具体的な動作について説明します。

##### <a name="places"></a>Places

Places ピッカーは、Uri ルート https://maps.windows.com/ で ContentLinkInfo を作成します。 このリンクは以下の 3 つの方法で開くことができます。

- LinkContentKind = "Places" である場合、ポップアップで情報カードが開かれます。 ポップアップは、コンテンツ リンク ピッカーのポップアップに似ています。 これは Windows の一部であり、アプリと別のプロセスで実行されます。
- LinkContentKind が "Places" でない場合、これは**マップ** アプリを指定の場所に開こうとします。 たとえば、これは ContentLinkChanged イベント ハンドラーで LinkContentKind を変更した場合に発生する可能性があります。
- マップ アプリで Uri を開くことができない場合、マップは既定のブラウザーで開かれます。 これは通常、ユーザーの _Web サイト用のアプリ_設定で**マップ** アプリを使用して Uri を開くことができない場合に発生します。

##### <a name="people"></a>People

People ピッカーは、**ms-people** プロトコルを使用する Uri で ContentLinkInfo を作成します。

- LinkContentKind = "People" である場合、ポップアップで情報カードが開かれます。 ポップアップは、コンテンツ リンク ピッカーのポップアップに似ています。 これは Windows の一部であり、アプリと別のプロセスで実行されます。
- LinkContentKind が "People" でない場合、**People** アプリが開きます。 たとえば、これは ContentLinkChanged イベント ハンドラーで LinkContentKind を変更した場合に発生する可能性があります。

> [!TIP]
> アプリから他のアプリや Web サイトを開く方法の詳細については、[URI を使ったアプリの起動] の下にあるトピックを参照してください (/windows/uwp/launch-resume/launch-app-with-uri)。

#### <a name="invoked"></a>Invoked

ユーザーがコンテンツ リンクを呼び出すと、URI の起動の既定の動作が発生する前に [ContentLinkInvoked](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkInvoked) イベントが発生します。 このイベントを処理して既定の動作を上書きするか、または取り消すことができます。

この例では、Place コンテンツ リンクの既定の起動動作を上書きする方法を示します。 場所情報カード、マップ アプリ、または既定の Web ブラウザーでマップを開く代わりに、イベントを処理済みとしてマークし、アプリ内の [WebView](/uwp/api/windows.ui.xaml.controls.webview) コントロールでマップを開きます。

```xaml
<RichEditBox x:Name="editor"
             ContentLinkInvoked="editor_ContentLinkInvoked">
    <RichEditBox.ContentLinkProviders>
        <ContentLinkProviderCollection>
            <PlaceContentLinkProvider/>
        </ContentLinkProviderCollection>
    </RichEditBox.ContentLinkProviders>
</RichEditBox>

<WebView x:Name="webView1"/>
```

```csharp
private void editor_ContentLinkInvoked(RichEditBox sender, ContentLinkInvokedEventArgs args)
{
    if (args.ContentLinkInfo.LinkContentKind == "Places")
    {
        args.Handled = true;
        webView1.Navigate(args.ContentLinkInfo.Uri);
    }
}
```

#### <a name="contentlinkchanged"></a>ContentLinkChanged

[ContentLinkChanged](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkChanged) イベントを使用して、コンテンツのリンクが追加、変更、または削除されたときに通知を受信することができます。 これにより、テキストからコンテンツ リンクを抽出し、アプリの他の場所で使用できるようになります。 これについては後で「例」のセクションで説明します。

[ContentLinkChangedEventArgs](/uwp/api/windows.ui.xaml.controls.contentlinkchangedeventargs) のプロパティは以下のとおりです。

- **ChangedKind** - この ContentLinkChangeKind 列挙型は ContentLink 内の操作です。 たとえば、ContentLink が挿入、削除、または編集された場合の操作です。
- **Info** - 操作のターゲットであった ContentLinkInfo。

このイベントは ContentLinkInfo 操作ごとに発生します。 たとえば、ユーザーが一度に複数のコンテンツ リンクをコピーして RichEditBox に貼り付けると、このイベントは追加された各項目で発生します。 または、ユーザーが同時にいくつかのコンテンツ リンクを選択して削除した場合、このイベントは削除された各項目で発生します。

このイベントは、**TextChanging** イベントの前、**TextChanged** イベントの前に RichEditBox で発生します。

#### <a name="enumerate-content-links-in-a-richeditbox"></a>RichEditBox でコンテンツ リンクを列挙します

RichEditTextRange.ContentLink プロパティを使用して、リッチ エディット ドキュメントからコンテンツ リンクを取得することができます。 TextRangeUnit 列挙型には値 ContentLink が含まれており、テキストの範囲を移動するときに使用する単位としてコンテンツ リンクを指定します。

この例では、すべてのコンテンツ リンクを RichEditBox に列挙し、ユーザーをリストに抽出する方法を示します。

```xaml
<StackPanel Width="300">
    <RichEditBox x:Name="Editor" Height="200">
        <RichEditBox.ContentLinkProviders>
            <ContentLinkProviderCollection>
                <ContactContentLinkProvider/>
                <PlaceContentLinkProvider/>
            </ContentLinkProviderCollection>
        </RichEditBox.ContentLinkProviders>
    </RichEditBox>

    <Button Content="Get people" Click="Button_Click"/>

    <ListView x:Name="PeopleList" Header="People">
        <ListView.ItemTemplate>
            <DataTemplate x:DataType="ContentLinkInfo">
                <TextBlock>
                    <ContentLink Info="{x:Bind}" Background="Transparent"/>
                </TextBlock>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
</StackPanel>
```

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    PeopleList.Items.Clear();
    RichEditTextRange textRange = Editor.Document.GetRange(0, 0) as RichEditTextRange;

    do
    {
        // The Expand method expands the Range EndPosition 
        // until it finds a ContentLink range. 
        textRange.Expand(TextRangeUnit.ContentLink);
        if (textRange.ContentLinkInfo != null
            && textRange.ContentLinkInfo.LinkContentKind == "People")
        {
            PeopleList.Items.Add(textRange.ContentLinkInfo);
        }
    } while (textRange.MoveStart(TextRangeUnit.ContentLink, 1) > 0);
}
```

## <a name="contentlink-text-element"></a>ContentLink テキスト要素

TextBlock コントロールまたは RichTextBlock コントロールでコンテンツ リンクを使用するには、[ContentLink](/uwp/api/windows.ui.xaml.documents.contentlink) テキスト要素 (Windows.UI.Xaml.Documents 名前空間から) を使用します。

テキスト ブロック内の ContentLink の標準的なソースは次のとおりです。

- RichTextBlock コントロールから抽出したピッカーによって作成されたコンテンツ リンク。
- コードで作成する場所のコンテンツ リンク。

その他の状況では、通常、ハイパーリンク テキスト要素が適しています。

### <a name="contentlink-appearance"></a>ContentLink の外観

コンテンツ リンクの外観は、フォアグラウンド、バックグラウンド、およびカーソルによって決まります。 テキスト ブロックで、Foreground (from TextElement) プロパティおよび [Background](/uwp/api/windows.ui.xaml.documents.contentlink.background) プロパティを設定して既定の色を変更できます。

既定で、ユーザーがコンテンツ リンクにマウス カーソルを置くと[手](/uwp/api/windows.ui.core.corecursortype) の形のカーソルが表示されます。 RichEditBlock とは異なり、テキスト ブロックのコントロールは、リンクの種類に基づいて自動的にカーソルを変更しません。 [カーソル](/uwp/api/windows.ui.xaml.documents.contentlink.Cursor) プロパティを設定して、リンクの種類またはその他の要因に基づいてカーソルを変更することができます。

TextBlock で使用される ContentLink の例を示します。 ContentLinkInfo はコードで作成され、XAML で作成される ContentLink テキスト要素の情報プロパティに割り当てられます。

```xaml
<StackPanel>
    <TextBlock>
        <Span xml:space="preserve">
            <Run>This valcano erupted in 1980: </Run><ContentLink x:Name="placeContentLink" Cursor="Pin"/>
            <LineBreak/>
        </Span>
    </TextBlock>

    <Button Content="Show" Click="Button_Click"/>
</StackPanel>
```

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    var info = new Windows.UI.Text.ContentLinkInfo();
    info.DisplayText = "Mount St. Helens";
    info.SecondaryText = "Washington State";
    info.LinkContentKind = "Places";
    info.Uri = new Uri("https://maps.windows.com?cp=46.1912~-122.1944");
    placeContentLink.Info = info;
}
```

> [!TIP]
> テキスト コントロールで ContentLink を XAML のその他のテキスト要素と一緒に使用する場合、[スパン](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.span.aspx) コンテナーにコンテンツを配置してスパンに `xml:space="preserve"` 属性を適用すると、ContentLink とその他の要素間に空白を保持します。

## <a name="examples"></a>例

この例では、ユーザーは人物や場所を入力したり、RickTextBlock にコンテンツ リンクを配置したりできます。 ContentLinkChanged イベントを処理して、コンテンツ リンクを抽出し、人物または場所のリストでそれらを最新に保ちます。

リストの項目テンプレートで、ContentLink テキスト要素とともに TextBlock を使用し、コンテンツ リンク情報を表示します。 ListView は項目ごとに独自の背景を提供するため、ContentLink のバックグラウンドは透明に設定されます。

```xaml
<StackPanel Orientation="Horizontal" Grid.Row="1">
    <RichEditBox x:Name="Editor"
                 ContentLinkChanged="Editor_ContentLinkChanged"
                 Margin="20" Width="300" Height="200"
                 VerticalAlignment="Top">
        <RichEditBox.ContentLinkProviders>
            <ContentLinkProviderCollection>
                <ContactContentLinkProvider/>
                <PlaceContentLinkProvider/>
            </ContentLinkProviderCollection>
        </RichEditBox.ContentLinkProviders>
    </RichEditBox>

    <ListView x:Name="PeopleList" Header="People">
        <ListView.ItemTemplate>
            <DataTemplate x:DataType="ContentLinkInfo">
                <TextBlock>
                    <ContentLink Info="{x:Bind}"
                                 Background="Transparent"
                                 Cursor="Person"/>
                </TextBlock>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>

    <ListView x:Name="PlacesList" Header="Places">
        <ListView.ItemTemplate>
            <DataTemplate x:DataType="ContentLinkInfo">
                <TextBlock>
                    <ContentLink Info="{x:Bind}"
                                 Background="Transparent"
                                 Cursor="Pin"/>
                </TextBlock>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
</StackPanel>
```

```csharp
private void Editor_ContentLinkChanged(RichEditBox sender, ContentLinkChangedEventArgs args)
{
    var info = args.ContentLinkInfo;
    var change = args.ChangeKind;
    ListViewBase list = null;

    // Determine whether to update the people or places list.
    if (info.LinkContentKind == "People")
    {
        list = PeopleList;
    }
    else if (info.LinkContentKind == "Places")
    {
        list = PlacesList;
    }

    // Determine whether to add, delete, or edit.
    if (change == ContentLinkChangeKind.Inserted)
    {
        Add();
    }
    else if (args.ChangeKind == ContentLinkChangeKind.Removed)
    {
        Remove();
    }
    else if (change == ContentLinkChangeKind.Edited)
    {
        Remove();
        Add();
    }

    // Add content link info to the list. It's bound to the
    // Info property of a ContentLink in XAML.
    void Add()
    {
        list.Items.Add(info);
    }

    // Use ContentLinkInfo.Id to find the item,
    // then remove it from the list using its index.
    void Remove()
    {
        var items = list.Items.Where(i => ((ContentLinkInfo)i).Id == info.Id);
        var item = items.FirstOrDefault();
        var idx = list.Items.IndexOf(item);

        list.Items.RemoveAt(idx);
    }
}
```