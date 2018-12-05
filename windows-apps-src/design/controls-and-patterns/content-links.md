---
Description: Use content links to embed rich data in your text controls.
title: テキスト コントロールのコンテンツ リンク
label: Content links
template: detail.hbs
ms.date: 03/07/2018
ms.topic: article
keywords: windows 10, UWP
pm-contact: miguelrb
design-contact: ''
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: a984e30bbdc569522b04d328087775aa9e8ce2bc
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8740740"
---
# <a name="content-links-in-text-controls"></a><span data-ttu-id="9cd0d-103">テキスト コントロールのコンテンツ リンク</span><span class="sxs-lookup"><span data-stu-id="9cd0d-103">Content links in text controls</span></span>

<span data-ttu-id="9cd0d-104">コンテンツ リンクを使用すると、テキスト コントロールにリッチ データを埋め込むことができます。これによってユーザーは、アプリのコンテキストから離れることなく、人物や場所に関する詳しい情報を見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-104">Content links provide a way to embed rich data in your text controls, which lets a user find and use more information about a person or place without leaving the context of your app.</span></span>

<span data-ttu-id="9cd0d-105">RichEditBox でユーザーがアンパサンド (@) 記号を使用してエントリにプレフィックスを付けると、そのエントリに一致する人々および/または場所の候補のリストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-105">When the user prefixes an entry with an ampersand (@) symbol in a RichEditBox, they’re shown a list of people and/or place suggestions that matches the entry.</span></span> <span data-ttu-id="9cd0d-106">次に、たとえば、ユーザーが場所を選択すると、その場所の ContentLink がテキストに挿入されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-106">Then, for example, when the user picks a place, a ContentLink for that place is inserted into the text.</span></span> <span data-ttu-id="9cd0d-107">ユーザーが RichEditBox からコンテンツ リンクを呼び出すと、その場所に関する地図と追加情報を示したポップアップが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-107">When the user invokes the content link from the RichEditBox, a flyout is shown with a map and additional info about the place.</span></span>

> <span data-ttu-id="9cd0d-108">**重要な API**: [ContentLink クラス](/uwp/api/windows.ui.xaml.documents.contentlink)、[ContentLinkInfo クラス](/uwp/api/windows.ui.text.contentlinkinfo)、[RichEditTextRange クラス](/uwp/api/windows.ui.text.richedittextrange)</span><span class="sxs-lookup"><span data-stu-id="9cd0d-108">**Important APIs**: [ContentLink class](/uwp/api/windows.ui.xaml.documents.contentlink), [ContentLinkInfo class](/uwp/api/windows.ui.text.contentlinkinfo), [RichEditTextRange class](/uwp/api/windows.ui.text.richedittextrange)</span></span>

> [!NOTE]
> <span data-ttu-id="9cd0d-109">コンテンツ リンクの Api は次の名前空間に拡散: Windows.UI.Xaml.Controls、Windows.UI.Xaml.Documents、および Windows.UI.Text。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-109">The APIs for content links are spread across the following namespaces: Windows.UI.Xaml.Controls, Windows.UI.Xaml.Documents, and Windows.UI.Text.</span></span>



## <a name="content-links-in-rich-edit-vs-text-block-controls"></a><span data-ttu-id="9cd0d-110">リッチ エディット コントロールとテキスト ブロック コントロールでのコンテンツ リンク</span><span class="sxs-lookup"><span data-stu-id="9cd0d-110">Content links in rich edit vs. text block controls</span></span>

<span data-ttu-id="9cd0d-111">コンテンツ リンクを使用する方法には、以下の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-111">There are two distinct ways to use content links:</span></span>

1. <span data-ttu-id="9cd0d-112">[RichEditBox](/uwp/api/windows.ui.xaml.controls.richeditbox) では、ユーザーはピッカーを開いてテキストの先頭に @ 記号を付けて指定し、コンテンツ リンクを追加できます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-112">In a [RichEditBox](/uwp/api/windows.ui.xaml.controls.richeditbox), the user can open a picker to add a content link by prefixing text with an @ symbol.</span></span> <span data-ttu-id="9cd0d-113">コンテンツ リンクは、リッチ テキスト コンテンツの一部として保存されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-113">The content link is stored as part the rich text content.</span></span>
1. <span data-ttu-id="9cd0d-114">[TextBlock](/uwp/api/windows.ui.xaml.controls.textblock) または [RichTextBlock](/uwp/api/windows.ui.xaml.controls.richtextblock) では、コンテンツ リンクは、使用法や動作が[ハイパーリンク](/uwp/api/windows.ui.xaml.documents.hyperlink)とよく似たテキスト要素です。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-114">In a [TextBlock](/uwp/api/windows.ui.xaml.controls.textblock) or [RichTextBlock](/uwp/api/windows.ui.xaml.controls.richtextblock), the content link is a text element with usage and behavior much like a [Hyperlink](/uwp/api/windows.ui.xaml.documents.hyperlink).</span></span>

