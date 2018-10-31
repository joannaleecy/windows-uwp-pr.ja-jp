---
author: TylerMSFT
title: ファイルのアクティブ化の処理
description: アプリは、特定のファイルの種類の既定のハンドラーとして登録することができます。
ms.assetid: A0F914C5-62BC-4FF7-9236-E34C5277C363
ms.author: twhitney
ms.date: 07/05/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
dev_langs:
- csharp
- vb
- cppwinrt
- cpp
ms.openlocfilehash: 9f1e41c3e09d9a711ce9174a5a658a55c7c44abd
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5866417"
---
# <a name="handle-file-activation"></a><span data-ttu-id="0a9a0-104">ファイルのアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="0a9a0-104">Handle file activation</span></span>

**<span data-ttu-id="0a9a0-105">重要な API</span><span class="sxs-lookup"><span data-stu-id="0a9a0-105">Important APIs</span></span>**

-   [**<span data-ttu-id="0a9a0-106">Windows.ApplicationModel.Activation.FileActivatedEventArgs</span><span class="sxs-lookup"><span data-stu-id="0a9a0-106">Windows.ApplicationModel.Activation.FileActivatedEventArgs</span></span>**](https://msdn.microsoft.com/library/windows/apps/br224716)
-   [**<span data-ttu-id="0a9a0-107">Windows.UI.Xaml.Application.OnFileActivated</span><span class="sxs-lookup"><span data-stu-id="0a9a0-107">Windows.UI.Xaml.Application.OnFileActivated</span></span>**](https://msdn.microsoft.com/library/windows/apps/br242331)

<span data-ttu-id="0a9a0-108">アプリは、特定のファイルの種類の既定のハンドラーとして登録できます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-108">Your app can register to become the default handler for a certain file type.</span></span> <span data-ttu-id="0a9a0-109">Windows デスクトップ アプリケーションとユニバーサル Windows プラットフォーム (UWP) アプリの両方を、既定のファイル ハンドラーとして登録できます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-109">Both Windows desktop applications and Universal Windows Platform (UWP) apps can register to be a default file handler.</span></span> <span data-ttu-id="0a9a0-110">ユーザーがアプリを特定のファイルの種類の既定のハンドラーとして選ぶと、アプリはその種類のファイルを起動したときにアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-110">If the user chooses your app as the default handler for a certain file type, your app will be activated when that type of file is launched.</span></span>

<span data-ttu-id="0a9a0-111">ファイルの種類に登録するのは、その種類のファイルのすべてのファイル起動を処理する場合のみにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-111">We recommend that you only register for a file type if you expect to handle all file launches for that type of file.</span></span> <span data-ttu-id="0a9a0-112">アプリをそのファイルの種類に内部的にのみ使う場合、既定のハンドラーに登録する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-112">If your app only needs to use the file type internally, then you don't need to register to be the default handler.</span></span> <span data-ttu-id="0a9a0-113">ファイルの種類に登録する場合は、そのファイルの種類のためにアプリをアクティブ化した際に期待される機能をエンド ユーザーに提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-113">If you do choose to register for a file type, you must provide the end user with the functionality that is expected when your app is activated for that file type.</span></span> <span data-ttu-id="0a9a0-114">たとえば、.jpg ファイルを表示する画像ビューアー アプリを登録できます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-114">For example, a picture viewer app may register to display a .jpg file.</span></span> <span data-ttu-id="0a9a0-115">ファイルの関連付けについて詳しくは、「[ファイルの種類と URI のガイドライン](https://msdn.microsoft.com/library/windows/apps/hh700321)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-115">For more info on file associations, see [Guidelines for file types and URIs](https://msdn.microsoft.com/library/windows/apps/hh700321).</span></span>

<span data-ttu-id="0a9a0-116">以下の手順では、カスタムのファイルの種類 .alsdk を登録する方法と、ユーザーによって .alsdk ファイルが起動されたときにアプリをアクティブ化する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-116">These steps show how to register for a custom file type, .alsdk, and how to activate your app when the user launches an .alsdk file.</span></span>

> <span data-ttu-id="0a9a0-117">**注:**、UWP アプリで特定の Uri とファイル拡張子は用に予約されて組み込みのアプリと、オペレーティング システム。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-117">**Note**In UWP apps, certain URIs and file extensions are reserved for use by built-in apps and the operating system.</span></span> <span data-ttu-id="0a9a0-118">予約されている URI またはファイル拡張子にアプリを登録しようとしても無視されます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-118">Attempts to register your app with a reserved URI or file extension will be ignored.</span></span> <span data-ttu-id="0a9a0-119">詳しくは、「[予約済みのファイルと URI スキーム名](reserved-uri-scheme-names.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-119">For more information, see [Reserved file and URI scheme names](reserved-uri-scheme-names.md).</span></span>

## <a name="step-1-specify-the-extension-point-in-the-package-manifest"></a><span data-ttu-id="0a9a0-120">ステップ 1: パッケージ マニフェストに拡張点を指定する</span><span class="sxs-lookup"><span data-stu-id="0a9a0-120">Step 1: Specify the extension point in the package manifest</span></span>

<span data-ttu-id="0a9a0-121">アプリは、パッケージ マニフェストに一覧表示されるファイル拡張子のアクティブ化イベントだけを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-121">The app receives activation events only for the file extensions listed in the package manifest.</span></span> <span data-ttu-id="0a9a0-122">アプリが `.alsdk` 拡張子を持つファイルを処理することを示す方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-122">Here's how you indicate that your app handles the files with the `.alsdk` extension.</span></span>

1.  <span data-ttu-id="0a9a0-123">**ソリューション エクスプローラー**で、package.appxmanifest をダブルクリックしてマニフェスト デザイナーを開きます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-123">In the **Solution Explorer**, double-click package.appxmanifest to open the manifest designer.</span></span> <span data-ttu-id="0a9a0-124">**[宣言]** タブを選び、**[使用可能な宣言]** ドロップダウンから **[ファイルの種類の関連付け]** を選んで **[追加]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-124">Select the **Declarations** tab and in the **Available Declarations** drop-down, select **File Type Associations** and then click **Add**.</span></span> <span data-ttu-id="0a9a0-125">ファイルの関連付けで使われる識別子について詳しくは、「[プログラムの識別子](https://msdn.microsoft.com/library/windows/desktop/cc144152)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-125">See [Programmatic Identifiers](https://msdn.microsoft.com/library/windows/desktop/cc144152) for more details of identifiers used by file associations.</span></span>

    <span data-ttu-id="0a9a0-126">マニフェスト デザイナーで指定することができる各フィールドについて、以下で簡単に説明します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-126">Here is a brief description of each of the fields that you may fill in the manifest designer:</span></span>

| <span data-ttu-id="0a9a0-127">フィールド</span><span class="sxs-lookup"><span data-stu-id="0a9a0-127">Field</span></span> | <span data-ttu-id="0a9a0-128">説明</span><span class="sxs-lookup"><span data-stu-id="0a9a0-128">Description</span></span> |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **<span data-ttu-id="0a9a0-129">表示名</span><span class="sxs-lookup"><span data-stu-id="0a9a0-129">Display Name</span></span>** | <span data-ttu-id="0a9a0-130">ファイルの種類のグループの表示名を指定します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-130">Specify the display name for a group of file types.</span></span> <span data-ttu-id="0a9a0-131">表示名は、**コントロール パネル**の [[既定のプログラムを設定する]](https://msdn.microsoft.com/library/windows/desktop/cc144154) でファイルの種類を識別するために使われます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-131">The display name is used to identify the file type in the [Set Default Programs](https://msdn.microsoft.com/library/windows/desktop/cc144154) on the **Control Panel**.</span></span> |
| **<span data-ttu-id="0a9a0-132">ロゴ</span><span class="sxs-lookup"><span data-stu-id="0a9a0-132">Logo</span></span>** | <span data-ttu-id="0a9a0-133">デスクトップと**コントロール パネル**の [[既定のプログラムを設定する]](https://msdn.microsoft.com/library/windows/desktop/cc144154) でファイルの種類を識別するために使われるロゴを指定します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-133">Specify the logo that is used to identify the file type on the desktop and in the [Set Default Programs](https://msdn.microsoft.com/library/windows/desktop/cc144154) on the **Control Panel**.</span></span> <span data-ttu-id="0a9a0-134">ロゴを指定しない場合は、アプリケーションの小さいロゴが使われます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-134">If no Logo is specified, the application’s small logo is used.</span></span> |
| **<span data-ttu-id="0a9a0-135">InfoTip</span><span class="sxs-lookup"><span data-stu-id="0a9a0-135">Info Tip</span></span>** | <span data-ttu-id="0a9a0-136">ファイルの種類のグループの [InfoTip](https://msdn.microsoft.com/library/windows/desktop/cc144152) を指定します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-136">Specify the [info tip](https://msdn.microsoft.com/library/windows/desktop/cc144152) for a group of file types.</span></span> <span data-ttu-id="0a9a0-137">このヒントのテキストは、ユーザーがこの種類のファイルのアイコンの上にマウス ポインターを置くと表示されます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-137">This tool tip text appears when the user hovers on the icon for a file of this type.</span></span> |
| **<span data-ttu-id="0a9a0-138">名前</span><span class="sxs-lookup"><span data-stu-id="0a9a0-138">Name</span></span>** | <span data-ttu-id="0a9a0-139">同じ表示名、ロゴ、InfoTip、編集フラグを共有するファイルの種類のグループの名前を選びます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-139">Choose a name for a group of file types that share the same display name, logo, info tip, and edit flags.</span></span> <span data-ttu-id="0a9a0-140">このグループ名は、アプリの更新後も維持される名前にします。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-140">Choose a group name that can stay the same across app updates.</span></span> <span data-ttu-id="0a9a0-141">**注**  名前はすべて小文字である必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-141">**Note**  The Name must be in all lower case letters.</span></span> |
| **<span data-ttu-id="0a9a0-142">コンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="0a9a0-142">Content Type</span></span>** | <span data-ttu-id="0a9a0-143">特定のファイルの種類の MIME コンテンツの種類 (**image/jpeg** など) を指定します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-143">Specify the MIME content type, such as **image/jpeg**, for a particular file type.</span></span> <span data-ttu-id="0a9a0-144">**許可されるコンテンツの種類に関する重要な注意:** MIME コンテンツの種類のうち、**application/force-download**、**application/octet-stream**、**application/unknown**、**application/x-msdownload** は予約または禁止されているため、パッケージ マニフェストに入力できません。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-144">**Important Note about allowed content types:** Here is an alphabetic list of MIME content types that you cannot enter into the package manifest because they are either reserved or forbidden: **application/force-download**, **application/octet-stream**, **application/unknown**, **application/x-msdownload**.</span></span> |
| **<span data-ttu-id="0a9a0-145">ファイルの種類</span><span class="sxs-lookup"><span data-stu-id="0a9a0-145">File type</span></span>** | <span data-ttu-id="0a9a0-146">登録するファイルの種類を指定します。先頭にはピリオドを付けます (例: ".jpeg")。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-146">Specify the file type to register for, preceded by a period, for example, “.jpeg”.</span></span> <span data-ttu-id="0a9a0-147">**予約および禁止されているファイルの種類:** 予約または禁止されているために UWP アプリを登録できない組み込みアプリ用のファイルの種類の一覧 (アルファベット順) については、「[予約済みのファイルと URI スキーム名](reserved-uri-scheme-names.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-147">**Reserved and forbidden file types:** See [Reserved URI scheme names and file types](reserved-uri-scheme-names.md) for an alphabetic list of file types for built-in apps that you can't register for your UWP apps because they are either reserved or forbidden.</span></span> |

2.  <span data-ttu-id="0a9a0-148">**[名前]** に `alsdk` と入力します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-148">Enter `alsdk` as the **Name**.</span></span>
3.  <span data-ttu-id="0a9a0-149">**[ファイルの種類]** に `.alsdk` と入力します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-149">Enter `.alsdk` as the **File Type**.</span></span>
4.  <span data-ttu-id="0a9a0-150">[ロゴ] に「images\\Icon.png」と入力します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-150">Enter “images\\Icon.png” as the Logo.</span></span>
5.  <span data-ttu-id="0a9a0-151">Ctrl + S キーを押して、変更を package.appxmanifest に保存します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-151">Press Ctrl+S to save the change to package.appxmanifest.</span></span>

<span data-ttu-id="0a9a0-152">上記の手順により、次のような [**Extension**](https://msdn.microsoft.com/library/windows/apps/br211400) 要素がパッケージ マニフェストに追加されます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-152">The steps above add an [**Extension**](https://msdn.microsoft.com/library/windows/apps/br211400) element like this one to the package manifest.</span></span> <span data-ttu-id="0a9a0-153">**windows.fileTypeAssociation** カテゴリは、アプリが `.alsdk` 拡張子を持つファイルを処理することを示しています。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-153">The **windows.fileTypeAssociation** category indicates that the app handles files with the `.alsdk` extension.</span></span>

```xml
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap:FileTypeAssociation Name="alsdk">
            <uap:Logo>images\icon.png</uap:Logo>
            <uap:SupportedFileTypes>
              <uap:FileType>.alsdk</uap:FileType>
            </uap:SupportedFileTypes>
          </uap:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
```

## <a name="step-2-add-the-proper-icons"></a><span data-ttu-id="0a9a0-154">ステップ 2: 適切なアイコンを追加する</span><span class="sxs-lookup"><span data-stu-id="0a9a0-154">Step 2: Add the proper icons</span></span>

<span data-ttu-id="0a9a0-155">ファイルの種類の既定となるアプリは、そのアイコンがシステムのさまざまな場所に表示されます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-155">Apps that become the default for a file type have their icons displayed in various places throughout the system.</span></span> <span data-ttu-id="0a9a0-156">アイコンは、たとえば次の場所に表示されます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-156">For example, these icons are shown in:</span></span>

-   <span data-ttu-id="0a9a0-157">エクスプローラーの項目ビュー、コンテキスト メニュー、リボン</span><span class="sxs-lookup"><span data-stu-id="0a9a0-157">Windows Explorer Items View, context menus, and the Ribbon</span></span>
-   <span data-ttu-id="0a9a0-158">[既定のプログラム] コントロール パネル</span><span class="sxs-lookup"><span data-stu-id="0a9a0-158">Default programs Control Panel</span></span>
-   <span data-ttu-id="0a9a0-159">ファイル ピッカー</span><span class="sxs-lookup"><span data-stu-id="0a9a0-159">File picker</span></span>
-   <span data-ttu-id="0a9a0-160">スタート画面での検索結果</span><span class="sxs-lookup"><span data-stu-id="0a9a0-160">Search results on the Start screen</span></span>

<span data-ttu-id="0a9a0-161">ロゴがこれらの場所に表示されるように、プロジェクトに 44 x 44 のアイコンを含めます。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-161">Include a 44x44 icon with your project so that your logo can appear in those locations.</span></span> <span data-ttu-id="0a9a0-162">アプリのタイルのロゴの外観を調和させ、アイコンを透明にするのではなく、アプリの背景色を使います。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-162">Match the look of the app tile logo and use your app's background color rather than making the icon transparent.</span></span> <span data-ttu-id="0a9a0-163">パディングせずにロゴを端まで拡張します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-163">Have the logo extend to the edge without padding it.</span></span> <span data-ttu-id="0a9a0-164">アイコンは、白い背景でテストします。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-164">Test your icons on white backgrounds.</span></span> <span data-ttu-id="0a9a0-165">アイコンについて詳しくは、「[タイルとアイコン アセットのガイドライン](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/app-assets)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-165">See [Guidelines for tile and icon assets](https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/app-assets) for more details about icons.</span></span>

## <a name="step-3-handle-the-activated-event"></a><span data-ttu-id="0a9a0-166">ステップ 3: アクティブ化イベントを処理する</span><span class="sxs-lookup"><span data-stu-id="0a9a0-166">Step 3: Handle the activated event</span></span>

<span data-ttu-id="0a9a0-167">[**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331) イベント ハンドラーは、すべてのファイル アクティブ化イベントを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-167">The [**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331) event handler receives all file activation events.</span></span>

```csharp
protected override void OnFileActivated(FileActivatedEventArgs args)
{
       // TODO: Handle file activation
       // The number of files received is args.Files.Size
       // The name of the first file is args.Files[0].Name
}
```

```vb
Protected Overrides Sub OnFileActivated(ByVal args As Windows.ApplicationModel.Activation.FileActivatedEventArgs)
      ' TODO: Handle file activation
      ' The number of files received is args.Files.Size
      ' The name of the first file is args.Files(0).Name
End Sub
```

```cppwinrt
void App::OnFileActivated(Windows::ApplicationModel::Activation::FileActivatedEventArgs const& args)
{
    // TODO: Handle file activation.
    auto numberOfFilesReceived{ args.Files().Size() };
    auto nameOfTheFirstFile{ args.Files().GetAt(0).Name() };
}
```

```cpp
void App::OnFileActivated(Windows::ApplicationModel::Activation::FileActivatedEventArgs^ args)
{
    // TODO: Handle file activation
    // The number of files received is args->Files->Size
    // The name of the first file is args->Files->GetAt(0)->Name
}
```

> [!NOTE]
> <span data-ttu-id="0a9a0-168">ファイルのコントラクトによって起動すると、その戻るボタン戻る、アプリを起動した画面としないアプリの以前のコンテンツを確認します。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-168">When launched via File Contract, make sure that Back button takes the user back to the screen that launched the app and not to the app's previous content.</span></span>

<span data-ttu-id="0a9a0-169">新しいページを開くアクティブ化イベントごとに新しい XAML**フレーム**を作成することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-169">We recommend that you create a new XAML **Frame** for each activation event that opens a new page.</span></span> <span data-ttu-id="0a9a0-170">これにより、新しい XAML フレームのナビゲーション backstack は、以前のコンテンツが中断されたときに、現在のウィンドウで、アプリが含まれていません。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-170">That way, the navigation backstack for the new XAML Frame doesn't contain any previous content that the app might have on the current window when suspended.</span></span> <span data-ttu-id="0a9a0-171">起動とファイル コントラクトに単一 XAML**フレーム**を使用した場合は、新しいページに移動する前に**フレーム**のナビゲーション ジャーナルにある内のページをクリアする必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-171">If you decide to use a single XAML **Frame** for Launch and for File Contracts, then you should clear the pages in the **Frame**'s navigation journal before navigating to a new page.</span></span>

<span data-ttu-id="0a9a0-172">ファイル アクティブ化によってアプリを起動すると、アプリの先頭ページに戻るには、ユーザーができる UI を含めることを検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-172">When your app is launched via File activation, you should consider including UI that allows the user to go back to the top page of the app.</span></span>

## <a name="remarks"></a><span data-ttu-id="0a9a0-173">注釈</span><span class="sxs-lookup"><span data-stu-id="0a9a0-173">Remarks</span></span>

<span data-ttu-id="0a9a0-174">受け取るファイルは、信頼できないソースからのファイルである可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-174">The files that you receive could come from an untrusted source.</span></span> <span data-ttu-id="0a9a0-175">操作する前に、ファイルのコンテンツを検証することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-175">We recommend that you validate the content of a file before taking action on it.</span></span> <span data-ttu-id="0a9a0-176">入力の検証について詳しくは、[安全なコードの記述](http://go.microsoft.com/fwlink/p/?LinkID=142053)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0a9a0-176">For more info on input validation, see [Writing Secure Code](http://go.microsoft.com/fwlink/p/?LinkID=142053)</span></span>

## <a name="related-topics"></a><span data-ttu-id="0a9a0-177">関連トピック</span><span class="sxs-lookup"><span data-stu-id="0a9a0-177">Related topics</span></span>

### <a name="complete-example"></a><span data-ttu-id="0a9a0-178">完全な例</span><span class="sxs-lookup"><span data-stu-id="0a9a0-178">Complete example</span></span>

* [<span data-ttu-id="0a9a0-179">Association Launching サンプル</span><span class="sxs-lookup"><span data-stu-id="0a9a0-179">Association launching sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=231484)

### <a name="concepts"></a><span data-ttu-id="0a9a0-180">概念</span><span class="sxs-lookup"><span data-stu-id="0a9a0-180">Concepts</span></span>

* [<span data-ttu-id="0a9a0-181">既定のプログラム</span><span class="sxs-lookup"><span data-stu-id="0a9a0-181">Default Programs</span></span>](https://msdn.microsoft.com/library/windows/desktop/cc144154)
* [<span data-ttu-id="0a9a0-182">ファイルの種類とプロトコルの関連付けのモデル</span><span class="sxs-lookup"><span data-stu-id="0a9a0-182">File Type and Protocol Associations Model</span></span>](https://msdn.microsoft.com/library/windows/desktop/hh848047)

### <a name="tasks"></a><span data-ttu-id="0a9a0-183">処理手順</span><span class="sxs-lookup"><span data-stu-id="0a9a0-183">Tasks</span></span>

* [<span data-ttu-id="0a9a0-184">ファイルに応じた既定のアプリの起動</span><span class="sxs-lookup"><span data-stu-id="0a9a0-184">Launch the default app for a file</span></span>](launch-the-default-app-for-a-file.md)
* [<span data-ttu-id="0a9a0-185">URI のアクティブ化の処理</span><span class="sxs-lookup"><span data-stu-id="0a9a0-185">Handle URI activation</span></span>](handle-uri-activation.md)

### <a name="guidelines"></a><span data-ttu-id="0a9a0-186">ガイドライン</span><span class="sxs-lookup"><span data-stu-id="0a9a0-186">Guidelines</span></span>

* [<span data-ttu-id="0a9a0-187">ファイルの種類と URI のガイドライン</span><span class="sxs-lookup"><span data-stu-id="0a9a0-187">Guidelines for file types and URIs</span></span>](https://msdn.microsoft.com/library/windows/apps/hh700321)

### <a name="reference"></a><span data-ttu-id="0a9a0-188">リファレンス</span><span class="sxs-lookup"><span data-stu-id="0a9a0-188">Reference</span></span>
* [<span data-ttu-id="0a9a0-189">Windows.ApplicationModel.Activation.FileActivatedEventArgs</span><span class="sxs-lookup"><span data-stu-id="0a9a0-189">Windows.ApplicationModel.Activation.FileActivatedEventArgs</span></span>](https://msdn.microsoft.com/library/windows/apps/br224716)
* [<span data-ttu-id="0a9a0-190">Windows.UI.Xaml.Application.OnFileActivated</span><span class="sxs-lookup"><span data-stu-id="0a9a0-190">Windows.UI.Xaml.Application.OnFileActivated</span></span>](https://msdn.microsoft.com/library/windows/apps/br242331)
