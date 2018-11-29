---
title: 結果を取得するためのアプリの起動
description: 別のアプリからアプリを起動し、2 つのアプリの間でデータを交換する方法について説明します。 これは、"結果を取得するためのアプリの起動" と呼ばれます。
ms.assetid: AFC53D75-B3DD-4FF6-9FC0-9335242EE327
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: f627cf2a897de32aea0e35faf66f5ea70695efd5
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7972513"
---
# <a name="launch-an-app-for-results"></a>結果を取得するためのアプリの起動




**重要な API**

-   [**LaunchUriForResultsAsync**](https://msdn.microsoft.com/library/windows/apps/dn956686)
-   [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131)

別のアプリからアプリを起動し、2 つのアプリの間でデータを交換する方法について説明します。 これは、"*結果を取得するためのアプリの起動*" と呼ばれます。 この例では、[**LaunchUriForResultsAsync**](https://msdn.microsoft.com/library/windows/apps/dn956686) を使って、結果を取得するためのアプリの起動方法を示しています。

新しいアプリ間の通信 windows 10 での Api を使うと Windows アプリ (および Windows Web アプリ) をアプリと exchange のデータとファイルを起動できます。 このため、複数のアプリを基にマッシュアップ ソリューションを構築できます。 これらの新しい API を使うと、複数のアプリを使う必要のあった複雑な作業をシームレスに処理できるようになります。 たとえば、アプリでソーシャル ネットワーキング アプリを起動して連絡先を選んだり、チェックアウト アプリを起動して支払処理を実行したりすることができます。

結果を得るために起動するアプリは、起動されたアプリと呼ばれます。 アプリを起動するアプリは、呼び出し元アプリと呼ばれます。 この例では、呼び出し元アプリと、起動されたアプリの両方を記述します。

## <a name="step-1-register-the-protocol-to-be-handled-in-the-app-that-youll-launch-for-results"></a>手順 1: 結果を取得するために起動するアプリで処理されるプロトコルを登録する


起動アプリの Package.appxmanifest ファイルで、プロトコル拡張機能を **&lt;Application&gt;** セクションに追加します。 この例では、**test-app2app** という名前の架空プロトコルを使います。

プロトコル拡張機能の **ReturnResults** 属性に指定できる値は、次の 3 つのうちいずれかです。

-   **optional**—結果を取得するためにアプリを起動する場合は、[**LaunchUriForResultsAsync**](https://msdn.microsoft.com/library/windows/apps/dn956686) メソッドを使います。結果を取得しない場合は、[**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) を使います。 **optional** を使うとき、起動アプリでは、結果を取得するためにアプリが起動されたかどうかを判別する必要があります。 これを行うには、[**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) イベント引数を調べます。 引数の [**IActivatedEventArgs.Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) プロパティが [**ActivationKind.ProtocolForResults**](https://msdn.microsoft.com/library/windows/apps/br224693) を返した場合、またはイベント引数の型が [**ProtocolActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224742) である場合は、アプリが **LaunchUriForResultsAsync** を介して起動されます。
-   **always**—アプリは、結果を取得するためにのみ起動することができます。つまり、[**LaunchUriForResultsAsync**](https://msdn.microsoft.com/library/windows/apps/dn956686) に対してのみ応答できます。
-   **none**—アプリは、結果を取得するために起動することはできません。[**LaunchUriAsync**](https://msdn.microsoft.com/library/windows/apps/hh701476) に対してのみ応答できます。

次のプロトコル拡張機能の例では、アプリは結果を取得するためにのみ起動することができます。 以下で説明するように、この例では、**OnActivated** メソッド内部のロジックが簡素化されます。これは、"結果を取得するために起動する" ケースのみを処理し、アプリをアクティブ化する他の方法を処理する必要がないためです。

```xml
<Applications>
   <Application ...>

     <Extensions>
       <uap:Extension Category="windows.protocol">
         <uap:Protocol Name="test-app2app" ReturnResults="always">
           <uap:DisplayName>Test app-2-app</uap:DisplayName>
         </uap:Protocol>
       </uap:Extension>
     </Extensions>

   </Application>
</Applications>
```

## <a name="step-2-override-applicationonactivated-in-the-app-that-youll-launch-for-results"></a>手順 2: 結果を取得するために起動するアプリで Application.OnActivated をオーバーライドする


このメソッドが起動アプリにまだ存在しない場合は、App.xaml.cs で定義されている `App` クラス内に作成します。

ソーシャル ネットワークで友だちを選ぶことができるアプリでは、この関数によって友だちを選ぶためのページを開くことができます。 次の例では、**LaunchedForResultsPage** という名前のページが、結果を取得するためにアプリがアクティブ化されたときに表示されます。 ファイルの先頭に、次の **using** ステートメントが含まれていることを確認します。

```cs
using Windows.ApplicationModel.Activation;
...
protected override void OnActivated(IActivatedEventArgs args)
{
    // Window management
    Frame rootFrame = Window.Current.Content as Frame;
    if (rootFrame == null)
    {
        rootFrame = new Frame();
        Window.Current.Content = rootFrame;
    }

    // Code specific to launch for results
    var protocolForResultsArgs = (ProtocolForResultsActivatedEventArgs)args;
    // Open the page that we created to handle activation for results.
    rootFrame.Navigate(typeof(LaunchedForResultsPage), protocolForResultsArgs);

    // Ensure the current window is active.
    Window.Current.Activate();
}
```

Package.appxmanifest ファイル内のプロトコル拡張機能では **ReturnResults** が **always** と指定されているため、上記のコードでは `args` を [**ProtocolForResultsActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn906905) に直接キャストすることができます。このとき、**ProtocolForResultsActivatedEventArgs** のみが、このアプリの **OnActivated** に送信されます。 結果を取得するための起動以外の方法でアプリがアクティブ化される可能性がある場合は、結果を取得するためにアプリが起動されたかどうかを判別するために [**IActivatedEventArgs.Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) プロパティが [**ActivationKind.ProtocolForResults**](https://msdn.microsoft.com/library/windows/apps/br224693) を返すかどうかを確認してください。

## <a name="step-3-add-a-protocolforresultsoperation-field-to-the-app-you-launch-for-results"></a>手順 3: 結果を取得するために起動するアプリに ProtocolForResultsOperation フィールドを追加する


```cs
private Windows.System.ProtocolForResultsOperation _operation = null;
```

[**ProtocolForResultsOperation**](https://msdn.microsoft.com/library/windows/apps/dn906913) フィールドを使うと、起動されたアプリが呼び出し元のアプリに結果を返すことができるようになった場合に、そのタイミングを通知することができます。 この例では、このフィールドは **LaunchedForResultsPage** クラスに追加されます。これは、結果を取得するための起動処理をそのページから実行し、そのページにアクセスする必要があるためです。

## <a name="step-4-override-onnavigatedto-in-the-app-you-launch-for-results"></a>手順 4: 結果を取得するために起動するアプリで OnNavigatedTo() をオーバーライドする


結果を取得するためにアプリを起動するときに表示するページで、[**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) メソッドをオーバーライドします。 このメソッドがまだ存在しない場合は、&lt;ページ名&gt;.xaml.cs で定義されているページのクラス内に作成します。 ファイルの先頭に、次の **using** ステートメントが含まれていることを確認します。

```cs
using Windows.ApplicationModel.Activation
```

[**OnNavigatedTo**](https://msdn.microsoft.com/library/windows/apps/br227508) メソッド内の [**NavigationEventArgs**](https://msdn.microsoft.com/library/windows/apps/br243285) オブジェクトには、呼び出し元アプリから渡されたデータが含まれます。 データは最大で 100 KB になります。また、データは [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) オブジェクトに格納されます。

次のコード例では、起動されたアプリは、呼び出し元のアプリから送信されたデータが **TestData** というキーで [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) に格納されていることを想定しています。これは、サンプルの呼び出し元アプリで、データを送信するためにそのようにコード化されているためです。

```cs
using Windows.ApplicationModel.Activation;
...
protected override void OnNavigatedTo(NavigationEventArgs e)
{
    var protocolForResultsArgs = e.Parameter as ProtocolForResultsActivatedEventArgs;
    // Set the ProtocolForResultsOperation field.
    _operation = protocolForResultsArgs.ProtocolForResultsOperation;

    if (protocolForResultsArgs.Data.ContainsKey("TestData"))
    {
        string dataFromCaller = protocolForResultsArgs.Data["TestData"] as string;
    }
}
...
private Windows.System.ProtocolForResultsOperation _operation = null;
```

## <a name="step-5-write-code-to-return-data-to-the-calling-app"></a>手順 5: 呼び出し元のアプリにデータを返すコードを記述する


起動アプリで、[**ProtocolForResultsOperation**](https://msdn.microsoft.com/library/windows/apps/dn906913) を使って呼び出し元のアプリにデータを返します。 次のコード例では、呼び出し元のアプリに返す値を格納する [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) オブジェクトが作成されます。 その後で、**ProtocolForResultsOperation** フィールドを使って、呼び出し元のアプリに値を送信します。

```cs
    ValueSet result = new ValueSet();
    result["ReturnedData"] = "The returned result";
    _operation.ReportCompleted(result);
```

## <a name="step-6-write-code-to-launch-the-app-for-results-and-get-the-returned-data"></a>手順 6: 結果を取得するためにアプリを起動し、返されたデータを取得するコードを記述する


次のコード例に示すように、呼び出し元のアプリの非同期メソッド内で、アプリを起動します。 **using** ステートメントは、コードをコンパイルするために必要となります。

```cs
using System.Threading.Tasks;
using Windows.System;
...

async Task<string> LaunchAppForResults()
{
    var testAppUri = new Uri("test-app2app:"); // The protocol handled by the launched app
    var options = new LauncherOptions();
    options.TargetApplicationPackageFamilyName = "67d987e1-e842-4229-9f7c-98cf13b5da45_yd7nk54bq29ra";

    var inputData = new ValueSet();
    inputData["TestData"] = "Test data";

    string theResult = "";
    LaunchUriResult result = await Windows.System.Launcher.LaunchUriForResultsAsync(testAppUri, options, inputData);
    if (result.Status == LaunchUriStatus.Success &&
        result.Result != null &&
        result.Result.ContainsKey("ReturnedData"))
    {
        ValueSet theValues = result.Result;
        theResult = theValues["ReturnedData"] as string;
    }
    return theResult;
}
```

この例では、キー **TestData** を含んでいる [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) が、起動アプリに渡されます。 起動アプリは、**ReturnedData** という名前のキーを持つ **ValueSet** を作成します。これには、呼び出し元に返される結果が含まれています。

結果を取得するために起動するアプリは、呼び出し元アプリを実行する前にビルドし、展開する必要があります。 このように操作しないと、[**LaunchUriResult.Status**](https://msdn.microsoft.com/library/windows/apps/dn906892) は **LaunchUriStatus.AppUnavailable** を報告します。

[**TargetApplicationPackageFamilyName**](https://msdn.microsoft.com/library/windows/apps/dn893511) を設定するときは、起動アプリのファミリ名が必要です。 ファミリ名を取得する方法の 1 つは、起動アプリ内から、次の呼び出しを行うことです。

```cs
string familyName = Windows.ApplicationModel.Package.Current.Id.FamilyName;
```

## <a name="remarks"></a>注釈


この方法の例については、結果を取得するためのアプリの起動の概要を説明した "hello world" アプリをご覧ください。 重要な注意点は、新しい [**LaunchUriForResultsAsync**](https://msdn.microsoft.com/library/windows/apps/dn956686) API を使うと、アプリを非同期的に起動し、[**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131) クラスを使って通信できるようになることです。 **ValueSet** を使って渡すデータは、100 KB に制限されます。 より多くのデータを渡す必要がある場合は、アプリ間で渡すことができるファイル トークンを作成するための、[**SharedStorageAccessManager**](https://msdn.microsoft.com/library/windows/apps/dn889985) クラスを使ってファイルを共有することができます。 たとえば、`inputData` という名前の **ValueSet** を指定し、起動アプリと共有するファイルのトークンを格納できます。

```cs
inputData["ImageFileToken"] = SharedStorageAccessManager.AddFile(myFile);
```

その後で、**LaunchUriForResultsAsync** を使って、トークンを起動アプリに渡します。

## <a name="related-topics"></a>関連トピック


* [**LaunchUri**](https://msdn.microsoft.com/library/windows/apps/hh701476)
* [**LaunchUriForResultsAsync**](https://msdn.microsoft.com/library/windows/apps/dn956686)
* [**ValueSet**](https://msdn.microsoft.com/library/windows/apps/dn636131)

 

 