<span data-ttu-id="9cd0d-115">既定でコンテンツ リンクが RichEditBox と TextBlock でどのように表示されるかを示します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-115">Here's how content links look by default in a RichEditBox and in a TextBlock.</span></span>

![<span data-ttu-id="9cd0d-116">リッチ エディット ボックスでのコンテンツ リンク](images/content-link-default-richedit.png)
![テキスト ブロックでのコンテンツ リンク</span><span class="sxs-lookup"><span data-stu-id="9cd0d-116">content link in rich edit box](images/content-link-default-richedit.png)
![content link in text block</span></span>](images/content-link-default-textblock.png)

<span data-ttu-id="9cd0d-117">使用状況、レンダリング、および動作の相違点については、次のセクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-117">Differences in usage, rendering, and behavior are covered in detail in the following sections.</span></span> <span data-ttu-id="9cd0d-118">次の表は、RichEditBox のコンテンツ リンクとテキスト ブロックの主な相違点を比較した早見表です。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-118">This table gives a quick comparison of the main differences between a content link in a RichEditBox and a text block.</span></span>

| <span data-ttu-id="9cd0d-119">機能</span><span class="sxs-lookup"><span data-stu-id="9cd0d-119">Feature</span></span>   | <span data-ttu-id="9cd0d-120">RichEditBox</span><span class="sxs-lookup"><span data-stu-id="9cd0d-120">RichEditBox</span></span> | <span data-ttu-id="9cd0d-121">テキスト ブロック</span><span class="sxs-lookup"><span data-stu-id="9cd0d-121">text block</span></span> |
| --------- | ----------- | ---------- |
| <span data-ttu-id="9cd0d-122">使用状況</span><span class="sxs-lookup"><span data-stu-id="9cd0d-122">Usage</span></span> | <span data-ttu-id="9cd0d-123">ContentLinkInfo インスタンス</span><span class="sxs-lookup"><span data-stu-id="9cd0d-123">ContentLinkInfo instance</span></span> | <span data-ttu-id="9cd0d-124">ContentLink テキスト要素</span><span class="sxs-lookup"><span data-stu-id="9cd0d-124">ContentLink text element</span></span> |
| <span data-ttu-id="9cd0d-125">Cursor</span><span class="sxs-lookup"><span data-stu-id="9cd0d-125">Cursor</span></span> | <span data-ttu-id="9cd0d-126">コンテンツ リンクの種類によって決まり、変更することはできません</span><span class="sxs-lookup"><span data-stu-id="9cd0d-126">Determined by type of content link, can't be changed</span></span> | <span data-ttu-id="9cd0d-127">Cursor プロパティによって決まります。既定では **null** です</span><span class="sxs-lookup"><span data-stu-id="9cd0d-127">Determined by Cursor property, **null** by default</span></span> |
| <span data-ttu-id="9cd0d-128">ToolTip</span><span class="sxs-lookup"><span data-stu-id="9cd0d-128">ToolTip</span></span> | <span data-ttu-id="9cd0d-129">表示されません</span><span class="sxs-lookup"><span data-stu-id="9cd0d-129">Not rendered</span></span> | <span data-ttu-id="9cd0d-130">セカンダリ テキストを表示します</span><span class="sxs-lookup"><span data-stu-id="9cd0d-130">Shows secondary text</span></span> |

## <a name="enable-content-links-in-a-richeditbox"></a><span data-ttu-id="9cd0d-131">RichEditBox でコンテンツ リンクを有効にします</span><span class="sxs-lookup"><span data-stu-id="9cd0d-131">Enable content links in a RichEditBox</span></span>

<span data-ttu-id="9cd0d-132">コンテンツ リンクの最も一般的な用途は、ユーザーがテキスト内の人物または場所の名前の先頭にアンパサンド (@) 記号を付けることによって、情報をすばやく追加できるようにすることです。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-132">The most common use of a content link is to let a user quickly add information by prefixing a person or place name with an ampersand (@) symbol in their text.</span></span> <span data-ttu-id="9cd0d-133">[RichEditBox](/uwp/api/windows.ui.xaml.controls.richeditbox) で有効になっている場合、ピッカーが開き、ユーザーは有効にした内容に応じて、連絡先リストまたは近くの場所から人物を挿入できます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-133">When enabled in a [RichEditBox](/uwp/api/windows.ui.xaml.controls.richeditbox), this opens a picker and lets the user insert a person from their contact list, or a nearby place, depending on what you’ve enabled.</span></span>

