---
description: 移植プロセスを始めるには、Visual Studio で新しい windows 10 プロジェクトを作成し、ファイルをコピーします。
title: UWP プロジェクトに WindowsPhone Silverlight プロジェクトを移植します。
ms.assetid: d86c99c5-eb13-4e37-b000-6a657543d8f4
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 55c4347b85d94d183d44599f7d34bc750d34d181
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8897438"
---
# <a name="porting-windowsphone-silverlight-projects-to-uwp-projects"></a>UWP プロジェクトに WindowsPhone Silverlight プロジェクトを移植します。


前のトピックは、「[名前空間とクラス マッピング](wpsl-to-uwp-namespace-and-class-mappings.md)」でした。

移植プロセスを始めるには、Visual Studio で新しい windows 10 プロジェクトを作成し、ファイルをコピーします。

## <a name="create-the-project-and-copy-files-to-it"></a>プロジェクトを作成し、ファイルをコピーする

1.  Microsoft Visual Studio2015 を起動し、新しい空のアプリケーション (Windows ユニバーサル) プロジェクトを作成します。 詳しくは、 [Windows ランタイム 8.x アプリ着手テンプレート (c#、C++、Visual Basic) を使用して](https://msdn.microsoft.com/library/windows/apps/hh768232)を参照してください。 新しいプロジェクトによって、すべてのデバイス ファミリで実行される 1 つのアプリ パッケージ (appx ファイル) が構築されます。
2.  WindowsPhone Silverlight アプリ プロジェクトでは、すべてのソース コード ファイルと再利用するビジュアル アセット ファイルを識別します。 エクスプローラーを使って、データ モデル、ビュー モデル、ビジュアル アセット、リソース ディクショナリ、フォルダー構造、および再利用するその他すべての要素を、新しいプロジェクトにコピーします。 必要に応じて、ディスクにサブフォルダーをコピーするか、作成します。
3.  新しいプロジェクト ノードに、ビュー (たとえば MainPage.xaml、MainPage.xaml.cs など) もコピーします。 ここでも、必要に応じて新しいサブフォルダーを作成し、プロジェクトから既にあるビューを削除します。 ただし、Visual Studio が生成したビューを上書きまたは削除する前に、後で参照することが役立つ場合があるために、コピーを保存しておきます。 WindowsPhone Silverlight アプリの移植の最初のフェーズ重視を探すされ機能 1 つのデバイス ファミリで適切にします。 その後で、すべてのフォーム ファクターに対してビューを適切に対応させることに重点を置きます。必要に応じて、特定のデバイス ファミリを最大限に活用できるように、アダプティブ コードを追加します。
4.  **ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。 コピーしたファイルを選択して右クリックし、**[プロジェクトに含める]** をクリックします。 これによって、含まれるフォルダーが自動的に取り込まれます。 後で必要に応じて、**[すべてのファイルを表示]** をオフに切り替えることができます。 代替ワークフローとして、**[既存項目の追加]** コマンドを使って Visual Studio **ソリューション エクスプローラー**で必要なすべてのサブフォルダーを作成することもできます。 ビジュアル アセットで、**[ビルド アクション]** が **[コンテンツ]** に設定されており、**[出力ディレクトリにコピー]** が **[コピーしない]** に設定されていることを確認します。
5.  名前空間とクラス名の違いにより、このステージでは多くのビルド エラーが生成されます。 たとえば、Visual Studio が生成したビューを開くと、型 **PhoneApplicationPage** ではなく型 [**Page**](https://msdn.microsoft.com/library/windows/apps/br227503) であることがわかります。 XAML マークアップと命令型コードには多くの違いがあり、この移植ガイドの次のトピックで詳細に取り上げます。 ただし、次の一般的な手順に従うことでプロセスを速めることができます。まず、XAML マークアップで名前空間のプレフィックス宣言を "clr-namespace" から "using" に変更します。次に、「[名前空間とクラス マッピング](wpsl-to-uwp-namespace-and-class-mappings.md)」トピックを参考に、Visual Studio の **[検索と置換]** コマンドを使って、ソース コードに一括変更を加えます (たとえば "System.Windows" を "Windows.UI.Xaml" に置換します)。そして Visual Studio の命令型コード エディターで、コンテキスト メニューの **[解決]** および **[using の整理]** コマンドを使ってよりターゲットを絞った変更を行います。

## <a name="extension-sdks"></a>拡張 SDK

移植したアプリによって呼び出されるユニバーサル Windows プラットフォーム (UWP) API のほとんどは、ユニバーサル デバイス ファミリと呼ばれる一連の API に実装されています。 ただし、一部の API は拡張 SDK に実装されており、Visual Studio で認識されるのは、アプリのターゲット デバイス ファミリによって実装された API、または参照している拡張 SDK によって実装された API のみです。

検出できなかった名前空間、型、メンバーについてのコンパイル エラーが発生した場合は、上記のことが原因となる可能性があります。 API リファレンス ドキュメントで API のトピックを表示し、要件に関するセクションに移動します。このセクションでは、どのようなデバイス ファミリが API を実装するかが示されています。 ターゲット デバイス ファミリが示されていない場合は、プロジェクトで API を利用できるようにするために、そのデバイス ファミリ用の拡張 SDK に対する参照が必要になります。

**[プロジェクト]** &gt; **[参照の追加]** &gt; **[Windows ユニバーサル]** &gt; **[拡張機能]** の順にクリックし、適切な拡張 SDK を選びます。 たとえば、呼び出す API がモバイル デバイス ファミリでのみ利用可能であり、それらの API がバージョン 10.0.x.y で導入されている場合は、**[Windows Mobile Extensions for the UWP]** を選びます。

これにより、次の参照がプロジェクト ファイルに追加されます。

```XML
<ItemGroup>
    <SDKReference Include="WindowsMobile, Version=10.0.x.y">
        <Name>Windows Mobile Extensions for the UWP</Name>
    </SDKReference>
</ItemGroup>
```

名前とバージョン番号は、SDK がインストールされている場所にあるフォルダーと一致します。 たとえば、上記の情報は次のフォルダー名と一致します。

`\Program Files (x86)\Windows Kits\10\Extension SDKs\WindowsMobile\10.0.x.y`

API を実装するデバイス ファミリがアプリのターゲットではない場合は、[**ApiInformation**](https://msdn.microsoft.com/library/windows/apps/dn949001) クラスを使って、API を呼び出す前に API の有無をテストする必要があります (これはアダプティブ コードと呼ばれます)。 このテストの条件は、アプリの実行時に必ず評価されますが、API が存在するデバイスに対してのみ true と評価され、呼び出しが可能になります。 ユニバーサル API が存在するかどうかを最初に確認した後では、拡張 SDK とアダプティブ コードのみを使います。 次のセクションで、例をいくつか示します。

「[アプリ パッケージ マニフェスト](#the-app-package-manifest)」もご覧ください。

## <a name="maximizing-markup-and-code-reuse"></a>マークアップとコード再利用の最大化

若干のリファクタリングを行い、アダプティブ コード (後で説明します) を追加することで、すべてのデバイス ファミリで動作するマークアップとコードを最大限に活用できることがわかります。 詳しい説明を次に示します。

-   すべてのデバイス ファミリに共通するファイルについては、特に考慮する必要はありません。 これらのファイルは、実行対象となるすべてのデバイス ファミリで、アプリが使うファイルです。 これには、XAML マークアップ ファイル、命令型ソース コード ファイル、アセット ファイルが含まれます。
-   実行されているデバイス ファミリをアプリで検出し、そのデバイス ファミリ専用に設計されたビューに移動させることができます。 詳しくは、「[アプリが実行されているプラットフォームの検出](wpsl-to-uwp-input-and-sensors.md)」をご覧ください。
-   プラットフォームを検出するための代替方法がない場合に役立つと考えられる同様の手法として、マークアップ ファイルや **ResourceDictionary** ファイル (またはこのファイルが保存されているフォルダー) に対して特殊な名前を設定する方法があります。この特殊な名前によって、アプリを特定のデバイス ファミリで実行する場合、実行時に自動的に読み込まれるようになります。 この手法については、「[Bookstore1](wpsl-to-uwp-case-study-bookstore1.md)」のケース スタディをご覧ください。
-   一部のデバイス ファミリでのみ利用できる機能 (プリンター、スキャナー、またはカメラのボタンなど) を使うには、アダプティブ コードを記述します。 このトピックの「[条件付きコンパイルとアダプティブ コード](#conditional-compilation-and-adaptive-code)」に記載されている 3 番目の例をご覧ください。
-   WindowsPhone Silverlight と windows 10 の両方をサポートする場合は、そのことができますプロジェクト間でソース コード ファイルを共有します。 Visual Studio でこのような処理を行うには、**ソリューション エクスプローラー**でプロジェクトを右クリックして **[既存項目の追加]** を選択し、共有するファイルを選択して **[リンクとして追加]** をクリックします。 リンクしたプロジェクトを確認できるファイル システム上の共通のフォルダーにソース コード ファイルを格納します。また、ソース コントロールに追加することを忘れないでください。 すべてではないにしても、大半のファイルが両プラットフォームで機能するように命令型ソース コードをファクタリングできる場合は、ファイルのコピーを 2 つ持つ必要はありません。 可能な場合は条件付きコンパイル ディレクティブ内、または必要であれば実行時条件付きで、ファイル内の任意のプラットフォーム固有ロジックを含めることができます。 次のセクションおよび「[C# プリプロセッサ ディレクティブ](http://msdn.microsoft.com/library/ed8yd1ha.aspx)」をご覧ください。
-   ソース コード レベルではなく、バイナリ レベルで再利用できるように、windows 10 アプリ (.NET Core) 用 WindowsPhone Silverlight で利用できる .NET Api のサブセットだけでなく、サブセットをサポートするポータブル クラス ライブラリがあります。 ポータブル クラス ライブラリ アセンブリは、これらの .NET プラットフォームおよびその他のプラットフォームとバイナリ レベルで互換性があります。 Visual Studio を使って、ポータブル クラス ライブラリをターゲットとするプロジェクトを作成します。 「[汎用性のあるクラス ライブラリを使用したプラットフォーム間の開発](http://msdn.microsoft.com/library/gg597391.aspx)」をご覧ください。

## <a name="conditional-compilation-and-adaptive-code"></a>条件付きコンパイルとアダプティブ コード

1 つのコード ファイルで WindowsPhone Silverlight と windows 10 の両方をサポートする場合、を実行できます。 プロジェクトのプロパティ ページで、windows 10 プロジェクトで参照する場合、プロジェクトは、条件付きコンパイル シンボルとして \_uap が定義することが表示されます。 一般的に、次のロジックを使って条件付きコンパイルを実行できます。

```csharp
#if WINDOWS_UAP
    // Code that you want to compile into the Windows 10 app.
#else
    // Code that you want to compile into the Windows Phone Silverlight app.
#endif // WINDOWS_UAP
```

WindowsPhone Silverlight アプリと Windows ランタイム 8.x アプリ間で共有コードがあれば、このようなロジックを使ってソース コード既にがあります。

```csharp
#if NETFX_CORE
    // Code that you want to compile into the Windows Runtime 8.x app.
#else
    // Code that you want to compile into the Windows Phone Silverlight app.
#endif // NETFX_CORE
```

その場合は、さらに windows 10 をサポートするようになりましたしを実行できます、すぎます。

```csharp
#if WINDOWS_UAP
    // Code that you want to compile into the Windows 10 app.
#else
#if NETFX_CORE
    // Code that you want to compile into the Windows Runtime 8.x app.
#else
    // Code that you want to compile into the Windows Phone Silverlight app.
#endif // NETFX_CORE
#endif // WINDOWS_UAP
```

ハードウェアの "戻る" ボタンの処理を Windows Phone に制限するために、条件付きコンパイルを使っている場合がありました。 Windows 10 での戻るボタンのイベントは、ユニバーサル概念です。 ハードウェアまたはソフトウェアに実装されているすべての "戻る" ボタンでは [**BackRequested**](https://msdn.microsoft.com/library/windows/apps/dn893596) イベントが発生するため、このイベントを処理します。

```csharp
       Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested +=
            this.ViewModelLocator_BackRequested;

...

    private void ViewModelLocator_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
    {
        // Handle the event.
    }

```

ハードウェアの "カメラ" ボタンの処理を Windows Phone に制限するために、条件付きコンパイルを使っている場合がありました。 、Windows 10 では、ハードウェアの"カメラ"ボタンは、モバイル デバイス ファミリに固有の概念です。 1 つのアプリ パッケージがすべてのデバイスで実行されるため、アダプティブ コードと呼ばれる手法を使って、コンパイル時の条件を実行時の条件に変更します。 そのためには、[**ApiInformation**](https://msdn.microsoft.com/library/windows/apps/dn949001) クラスを使って、実行時に [**HardwareButtons**](https://msdn.microsoft.com/library/windows/apps/jj207557) クラスの有無を照会します。 **HardwareButtons** は、モバイル拡張 SDK で定義されているため、その SDK への参照をプロジェクトに追加して、このコードをコンパイルする必要があります。 ただし、ハンドラーはモバイル拡張 SDK で定義されている型を実装するデバイスでのみ実行されることに注意してください。このようなデバイスは、モバイル デバイス ファミリに該当します。 次のコードでは存在する機能のみを使うように注意しています。ただし、条件付きコンパイルとは別の方法でこれを実現しています。

```csharp
       // Note: Cache the value instead of querying it more than once.
        bool isHardwareButtonsAPIPresent = Windows.Foundation.Metadata.ApiInformation.IsTypePresent
            ("Windows.Phone.UI.Input.HardwareButtons");

        if (isHardwareButtonsAPIPresent)
        {
            Windows.Phone.UI.Input.HardwareButtons.CameraPressed +=
                this.HardwareButtons_CameraPressed;
        }

    ...

    private void HardwareButtons_CameraPressed(object sender, Windows.Phone.UI.Input.CameraEventArgs e)
    {
        // Handle the event.
    }
```

「[アプリが実行されているプラットフォームの検出](wpsl-to-uwp-input-and-sensors.md)」もご覧ください。

## <a name="the-app-package-manifest"></a>アプリ パッケージ マニフェスト

アプリが呼び出すことのできる API サーフェス領域は、プロジェクトの設定 (拡張 SDK の参照を含む) によって決定されます。 ただし、ユーザーがアプリをストアからインストールできる実際のデバイスのセットを決定するのは、アプリ パッケージ マニフェストです。 詳しくは、「[**TargetDeviceFamily**](https://msdn.microsoft.com/library/windows/apps/dn986903)」の例をご覧ください。

この後のトピックでは、一部の機能で必要になるさまざまな宣言、機能、その他の設定に対してアプリ パッケージ マニフェストを使う方法について説明するため、アプリ パッケージ マニフェストを編集する方法を理解しておいてください。 Visual Studio アプリ パッケージ マニフェスト エディターを使って、編集できます。 **ソリューション エクスプローラー**が表示されていない場合は、**[表示]** メニューから選択します。 **[Package.appxmanifest]** をダブルクリックします。 マニフェスト エディター ウィンドウが開きます。 適切なタブを選んで変更し、変更を保存します。 移植先のアプリ マニフェスト内の **pm:PhoneIdentity** 要素が、移植元のアプリのアプリ マニフェスト内の要素と一致していることを、必要に応じて確認できます (詳しくは、「[**pm:PhoneIdentity**](https://msdn.microsoft.com/library/windows/apps/dn934763)」トピックをご覧ください)。

[パッケージ マニフェストの windows 10 のスキーマ リファレンス](https://msdn.microsoft.com/library/windows/apps/dn934820)を参照してください。

次のトピックは「[トラブルシューティング](wpsl-to-uwp-troubleshooting.md)」です。

