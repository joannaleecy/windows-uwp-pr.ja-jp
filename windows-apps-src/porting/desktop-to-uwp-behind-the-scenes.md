---
author: awkoren
Description: "この記事では、Desktop to UWP Bridge の内部的な処理について詳しく説明します。"
title: "Desktop Bridge の内側"
translationtype: Human Translation
ms.sourcegitcommit: fe96945759739e9260d0cdfc501e3e59fb915b1e
ms.openlocfilehash: c261f40734ab40475ca3a8e0b7c3bea7b64afacd

---

# Desktop Bridge の内側

この記事では、Desktop to UWP Bridge の内部的な処理について詳しく説明します。

Desktop to UWP Bridge の主な目的は、他のアプリとの互換性を維持しつつ、アプリケーションの状態をシステムの状態からできるだけ分離することです。 ブリッジではこれを行うために、アプリケーションをユニバーサル Windows プラットフォーム (UWP) パッケージ内に配置し、実行時にファイル システムとレジストリに行われる変更を検出して、一部の変更のリダイレクトを行います。

変換済みのアプリ パッケージは、完全に信頼できるデスクトップ専用アプリケーションであり、仮想化やサンド ボックス化は行われません。 このため、従来のデスクトップ アプリケーションと同じように、他のアプリとやり取りすることが可能です。

## インストール 

アプリ パッケージは *C:\Program Files\WindowsApps\package_name* にインストールされ、実行可能プログラム名は *app_name.exe* になります。 各パッケージ フォルダーには、変換済みのアプリ用の XML 名前空間を含むマニフェスト (AppxManifest.xml という名前) が含まれています。 マニフェスト ファイル内の ```<EntryPoint>``` 要素で、完全信頼アプリを参照します。 アプリが起動されると、アプリ コンテナー内では実行されず、ユーザーが通常実行するように実行されます。

展開後、パッケージ ファイルは読み取り専用としてマークされ、オペレーティング システムによって厳重にロックダウンされます。 これらのファイルが改ざんされると、Windows によりアプリの起動が回避されます。 

## ファイル システム

ブリッジでは、アプリの状態を含めるために、アプリによる AppData への変更がキャプチャされます。 作成、削除、更新など、ユーザーの AppData フォルダー (例: *C:\Users\user_name\AppData*) に対する書き込みはすべて、書き込み時にユーザーごと、アプリごとのプライベートな場所にコピーされます。 つまり、変換済みアプリが AppData への編集を行っているように見えても、実際に行われているのはプライベート コピーへの変更です。 このように書き込みのリダイレクトを行うことで、アプリによって行われたすべてのファイル変更をシステムで追跡できます。 これにより、アプリのアンインストール時にシステムがこれらのファイルをクリーンアップできるため、システムの "劣化" を抑え、ユーザーから見たアプリ削除の操作を改善することができます。 

ブリッジでは、AppData のリダイレクトに加えて、Windows の既知のフォルダー (System32、Program Files (x86) など) がアプリ パッケージ内の対応するディレクトリに動的にマージされます。 それぞれの変換済みパッケージのルート ディレクトリには、"VFS" という名前のフォルダーが含まれています。 この VFS ディレクトリ内のディレクトリまたはファイルに対する読み取り操作は、実行時にそれぞれ対応するネイティブ部分にマージされます。 たとえば、アプリ パッケージに *C:\Program Files\WindowsApps\package_name\VFS\SystemX86\vc10.dll* が含まれている場合、このファイルは *C:\Windows\System32\vc10.dll* にインストールされているように表示されます。  これにより、ファイルがパッケージ外の場所にあることを想定しているデスクトップ アプリケーションとの互換性が維持されます。 

変換済みアプリ パッケージ内のファイルまたはフォルダーへの書き込みは、許可されていません。 パッケージに含まれないファイルやフォルダーへの書き込みは、ブリッジでは無視され、ユーザーにアクセス許可があれば許可されます。

### 一般的な操作

一般的なファイル システム操作とブリッジでの処理方法を以下に示します。 