<span data-ttu-id="9cd0d-134">コンテンツ リンクは、リッチ テキスト コンテンツで保存でき、抽出してアプリの他の部分で使用することができます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-134">The content link can be saved with the rich text content, and you can extract it to use in other parts of your app.</span></span> <span data-ttu-id="9cd0d-135">たとえば、メール アプリで個人情報を抽出し、それを使用して [終了] ボックスにメール アドレスを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-135">For example, in an email app, you might extract the person info and use it to populate the To box with an email address.</span></span>

> [!NOTE]
> <span data-ttu-id="9cd0d-136">コンテンツ リンク ピッカーは、Windows の一部であるアプリであるため、アプリと別のプロセスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-136">The content link picker is an app that’s part of Windows, so it runs in a separate process from your app.</span></span>

### <a name="content-link-providers"></a><span data-ttu-id="9cd0d-137">コンテンツ リンク プロバイダー</span><span class="sxs-lookup"><span data-stu-id="9cd0d-137">Content link providers</span></span>

<span data-ttu-id="9cd0d-138">RichEditBox でコンテンツ リンクを有効にするには、1 つまたは複数のコンテンツ リンク プロバイダーを [RichEditBox.ContentLinkProviders](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkProviders) コレクションに追加します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-138">You enable content links in a RichEditBox by adding one or more content link providers to the [RichEditBox.ContentLinkProviders](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkProviders) collection.</span></span> <span data-ttu-id="9cd0d-139">XAML フレームワークに組み込まれているコンテンツ リンク プロバイダーが 2 つあります。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-139">There are 2 content link providers built into the XAML framework.</span></span>

- <span data-ttu-id="9cd0d-140">[ContactContentLinkProvider](/uwp/api/windows.ui.xaml.documents.contactcontentlinkprovider) – **People**アプリを使用して連絡先を検索します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-140">[ContactContentLinkProvider](/uwp/api/windows.ui.xaml.documents.contactcontentlinkprovider) – looks up contacts using the **People** app.</span></span>
- <span data-ttu-id="9cd0d-141">[PlaceContentLinkProvider](/uwp/api/windows.ui.xaml.documents.placecontentlinkprovider) – **Maps**アプリを使用して場所を検索します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-141">[PlaceContentLinkProvider](/uwp/api/windows.ui.xaml.documents.placecontentlinkprovider) – looks up places using the **Maps** app.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="9cd0d-142">RichEditBox.ContentLinkProviders プロパティの既定値は **null** であり、空のコレクションではありません。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-142">The default value for the RichEditBox.ContentLinkProviders property is **null**, not an empty collection.</span></span> <span data-ttu-id="9cd0d-143">コンテンツ リンク プロバイダーを追加する前に、[ContentLinkProviderCollection](/uwp/api/windows.ui.xaml.documents.contentlinkprovidercollection) を明示的に作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-143">You need to explicity create the [ContentLinkProviderCollection](/uwp/api/windows.ui.xaml.documents.contentlinkprovidercollection) before you add content link providers.</span></span>

<span data-ttu-id="9cd0d-144">XAML でコンテンツ リンク プロバイダーを追加する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-144">Here’s how to add the content link providers in XAML.</span></span>

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

<span data-ttu-id="9cd0d-145">スタイルにコンテンツ リンク プロバイダーを追加し、次のように複数の RichEditBoxes に適用することもできます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-145">You can also add content link providers in a Style and apply it to multiple RichEditBoxes like this.</span></span>

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

<span data-ttu-id="9cd0d-146">コードでコンテンツ リンク プロバイダーを追加する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-146">Here's how to add content link providers in code.</span></span>

```csharp
RichEditBox editor = new RichEditBox();
editor.ContentLinkProviders = new ContentLinkProviderCollection
{
    new ContactContentLinkProvider(),
    new PlaceContentLinkProvider()
};
```

### <a name="content-link-colors"></a><span data-ttu-id="9cd0d-147">コンテンツ リンクの色</span><span class="sxs-lookup"><span data-stu-id="9cd0d-147">Content link colors</span></span>

