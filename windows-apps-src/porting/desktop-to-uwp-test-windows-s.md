---
author: normesta
Description: Test your app for Windows 10 in S mode.
Search.Product: eADQiWindows 10XVcnh
title: Windows アプリの Windows 10 S 対応のテスト
ms.author: normesta
ms.date: 05/11/2017
ms.topic: article
keywords: windows 10 S, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 3307506c5cf62d04cd19fbc302ad14bfcedd0045
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7299164"
---
# <a name="test-your-windows-app-for-windows-10-in-s-mode"></a>Windows アプリの S モードの Windows 10 をテストする

Windows アプリをテストして、S モードの Windows10 を実行するデバイスで正しく動作することを確認できます。 実際には、Microsoft Store にアプリを公開する場合、これはストア要件のため実行する必要があります。 アプリをテストするために、Windows 10 Pro を実行しているデバイスでは Device Guard コードの整合性ポリシーを適用できます。

> [!NOTE]
> Device Guard コードの整合性ポリシーを適用するデバイスでは、Windows 10 Creators Edition (10.0 ビルド 15063) 以降が実行されている必要があります。

Device Guard コードの整合性ポリシーは、Windows 10 S で実行するために従う必要のある規則がアプリに適用されます。

> [!IMPORTANT]
>これらのポリシーを仮想マシンに適用することをお勧めします。ただし、ローカル コンピューターに適用する場合は、ポリシーを適用する前に、このトピックの「次に、ポリシーをインストールしてシステムを再起動する」セクションに記載されているベスト プラクティスのガイダンスを確認してください。

<a id="choose-policy" />

## <a name="first-download-the-policies-and-then-choose-one"></a>まず、ポリシーをダウンロードして 1 つを選択する

Device Guard コード整合性ポリシーは、[こちら](https://go.microsoft.com/fwlink/?linkid=849018)からダウンロードできます。

次に、最も希望に合うものを 1 つ選びます。 各ポリシーの概要を以下に示します。

|ポリシー |適用 |署名用の証明書 |ファイル名 |
|--|--|--|--|
|監査モード ポリシー |問題をログに記録/ブロックしない |ストア |SiPolicy_Audit.p7b |
|実稼働モード ポリシー |はい |ストア |SiPolicy_Enforced.p7b |
|自己署名アプリを使用する実稼働モード ポリシー |はい |AppX テスト証明書  |SiPolicy_DevModeEx_Enforced.p7b |

監査モード ポリシーから開始することをお勧めします。 コードの整合性イベント ログを確認し、その情報を使用してアプリを調整することができます。 最終的なテストの準備ができたら、実稼働モード ポリシーを適用します。

各ポリシーについて、もう少し詳しい情報を次に示します。

### <a name="audit-mode-policy"></a>監査モード ポリシー
このモードでは、Windows 10 S でサポートされていないタスクがアプリで実行される場合も、そのアプリを実行できます。実稼働でブロックされる実行可能ファイルは、Windows によってコード整合性イベント ログに記録されます。

これらのログを見つけるには、**[イベント ビューアー]** を開き、[アプリケーションとサービス ログ]、[Microsoft]、[Windows]、[CodeIntegrity]、[Operational] の順に移動します。

![コードの整合性イベント ログ](images/desktop-to-uwp/code-integrity-logs.png)

このモードは安全であり、システムの起動を妨げません。

#### <a name="optional-find-specific-failure-points-in-the-call-stack"></a>(省略可能) 呼び出し履歴で特定の障害箇所を見つける
呼び出し履歴でブロックに関する問題が発生している特定のポイントを見つけるには、次のレジストリ キーを追加してから、[カーネル モード デバッグ環境をセットアップ](https://docs.microsoft.com/windows-hardware/drivers/debugger/getting-started-with-windbg--kernel-mode-#span-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanspan-idsetupakernel-modedebuggingspanset-up-a-kernel-mode-debugging)します。

|キー|名前|型|値|
|--|---|--|--|
|HKEY_LOCAL_MACHINE\SYSTEM\CurentControlSet\Control\CI| DebugFlags |REG_DWORD | 1 |


![レジストリ設定](images/desktop-to-uwp/ci-debug-setting.png)

### <a name="production-mode-policy"></a>実稼働モード ポリシー
このポリシーでは、Windows 10 S に合致するコード整合性規則が適用され、Windows 10 S での実行をシミュレートできます。これは最も厳しいポリシーであり、最終的な実稼働テストに適しています。 このモードでは、アプリへの制限が、ユーザーのデバイスでの制限と同じである必要があります。 このモードを使用するには、Microsoft Store によるアプリへの署名が必要です。

### <a name="production-mode-policy-with-self-signed-apps"></a>自己署名アプリを使用する実稼働モード ポリシー
このモードは、実稼働モード ポリシーに似ていますが、zip ファイルに含まれているテスト証明書で署名されているアプリを実行できる点が異なります。 この zip ファイル内にある **AppxTestRootAgency** フォルダーに含まれる PFX ファイルをインストールします。 次に、それを使用してアプリに署名します。 この方法では、ストアによる署名を必要としないため、迅速に反復できます。

証明書の発行元名がアプリの発行者名と一致する必要があるため、**Identity** 要素の **Publisher** 属性の値を "CN=Appx Test Root Agency Ex" に一時的に変更する必要があります。 テストの完了後に、この属性を元の値に戻すことができます。

## <a name="next-install-the-policy-and-restart-your-system"></a>次に、ポリシーをインストールしてシステムを再起動する

これらのポリシーは起動エラーを招く可能性があるため、仮想マシンに適用することをお勧めします。 エラーが発生するのは、ドライバーを含めて Microsoft Store によって署名されていないコードの実行がポリシーによってブロックされるためです。

ローカル コンピューターにこれらのポリシーを適用する場合は、監査モード ポリシーから始めることをお勧めします。 このポリシーでは、適用されたポリシーで重要なコードがブロックされないことをコード整合性イベント ログで確認できます。

ポリシーを適用する準備ができたら、選択したポリシーに対応する .P7B ファイルを見つけて、**SIPolicy.P7B** という名前に変更したうえで、このファイルをシステム上の **C:\Windows\System32\CodeIntegrity\\** に保存します。

システムを再起動します。

>[!NOTE]
>システムからポリシーを削除するには、.P7B ファイルを削除してからシステムを再起動します。

## <a name="next-steps"></a>次のステップ

**質問に対する回答を見つける**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](http://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**フィードバックの提供または機能の提案を行う**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。

**App Consult Team が投稿した詳細なブログ記事を確認する**

[Windows 10 S でのデスクトップ ブリッジを使用した従来のデスクトップ アプリケーションの移植とテストに関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/06/15/porting-and-testing-your-classic-desktop-applications-on-windows-10-s-with-the-desktop-bridge/)を参照してください。

**S モードの Windows10 でのテストを容易にするツールについて理解する**

[APPX のアンパッケージ、変更、再パッケージ、署名に関する記事](https://blogs.msdn.microsoft.com/appconsult/2017/08/07/unpack-modify-repack-sign-appx/)を参照してください。
