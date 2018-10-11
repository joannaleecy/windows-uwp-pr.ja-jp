---
author: normesta
Description: This article provides a deeper dive on how the Desktop Bridge works under the covers.
title: Desktop Bridge の内側
ms.author: normesta
ms.date: 05/25/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: a399fae9-122c-46c4-a1dc-a1a241e5547a
ms.localizationpriority: medium
ms.openlocfilehash: 4e6cd2b305a9d52a2239be46cc7f77650cdd6531
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4531482"
---
# <a name="behind-the-scenes-of-your-packaged-desktop-application"></a>パッケージ化されたデスクトップ アプリケーションの内側

この記事では、デスクトップ アプリケーションの Windows アプリ パッケージを作成するときのファイルとレジストリ エントリを動作で、について詳しく説明を提供します。

他のアプリとの互換性を維持しながら可能な限り多くのシステムの状態からアプリケーションの状態を分離する、最新のパッケージの主な目標ことです。 ブリッジではこれを行うために、アプリケーションをユニバーサル Windows プラットフォーム (UWP) パッケージ内に配置し、実行時にファイル システムとレジストリに行われる変更を検出して、一部の変更のリダイレクトを行います。

デスクトップ アプリケーション用に作成されたパッケージは、完全信頼できるデスクトップ専用アプリケーションし、仮想化やサンド ボックス化されていません。 このため、従来のデスクトップ アプリケーションと同じように、他のアプリとやり取りすることが可能です。

## <a name="installation"></a>インストール

アプリ パッケージは *C:\Program Files\WindowsApps\package_name* にインストールされ、実行可能プログラム名は *app_name.exe* になります。 各パッケージ フォルダーには、パッケージ アプリ用の XML 名前空間を含むマニフェスト (AppxManifest.xml という名前) が含まれています。 マニフェスト ファイル内の ```<EntryPoint>``` 要素で、完全信頼アプリを参照します。 そのアプリケーションが起動されるとき、アプリ コンテナー内では実行されませんが、代わりに、ユーザーとして実行されるが通常。

展開後、パッケージ ファイルは読み取り専用としてマークされ、オペレーティング システムによって厳重にロックダウンされます。 これらのファイルが改ざんされると、Windows によりアプリの起動が回避されます。

## <a name="file-system"></a>ファイル システム

アプリの状態を含めるために、アプリケーションによる AppData への変更がキャプチャされます。 作成、削除、更新など、ユーザーの AppData フォルダー (例: *C:\Users\user_name\AppData*) に対する書き込みはすべて、書き込み時にユーザーごと、アプリごとのプライベートな場所にコピーされます。 これは、パッケージ化されたアプリケーションは実際にはプライベート コピーを変更するときは、AppData を編集、奥行きを作成します。 このように書き込みのリダイレクトを行うことで、アプリによって行われたすべてのファイル変更をシステムで追跡できます。 これにより、アプリケーションがアンインストールされると、それらのファイルをクリーンアップするシステムで、したがってシステム「劣化」を削減しより優れたアプリケーションの削除を提供する、ユーザー操作します。

AppData のリダイレクトに加えて Windows の既知のフォルダー (System32、Program Files (x86) など) は、アプリ パッケージ内の対応するディレクトリに動的にマージされます。 それぞれのパッケージのルート ディレクトリには、"VFS" という名前のフォルダーが含まれています。 この VFS ディレクトリ内のディレクトリまたはファイルに対する読み取り操作は、実行時にそれぞれ対応するネイティブ部分にマージされます。 たとえば、アプリケーションは、そのアプリ パッケージの一部として*C:\Program Files\WindowsApps\package_name\VFS\SystemX86\vc10.dll*を含めることができますが、ファイル*C:\Windows\System32\vc10.dll*でインストールされるように表示されます。  これにより、ファイルがパッケージ外の場所にあることを想定しているデスクトップ アプリケーションとの互換性が維持されます。

アプリ パッケージ内のファイルまたはフォルダーへの書き込みは、許可されていません。 パッケージに含まれないファイルやフォルダーへの書き込みは、ブリッジでは無視され、ユーザーにアクセス許可があれば許可されます。

### <a name="common-operations"></a>一般的な操作

一般的なファイル システム操作とブリッジでの処理方法を以下に示します。

操作 | 結果 | 例
:--- | :--- | :---
既知の Windows ファイルまたはフォルダーに対する読み取りまたは列挙 | *C:\Program Files\package_name\VFS\well_known_folder* がローカル システムの対応部分に動的にマージされます。 | *C:\Windows\System32* の読み取りでは、*C:\Windows\System32* の内容と *C:\Program Files\WindowsApps\package_name\VFS\SystemX86* の内容が返されます。
AppData 内の書き込み | 書き込み時に、ユーザーごと、アプリごとの場所にコピーされます。 | AppData は通常、*C:\Users\user_name\AppData* です。  
パッケージ内の書き込み | 許可されていません。 パッケージは読み取り専用です。 | *C:\Program Files\WindowsApps\package_name* 内の書き込みは、許可されていません。
パッケージ外の書き込み | ユーザーにアクセス許可があれば、許可されます。 | *C:\Windows\System32\foo.dll* への書き込みは、パッケージに *C:\Program Files\WindowsApps\package_name\VFS\SystemX86\foo.dll* が含まれておらずユーザーにアクセス許可があれば許可されます。