<span data-ttu-id="9cd0d-148">コンテンツ リンクの外観は、フォアグラウンド、バックグラウンド、およびアイコンによって決まります。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-148">The appearance of a content link is determined by its foreground, background, and icon.</span></span> <span data-ttu-id="9cd0d-149">RichEditBox で、[ContentLinkForegroundColor](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkForegroundColor) プロパティおよび [ContentLinkBackgroundColor](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkBackgroundColor) プロパティを設定して既定の色を変更できます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-149">In a RichEditBox, you can set the [ContentLinkForegroundColor](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkForegroundColor) and [ContentLinkBackgroundColor](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkBackgroundColor) properties to change the default colors.</span></span> 

<span data-ttu-id="9cd0d-150">カーソルを設定することはできません。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-150">You can't set the cursor.</span></span> <span data-ttu-id="9cd0d-151">カーソルは、コンテンツ リンクの種類に基づいて RichEditbox によって表示されます (ユーザー リンクの場合は[ユーザー](/uwp/api/windows.ui.core.corecursortype) カーソル、場所リンクの場合は[ピン](/uwp/api/windows.ui.core.corecursortype) カーソル)。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-151">The cursor is rendered by the RichEditbox based on the type of content link - a [Person](/uwp/api/windows.ui.core.corecursortype) cursor for a person link, or a [Pin](/uwp/api/windows.ui.core.corecursortype) cursor for a place link.</span></span>

### <a name="the-contentlinkinfo-object"></a><span data-ttu-id="9cd0d-152">ContentLinkInfo オブジェクト</span><span class="sxs-lookup"><span data-stu-id="9cd0d-152">The ContentLinkInfo object</span></span>

<span data-ttu-id="9cd0d-153">ユーザーがユーザー ピッカーまたは場所ピッカーから選択すると、システムは [ContentLinkInfo](/uwp/api/windows.ui.text.contentlinkinfo) オブジェクトを作成し、それを現在の [RichEditTextRange](/uwp/api/windows.ui.text.richedittextrange) の **ContentLinkInfo** プロパティに追加します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-153">When the user makes a selection from the people or places picker, the system creates a [ContentLinkInfo](/uwp/api/windows.ui.text.contentlinkinfo) object and adds it to the **ContentLinkInfo** property of the current [RichEditTextRange](/uwp/api/windows.ui.text.richedittextrange).</span></span>

<span data-ttu-id="9cd0d-154">ContentLinkInfo オブジェクトには、コンテンツ リンクを表示、起動、および管理するための情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-154">The ContentLinkInfo object contains the information used to display, invoke, and manage the content link.</span></span>

- <span data-ttu-id="9cd0d-155">**DisplayText**– これは、コンテンツ リンクが表示されるときに表示される文字列です。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-155">**DisplayText** – This is the string that is shown when the content link is rendered.</span></span> <span data-ttu-id="9cd0d-156">RichEditBox では、ユーザーはコンテンツ リンクを作成後にそのテキストを編集することができます。これにより、このプロパティの値が変更されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-156">In a RichEditBox, the user can edit the text of a content link after it’s created, which alters the value of this property.</span></span>
- <span data-ttu-id="9cd0d-157">**SecondaryText** – この文字列は、表示されたコンテンツ リンクのヒントに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-157">**SecondaryText** – This string is shown in the ToolTip of a rendered content link.</span></span>
  - <span data-ttu-id="9cd0d-158">ピッカーによって作成された Place コンテンツ リンクでは、使用可能な場合、この文字列に場所の住所が含まれます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-158">In a Place content link created by the picker, it contains the address of the location, if available.</span></span>
- <span data-ttu-id="9cd0d-159">**Uri** – コンテンツ リンクのサブジェクトの詳細へのリンク。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-159">**Uri** – The link to more information about the subject of the content link.</span></span> <span data-ttu-id="9cd0d-160">この Uri は、インストール済みのアプリまたは Web サイトを開くことができます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-160">This Uri can open an installed app or a website.</span></span>
- <span data-ttu-id="9cd0d-161">**Id** - これは、RichEditBox コントロールによって作成されたコントロールごとの読み取り専用カウンタです。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-161">**Id** - This is a read-only, per control, counter created by the RichEditBox control.</span></span> <span data-ttu-id="9cd0d-162">これは、削除または編集などの操作中にこの ContentLinkInfo を追跡するために使用します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-162">It’s used to track this ContentLinkInfo during actions such as delete or edit.</span></span> <span data-ttu-id="9cd0d-163">ContentLinkInfo が切り取られてコントロールに貼り付けられると、新しい Id が取得されます。Id の値は増加します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-163">If the ContentLinkInfo is cut and paste back into the control, it will get a new Id. Id values are incremental.</span></span>
- <span data-ttu-id="9cd0d-164">**LinkContentKind** – コンテンツ リンクの種類を説明する文字列。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-164">**LinkContentKind** – A string that describes the type of the content link.</span></span> <span data-ttu-id="9cd0d-165">組み込みのコンテンツの種類は_場所_と_連絡先_です。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-165">The built-in content types are _Places_ and _Contacts_.</span></span> <span data-ttu-id="9cd0d-166">この値では、大文字と小文字を区別します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-166">The value is case sensitive.</span></span>

