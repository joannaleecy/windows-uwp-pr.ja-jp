---
author: TylerMSFT
title: "URI のアクティブ化の処理"
description: "URI (Uniform Resource Identifier) スキーム名の既定のハンドラーとしてアプリを登録する方法について説明します。"
ms.assetid: 92D06F3E-C8F3-42E0-A476-7E94FD14B2BE
ms.author: twhitney
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 40c70770028853d5912ef63f84259245252ce881
ms.sourcegitcommit: 7f03e200ef34f7f24b6f8b6489ecb44aa2b870bc
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/01/2017
---
# <a name="handle-uri-activation"></a><span data-ttu-id="7a6bf-104">URI のアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="7a6bf-104">Handle URI activation</span></span>


<span data-ttu-id="7a6bf-105">\[Windows 10 の UWP アプリ向けに更新。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-105">\[ Updated for UWP apps on Windows 10.</span></span> <span data-ttu-id="7a6bf-106">Windows 8.x の記事については、「[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)」をご覧ください\]</span><span class="sxs-lookup"><span data-stu-id="7a6bf-106">For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]</span></span>


**<span data-ttu-id="7a6bf-107">重要な API</span><span class="sxs-lookup"><span data-stu-id="7a6bf-107">Important APIs</span></span>**

-   [**<span data-ttu-id="7a6bf-108">Windows.ApplicationModel.Activation.ProtocolActivatedEventArgs</span><span class="sxs-lookup"><span data-stu-id="7a6bf-108">Windows.ApplicationModel.Activation.ProtocolActivatedEventArgs</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224742)
-   [**<span data-ttu-id="7a6bf-109">Windows.UI.Xaml.Application.OnActivated</span><span class="sxs-lookup"><span data-stu-id="7a6bf-109">Windows.UI.Xaml.Application.OnActivated</span></span>**](https://msdn.microsoft.com/library/windows/apps/br242330)

<span data-ttu-id="7a6bf-110">URI (Uniform Resource Identifier) スキーム名の既定のハンドラーとしてアプリを登録する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-110">Learn how to register an app to become the default handler for a Uniform Resource Identifier (URI) scheme name.</span></span> <span data-ttu-id="7a6bf-111">Windows デスクトップ アプリとユニバーサル Windows プラットフォーム (UWP) アプリの両方を、URI スキーム名の既定のハンドラーとして登録できます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-111">Both Windows desktop apps and Universal Windows Platform (UWP) apps can register to be a default handler for a URI scheme name.</span></span> <span data-ttu-id="7a6bf-112">アプリを URI スキーム名の既定のハンドラーとして選ぶと、アプリはその種類の URI を起動するたびにアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-112">If the user chooses your app as the default handler for a URI scheme name, your app will be activated every time that type of URI is launched.</span></span>

<span data-ttu-id="7a6bf-113">URI スキーム名に登録するのは、その種類の URI スキームのすべての URI 起動を処理する場合のみにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-113">We recommend that you only register for a URI scheme name if you expect to handle all URI launches for that type of URI scheme.</span></span> <span data-ttu-id="7a6bf-114">URI スキーム名に登録する場合は、その URI スキームのためにアプリをアクティブ化した際に期待される機能をエンド ユーザーに提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-114">If you do choose to register for a URI scheme name, you must provide the end user with the functionality that is expected when your app is activated for that URI scheme.</span></span> <span data-ttu-id="7a6bf-115">たとえば、mailto: URI スキーム名に登録したアプリでは、新しいメールを開いて、ユーザーが新しいメールを書くことができるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-115">For example, an app that registers for the mailto: URI scheme name should open to a new e-mail message so that the user can compose a new e-mail.</span></span> <span data-ttu-id="7a6bf-116">URI の関連付けについて詳しくは、「[ファイルの種類と URI のガイドラインとチェック リスト](https://msdn.microsoft.com/library/windows/apps/hh700321)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-116">For more info on URI associations, see [Guidelines and checklist for file types and URIs](https://msdn.microsoft.com/library/windows/apps/hh700321).</span></span>

<span data-ttu-id="7a6bf-117">以下の手順では、カスタムの URI スキーム名 alsdk:// を登録する方法と、ユーザーによって alsdk:// URI が起動されたときにアプリをアクティブ化する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-117">These steps show how to register for a custom URI scheme name, alsdk://, and how to activate your app when the user launches a alsdk:// URI.</span></span>

> <span data-ttu-id="7a6bf-118">**注**  UWP アプリでは、組み込みのアプリとオペレーティング システムで使うために、特定の URI とファイル拡張子が予約されています。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-118">**Note**  In UWP apps, certain URIs and file extensions are reserved for use by built-in apps and the operating system.</span></span> <span data-ttu-id="7a6bf-119">予約されている URI またはファイル拡張子にアプリを登録しようとしても無視されます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-119">Attempts to register your app with a reserved URI or file extension will be ignored.</span></span> <span data-ttu-id="7a6bf-120">予約または禁止されいるため、UWP アプリを登録できない URI スキームの一覧 (アルファベット順) については、「[予約済みの URI スキーム名とファイルの種類](reserved-uri-scheme-names.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-120">See [Reserved URI scheme names and file types](reserved-uri-scheme-names.md) for an alphabetic list of Uri schemes that you can't register for your UWP apps because they are either reserved or forbidden.</span></span>

## <a name="step-1-specify-the-extension-point-in-the-package-manifest"></a><span data-ttu-id="7a6bf-121">ステップ 1: パッケージ マニフェストに拡張点を指定する</span><span class="sxs-lookup"><span data-stu-id="7a6bf-121">Step 1: Specify the extension point in the package manifest</span></span>


<span data-ttu-id="7a6bf-122">アプリは、パッケージ マニフェストに一覧表示される URI スキーム名のアクティブ化イベントだけを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-122">The app receives activation events only for the URI scheme names listed in the package manifest.</span></span> <span data-ttu-id="7a6bf-123">アプリが `alsdk` URI スキーム名を処理することを示す方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-123">Here's how you indicate that your app handles the `alsdk`URI scheme name.</span></span>

1.  <span data-ttu-id="7a6bf-124">**ソリューション エクスプローラー**で、package.appxmanifest をダブルクリックしてマニフェスト デザイナーを開きます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-124">In the **Solution Explorer**, double-click package.appxmanifest to open the manifest designer.</span></span> <span data-ttu-id="7a6bf-125">**[宣言]** タブを選び、**[使用可能な宣言]** ドロップダウンから **[プロトコル]** を選んで **[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-125">Select the **Declarations** tab and in the **Available Declarations** drop-down, select **Protocol** and then click **Add**.</span></span>

    <span data-ttu-id="7a6bf-126">プロトコルのマニフェスト デザイナーで指定することができる各フィールドについて、以下で簡単に説明します (詳しくは、「[**AppX パッケージ マニフェスト**](https://msdn.microsoft.com/library/windows/apps/dn934791)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-126">Here is a brief description of each of the fields that you may fill in the manifest designer for the Protocol (see [**AppX Package Manifest**](https://msdn.microsoft.com/library/windows/apps/dn934791) for details):</span></span>

| <span data-ttu-id="7a6bf-127">フィールド</span><span class="sxs-lookup"><span data-stu-id="7a6bf-127">Field</span></span> | <span data-ttu-id="7a6bf-128">説明</span><span class="sxs-lookup"><span data-stu-id="7a6bf-128">Description</span></span> |
|-------|-------------|
| **<span data-ttu-id="7a6bf-129">ロゴ</span><span class="sxs-lookup"><span data-stu-id="7a6bf-129">Logo</span></span>** | <span data-ttu-id="7a6bf-130">**コントロール パネル**の [[既定のプログラムを設定する]](https://msdn.microsoft.com/library/windows/desktop/cc144154) で URI スキーム名を識別するために使われるロゴを指定します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-130">Specify the logo that is used to identify the URI scheme name in the [Set Default Programs](https://msdn.microsoft.com/library/windows/desktop/cc144154) on the **Control Panel**.</span></span> <span data-ttu-id="7a6bf-131">ロゴを指定しない場合は、アプリの小さいロゴが使われます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-131">If no Logo is specified, the small logo for the app is used.</span></span> |
| **<span data-ttu-id="7a6bf-132">表示名</span><span class="sxs-lookup"><span data-stu-id="7a6bf-132">Display Name</span></span>** | <span data-ttu-id="7a6bf-133">**コントロール パネル**の [[既定のプログラムを設定する]](https://msdn.microsoft.com/library/windows/desktop/cc144154) で URI スキーム名を識別するための表示名を指定します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-133">Specify the display name to identify the URI scheme name in the [Set Default Programs](https://msdn.microsoft.com/library/windows/desktop/cc144154) on the **Control Panel**.</span></span> |
| **<span data-ttu-id="7a6bf-134">名前</span><span class="sxs-lookup"><span data-stu-id="7a6bf-134">Name</span></span>** | <span data-ttu-id="7a6bf-135">URI スキームの名前を選びます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-135">Choose a name for the Uri scheme.</span></span> |
|  | <span data-ttu-id="7a6bf-136">**注**  名前はすべて小文字である必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-136">**Note**  The Name must be in all lower case letters.</span></span> |
|  | <span data-ttu-id="7a6bf-137">**予約および禁止されているファイルの種類** 予約または禁止されているため、UWP アプリを登録できない URI スキームの一覧 (アルファベット順) については、[予約済みの URI スキーム名とファイルの種類](reserved-uri-scheme-names.md)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-137">**Reserved and forbidden file types** See [Reserved URI scheme names and file types](reserved-uri-scheme-names.md) for an alphabetic list of Uri schemes that you can't register for your UWP apps because they are either reserved or forbidden.</span></span> |
| **<span data-ttu-id="7a6bf-138">実行可能ファイル</span><span class="sxs-lookup"><span data-stu-id="7a6bf-138">Executable</span></span>** | <span data-ttu-id="7a6bf-139">プロトコルの既定の起動実行可能ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-139">Specifies the default launch executable for the protocol.</span></span> <span data-ttu-id="7a6bf-140">指定しない場合、アプリの実行可能ファイルが使用されます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-140">If not specified, the app's executable is used.</span></span> <span data-ttu-id="7a6bf-141">指定する場合は、長さが 1 ～ 256 文字の文字列で、".exe" で終わっている必要があります。また、&gt;、&lt;、:、"、&#124;、?、\* の各文字を含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-141">If specified, the string must be between 1 and 256 characters in length, must end with ".exe", and cannot contain these characters: &gt;, &lt;, :, ", &#124;, ?, or \*.</span></span> <span data-ttu-id="7a6bf-142">指定した場合、**エントリ ポイント**も使用されます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-142">If specified, the **Entry point** is also used.</span></span> <span data-ttu-id="7a6bf-143">**[エントリ ポイント]** を指定しない場合、アプリで定義されているエントリ ポイントが使用されます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-143">If the **Entry point** isn't specified, the entry point defined for the app is used.</span></span> |
| **<span data-ttu-id="7a6bf-144">エントリ ポイント</span><span class="sxs-lookup"><span data-stu-id="7a6bf-144">Entry point</span></span>** | <span data-ttu-id="7a6bf-145">プロトコル拡張機能を処理するタスクを指定します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-145">Specifies the task that handles the protocol extension.</span></span> <span data-ttu-id="7a6bf-146">これは、通常、Windows ランタイムの型の完全な名前空間修飾名です。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-146">This is normally the fully namespace-qualified name of a Windows Runtime type.</span></span> <span data-ttu-id="7a6bf-147">指定しない場合、アプリのエントリ ポイントが使用されます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-147">If not specified, the entry point for the app is used.</span></span> |
| **<span data-ttu-id="7a6bf-148">スタート ページ</span><span class="sxs-lookup"><span data-stu-id="7a6bf-148">Start page</span></span>** | <span data-ttu-id="7a6bf-149">拡張ポイントを処理する Web ページです。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-149">The web page that handles the extensibility point.</span></span> |
| **<span data-ttu-id="7a6bf-150">リソース グループ</span><span class="sxs-lookup"><span data-stu-id="7a6bf-150">Resource group</span></span>** | <span data-ttu-id="7a6bf-151">リソース管理のために拡張機能のアクティブ化をグループ化するために使用できるタグ。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-151">A tag that you can use to group extension activations together for resource management purposes.</span></span> |
| <span data-ttu-id="7a6bf-152">**必要な表示** (Windows のみ)</span><span class="sxs-lookup"><span data-stu-id="7a6bf-152">**Desired View** (Windows-only)</span></span> | <span data-ttu-id="7a6bf-153">この URI スキーム名に対して起動されたときにアプリのウィンドウに必要なスペースの量を示すには、**[必要な表示]** フィールドを指定します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-153">Specify the **Desired View** field to indicate the amount of space the app's window needs when it is launched for the URI scheme name.</span></span> <span data-ttu-id="7a6bf-154">**[必要な表示]** に指定できる値は、**Default**、**UseLess**、**UseHalf**、**UseMore**、または **UseMinimum** です。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-154">The possible values for **Desired View** are **Default**, **UseLess**, **UseHalf**, **UseMore**, or **UseMinimum**.</span></span> <br/><span data-ttu-id="7a6bf-155">**注**  Windows では、ターゲット アプリの最終的なウィンドウ サイズを決定するときに複数の異なる要素が考慮されます。たとえば、ソース アプリの設定、画面上のアプリの数、画面の向きなどです。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-155">**Note**  Windows takes into account multiple different factors when determining the target app's final window size, for example, the preference of the source app, the number of apps on screen, the screen orientation, and so on.</span></span> <span data-ttu-id="7a6bf-156">**[必要な表示]** を設定しても、ターゲット アプリの特定のウィンドウ動作が保証されるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-156">Setting **Desired View** doesn't guarantee a specific windowing behavior for the target app.</span></span><br/> <span data-ttu-id="7a6bf-157">**モバイル デバイス ファミリ: [必要な表示]** はモバイル デバイス ファミリではサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-157">**Mobile device family:  Desired View** isn't supported on the mobile device family.</span></span> |
2.  <span data-ttu-id="7a6bf-158">**[ロゴ]** に `images\Icon.png` と入力します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-158">Enter `images\Icon.png` as the **Logo**.</span></span>
3.  <span data-ttu-id="7a6bf-159">**[表示名]** に `SDK Sample URI Scheme` と入力します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-159">Enter `SDK Sample URI Scheme` as the **Display name**</span></span>
4.  <span data-ttu-id="7a6bf-160">**[名前]** に `alsdk` と入力します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-160">Enter `alsdk` as the **Name**.</span></span>
5.  <span data-ttu-id="7a6bf-161">Ctrl + S キーを押して、変更を package.appxmanifest に保存します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-161">Press Ctrl+S to save the change to package.appxmanifest.</span></span>

    <span data-ttu-id="7a6bf-162">これにより、次のような [**Extension**](https://msdn.microsoft.com/library/windows/apps/br211400) 要素がパッケージ マニフェストに追加されます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-162">This adds an [**Extension**](https://msdn.microsoft.com/library/windows/apps/br211400) element like this one to the package manifest.</span></span> <span data-ttu-id="7a6bf-163">**windows.protocol** カテゴリは、アプリが `alsdk` URI スキーム名を処理することを示しています。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-163">The **windows.protocol** category indicates that the app handles the `alsdk` URI scheme name.</span></span>

    ```xml
          <Extensions>
            <uap:Extension Category="windows.protocol">
              <uap:Protocol Name="alsdk">
                <uap:Logo>images\icon.png</uap:Logo>
                <uap:DisplayName>SDK Sample URI Scheme</uap:DisplayName>
              </uap:Protocol>
            </uap:Extension>
          </Extensions>
    ```

## <a name="step-2-add-the-proper-icons"></a><span data-ttu-id="7a6bf-164">ステップ 2: 適切なアイコンを追加する</span><span class="sxs-lookup"><span data-stu-id="7a6bf-164">Step 2: Add the proper icons</span></span>

<span data-ttu-id="7a6bf-165">URI スキーム名の既定となるアプリは、そのアイコンがシステムのさまざまな場所に表示されます。アイコンは、[既定のプログラム] コントロール パネルなどに表示されます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-165">Apps that become the default for a URI scheme name have their icons displayed in various places throughout the system such as in the Default programs control panel.</span></span> <span data-ttu-id="7a6bf-166">このため、プロジェクトに 44 x 44 アイコンを含めます。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-166">Include a 44x44 icon with your project for this purpose.</span></span> <span data-ttu-id="7a6bf-167">アプリのタイルのロゴの外観を調和させ、アイコンを透明にするのではなく、アプリの背景色を使います。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-167">Match the look of the app tile logo and use your app's background color rather than making the icon transparent.</span></span> <span data-ttu-id="7a6bf-168">パディングせずにロゴを端まで拡張します。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-168">Have the logo extend to the edge without padding it.</span></span> <span data-ttu-id="7a6bf-169">アイコンは、白い背景でテストします。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-169">Test your icons on white backgrounds.</span></span> <span data-ttu-id="7a6bf-170">アイコンについて詳しくは、「[タイルとアイコン アセットのガイドライン](https://docs.microsoft.com/windows/uwp/controls-and-patterns/tiles-and-notifications-app-assets)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-170">See [Guidelines for tile and icon assets](https://docs.microsoft.com/windows/uwp/controls-and-patterns/tiles-and-notifications-app-assets) for more details about icons.</span></span>

## <a name="step-3-handle-the-activated-event"></a><span data-ttu-id="7a6bf-171">ステップ 3: アクティブ化イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="7a6bf-171">Step 3: Handle the activated event</span></span>


<span data-ttu-id="7a6bf-172">[**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) イベント ハンドラーは、すべてのファイル アクティブ化イベントを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-172">The [**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) event handler receives all activation events.</span></span> <span data-ttu-id="7a6bf-173">**Kind** プロパティは、アクティブ化イベントの種類を示しています。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-173">The **Kind** property indicates the type of activation event.</span></span> <span data-ttu-id="7a6bf-174">次の例では、[**Protocol**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.activation.activationkind.aspx#Protocol) アクティブ化イベントを処理するように設定されています。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-174">This example is set up to handle [**Protocol**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.activation.activationkind.aspx#Protocol) activation events.</span></span>

> [!div class="tabbedCodeSnippets"]
> ```cs
> public partial class App
> {
>    protected override void OnActivated(IActivatedEventArgs args)
>   {
>       if (args.Kind == ActivationKind.Protocol)
>       {
>          ProtocolActivatedEventArgs eventArgs = args as ProtocolActivatedEventArgs;
>          // TODO: Handle URI activation
>          // The received URI is eventArgs.Uri.AbsoluteUri
>       }
>    }
> }
> ```
> ```vb
> Protected Overrides Sub OnActivated(ByVal args As Windows.ApplicationModel.Activation.IActivatedEventArgs)
>    If args.Kind = ActivationKind.Protocol Then
>       ProtocolActivatedEventArgs eventArgs = args As ProtocolActivatedEventArgs
>       
>       ' TODO: Handle URI activation
>       ' The received URI is eventArgs.Uri.AbsoluteUri
>  End If
> End Sub
> ```
> ```cpp
> void App::OnActivated(Windows::ApplicationModel::Activation::IActivatedEventArgs^ args)
> {
>    if (args->Kind == Windows::ApplicationModel::Activation::ActivationKind::Protocol)
>    {
>       Windows::ApplicationModel::Activation::ProtocolActivatedEventArgs^ eventArgs =
>           dynamic_cast<Windows::ApplicationModel::Activation::ProtocolActivatedEventArgs^>(args);
>       
>       // TODO: Handle URI activation  
>       // The received URI is eventArgs->Uri->RawUri
>    }
> }
> ```

> <span data-ttu-id="7a6bf-175">**注**  プロトコル コントラクトを介して起動した場合、戻るボタンが使われたときは、アプリの以前のコンテンツに戻るのではなく、アプリを起動した画面に戻るようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-175">**Note**  When launched via Protocol Contract, make sure that Back button takes the user back to the screen that launched the app and not to the app's previous content.</span></span>

<span data-ttu-id="7a6bf-176">新しいページを開くアクティブ化イベントごとにアプリで新しい XAML [**フレーム**](https://msdn.microsoft.com/library/windows/apps/br242682)を作成することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-176">It is recommended that apps create a new XAML [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) for each activation event that opens a new page.</span></span> <span data-ttu-id="7a6bf-177">こうすると、新しい XAML **フレーム**のナビゲーション バックスタックに、中断されたときに現在のウィンドウに表示されていた以前のコンテンツが含まれなくなります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-177">This way, the navigation backstack for the new XAML **Frame** will not contain any previous content that the app might have on the current window when suspended.</span></span> <span data-ttu-id="7a6bf-178">起動コントラクトとファイル コントラクトで単一 XAML **フレーム**を使うことにしたアプリは、新しいページに移動する前に**フレーム**のナビゲーション ジャーナルにあるページをクリアする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-178">Apps that decide to use a single XAML **Frame** for Launch and File Contracts should clear the pages on the **Frame** navigation journal before navigating to a new page.</span></span>

<span data-ttu-id="7a6bf-179">プロトコルのアクティブ化によって起動されるときは、アプリの先頭ページに戻ることができる UI を含めることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-179">When launched via Protocol activation, apps should consider including UI that allows the user to go back to the top page of the app.</span></span>

## <a name="remarks"></a><span data-ttu-id="7a6bf-180">注釈</span><span class="sxs-lookup"><span data-stu-id="7a6bf-180">Remarks</span></span>


<span data-ttu-id="7a6bf-181">URI スキーム名は、悪意のあるものも含め、あらゆるアプリや Web サイトから使われる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-181">Any app or website can use your URI scheme name, including malicious ones.</span></span> <span data-ttu-id="7a6bf-182">そのため、その URI で受け取るデータは、信頼できないソースからのデータである可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-182">So any data that you get in the URI could come from an untrusted source.</span></span> <span data-ttu-id="7a6bf-183">URI で受け取るパラメーターに基づいて永続的な操作を実行しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-183">We recommend that you never perform a permanent action based on the parameters that you receive in the URI.</span></span> <span data-ttu-id="7a6bf-184">たとえば、アプリを起動するとユーザーのアカウント ページが表示されるようにするために URI パラメーターを使うことはかまいませんが、ユーザーのアカウントを直接変更するためにプロトコル パラメーターを使うことは行わないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-184">For example, URI parameters could be used to launch the app to a user's account page, but we recommend that you never use them to directly modify the user's account.</span></span>

> <span data-ttu-id="7a6bf-185">**注**  アプリの新しい URI スキーム名を作成する場合は、[RFC 4395](http://go.microsoft.com/fwlink/p/?LinkID=266550) のガイダンスに従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-185">**Note**  If you are creating a new URI scheme name for your app, be sure to follow the guidance in [RFC 4395](http://go.microsoft.com/fwlink/p/?LinkID=266550).</span></span> <span data-ttu-id="7a6bf-186">これにより確実に名前が URI スキームの標準に準拠するようになります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-186">This ensures that your name meets the standards for URI schemes.</span></span>

> <span data-ttu-id="7a6bf-187">**注**  プロトコル コントラクトを介して起動した場合、戻るボタンが使われたときは、アプリの以前のコンテンツに戻るのではなく、アプリを起動した画面に戻るようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-187">**Note**  When launched via Protocol Contract, make sure that Back button takes the user back to the screen that launched the app and not to the app's previous content.</span></span>

<span data-ttu-id="7a6bf-188">新しい URI ターゲットを開くアクティブ化イベントごとに、アプリで新しい XAML [**フレーム**](https://msdn.microsoft.com/library/windows/apps/br242682)を作成することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-188">We recommend that apps create a new XAML [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) for each activation event that opens a new Uri target.</span></span> <span data-ttu-id="7a6bf-189">こうすると、新しい XAML **フレーム**のナビゲーション バックスタックに、中断されたときに現在のウィンドウに表示されていた以前のコンテンツが含まれなくなります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-189">This way, the navigation backstack for the new XAML **Frame** will not contain any previous content that the app might have on the current window when suspended.</span></span>

<span data-ttu-id="7a6bf-190">アプリが、起動コントラクトとプロトコル コントラクトに単一 XAML [**フレーム**](https://msdn.microsoft.com/library/windows/apps/br242682)を使うようにした場合は、新しいページに移動する前に**フレーム**のナビゲーション ジャーナルにあるページをクリアする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-190">If you decide that you want your apps to use a single XAML [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) for Launch and Protocol Contracts, clear the pages on the **Frame** navigation journal before navigating to a new page.</span></span> <span data-ttu-id="7a6bf-191">プロトコル コントラクトによって起動されるときは、アプリの先頭に戻ることができる UI をアプリに含めることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-191">When launched via Protocol Contract, consider including UI into your apps that allows the user to go back to the top of the app.</span></span>

> <span data-ttu-id="7a6bf-192">**注**  この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-192">**Note**  This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps.</span></span> <span data-ttu-id="7a6bf-193">Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7a6bf-193">If you're developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).</span></span>

 

## <a name="related-topics"></a><span data-ttu-id="7a6bf-194">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7a6bf-194">Related topics</span></span>


**<span data-ttu-id="7a6bf-195">完全な例</span><span class="sxs-lookup"><span data-stu-id="7a6bf-195">Complete example</span></span>**

* [<span data-ttu-id="7a6bf-196">Association Launching サンプル</span><span class="sxs-lookup"><span data-stu-id="7a6bf-196">Association launching sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=231484)

**<span data-ttu-id="7a6bf-197">概念</span><span class="sxs-lookup"><span data-stu-id="7a6bf-197">Concepts</span></span>**

* [<span data-ttu-id="7a6bf-198">既定のプログラム</span><span class="sxs-lookup"><span data-stu-id="7a6bf-198">Default Programs</span></span>](https://msdn.microsoft.com/library/windows/desktop/cc144154)
* [<span data-ttu-id="7a6bf-199">ファイルの種類と URI の関連付けのモデル</span><span class="sxs-lookup"><span data-stu-id="7a6bf-199">File Type and URI Associations Model</span></span>](https://msdn.microsoft.com/library/windows/desktop/hh848047)

**<span data-ttu-id="7a6bf-200">処理手順</span><span class="sxs-lookup"><span data-stu-id="7a6bf-200">Tasks</span></span>**

* [<span data-ttu-id="7a6bf-201">URI に応じた既定のアプリの起動</span><span class="sxs-lookup"><span data-stu-id="7a6bf-201">Launch the default app for a URI</span></span>](launch-default-app.md)
* [<span data-ttu-id="7a6bf-202">ファイルのアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="7a6bf-202">Handle file activation</span></span>](handle-file-activation.md)

**<span data-ttu-id="7a6bf-203">ガイドライン</span><span class="sxs-lookup"><span data-stu-id="7a6bf-203">Guidelines</span></span>**

* [<span data-ttu-id="7a6bf-204">ファイルの種類と URI のガイドライン</span><span class="sxs-lookup"><span data-stu-id="7a6bf-204">Guidelines for file types and URIs</span></span>](https://msdn.microsoft.com/library/windows/apps/hh700321)

**<span data-ttu-id="7a6bf-205">リファレンス</span><span class="sxs-lookup"><span data-stu-id="7a6bf-205">Reference</span></span>**

* [**<span data-ttu-id="7a6bf-206">AppX パッケージ マニフェスト</span><span class="sxs-lookup"><span data-stu-id="7a6bf-206">AppX Package Manifest</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn934791)
* [**<span data-ttu-id="7a6bf-207">Windows.ApplicationModel.Activation.ProtocolActivatedEventArgs</span><span class="sxs-lookup"><span data-stu-id="7a6bf-207">Windows.ApplicationModel.Activation.ProtocolActivatedEventArgs</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224742)
* [**<span data-ttu-id="7a6bf-208">Windows.UI.Xaml.Application.OnActivated</span><span class="sxs-lookup"><span data-stu-id="7a6bf-208">Windows.UI.Xaml.Application.OnActivated</span></span>**](https://msdn.microsoft.com/library/windows/apps/br242330)

 

 
