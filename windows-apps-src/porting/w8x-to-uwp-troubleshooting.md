---
author: mcleblanc
description: "この移植ガイドは最後まで読むことを強くお勧めしますが、早く先へ進んで、プロジェクトのビルドと実行の段階まで到達したいと思われるのも無理のないことです。"
title: "Windows ランタイム 8.x から UWP への移植のトラブルシューティング&quot;"
ms.assetid: 1882b477-bb5d-4f29-ba99-b61096f45e50
ms.author: markl
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 6c10376854656abe276c53a9b6778665c1d47a4b
ms.lasthandoff: 02/07/2017

---

# <a name="troubleshooting-porting-windows-runtime-8x-to-uwp"></a>Windows ランタイム 8.x から UWP への移植のトラブルシューティング

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

前のトピックは、「[プロジェクトの移植](w8x-to-uwp-porting-to-a-uwp-project.md)」でした。

この移植ガイドは最後まで読むことを強くお勧めしますが、早く先へ進んで、プロジェクトのビルドと実行の段階まで到達したいと思われるのも無理のないことです。 このために、重要でないコードに対してコメント アウトやスタブの挿入を行って一時的に先に進み、後でその部分に戻って対応することもできます。 このトピックには、トラブルシューティングの現象とその対処法を示す表が記載されており、以降のいくつかのトピックに示されている情報に代わるものではありませんが、この段階での作業に役立ちます。 以降のトピックを読み進む中で、いつでもこの表に戻って参考にすることができます。

## <a name="tracking-down-issues"></a>問題の検出

XAML 解析例外は診断が難しい場合があります。特に、わかりやすいエラー メッセージが例外に含まれていない場合は、診断が難しくなります。 デバッガーが初回例外をキャッチするように構成されていることを確してください (早い段階で解析例外のキャッチを試行するため)。 デバッガーで例外変数を調べて、HRESULT やメッセージ内に役立つ情報が含まれているかどうかを確認できます。 また、XAML パーサーを使って、Visual Studio の出力ウィンドウを調べ、エラー メッセージの出力を確認することもできます。

アプリが終了したとき、確認できたことが、ハンドルされていない例外が XAML マークアップの解析中にスローされたことのみである場合は、存在しないリソース (システム **TextBlock** スタイル キーなどのキーが Windows 10 アプリには存在せず、ユニバーサル 8.1 アプリに存在するリソース) への参照が原因であると考えられます。 または、**UserControl**、カスタム コントロール、カスタム レイアウト パネルの内部で例外がスローされたことも考えられます。

最終手段として、バイナリ分割を使うことができます。 ページからマークアップのおよそ半分を削除し、アプリを再実行します。 これによって、エラーが削除した半分で発生しているか (いずれの場合でも、削除した部分はここで元に戻す必要があります)、または削除*しなかった*半分で発生しているかがわかります。 問題が特定されるまで、エラーを含む半分をさらに分割するプロセスを繰り返します。

## <a name="targetplatformversion"></a>TargetPlatformVersion

このセクションでは、Visual Studio で Windows 10 プロジェクトを開いたとき、"Visual Studio 更新プログラムが必要。 1 つ以上のプロジェクトでは、インストールされていないか、Visual Studio に対する今後の更新の一部として含まれるプラットフォーム SDK <version> が必要です。"

-   まず、インストールされている SDK for Windows 10 のバージョン番号を確認します。 **C:\\Program Files (x86)\\Windows Kits\\10\\Include\\<versionfoldername>** に移動し、*<versionfoldername>* をメモしてください。これは、4 つの部分 "メジャー.マイナー.ビルド.リビジョン" から成るバージョン文字列です。
-   編集用のプロジェクト ファイルを開き、`TargetPlatformVersion` 要素と `TargetPlatformMinVersion` 要素を探します。 これらの要素を次のように編集します。*<versionfoldername>* は、ディスク上で見つけた 4 つの部分から成るバージョン文字列に置き換えてください。

```xml
   <TargetPlatformVersion><versionfoldername></TargetPlatformVersion>
    <TargetPlatformMinVersion><versionfoldername></TargetPlatformMinVersion>
```

