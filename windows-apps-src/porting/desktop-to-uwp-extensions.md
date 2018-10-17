---
author: normesta
Description: You can use extensions to integrate your packaged desktop app with Windows 10 in predefined ways.
Search.Product: eADQiWindows 10XVcnh
title: Windows 10 にアプリを統合する (デスクトップ ブリッジ)
ms.author: normesta
ms.date: 04/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 0a8cedac-172a-4efd-8b6b-67fd3667df34
ms.localizationpriority: medium
ms.openlocfilehash: fadd9c2b6a35a1418a782ab0a6ef419e3f127f42
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4756013"
---
# <a name="integrate-your-packaged-desktop-application-with-windows-10"></a><span data-ttu-id="628bb-103">Windows 10 にパッケージ化されたデスクトップ アプリケーションを統合します。</span><span class="sxs-lookup"><span data-stu-id="628bb-103">Integrate your packaged desktop application with Windows 10</span></span>

<span data-ttu-id="628bb-104">拡張機能を使用すると、あらかじめ定義された方法で Windows 10 にパッケージ化されたデスクトップ アプリケーションを統合します。</span><span class="sxs-lookup"><span data-stu-id="628bb-104">Use extensions to integrate your packaged desktop application with Windows 10 in predefined ways.</span></span>

<span data-ttu-id="628bb-105">たとえば、ファイアウォールの例外を作成、アプリケーションのファイルの種類の既定のアプリケーションにする、またはアプリのパッケージ バージョンをスタート画面のタイルをポイントする拡張機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="628bb-105">For example, use an extension to create a firewall exception, make your application the default application for a file type, or point start tiles to the packaged version of your app.</span></span> <span data-ttu-id="628bb-106">拡張機能は、アプリのパッケージ マニフェスト ファイルに XML を追加するだけで使用できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-106">To use an extension, just add some XML to your app's package manifest file.</span></span> <span data-ttu-id="628bb-107">コードは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="628bb-107">No code is required.</span></span>

<span data-ttu-id="628bb-108">このトピックでは、これらの拡張機能について説明し、拡張機能を使って実行できるタスクについても示します。</span><span class="sxs-lookup"><span data-stu-id="628bb-108">This topic describes these extensions and the tasks that you can perform by using them.</span></span>

## <a name="transition-users-to-your-app"></a><span data-ttu-id="628bb-109">ユーザーをアプリに移行する</span><span class="sxs-lookup"><span data-stu-id="628bb-109">Transition users to your app</span></span>

<span data-ttu-id="628bb-110">ユーザーによってパッケージ アプリが使用されるように、移行を促します。</span><span class="sxs-lookup"><span data-stu-id="628bb-110">Help users transition to your packaged app.</span></span>

