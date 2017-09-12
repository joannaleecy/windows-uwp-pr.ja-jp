---
author: normesta
Description: "拡張機能を使用すると、あらかじめ定義された方法で Windows 10 にパッケージ デスクトップ アプリを統合できます。"
Search.Product: eADQiWindows 10XVcnh
title: "Windows 10 にアプリを統合する (デスクトップ ブリッジ)"
ms.author: normesta
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.assetid: 0a8cedac-172a-4efd-8b6b-67fd3667df34
ms.openlocfilehash: 0c3427a7b49b17fda9a3ba0680e59b134732e9fa
ms.sourcegitcommit: 38ef208ef457ce1857038c9cde3658c884d29b75
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/13/2017
---
# <a name="integrate-your-app-with-windows-10-desktop-bridge"></a><span data-ttu-id="ed335-104">Windows 10 にアプリを統合する (デスクトップ ブリッジ)</span><span class="sxs-lookup"><span data-stu-id="ed335-104">Integrate your app with Windows 10 (Desktop Bridge)</span></span>

<span data-ttu-id="ed335-105">拡張機能を使用すると、あらかじめ定義された方法で Windows 10 にアプリを統合できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-105">Use extensions to integrate your app with Windows 10 in predefined ways.</span></span>

<span data-ttu-id="ed335-106">たとえば、ファイアウォール例外を作成する、アプリを特定のファイルの種類の既定アプリにする、アプリのパッケージ バージョンをスタート タイルの参照先に指定する、などの操作を拡張機能で行うことができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-106">For example, use an extension to create a firewall exception, make your app the default app for a file type, or point start tiles to the packaged version of your app.</span></span> <span data-ttu-id="ed335-107">拡張機能は、アプリのパッケージ マニフェスト ファイルに XML を追加するだけで使用できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-107">To use an extension, just add some XML to your app's package manifest file.</span></span> <span data-ttu-id="ed335-108">コードは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="ed335-108">No code is required.</span></span>

<span data-ttu-id="ed335-109">このトピックでは、これらの拡張機能について説明し、拡張機能を使って実行できるタスクについても示します。</span><span class="sxs-lookup"><span data-stu-id="ed335-109">This topic describes these extensions and the tasks that you can perform by using them.</span></span>

## <a name="transition-users-to-your-app"></a><span data-ttu-id="ed335-110">ユーザーをアプリに移行する</span><span class="sxs-lookup"><span data-stu-id="ed335-110">Transition users to your app</span></span>

<span data-ttu-id="ed335-111">ユーザーによってパッケージ アプリが使用されるように、移行を促します。</span><span class="sxs-lookup"><span data-stu-id="ed335-111">Help users transition to your packaged app.</span></span>

