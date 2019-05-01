---
Description: '[パッケージ] ページは、すべてのアプリを提出する場合のパッケージ ファイル (.appxupload、.appx、.appxbundle、または .xap) をアップロードします。'
title: アプリ パッケージのアップロード
ms.assetid: B1BB810D-3EAA-4FB5-B03C-1F01AFB2DE36
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10、uwp、パッケージ、アップロード、パッケージのアップロード
ms.localizationpriority: medium
ms.openlocfilehash: 07643b42a4c897c3af1865b895fb174e0eee4a3e
ms.sourcegitcommit: fca0132794ec187e90b2ebdad862f22d9f6c0db8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/24/2019
ms.locfileid: "63787941"
---
# <a name="upload-app-packages"></a>アプリ パッケージのアップロード

**パッケージ**ページは、すべてのアプリを提出する場合のパッケージ ファイル (.msix、.msixupload、.msixbundle、.appx、.appxupload、または .appxbundle) をアップロードします。 このページで、同じアプリをすべてのパッケージをアップロードして、自分のデバイスの最適なパッケージには、各顧客、顧客がアプリをダウンロードするとき、自動的にストアを提供します。 開発者がパッケージをアップロードした後は、[特定の Windows 10 デバイス ファミリ (および該当する場合は以前の OS バージョン) に対して提供されるパッケージ](#device-family-availability)をランキング順に示すテーブルが表示されます。

> [!IMPORTANT]
> 2018 年 10 月 31 日の時点で、新しく作成された製品が Windows 8.x/Windows を対象とするパッケージを含めることはできません Phone 8.x 以前のバージョン。 詳細については、「この[ブログの投稿](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/#SzKghBbqDMlmAO4c.97)します。

パッケージに含まれる内容やパッケージの構成方法について詳しくは、「[アプリ パッケージの要件](app-package-requirements.md)」をご覧ください。 について学習したいも[方法バージョン番号への影響されるパッケージが特定の顧客に配信される](package-version-numbering.md)と[さまざまなシナリオ用のパッケージを管理する方法](guidance-for-app-package-management.md)します。


## <a name="uploading-packages-to-your-submission"></a>申請へのパッケージのアップロード

パッケージをアップロードするには、アップロード フィールドにパッケージをドラッグするか、クリックしてファイルを参照します。 **パッケージ**ページには、.msix、.msixupload、.msixbundle、.appx、.appxupload、または .appxbundle ファイルをアップロードすることができます。

> [!IMPORTANT]
> Windows 10、.msixupload または .appxupload ファイルには、ここではなく .msix、.appx、.msixbundle、または .appxbundle のアップロードをお勧めします。  ストア用の UWP アプリのパッケージ化について詳しくは、「[Visual Studio での UWP アプリのパッケージ化](../packaging/packaging-uwp-apps.md)」をご覧ください。

アプリの[パッケージ フライト](package-flights.md)を作成すると、いずれかのパッケージ フライトからパッケージをコピーするオプションがドロップダウンに表示されます。 必要なパッケージが含まれているパッケージ フライトを選びます。 その後で、いずれかまたはすべてのパッケージを選んで、この申請に含めることができます。

検証中に、パッケージでエラーを検出した場合に、何が悪いことを知らせるメッセージが表示されます。 パッケージを削除して、問題を修正し、もう一度アップロードを再試行する必要があります。 また、問題を引き起こす可能性はあるが、申請の続行は妨げない事柄について通知する警告が表示されることもあります。


## <a name="device-family-availability"></a>デバイス ファミリの利用可否

パッケージのアップロードが正常に行われると、**[Device family availability]** (デバイス ファミリの利用可否) セクションに、特定の Windows 10 デバイス ファミリ (および該当する場合は以前の OS バージョン) に対して提供されるパッケージをランキング順に示すテーブルが表示されます。 このセクションでは、申請するアプリを特定の Windows 10 デバイス ファミリのユーザーに提供するかどうかも選択できます。

詳しくは、「[デバイス ファミリの利用可否](device-family-availability.md)」をご覧ください。


## <a name="package-details"></a>パッケージの詳細

アップロードされたパッケージがここでは、表示対象のオペレーティング システム別にグループ化されます。 パッケージの名前、バージョン、アーキテクチャが表示されます。 各パッケージのサポートされる言語、アプリの機能、ファイル サイズなどの詳しい情報については、**[詳細の表示]** をクリックします。

提出からパッケージを削除する必要がある場合は、各パッケージの **[詳細]** セクションの下部にある **[削除]** リンクをクリックします。


## <a name="removing-redundant-packages"></a>冗長なパッケージの削除

1 つ以上のパッケージが重複している場合、この申請から冗長なパッケージを削除することを提案する警告が表示されます。 これは多くの場合、以前にパッケージをアップロードした後で、同じユーザーをサポートする新しいバージョンのパッケージを提供するときに発生します。 この場合、これらのユーザーをサポートするより良い (より高いバージョンの) パッケージがあるため、ユーザーが冗長なパッケージを取得することはありません。

冗長なパッケージが存在することが検出された場合、すべての冗長なパッケージをこの申請から自動的に削除するオプションを提供します。 必要に応じて、パッケージを申請から個別に削除することもできます。


## <a name="gradual-package-rollout"></a>段階的なパッケージのロールアウト

申請が前に公開したアプリに対する更新プログラムの場合は、**[Roll out update gradually after this submission is published (to Windows 10 customers only)]** (この申請が公開された後で段階的に更新プログラムをロールアウトする (Windows 10 ユーザーのみ)) チェック ボックスが表示されます。 これにより、申請からパッケージを取得するユーザーの割合を選択でき、フィードバックや分析データを監視して、自信を持って更新プログラムのロールアウト範囲を広げることができます。 この割合は、新しい申請を作成することなく、いつでも増やす (または更新を停止する) ことができます。 

詳しくは、「[段階的なパッケージのロールアウト](gradual-package-rollout.md)」をご覧ください。


## <a name="mandatory-update"></a>必須の更新プログラム

申請が以前に公開したアプリに対する更新プログラムの場合、**[Make this update mandatory]** (この更新プログラムを必須にする) チェック ボックスが表示されます。 Windows.Services.Store API を使うことで、アプリがプログラムでパッケージの更新プログラムを確認し、更新されたパッケージをダウンロードしてインストールできるようにしてある場合は、このチェック ボックスをオンにすると、必須の更新の日時を設定できます。 このオプションを使うには、アプリの対象を Windows 10 Version 1607 以降にする必要があります。

詳しくは、「[アプリのパッケージの更新をダウンロードしてインストールする](../packaging/self-install-package-updates.md)」をご覧ください。

 