* [<span data-ttu-id="628bb-111">既存のスタート タイルとタスク バー ボタンの参照先をパッケージ アプリに設定する</span><span class="sxs-lookup"><span data-stu-id="628bb-111">Point existing Start tiles and taskbar buttons to your packaged app</span></span>](#point)
* [<span data-ttu-id="628bb-112">デスクトップ アプリではなくファイルを開き、パッケージ化されたアプリケーションを作成します。</span><span class="sxs-lookup"><span data-stu-id="628bb-112">Make your packaged application open files instead of your desktop app</span></span>](#make)
* [<span data-ttu-id="628bb-113">ファイルの種類のセットをパッケージ化されたアプリケーションを関連付ける</span><span class="sxs-lookup"><span data-stu-id="628bb-113">Associate your packaged application with a set of file types</span></span>](#associate)
* [<span data-ttu-id="628bb-114">特定の種類のファイルのコンテキスト メニューにオプションを追加する</span><span class="sxs-lookup"><span data-stu-id="628bb-114">Add options to the context menus of files that have a certain file type</span></span>](#add)
* [<span data-ttu-id="628bb-115">URL を使用して特定の種類のファイルを直接開く</span><span class="sxs-lookup"><span data-stu-id="628bb-115">Open certain types of files directly by using a URL</span></span>](#open)

<a id="point" />

### <a name="point-existing-start-tiles-and-taskbar-buttons-to-your-packaged-app"></a><span data-ttu-id="628bb-116">既存のスタート タイルとタスク バー ボタンの参照先をパッケージ アプリに設定する</span><span class="sxs-lookup"><span data-stu-id="628bb-116">Point existing Start tiles and taskbar buttons to your packaged app</span></span>

<span data-ttu-id="628bb-117">ユーザーによって、デスクトップ アプリがタスク バーまたはスタート メニューにピン留めされている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="628bb-117">Your users might have pinned your desktop application to the taskbar or the Start menu.</span></span> <span data-ttu-id="628bb-118">これらのショートカットの参照先を新しいパッケージ アプリに変更できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-118">You can point those shortcuts to your new packaged app.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-119">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-119">XML namespace</span></span>

http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-120">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-120">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.desktopAppMigration">
    <DesktopAppMigration>
        <DesktopApp AumId="[your_app_aumid]" />
        <DesktopApp ShortcutPath="[path]" />
    </DesktopAppMigration>
</Extension>

```

<span data-ttu-id="628bb-121">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-rescap3-desktopappmigration)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-121">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-rescap3-desktopappmigration).</span></span>

|<span data-ttu-id="628bb-122">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-122">Name</span></span> | <span data-ttu-id="628bb-123">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-123">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-124">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-124">Category</span></span> |<span data-ttu-id="628bb-125">常に ``windows.desktopAppMigration`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-125">Always ``windows.desktopAppMigration``.</span></span>
|<span data-ttu-id="628bb-126">AumID</span><span class="sxs-lookup"><span data-stu-id="628bb-126">AumID</span></span> |<span data-ttu-id="628bb-127">パッケージ アプリのアプリケーション ユーザー モデル ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-127">The Application User Model ID of your packaged app.</span></span> |
|<span data-ttu-id="628bb-128">ShortcutPath</span><span class="sxs-lookup"><span data-stu-id="628bb-128">ShortcutPath</span></span> |<span data-ttu-id="628bb-129">アプリのデスクトップ バージョンを起動する .lnk ファイルへのパス。</span><span class="sxs-lookup"><span data-stu-id="628bb-129">The path to .lnk files that start the desktop version of your app.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-130">例</span><span class="sxs-lookup"><span data-stu-id="628bb-130">Example</span></span>

```XML
<Package
  xmlns:rescap3="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3"
  IgnorableNamespaces="rescap3">
  <Applications>
    <Application>
      <Extensions>
        <rescap3:Extension Category="windows.desktopAppMigration">
          <rescap3:DesktopAppMigration>
            <rescap3:DesktopApp AumId="[your_app_aumid]" />
            <rescap3:DesktopApp ShortcutPath="%USERPROFILE%\Desktop\[my_app].lnk" />
            <rescap3:DesktopApp ShortcutPath="%APPDATA%\Microsoft\Windows\Start Menu\Programs\[my_app].lnk" />
            <rescap3:DesktopApp ShortcutPath="%PROGRAMDATA%\Microsoft\Windows\Start Menu\Programs\[my_app_folder]\[my_app].lnk"/>
         </rescap3:DesktopAppMigration>
        </rescap3:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
#### <a name="related-sample"></a><span data-ttu-id="628bb-131">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="628bb-131">Related sample</span></span>

[<span data-ttu-id="628bb-132">WPF picture viewer with transition/migration/uninstallation</span><span class="sxs-lookup"><span data-stu-id="628bb-132">WPF picture viewer with transition/migration/uninstallation</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<a id="make" />

### <a name="make-your-packaged-application-open-files-instead-of-your-desktop-app"></a><span data-ttu-id="628bb-133">デスクトップ アプリではなくファイルを開き、パッケージ化されたアプリケーションを作成します。</span><span class="sxs-lookup"><span data-stu-id="628bb-133">Make your packaged application open files instead of your desktop app</span></span>

<span data-ttu-id="628bb-134">ユーザーが既定では特定の種類のファイルを開くときに、アプリのデスクトップ バージョンではなく、新しいパッケージ化されたアプリケーションを開くことを確認することができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-134">You can make sure that users open your new packaged application by default for specific types of files instead of opening the desktop version of your app.</span></span>

<span data-ttu-id="628bb-135">これを行うには、ファイルの関連付けを継承するために、関連付けされている各アプリケーションの[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) を指定します。</span><span class="sxs-lookup"><span data-stu-id="628bb-135">To do that, you'll specify the [programmatic identifier (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) of each application from which you want to inherit file associations.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="628bb-136">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-136">XML namespaces</span></span>

* http://schemas.microsoft.com/appx/manifest/uap/windows10/3
* http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-137">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-137">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
<FileTypeAssociation Name="[AppID]">
         <MigrationProgIds>
            <MigrationProgId>"[ProgID]"</MigrationProgId>
        </MigrationProgIds>
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="628bb-138">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-138">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="628bb-139">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-139">Name</span></span> |<span data-ttu-id="628bb-140">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-140">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-141">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-141">Category</span></span> |<span data-ttu-id="628bb-142">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-142">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="628bb-143">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-143">Name</span></span> |<span data-ttu-id="628bb-144">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-144">A unique Id for your app.</span></span> <span data-ttu-id="628bb-145">この ID は、ファイルの種類の関連付けによって関連付けられたハッシュ対象の[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) を生成するために内部で使用されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-145">This Id is used internally to generate a hashed [programmatic identifier (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) associated with your file type association.</span></span> <span data-ttu-id="628bb-146">この ID を使って、アプリの今後のバージョンで変更を管理することができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-146">You can use this Id to manage changes in future versions of your app.</span></span> |
|<span data-ttu-id="628bb-147">MigrationProgId</span><span class="sxs-lookup"><span data-stu-id="628bb-147">MigrationProgId</span></span> |<span data-ttu-id="628bb-148">アプリケーション、コンポーネント、およびファイルの関連付けを継承するデスクトップ アプリケーションのバージョンを記述した[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="628bb-148">The [programmatic identifier (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) that describes the application, component, and version of the desktop application from which you want to inherit file associations.</span></span>|

#### <a name="example"></a><span data-ttu-id="628bb-149">例</span><span class="sxs-lookup"><span data-stu-id="628bb-149">Example</span></span>

```XML
<Package
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:rescap3="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3"
  IgnorableNamespaces="uap3, rescap3">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <rescap3:MigrationProgIds>
              <rescap3:MigrationProgId>Foo.Bar.1</rescap3:MigrationProgId>
              <rescap3:MigrationProgId>Foo.Bar.2</rescap3:MigrationProgId>
            </rescap3:MigrationProgIds>
          </uap3:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
#### <a name="related-sample"></a><span data-ttu-id="628bb-150">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="628bb-150">Related sample</span></span>

[<span data-ttu-id="628bb-151">WPF picture viewer with transition/migration/uninstallation</span><span class="sxs-lookup"><span data-stu-id="628bb-151">WPF picture viewer with transition/migration/uninstallation</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<a id="associate" />

### <a name="associate-your-packaged-application-with-a-set-of-file-types"></a><span data-ttu-id="628bb-152">ファイルの種類のセットをパッケージ化されたアプリケーションを関連付ける</span><span class="sxs-lookup"><span data-stu-id="628bb-152">Associate your packaged application with a set of file types</span></span>

<span data-ttu-id="628bb-153">パッケージ化されたアプリケーションは、ファイル拡張子に関連付けられていることができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-153">You can associated your packaged application with file type extensions.</span></span> <span data-ttu-id="628bb-154">ユーザーは、ファイルを右クリックし、**プログラムから開く**] オプションを選択し、候補の一覧に、アプリケーションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-154">If a user right-clicks a file and then selects the **Open with** option, your application appears in the list of suggestions.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-155">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-155">XML namespace</span></span>

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-156">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-156">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>"[file extension]"</FileType>
        </SupportedFileTypes>
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="628bb-157">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-157">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="628bb-158">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-158">Name</span></span> |<span data-ttu-id="628bb-159">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-159">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-160">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-160">Category</span></span> |<span data-ttu-id="628bb-161">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-161">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="628bb-162">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-162">Name</span></span> |<span data-ttu-id="628bb-163">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-163">A unique Id for your app.</span></span> <span data-ttu-id="628bb-164">この ID は、ファイルの種類の関連付けによって関連付けられたハッシュ対象の[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) を生成するために内部で使用されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-164">This Id is used internally to generate a hashed [programmatic identifier (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) associated with your file type association.</span></span> <span data-ttu-id="628bb-165">この ID を使って、アプリの今後のバージョンで変更を管理することができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-165">You can use this Id to manage changes in future versions of your app.</span></span>   |
|<span data-ttu-id="628bb-166">FileType</span><span class="sxs-lookup"><span data-stu-id="628bb-166">FileType</span></span> |<span data-ttu-id="628bb-167">アプリでサポートされているファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="628bb-167">The file extension supported by your app.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-168">例</span><span class="sxs-lookup"><span data-stu-id="628bb-168">Example</span></span>

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap, uap3">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <uap:SupportedFileTypes>
              <uap:FileType>.txt</uap:FileType>
              <uap:FileType>.avi</uap:FileType>
            </uap:SupportedFileTypes>
          </uap3:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

#### <a name="related-sample"></a><span data-ttu-id="628bb-169">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="628bb-169">Related sample</span></span>

[<span data-ttu-id="628bb-170">WPF picture viewer with transition/migration/uninstallation</span><span class="sxs-lookup"><span data-stu-id="628bb-170">WPF picture viewer with transition/migration/uninstallation</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<a id="add" />

### <a name="add-options-to-the-context-menus-of-files-that-have-a-certain-file-type"></a><span data-ttu-id="628bb-171">特定の種類のファイルのコンテキスト メニューにオプションを追加する</span><span class="sxs-lookup"><span data-stu-id="628bb-171">Add options to the context menus of files that have a certain file type</span></span>

<span data-ttu-id="628bb-172">ほとんどの場合、ユーザーはファイルをダブルクリックして開きます。</span><span class="sxs-lookup"><span data-stu-id="628bb-172">In most cases, users double-click files to open them.</span></span> <span data-ttu-id="628bb-173">ユーザーがファイルを右クリックすると、さまざまなオプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-173">If users, right click a file, various options appear.</span></span>

<span data-ttu-id="628bb-174">このメニューには、オプションを追加できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-174">You can add options to that menu.</span></span> <span data-ttu-id="628bb-175">これらのオプションを使用すると、ファイルの印刷、編集、プレビューなど、ファイルの操作を別の方法で行うことができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-175">These options give users other ways to interact with your file such as print, edit, or preview the file.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="628bb-176">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-176">XML namespaces</span></span>

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/2
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3


#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-177">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-177">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedVerbs>
              <Verb Id="[ID]" Extended="[Extended]" Parameters="[parameters]">"[verb label]"</Verb>
        </SupportedVerbs>
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="628bb-178">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-178">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="628bb-179">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-179">Name</span></span> |<span data-ttu-id="628bb-180">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-180">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-181">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-181">Category</span></span> | <span data-ttu-id="628bb-182">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-182">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="628bb-183">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-183">Name</span></span> |<span data-ttu-id="628bb-184">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-184">A unique Id for your app.</span></span> |
|<span data-ttu-id="628bb-185">Verb</span><span class="sxs-lookup"><span data-stu-id="628bb-185">Verb</span></span> |<span data-ttu-id="628bb-186">エクスプローラーのコンテキスト メニューに表示される名前です。</span><span class="sxs-lookup"><span data-stu-id="628bb-186">The name that appears in the File Explorer context menu.</span></span> <span data-ttu-id="628bb-187">この文字列は、```ms-resource``` を使用してローカライズできます。</span><span class="sxs-lookup"><span data-stu-id="628bb-187">This string is localizable that uses ```ms-resource```.</span></span>|
|<span data-ttu-id="628bb-188">Id</span><span class="sxs-lookup"><span data-stu-id="628bb-188">Id</span></span> |<span data-ttu-id="628bb-189">動詞の一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-189">The unique Id of the verb.</span></span> <span data-ttu-id="628bb-190">アプリが UWP アプリの場合は、ユーザーの選択内容を適切に処理できるようにアクティブ化イベント引数の一部としてアプリに渡されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-190">If your application is a UWP app, this is passed to your app as part of its activation event args so it can handle the user’s selection appropriately.</span></span> <span data-ttu-id="628bb-191">アプリが完全に信頼できるパッケージ アプリの場合は、パラメーターを受け取ります (次の項目をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="628bb-191">If your application is a full-trust packaged app, it receives parameters instead (see the next bullet).</span></span> |
|<span data-ttu-id="628bb-192">パラメーター</span><span class="sxs-lookup"><span data-stu-id="628bb-192">Parameters</span></span> |<span data-ttu-id="628bb-193">動詞に関連付けられている引数のパラメーターと値のリスト。</span><span class="sxs-lookup"><span data-stu-id="628bb-193">The list of argument parameters and values associated with the verb.</span></span> <span data-ttu-id="628bb-194">アプリが完全に信頼できるパッケージ アプリの場合は、アプリケーションがアクティブ化されるときに、これらのパラメーターがイベント引数としてアプリケーションに渡されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-194">If your application is a full-trust packaged app, these parameters are passed to the application as event args when the application is activated.</span></span> <span data-ttu-id="628bb-195">さまざまなアクティブ化の動詞に基づいてアプリの動作をカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-195">You can customize the behavior of your application based on different activation verbs.</span></span> <span data-ttu-id="628bb-196">変数にファイル パスが含まれる可能性がある場合は、パラメーター値を引用符で囲みます。</span><span class="sxs-lookup"><span data-stu-id="628bb-196">If a variable can contain a file path, wrap the parameter value in quotes.</span></span> <span data-ttu-id="628bb-197">これにより、パスにスペースが含まれている場合に発生する問題を回避できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-197">That will avoid any issues that happen in cases where the path includes spaces.</span></span> <span data-ttu-id="628bb-198">アプリが UWP アプリの場合は、パラメーターを渡すことはできません。</span><span class="sxs-lookup"><span data-stu-id="628bb-198">If your application is a UWP app, you can’t pass parameters.</span></span> <span data-ttu-id="628bb-199">アプリは、代わりに ID を受け取ります (前の項目を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="628bb-199">The app receives the Id instead (see the previous bullet).</span></span>|
|<span data-ttu-id="628bb-200">Extended</span><span class="sxs-lookup"><span data-stu-id="628bb-200">Extended</span></span> |<span data-ttu-id="628bb-201">ユーザーが **Shift** キーを押しながらファイルを右クリックすることでコンテキスト メニューを表示した場合にのみ表示される動詞を指定します。</span><span class="sxs-lookup"><span data-stu-id="628bb-201">Specifies that the verb appears only if the user shows the context menu by holding the **Shift** key before right-clicking the file.</span></span> <span data-ttu-id="628bb-202">この属性は省略可能であり、指定されていない場合の既定値は **False** (常に動詞を表示する) です。</span><span class="sxs-lookup"><span data-stu-id="628bb-202">This attribute is optional and defaults to a value of **False** (e.g., always show the verb) if not listed.</span></span> <span data-ttu-id="628bb-203">この動作は各動詞について個別に指定します ("開く" は例外で、常に **False**)。</span><span class="sxs-lookup"><span data-stu-id="628bb-203">You specify this behavior individually for each verb (except for "Open," which is always **False**).</span></span>|

#### <a name="example"></a><span data-ttu-id="628bb-204">例</span><span class="sxs-lookup"><span data-stu-id="628bb-204">Example</span></span>

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap2="http://schemas.microsoft.com/appx/manifest/uap/windows10/2"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"

  IgnorableNamespaces="uap, uap2, uap3">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <uap2:SupportedVerbs>
              <uap3:Verb Id="Edit" Parameters="/e &quot;%1&quot;">Edit</uap3:Verb>
              <uap3:Verb Id="Print" Extended="true" Parameters="/p &quot;%1&quot;">Print</uap3:Verb>
            </uap2:SupportedVerbs>
          </uap3:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
#### <a name="related-sample"></a><span data-ttu-id="628bb-205">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="628bb-205">Related sample</span></span>

[<span data-ttu-id="628bb-206">WPF picture viewer with transition/migration/uninstallation</span><span class="sxs-lookup"><span data-stu-id="628bb-206">WPF picture viewer with transition/migration/uninstallation</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<a id="open" />

### <a name="open-certain-types-of-files-directly-by-using-a-url"></a><span data-ttu-id="628bb-207">URL を使用して特定の種類のファイルを直接開く</span><span class="sxs-lookup"><span data-stu-id="628bb-207">Open certain types of files directly by using a URL</span></span>

<span data-ttu-id="628bb-208">ユーザーが既定では特定の種類のファイルを開くときに、アプリのデスクトップ バージョンではなく、新しいパッケージ化されたアプリケーションを開くことを確認することができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-208">You can make sure that users open your new packaged application by default for specific types of files instead of opening the desktop version of your app.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="628bb-209">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-209">XML namespaces</span></span>

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* <span data-ttu-id="628bb-210">http://schemas.microsoft.com/appx/manifest/uap/windows10/3"</span><span class="sxs-lookup"><span data-stu-id="628bb-210">http://schemas.microsoft.com/appx/manifest/uap/windows10/3"</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-211">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-211">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]" UseUrl="true" Parameters="%1">
        <SupportedFileTypes>
            <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes> 
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="628bb-212">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-212">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="628bb-213">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-213">Name</span></span> |<span data-ttu-id="628bb-214">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-214">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-215">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-215">Category</span></span> |<span data-ttu-id="628bb-216">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-216">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="628bb-217">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-217">Name</span></span> |<span data-ttu-id="628bb-218">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-218">A unique Id for your app.</span></span> |
|<span data-ttu-id="628bb-219">UseUrl</span><span class="sxs-lookup"><span data-stu-id="628bb-219">UseUrl</span></span> |<span data-ttu-id="628bb-220">URL ターゲットから直接ファイルを開くかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="628bb-220">Indicates whether to open files directly from a URL target.</span></span> <span data-ttu-id="628bb-221">この値を設定しない場合は、システムを使って URL 原因、最初のダウンロード ファイルをローカル ファイルを開くアプリケーションでしようとします。</span><span class="sxs-lookup"><span data-stu-id="628bb-221">If you do not set this value, attempts by your application to open a file by using a URL cause the system to first download the file locally.</span></span> |
|<span data-ttu-id="628bb-222">パラメーター</span><span class="sxs-lookup"><span data-stu-id="628bb-222">Parameters</span></span> |<span data-ttu-id="628bb-223">省略可能なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="628bb-223">optional parameters.</span></span> |
|<span data-ttu-id="628bb-224">FileType</span><span class="sxs-lookup"><span data-stu-id="628bb-224">FileType</span></span> |<span data-ttu-id="628bb-225">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="628bb-225">The relevant file extensions.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-226">例</span><span class="sxs-lookup"><span data-stu-id="628bb-226">Example</span></span>

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap, uap3">
  <Applications>
      <Application>
        <Extensions>
          <uap:Extension Category="windows.fileTypeAssociation">
            <uap3:FileTypeAssociation Name="documenttypes" UseUrl="true" Parameters="%1">
              <uap:SupportedFileTypes>
                <uap:FileType>.txt</uap:FileType>
                <uap:FileType>.doc</uap:FileType>
              </uap:SupportedFileTypes> 
            </uap3:FileTypeAssociation>
          </uap:Extension>
        </Extensions>
      </Application>
    </Applications>
</Package>
```

## <a name="perform-setup-tasks"></a><span data-ttu-id="628bb-227">セットアップ タスクを実行する</span><span class="sxs-lookup"><span data-stu-id="628bb-227">Perform setup tasks</span></span>

* [<span data-ttu-id="628bb-228">アプリのファイアウォール例外を作成する</span><span class="sxs-lookup"><span data-stu-id="628bb-228">Create firewall exception for your app</span></span>](#rules)
* [<span data-ttu-id="628bb-229">DLL ファイルをパッケージの任意のフォルダーに配置します。</span><span class="sxs-lookup"><span data-stu-id="628bb-229">Place your DLL files into any folder of the package</span></span>](#load-paths)

<a id="rules" />

### <a name="create-firewall-exception-for-your-app"></a><span data-ttu-id="628bb-230">アプリのファイアウォール例外を作成する</span><span class="sxs-lookup"><span data-stu-id="628bb-230">Create firewall exception for your app</span></span>

<span data-ttu-id="628bb-231">アプリケーションは、ポート経由で通信を必要とする場合は、ファイアウォールの例外の一覧にアプリを追加できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-231">If your application requires communication through a port, you can add your application to the list of firewall exceptions.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-232">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-232">XML namespace</span></span>

http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-233">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-233">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.firewallRules">  
  <FirewallRules Executable="[executable file name]">  
    <Rule
      Direction="[Direction]"
      IPProtocol="[Protocol]"
      LocalPortMin="[LocalPortMin]"
      LocalPortMax="LocalPortMax"
      RemotePortMin="RemotePortMin"
      RemotePortMax="RemotePortMax"
      Profile="[Profile]"/>  
  </FirewallRules>  
</Extension>
```
<span data-ttu-id="628bb-234">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-desktop2-firewallrules)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-234">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-desktop2-firewallrules).</span></span>

|<span data-ttu-id="628bb-235">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-235">Name</span></span> |<span data-ttu-id="628bb-236">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-236">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-237">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-237">Category</span></span> |<span data-ttu-id="628bb-238">常に </span><span class="sxs-lookup"><span data-stu-id="628bb-238">Always</span></span> ``windows.firewallRules``|
|<span data-ttu-id="628bb-239">Executable</span><span class="sxs-lookup"><span data-stu-id="628bb-239">Executable</span></span> |<span data-ttu-id="628bb-240">ファイアウォールの例外の一覧に追加する実行可能ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="628bb-240">The name of the executable file that you want to add to the list of firewall exceptions</span></span> |
|<span data-ttu-id="628bb-241">Direction</span><span class="sxs-lookup"><span data-stu-id="628bb-241">Direction</span></span> |<span data-ttu-id="628bb-242">規則が受信規則か送信規則かを示します。</span><span class="sxs-lookup"><span data-stu-id="628bb-242">Indicates whether the rule is an inbound or outbound rule</span></span> |
|<span data-ttu-id="628bb-243">IPProtocol</span><span class="sxs-lookup"><span data-stu-id="628bb-243">IPProtocol</span></span> |<span data-ttu-id="628bb-244">通信プロトコル。</span><span class="sxs-lookup"><span data-stu-id="628bb-244">The communication protocol</span></span> |
|<span data-ttu-id="628bb-245">LocalPortMin</span><span class="sxs-lookup"><span data-stu-id="628bb-245">LocalPortMin</span></span> |<span data-ttu-id="628bb-246">ローカル ポート番号の範囲を示すポート番号の下限。</span><span class="sxs-lookup"><span data-stu-id="628bb-246">The lower port number in a range of local port numbers.</span></span> |
|<span data-ttu-id="628bb-247">LocalPortMax</span><span class="sxs-lookup"><span data-stu-id="628bb-247">LocalPortMax</span></span> |<span data-ttu-id="628bb-248">ローカル ポート番号の範囲を示すポート番号の上限。</span><span class="sxs-lookup"><span data-stu-id="628bb-248">The highest port number of a range of local port numbers.</span></span> |
|<span data-ttu-id="628bb-249">RemotePortMax</span><span class="sxs-lookup"><span data-stu-id="628bb-249">RemotePortMax</span></span> |<span data-ttu-id="628bb-250">リモート ポート番号の範囲を示すポート番号の下限。</span><span class="sxs-lookup"><span data-stu-id="628bb-250">The lower port number in a range of remote port numbers.</span></span> |
|<span data-ttu-id="628bb-251">RemotePortMax</span><span class="sxs-lookup"><span data-stu-id="628bb-251">RemotePortMax</span></span> |<span data-ttu-id="628bb-252">リモート ポート番号の範囲を示すポート番号の上限。</span><span class="sxs-lookup"><span data-stu-id="628bb-252">The highest port number of a range of remote port numbers.</span></span> |
|<span data-ttu-id="628bb-253">Profile</span><span class="sxs-lookup"><span data-stu-id="628bb-253">Profile</span></span> |<span data-ttu-id="628bb-254">ネットワークの種類。</span><span class="sxs-lookup"><span data-stu-id="628bb-254">The network type</span></span> |



#### <a name="example"></a><span data-ttu-id="628bb-255">例</span><span class="sxs-lookup"><span data-stu-id="628bb-255">Example</span></span>

```XML
<Package
  xmlns:desktop2="http://schemas.microsoft.com/appx/manifest/desktop/windows10/2"
  IgnorableNamespaces="desktop2">
  <Extensions>
    <desktop2:Extension Category="windows.firewallRules">  
      <desktop2:FirewallRules Executable="Contoso.exe">  
          <desktop2:Rule Direction="in" IPProtocol="TCP" Profile="all"/>  
          <desktop2:Rule Direction="in" IPProtocol="UDP" LocalPortMin="1337" LocalPortMax="1338" Profile="domain"/>  
          <desktop2:Rule Direction="in" IPProtocol="UDP" LocalPortMin="1337" LocalPortMax="1338" Profile="public"/>  
          <desktop2:Rule Direction="out" IPProtocol="UDP" LocalPortMin="1339" LocalPortMax="1340" RemotePortMin="15"
                         RemotePortMax="19" Profile="domainAndPrivate"/>  
          <desktop2:Rule Direction="out" IPProtocol="GRE" Profile="private"/>  
      </desktop2:FirewallRules>  
  </desktop2:Extension>
</Extensions>
</Package>
```

<a id="load-paths" />

### <a name="place-your-dll-files-into-any-folder-of-the-package"></a><span data-ttu-id="628bb-256">DLL ファイルをパッケージの任意のフォルダーに配置します。</span><span class="sxs-lookup"><span data-stu-id="628bb-256">Place your DLL files into any folder of the package</span></span>

<span data-ttu-id="628bb-257">拡張機能を使ってそれらのフォルダーを指定します。</span><span class="sxs-lookup"><span data-stu-id="628bb-257">Use an extension to identify those folders.</span></span> <span data-ttu-id="628bb-258">これにより、システムは配置したファイルを見つけて読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-258">That way, the system can find and load the files that you place in them.</span></span> <span data-ttu-id="628bb-259">この拡張機能は、_%PATH%_ 環境変数の置き換えと考えてください。</span><span class="sxs-lookup"><span data-stu-id="628bb-259">Think of this extension as a replacement of the _%PATH%_ environment variable.</span></span>

<span data-ttu-id="628bb-260">この拡張機能を使わない場合、システムはプロセスのパッケージの依存関係グラフ、パッケージ ルート フォルダー、システム ディレクトリ (_%SystemRoot%\system32_) の順で検索します。</span><span class="sxs-lookup"><span data-stu-id="628bb-260">If you don't use this extension, the system searches the package dependency graph of the process, the package root folder, and then the system directory (_%SystemRoot%\system32_) in that order.</span></span> <span data-ttu-id="628bb-261">詳しくは、[Windows アプリの検索順序に関するページ](https://msdn.microsoft.com/library/windows/desktop/ms682586.aspx#_search_order_for_windows_store_apps)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-261">To learn more, see [Search order of Windows apps](https://msdn.microsoft.com/library/windows/desktop/ms682586.aspx#_search_order_for_windows_store_apps).</span></span>

<span data-ttu-id="628bb-262">各パッケージには、これらの拡張機能を 1 つだけ含めることができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-262">Each package can contain only one of these extensions.</span></span> <span data-ttu-id="628bb-263">つまり、1 つをメイン パッケージに追加し、他の拡張機能は[オプション パッケージと関連するセット](https://docs.microsoft.com/windows/uwp/packaging/optional-packages)それぞれに 1 つずつ追加できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-263">That means that you can add one of them to your main package, and then add one to each of your [optional packages, and related sets](https://docs.microsoft.com/windows/uwp/packaging/optional-packages).</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-264">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-264">XML namespace</span></span>

http://schemas.microsoft.com/appx/manifest/uap/windows10/6

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-265">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-265">Elements and attributes of this extension</span></span>
<span data-ttu-id="628bb-266">アプリケーション マニフェストのパッケージ レベルでこの拡張機能を宣言します。</span><span class="sxs-lookup"><span data-stu-id="628bb-266">Declare this extension at the package-level of your app manifest.</span></span>

```XML
<Extension Category="windows.loaderSearchPathOverride">
  <LoaderSearchPathOverride>
    <LoaderSearchPathEntry FolderPath="[path]"/>
  </LoaderSearchPathOverride>
</Extension>

```

|<span data-ttu-id="628bb-267">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-267">Name</span></span> | <span data-ttu-id="628bb-268">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-268">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-269">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-269">Category</span></span> |<span data-ttu-id="628bb-270">常に ``windows.loaderSearchPathOverride`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-270">Always ``windows.loaderSearchPathOverride``.</span></span>
|<span data-ttu-id="628bb-271">FolderPath</span><span class="sxs-lookup"><span data-stu-id="628bb-271">FolderPath</span></span> | <span data-ttu-id="628bb-272">dll ファイルが含まれているフォルダーのパス。</span><span class="sxs-lookup"><span data-stu-id="628bb-272">The path of the folder that contains your dll files.</span></span> <span data-ttu-id="628bb-273">パッケージのルート フォルダーの相対パスを指定します。</span><span class="sxs-lookup"><span data-stu-id="628bb-273">Specify a path that is relative to the root folder of the package.</span></span> <span data-ttu-id="628bb-274">1 つの拡張機能で最大 5 つのパスを指定できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-274">You can specify up to five paths in one extension.</span></span> <span data-ttu-id="628bb-275">システムがパッケージのルート フォルダーにあるファイルを検索するようにする場合、これらのパスのいずれかに空の文字列を使用します。</span><span class="sxs-lookup"><span data-stu-id="628bb-275">If you want the system to search for files in the root folder of the package, use an empty string for one of these paths.</span></span> <span data-ttu-id="628bb-276">重複するパスを含めないでください。パスの先頭と末尾にスラッシュや円記号を使わないでください。</span><span class="sxs-lookup"><span data-stu-id="628bb-276">Don't included duplicate paths and make sure that your paths don't contain leading and trailing slashes or backslashes.</span></span> <br><br> <span data-ttu-id="628bb-277">システムはサブフォルダーを検索しないため、システムが読み込む DLL ファイルが含まれている各フォルダーを明示的に一覧表示してください。</span><span class="sxs-lookup"><span data-stu-id="628bb-277">The system won't search subfolders, so make sure to explicitly list each folder that contains DLL files that you want the system to load.</span></span>|

#### <a name="example"></a><span data-ttu-id="628bb-278">例</span><span class="sxs-lookup"><span data-stu-id="628bb-278">Example</span></span>

```XML
<Package
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/6"
  IgnorableNamespaces="uap6">
  ...
    <Extensions>
      <uap6:Extension Category="windows.loaderSearchPathOverride">
        <uap6:LoaderSearchPathOverride>
          <uap6:LoaderSearchPathEntry FolderPath=""/>
          <uap6:LoaderSearchPathEntry FolderPath="folder1/subfolder1"/>
          <uap6:LoaderSearchPathEntry FolderPath="folder2/subfolder2"/>
        </uap6:LoaderSearchPathOverride>
      </uap6:Extension>
    </Extensions>
...
</Package>
```

## <a name="integrate-with-file-explorer"></a><span data-ttu-id="628bb-279">エクスプローラーに統合する</span><span class="sxs-lookup"><span data-stu-id="628bb-279">Integrate with File Explorer</span></span>

<span data-ttu-id="628bb-280">ユーザーが慣れた方法でファイルを整理し操作できるようになります。</span><span class="sxs-lookup"><span data-stu-id="628bb-280">Help users organize your files and interact with them in familiar ways.</span></span>

* [<span data-ttu-id="628bb-281">ユーザーが選択し、同時に複数のファイルを開くときに、アプリケーションの動作を定義します。</span><span class="sxs-lookup"><span data-stu-id="628bb-281">Define how your application behaves when users select and open multiple files at the same time</span></span>](#define)
* [<span data-ttu-id="628bb-282">エクスプ ローラーでサムネイル画像のファイル内容を表示する</span><span class="sxs-lookup"><span data-stu-id="628bb-282">Show file contents in a thumbnail image within File Explorer</span></span>](#show)
* [<span data-ttu-id="628bb-283">エクスプローラーのプレビュー ウィンドウにファイル内容を表示する</span><span class="sxs-lookup"><span data-stu-id="628bb-283">Show file contents in a Preview pane of File Explorer</span></span>](#preview)
* [<span data-ttu-id="628bb-284">ユーザーがエクスプローラーの [種類] 列を使用してファイルをグループ化できるようにする</span><span class="sxs-lookup"><span data-stu-id="628bb-284">Enable users to group files by using the Kind column in File Explorer</span></span>](#enable)
* [<span data-ttu-id="628bb-285">ファイルのプロパティを検索、インデックス、プロパティ ダイアログ、詳細ウィンドウに利用できるようにする</span><span class="sxs-lookup"><span data-stu-id="628bb-285">Make file properties available to search, index, property dialogs, and the details pane</span></span>](#make-file-properties)
* [<span data-ttu-id="628bb-286">クラウド サービスのファイルがエクスプローラーに表示されるようにする</span><span class="sxs-lookup"><span data-stu-id="628bb-286">Make files from your cloud service appear in File Explorer</span></span>](#cloud-files)

<a id="define" />

### <a name="define-how-your-application-behaves-when-users-select-and-open-multiple-files-at-the-same-time"></a><span data-ttu-id="628bb-287">ユーザーが選択し、同時に複数のファイルを開くときに、アプリケーションの動作を定義します。</span><span class="sxs-lookup"><span data-stu-id="628bb-287">Define how your application behaves when users select and open multiple files at the same time</span></span>

<span data-ttu-id="628bb-288">ユーザーが同時に複数のファイルを開いたときに、アプリケーションの動作を指定します。</span><span class="sxs-lookup"><span data-stu-id="628bb-288">Specify how your application behaves when a user opens multiple files simultaneously.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="628bb-289">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-289">XML namespaces</span></span>

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/2
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-290">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-290">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]" MultiSelectModel="[SelectionModel]">
        <SupportedVerbs>
            <Verb Id="Edit" MultiSelectModel="[SelectionModel]">Edit</Verb>
        </SupportedVerbs>
          <SupportedFileTypes>
                <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes>
</Extension>
```
<span data-ttu-id="628bb-291">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-291">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="628bb-292">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-292">Name</span></span> |<span data-ttu-id="628bb-293">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-293">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-294">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-294">Category</span></span> |<span data-ttu-id="628bb-295">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-295">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="628bb-296">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-296">Name</span></span> |<span data-ttu-id="628bb-297">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-297">A unique Id for your app.</span></span> |
|<span data-ttu-id="628bb-298">MultiSelectModel</span><span class="sxs-lookup"><span data-stu-id="628bb-298">MultiSelectModel</span></span> |<span data-ttu-id="628bb-299">下を参照</span><span class="sxs-lookup"><span data-stu-id="628bb-299">See below</span></span> |
|<span data-ttu-id="628bb-300">FileType</span><span class="sxs-lookup"><span data-stu-id="628bb-300">FileType</span></span> |<span data-ttu-id="628bb-301">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="628bb-301">The relevant file extensions.</span></span> |

**<span data-ttu-id="628bb-302">MultSelectModel</span><span class="sxs-lookup"><span data-stu-id="628bb-302">MultSelectModel</span></span>**

<span data-ttu-id="628bb-303">パッケージ デスクトップ アプリには、通常のデスクトップ アプリと同じ 3 つのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="628bb-303">packaged desktop apps have the same three options as regular desktop apps.</span></span>

 * ``Player``<span data-ttu-id="628bb-304">: アプリケーションは、1 回アクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-304">: Your application is activated one time.</span></span> <span data-ttu-id="628bb-305">すべての選択したファイルは、引数パラメーターとして、アプリケーションに渡されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-305">All of the selected files are passed to your application as argument parameters.</span></span>
 * ``Single``<span data-ttu-id="628bb-306">: アプリケーションは、最初に選択したファイルに 1 回アクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-306">: Your application is activated one time for the first selected file.</span></span> <span data-ttu-id="628bb-307">その他のファイルは無視されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-307">Other files are ignored.</span></span>
 * ``Document``<span data-ttu-id="628bb-308">選択された各ファイルについては、アプリケーションの: 新しい別のインスタンスがアクティブ化します。</span><span class="sxs-lookup"><span data-stu-id="628bb-308">: A new, separate instance of your application is activated for each selected file.</span></span>

 <span data-ttu-id="628bb-309">ファイルの種類やアクションごとに、さまざまな環境設定項目を設定できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-309">You can set different preferences for different file types and actions.</span></span> <span data-ttu-id="628bb-310">たとえば、*Documents* は *Document* モードで開き、*Images* は *Player* モードで開くことができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-310">For example, you may wish to open *Documents* in *Document* mode and *Images* in *Player* mode.</span></span>

#### <a name="example"></a><span data-ttu-id="628bb-311">例</span><span class="sxs-lookup"><span data-stu-id="628bb-311">Example</span></span>

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap2="http://schemas.microsoft.com/appx/manifest/uap/windows10/2"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap, uap2, uap3">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="myapp" MultiSelectModel="Document">
            <uap2:SupportedVerbs>
              <uap3:Verb Id="Edit" MultiSelectModel="Player">Edit</uap3:Verb>
              <uap3:Verb Id="Preview" MultiSelectModel="Document">Preview</uap3:Verb>
            </uap2:SupportedVerbs>
            <uap:SupportedFileTypes>
                <uap:FileType>.txt</uap:FileType>
            </uap:SupportedFileTypes>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

<span data-ttu-id="628bb-312">ユーザーが 15 個以下のファイルを開いた場合、**MultiSelectModel** 属性の既定値は *Player* になります。</span><span class="sxs-lookup"><span data-stu-id="628bb-312">If the user opens 15 or fewer files, the default choice for the **MultiSelectModel** attribute is *Player*.</span></span> <span data-ttu-id="628bb-313">それ以外の場合、既定値は *Document* です。</span><span class="sxs-lookup"><span data-stu-id="628bb-313">Otherwise, the default is *Document*.</span></span> <span data-ttu-id="628bb-314">UWP アプリは常に *Player* として起動されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-314">UWP apps are always started as *Player*.</span></span>

<a id="show" />

### <a name="show-file-contents-in-a-thumbnail-image-within-file-explorer"></a><span data-ttu-id="628bb-315">エクスプ ローラーでサムネイル画像のファイル内容を表示する</span><span class="sxs-lookup"><span data-stu-id="628bb-315">Show file contents in a thumbnail image within File Explorer</span></span>

<span data-ttu-id="628bb-316">ファイルが中アイコン、大アイコン、特大アイコンで表示された場合に、ファイル内容のサムネイル画像をユーザーが確認できるようにします。</span><span class="sxs-lookup"><span data-stu-id="628bb-316">Enable users to view a thumbnail image of the file's contents when the icon of the file appears in the medium, large, or extra large size.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-317">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-317">XML namespace</span></span>

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/2
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3
* http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-318">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-318">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes>
        <ThumbnailHandler
            Clsid  ="[Clsid  ]" />
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="628bb-319">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-319">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="628bb-320">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-320">Name</span></span> |<span data-ttu-id="628bb-321">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-321">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-322">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-322">Category</span></span> |<span data-ttu-id="628bb-323">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-323">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="628bb-324">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-324">Name</span></span> |<span data-ttu-id="628bb-325">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-325">A unique Id for your app.</span></span> |
|<span data-ttu-id="628bb-326">FileType</span><span class="sxs-lookup"><span data-stu-id="628bb-326">FileType</span></span> |<span data-ttu-id="628bb-327">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="628bb-327">The relevant file extensions.</span></span> |
|<span data-ttu-id="628bb-328">Clsid</span><span class="sxs-lookup"><span data-stu-id="628bb-328">Clsid</span></span>   |<span data-ttu-id="628bb-329">アプリのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-329">The class ID of your app.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-330">例</span><span class="sxs-lookup"><span data-stu-id="628bb-330">Example</span></span>

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap2="http://schemas.microsoft.com/appx/manifest/uap/windows10/2"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:desktop2="http://schemas.microsoft.com/appx/manifest/desktop/windows10/2"
  IgnorableNamespaces="uap, uap2, uap3, desktop2">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <uap2:SupportedFileTypes>
              <uap:FileType>.bar</uap:FileType>
            </uap2:SupportedFileTypes>
            <desktop2:ThumbnailHandler
              Clsid  ="20000000-0000-0000-0000-000000000001"  />
            </uap3:FileTypeAssociation>
         </uap::Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

<a id="preview" />

### <a name="show-file-contents-in-the-preview-pane-of-file-explorer"></a><span data-ttu-id="628bb-331">エクスプローラーのプレビュー ウィンドウにファイル内容を表示する</span><span class="sxs-lookup"><span data-stu-id="628bb-331">Show file contents in the Preview pane of File Explorer</span></span>

<span data-ttu-id="628bb-332">エクスプローラーのプレビュー ウィンドウで、ユーザーがファイルの内容をプレビューできるようにします。</span><span class="sxs-lookup"><span data-stu-id="628bb-332">Enable users to preview a file's contents in the Preview pane of File Explorer.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-333">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-333">XML namespace</span></span>

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/2
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3
* http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-334">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-334">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes>
        <DesktopPreviewHandler Clsid  ="[Clsid  ]" />
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="628bb-335">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-335">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="628bb-336">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-336">Name</span></span> |<span data-ttu-id="628bb-337">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-337">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-338">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-338">Category</span></span> |<span data-ttu-id="628bb-339">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-339">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="628bb-340">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-340">Name</span></span> |<span data-ttu-id="628bb-341">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-341">A unique Id for your app.</span></span> |
|<span data-ttu-id="628bb-342">FileType</span><span class="sxs-lookup"><span data-stu-id="628bb-342">FileType</span></span> |<span data-ttu-id="628bb-343">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="628bb-343">The relevant file extensions.</span></span> |
|<span data-ttu-id="628bb-344">Clsid</span><span class="sxs-lookup"><span data-stu-id="628bb-344">Clsid</span></span>   |<span data-ttu-id="628bb-345">アプリのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-345">The class ID of your app.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-346">例</span><span class="sxs-lookup"><span data-stu-id="628bb-346">Example</span></span>

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap2="http://schemas.microsoft.com/appx/manifest/uap/windows10/2"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:desktop2="http://schemas.microsoft.com/appx/manifest/desktop/windows10/2"
  IgnorableNamespaces="uap, uap2, uap3, desktop2">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <uap2SupportedFileTypes>
              <uap:FileType>.bar</uap:FileType>
                </uap2SupportedFileTypes>
              <desktop2:DesktopPreviewHandler Clsid ="20000000-0000-0000-0000-000000000001" />
           </uap3:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

<a id="enable" />

### <a name="enable-users-to-group-files-by-using-the-kind-column-in-file-explorer"></a><span data-ttu-id="628bb-347">ユーザーがエクスプローラーの [種類] 列を使用してファイルをグループ化できるようにする</span><span class="sxs-lookup"><span data-stu-id="628bb-347">Enable users to group files by using the Kind column in File Explorer</span></span>

<span data-ttu-id="628bb-348">ファイルの種類に関する 1 つまたは複数の定義済みの値を **Kind** フィールドに関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-348">You can associate one or more predefined values for your file types with the **Kind** field.</span></span>

<span data-ttu-id="628bb-349">ユーザーはエクスプローラーでこのフィールドを使用して、ファイルをグループ化できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-349">In File Explorer, users can group those files by using that field.</span></span> <span data-ttu-id="628bb-350">また、このフィールドは、システム コンポーネントによって、インデックス作成などのさまざまな目的にも使用されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-350">System components also use this field for various purposes such as indexing.</span></span>

<span data-ttu-id="628bb-351">**Kind** フィールドの詳細と、このフィールドに使用できる値については、「[種類名の使用](https://msdn.microsoft.com/library/windows/desktop/cc144136.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-351">For more information about the **Kind** field and the values that you can use for this field, see [Using Kind Names](https://msdn.microsoft.com/library/windows/desktop/cc144136.aspx).</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="628bb-352">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-352">XML namespaces</span></span>

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-353">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-353">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes>
        <KindMap>
            <Kind value="[KindValue]">
        </KindMap>
    </FileTypeAssociation>
</Extension>
```
<span data-ttu-id="628bb-354">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-354">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="628bb-355">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-355">Name</span></span> |<span data-ttu-id="628bb-356">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-356">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-357">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-357">Category</span></span> |<span data-ttu-id="628bb-358">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-358">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="628bb-359">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-359">Name</span></span> |<span data-ttu-id="628bb-360">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-360">A unique Id for your app.</span></span> |
|<span data-ttu-id="628bb-361">FileType</span><span class="sxs-lookup"><span data-stu-id="628bb-361">FileType</span></span> |<span data-ttu-id="628bb-362">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="628bb-362">The relevant file extensions.</span></span> |
|<span data-ttu-id="628bb-363">value</span><span class="sxs-lookup"><span data-stu-id="628bb-363">value</span></span> |<span data-ttu-id="628bb-364">有効な [Kind 値](https://msdn.microsoft.com/en-us/library/windows/desktop/cc144136.aspx#kind_hierarchy)。</span><span class="sxs-lookup"><span data-stu-id="628bb-364">A valid [Kind value](https://msdn.microsoft.com/en-us/library/windows/desktop/cc144136.aspx#kind_hierarchy)</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-365">例</span><span class="sxs-lookup"><span data-stu-id="628bb-365">Example</span></span>

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3"
  IgnorableNamespaces="uap, rescap">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
           <uap:FileTypeAssociation Name="Contoso">
             <uap:SupportedFileTypes>
               <uap:FileType>.m4a</uap:FileType>
               <uap:FileType>.mta</uap:FileType>
             </uap:SupportedFileTypes>
             <rescap:KindMap>
               <rescap:Kind value="Item">
               <rescap:Kind value="Communications">
               <rescap:Kind value="Task">
             </rescap:KindMap>
          </uap:FileTypeAssociation>
      </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
<a id="make-file-properties" />

### <a name="make-file-properties-available-to-search-index-property-dialogs-and-the-details-pane"></a><span data-ttu-id="628bb-366">ファイルのプロパティを検索、インデックス、プロパティ ダイアログ、詳細ウィンドウに利用できるようにする</span><span class="sxs-lookup"><span data-stu-id="628bb-366">Make file properties available to search, index, property dialogs, and the details pane</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-367">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-367">XML namespace</span></span>

* http://schemas.microsoft.com/appx/manifest/uap/windows10
* http://schemas.microsoft.com/appx/manifest/uap/windows10/3
* http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-368">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-368">Elements and attributes of this extension</span></span>

```XML
<uap:Extension Category="windows.fileTypeAssociation">
    <uap:FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>.bar</FileType>
        </SupportedFileTypes>
        <DesktopPropertyHandler Clsid ="[Clsid]"/>
    </uap:FileTypeAssociation>
</uap:Extension>
```
<span data-ttu-id="628bb-369">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-369">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="628bb-370">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-370">Name</span></span> |<span data-ttu-id="628bb-371">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-371">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-372">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-372">Category</span></span> |<span data-ttu-id="628bb-373">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-373">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="628bb-374">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-374">Name</span></span> |<span data-ttu-id="628bb-375">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-375">A unique Id for your app.</span></span> |
|<span data-ttu-id="628bb-376">FileType</span><span class="sxs-lookup"><span data-stu-id="628bb-376">FileType</span></span> |<span data-ttu-id="628bb-377">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="628bb-377">The relevant file extensions.</span></span> |
|<span data-ttu-id="628bb-378">Clsid</span><span class="sxs-lookup"><span data-stu-id="628bb-378">Clsid</span></span>  |<span data-ttu-id="628bb-379">アプリのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-379">The class ID of your app.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-380">例</span><span class="sxs-lookup"><span data-stu-id="628bb-380">Example</span></span>

```XML
<Package
  xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:desktop2="http://schemas.microsoft.com/appx/manifest/desktop/windows10/2"
  IgnorableNamespaces="uap, uap3, desktop2">
  <Applications>
    <Application>
      <Extensions>
        <uap:Extension Category="windows.fileTypeAssociation">
          <uap3:FileTypeAssociation Name="Contoso">
            <uap:SupportedFileTypes>
              <uap:FileType>.bar</uap:FileType>
            </uap:SupportedFileTypes>
            <desktop2:DesktopPropertyHandler Clsid ="20000000-0000-0000-0000-000000000001"/>
          </uap3:FileTypeAssociation>
        </uap:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

<a id="cloud-files" />

### <a name="make-files-from-your-cloud-service-appear-in-file-explorer"></a><span data-ttu-id="628bb-381">クラウド サービスのファイルがエクスプローラーに表示されるようにする</span><span class="sxs-lookup"><span data-stu-id="628bb-381">Make files from your cloud service appear in File Explorer</span></span>

<span data-ttu-id="628bb-382">アプリに実装するハンドラーを登録する</span><span class="sxs-lookup"><span data-stu-id="628bb-382">Register the handlers that you implement in your application.</span></span> <span data-ttu-id="628bb-383">ユーザーがエクスプローラーでクラウド ベースのファイルを右クリックしたときに表示されるコンテキスト メニュー オプションを追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="628bb-383">You can also add context menu options that appear when you users right-click your cloud-based files in File Explorer.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-384">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-384">XML namespace</span></span>

* http://schemas.microsoft.com/appx/manifest/desktop/windows10

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-385">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-385">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.cloudfiles" >
    <CloudFiles IconResource="[Icon]">
        <CustomStateHandler Clsid ="[Clsid]"/>
        <ThumbnailProviderHandler Clsid ="[Clsid]"/>
        <ExtendedPropertyhandler Clsid ="[Clsid]"/>
        <CloudFilesContextMenus>
            <Verb Id ="Command3" Clsid= "[GUID]">[Verb Label]</Verb>
        </CloudFilesContextMenus>
    </CloudFiles>
</Extension>

```

|<span data-ttu-id="628bb-386">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-386">Name</span></span> |<span data-ttu-id="628bb-387">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-387">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-388">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-388">Category</span></span> |<span data-ttu-id="628bb-389">常に ``windows.cloudfiles`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-389">Always ``windows.cloudfiles``.</span></span>
|<span data-ttu-id="628bb-390">iconResource</span><span class="sxs-lookup"><span data-stu-id="628bb-390">iconResource</span></span> |<span data-ttu-id="628bb-391">クラウド ファイル プロバイダー サービスを表すアイコン。</span><span class="sxs-lookup"><span data-stu-id="628bb-391">The icon that represents your cloud file provider service.</span></span> <span data-ttu-id="628bb-392">このアイコンは、エクスプローラーのナビゲーション ウィンドウに表示されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-392">This icon appears in the Navigation pane of File Explorer.</span></span>  <span data-ttu-id="628bb-393">ユーザーは、このアイコンを選んでクラウド サービスのファイルを表示します。</span><span class="sxs-lookup"><span data-stu-id="628bb-393">Users choose this icon to show files from your cloud service.</span></span> |
|<span data-ttu-id="628bb-394">CustomStateHandler Clsid</span><span class="sxs-lookup"><span data-stu-id="628bb-394">CustomStateHandler Clsid</span></span> |<span data-ttu-id="628bb-395">CustomStateHandler を実装するアプリケーションのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-395">The class ID of the application that implements the CustomStateHandler.</span></span> <span data-ttu-id="628bb-396">システムは、このクラス ID を使ってクラウド ファイルのカスタム状態と列を要求します。</span><span class="sxs-lookup"><span data-stu-id="628bb-396">The system uses this Class ID to request custom states and columns for cloud files.</span></span> |
|<span data-ttu-id="628bb-397">ThumbnailProviderHandler Clsid</span><span class="sxs-lookup"><span data-stu-id="628bb-397">ThumbnailProviderHandler Clsid</span></span> |<span data-ttu-id="628bb-398">ThumbnailProviderHandler を実装するアプリケーションのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-398">The class ID of the application that implements the ThumbnailProviderHandler.</span></span> <span data-ttu-id="628bb-399">システムは、このクラス ID を使ってクラウド ファイルの縮小版イメージを要求します。</span><span class="sxs-lookup"><span data-stu-id="628bb-399">The system uses this Class ID to request thumbnail images for cloud files.</span></span> |
|<span data-ttu-id="628bb-400">ExtendedPropertyHandler Clsid</span><span class="sxs-lookup"><span data-stu-id="628bb-400">ExtendedPropertyHandler Clsid</span></span> |<span data-ttu-id="628bb-401">ExtendedPropertyHandler を実装するアプリケーションのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-401">The class ID of the application that implements the ExtendedPropertyHandler.</span></span>  <span data-ttu-id="628bb-402">システムは、このクラス ID を使ってクラウド ファイルの拡張プロパティを要求します。</span><span class="sxs-lookup"><span data-stu-id="628bb-402">The system uses this Class ID to request extended properties for a cloud file.</span></span> |
|<span data-ttu-id="628bb-403">Verb</span><span class="sxs-lookup"><span data-stu-id="628bb-403">Verb</span></span> |<span data-ttu-id="628bb-404">クラウド サービスによって提供されるファイルのエクスプローラー コンテキスト メニューに表示される名前です。</span><span class="sxs-lookup"><span data-stu-id="628bb-404">The name that appears in the File Explorer context menu for files provided by your cloud service.</span></span> |
|<span data-ttu-id="628bb-405">Id</span><span class="sxs-lookup"><span data-stu-id="628bb-405">Id</span></span> |<span data-ttu-id="628bb-406">動詞の一意の ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-406">The unique ID of the verb.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-407">例</span><span class="sxs-lookup"><span data-stu-id="628bb-407">Example</span></span>

```XML
<Package
    xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10"
    IgnorableNamespaces="desktop">
  <Applications>
    <Application>
      <Extensions>
        <Extension Category="windows.cloudfiles" >
            <CloudFiles IconResource="images\Wide310x150Logo.png">
                <CustomStateHandler Clsid ="20000000-0000-0000-0000-000000000001"/>
                <ThumbnailProviderHandler Clsid ="20000000-0000-0000-0000-000000000001"/>
                <ExtendedPropertyhandler Clsid ="20000000-0000-0000-0000-000000000001"/>
                <desktop:CloudFilesContextMenus>
                    <desktop:Verb Id ="keep" Clsid=     
                       "20000000-0000-0000-0000-000000000001">
                       Always keep on this device</desktop:Verb>
                </desktop:CloudFilesContextMenus>
            </CloudFiles>
          </Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

<a id="start" />

## <a name="start-your-application-in-different-ways"></a><span data-ttu-id="628bb-408">さまざまな方法でアプリケーションを起動します。</span><span class="sxs-lookup"><span data-stu-id="628bb-408">Start your application in different ways</span></span>

* [<span data-ttu-id="628bb-409">プロトコルを使用してアプリケーションを起動します。</span><span class="sxs-lookup"><span data-stu-id="628bb-409">Start your application by using a protocol</span></span>](#protocol)
* [<span data-ttu-id="628bb-410">エイリアスを使用して、アプリケーションを起動します。</span><span class="sxs-lookup"><span data-stu-id="628bb-410">Start your application by using an alias</span></span>](#alias)
* [<span data-ttu-id="628bb-411">ユーザーが Windows にログオンしたときに実行可能ファイルを起動する</span><span class="sxs-lookup"><span data-stu-id="628bb-411">Start an executable file when users log into Windows</span></span>](#executable)
* [<span data-ttu-id="628bb-412">デバイスを自分の PC に接続するときに、アプリケーションを起動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="628bb-412">Enable users to start your application when they connect a device to their PC</span></span>](#autoplay)
* [<span data-ttu-id="628bb-413">Microsoft Store から更新プログラムを受信した後、自動的に再起動する</span><span class="sxs-lookup"><span data-stu-id="628bb-413">Restart automatically after receiving an update from the Microsoft Store</span></span>](#updates)

<a id="protocol" />

### <a name="start-your-application-by-using-a-protocol"></a><span data-ttu-id="628bb-414">プロトコルを使用してアプリケーションを起動します。</span><span class="sxs-lookup"><span data-stu-id="628bb-414">Start your application by using a protocol</span></span>

<span data-ttu-id="628bb-415">プロトコルの関連付けによって、他のプログラムやシステム コンポーネントがパッケージ アプリと相互運用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="628bb-415">Protocol associations can enable other programs and system components to interoperate with your packaged app.</span></span> <span data-ttu-id="628bb-416">プロトコルを使用してパッケージ化されたアプリケーションが開始されると、それに応じて動作ことができるように、アクティブ化イベント引数に渡す特定のパラメーターを指定できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-416">When your packaged application is started by using a protocol, you can specify specific parameters to pass to its activation event arguments so it can behave accordingly.</span></span> <span data-ttu-id="628bb-417">パラメーターは、完全に信頼できるパッケージ アプリでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="628bb-417">Parameters are supported only for packaged, full-trust apps.</span></span> <span data-ttu-id="628bb-418">UWP アプリでは、パラメーターを使用できません。</span><span class="sxs-lookup"><span data-stu-id="628bb-418">UWP apps can't use parameters.</span></span>  

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-419">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-419">XML namespace</span></span>

http://schemas.microsoft.com/appx/manifest/uap/windows10/3


#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-420">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-420">Elements and attributes of this extension</span></span>

```XML
<Extension
    Category="windows.protocol">
    <Protocol
      Name="[Protocol name]"
      Parameters="[Parameters]" />
</Extension>
```

<span data-ttu-id="628bb-421">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-protocol)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-421">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-protocol).</span></span>

|<span data-ttu-id="628bb-422">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-422">Name</span></span> |<span data-ttu-id="628bb-423">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-423">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-424">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-424">Category</span></span> |<span data-ttu-id="628bb-425">常に ``windows.protocol`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-425">Always ``windows.protocol``.</span></span>
|<span data-ttu-id="628bb-426">Name</span><span class="sxs-lookup"><span data-stu-id="628bb-426">Name</span></span> |<span data-ttu-id="628bb-427">プロトコルの名前。</span><span class="sxs-lookup"><span data-stu-id="628bb-427">The name of the protocol.</span></span> |
|<span data-ttu-id="628bb-428">パラメーター</span><span class="sxs-lookup"><span data-stu-id="628bb-428">Parameters</span></span> |<span data-ttu-id="628bb-429">パラメーターと、アプリケーションがアクティブ化されるときにイベント引数としてアプリに渡す値の一覧。</span><span class="sxs-lookup"><span data-stu-id="628bb-429">The list of parameters and values to pass to your application as event arguments when the application is activated.</span></span> <span data-ttu-id="628bb-430">変数にファイル パスが含まれる可能性がある場合は、パラメーター値を引用符で囲みます。</span><span class="sxs-lookup"><span data-stu-id="628bb-430">If a variable can contain a file path, wrap the parameter value in quotes.</span></span> <span data-ttu-id="628bb-431">これにより、パスにスペースが含まれている場合に発生する問題を回避できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-431">That will avoid any issues that happen in cases where the path includes spaces.</span></span> |

### <a name="example"></a><span data-ttu-id="628bb-432">例</span><span class="sxs-lookup"><span data-stu-id="628bb-432">Example</span></span>

```XML
<Package
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  IgnorableNamespaces="uap3">
  <Applications>
    <Application>
      <Extensions>
        <uap3:Extension
          Category="windows.protocol">
        <uap3:Protocol
          Name="myapp-cmd"
          Parameters="/p &quot;%1&quot;" />
        </uap3:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
<a id="alias" />

### <a name="start-your-application-by-using-an-alias"></a><span data-ttu-id="628bb-433">エイリアスを使用して、アプリケーションを起動します。</span><span class="sxs-lookup"><span data-stu-id="628bb-433">Start your application by using an alias</span></span>

<span data-ttu-id="628bb-434">ユーザーおよびその他のプロセスは、アプリへの完全パスを指定するのにことがなく、アプリケーションを開始するのに、エイリアスを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-434">Users and other processes can use an alias to start your application without having to specify the full path to your app.</span></span> <span data-ttu-id="628bb-435">そのエイリアス名を指定できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-435">You can specify that alias name.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="628bb-436">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-436">XML namespaces</span></span>

* http://schemas.microsoft.com/appx/manifest/uap/windows10/3
* http://schemas.microsoft.com/appx/manifest/desktop/windows10


#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-437">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-437">Elements and attributes of this extension</span></span>

```XML
<Extension
    Category="windows.appExecutionAlias"
    Executable="[ExecutableName]"
    EntryPoint="Windows.FullTrustApplication">
    <AppExecutionAlias>
            <desktop:ExecutionAlias Alias="[AliasName]" />
      </AppExecutionAlias>
</Extension>
```

|<span data-ttu-id="628bb-438">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-438">Name</span></span> |<span data-ttu-id="628bb-439">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-439">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-440">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-440">Category</span></span> |<span data-ttu-id="628bb-441">常に ``windows.appExecutionAlias`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-441">Always ``windows.appExecutionAlias``.</span></span>
|<span data-ttu-id="628bb-442">Executable</span><span class="sxs-lookup"><span data-stu-id="628bb-442">Executable</span></span> |<span data-ttu-id="628bb-443">エイリアスが呼び出されたときに起動する実行可能ファイルの相対パス。</span><span class="sxs-lookup"><span data-stu-id="628bb-443">The relative path to the executable to start when the alias is invoked.</span></span> |
|<span data-ttu-id="628bb-444">Alias</span><span class="sxs-lookup"><span data-stu-id="628bb-444">Alias</span></span> |<span data-ttu-id="628bb-445">アプリの短い名前。</span><span class="sxs-lookup"><span data-stu-id="628bb-445">The short name for your app.</span></span> <span data-ttu-id="628bb-446">常に、拡張子 ".exe" で終わっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="628bb-446">It must always end with the ".exe" extension.</span></span> <span data-ttu-id="628bb-447">パッケージ内のアプリケーションごとにアプリの実行エイリアスは 1 つだけ指定できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-447">You can only specify a single app execution alias for each application in the package.</span></span> <span data-ttu-id="628bb-448">複数のアプリで同じエイリアスが登録されている場合、システムは最後に登録されたアプリを呼び出します。したがって、他のアプリが上書きする可能性が低い一意のエイリアスを選んでください。</span><span class="sxs-lookup"><span data-stu-id="628bb-448">If multiple apps register for the same alias, the system will invoke the last one that was registered, so make sure to choose a unique alias other apps are unlikely to override.</span></span>
|

#### <a name="example"></a><span data-ttu-id="628bb-449">例</span><span class="sxs-lookup"><span data-stu-id="628bb-449">Example</span></span>

```XML
<Package
  xmlns:uap3="http://schemas.microsoft.com/appx/manifest/uap/windows10/3"
  xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10"
  IgnorableNamespaces="uap3, desktop">
  ...
  <uap3:Extension
        Category="windows.appExecutionAlias"
        Executable="exes\launcher.exe"
        EntryPoint="Windows.FullTrustApplication">
        <uap3:AppExecutionAlias>
            <desktop:ExecutionAlias Alias="Contoso.exe" />
        </uap3:AppExecutionAlias>
  </uap3:Extension>
...
</Package>
```

<span data-ttu-id="628bb-450">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-450">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

<a id="executable" />

### <a name="start-an-executable-file-when-users-log-into-windows"></a><span data-ttu-id="628bb-451">ユーザーが Windows にログオンしたときに実行可能ファイルを起動する</span><span class="sxs-lookup"><span data-stu-id="628bb-451">Start an executable file when users log into Windows</span></span>

<span data-ttu-id="628bb-452">スタートアップ タスクは、ユーザーがログオンするたびに、実行可能ファイルを自動的に実行するアプリケーションを許可します。</span><span class="sxs-lookup"><span data-stu-id="628bb-452">Startup tasks allow your application to run an executable automatically whenever a user logs on.</span></span>

> [!NOTE]
> <span data-ttu-id="628bb-453">ユーザーは、このスタートアップ タスクを登録するアプリケーションで少なくとも 1 回の開始があります。</span><span class="sxs-lookup"><span data-stu-id="628bb-453">The user has to start your application at least one time to register this startup task.</span></span>

<span data-ttu-id="628bb-454">アプリケーションでは、複数のスタートアップ タスクを宣言できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-454">Your application can declare multiple startup tasks.</span></span> <span data-ttu-id="628bb-455">各タスクは独立して起動されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-455">Each task starts independently.</span></span> <span data-ttu-id="628bb-456">すべてのスタートアップ タスクは、タスク マネージャーの **[スタートアップ]** タブに、アプリのマニフェストで指定した名前とアプリのアイコンを使って表示されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-456">All startup tasks will appear in Task Manager under the **Startup** tab with the name that you specify in your app's manifest and your app's icon.</span></span> <span data-ttu-id="628bb-457">タスク マネージャーによって、タスクの起動への影響が自動的に分析されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-457">Task Manager will automatically analyze the startup impact of your tasks.</span></span>

<span data-ttu-id="628bb-458">ユーザーは、タスク マネージャーを使用して、アプリのスタートアップ タスクを手動で無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-458">Users can manually disable your app's startup task by using Task Manager.</span></span> <span data-ttu-id="628bb-459">ユーザーがタスクを無効にした場合、プログラムでタスクを再度有効にすることはできません。</span><span class="sxs-lookup"><span data-stu-id="628bb-459">If a user disables a task, you can't programmatically re-enable it.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-460">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-460">XML namespace</span></span>

http://schemas.microsoft.com/appx/manifest/desktop/windows10

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-461">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-461">Elements and attributes of this extension</span></span>

```XML
<Extension
    Category="windows.startupTask"
    Executable="[ExecutableName]"
    EntryPoint="Windows.FullTrustApplication">
    <StartupTask
      TaskId="[TaskID]"
      Enabled="true"
      DisplayName="[DisplayName]" />
</Extension>
```

|<span data-ttu-id="628bb-462">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-462">Name</span></span> |<span data-ttu-id="628bb-463">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-463">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-464">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-464">Category</span></span> |<span data-ttu-id="628bb-465">常に ``windows.startupTask`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-465">Always ``windows.startupTask``.</span></span>|
|<span data-ttu-id="628bb-466">Executable</span><span class="sxs-lookup"><span data-stu-id="628bb-466">Executable</span></span> |<span data-ttu-id="628bb-467">起動する実行可能ファイルへの相対パス。</span><span class="sxs-lookup"><span data-stu-id="628bb-467">The relative path to the executable file to start.</span></span> |
|<span data-ttu-id="628bb-468">TaskId</span><span class="sxs-lookup"><span data-stu-id="628bb-468">TaskId</span></span> |<span data-ttu-id="628bb-469">タスクの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="628bb-469">A unique identifier for your task.</span></span> <span data-ttu-id="628bb-470">この識別子を使用して、アプリケーションはプログラムによって有効にするまたはスタートアップ タスクを無効にするには、 [Windows.ApplicationModel.StartupTask](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.StartupTask)クラスで Api を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-470">Using this identifier, your application can call the APIs in the [Windows.ApplicationModel.StartupTask](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.StartupTask) class to programmatically enable or disable a startup task.</span></span> |
|<span data-ttu-id="628bb-471">有効</span><span class="sxs-lookup"><span data-stu-id="628bb-471">Enabled</span></span> |<span data-ttu-id="628bb-472">初めて起動したタスクを有効にするか、無効にするかを指定します。</span><span class="sxs-lookup"><span data-stu-id="628bb-472">Indicates whether the task first starts enabled or disabled.</span></span> <span data-ttu-id="628bb-473">有効になっているタスクは、(ユーザーが無効にしていない限り) 次回ユーザーがログオンするときに実行されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-473">Enabled tasks will run the next time the user logs on (unless the user disables it).</span></span> |
|<span data-ttu-id="628bb-474">DisplayName</span><span class="sxs-lookup"><span data-stu-id="628bb-474">DisplayName</span></span> |<span data-ttu-id="628bb-475">タスク マネージャーに表示されるタスクの名前。</span><span class="sxs-lookup"><span data-stu-id="628bb-475">The name of the task that appears in Task Manager.</span></span> <span data-ttu-id="628bb-476">この文字列は、```ms-resource``` を使用してローカライズできます。</span><span class="sxs-lookup"><span data-stu-id="628bb-476">You can localize this string by using ```ms-resource```.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-477">例</span><span class="sxs-lookup"><span data-stu-id="628bb-477">Example</span></span>

```XML
<Package
  xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10"
  IgnorableNamespaces="desktop">
  <Applications>
    <Application>
      <Extensions>
        <desktop:Extension
          Category="windows.startupTask"
          Executable="bin\MyStartupTask.exe"
          EntryPoint="Windows.FullTrustApplication">
          <desktop:StartupTask
          TaskId="MyStartupTask"
          Enabled="true"
          DisplayName="My App Service" />
        </desktop:Extension>
      </Extensions>
    </Application>
  </Applications>
 </Package>
```
<a id="autoplay" />

### <a name="enable-users-to-start-your-application-when-they-connect-a-device-to-their-pc"></a><span data-ttu-id="628bb-478">デバイスを自分の PC に接続するときに、アプリケーションを起動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="628bb-478">Enable users to start your application when they connect a device to their PC</span></span>

<span data-ttu-id="628bb-479">自動再生は、ユーザーがデバイスを自分の PC に接続するときにオプションとしてアプリを表示できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-479">AutoPlay can present your application as an option when a user connects a device to their PC.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="628bb-480">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-480">XML namespace</span></span>

http://schemas.microsoft.com/appx/manifest/desktop/windows10/3


#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-481">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-481">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.autoPlayHandler">
  <AutoPlayHandler>
    <InvokeAction ActionDisplayName="[action string]" ProviderDisplayName="[name of your app/service]">
      <Content ContentEvent="[Content event]" Verb="[any string]" DropTargetHandler="[Clsid]" />
      <Content ContentEvent="[Content event]" Verb="[any string]" Parameters="[Initialization parameter]"/>
      <Device DeviceEvent="[Device event]" HWEventHandler="[Clsid]" InitCmdLine="[Initialization parameter]"/>
    </InvokeAction>
  </AutoPlayHandler>
```

|<span data-ttu-id="628bb-482">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-482">Name</span></span> |<span data-ttu-id="628bb-483">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-483">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-484">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-484">Category</span></span> |<span data-ttu-id="628bb-485">常に ``windows.autoPlayHandler`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-485">Always ``windows.autoPlayHandler``.</span></span>
|<span data-ttu-id="628bb-486">ActionDisplayName</span><span class="sxs-lookup"><span data-stu-id="628bb-486">ActionDisplayName</span></span> |<span data-ttu-id="628bb-487">ユーザーが PC に接続したときにデバイスで実行できるアクションを表す文字列 (例: "ファイルのインポート" や "ビデオの再生")。</span><span class="sxs-lookup"><span data-stu-id="628bb-487">A string that represents the action that users can take with a device that they connect to a PC (For example: "Import files", or "Play video").</span></span> |
|<span data-ttu-id="628bb-488">ProviderDisplayName</span><span class="sxs-lookup"><span data-stu-id="628bb-488">ProviderDisplayName</span></span> | <span data-ttu-id="628bb-489">アプリケーションまたはサービスを表す文字列 (例:「Contoso ビデオ プレーヤー」)。</span><span class="sxs-lookup"><span data-stu-id="628bb-489">A string that represents your application or service (For example: "Contoso video player").</span></span> |
|<span data-ttu-id="628bb-490">ContentEvent</span><span class="sxs-lookup"><span data-stu-id="628bb-490">ContentEvent</span></span> |<span data-ttu-id="628bb-491">ユーザーに ``ActionDisplayName`` と ``ProviderDisplayName`` をプロンプト表示する原因となるコンテンツ イベントの名前。</span><span class="sxs-lookup"><span data-stu-id="628bb-491">The name of a content event that causes users to be prompted with your ``ActionDisplayName`` and ``ProviderDisplayName``.</span></span> <span data-ttu-id="628bb-492">コンテンツ イベントは、カメラのメモリ カード、サム ドライブ、DVD などのボリューム デバイスが PC に挿入されたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="628bb-492">A content event is raised when a volume device such as a camera memory card, thumb drive, or DVD is inserted into the PC.</span></span> <span data-ttu-id="628bb-493">これらのイベントの詳しい一覧については、[ここ](https://docs.microsoft.com/windows/uwp/launch-resume/auto-launching-with-autoplay#autoplay-event-reference)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-493">You can find the full list of those events [here](https://docs.microsoft.com/windows/uwp/launch-resume/auto-launching-with-autoplay#autoplay-event-reference).</span></span>  |
|<span data-ttu-id="628bb-494">動詞</span><span class="sxs-lookup"><span data-stu-id="628bb-494">Verb</span></span> |<span data-ttu-id="628bb-495">[動詞] 設定では、選択したオプションのアプリケーションに渡される値を識別します。</span><span class="sxs-lookup"><span data-stu-id="628bb-495">The Verb setting identifies a value that is passed to your application for the selected option.</span></span> <span data-ttu-id="628bb-496">自動再生のイベントの起動アクションは複数指定できます。また、[動詞] 設定を使って、ユーザーがアプリで選んだアクションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-496">You can specify multiple launch actions for an AutoPlay event and use the Verb setting to determine which option a user has selected for your app.</span></span> <span data-ttu-id="628bb-497">アプリに渡される起動イベント引数の verb プロパティを調べることでユーザーが選んだオプションを確認できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-497">You can tell which option the user selected by checking the verb property of the startup event arguments passed to your app.</span></span> <span data-ttu-id="628bb-498">[動詞] 設定には任意の値を使うことができます。ただし、予約されている open を除きます。</span><span class="sxs-lookup"><span data-stu-id="628bb-498">You can use any value for the Verb setting except, open, which is reserved.</span></span> |
|<span data-ttu-id="628bb-499">DropTargetHandler</span><span class="sxs-lookup"><span data-stu-id="628bb-499">DropTargetHandler</span></span> |<span data-ttu-id="628bb-500">[IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017)インターフェイスを実装するアプリケーションのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-500">The class ID of the application that implements the [IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017) interface.</span></span> <span data-ttu-id="628bb-501">リムーバブル メディアのファイルは、[IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017) 実装の [Drop](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget.drop?view=visualstudiosdk-2017#Microsoft_VisualStudio_OLE_Interop_IDropTarget_Drop_Microsoft_VisualStudio_OLE_Interop_IDataObject_System_UInt32_Microsoft_VisualStudio_OLE_Interop_POINTL_System_UInt32__) メソッドに渡されます。</span><span class="sxs-lookup"><span data-stu-id="628bb-501">Files from the removable media are passed to the [Drop](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget.drop?view=visualstudiosdk-2017#Microsoft_VisualStudio_OLE_Interop_IDropTarget_Drop_Microsoft_VisualStudio_OLE_Interop_IDataObject_System_UInt32_Microsoft_VisualStudio_OLE_Interop_POINTL_System_UInt32__) method of your [IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017) implementation.</span></span>  |
|<span data-ttu-id="628bb-502">パラメーター</span><span class="sxs-lookup"><span data-stu-id="628bb-502">Parameters</span></span> |<span data-ttu-id="628bb-503">すべてのコンテンツ イベントで [IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017) インターフェイスを実装する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="628bb-503">You don't have to implement the [IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017) interface for all content events.</span></span> <span data-ttu-id="628bb-504">どのコンテンツ イベントにも、[IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017) インターフェイスを実装する代わりにコマンド ライン パラメーターを指定することができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-504">For any of the content events, you could provide command line parameters instead of implementing the [IDropTarget](https://docs.microsoft.com/dotnet/api/microsoft.visualstudio.ole.interop.idroptarget?view=visualstudiosdk-2017) interface.</span></span> <span data-ttu-id="628bb-505">これらのイベントでは、自動再生がこれらのコマンド ライン パラメーターを使用してアプリケーションを起動します。</span><span class="sxs-lookup"><span data-stu-id="628bb-505">For those events, AutoPlay will start your application by using those command line parameters.</span></span> <span data-ttu-id="628bb-506">アプリの初期化コードでそれらのパラメーターを解析して、自動再生によって起動したかどうかを判断し、カスタム実装を提供することができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-506">You can parse those parameters in your app's initialization code to determine if it was started by AutoPlay and then provide your custom implementation.</span></span> |
|<span data-ttu-id="628bb-507">DeviceEvent</span><span class="sxs-lookup"><span data-stu-id="628bb-507">DeviceEvent</span></span> |<span data-ttu-id="628bb-508">ユーザーに ``ActionDisplayName`` と ``ProviderDisplayName`` をプロンプト表示する原因となるデバイス イベントの名前。</span><span class="sxs-lookup"><span data-stu-id="628bb-508">The name of a device event that causes users to be prompted with your ``ActionDisplayName`` and ``ProviderDisplayName``.</span></span> <span data-ttu-id="628bb-509">デバイス イベントは、デバイスが PC に接続されると発生します。</span><span class="sxs-lookup"><span data-stu-id="628bb-509">A device event is raised when a device is connected to the PC.</span></span> <span data-ttu-id="628bb-510">デバイス イベントの先頭は文字列 ``WPD`` です。一覧については[ここ](https://docs.microsoft.com/windows/uwp/launch-resume/auto-launching-with-autoplay#autoplay-event-reference)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-510">Device events begin with the string ``WPD`` and you can find them listed [here](https://docs.microsoft.com/windows/uwp/launch-resume/auto-launching-with-autoplay#autoplay-event-reference).</span></span> |
|<span data-ttu-id="628bb-511">HWEventHandler</span><span class="sxs-lookup"><span data-stu-id="628bb-511">HWEventHandler</span></span> |<span data-ttu-id="628bb-512">[IHWEventHandler](https://msdn.microsoft.com/library/windows/desktop/bb775492.aspx)インターフェイスを実装するアプリケーションのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="628bb-512">The Class ID of the application that implements the [IHWEventHandler](https://msdn.microsoft.com/library/windows/desktop/bb775492.aspx) interface.</span></span> |
|<span data-ttu-id="628bb-513">InitCmdLine</span><span class="sxs-lookup"><span data-stu-id="628bb-513">InitCmdLine</span></span> |<span data-ttu-id="628bb-514">[IHWEventHandler](https://msdn.microsoft.com/library/windows/desktop/bb775492.aspx) インターフェイスの [Initialize](https://msdn.microsoft.com/en-us/library/windows/desktop/bb775495.aspx) メソッドに渡す文字列パラメーター。</span><span class="sxs-lookup"><span data-stu-id="628bb-514">The string parameter that you want to pass into the [Initialize](https://msdn.microsoft.com/en-us/library/windows/desktop/bb775495.aspx) method of the [IHWEventHandler](https://msdn.microsoft.com/library/windows/desktop/bb775492.aspx) interface.</span></span> |

### <a name="example"></a><span data-ttu-id="628bb-515">例</span><span class="sxs-lookup"><span data-stu-id="628bb-515">Example</span></span>

```XML
<Package
  xmlns:desktop3="http://schemas.microsoft.com/appx/manifest/desktop/windows10/3"
  IgnorableNamespaces="desktop3">
  <Applications>
    <Application>
      <Extensions>
        <desktop3:Extension Category="windows.autoPlayHandler">
          <desktop3:AutoPlayHandler>
            <desktop3:InvokeAction ActionDisplayName="Import my files" ProviderDisplayName="ms-resource:AutoPlayDisplayName">
              <desktop3:Content ContentEvent="ShowPicturesOnArrival" Verb="show" DropTargetHandler="CD041BAE-0DEA-4472-9B7B-C98043D26EA8"/>
              <desktop3:Content ContentEvent="PlayVideoFilesOnArrival" Verb="play" Parameters="%1" />
              <desktop3:Device DeviceEvent="WPD\ImageSource" HWEventHandler="CD041BAE-0DEA-4472-9B7B-C98043D26EA8" InitCmdLine="/autoplay"/>
            </desktop3:InvokeAction>
          </desktop3:AutoPlayHandler>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
<a id="updates" />

### <a name="restart-automatically-after-receiving-an-update-from-the-microsoft-store"></a><span data-ttu-id="628bb-516">Microsoft Store から更新プログラムを受信した後、自動的に再起動する</span><span class="sxs-lookup"><span data-stu-id="628bb-516">Restart automatically after receiving an update from the Microsoft Store</span></span>

<span data-ttu-id="628bb-517">ユーザーを更新プログラムをインストールするときに、アプリケーションが開いている場合は、アプリケーションを閉じます。</span><span class="sxs-lookup"><span data-stu-id="628bb-517">If your application is open when users install an update to it, the application closes.</span></span>

<span data-ttu-id="628bb-518">更新の完了後に再起動するようにアプリケーションを設定する場合は、再起動するすべてのプロセスで[RegisterApplicationRestart](https://msdn.microsoft.com/library/windows/desktop/aa373347.aspx)関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="628bb-518">If you want that application to restart after the update completes, call the  [RegisterApplicationRestart](https://msdn.microsoft.com/library/windows/desktop/aa373347.aspx) function in every process that you want to restart.</span></span>

<span data-ttu-id="628bb-519">アプリの各アクティブ ウィンドウでは、 [WM_QUERYENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376890.aspx)メッセージを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="628bb-519">Each active window in your application receives a [WM_QUERYENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376890.aspx) message.</span></span> <span data-ttu-id="628bb-520">この時点で、アプリケーションでは、必要に応じて、コマンド ラインを更新するには、もう一度[RegisterApplicationRestart](https://msdn.microsoft.com/library/windows/desktop/aa373347.aspx)関数を呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-520">At this point, your application can call the [RegisterApplicationRestart](https://msdn.microsoft.com/library/windows/desktop/aa373347.aspx) function again to update the command line if necessary.</span></span>

<span data-ttu-id="628bb-521">アプリケーションの各アクティブ ウィンドウでは、 [WM_ENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376889.aspx)メッセージを受信した場合、アプリケーションがデータを保存、シャット ダウンする必要があります。</span><span class="sxs-lookup"><span data-stu-id="628bb-521">When each active window in your application receives the [WM_ENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376889.aspx) message, your application should save data and shut down.</span></span>

>[!NOTE]
<span data-ttu-id="628bb-522">アクティブ ウィンドウは、アプリケーションが[WM_ENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376889.aspx)メッセージを処理しない場合にも[WM_CLOSE](https://msdn.microsoft.com/library/windows/desktop/ms632617.aspx)メッセージを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="628bb-522">Your active windows also receive the [WM_CLOSE](https://msdn.microsoft.com/library/windows/desktop/ms632617.aspx) message in case the application doesn't handle the [WM_ENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376889.aspx) message.</span></span>

<span data-ttu-id="628bb-523">この時点で、アプリケーション 30 秒、独自のプロセスを終了するか、または終了しなければ、プラットフォームです。</span><span class="sxs-lookup"><span data-stu-id="628bb-523">At this point, your application has 30 seconds to close it's own processes or the platform terminates them forcefully.</span></span>

<span data-ttu-id="628bb-524">更新が完了したら、アプリを再起動します。</span><span class="sxs-lookup"><span data-stu-id="628bb-524">After the update is complete, your application restarts.</span></span>

## <a name="work-with-other-applications"></a><span data-ttu-id="628bb-525">他のアプリケーションと連携する</span><span class="sxs-lookup"><span data-stu-id="628bb-525">Work with other applications</span></span>

<span data-ttu-id="628bb-526">他のアプリとの統合、他のプロセスの開始、情報の共有が可能です。</span><span class="sxs-lookup"><span data-stu-id="628bb-526">Integrate with other apps, start other processes or share information.</span></span>

* [<span data-ttu-id="628bb-527">印刷をサポートするアプリケーションで印刷先として表示される、アプリケーションを作成します。</span><span class="sxs-lookup"><span data-stu-id="628bb-527">Make your application appear as the print target in applications that support printing</span></span>](#printing)
* [<span data-ttu-id="628bb-528">他の Windows アプリケーションとフォントを共有する</span><span class="sxs-lookup"><span data-stu-id="628bb-528">Share fonts with other Windows applications</span></span>](#fonts)
* [<span data-ttu-id="628bb-529">ユニバーサル Windows プラットフォーム (UWP) アプリから Win32 プロセスを開始する</span><span class="sxs-lookup"><span data-stu-id="628bb-529">Start a Win32 process from a Universal Windows Platform (UWP) app</span></span>](#win32-process)

<a id="printing" />

### <a name="make-your-application-appear-as-the-print-target-in-applications-that-support-printing"></a><span data-ttu-id="628bb-530">印刷をサポートするアプリケーションで印刷先として表示される、アプリケーションを作成します。</span><span class="sxs-lookup"><span data-stu-id="628bb-530">Make your application appear as the print target in applications that support printing</span></span>

<span data-ttu-id="628bb-531">ユーザーは、メモ帳など別のアプリケーションからデータを印刷する場合、利用できる印刷先のアプリの一覧で印刷先として表示されるアプリケーションを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="628bb-531">When users want to print data from another application such as Notepad, you can make your application appear as a print target in the app's list of available print targets.</span></span>

<span data-ttu-id="628bb-532">XML Paper Specification (XPS) 形式で印刷データを受信できるように、アプリケーションを変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="628bb-532">You'll have to modify your application so that it receives print data in XML Paper Specification (XPS) format.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="628bb-533">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-533">XML namespaces</span></span>

http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-534">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-534">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.appPrinter">
    <AppPrinter
        DisplayName="[DisplayName]"
        Parameters="[Parameters]" />
</Extension>
```

<span data-ttu-id="628bb-535">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-desktop2-appprinter)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-535">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-desktop2-appprinter).</span></span>

|<span data-ttu-id="628bb-536">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-536">Name</span></span> |<span data-ttu-id="628bb-537">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-537">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-538">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-538">Category</span></span> |<span data-ttu-id="628bb-539">常に ``windows.appPrinter`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-539">Always ``windows.appPrinter``.</span></span>
|<span data-ttu-id="628bb-540">DisplayName</span><span class="sxs-lookup"><span data-stu-id="628bb-540">DisplayName</span></span> |<span data-ttu-id="628bb-541">アプリの印刷先一覧に表示する名前。</span><span class="sxs-lookup"><span data-stu-id="628bb-541">The name that you want to appear in the list of print targets for an app.</span></span> |
|<span data-ttu-id="628bb-542">パラメーター</span><span class="sxs-lookup"><span data-stu-id="628bb-542">Parameters</span></span> |<span data-ttu-id="628bb-543">要求を適切に処理して、アプリケーションが必要なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="628bb-543">Any parameters that your application requires to properly handle the request.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-544">例</span><span class="sxs-lookup"><span data-stu-id="628bb-544">Example</span></span>

```XML
<Package
  xmlns:desktop2="http://schemas.microsoft.com/appx/manifest/desktop/windows10/2"
  IgnorableNamespaces="desktop2">
  <Applications>
  <Application>
    <Extensions>
      <desktop2:Extension Category="windows.appPrinter">
        <desktop2:AppPrinter
          DisplayName="Send to Contoso"
          Parameters="/insertdoc %1" />
      </desktop2:Extension>
    </Extensions>
  </Application>
</Applications>
</Package>
```
<span data-ttu-id="628bb-545">この拡張機能を使用するサンプルについては、[こちら](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/PrintToPDF)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-545">Find a sample that uses this extension [Here](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/PrintToPDF)</span></span>

<a id="fonts" />

### <a name="share-fonts-with-other-windows-applications"></a><span data-ttu-id="628bb-546">他の Windows アプリケーションとフォントを共有する</span><span class="sxs-lookup"><span data-stu-id="628bb-546">Share fonts with other Windows applications</span></span>

<span data-ttu-id="628bb-547">他の Windows アプリケーションとカスタム フォントを共有できます。</span><span class="sxs-lookup"><span data-stu-id="628bb-547">Share your custom fonts with other Windows applications.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="628bb-548">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-548">XML namespaces</span></span>

http://schemas.microsoft.com/appx/manifest/desktop/windows10/2

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-549">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-549">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.sharedFonts">
    <SharedFonts>
      <Font File="[FontFile]" />
    </SharedFonts>
  </Extension>
```

<span data-ttu-id="628bb-550">完全なスキーマ リファレンスについては、[こちら](https://review.docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap4-sharedfonts)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-550">Find the complete schema reference [here](https://review.docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap4-sharedfonts).</span></span>


|<span data-ttu-id="628bb-551">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-551">Name</span></span> |<span data-ttu-id="628bb-552">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-552">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-553">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-553">Category</span></span> |<span data-ttu-id="628bb-554">常に ``windows.sharedFonts`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-554">Always ``windows.sharedFonts``.</span></span>
|<span data-ttu-id="628bb-555">File</span><span class="sxs-lookup"><span data-stu-id="628bb-555">File</span></span> |<span data-ttu-id="628bb-556">共有するフォントが格納されたファイル。</span><span class="sxs-lookup"><span data-stu-id="628bb-556">The file that contains the fonts that you want to share.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-557">例</span><span class="sxs-lookup"><span data-stu-id="628bb-557">Example</span></span>

```XML
<Package
  xmlns:uap4="http://schemas.microsoft.com/appx/manifest/uap/windows10/4"
  IgnorableNamespaces="uap4">
  <Applications>
    <Application>
      <Extensions>
        <uap4:Extension Category="windows.sharedFonts">
          <uap4:SharedFonts>
            <uap4:Font File="Fonts\JustRealize.ttf" />
            <uap4:Font File="Fonts\JustRealizeBold.ttf" />
          </uap4:SharedFonts>
        </uap4:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
<a id="win32-process" />

### <a name="start-a-win32-process-from-a-universal-windows-platform-uwp-app"></a><span data-ttu-id="628bb-558">ユニバーサル Windows プラットフォーム (UWP) アプリから Win32 プロセスを開始する</span><span class="sxs-lookup"><span data-stu-id="628bb-558">Start a Win32 process from a Universal Windows Platform (UWP) app</span></span>

<span data-ttu-id="628bb-559">完全信頼で実行される Win32 プロセスを開始します。</span><span class="sxs-lookup"><span data-stu-id="628bb-559">Start a Win32 process that runs in full-trust.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="628bb-560">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="628bb-560">XML namespaces</span></span>

http://schemas.microsoft.com/appx/manifest/desktop/windows10

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="628bb-561">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="628bb-561">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fullTrustProcess" Executable="[executable file]">
  <FullTrustProcess>
    <ParameterGroup GroupId="[GroupID]" Parameters="[Parameters]"/>
  </FullTrustProcess>
</Extension>
```

|<span data-ttu-id="628bb-562">名前</span><span class="sxs-lookup"><span data-stu-id="628bb-562">Name</span></span> |<span data-ttu-id="628bb-563">説明</span><span class="sxs-lookup"><span data-stu-id="628bb-563">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="628bb-564">Category</span><span class="sxs-lookup"><span data-stu-id="628bb-564">Category</span></span> |<span data-ttu-id="628bb-565">常に ``windows.fullTrustProcess`` です。</span><span class="sxs-lookup"><span data-stu-id="628bb-565">Always ``windows.fullTrustProcess``.</span></span>
|<span data-ttu-id="628bb-566">GroupID</span><span class="sxs-lookup"><span data-stu-id="628bb-566">GroupID</span></span> |<span data-ttu-id="628bb-567">実行可能ファイルに渡すパラメーターのセットを識別するための文字列。</span><span class="sxs-lookup"><span data-stu-id="628bb-567">A string that identifies a set of parameters that you want to pass to the executable.</span></span> |
|<span data-ttu-id="628bb-568">Parameters</span><span class="sxs-lookup"><span data-stu-id="628bb-568">Parameters</span></span> |<span data-ttu-id="628bb-569">実行可能ファイルに渡すパラメーター。</span><span class="sxs-lookup"><span data-stu-id="628bb-569">Parameters that you want to pass to the executable.</span></span> |

#### <a name="example"></a><span data-ttu-id="628bb-570">例</span><span class="sxs-lookup"><span data-stu-id="628bb-570">Example</span></span>

```XML
<Package xmlns="http://schemas.microsoft.com/appx/manifest/foundation/windows10"
         xmlns:uap="http://schemas.microsoft.com/appx/manifest/uap/windows10"
         xmlns:rescap=
"http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
         xmlns:desktop="http://schemas.microsoft.com/appx/manifest/desktop/windows10">
  ...
  <Capabilities>
      <rescap:Capability Name="runFullTrust"/>
  </Capabilities>
  <Applications>
    <Application>
      <Extensions>
          <desktop:Extension Category="windows.fullTrustProcess" Executable="fulltrustprocess.exe">
              <desktop:FullTrustProcess>
                  <desktop:ParameterGroup GroupId="SyncGroup" Parameters="/Sync"/>
                  <desktop:ParameterGroup GroupId="OtherGroup" Parameters="/Other"/>
              </desktop:FullTrustProcess>
           </desktop:Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```
<span data-ttu-id="628bb-571">この拡張機能をすべてのデバイスで実行されるユニバーサル Windows プラットフォームのユーザー インターフェイスを作成する場合に役立つことがありますが、完全信頼で実行を続ける Win32 アプリケーションのコンポーネントをします。</span><span class="sxs-lookup"><span data-stu-id="628bb-571">This extension might be useful if you want to create a Universal Windows Platform User interface that runs on all devices, but you want components of your Win32 application to continue running in full-trust.</span></span>

<span data-ttu-id="628bb-572">Win32 アプリの Windows アプリ パッケージの作成だけです。</span><span class="sxs-lookup"><span data-stu-id="628bb-572">Just create a Windows app package for your Win32 app.</span></span> <span data-ttu-id="628bb-573">そのうえで、この拡張機能を UWP アプリのパッケージ ファイルに追加してください。</span><span class="sxs-lookup"><span data-stu-id="628bb-573">Then, add this extension to the package file of your UWP app.</span></span> <span data-ttu-id="628bb-574">この拡張機能では、Windows アプリ パッケージで実行可能ファイルを開始することを示します。</span><span class="sxs-lookup"><span data-stu-id="628bb-574">This extensions indicates that you want to start an executable file in the Windows app package.</span></span>  <span data-ttu-id="628bb-575">UWP アプリと Win32 アプリの間でやり取りを行うには、1 つまたは複数の[アプリ サービス](../launch-resume/app-services.md)を設定します。</span><span class="sxs-lookup"><span data-stu-id="628bb-575">If you want to communicate between your UWP app and your Win32 app, you can set up one or more [app services](../launch-resume/app-services.md) to do that.</span></span> <span data-ttu-id="628bb-576">このシナリオについては詳しくは、[こちら](https://blogs.msdn.microsoft.com/appconsult/2016/12/19/desktop-bridge-the-migrate-phase-invoking-a-win32-process-from-a-uwp-app/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-576">You can read more about this scenario [here](https://blogs.msdn.microsoft.com/appconsult/2016/12/19/desktop-bridge-the-migrate-phase-invoking-a-win32-process-from-a-uwp-app/).</span></span>

## <a name="next-steps"></a><span data-ttu-id="628bb-577">次のステップ</span><span class="sxs-lookup"><span data-stu-id="628bb-577">Next steps</span></span>

**<span data-ttu-id="628bb-578">質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="628bb-578">Find answers to your questions</span></span>**

<span data-ttu-id="628bb-579">ご質問がある場合は、</span><span class="sxs-lookup"><span data-stu-id="628bb-579">Have questions?</span></span> <span data-ttu-id="628bb-580">Stack Overflow でお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="628bb-580">Ask us on Stack Overflow.</span></span> <span data-ttu-id="628bb-581">Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="628bb-581">Our team monitors these [tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span> <span data-ttu-id="628bb-582">[こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。</span><span class="sxs-lookup"><span data-stu-id="628bb-582">You can also ask us [here](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D).</span></span>

**<span data-ttu-id="628bb-583">フィードバックの提供または機能の提案を行う</span><span class="sxs-lookup"><span data-stu-id="628bb-583">Give feedback or make feature suggestions</span></span>**

<span data-ttu-id="628bb-584">[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="628bb-584">See [UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial).</span></span>