#### <a name="link-content-kind"></a><span data-ttu-id="9cd0d-167">リンク コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="9cd0d-167">Link content kind</span></span>

<span data-ttu-id="9cd0d-168">LinkContentKind が重要になることがあります。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-168">There are several situations where the LinkContentKind is important.</span></span>

- <span data-ttu-id="9cd0d-169">ユーザーが RichEditBox からコンテンツ リンクをコピーし、別の RichEditBox に貼り付けると、両方のコントロールにそのコンテンツの種類の ContentLinkProvider が必要になります。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-169">When a user copies a content link from a RichEditBox and pastes it into another RichEditBox, both controls must have a ContentLinkProvider for that content type.</span></span> <span data-ttu-id="9cd0d-170">存在しない場合、リンクはテキストとして貼り付けられます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-170">If not, the link is pasted as text.</span></span>
- <span data-ttu-id="9cd0d-171">[ContentLinkChanged](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkChanged) イベント ハンドラーで LinkContentKind を使用して、アプリの他の部分で使用する場合のコンテンツ リンクに対する処理を決定することができます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-171">You can use LinkContentKind in a [ContentLinkChanged](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkChanged) event handler to determine what to do with a content link when you use it in other parts of your app.</span></span> <span data-ttu-id="9cd0d-172">詳しくは、「例」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-172">See the Example section for more info.</span></span>
- <span data-ttu-id="9cd0d-173">LinkContentKind は、リンクが呼び出されたときにシステムが Uri を開く方法に影響します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-173">The LinkContentKind influences how the system opens the Uri when the link is invoked.</span></span> <span data-ttu-id="9cd0d-174">これについては、次に起動される Uri のディスカッションで説明します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-174">We’ll see this in the discussion of Uri launching next.</span></span>

#### <a name="uri-launching"></a><span data-ttu-id="9cd0d-175">Uri の起動</span><span class="sxs-lookup"><span data-stu-id="9cd0d-175">Uri launching</span></span>

<span data-ttu-id="9cd0d-176">Uri プロパティは、ハイパーリンクの NavigateUri プロパティと同様に機能します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-176">The Uri property works much like the NavigateUri property of a Hyperlink.</span></span> <span data-ttu-id="9cd0d-177">ユーザーがクリックすると、既定のブラウザーで、または Uri 値で指定された特定のプロトコルに登録されているアプリで Uri を起動します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-177">When a user clicks it, it launches the Uri in the default browser, or in the app that's registered for the particular protocol specified in the Uri value.</span></span>

<span data-ttu-id="9cd0d-178">ここでは、2 種類の組み込みリンク コンテンツの具体的な動作について説明します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-178">The specific behavior for the 2 built in kinds of link content are described here.</span></span>

##### <a name="places"></a><span data-ttu-id="9cd0d-179">Places</span><span class="sxs-lookup"><span data-stu-id="9cd0d-179">Places</span></span>

<span data-ttu-id="9cd0d-180">Places ピッカーは、Uri ルート https://maps.windows.com/ で ContentLinkInfo を作成します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-180">The Places picker creates a ContentLinkInfo with a Uri root of https://maps.windows.com/.</span></span> <span data-ttu-id="9cd0d-181">このリンクは以下の 3 つの方法で開くことができます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-181">This link can be opened in 3 ways:</span></span>

- <span data-ttu-id="9cd0d-182">LinkContentKind = "Places" である場合、ポップアップで情報カードが開かれます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-182">If LinkContentKind = "Places", it opens an info card in a flyout.</span></span> <span data-ttu-id="9cd0d-183">ポップアップは、コンテンツ リンク ピッカーのポップアップに似ています。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-183">The flyout is similar to the content link picker flyout.</span></span> <span data-ttu-id="9cd0d-184">これは Windows の一部であり、アプリと別のプロセスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-184">It’s part of Windows, and runs in a separate process from your app.</span></span>
- <span data-ttu-id="9cd0d-185">LinkContentKind が "Places" でない場合、これは**マップ** アプリを指定の場所に開こうとします。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-185">If LinkContentKind is not "Places", it attempts to open the **Maps** app to the specified location.</span></span> <span data-ttu-id="9cd0d-186">たとえば、これは ContentLinkChanged イベント ハンドラーで LinkContentKind を変更した場合に発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-186">For example, this can happen if you’ve modified the LinkContentKind in the ContentLinkChanged event handler.</span></span>
- <span data-ttu-id="9cd0d-187">マップ アプリで Uri を開くことができない場合、マップは既定のブラウザーで開かれます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-187">If the Uri can’t be opened in the Maps app, the map is opened in the default browser.</span></span> <span data-ttu-id="9cd0d-188">これは通常、ユーザーの _Web サイト用のアプリ_設定で**マップ** アプリを使用して Uri を開くことができない場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-188">This typically happens when the user's _Apps for websites_ settings don’t allow opening the Uri with the **Maps** app.</span></span>