### <a name="packaged-vfs-locations"></a>パッケージ化された VFS の場所

次の表は、パッケージの一部として含まれるファイルが、システム上でアプリのためにどのように配置されるかを示しています。 これらのファイル内にある表示されたシステムの場所、 *C:\Program \windowsapps\package_name\vfs*内のリダイレクトされた場所に実際には、アプリケーションと感じます。 FOLDERID の場所は [**KNOWNFOLDERID**](https://msdn.microsoft.com/library/windows/desktop/dd378457.aspx) 定数で示されます。

システムの場所 | リダイレクトされた場所 ([PackageRoot]\VFS\ の下) | 有効なアーキテクチャ
 :--- | :--- | :---
FOLDERID_SystemX86 | SystemX86 | x86、amd64
FOLDERID_System | SystemX64 | amd64
FOLDERID_ProgramFilesX86 | ProgramFilesX86 | x86、amd64
FOLDERID_ProgramFilesX64 | ProgramFilesX64 | amd64
FOLDERID_ProgramFilesCommonX86 | ProgramFilesCommonX86 | x86、amd64
FOLDERID_ProgramFilesCommonX64 | ProgramFilesCommonX64 | amd64
FOLDERID_Windows | Windows | x86、amd64
FOLDERID_ProgramData | 一般的な AppData | x86、amd64
FOLDERID_System\catroot | AppVSystem32Catroot | x86、amd64
FOLDERID_System\catroot2 | AppVSystem32Catroot2 | x86、amd64
FOLDERID_System\drivers\etc | AppVSystem32DriversEtc | x86、amd64
FOLDERID_System\driverstore | AppVSystem32Driverstore | x86、amd64
FOLDERID_System\logfiles | AppVSystem32Logfiles | x86、amd64
FOLDERID_System\spool | AppVSystem32Spool | x86、amd64

## <a name="registry"></a>レジストリ

アプリ パッケージには、registry.dat ファイルが含まれています。このファイルは、実際のレジストリ内の *HKLM\Software* に論理的に対応しています。 実行時には、この仮想レジストリのハイブの内容がネイティブ システム ハイブにマージされ、両方が一括して表示されます。 たとえば、registry.dat に単一のキー "Foo" が含まれている場合、実行時に *HKLM\Software* を読み取ると、(すべてのネイティブ システム キーに加えて) "Foo" も含まれているように表示されます。

パッケージに含まれる部分は *HKLM\Software* 以下のキーのみです。*HKCU* 以下のキーやレジストリの他の部分は、パッケージに含まれていません。 パッケージ内のキーまたは値への書き込みは許可されていません。 書き込むキーまたは値へユーザー権限を持っている限り、パッケージの一部を許可します。

HKCU 以下の書き込みはすべて、書き込み時にユーザーごと、アプリごとのプライベートな場所にコピーされます。 従来、ログアウトしたユーザーのレジストリ データはマウント解除され使用できなくなるため、アンインストーラーが *HKEY_CURRENT_USER* をクリーンアップできませんでした。

すべての書き込みはパッケージのアップグレード中に保持し、アプリケーションが完全に削除するときにのみ削除します。

### <a name="common-operations"></a>一般的な操作

一般的なレジストリ操作とブリッジでの処理方法を以下に示します。

操作 | 結果 | 例
:--- | :--- | :---
*HKLM\Software* に対する読み取りまたは列挙 | パッケージのハイブがローカル システムの対応部分に動的にマージされます。 | registry.dat に単一のキー "Foo" が含まれている場合、実行時に *HKLM\Software* を読み取ると、*HKLM\Software* と *HKLM\Software\Foo* の内容がどちらも表示されます。
HKCU 以下の書き込み | 書き込み時に、ユーザーごと、アプリごとのプライベートな場所にコピーされます。 | ファイルの AppData と同じです。
パッケージ内の書き込み | 許可されていません。 パッケージは読み取り専用です。 | 対応するキー/値がパッケージ ハイブに存在する場合、*HKLM\Software* 以下の書き込みは許可されません。
パッケージ外の書き込み | ブリッジでは無視されます。 ユーザーにアクセス許可があれば、許可されます。 | *HKLM\Software* 以下の書き込みは、対応するキー/値がパッケージに含まれておらずユーザーに適切なアクセス許可があれば許可されます。

## <a name="uninstallation"></a>アンインストール

パッケージは、ユーザーがアンインストールされると、ファイルとフォルダー *C:\Program \windowsapps\package_name*の下にあるすべて削除されます。 パッケージ化プロセス中にキャプチャされた AppData またはレジストリにリダイレクトされた書き込みも。

## <a name="next-steps"></a>次のステップ

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。
