---
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、共有コントラクトを使用して別のアプリから共有されたコンテンツを受け取る方法について説明します。 共有コントラクトを使うと、ユーザーが共有機能を呼び出したときに、アプリをオプションとして提示できます。
title: データの受信
ms.assetid: 0AFF9E0D-DFF4-4018-B393-A26B11AFDB41
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 7d64e4a2d4251aca6bbce39b5f24e3e5f35295b8
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6844303"
---
# <a name="receive-data"></a>データの受信



この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリで、共有コントラクトを使用して別のアプリから共有されたコンテンツを受け取る方法について説明します。 共有コントラクトを使うと、ユーザーが共有機能を呼び出したときに、アプリをオプションとして提示できます。

## <a name="declare-your-app-as-a-share-target"></a>アプリを共有ターゲットとして宣言する

ユーザーが共有を選択すると、ターゲット アプリの一覧が表示されます。 アプリを一覧に表示するには、そのアプリが共有コントラクトをサポートしていることを宣言する必要があります。 こうすることで、そのアプリでコンテンツを受け取ることができるとシステムに通知できます。

1.  マニフェスト ファイルを開きます。 マニフェスト ファイルは **package.appxmanifest** のような名前になっています。
2.  **[宣言]** タブを開きます。
3.  **[使用可能な宣言]** ボックスの一覧の **[共有ターゲット]** を選び、**[追加]** をクリックします。

## <a name="choose-file-types-and-formats"></a>ファイルの種類と形式を選択する

次に、サポートするファイルの種類とデータ形式を決定します。 共有 API では、テキスト、HTML、ビットマップなど複数の標準形式がサポートされます。 カスタムのファイルの種類とデータ形式を指定することもできます。 これを行う場合は、その種類と形式をソース アプリが認識している必要があります。そうしないと、ソース アプリはその形式を使ってデータを共有できません。

アプリで処理できる形式のみを登録してください。 ユーザーが共有を選択すると、共有されるデータをサポートしているターゲット アプリだけが表示されます。

ファイルの種類を設定するには:

1.  マニフェスト ファイルを開きます。 マニフェスト ファイルは **package.appxmanifest** のような名前になっています。
2.  **[宣言]** ページの **[サポートされるファイルの種類]** セクションで、**[新規追加]** をクリックします。
3.  サポートするファイル名拡張子を入力します。たとえば、「.docx」と入力します。 ピリオドを忘れないように注意してください。 すべてのファイルの種類をサポートする場合は、**SupportsAnyFileType** チェック ボックスをオンにします。

データ形式を設定するには:

1.  マニフェスト ファイルを開きます。
2.  **[宣言]** ページの **[データ形式]** セクションを開き、**[新規追加]** をクリックします。
3.  サポートすデータ形式の名前を入力します。たとえば、「テキスト」と入力します。

## <a name="handle-share-activation"></a>共有のアクティブ化の処理