##### <a name="people"></a><span data-ttu-id="9cd0d-189">People</span><span class="sxs-lookup"><span data-stu-id="9cd0d-189">People</span></span>

<span data-ttu-id="9cd0d-190">People ピッカーは、**ms-people** プロトコルを使用する Uri で ContentLinkInfo を作成します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-190">The People picker creates a ContentLinkInfo with a Uri that uses the **ms-people** protocol.</span></span>

- <span data-ttu-id="9cd0d-191">LinkContentKind = "People" である場合、ポップアップで情報カードが開かれます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-191">If LinkContentKind = "People", it opens an info card in a flyout.</span></span> <span data-ttu-id="9cd0d-192">ポップアップは、コンテンツ リンク ピッカーのポップアップに似ています。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-192">The flyout is similar to the content link picker flyout.</span></span> <span data-ttu-id="9cd0d-193">これは Windows の一部であり、アプリと別のプロセスで実行されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-193">It’s part of Windows, and runs in a separate process from your app.</span></span>
- <span data-ttu-id="9cd0d-194">LinkContentKind が "People" でない場合、**People** アプリが開きます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-194">If LinkContentKind is not "People", it opens the **People** app.</span></span> <span data-ttu-id="9cd0d-195">たとえば、これは ContentLinkChanged イベント ハンドラーで LinkContentKind を変更した場合に発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-195">For example, this can happen if you’ve modified the LinkContentKind in the ContentLinkChanged event handler.</span></span>

> [!TIP]
> <span data-ttu-id="9cd0d-196">アプリから他のアプリや web サイトを開くについて詳しくは、 [Uri を使ったアプリの起動](/windows/uwp/launch-resume/launch-app-with-uri)の下のトピックを参照してください。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-196">For more info about opening other apps and websites from your app, see the topics under [Launch an app with a Uri](/windows/uwp/launch-resume/launch-app-with-uri).</span></span>

#### <a name="invoked"></a><span data-ttu-id="9cd0d-197">Invoked</span><span class="sxs-lookup"><span data-stu-id="9cd0d-197">Invoked</span></span>

<span data-ttu-id="9cd0d-198">ユーザーがコンテンツ リンクを呼び出すと、URI の起動の既定の動作が発生する前に [ContentLinkInvoked](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkInvoked) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-198">When the user invokes a content link, the [ContentLinkInvoked](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkInvoked) event is raised before the default behavior of launching the Uri happens.</span></span> <span data-ttu-id="9cd0d-199">このイベントを処理して既定の動作を上書きするか、または取り消すことができます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-199">You can handle this event to override or cancel the default behavior.</span></span>

<span data-ttu-id="9cd0d-200">この例では、Place コンテンツ リンクの既定の起動動作を上書きする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-200">This example shows how you can override the default launching behavior for a Place content link.</span></span> <span data-ttu-id="9cd0d-201">場所情報カード、マップ アプリ、または既定の Web ブラウザーでマップを開く代わりに、イベントを処理済みとしてマークし、アプリ内の [WebView](/uwp/api/windows.ui.xaml.controls.webview) コントロールでマップを開きます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-201">Instead of opening the map in a Place info card, Maps app, or default web browser, you mark the event as Handled and open the map in an in-app [WebView](/uwp/api/windows.ui.xaml.controls.webview) control.</span></span>

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

#### <a name="contentlinkchanged"></a><span data-ttu-id="9cd0d-202">ContentLinkChanged</span><span class="sxs-lookup"><span data-stu-id="9cd0d-202">ContentLinkChanged</span></span>

<span data-ttu-id="9cd0d-203">[ContentLinkChanged](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkChanged) イベントを使用して、コンテンツのリンクが追加、変更、または削除されたときに通知を受信することができます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-203">You can use the [ContentLinkChanged](/uwp/api/windows.ui.xaml.controls.richeditbox.ContentLinkChanged) event to be notified when a content link is added, modified, or removed.</span></span> <span data-ttu-id="9cd0d-204">これにより、テキストからコンテンツ リンクを抽出し、アプリの他の場所で使用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-204">This lets you extract the content link from the text and use it in other places in your app.</span></span> <span data-ttu-id="9cd0d-205">これについては後で「例」のセクションで説明します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-205">This is shown later in the Examples section.</span></span>