操作 | 結果 | 例
:--- | :--- | :---
既知の Windows ファイルまたはフォルダーに対する読み取りまたは列挙 | *C:\Program Files\package_name\VFS\well_known_folder* がローカル システムの対応部分に動的にマージされます。 | *C:\Windows\System32* の読み取りでは、*C:\Windows\System32* の内容と *C:\Program Files\WindowsApps\package_name\VFS\SystemX86* の内容が返されます。 
AppData 内の書き込み | 書き込み時に、ユーザーごと、アプリごとの場所にコピーされます。 | AppData は通常、*C:\Users\user_name\AppData* です。  
パッケージ内の書き込み | 許可されていません。 パッケージは読み取り専用です。 | *C:\Program Files\WindowsApps\package_name* 内の書き込みは、許可されていません。
パッケージ外の書き込み | ブリッジでは無視されます。 ユーザーにアクセス許可があれば、許可されます。 | *C:\Windows\System32\foo.dll* への書き込みは、パッケージに *C:\Program Files\WindowsApps\package_name\VFS\SystemX86\foo.dll* が含まれておらずユーザーにアクセス許可があれば許可されます。

### パッケージ化された VFS の場所

次の表は、パッケージの一部として含まれるファイルが、システム上でアプリのためにどのように配置されるかを示しています。 これらのファイルは、アプリではここに示されているシステム内の場所にあると認識されますが、実際にはリダイレクトされており、*C:\Program Files\WindowsApps\package_name\VFS* 内の場所に配置されます。 FOLDERID の場所は [**KNOWNFOLDERID**](https://msdn.microsoft.com/library/windows/desktop/dd378457.aspx) 定数で示されます。

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

## レジストリ

ブリッジでは、レジストリがファイル システムと同じように処理されます。 変換済みアプリ パッケージには、registry.dat ファイルが含まれています。このファイルは、実際のレジストリ内の *HKLM\Software* に論理的に対応しています。 実行時には、この仮想レジストリのハイブの内容がネイティブ システム ハイブにマージされ、両方が一括して表示されます。 たとえば、registry.dat に単一のキー "Foo" が含まれている場合、実行時に *HKLM\Software* を読み取ると、(すべてのネイティブ システム キーに加えて) "Foo" も含まれているように表示されます。 

パッケージに含まれる部分は *HKLM\Software* 以下のキーのみです。*HKCU* 以下のキーやレジストリの他の部分は、パッケージに含まれていません。 パッケージ内のキーまたは値への書き込みは許可されていません。 パッケージに含まれないキーまたは値への書き込みは、ブリッジでは無視され、ユーザーに書き込み許可があれば許可されます。

HKCU 以下の書き込みはすべて、書き込み時にユーザーごと、アプリごとのプライベートな場所にコピーされます。 これにより、アンインストールのクリーンアップが、ブリッジによるファイル システムの処理と同じように行われるという利点があります。 従来、ログアウトしたユーザーのレジストリ データはマウント解除され使用できなくなるため、アンインストーラーが *HKEY_CURRENT_USER* をクリーンアップできませんでした。 

書き込みはすべて、パッケージのアップグレード中には保持され、アプリが完全に削除された場合にのみ削除されます。 

### 一般的な操作

一般的なレジストリ操作とブリッジでの処理方法を以下に示します。 

操作 | 結果 | 例
:--- | :--- | :---
*HKLM\Software* に対する読み取りまたは列挙 | パッケージのハイブがローカル システムの対応部分に動的にマージされます。 | registry.dat に単一のキー "Foo" が含まれている場合、実行時に *HKLM\Software* を読み取ると、*HKLM\Software* と *HKLM\Software\Foo* の内容がどちらも表示されます。 
HKCU 以下の書き込み | 書き込み時に、ユーザーごと、アプリごとのプライベートな場所にコピーされます。 | ファイルの AppData と同じです。 
パッケージ内の書き込み | 許可されていません。 パッケージは読み取り専用です。 | 対応するキー/値がパッケージ ハイブに存在する場合、*HKLM\Software* 以下の書き込みは許可されません。
パッケージ外の書き込み | ブリッジでは無視されます。 ユーザーにアクセス許可があれば、許可されます。 | *HKLM\Software* 以下の書き込みは、対応するキー/値がパッケージに含まれておらずユーザーに適切なアクセス許可があれば許可されます。

## アンインストール 

パッケージがユーザーによってアンインストールされると、*C:\Program Files\WindowsApps\package_name* 以下にあるすべてのファイルとフォルダーが削除されます。また、AppData またはレジストリにリダイレクトされ、ブリッジによってキャプチャされた書き込みも削除されます。 



<!--HONumber=Nov16_HO1-->