## <a name="troubleshooting-symptoms-and-remedies"></a>トラブルシューティングの現象とその対処法

この表の対処法に関する情報では、自身で問題を解消するために十分な情報を提供することが意図されています。 以降のトピックを読み進むことで、こうした各問題についてさらに詳細な情報が提供されます。

| 現象 | 対処法 |
|---------|--------|
| Visual Studio で Windows 10 プロジェクトを開いたとき、"Visual Studio 更新プログラムが必要。 1 つ以上のプロジェクトでは、インストールされていないか、Visual Studio に対する今後の更新の一部として含まれるプラットフォーム SDK &lt;バージョン&gt; が必要です。" というメッセージが表示されます。 | このトピックの「[TargetPlatformVersion](#targetplatformversion)」セクションをご覧ください。 |
| InitializeComponent が xaml.cs ファイルで呼び出されると、System.InvalidCastException がスローされます。| これは、同じ xaml.cs ファイルを共有している xaml ファイルが複数あり (少なくとも 1 つは MRT 修飾されたファイル)、要素が持つ x:Name 属性が 2 つの xaml ファイル間で整合性がとれていない場合に発生することがあります。 両方の xaml ファイルで同じ要素に同じ名前を追加してみるか、どちらの名前も省略してください。 |
| デバイスでの実行時にアプリを終了する場合、または Visual Studio からの起動時に、"Windows ストア アプリ \[…\] をアクティブにできません。 アクティベーション要求がエラー "Windows はターゲット アプリケーションと通信できませんでした。 これは通常、ターゲット アプリケーションのプロセスが中断されたことを示します。 \[…\]” で失敗しました。" というエラーが表示されます。 | この問題は、初期化時に独自のページ、またはバインド プロパティ (またはその他の型) で実行する命令型コードにあることが考えられます。 また、アプリの終了時に表示される XAML ファイルの解析でエラーが発生した可能性があります (Visual Studio から起動した場合は、これは起動ページになります)。 無効なリソース キーを検索するか、このトピックの「問題の検出」セクションのガイダンスを実行します。|
| XAML のパーサーやコンパイラ、またはランタイム例外で、"*リソース "<resourcekey>" を解決できませんでした*" というエラーが発生します。 | リソース キーは、ユニバーサル Windows プラットフォーム (UWP) アプリには適用されません (たとえば、一部の Windows Phone リソースがこの場合に該当します)。 同等の正しいリソースを探し、マークアップを更新します。 発生する可能性が高い例としては、`PhoneAccentBrush` などのシステム キーが挙げられます。 |
| C# コンパイラで、エラー "*型または名前空間の名前 '<name>' が見つかりませんでした \[...\]*"、*型または名前空間の名前 '<name>' は名前空間 \[...\] に存在しません*"、または "*型または名前空間の名前 '<name>' が現在のコンテキスト内に存在しません*" が発生します。 | これは、型が拡張 SDK に実装されていることを示していると考えられます (ただし、この場合、対処法が難しくなる可能性があります)。 [Windows API](https://msdn.microsoft.com/library/windows/apps/bg124285) の参照コンテンツを使って、API を実装している拡張 SDK を特定し、Visual Studio の **[追加]** にある **[参照]** コマンドを使って、その SDK への参照をプロジェクトに追加します。 アプリがユニバーサル デバイス ファミリと呼ばれる一連の API をターゲットとしている場合は、API を呼び出す前に、[**ApiInformation**](https://msdn.microsoft.com/library/windows/apps/dn949001) クラスを使って、実行時にテストを行い、拡張 SDK の有無を確認する必要があります (これはアダプティブ コードと呼ばれます)。 ユニバーサル API が存在する場合、拡張 SDK の API では常にこれが推奨されます。 詳しくは、「[拡張 SDK](w8x-to-uwp-porting-to-a-uwp-project.md)」をご覧ください。 |

次のトピックは、「[XAML と UI の移植](w8x-to-uwp-porting-xaml-and-ui.md)」です。