* [<span data-ttu-id="ed335-112">既存のスタート タイルとタスク バー ボタンの参照先をパッケージ アプリに設定する</span><span class="sxs-lookup"><span data-stu-id="ed335-112">Point existing Start tiles and taskbar buttons to your packaged app</span></span>](#point)
* [<span data-ttu-id="ed335-113">デスクトップ アプリではなくパッケージ アプリによってファイルが開かれるように設定する</span><span class="sxs-lookup"><span data-stu-id="ed335-113">Make your packaged app open files instead of your desktop app</span></span>](#make)
* [<span data-ttu-id="ed335-114">パッケージ アプリを一連のファイルの種類に関連付ける</span><span class="sxs-lookup"><span data-stu-id="ed335-114">Associate your packaged app with a set of file types</span></span>](#associate)
* [<span data-ttu-id="ed335-115">特定の種類のファイルのコンテキスト メニューにオプションを追加する</span><span class="sxs-lookup"><span data-stu-id="ed335-115">Add options to the context menus of files that have a certain file type</span></span>](#add)
* [<span data-ttu-id="ed335-116">URL を使用して特定の種類のファイルを直接開く</span><span class="sxs-lookup"><span data-stu-id="ed335-116">Open certain types of files directly by using a URL</span></span>](#open)

<span id="point" />
### <a name="point-existing-start-tiles-and-taskbar-buttons-to-your-packaged-app"></a><span data-ttu-id="ed335-117">既存のスタート タイルとタスク バー ボタンの参照先をパッケージ アプリに設定する</span><span class="sxs-lookup"><span data-stu-id="ed335-117">Point existing Start tiles and taskbar buttons to your packaged app</span></span>

<span data-ttu-id="ed335-118">ユーザーによって、デスクトップ アプリがタスク バーまたはスタート メニューにピン留めされている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ed335-118">Your users might have pinned your desktop application to the taskbar or the Start menu.</span></span> <span data-ttu-id="ed335-119">これらのショートカットの参照先を新しいパッケージ アプリに変更できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-119">You can point those shortcuts to your new packaged app.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="ed335-120">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-120">XML namespace</span></span>

<span data-ttu-id="ed335-121">http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3</span><span class="sxs-lookup"><span data-stu-id="ed335-121">http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-122">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-122">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.desktopAppMigration">
    <DesktopAppMigration>
        <DesktopApp AumId="[your_app_aumid]" />
        <DesktopApp ShortcutPath="[path]" />
    </DesktopAppMigration>
</Extension>

```

<span data-ttu-id="ed335-123">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-rescap3-desktopappmigration)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-123">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-rescap3-desktopappmigration).</span></span>

|<span data-ttu-id="ed335-124">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-124">Name</span></span> | <span data-ttu-id="ed335-125">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-125">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-126">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-126">Category</span></span> |<span data-ttu-id="ed335-127">常に ``windows.desktopAppMigration`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-127">Always ``windows.desktopAppMigration``.</span></span>
|<span data-ttu-id="ed335-128">AumID</span><span class="sxs-lookup"><span data-stu-id="ed335-128">AumID</span></span> |<span data-ttu-id="ed335-129">パッケージ アプリのアプリケーション ユーザー モデル ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-129">The Application User Model ID of your packaged app.</span></span> |
|<span data-ttu-id="ed335-130">ShortcutPath</span><span class="sxs-lookup"><span data-stu-id="ed335-130">ShortcutPath</span></span> |<span data-ttu-id="ed335-131">アプリのデスクトップ バージョンを起動する .lnk ファイルへのパス。</span><span class="sxs-lookup"><span data-stu-id="ed335-131">The path to .lnk files that start the desktop version of your app.</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-132">例</span><span class="sxs-lookup"><span data-stu-id="ed335-132">Example</span></span>

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
#### <a name="related-sample"></a><span data-ttu-id="ed335-133">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="ed335-133">Related sample</span></span>

[<span data-ttu-id="ed335-134">WPF picture viewer with transition/migration/uninstallation</span><span class="sxs-lookup"><span data-stu-id="ed335-134">WPF picture viewer with transition/migration/uninstallation</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<span id="make" />
### <a name="make-your-packaged-app-open-files-instead-of-your-desktop-app"></a><span data-ttu-id="ed335-135">デスクトップ アプリではなくパッケージ アプリによってファイルが開かれるように設定する</span><span class="sxs-lookup"><span data-stu-id="ed335-135">Make your packaged app open files instead of your desktop app</span></span>

<span data-ttu-id="ed335-136">ユーザーが特定の種類のファイルを開くときに、アプリのデスクトップ バージョンではなく、新しいパッケージ アプリが既定で開くように設定できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-136">You can make sure that users open your new packaged app by default for specific types of files instead of opening the desktop version of your app.</span></span>

<span data-ttu-id="ed335-137">これを行うには、ファイルの関連付けを継承するために、関連付けされている各アプリケーションの[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) を指定します。</span><span class="sxs-lookup"><span data-stu-id="ed335-137">To do that, you'll specify the [programmatic identifier (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) of each application from which you want to inherit file associations.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="ed335-138">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-138">XML namespaces</span></span>

* <span data-ttu-id="ed335-139">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span><span class="sxs-lookup"><span data-stu-id="ed335-139">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span></span>
* <span data-ttu-id="ed335-140">http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3</span><span class="sxs-lookup"><span data-stu-id="ed335-140">http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-141">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-141">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
<FileTypeAssociation Name="[AppID]">
         <MigrationProgIds>
            <MigrationProgId>"[ProgID]"</MigrationProgId>
        </MigrationProgIds>
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="ed335-142">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-142">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="ed335-143">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-143">Name</span></span> |<span data-ttu-id="ed335-144">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-144">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-145">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-145">Category</span></span> |<span data-ttu-id="ed335-146">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-146">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="ed335-147">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-147">Name</span></span> |<span data-ttu-id="ed335-148">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-148">A unique Id for your app.</span></span> <span data-ttu-id="ed335-149">この ID は、ファイルの種類の関連付けによって関連付けられたハッシュ対象の[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) を生成するために内部で使用されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-149">This Id is used internally to generate a hashed [programmatic identifier (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) associated with your file type association.</span></span> <span data-ttu-id="ed335-150">この ID を使って、アプリの今後のバージョンで変更を管理することができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-150">You can use this Id to manage changes in future versions of your app.</span></span> |
|<span data-ttu-id="ed335-151">MigrationProgId</span><span class="sxs-lookup"><span data-stu-id="ed335-151">MigrationProgId</span></span> |<span data-ttu-id="ed335-152">ファイルの関連付けを継承するための、元のデスクトップ アプリの用途、コンポーネント、およびバージョンを示す[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx)。</span><span class="sxs-lookup"><span data-stu-id="ed335-152">The [programmatic identifier (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) that describes the application, component, and version of the desktop app from which you want to inherit file associations.</span></span>|

#### <a name="example"></a><span data-ttu-id="ed335-153">例</span><span class="sxs-lookup"><span data-stu-id="ed335-153">Example</span></span>

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
#### <a name="related-sample"></a><span data-ttu-id="ed335-154">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="ed335-154">Related sample</span></span>

[<span data-ttu-id="ed335-155">WPF picture viewer with transition/migration/uninstallation</span><span class="sxs-lookup"><span data-stu-id="ed335-155">WPF picture viewer with transition/migration/uninstallation</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<span id="associate" />
### <a name="associate-your-packaged-app-with-a-set-of-file-types"></a><span data-ttu-id="ed335-156">パッケージ アプリを一連のファイルの種類に関連付ける</span><span class="sxs-lookup"><span data-stu-id="ed335-156">Associate your packaged app with a set of file types</span></span>

<span data-ttu-id="ed335-157">パッケージ アプリは、ファイルの種類の拡張機能に関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-157">You can associated your packaged app with file type extensions.</span></span> <span data-ttu-id="ed335-158">ユーザーがファイルを右クリックして **[プログラムから開く]** オプションを選んだ場合、候補の一覧にアプリが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-158">If a user right-clicks a file and then selects the **Open with** option, your app appears in the list of suggestions.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="ed335-159">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-159">XML namespace</span></span>

* <span data-ttu-id="ed335-160">http://schemas.microsoft.com/appx/manifest/uap/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-160">http://schemas.microsoft.com/appx/manifest/uap/windows10</span></span>
* <span data-ttu-id="ed335-161">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span><span class="sxs-lookup"><span data-stu-id="ed335-161">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-162">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-162">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>"[file extension]"</FileType>
        </SupportedFileTypes>
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="ed335-163">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-163">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="ed335-164">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-164">Name</span></span> |<span data-ttu-id="ed335-165">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-165">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-166">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-166">Category</span></span> |<span data-ttu-id="ed335-167">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-167">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="ed335-168">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-168">Name</span></span> |<span data-ttu-id="ed335-169">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-169">A unique Id for your app.</span></span> <span data-ttu-id="ed335-170">この ID は、ファイルの種類の関連付けによって関連付けられたハッシュ対象の[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) を生成するために内部で使用されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-170">This Id is used internally to generate a hashed [programmatic identifier (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) associated with your file type association.</span></span> <span data-ttu-id="ed335-171">この ID を使って、アプリの今後のバージョンで変更を管理することができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-171">You can use this Id to manage changes in future versions of your app.</span></span>   |
|<span data-ttu-id="ed335-172">FileType</span><span class="sxs-lookup"><span data-stu-id="ed335-172">FileType</span></span> |<span data-ttu-id="ed335-173">アプリでサポートされているファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="ed335-173">The file extension supported by your app.</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-174">例</span><span class="sxs-lookup"><span data-stu-id="ed335-174">Example</span></span>

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

#### <a name="related-sample"></a><span data-ttu-id="ed335-175">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="ed335-175">Related sample</span></span>

[<span data-ttu-id="ed335-176">WPF picture viewer with transition/migration/uninstallation</span><span class="sxs-lookup"><span data-stu-id="ed335-176">WPF picture viewer with transition/migration/uninstallation</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<span id="add" />
### <a name="add-options-to-the-context-menus-of-files-that-have-a-certain-file-type"></a><span data-ttu-id="ed335-177">特定の種類のファイルのコンテキスト メニューにオプションを追加する</span><span class="sxs-lookup"><span data-stu-id="ed335-177">Add options to the context menus of files that have a certain file type</span></span>

<span data-ttu-id="ed335-178">ほとんどの場合、ユーザーはファイルをダブルクリックして開きます。</span><span class="sxs-lookup"><span data-stu-id="ed335-178">In most cases, users double-click files to open them.</span></span> <span data-ttu-id="ed335-179">ユーザーがファイルを右クリックすると、さまざまなオプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-179">If users, right click a file, various options appear.</span></span>

<span data-ttu-id="ed335-180">このメニューには、オプションを追加できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-180">You can add options to that menu.</span></span> <span data-ttu-id="ed335-181">これらのオプションを使用すると、ファイルの印刷、編集、プレビューなど、ファイルの操作を別の方法で行うことができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-181">These options give users other ways to interact with your file such as print, edit, or preview the file.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="ed335-182">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-182">XML namespaces</span></span>

* <span data-ttu-id="ed335-183">http://schemas.microsoft.com/appx/manifest/uap/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-183">http://schemas.microsoft.com/appx/manifest/uap/windows10</span></span>
* <span data-ttu-id="ed335-184">http://schemas.microsoft.com/appx/manifest/uap/windows10/2</span><span class="sxs-lookup"><span data-stu-id="ed335-184">http://schemas.microsoft.com/appx/manifest/uap/windows10/2</span></span>
* <span data-ttu-id="ed335-185">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span><span class="sxs-lookup"><span data-stu-id="ed335-185">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span></span>


#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-186">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-186">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedVerbs>
              <Verb Id="[ID]" Extended="[Extended]" Parameters="[parameters]">"[verb label]"</Verb>
        </SupportedVerbs>
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="ed335-187">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-187">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="ed335-188">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-188">Name</span></span> |<span data-ttu-id="ed335-189">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-189">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-190">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-190">Category</span></span> | <span data-ttu-id="ed335-191">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-191">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="ed335-192">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-192">Name</span></span> |<span data-ttu-id="ed335-193">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-193">A unique Id for your app.</span></span> |
|<span data-ttu-id="ed335-194">Verb</span><span class="sxs-lookup"><span data-stu-id="ed335-194">Verb</span></span> |<span data-ttu-id="ed335-195">エクスプローラーのコンテキスト メニューに表示される名前です。</span><span class="sxs-lookup"><span data-stu-id="ed335-195">The name that appears in the File Explorer context menu.</span></span> <span data-ttu-id="ed335-196">この文字列は、```ms-resource``` を使用してローカライズできます。</span><span class="sxs-lookup"><span data-stu-id="ed335-196">This string is localizable that uses ```ms-resource```.</span></span>|
|<span data-ttu-id="ed335-197">Id</span><span class="sxs-lookup"><span data-stu-id="ed335-197">Id</span></span> |<span data-ttu-id="ed335-198">動詞の一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-198">The unique Id of the verb.</span></span> <span data-ttu-id="ed335-199">アプリが UWP アプリである場合、アプリがユーザーの選択内容を適切に処理できるように、この ID がアクティブ化イベント引数の一部としてアプリに渡されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-199">If your app is a UWP app, this is passed to your app as part of its activation event args so it can handle the user’s selection appropriately.</span></span> <span data-ttu-id="ed335-200">完全信頼のパッケージ アプリは、パラメーターを受け取ります (次の項目をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="ed335-200">If your app is a full-trust packaged app, it receives parameters instead (see the next bullet).</span></span> |
|<span data-ttu-id="ed335-201">Parameters</span><span class="sxs-lookup"><span data-stu-id="ed335-201">Parameters</span></span> |<span data-ttu-id="ed335-202">動詞に関連付けられている引数のパラメーターと値のリスト。</span><span class="sxs-lookup"><span data-stu-id="ed335-202">The list of argument parameters and values associated with the verb.</span></span> <span data-ttu-id="ed335-203">アプリが完全信頼のパッケージ アプリである場合は、アプリがアクティブ化されたときにイベント引数としてこれらのパラメーターがアプリに渡されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-203">If your app is a full-trust packaged app, these parameters are passed to the app as event args when the app is activated.</span></span> <span data-ttu-id="ed335-204">アプリの動作は、さまざまなアクティブ化の動詞に基づいてカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="ed335-204">You can customize the behavior of your app based on different activation verbs.</span></span> <span data-ttu-id="ed335-205">変数にファイル パスが含まれる可能性がある場合は、パラメーター値を引用符で囲みます。</span><span class="sxs-lookup"><span data-stu-id="ed335-205">If a variable can contain a file path, wrap the parameter value in quotes.</span></span> <span data-ttu-id="ed335-206">これにより、パスにスペースが含まれている場合に発生する問題を回避できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-206">That will avoid any issues that happen in cases where the path includes spaces.</span></span> <span data-ttu-id="ed335-207">アプリが UWP アプリの場合、パラメーターを渡すことはできません。</span><span class="sxs-lookup"><span data-stu-id="ed335-207">If your app is a UWP app, you can’t pass parameters.</span></span> <span data-ttu-id="ed335-208">アプリは、代わりに ID を受け取ります (前の項目を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="ed335-208">The app receives the Id instead (see the previous bullet).</span></span>|
|<span data-ttu-id="ed335-209">Extended</span><span class="sxs-lookup"><span data-stu-id="ed335-209">Extended</span></span> |<span data-ttu-id="ed335-210">ユーザーが **Shift** キーを押しながらファイルを右クリックすることでコンテキスト メニューを表示した場合にのみ表示される動詞を指定します。</span><span class="sxs-lookup"><span data-stu-id="ed335-210">Specifies that the verb appears only if the user shows the context menu by holding the **Shift** key before right-clicking the file.</span></span> <span data-ttu-id="ed335-211">この属性は省略可能であり、指定されていない場合の既定値は **False** (常に動詞を表示する) です。</span><span class="sxs-lookup"><span data-stu-id="ed335-211">This attribute is optional and defaults to a value of **False** (e.g., always show the verb) if not listed.</span></span> <span data-ttu-id="ed335-212">この動作は各動詞について個別に指定します ("開く" は例外で、常に **False**)。</span><span class="sxs-lookup"><span data-stu-id="ed335-212">You specify this behavior individually for each verb (except for "Open," which is always **False**).</span></span>|

#### <a name="example"></a><span data-ttu-id="ed335-213">例</span><span class="sxs-lookup"><span data-stu-id="ed335-213">Example</span></span>

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
#### <a name="related-sample"></a><span data-ttu-id="ed335-214">関連するサンプル</span><span class="sxs-lookup"><span data-stu-id="ed335-214">Related sample</span></span>

[<span data-ttu-id="ed335-215">WPF picture viewer with transition/migration/uninstallation</span><span class="sxs-lookup"><span data-stu-id="ed335-215">WPF picture viewer with transition/migration/uninstallation</span></span>](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/DesktopAppTransition)

<span id="open" />
### <a name="open-certain-types-of-files-directly-by-using-a-url"></a><span data-ttu-id="ed335-216">URL を使用して特定の種類のファイルを直接開く</span><span class="sxs-lookup"><span data-stu-id="ed335-216">Open certain types of files directly by using a URL</span></span>

<span data-ttu-id="ed335-217">ユーザーが特定の種類のファイルを開くときに、アプリのデスクトップ バージョンではなく、新しいパッケージ アプリが既定で開くように設定できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-217">You can make sure that users open your new packaged app by default for specific types of files instead of opening the desktop version of your app.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="ed335-218">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-218">XML namespaces</span></span>

* <span data-ttu-id="ed335-219">http://schemas.microsoft.com/appx/manifest/uap/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-219">http://schemas.microsoft.com/appx/manifest/uap/windows10</span></span>
* <span data-ttu-id="ed335-220">http://schemas.microsoft.com/appx/manifest/uap/windows10/3"</span><span class="sxs-lookup"><span data-stu-id="ed335-220">http://schemas.microsoft.com/appx/manifest/uap/windows10/3"</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-221">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-221">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]" UseUrl="true" Parameters="%1">
        <SupportedFileTypes>
            <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes> 
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="ed335-222">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-222">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="ed335-223">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-223">Name</span></span> |<span data-ttu-id="ed335-224">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-224">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-225">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-225">Category</span></span> |<span data-ttu-id="ed335-226">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-226">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="ed335-227">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-227">Name</span></span> |<span data-ttu-id="ed335-228">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-228">A unique Id for your app.</span></span> |
|<span data-ttu-id="ed335-229">UseUrl</span><span class="sxs-lookup"><span data-stu-id="ed335-229">UseUrl</span></span> |<span data-ttu-id="ed335-230">URL ターゲットから直接ファイルを開くかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="ed335-230">Indicates whether to open files directly from a URL target.</span></span> <span data-ttu-id="ed335-231">この値が設定されていない場合にアプリで URL を使用してファイルを開こうとすると、まずファイルがローカルにダウンロードされます。</span><span class="sxs-lookup"><span data-stu-id="ed335-231">If you do not set this value, attempts by your app to open a file by using a URL cause the system to first download the file locally.</span></span> |
|<span data-ttu-id="ed335-232">Parameters</span><span class="sxs-lookup"><span data-stu-id="ed335-232">Parameters</span></span> |<span data-ttu-id="ed335-233">省略可能なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="ed335-233">optional parameters.</span></span> |
|<span data-ttu-id="ed335-234">FileType</span><span class="sxs-lookup"><span data-stu-id="ed335-234">FileType</span></span> |<span data-ttu-id="ed335-235">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="ed335-235">The relevant file extensions.</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-236">例</span><span class="sxs-lookup"><span data-stu-id="ed335-236">Example</span></span>

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

## <a name="perform-setup-tasks"></a><span data-ttu-id="ed335-237">セットアップ タスクを実行する</span><span class="sxs-lookup"><span data-stu-id="ed335-237">Perform setup tasks</span></span>

* [<span data-ttu-id="ed335-238">アプリのファイアウォール例外を作成する</span><span class="sxs-lookup"><span data-stu-id="ed335-238">Create firewall exception for your app</span></span>](#rules)

<span id="rules" />
### <a name="create-firewall-exception-for-your-app"></a><span data-ttu-id="ed335-239">アプリのファイアウォール例外を作成する</span><span class="sxs-lookup"><span data-stu-id="ed335-239">Create firewall exception for your app</span></span>

<span data-ttu-id="ed335-240">アプリがポート経由で通信する必要がある場合は、アプリをファイアウォールの例外の一覧に追加します。</span><span class="sxs-lookup"><span data-stu-id="ed335-240">If your app requires communication through a port, you can add your app to the list of firewall exceptions.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="ed335-241">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-241">XML namespace</span></span>

<span data-ttu-id="ed335-242">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span><span class="sxs-lookup"><span data-stu-id="ed335-242">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-243">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-243">Elements and attributes of this extension</span></span>

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
<span data-ttu-id="ed335-244">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-desktop2-firewallrules)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-244">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-desktop2-firewallrules).</span></span>

|<span data-ttu-id="ed335-245">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-245">Name</span></span> |<span data-ttu-id="ed335-246">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-246">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-247">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-247">Category</span></span> |<span data-ttu-id="ed335-248">常に </span><span class="sxs-lookup"><span data-stu-id="ed335-248">Always</span></span> ``windows.firewallRules``|
|<span data-ttu-id="ed335-249">Executable</span><span class="sxs-lookup"><span data-stu-id="ed335-249">Executable</span></span> |<span data-ttu-id="ed335-250">ファイアウォールの例外の一覧に追加する実行可能ファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="ed335-250">The name of the executable file that you want to add to the list of firewall exceptions</span></span> |
|<span data-ttu-id="ed335-251">Direction</span><span class="sxs-lookup"><span data-stu-id="ed335-251">Direction</span></span> |<span data-ttu-id="ed335-252">規則が受信規則か送信規則かを示します。</span><span class="sxs-lookup"><span data-stu-id="ed335-252">Indicates whether the rule is an inbound or outbound rule</span></span> |
|<span data-ttu-id="ed335-253">IPProtocol</span><span class="sxs-lookup"><span data-stu-id="ed335-253">IPProtocol</span></span> |<span data-ttu-id="ed335-254">通信プロトコル。</span><span class="sxs-lookup"><span data-stu-id="ed335-254">The communication protocol</span></span> |
|<span data-ttu-id="ed335-255">LocalPortMin</span><span class="sxs-lookup"><span data-stu-id="ed335-255">LocalPortMin</span></span> |<span data-ttu-id="ed335-256">ローカル ポート番号の範囲を示すポート番号の下限。</span><span class="sxs-lookup"><span data-stu-id="ed335-256">The lower port number in a range of local port numbers.</span></span> |
|<span data-ttu-id="ed335-257">LocalPortMax</span><span class="sxs-lookup"><span data-stu-id="ed335-257">LocalPortMax</span></span> |<span data-ttu-id="ed335-258">ローカル ポート番号の範囲を示すポート番号の上限。</span><span class="sxs-lookup"><span data-stu-id="ed335-258">The highest port number of a range of local port numbers.</span></span> |
|<span data-ttu-id="ed335-259">RemotePortMax</span><span class="sxs-lookup"><span data-stu-id="ed335-259">RemotePortMax</span></span> |<span data-ttu-id="ed335-260">リモート ポート番号の範囲を示すポート番号の下限。</span><span class="sxs-lookup"><span data-stu-id="ed335-260">The lower port number in a range of remote port numbers.</span></span> |
|<span data-ttu-id="ed335-261">RemotePortMax</span><span class="sxs-lookup"><span data-stu-id="ed335-261">RemotePortMax</span></span> |<span data-ttu-id="ed335-262">リモート ポート番号の範囲を示すポート番号の上限。</span><span class="sxs-lookup"><span data-stu-id="ed335-262">The highest port number of a range of remote port numbers.</span></span> |
|<span data-ttu-id="ed335-263">Profile</span><span class="sxs-lookup"><span data-stu-id="ed335-263">Profile</span></span> |<span data-ttu-id="ed335-264">ネットワークの種類。</span><span class="sxs-lookup"><span data-stu-id="ed335-264">The network type</span></span> |



#### <a name="example"></a><span data-ttu-id="ed335-265">例</span><span class="sxs-lookup"><span data-stu-id="ed335-265">Example</span></span>

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

## <a name="integrate-with-file-explorer"></a><span data-ttu-id="ed335-266">エクスプローラーに統合する</span><span class="sxs-lookup"><span data-stu-id="ed335-266">Integrate with File Explorer</span></span>

<span data-ttu-id="ed335-267">ユーザーが慣れた方法でファイルを整理し操作できるようになります。</span><span class="sxs-lookup"><span data-stu-id="ed335-267">Help users organize your files and interact with them in familiar ways.</span></span>

* [<span data-ttu-id="ed335-268">ユーザーが複数のファイルを同時に選択して開いた場合のアプリの動作を定義する</span><span class="sxs-lookup"><span data-stu-id="ed335-268">Define how your app behaves when users select and open multiple files at the same time</span></span>](#define)
* [<span data-ttu-id="ed335-269">エクスプ ローラーでサムネイル画像のファイル内容を表示する</span><span class="sxs-lookup"><span data-stu-id="ed335-269">Show file contents in a thumbnail image within File Explorer</span></span>](#show)
* [<span data-ttu-id="ed335-270">エクスプローラーのプレビュー ウィンドウにファイル内容を表示する</span><span class="sxs-lookup"><span data-stu-id="ed335-270">Show file contents in a Preview pane of File Explorer</span></span>](#preview)
* [<span data-ttu-id="ed335-271">ユーザーがエクスプローラーの [種類] 列を使用してファイルをグループ化できるようにする</span><span class="sxs-lookup"><span data-stu-id="ed335-271">Enable users to group files by using the Kind column in File Explorer</span></span>](#enable)
* [<span data-ttu-id="ed335-272">ファイルのプロパティを検索、インデックス、プロパティ ダイアログ、詳細ウィンドウに利用できるようにする</span><span class="sxs-lookup"><span data-stu-id="ed335-272">Make file properties available to search, index, property dialogs, and the details pane</span></span>](#make-file-properties)

<span id="define" />
### <a name="define-how-your-app-behaves-when-users-select-and-open-multiple-files-at-the-same-time"></a><span data-ttu-id="ed335-273">ユーザーが複数のファイルを同時に選択して開いた場合のアプリの動作を定義する</span><span class="sxs-lookup"><span data-stu-id="ed335-273">Define how your app behaves when users select and open multiple files at the same time</span></span>

<span data-ttu-id="ed335-274">ユーザーが同時に複数のファイルを開いたときに、アプリがどのように動作するかを指定します。</span><span class="sxs-lookup"><span data-stu-id="ed335-274">Specify how your app behaves when a user opens multiple files simultaneously.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="ed335-275">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-275">XML namespaces</span></span>

* <span data-ttu-id="ed335-276">http://schemas.microsoft.com/appx/manifest/uap/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-276">http://schemas.microsoft.com/appx/manifest/uap/windows10</span></span>
* <span data-ttu-id="ed335-277">http://schemas.microsoft.com/appx/manifest/uap/windows10/2</span><span class="sxs-lookup"><span data-stu-id="ed335-277">http://schemas.microsoft.com/appx/manifest/uap/windows10/2</span></span>
* <span data-ttu-id="ed335-278">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span><span class="sxs-lookup"><span data-stu-id="ed335-278">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-279">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-279">Elements and attributes of this extension</span></span>

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
<span data-ttu-id="ed335-280">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-280">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="ed335-281">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-281">Name</span></span> |<span data-ttu-id="ed335-282">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-282">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-283">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-283">Category</span></span> |<span data-ttu-id="ed335-284">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-284">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="ed335-285">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-285">Name</span></span> |<span data-ttu-id="ed335-286">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-286">A unique Id for your app.</span></span> |
|<span data-ttu-id="ed335-287">MultiSelectModel</span><span class="sxs-lookup"><span data-stu-id="ed335-287">MultiSelectModel</span></span> |<span data-ttu-id="ed335-288">下を参照</span><span class="sxs-lookup"><span data-stu-id="ed335-288">See below</span></span> |
|<span data-ttu-id="ed335-289">FileType</span><span class="sxs-lookup"><span data-stu-id="ed335-289">FileType</span></span> |<span data-ttu-id="ed335-290">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="ed335-290">The relevant file extensions.</span></span> |

**<span data-ttu-id="ed335-291">MultSelectModel</span><span class="sxs-lookup"><span data-stu-id="ed335-291">MultSelectModel</span></span>**

<span data-ttu-id="ed335-292">パッケージ デスクトップ アプリには、通常のデスクトップ アプリと同じ 3 つのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="ed335-292">packaged desktop apps have the same three options as regular desktop apps.</span></span>

 * ``Player``<span data-ttu-id="ed335-293">: アプリは、1 回アクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-293">: Your app is activated one time.</span></span> <span data-ttu-id="ed335-294">選択されているすべてのファイルが、引数パラメーターとしてアプリに渡されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-294">All of the selected files are passed to your app as argument parameters.</span></span>
 * ``Single``<span data-ttu-id="ed335-295">: アプリは、最初に選択されたファイルに対して 1 回アクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-295">: Your app is activated one time for the first selected file.</span></span> <span data-ttu-id="ed335-296">その他のファイルは無視されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-296">Other files are ignored.</span></span>
 * ``Document``<span data-ttu-id="ed335-297">: 選択された各ファイルについて、アプリの新しい独立したインスタンスがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-297">: A new, separate instance of your app is activated for each selected file.</span></span>

 <span data-ttu-id="ed335-298">ファイルの種類やアクションごとに、さまざまな環境設定項目を設定できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-298">You can set different preferences for different file types and actions.</span></span> <span data-ttu-id="ed335-299">たとえば、*Documents* は *Document* モードで開き、*Images* は *Player* モードで開くことができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-299">For example, you may wish to open *Documents* in *Document* mode and *Images* in *Player* mode.</span></span>

#### <a name="example"></a><span data-ttu-id="ed335-300">例</span><span class="sxs-lookup"><span data-stu-id="ed335-300">Example</span></span>

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

<span data-ttu-id="ed335-301">ユーザーが 15 個以下のファイルを開いた場合、**MultiSelectModel** 属性の既定値は *Player* になります。</span><span class="sxs-lookup"><span data-stu-id="ed335-301">If the user opens 15 or fewer files, the default choice for the **MultiSelectModel** attribute is *Player*.</span></span> <span data-ttu-id="ed335-302">それ以外の場合、既定値は *Document* です。</span><span class="sxs-lookup"><span data-stu-id="ed335-302">Otherwise, the default is *Document*.</span></span> <span data-ttu-id="ed335-303">UWP アプリは常に *Player* として起動されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-303">UWP apps are always started as *Player*.</span></span>

<span id="show" />
### <a name="show-file-contents-in-a-thumbnail-image-within-file-explorer"></a><span data-ttu-id="ed335-304">エクスプ ローラーでサムネイル画像のファイル内容を表示する</span><span class="sxs-lookup"><span data-stu-id="ed335-304">Show file contents in a thumbnail image within File Explorer</span></span>

<span data-ttu-id="ed335-305">ファイルが中アイコン、大アイコン、特大アイコンで表示された場合に、ファイル内容のサムネイル画像をユーザーが確認できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ed335-305">Enable users to view a thumbnail image of the file's contents when the icon of the file appears in the medium, large, or extra large size.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="ed335-306">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-306">XML namespace</span></span>

* <span data-ttu-id="ed335-307">http://schemas.microsoft.com/appx/manifest/uap/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-307">http://schemas.microsoft.com/appx/manifest/uap/windows10</span></span>
* <span data-ttu-id="ed335-308">http://schemas.microsoft.com/appx/manifest/uap/windows10/2</span><span class="sxs-lookup"><span data-stu-id="ed335-308">http://schemas.microsoft.com/appx/manifest/uap/windows10/2</span></span>
* <span data-ttu-id="ed335-309">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span><span class="sxs-lookup"><span data-stu-id="ed335-309">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span></span>
* <span data-ttu-id="ed335-310">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span><span class="sxs-lookup"><span data-stu-id="ed335-310">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-311">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-311">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.fileTypeAssociation">
    <FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>"[FileExtension]"</FileType>
        </SupportedFileTypes>
        <ThumbnailHandler
            Clsid  ="[Clsid  ]"
            Cutoff="[Cutoff]"
            Treatment="[Treatment]" />
    </FileTypeAssociation>
</Extension>
```

<span data-ttu-id="ed335-312">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-312">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="ed335-313">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-313">Name</span></span> |<span data-ttu-id="ed335-314">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-314">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-315">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-315">Category</span></span> |<span data-ttu-id="ed335-316">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-316">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="ed335-317">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-317">Name</span></span> |<span data-ttu-id="ed335-318">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-318">A unique Id for your app.</span></span> |
|<span data-ttu-id="ed335-319">FileType</span><span class="sxs-lookup"><span data-stu-id="ed335-319">FileType</span></span> |<span data-ttu-id="ed335-320">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="ed335-320">The relevant file extensions.</span></span> |
|<span data-ttu-id="ed335-321">Clsid</span><span class="sxs-lookup"><span data-stu-id="ed335-321">Clsid</span></span>   |<span data-ttu-id="ed335-322">アプリのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-322">The class ID of your app.</span></span> |
|<span data-ttu-id="ed335-323">Cutoff</span><span class="sxs-lookup"><span data-stu-id="ed335-323">Cutoff</span></span> |<span data-ttu-id="ed335-324">サムネイル画像を使用するサイズの下限。これ以上小さいサイズの場合、サムネイル画像が使用されません。</span><span class="sxs-lookup"><span data-stu-id="ed335-324">The size below which a thumbnail image is not used.</span></span> <span data-ttu-id="ed335-325">「[サムネイルのキャッシュとサイズ](https://msdn.microsoft.com/library/windows/desktop/cc144118.aspx#cache)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-325">See [Thumbnail Cache and Sizing](https://msdn.microsoft.com/library/windows/desktop/cc144118.aspx#cache)</span></span> |
|<span data-ttu-id="ed335-326">Treatment</span><span class="sxs-lookup"><span data-stu-id="ed335-326">Treatment</span></span> |<span data-ttu-id="ed335-327">サムネイル アイコンの外観を定義する[サムネイル装飾](https://msdn.microsoft.com/library/windows/desktop/cc144118.aspx#adornments)。</span><span class="sxs-lookup"><span data-stu-id="ed335-327">The [thumbnail adornment](https://msdn.microsoft.com/library/windows/desktop/cc144118.aspx#adornments) that defines the look of the thumbnail icon.</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-328">例</span><span class="sxs-lookup"><span data-stu-id="ed335-328">Example</span></span>

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
              Clsid  ="20000000-0000-0000-0000-000000000001"
              Cutoff="20x20"
              Treatment="Video Sprockets" />
            </uap3:FileTypeAssociation>
         </uap::Extension>
      </Extensions>
    </Application>
  </Applications>
</Package>
```

<span id="preview" />
### <a name="show-file-contents-in-the-preview-pane-of-file-explorer"></a><span data-ttu-id="ed335-329">エクスプローラーのプレビュー ウィンドウにファイル内容を表示する</span><span class="sxs-lookup"><span data-stu-id="ed335-329">Show file contents in the Preview pane of File Explorer</span></span>

<span data-ttu-id="ed335-330">エクスプローラーのプレビュー ウィンドウで、ユーザーがファイルの内容をプレビューできるようにします。</span><span class="sxs-lookup"><span data-stu-id="ed335-330">Enable users to preview a file's contents in the Preview pane of File Explorer.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="ed335-331">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-331">XML namespace</span></span>

* <span data-ttu-id="ed335-332">http://schemas.microsoft.com/appx/manifest/uap/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-332">http://schemas.microsoft.com/appx/manifest/uap/windows10</span></span>
* <span data-ttu-id="ed335-333">http://schemas.microsoft.com/appx/manifest/uap/windows10/2</span><span class="sxs-lookup"><span data-stu-id="ed335-333">http://schemas.microsoft.com/appx/manifest/uap/windows10/2</span></span>
* <span data-ttu-id="ed335-334">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span><span class="sxs-lookup"><span data-stu-id="ed335-334">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span></span>
* <span data-ttu-id="ed335-335">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span><span class="sxs-lookup"><span data-stu-id="ed335-335">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-336">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-336">Elements and attributes of this extension</span></span>

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

<span data-ttu-id="ed335-337">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-337">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="ed335-338">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-338">Name</span></span> |<span data-ttu-id="ed335-339">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-339">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-340">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-340">Category</span></span> |<span data-ttu-id="ed335-341">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-341">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="ed335-342">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-342">Name</span></span> |<span data-ttu-id="ed335-343">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-343">A unique Id for your app.</span></span> |
|<span data-ttu-id="ed335-344">FileType</span><span class="sxs-lookup"><span data-stu-id="ed335-344">FileType</span></span> |<span data-ttu-id="ed335-345">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="ed335-345">The relevant file extensions.</span></span> |
|<span data-ttu-id="ed335-346">Clsid</span><span class="sxs-lookup"><span data-stu-id="ed335-346">Clsid</span></span>   |<span data-ttu-id="ed335-347">アプリのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-347">The class ID of your app.</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-348">例</span><span class="sxs-lookup"><span data-stu-id="ed335-348">Example</span></span>

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

<span id="enable" />
### <a name="enable-users-to-group-files-by-using-the-kind-column-in-file-explorer"></a><span data-ttu-id="ed335-349">ユーザーがエクスプローラーの [種類] 列を使用してファイルをグループ化できるようにする</span><span class="sxs-lookup"><span data-stu-id="ed335-349">Enable users to group files by using the Kind column in File Explorer</span></span>

<span data-ttu-id="ed335-350">ファイルの種類に関する 1 つまたは複数の定義済みの値を **Kind** フィールドに関連付けることができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-350">You can associate one or more predefined values for your file types with the **Kind** field.</span></span>

<span data-ttu-id="ed335-351">ユーザーはエクスプローラーでこのフィールドを使用して、ファイルをグループ化できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-351">In File Explorer, users can group those files by using that field.</span></span> <span data-ttu-id="ed335-352">また、このフィールドは、システム コンポーネントによって、インデックス作成などのさまざまな目的にも使用されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-352">System components also use this field for various purposes such as indexing.</span></span>

<span data-ttu-id="ed335-353">**Kind** フィールドの詳細と、このフィールドに使用できる値については、「[種類名の使用](https://msdn.microsoft.com/library/windows/desktop/cc144136.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-353">For more information about the **Kind** field and the values that you can use for this field, see [Using Kind Names](https://msdn.microsoft.com/library/windows/desktop/cc144136.aspx).</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="ed335-354">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-354">XML namespaces</span></span>

* <span data-ttu-id="ed335-355">http://schemas.microsoft.com/appx/manifest/uap/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-355">http://schemas.microsoft.com/appx/manifest/uap/windows10</span></span>
* <span data-ttu-id="ed335-356">http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3</span><span class="sxs-lookup"><span data-stu-id="ed335-356">http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities/3</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-357">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-357">Elements and attributes of this extension</span></span>

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
<span data-ttu-id="ed335-358">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-358">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="ed335-359">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-359">Name</span></span> |<span data-ttu-id="ed335-360">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-360">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-361">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-361">Category</span></span> |<span data-ttu-id="ed335-362">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-362">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="ed335-363">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-363">Name</span></span> |<span data-ttu-id="ed335-364">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-364">A unique Id for your app.</span></span> |
|<span data-ttu-id="ed335-365">FileType</span><span class="sxs-lookup"><span data-stu-id="ed335-365">FileType</span></span> |<span data-ttu-id="ed335-366">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="ed335-366">The relevant file extensions.</span></span> |
|<span data-ttu-id="ed335-367">value</span><span class="sxs-lookup"><span data-stu-id="ed335-367">value</span></span> |<span data-ttu-id="ed335-368">有効な [Kind 値](https://msdn.microsoft.com/en-us/library/windows/desktop/cc144136.aspx#kind_hierarchy)。</span><span class="sxs-lookup"><span data-stu-id="ed335-368">A valid [Kind value](https://msdn.microsoft.com/en-us/library/windows/desktop/cc144136.aspx#kind_hierarchy)</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-369">例</span><span class="sxs-lookup"><span data-stu-id="ed335-369">Example</span></span>

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
<span id="make-file-properties" />
### <a name="make-file-properties-available-to-search-index-property-dialogs-and-the-details-pane"></a><span data-ttu-id="ed335-370">ファイルのプロパティを検索、インデックス、プロパティ ダイアログ、詳細ウィンドウに利用できるようにする</span><span class="sxs-lookup"><span data-stu-id="ed335-370">Make file properties available to search, index, property dialogs, and the details pane</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="ed335-371">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-371">XML namespace</span></span>

* <span data-ttu-id="ed335-372">http://schemas.microsoft.com/appx/manifest/uap/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-372">http://schemas.microsoft.com/appx/manifest/uap/windows10</span></span>
* <span data-ttu-id="ed335-373">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span><span class="sxs-lookup"><span data-stu-id="ed335-373">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span></span>
* <span data-ttu-id="ed335-374">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span><span class="sxs-lookup"><span data-stu-id="ed335-374">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-375">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-375">Elements and attributes of this extension</span></span>

```XML
<uap:Extension Category="windows.fileTypeAssociation">
    <uap:FileTypeAssociation Name="[AppID]">
        <SupportedFileTypes>
            <FileType>.bar</FileType>
        </SupportedFileTypes>
        <DesktopPropertyHandler Clsid ="[Clsid ]"/>
    </uap:FileTypeAssociation>
</uap:Extension>
```
**<span data-ttu-id="ed335-376">主な要素と属性の説明</span><span class="sxs-lookup"><span data-stu-id="ed335-376">Key element and attribute descriptions</span></span>**

<span data-ttu-id="ed335-377">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-377">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="ed335-378">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-378">Name</span></span> |<span data-ttu-id="ed335-379">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-379">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-380">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-380">Category</span></span> |<span data-ttu-id="ed335-381">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-381">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="ed335-382">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-382">Name</span></span> |<span data-ttu-id="ed335-383">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-383">A unique Id for your app.</span></span> |
|<span data-ttu-id="ed335-384">FileType</span><span class="sxs-lookup"><span data-stu-id="ed335-384">FileType</span></span> |<span data-ttu-id="ed335-385">関連するファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="ed335-385">The relevant file extensions.</span></span> |
|<span data-ttu-id="ed335-386">Clsid</span><span class="sxs-lookup"><span data-stu-id="ed335-386">Clsid</span></span>  |<span data-ttu-id="ed335-387">アプリのクラス ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-387">The class ID of your app.</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-388">例</span><span class="sxs-lookup"><span data-stu-id="ed335-388">Example</span></span>

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

<span id="start" />
## <a name="start-your-app-in-different-ways"></a><span data-ttu-id="ed335-389">さまざまな方法でアプリを起動する</span><span class="sxs-lookup"><span data-stu-id="ed335-389">Start your app in different ways</span></span>

* [<span data-ttu-id="ed335-390">プロトコルを使用してアプリを起動する</span><span class="sxs-lookup"><span data-stu-id="ed335-390">Start your app by using a protocol</span></span>](#protocol)
* [<span data-ttu-id="ed335-391">エイリアスを使用してアプリを起動する</span><span class="sxs-lookup"><span data-stu-id="ed335-391">Start your app by using an alias</span></span>](#alias)
* [<span data-ttu-id="ed335-392">ユーザーが Windows にログオンしたときに実行可能ファイルを起動する</span><span class="sxs-lookup"><span data-stu-id="ed335-392">Start an executable file when users log into Windows</span></span>](#executable)
* [<span data-ttu-id="ed335-393">Windows ストアから更新プログラムを受信した後、自動的に再起動する</span><span class="sxs-lookup"><span data-stu-id="ed335-393">Restart automatically after receiving an update from the Windows Store</span></span>](#updates)

<span id="protocol" />
### <a name="start-your-app-by-using-a-protocol"></a><span data-ttu-id="ed335-394">プロトコルを使用してアプリを起動する</span><span class="sxs-lookup"><span data-stu-id="ed335-394">Start your app by using a protocol</span></span>

<span data-ttu-id="ed335-395">プロトコルの関連付けによって、他のプログラムやシステム コンポーネントがパッケージ アプリと相互運用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ed335-395">Protocol associations can enable other programs and system components to interoperate with your packaged app.</span></span> <span data-ttu-id="ed335-396">プロトコルを使用してパッケージ アプリを起動する場合、アプリが適切に動作できるように、特定のパラメーターを指定してアプリのアクティブ化イベント引数に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-396">When your packaged app is started by using a protocol, you can specify specific parameters to pass to its activation event arguments so it can behave accordingly.</span></span> <span data-ttu-id="ed335-397">パラメーターは、完全に信頼できるパッケージ アプリでのみサポートされています。</span><span class="sxs-lookup"><span data-stu-id="ed335-397">Parameters are supported only for packaged, full-trust apps.</span></span> <span data-ttu-id="ed335-398">UWP アプリでは、パラメーターを使用できません。</span><span class="sxs-lookup"><span data-stu-id="ed335-398">UWP apps can't use parameters.</span></span>  

#### <a name="xml-namespace"></a><span data-ttu-id="ed335-399">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-399">XML namespace</span></span>

<span data-ttu-id="ed335-400">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span><span class="sxs-lookup"><span data-stu-id="ed335-400">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span></span>


#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-401">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-401">Elements and attributes of this extension</span></span>

```XML
<Extension
    Category="windows.protocol">
    <Protocol
      Name="[Protocol name]"
      Parameters="[Parameters]" />
</Extension>
```

<span data-ttu-id="ed335-402">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-protocol)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-402">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-protocol).</span></span>

|<span data-ttu-id="ed335-403">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-403">Name</span></span> |<span data-ttu-id="ed335-404">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-404">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-405">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-405">Category</span></span> |<span data-ttu-id="ed335-406">常に ``windows.protocol`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-406">Always ``windows.protocol``.</span></span>
|<span data-ttu-id="ed335-407">Name</span><span class="sxs-lookup"><span data-stu-id="ed335-407">Name</span></span> |<span data-ttu-id="ed335-408">プロトコルの名前。</span><span class="sxs-lookup"><span data-stu-id="ed335-408">The name of the protocol.</span></span> |
|<span data-ttu-id="ed335-409">Parameters</span><span class="sxs-lookup"><span data-stu-id="ed335-409">Parameters</span></span> |<span data-ttu-id="ed335-410">アプリアクティブ化するときにイベント引数としてアプリに渡すパラメーターや値のリスト。</span><span class="sxs-lookup"><span data-stu-id="ed335-410">The list of parameters and values to pass to your app as event arguments when the app is activated.</span></span> <span data-ttu-id="ed335-411">変数にファイル パスが含まれる可能性がある場合は、パラメーター値を引用符で囲みます。</span><span class="sxs-lookup"><span data-stu-id="ed335-411">If a variable can contain a file path, wrap the parameter value in quotes.</span></span> <span data-ttu-id="ed335-412">これにより、パスにスペースが含まれている場合に発生する問題を回避できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-412">That will avoid any issues that happen in cases where the path includes spaces.</span></span> |

### <a name="example"></a><span data-ttu-id="ed335-413">例</span><span class="sxs-lookup"><span data-stu-id="ed335-413">Example</span></span>

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
<span id="alias" />
### <a name="start-your-app-by-using-an-alias"></a><span data-ttu-id="ed335-414">エイリアスを使用してアプリを起動する</span><span class="sxs-lookup"><span data-stu-id="ed335-414">Start your app by using an alias</span></span>

<span data-ttu-id="ed335-415">ユーザーと他のプロセスは、アプリの完全パスを指定することなく、エイリアスを使用してアプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-415">Users and other processes can use an alias to start your app without having to specify the full path to your app.</span></span> <span data-ttu-id="ed335-416">そのエイリアス名を指定できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-416">You can specify that alias name.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="ed335-417">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-417">XML namespaces</span></span>

* <span data-ttu-id="ed335-418">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span><span class="sxs-lookup"><span data-stu-id="ed335-418">http://schemas.microsoft.com/appx/manifest/uap/windows10/3</span></span>
* <span data-ttu-id="ed335-419">http://schemas.microsoft.com/appx/manifest/desktop/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-419">http://schemas.microsoft.com/appx/manifest/desktop/windows10</span></span>


#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-420">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-420">Elements and attributes of this extension</span></span>

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

|<span data-ttu-id="ed335-421">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-421">Name</span></span> |<span data-ttu-id="ed335-422">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-422">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-423">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-423">Category</span></span> |<span data-ttu-id="ed335-424">常に ``windows.appExecutionAlias`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-424">Always ``windows.appExecutionAlias``.</span></span>
|<span data-ttu-id="ed335-425">Executable</span><span class="sxs-lookup"><span data-stu-id="ed335-425">Executable</span></span> |<span data-ttu-id="ed335-426">エイリアスが呼び出されたときに起動する実行可能ファイルの相対パス。</span><span class="sxs-lookup"><span data-stu-id="ed335-426">The relative path to the executable to start when the alias is invoked.</span></span> |
|<span data-ttu-id="ed335-427">Alias</span><span class="sxs-lookup"><span data-stu-id="ed335-427">Alias</span></span> |<span data-ttu-id="ed335-428">アプリの短い名前。</span><span class="sxs-lookup"><span data-stu-id="ed335-428">The short name for your app.</span></span> <span data-ttu-id="ed335-429">常に、拡張子 ".exe" で終わっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed335-429">It must always end with the ".exe" extension.</span></span> <span data-ttu-id="ed335-430">パッケージ内のアプリケーションごとにアプリの実行エイリアスは 1 つだけ指定できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-430">You can only specify a single app execution alias for each application in the package.</span></span> <span data-ttu-id="ed335-431">複数のアプリで同じエイリアスが登録されている場合、システムは最後に登録されたアプリを呼び出します。したがって、他のアプリによって上書きされる可能性が低い一意のエイリアスを選んでください。</span><span class="sxs-lookup"><span data-stu-id="ed335-431">If multiple apps register for the same alias, the system will invoke the last one that was registered, so make sure to choose a unique alias other apps are unlikely to override.</span></span>
|

#### <a name="example"></a><span data-ttu-id="ed335-432">例</span><span class="sxs-lookup"><span data-stu-id="ed335-432">Example</span></span>

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

<span data-ttu-id="ed335-433">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-433">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap-filetypeassociation).</span></span>

|<span data-ttu-id="ed335-434">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-434">Name</span></span> |<span data-ttu-id="ed335-435">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-435">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-436">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-436">Category</span></span> |<span data-ttu-id="ed335-437">常に ``windows.fileTypeAssociation`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-437">Always ``windows.fileTypeAssociation``.</span></span>
|<span data-ttu-id="ed335-438">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-438">Name</span></span> |<span data-ttu-id="ed335-439">アプリの一意の ID。</span><span class="sxs-lookup"><span data-stu-id="ed335-439">A unique Id for your app.</span></span> <span data-ttu-id="ed335-440">この ID は、ファイルの種類の関連付けによって関連付けられたハッシュ対象の[プログラム識別子 (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) を生成するために内部で使用されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-440">This Id is used internally to generate a hashed [programmatic identifier (ProgID)](https://msdn.microsoft.com/library/windows/desktop/cc144152.aspx) associated with your file type association.</span></span> <span data-ttu-id="ed335-441">この ID を使って、アプリの今後のバージョンで変更を管理することができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-441">You can use this Id to manage changes in future versions of your app.</span></span>   |
|<span data-ttu-id="ed335-442">FileType</span><span class="sxs-lookup"><span data-stu-id="ed335-442">FileType</span></span> |<span data-ttu-id="ed335-443">アプリでサポートされているファイル拡張子。</span><span class="sxs-lookup"><span data-stu-id="ed335-443">The file extension supported by your app.</span></span> |

<span id="executable" />
### <a name="start-an-executable-file-when-users-log-into-windows"></a><span data-ttu-id="ed335-444">ユーザーが Windows にログオンしたときに実行可能ファイルを起動する</span><span class="sxs-lookup"><span data-stu-id="ed335-444">Start an executable file when users log into Windows</span></span>

<span data-ttu-id="ed335-445">スタートアップ タスクによって、アプリでは、ユーザーがログオンするたびに自動的に実行可能ファイルを実行できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-445">Startup tasks allow your app to run an executable automatically whenever a user logs on.</span></span>

> [!NOTE]
> <span data-ttu-id="ed335-446">このスタートアップ タスクを登録するには、ユーザーが少なくとも 1 回アプリを起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed335-446">The user has to start your app at least one time to register this startup task.</span></span>

<span data-ttu-id="ed335-447">アプリでは、複数のスタートアップ タスクを宣言できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-447">Your app can declare multiple startup tasks.</span></span> <span data-ttu-id="ed335-448">各タスクは独立して起動されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-448">Each task starts independently.</span></span> <span data-ttu-id="ed335-449">すべてのスタートアップ タスクは、タスク マネージャーの **[スタートアップ]** タブに、アプリのマニフェストで指定した名前とアプリのアイコンを使って表示されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-449">All startup tasks will appear in Task Manager under the **Startup** tab with the name that you specify in your app's manifest and your app's icon.</span></span> <span data-ttu-id="ed335-450">タスク マネージャーによって、タスクの起動への影響が自動的に分析されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-450">Task Manager will automatically analyze the startup impact of your tasks.</span></span>

<span data-ttu-id="ed335-451">ユーザーは、タスク マネージャーを使用して、アプリのスタートアップ タスクを手動で無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-451">Users can manually disable your app's startup task by using Task Manager.</span></span> <span data-ttu-id="ed335-452">ユーザーがタスクを無効にした場合、プログラムでタスクを再度有効にすることはできません。</span><span class="sxs-lookup"><span data-stu-id="ed335-452">If a user disables a task, you can't programmatically re-enable it.</span></span>

#### <a name="xml-namespace"></a><span data-ttu-id="ed335-453">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-453">XML namespace</span></span>

<span data-ttu-id="ed335-454">http://schemas.microsoft.com/appx/manifest/desktop/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-454">http://schemas.microsoft.com/appx/manifest/desktop/windows10</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-455">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-455">Elements and attributes of this extension</span></span>

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

|<span data-ttu-id="ed335-456">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-456">Name</span></span> |<span data-ttu-id="ed335-457">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-457">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-458">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-458">Category</span></span> |<span data-ttu-id="ed335-459">常に ``windows.startupTask`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-459">Always ``windows.startupTask``.</span></span>|
|<span data-ttu-id="ed335-460">Executable</span><span class="sxs-lookup"><span data-stu-id="ed335-460">Executable</span></span> |<span data-ttu-id="ed335-461">起動する実行可能ファイルへの相対パス。</span><span class="sxs-lookup"><span data-stu-id="ed335-461">The relative path to the executable file to start.</span></span> |
|<span data-ttu-id="ed335-462">TaskId</span><span class="sxs-lookup"><span data-stu-id="ed335-462">TaskId</span></span> |<span data-ttu-id="ed335-463">タスクの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="ed335-463">A unique identifier for your task.</span></span> <span data-ttu-id="ed335-464">この識別子を使用して、アプリは [Windows.ApplicationModel.StartupTask](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.StartupTask) クラスの API を呼び出し、プログラムでスタートアップ タスクを有効または無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-464">Using this identifier, your app can call the APIs in the [Windows.ApplicationModel.StartupTask](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.StartupTask) class to programmatically enable or disable a startup task.</span></span> |
|<span data-ttu-id="ed335-465">Enabled</span><span class="sxs-lookup"><span data-stu-id="ed335-465">Enabled</span></span> |<span data-ttu-id="ed335-466">初めて起動したタスクを有効にするか、無効にするかを指定します。</span><span class="sxs-lookup"><span data-stu-id="ed335-466">Indicates whether the task first starts enabled or disabled.</span></span> <span data-ttu-id="ed335-467">有効になっているタスクは、(ユーザーが無効にしていない限り) 次回ユーザーがログオンするときに実行されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-467">Enabled tasks will run the next time the user logs on (unless the user disables it).</span></span> |
|<span data-ttu-id="ed335-468">DisplayName</span><span class="sxs-lookup"><span data-stu-id="ed335-468">DisplayName</span></span> |<span data-ttu-id="ed335-469">タスク マネージャーに表示されるタスクの名前。</span><span class="sxs-lookup"><span data-stu-id="ed335-469">The name of the task that appears in Task Manager.</span></span> <span data-ttu-id="ed335-470">この文字列は、```ms-resource``` を使用してローカライズできます。</span><span class="sxs-lookup"><span data-stu-id="ed335-470">You can localize this string by using ```ms-resource```.</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-471">例</span><span class="sxs-lookup"><span data-stu-id="ed335-471">Example</span></span>

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

<span id="updates" />
### <a name="restart-automatically-after-receiving-an-update-from-the-windows-store"></a><span data-ttu-id="ed335-472">Windows ストアから更新プログラムを受信した後、自動的に再起動する</span><span class="sxs-lookup"><span data-stu-id="ed335-472">Restart automatically after receiving an update from the Windows Store</span></span>

<span data-ttu-id="ed335-473">ユーザーがアプリに更新プログラムをインストールするときにアプリが開かれている場合、アプリは終了します。</span><span class="sxs-lookup"><span data-stu-id="ed335-473">If your app is open when users install an update to it, the app closes.</span></span>

<span data-ttu-id="ed335-474">更新の完了後にアプリを再起動する場合は、再開するすべてのプロセスで [RegisterApplicationRestart](https://msdn.microsoft.com/library/windows/desktop/aa373347.aspx) 機能を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ed335-474">If you want that app to restart after the update completes, call the  [RegisterApplicationRestart](https://msdn.microsoft.com/library/windows/desktop/aa373347.aspx) function in every process that you want to restart.</span></span>

<span data-ttu-id="ed335-475">[WM_QUERYENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376890.aspx) メッセージを受け取るアプリの各アクティブ ウィンドウ。</span><span class="sxs-lookup"><span data-stu-id="ed335-475">Each active window in your app receives a [WM_QUERYENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376890.aspx) message.</span></span> <span data-ttu-id="ed335-476">この時点では、アプリで [RegisterApplicationRestart](https://msdn.microsoft.com/library/windows/desktop/aa373347.aspx) 機能を再度呼び出して、必要に応じてコマンド ラインをアップデートすることができます。</span><span class="sxs-lookup"><span data-stu-id="ed335-476">At this point, your app can call the [RegisterApplicationRestart](https://msdn.microsoft.com/library/windows/desktop/aa373347.aspx) function again to update the command line if necessary.</span></span>

<span data-ttu-id="ed335-477">アプリの各アクティブ ウィンドウで、[WM_ENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376889.aspx) メッセージを受け取ったら、アプリでデータを保存してシャットダウンする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed335-477">When each active window in your app receives the [WM_ENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376889.aspx) message, your app should save data and shut down.</span></span>

>[!NOTE]
<span data-ttu-id="ed335-478">また、アプリで [WM_ENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376889.aspx) メッセージが処理されない場合は、アクティブ ウィンドウにも [WM_CLOSE](https://msdn.microsoft.com/library/windows/desktop/ms632617.aspx) メッセージが届きます。</span><span class="sxs-lookup"><span data-stu-id="ed335-478">Your active windows also receive the [WM_CLOSE](https://msdn.microsoft.com/library/windows/desktop/ms632617.aspx) message in case the app doesn't handle the [WM_ENDSESSION](https://msdn.microsoft.com/library/windows/desktop/aa376889.aspx) message.</span></span>

<span data-ttu-id="ed335-479">この時点で、アプリが 30 秒内に終了しなければ、プラットフォームによって強制終了されます。</span><span class="sxs-lookup"><span data-stu-id="ed335-479">At this point, your app has 30 seconds to close it's own processes or the platform terminates them forcefully.</span></span>

<span data-ttu-id="ed335-480">更新が完了したら、アプリが再起動します。</span><span class="sxs-lookup"><span data-stu-id="ed335-480">After the update is complete, your app restarts.</span></span>

## <a name="work-with-other-applications"></a><span data-ttu-id="ed335-481">他のアプリケーションと連携する</span><span class="sxs-lookup"><span data-stu-id="ed335-481">Work with other applications</span></span>

<span data-ttu-id="ed335-482">他のアプリとの統合、他のプロセスの開始、情報の共有が可能です。</span><span class="sxs-lookup"><span data-stu-id="ed335-482">Integrate with other apps, start other processes or share information.</span></span>

* [<span data-ttu-id="ed335-483">印刷をサポートするアプリケーションで印刷先としてアプリを表示する</span><span class="sxs-lookup"><span data-stu-id="ed335-483">Make your app appear as the print target in applications that support printing</span></span>](#printing)
* [<span data-ttu-id="ed335-484">他の Windows アプリケーションとフォントを共有する</span><span class="sxs-lookup"><span data-stu-id="ed335-484">Share fonts with other Windows applications</span></span>](#fonts)
* [<span data-ttu-id="ed335-485">ユニバーサル Windows プラットフォーム (UWP) アプリから Win32 プロセスを開始する</span><span class="sxs-lookup"><span data-stu-id="ed335-485">Start a Win32 process from a Universal Windows Platform (UWP) app</span></span>](#win32-process)

<span id="printing" />
### <a name="make-your-app-appear-as-the-print-target-in-applications-that-support-printing"></a><span data-ttu-id="ed335-486">印刷をサポートするアプリケーションで印刷先としてアプリを表示する</span><span class="sxs-lookup"><span data-stu-id="ed335-486">Make your app appear as the print target in applications that support printing</span></span>

<span data-ttu-id="ed335-487">メモ帳など別のアプリからデータを印刷できるようにするには、そのアプリで利用できる印刷先の一覧に、印刷先として対象のアプリが表示されるように設定できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-487">When users want to print data from another app such as Notepad, you can make your app appear as a print target in the app's list of available print targets.</span></span>

<span data-ttu-id="ed335-488">印刷データを XML Paper Specification (XPS) 形式で受信できるように、アプリを変更する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed335-488">You'll have to modify your app so that it receives print data in XML Paper Specification (XPS) format.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="ed335-489">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-489">XML namespaces</span></span>

<span data-ttu-id="ed335-490">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span><span class="sxs-lookup"><span data-stu-id="ed335-490">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-491">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-491">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.appPrinter">
    <AppPrinter
        DisplayName="[DisplayName]"
        Parameters="[Parameters]" />
</Extension>
```

<span data-ttu-id="ed335-492">完全なスキーマ リファレンスについては、[こちら](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-desktop2-appprinter)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-492">Find the complete schema reference [here](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-desktop2-appprinter).</span></span>

|<span data-ttu-id="ed335-493">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-493">Name</span></span> |<span data-ttu-id="ed335-494">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-494">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-495">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-495">Category</span></span> |<span data-ttu-id="ed335-496">常に ``windows.appPrinter`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-496">Always ``windows.appPrinter``.</span></span>
|<span data-ttu-id="ed335-497">DisplayName</span><span class="sxs-lookup"><span data-stu-id="ed335-497">DisplayName</span></span> |<span data-ttu-id="ed335-498">アプリの印刷先一覧に表示する名前。</span><span class="sxs-lookup"><span data-stu-id="ed335-498">The name that you want to appear in the list of print targets for an app.</span></span> |
|<span data-ttu-id="ed335-499">Parameters</span><span class="sxs-lookup"><span data-stu-id="ed335-499">Parameters</span></span> |<span data-ttu-id="ed335-500">要求を正しく処理するためにアプリが必要とするパラメーター。</span><span class="sxs-lookup"><span data-stu-id="ed335-500">Any parameters that your app requires to properly handle the request.</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-501">例</span><span class="sxs-lookup"><span data-stu-id="ed335-501">Example</span></span>

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
<span data-ttu-id="ed335-502">この拡張機能を使用するサンプルについては、[こちら](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/PrintToPDF)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-502">Find a sample that uses this extension [Here](https://github.com/Microsoft/DesktopBridgeToUWP-Samples/tree/master/Samples/PrintToPDF)</span></span>

<span id="fonts" />
### <a name="share-fonts-with-other-windows-applications"></a><span data-ttu-id="ed335-503">他の Windows アプリケーションとフォントを共有する</span><span class="sxs-lookup"><span data-stu-id="ed335-503">Share fonts with other Windows applications</span></span>

<span data-ttu-id="ed335-504">他の Windows アプリケーションとカスタム フォントを共有できます。</span><span class="sxs-lookup"><span data-stu-id="ed335-504">Share your custom fonts with other Windows applications.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="ed335-505">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-505">XML namespaces</span></span>

<span data-ttu-id="ed335-506">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span><span class="sxs-lookup"><span data-stu-id="ed335-506">http://schemas.microsoft.com/appx/manifest/desktop/windows10/2</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-507">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-507">Elements and attributes of this extension</span></span>

```XML
<Extension Category="windows.sharedFonts">
    <SharedFonts>
      <Font File="[FontFile]" />
    </SharedFonts>
  </Extension>
```

<span data-ttu-id="ed335-508">完全なスキーマ リファレンスについては、[こちら](https://review.docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap4-sharedfonts)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-508">Find the complete schema reference [here](https://review.docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-uap4-sharedfonts).</span></span>


|<span data-ttu-id="ed335-509">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-509">Name</span></span> |<span data-ttu-id="ed335-510">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-510">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-511">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-511">Category</span></span> |<span data-ttu-id="ed335-512">常に ``windows.sharedFonts`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-512">Always ``windows.sharedFonts``.</span></span>
|<span data-ttu-id="ed335-513">File</span><span class="sxs-lookup"><span data-stu-id="ed335-513">File</span></span> |<span data-ttu-id="ed335-514">共有するフォントが格納されたファイル。</span><span class="sxs-lookup"><span data-stu-id="ed335-514">The file that contains the fonts that you want to share.</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-515">例</span><span class="sxs-lookup"><span data-stu-id="ed335-515">Example</span></span>

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
<span id="win32-process" />
### <a name="start-a-win32-process-from-a-universal-windows-platform-uwp-app"></a><span data-ttu-id="ed335-516">ユニバーサル Windows プラットフォーム (UWP) アプリから Win32 プロセスを開始する</span><span class="sxs-lookup"><span data-stu-id="ed335-516">Start a Win32 process from a Universal Windows Platform (UWP) app</span></span>

<span data-ttu-id="ed335-517">完全信頼で実行される Win32 プロセスを開始します。</span><span class="sxs-lookup"><span data-stu-id="ed335-517">Start a Win32 process that runs in full-trust.</span></span>

#### <a name="xml-namespaces"></a><span data-ttu-id="ed335-518">XML 名前空間</span><span class="sxs-lookup"><span data-stu-id="ed335-518">XML namespaces</span></span>

<span data-ttu-id="ed335-519">http://schemas.microsoft.com/appx/manifest/desktop/windows10</span><span class="sxs-lookup"><span data-stu-id="ed335-519">http://schemas.microsoft.com/appx/manifest/desktop/windows10</span></span>

#### <a name="elements-and-attributes-of-this-extension"></a><span data-ttu-id="ed335-520">この拡張機能の要素と属性</span><span class="sxs-lookup"><span data-stu-id="ed335-520">Elements and attributes of this extension</span></span>

```XML
<xtension Category="windows.fullTrustProcess" Executable="[executable file]">
  <FullTrustProcess>
    <ParameterGroup GroupId="[GroupID]" Parameters="[Parameters]"/>
  </FullTrustProcess>
</Extension>
```

|<span data-ttu-id="ed335-521">名前</span><span class="sxs-lookup"><span data-stu-id="ed335-521">Name</span></span> |<span data-ttu-id="ed335-522">説明</span><span class="sxs-lookup"><span data-stu-id="ed335-522">Description</span></span> |
|-------|-------------|
|<span data-ttu-id="ed335-523">Category</span><span class="sxs-lookup"><span data-stu-id="ed335-523">Category</span></span> |<span data-ttu-id="ed335-524">常に ``windows.fullTrustProcess`` です。</span><span class="sxs-lookup"><span data-stu-id="ed335-524">Always ``windows.fullTrustProcess``.</span></span>
|<span data-ttu-id="ed335-525">GroupID</span><span class="sxs-lookup"><span data-stu-id="ed335-525">GroupID</span></span> |<span data-ttu-id="ed335-526">実行可能ファイルに渡すパラメーターのセットを識別するための文字列。</span><span class="sxs-lookup"><span data-stu-id="ed335-526">A string that identifies a set of parameters that you want to pass to the executable.</span></span> |
|<span data-ttu-id="ed335-527">Parameters</span><span class="sxs-lookup"><span data-stu-id="ed335-527">Parameters</span></span> |<span data-ttu-id="ed335-528">実行可能ファイルに渡すパラメーター。</span><span class="sxs-lookup"><span data-stu-id="ed335-528">Parameters that you want to pass to the executable.</span></span> |

#### <a name="example"></a><span data-ttu-id="ed335-529">例</span><span class="sxs-lookup"><span data-stu-id="ed335-529">Example</span></span>

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
<span data-ttu-id="ed335-530">この拡張機能は、すべてのデバイスで実行できるユニバーサル Windows プラットフォームのユーザー インターフェイスを作成する一方で、Win32 アプリのコンポーネントについては完全信頼での実行を継続する場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="ed335-530">This extension might be useful if you want to create a Universal Windows Platform User interface that runs on all devices, but you want components of your Win32 app to continue running in full-trust.</span></span>

<span data-ttu-id="ed335-531">まず、Win32 アプリのデスクトップ ブリッジのパッケージを作成します。</span><span class="sxs-lookup"><span data-stu-id="ed335-531">Just create a desktop bridge package for your Win32 app.</span></span> <span data-ttu-id="ed335-532">そのうえで、この拡張機能を UWP アプリのパッケージ ファイルに追加してください。</span><span class="sxs-lookup"><span data-stu-id="ed335-532">Then, add this extension to the package file of your UWP app.</span></span> <span data-ttu-id="ed335-533">この拡張機能は、デスクトップ ブリッジ パッケージで実行可能ファイルを開始することを示します。</span><span class="sxs-lookup"><span data-stu-id="ed335-533">This extensions indicates that you want to start an executable file in the desktop bridge package.</span></span>  <span data-ttu-id="ed335-534">UWP アプリと Win32 アプリの間でやり取りを行うには、1 つまたは複数の[アプリ サービス](../launch-resume/app-services.md)を設定します。</span><span class="sxs-lookup"><span data-stu-id="ed335-534">If you want to communicate between your UWP app and your Win32 app, you can set up one or more [app services](../launch-resume/app-services.md) to do that.</span></span> <span data-ttu-id="ed335-535">このシナリオについては詳しくは、[こちら](https://blogs.msdn.microsoft.com/appconsult/2016/12/19/desktop-bridge-the-migrate-phase-invoking-a-win32-process-from-a-uwp-app/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-535">You can read more about this scenario [here](https://blogs.msdn.microsoft.com/appconsult/2016/12/19/desktop-bridge-the-migrate-phase-invoking-a-win32-process-from-a-uwp-app/).</span></span>

## <a name="next-steps"></a><span data-ttu-id="ed335-536">次のステップ</span><span class="sxs-lookup"><span data-stu-id="ed335-536">Next steps</span></span>

**<span data-ttu-id="ed335-537">特定の質問に対する回答を見つける</span><span class="sxs-lookup"><span data-stu-id="ed335-537">Find answers to specific questions</span></span>**

<span data-ttu-id="ed335-538">マイクロソフトのチームでは、[StackOverflow タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。</span><span class="sxs-lookup"><span data-stu-id="ed335-538">Our team monitors these [StackOverflow tags](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge).</span></span>

**<span data-ttu-id="ed335-539">この記事に関するフィードバックを送信する</span><span class="sxs-lookup"><span data-stu-id="ed335-539">Give feedback about this article</span></span>**

<span data-ttu-id="ed335-540">下のコメント セクションをご利用ください。</span><span class="sxs-lookup"><span data-stu-id="ed335-540">Use the comments section below.</span></span>
