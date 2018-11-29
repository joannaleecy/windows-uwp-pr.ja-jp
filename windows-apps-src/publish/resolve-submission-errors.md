---
Description: If you encounter errors after submitting your app to the Store, you must resolve them in order to continue the certification process.
title: 申請エラーの解決
ms.assetid: 68199E09-0C66-4EB4-BFE8-D2EEB139C4F3
ms.date: 10/31/2018
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: 9911323010f691d1fa59c35306a7173cd08a0faa
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "7986083"
---
# <a name="resolve-submission-errors"></a>申請エラーの解決

ストアにアプリを提出した後にエラーが発生した場合、「[認定プロセス](the-app-certification-process.md)」を続行するためにそれを解決する必要があります。 エラー メッセージには、どのような問題があるのか、問題を修正するために何をする必要があるのかが示されます。 以下に、これらのエラーの解決に役立つ追加情報をいくつか示します。

## <a name="uwp-apps"></a>UWP アプリ

UWP アプリを提出する場合、パッケージ ファイルが、ストアの Visual Studio によって生成された .msixupload または .appxupload ファイルではない場合に、前処理中にエラーが表示可能性があります。 [Visual Studio で UWP アプリのパッケージ](../packaging/packaging-uwp-apps.md)アプリのパッケージのファイルを作成するときの手順し、のみ .msix/appx または .msixbundle/appxbundle いない、申請の[パッケージ](upload-app-packages.md)] ページで、.msixupload または .appxupload ファイルをアップロードことを確認します。.

コンパイル エラーが表示される場合は、リリース モードでアプリケーションを正常にビルドできることを確認します。 詳しくは、[.NET ネイティブ内部コンパイラ エラーに関するページ](http://go.microsoft.com/fwlink/p/?LinkID=613098)をご覧ください。

## <a name="desktop-application"></a>デスクトップ アプリケーション

Win32 と UWP の両方のバイナリが含まれているパッケージを提出する場合は、Visual Studio 2017 Update 4 で利用可能な Windows パッケージ プロジェクトを使用して、そのパッケージを作成することを確認します。 UWP プロジェクト テンプレートを使用してパッケージを作成する場合は、提出するパッケージをストアまたはサイドローディング化上の他の Pc にできない可能性があります。 パッケージが正常に発行、した場合でも、ユーザーの PC で予期動作する可能性があります。 詳しくは、 [Visual Studio (デスクトップ ブリッジ) を使用して、アプリのパッケージ]( https://docs.microsoft.com/windows/uwp/porting/desktop-to-uwp-packaging-dot-net)を参照してください。

## <a name="windows-phone-8x-and-earlier"></a>Windows Phone 8.x 以前のバージョン

> [!IMPORTANT]
> 2018 年 10 月 31 日の時点で、新しく作成した製品が Windows Phone を対象とするパッケージを含めることはできません 8.x 以前のバージョン。 詳しくは、この[ブログ記事](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/#SzKghBbqDMlmAO4c.97)を参照してください。

前処理中に Windows Phone のパッケージに関する問題が検出されると、**エラー 2001** が表示されることがあります。 ほとんどの場合は、アプリのパッケージをリビルドしてエラーを修正する必要があります。 処理が完了したら、[パッケージ](upload-app-packages.md) ページで古いパッケージを新しいパッケージに置き換えてから、**[ストアに提出]** をもう一度クリックします。

このエラーの原因になる問題はいくつかあります。 次の一覧を調べて、どの問題が自分のパッケージに当てはまるか判断してください。

-   **パッケージ内の 1 つ以上のアセンブリが不正に暗号化されています:** 別のツールを使用して暗号化を実行するか、暗号化を削除します。 コンパイル プロセスによって暗号化アセンブリが最適化されますが、サポート外の方法で MSIL を変更するツールによって一部のアセンブリが暗号化されているため、エラーが発生する場合があります。
-   **アプリ内の 1 つ以上のメソッドのサイズが、256 KB の IL を超過しています:** 問題のあるメソッドをリファクタリングして、複数の小さい関数にします。 アセンブリ内のメソッドの MSIL のサイズは、ILDASM ツールを使って判別できます。
-   **1 つ以上のアセンブリで、厳密な名前の署名確認に失敗しました:** このエラーは通常、アセンブリ メタデータで必要なキーとは異なるキーを使用して、厳密な名前の署名が実行された場合に発生します。 正しいキーを使用して署名するか、または厳密な名前の署名を削除します。
-   **パッケージに混合モード (マネージ コードとネイティブ コードの) アセンブリが含まれています:** Windows Phone では、混合モード アセンブリはサポートされていません。 パッケージから混合モード アセンブリを削除し、アプリを再申請します。
-   **Windows Phone 8.1 XAP または appx/appxbundle アセンブリが無効です:** .winmd ファイルに公開エントリ ポイントが少なくとも 1 つあることを確認します。 必要に応じて、逆コンパイラ アプリケーションを使ってコードを確認し、公開エントリ ポイントがあるかどうかをチェックすることができます。

アプリの提出後に発生する可能性のある他のエラーは、**エラー 1300** です。 これは、1 つ以上のアセンブリ (またはパッケージ全体) が既にプリコンパイルされているときに発生します。 この問題を解決するには、Microsoft Visual Studio でアプリのパッケージをリビルドし、新たに生成されたパッケージを提出します。

## <a name="nameidentity-errors"></a>名前/ID エラー

「**パッケージ内で見つかった名前が、予約したアプリ名のいずれにも該当しません。アプリ名を予約するか、この言語に対応した正しいアプリ名でパッケージを更新してください**」ということを示すエラーが表示された場合、パッケージに誤った名前を入力した可能性があります。 このエラーは、パートナー センターで予約していないアプリ名を使用している場合にも発生することができます。 通常、このエラーは次の手順に従って解決できます。

- アプリの [[アプリ ID]](view-app-identity-details.md) ページ (**[アプリ管理]** の下) に移動して、アプリに ID が割り当てられているかどうかを確認します。 割り当てられていない場合は、ID を作成するオプションが表示されます。 ID を作成するためには、アプリの名前を予約する必要があります。 その名前がパッケージで使用されている名前であることを確認してください。
- アプリに ID が既に割り当てられているときでも、場合によっては、パッケージで使用する名前を予約する必要があります。 **[アプリ管理]** で、[[アプリ名の管理]](manage-app-names.md) をクリックします。 使用する名前を入力し、**[アプリ名を予約]** をクリックします。

> [!IMPORTANT]
>  使用する名前が利用できない場合別のアプリが既に予約済みであるその名前。 アプリがその名前には、既に公開されている場合、または、[サポートにお問い合わせ](https://go.microsoft.com/fwlink/p/?LinkId=331509)を使用する権利があると考えられる場合。  

 

 




