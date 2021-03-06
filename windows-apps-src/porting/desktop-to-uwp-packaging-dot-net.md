---
Description: このガイドでは、編集、デバッグ、およびデスクトップ アプリケーション パッケージを Visual Studio ソリューションを構成する方法について説明します。
Search.Product: eADQiWindows 10XVcnh
title: Visual Studio を使用して、デスクトップ アプリケーションをパッケージ化します。
ms.date: 08/30/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 807a99a7-d285-46e7-af6a-7214da908907
ms.localizationpriority: medium
ms.openlocfilehash: 04a16b5e824621b0e7f32c8cb012db326f591d48
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655967"
---
# <a name="package-a-desktop-application-by-using-visual-studio"></a>Visual Studio を使用して、デスクトップ アプリケーションをパッケージ化します。

Visual Studio を使用して、デスクトップ アプリのパッケージを生成できます。 次に、その 1 つまたは複数の Pc にサイドロード、Microsoft Store にパッケージを発行できます。

最新バージョンの Visual Studio には、アプリのパッケージ化に必要であった手動ステップをすべてなくす新しいバージョンのパッケージ プロジェクトが用意されています。 パッケージ プロジェクトを追加して、デスクトップ プロジェクトを参照し、F5 キーを押してアプリをデバッグするだけです。 手動で調整する必要はありません。 この新しい効率化されたエクスペリエンスは、以前のバージョンの Visual Studio のエクスペリエンスから大幅に向上しています。

>[!IMPORTANT]
>(それ以外の場合は、デスクトップ ブリッジと呼ばれます) デスクトップ アプリケーションの Windows アプリ パッケージを作成する機能は Windows 10 バージョン 1607 で導入され、Windows 10 Anniversary Update (10.0; を対象とするプロジェクトでのみ使用できます。ビルド 14393) または Visual Studio の今後のリリース。

## <a name="first-prepare-your-application"></a>まず、アプリケーションを準備します

アプリケーションのパッケージの作成を開始する前に、このガイドを確認します。[デスクトップ アプリケーションをパッケージ化するための準備](desktop-to-uwp-prepare.md)します。

<a id="new-packaging-project"/>

## <a name="create-a-package"></a>パッケージを作成する

1. Visual Studio で、デスクトップ アプリケーション プロジェクトが含まれたソリューションを開きます。

2. ソリューションに **Windows アプリケーション パッケージ プロジェクト** プロジェクトを追加します。

   コードを追加する必要はありません。 プロジェクトを追加したのは単にパッケージを生成するためです。 このプロジェクトを "パッケージ プロジェクト" と呼びます。

   ![パッケージ プロジェクト](images/desktop-to-uwp/packaging-project.png)

   >[!NOTE]
   >このプロジェクトは、Visual Studio 2017 バージョン 15.5 以降でのみ表示されます。

3. このプロジェクトの **[ターゲット バージョン]** を目的のバージョンに設定しますが、**[最小バージョン]** は必ず **[Windows 10 Anniversary Update]** に設定してください。

   ![パッケージ バージョンの選択ダイアログ ボックス](images/desktop-to-uwp/packaging-version.png)

4. パッケージ プロジェクトで、**[アプリケーション]** フォルダーを右クリックして **[参照の追加]** を選びます。

   ![プロジェクト参照の追加](images/desktop-to-uwp/add-project-reference.png)

5. デスクトップ アプリケーション プロジェクトを選択し、**[OK]** ボタンをクリックします。

   ![デスクトップ プロジェクト](images/desktop-to-uwp/reference-project.png)

   パッケージには複数のデスクトップ アプリケーションを含めることができますが、ユーザーがアプリ タイルを選択したときに起動できるのは 1 つだけです。 **[アプリケーション]** ノードで、ユーザーがアプリのタイルを選択したときに起動するアプリケーションを右クリックし、**[Set as Entry Point]** (エントリ ポイントとして設定) を選びます。

   ![エントリ ポイントの設定](images/desktop-to-uwp/entry-point-set.png)

6. パッケージ プロジェクトをビルドし、エラーが表示されないことを確認します。  エラーが発生した場合は開きます**Configuration Manager**プロジェクトのターゲット プラットフォームが同じことを確認してください。

   ![構成マネージャー](images/desktop-to-uwp/config-manager.png)

7. [アプリ パッケージの作成](../packaging/packaging-uwp-apps.md)ウィザードを使って、appxupload ファイルを生成します。

   ストアに直接、そのファイルをアップロードできます。

**ビデオ**

&nbsp;
> [!VIDEO https://www.youtube-nocookie.com/embed/fJkbYPyd08w]

## <a name="next-steps"></a>次のステップ

**質問の回答を検索**

ご質問がある場合は、 Stack Overflow でお問い合わせください。 Microsoft のチームでは、これらの[タグ](https://stackoverflow.com/questions/tagged/project-centennial+or+desktop-bridge)をチェックしています。 [こちら](https://social.msdn.microsoft.com/Forums/en-US/home?filter=alltypes&sort=relevancedesc&searchTerm=%5BDesktop%20Converter%5D)から質問することもできます。

**ご意見や機能を提案します。**

[UserVoice](https://wpdev.uservoice.com/forums/110705-universal-windows-platform/category/161895-desktop-bridge-centennial) のページをご覧ください。

**実行、デバッグまたはお客様のデスクトップ アプリケーションのテスト**

参照してください[実行、デバッグ、およびデスクトップ アプリケーションをパッケージ化されたテスト](desktop-to-uwp-debug.md)

**UWP Api を追加することで、デスクトップ アプリケーションを強化します。**

「[Windows 10 向けのデスクトップ アプリを強化する](desktop-to-uwp-enhance.md)」をご覧ください。

**UWP プロジェクトと Windows ランタイム コンポーネントを追加することで、デスクトップ アプリケーションを拡張します。**

「[最新の UWP コンポーネントによるデスクトップ アプリケーションの拡張](desktop-to-uwp-extend.md)」をご覧ください。

**アプリを配布します。**

参照してください[パッケージ化されたデスクトップ アプリケーションの配布](desktop-to-uwp-distribute.md)