<span data-ttu-id="9cd0d-206">[ContentLinkChangedEventArgs](/uwp/api/windows.ui.xaml.controls.contentlinkchangedeventargs) のプロパティは以下のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-206">The properties of the [ContentLinkChangedEventArgs](/uwp/api/windows.ui.xaml.controls.contentlinkchangedeventargs) are:</span></span>

- <span data-ttu-id="9cd0d-207">**ChangedKind** - この ContentLinkChangeKind 列挙型は ContentLink 内の操作です。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-207">**ChangedKind** - This ContentLinkChangeKind enum is the action within the ContentLink.</span></span> <span data-ttu-id="9cd0d-208">たとえば、ContentLink が挿入、削除、または編集された場合の操作です。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-208">For example, if the ContentLink is inserted, removed, or edited.</span></span>
- <span data-ttu-id="9cd0d-209">**Info** - 操作のターゲットであった ContentLinkInfo。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-209">**Info** - The ContentLinkInfo that was the target of the action.</span></span>

<span data-ttu-id="9cd0d-210">このイベントは ContentLinkInfo 操作ごとに発生します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-210">This event is raised for each ContentLinkInfo action.</span></span> <span data-ttu-id="9cd0d-211">たとえば、ユーザーが一度に複数のコンテンツ リンクをコピーして RichEditBox に貼り付けると、このイベントは追加された各項目で発生します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-211">For example, if the user copies and pastes several content links into the RichEditBox at once, this event is raised for each added item.</span></span> <span data-ttu-id="9cd0d-212">または、ユーザーが同時にいくつかのコンテンツ リンクを選択して削除した場合、このイベントは削除された各項目で発生します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-212">Or if the user selects and deletes several content links at the same time, this event is raised for each deleted item.</span></span>

<span data-ttu-id="9cd0d-213">このイベントは、**TextChanging** イベントの前、**TextChanged** イベントの前に RichEditBox で発生します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-213">This event is raised on the RichEditBox after the **TextChanging** event and before the **TextChanged** event.</span></span>

#### <a name="enumerate-content-links-in-a-richeditbox"></a><span data-ttu-id="9cd0d-214">RichEditBox でコンテンツ リンクを列挙します</span><span class="sxs-lookup"><span data-stu-id="9cd0d-214">Enumerate content links in a RichEditBox</span></span>

<span data-ttu-id="9cd0d-215">RichEditTextRange.ContentLink プロパティを使用して、リッチ エディット ドキュメントからコンテンツ リンクを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-215">You can use the RichEditTextRange.ContentLink property to get a content link from a rich edit document.</span></span> <span data-ttu-id="9cd0d-216">TextRangeUnit 列挙型には値 ContentLink が含まれており、テキストの範囲を移動するときに使用する単位としてコンテンツ リンクを指定します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-216">The TextRangeUnit enumeration has the value ContentLink to specify the content link as a unit to use when navigating a text range.</span></span>

<span data-ttu-id="9cd0d-217">この例では、すべてのコンテンツ リンクを RichEditBox に列挙し、ユーザーをリストに抽出する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-217">This example shows how you can enumerate all the content links in a RichEditBox, and extract the people into a list.</span></span>

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

## <a name="contentlink-text-element"></a><span data-ttu-id="9cd0d-218">ContentLink テキスト要素</span><span class="sxs-lookup"><span data-stu-id="9cd0d-218">ContentLink text element</span></span>

<span data-ttu-id="9cd0d-219">TextBlock コントロールまたは RichTextBlock コントロールでコンテンツ リンクを使用するには、[ContentLink](/uwp/api/windows.ui.xaml.documents.contentlink) テキスト要素 (Windows.UI.Xaml.Documents 名前空間から) を使用します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-219">To use a content link in a TextBlock or RichTextBlock control, you use the [ContentLink](/uwp/api/windows.ui.xaml.documents.contentlink) text element (from the Windows.UI.Xaml.Documents namespace).</span></span>

<span data-ttu-id="9cd0d-220">テキスト ブロック内の ContentLink の標準的なソースは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-220">Typical sources for a ContentLink in a text block are:</span></span>