ユーザーが (通常は共有 UI の使用可能なターゲット アプリの一覧から) アプリを選ぶと、[**OnShareTargetActivated**](https://msdn.microsoft.com/library/windows/apps/Windows.UI.Xaml.Application.OnShareTargetActivated(Windows.ApplicationModel.Activation.ShareTargetActivatedEventArgs)) イベントが発生します。 アプリはこのイベントを処理して、ユーザーが共有するデータを処理する必要があります。

<!-- For some reason, the snippets in this file are all inline in the WDCML topic. Suggest moving to VS project with rest of snippets. -->
```cs
protected override async void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
{
    // Code to handle activation goes here. 
} 
```

ユーザーが共有するデータは、[**ShareOperation**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation) オブジェクトに格納されています。 このオブジェクトを使うと、オブジェクトに格納されているデータの形式を調べることができます。

```cs
ShareOperation shareOperation = args.ShareOperation;
if (shareOperation.Data.Contains(StandardDataFormats.Text))
{
    string text = await shareOperation.Data.GetTextAsync();

    // To output the text from this example, you need a TextBlock control
    // with a name of "sharedContent".
    sharedContent.Text = "Text: " + text;
} 
```

## <a name="report-sharing-status"></a>共有状態の報告

場合によっては、ユーザーが共有するデータをアプリが処理するのに時間がかかることがあります。 たとえば、ファイルまたは画像のコレクションを共有する場合などです。 このような項目は単純なテキスト文字列より大きいため、処理に時間がかかります。

```cs
shareOperation.ReportStarted(); 
```

[**ReportStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportStarted) を呼び出した後、ユーザーはアプリをそれ以上操作できなくなります。 したがって、このオブジェクトの呼び出しは、ユーザーがアプリを閉じても問題がない状況でのみ行ってください。

長時間共有が行われている状況では、アプリが DataPackage オブジェクトからすべてのデータを取得する前に、ユーザーがソース アプリを閉じる可能性があります。 そのため、アプリが必要なデータを取得したタイミングをシステムに通知することをお勧めします。 こうすると、システムは必要に応じてソース アプリを中断または終了できます。

```cs
shareOperation.ReportSubmittedBackgroundTask(); 
```

問題が発生した場合には、[**ReportError**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportError(System.String)) を呼び出して、エラー メッセージをシステムに送信します。 ユーザーは、共有の状態を確認したときにこのメッセージを目にします。 その時点で、アプリがシャットダウンし、共有が終了します。 この場合、ユーザーはアプリでのコンテンツの共有をやり直す必要があります。 エラーの中にはそれほど重大ではないものも含まれ、シナリオによっては、共有操作を終了しなくても済む場合もあります。 その場合は、**ReportError** を呼び出さずに、共有を続けることができます。

```cs
shareOperation.ReportError("Could not reach the server! Try again later."); 
```

最後に、アプリによる共有コンテンツの処理が正常に完了したときは、[**ReportCompleted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportCompleted) を呼び出してシステムに通知する必要があります。

```cs
shareOperation.ReportCompleted();
```

これらのメソッドを使う場合は、通常、前に説明した順序で呼び出し、2 回以上呼び出さないようにしてください。 ただし、ターゲット アプリが [**ReportStarted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportStarted) の前に [**ReportDataRetrieved**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportDataRetrieved) を呼び出すことができる場合があります。 たとえば、アプリがアクティブ化ハンドラーのタスクの一部としてデータを受信できるが、ユーザーが **[共有]** ボタンをクリックするまで **ReportStarted** を呼び出さない場合です。

## <a name="return-a-quicklink-if-sharing-was-successful"></a>共有が成功した場合に QuickLink を返す

ユーザーがアプリでコンテンツを受け取ることを選んだときは、[**QuickLink**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.QuickLink) を作成することをお勧めします。 **QuickLink** は、情報をアプリと簡単に共有できるようにするショートカットのようなものです。 たとえば、あらかじめ友人のメール アドレスが構成された新しいメール メッセージを開く **QuickLink** を作成できます。

**QuickLink** には、タイトル、アイコン、ID が必要です。タイトル ("母へのメール" など) とアイコンは、ユーザーが共有チャームをタップすると表示されます。 ID は、アプリがメール アドレスやログイン資格情報などのカスタム情報にアクセスするために使われます。 アプリは、**QuickLink** を作成すると、[**ReportCompleted**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.ReportCompleted) を呼び出して **QuickLink** をシステムに返します。

**QuickLink** には、実際にデータが格納されているわけではなく、 識別子だけが含まれています。選択されたときにその識別子がアプリに送られます。 **QuickLink** の ID と対応するユーザー データは、アプリで格納する必要があります。 ユーザーが **QuickLink** をタップすると、[**QuickLinkId**](https://msdn.microsoft.com/library/windows/apps/Windows.ApplicationModel.DataTransfer.ShareTarget.ShareOperation.QuickLinkId) プロパティを介してその ID を取得できます。

```cs
async void ReportCompleted(ShareOperation shareOperation, string quickLinkId, string quickLinkTitle)
{
    QuickLink quickLinkInfo = new QuickLink
    {
        Id = quickLinkId,
        Title = quickLinkTitle,

        // For quicklinks, the supported FileTypes and DataFormats are set 
        // independently from the manifest
        SupportedFileTypes = { "*" },
        SupportedDataFormats = { StandardDataFormats.Text, StandardDataFormats.Uri, 
                StandardDataFormats.Bitmap, StandardDataFormats.StorageItems }
    };

    StorageFile iconFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.CreateFileAsync(
            "assets\\user.png", CreationCollisionOption.OpenIfExists);
    quickLinkInfo.Thumbnail = RandomAccessStreamReference.CreateFromFile(iconFile);
    shareOperation.ReportCompleted(quickLinkInfo);
}
```

## <a name="see-also"></a>参照 

* [アプリ間通信](index.md)
* [データの共有](share-data.md)
* [OnShareTargetActivated](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.application.onsharetargetactivated.aspx)
* [ReportStarted](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.shareoperation.reportstarted.aspx)
* [ReportError](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.shareoperation.reporterror.aspx)
* [ReportCompleted](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.shareoperation.reportcompleted.aspx)
* [ReportDataRetrieved](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.shareoperation.reportdataretrieved.aspx)
* [ReportStarted](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.shareoperation.reportstarted.aspx)
* [QuickLink](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.quicklink.aspx)
* [QuickLInkId](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.datatransfer.sharetarget.quicklink.id.aspx)