- <span data-ttu-id="9cd0d-221">RichTextBlock コントロールから抽出したピッカーによって作成されたコンテンツ リンク。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-221">A content link created by a picker that you extracted from a RichTextBlock control.</span></span>
- <span data-ttu-id="9cd0d-222">コードで作成する場所のコンテンツ リンク。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-222">A content link for a place that you create in your code.</span></span>

<span data-ttu-id="9cd0d-223">その他の状況では、通常、ハイパーリンク テキスト要素が適しています。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-223">For other situations, a Hyperlink text element is usually appropriate.</span></span>

### <a name="contentlink-appearance"></a><span data-ttu-id="9cd0d-224">ContentLink の外観</span><span class="sxs-lookup"><span data-stu-id="9cd0d-224">ContentLink appearance</span></span>

<span data-ttu-id="9cd0d-225">コンテンツ リンクの外観は、フォアグラウンド、バックグラウンド、およびカーソルによって決まります。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-225">The appearance of a content link is determined by its foreground, background, and cursor.</span></span> <span data-ttu-id="9cd0d-226">テキスト ブロックで、Foreground (from TextElement) プロパティおよび [Background](/uwp/api/windows.ui.xaml.documents.contentlink.background) プロパティを設定して既定の色を変更できます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-226">In a text block, you can set the Foreground (from TextElement) and [Background](/uwp/api/windows.ui.xaml.documents.contentlink.background) properties to change the default colors.</span></span>

<span data-ttu-id="9cd0d-227">既定で、ユーザーがコンテンツ リンクにマウス カーソルを置くと[手](/uwp/api/windows.ui.core.corecursortype) の形のカーソルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-227">By default, the [Hand](/uwp/api/windows.ui.core.corecursortype) cursor is shown when the user hovers over the content link.</span></span> <span data-ttu-id="9cd0d-228">RichEditBlock とは異なり、テキスト ブロックのコントロールは、リンクの種類に基づいて自動的にカーソルを変更しません。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-228">Unlike RichEditBlock, text block controls don't change the cursor automatically based on the link type.</span></span> <span data-ttu-id="9cd0d-229">[カーソル](/uwp/api/windows.ui.xaml.documents.contentlink.Cursor) プロパティを設定して、リンクの種類またはその他の要因に基づいてカーソルを変更することができます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-229">You can set the [Cursor](/uwp/api/windows.ui.xaml.documents.contentlink.Cursor) property to change the cursor based on link type or other factors.</span></span>

<span data-ttu-id="9cd0d-230">TextBlock で使用される ContentLink の例を示します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-230">Here's an example of a ContentLink used in a TextBlock.</span></span> <span data-ttu-id="9cd0d-231">ContentLinkInfo はコードで作成され、XAML で作成される ContentLink テキスト要素の情報プロパティに割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-231">The ContentLinkInfo is created in code and assigned to the Info property of the ContentLink text element that's created in XAML.</span></span>

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
> <span data-ttu-id="9cd0d-232">テキスト コントロールで ContentLink を XAML のその他のテキスト要素と一緒に使用する場合、[スパン](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.span.aspx) コンテナーにコンテンツを配置してスパンに `xml:space="preserve"` 属性を適用すると、ContentLink とその他の要素間に空白を保持します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-232">When you use a ContentLink in a text control with other text elements in XAML, place the content in a [Span](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.documents.span.aspx) container and apply the `xml:space="preserve"` attribute to the Span to keep the white space between the ContentLink and other elements.</span></span>

## <a name="examples"></a><span data-ttu-id="9cd0d-233">例</span><span class="sxs-lookup"><span data-stu-id="9cd0d-233">Examples</span></span>

<span data-ttu-id="9cd0d-234">この例では、ユーザーは人物や場所を入力したり、RickTextBlock にコンテンツ リンクを配置したりできます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-234">In this example, a user can enter a person or place content link into a RickTextBlock.</span></span> <span data-ttu-id="9cd0d-235">ContentLinkChanged イベントを処理して、コンテンツ リンクを抽出し、人物または場所のリストでそれらを最新に保ちます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-235">You handle the ContentLinkChanged event to extract the content links and keep them up-to-date in either a people list or places list.</span></span>

<span data-ttu-id="9cd0d-236">リストの項目テンプレートで、ContentLink テキスト要素とともに TextBlock を使用し、コンテンツ リンク情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-236">In the item templates for the lists, you use a TextBlock with a ContentLink text element to show the content link info.</span></span> <span data-ttu-id="9cd0d-237">ListView は項目ごとに独自の背景を提供するため、ContentLink のバックグラウンドは透明に設定されます。</span><span class="sxs-lookup"><span data-stu-id="9cd0d-237">The ListView provides its own background for each item, so the ContentLink background is set to Transparent.</span></span>

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
