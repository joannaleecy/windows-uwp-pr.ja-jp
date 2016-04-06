---
description: ネットワーク経由でファイルを確実にコピーするには、バックグラウンド転送 API を使います。
title: バックグラウンド転送
ms.assetid: 1207B089-BC16-4BF0-BBD4-FD99950C764B
---

# バックグラウンド転送

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]


**重要な API**

-   [**Windows.Networking.backgroundTransfer**](https://msdn.microsoft.com/library/windows/apps/br207242)
-   [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998)
-   [**Windows.Networking.Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960)

ネットワーク経由でファイルを確実にコピーするには、バックグラウンド転送 API を使います。 バックグラウンド転送 API には、アプリの一時停止中はバックグラウンドで実行され、アプリの終了後も実行が続行される高度なアップロード機能とダウンロード機能があります。 この API は、ネットワークの状態を監視し、接続が失われたときに転送の中断と再開を自動的に実行します。転送ではデータ センサーとバッテリー セーバーにも対応し、ダウンロード アクティビティは現在の接続とデバイスのバッテリー状態に基づいて調整されます。 この API は、アップロード HTTP(S) を使った大きなファイルのアップロードとダウンロードに適しています。 FTP もサポートされますが、その対象はダウンロードのみです。

バックグラウンド転送はアプリの呼び出しとは別に実行され、主にビデオ、音楽、サイズの大きい画像などのリソースの長期の転送操作を目的としています。 これらのシナリオでは、アプリが一時停止状態でもダウンロードが続行されるため、バックグラウンド転送の使用が不可欠です。

すぐに完了する可能性がある小さいリソースをダウンロードする場合は、バックグラウンド転送ではなく [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) API を使ってください。

## Windows.Networking.BackgroundTransfer を使う


### バックグラウンド転送機能はどのように動作するか

アプリがバックグラウンド転送を使って転送を開始するときは、[**BackgroundDownloader**](https://msdn.microsoft.com/library/windows/apps/br207126) または [**BackgroundUploader**](https://msdn.microsoft.com/library/windows/apps/br207140) クラス オブジェクトを使って要求が構成され初期化されます。 それぞれの転送操作は、呼び出し元アプリとは別にシステムによって個別に処理されます。 進行情報はアプリの UI でユーザーに状況を示す場合に利用することができ、アプリで一時停止、再開、キャンセルしたり、転送中にデータを読み取ったりすることができます。 システムによって転送が処理される方法により、スマートな電力消費が実現し、アプリの中断や終了、突然のネットワーク ステータス変化などのイベントが接続アプリで発生したときに起こる可能性のある問題を回避できます。

### バックグラウンド転送での認証されたファイル要求の実行

バックグラウンド転送では、基本サーバーとプロキシの資格情報、Cookie をサポートするメソッドが用意されており、それぞれの転送操作で ([**SetRequestHeader**](https://msdn.microsoft.com/library/windows/apps/br207146) を介して) カスタム HTTP ヘッダーを使うこともできます。

### この機能ではネットワーク ステータスの変化や予期しないシャットダウンにどのように対応するか

バックグラウンド転送機能により、ネットワークの状態が変化したときに各転送操作に対して一貫性のあるエクスペリエンスが保たれます。これは、[接続](https://msdn.microsoft.com/library/windows/apps/hh452990) 機能によって提供される接続とキャリアのデータ プラン ステータスの情報をインテリジェントに利用しています。 さまざまなネットワーク シナリオでの動作を定義するために、アプリは、[**BackgroundTransferCostPolicy**](https://msdn.microsoft.com/library/windows/apps/br207138) によって定義された値を使って、各転送操作のコスト ポリシーを設定します。

たとえば、操作に対して定義されたコスト ポリシーで、デバイスが従量制課金接続を使っているときに操作を自動的に一時停止する必要があることを示すことができます。 "制限のない" ネットワークへの接続が確立されたときには、転送が自動的に再開されます。 コストによってネットワークがどのように定義されるかについては、「[**NetworkCostType**](https://msdn.microsoft.com/library/windows/apps/br207292)」をご覧ください。

バックグラウンド転送機能にはネットワーク ステータスの変化に対応する独自のメカニズムがありますが、ネットワーク接続されたアプリには他にも一般的な接続の考慮事項があります。 詳しくは、「[利用できるネットワーク接続情報の活用](https://msdn.microsoft.com/library/windows/apps/hh452983)」をご覧ください。

> **注:** モバイル デバイスで実行されるアプリでは、接続の種類、ローミング ステータス、ユーザーのデータ通信プランに基づいて転送されるデータの量を、ユーザーが監視および制限できる機能が用意されています。 このため、[**BackgroundTransferCostPolicy**](https://msdn.microsoft.com/library/windows/apps/br207138) が転送が継続中であることを示す場合でも、電話でバックグラウンド転送が一時停止される可能性があります。

次の表に、電話の現在の状態に応じて、[**BackgroundTransferCostPolicy**](https://msdn.microsoft.com/library/windows/apps/br207138) の各値に対して、電話でバックグラウンド転送が許可されるかどうかを示します。 [
            **ConnectionCost**](https://msdn.microsoft.com/library/windows/apps/br207244) クラスを使って、電話の現在の状態を判断できます。

| デバイスの状態                                                                                                                      | UnrestrictedOnly | Default (既定) | Always |
|-----------------------------------------------------------------------------------------------------------------------------------|------------------|---------|--------|
| WiFi 接続                                                                                                                 | 許可            | 許可   | 許可  |
| 従量制課金接続、ローミング時以外、データ制限未満、制限内にとどまる見込み                                                   | 拒否             | 許可   | 許可  |
| 従量制課金接続、ローミング時以外、データ制限未満、制限を超過する見込み                                                       | 拒否             | 拒否    | 許可  |
| 従量制課金接続、ローミング時、データ制限未満                                                                                     | 拒否             | 拒否    | 許可  |
| 従量制課金接続、データ制限超過 この状態は、ユーザーが Data Sense UI で [バックグラウンドでのデータ通信を制限する] を有効にしている場合にのみ発生します。 | 拒否             | 拒否    | 拒否   |

 

## ファイルのアップロード


バックグラウンド転送を使う場合、アップロードは [**UploadOperation**](https://msdn.microsoft.com/library/windows/apps/br207224) として存在し、操作の再起動や取り消しに使われる多くの制御メソッドを公開します。 アプリのイベント (一時停止、終了など) や接続の変更は、**UploadOperation** を通じてシステムによって自動的に処理されます。アップロードは、アプリの一時停止中も続行し、アプリの終了以降は一時停止して保持されます。 また、[**CostPolicy**](https://msdn.microsoft.com/library/windows/apps/hh701018) プロパティを設定することで、従量制課金接続がインターネット接続のために使われている間もアプリがアップロードを開始するかどうかを指定します。

以下に、基本的なアップロードを作成および初期化する例と、前のアプリ セッションから続いている操作を列挙および再び取り込む例を示します。

### 1 つのファイルのアップロード

アップロードの作成は、[**BackgroundUploader**](https://msdn.microsoft.com/library/windows/apps/br207140) から始めます。 このクラスは、アプリで [**UploadOperation**](https://msdn.microsoft.com/library/windows/apps/br207224) を作成する前に、そのアップロードを構成できるようにするメソッドを提供するために使われます。 次の例は、必要な [**Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) オブジェクトと [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを使ってこれを行う方法を示しています。

**アップロードするファイルと送信先の特定**

[
            **UploadOperation**](https://msdn.microsoft.com/library/windows/apps/br207224) の作成を始める前に、アップロード先となる場所の URI とアップロードされるファイルを識別する必要があります。 次の例では、UI 入力からの文字列を使って *uriString* の値が設定され、[**PickSingleFileAsync**](https://msdn.microsoft.com/library/windows/apps/jj635275) 操作で返される [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを使って *file* の値が設定されます。

[!code-js[uploadFile](./code/backgroundtransfer/upload_quickstart/js/main.js#Snippetupload_quickstart_B "アップロードするファイルと送信先の特定")]

**アップロード操作の作成と初期化**

前の手順では、*uriString* と *file* の値が次に示す例の UploadOp のインスタンスに渡されました。これらの値は、新しいアップロード操作を構成し開始するために使われます。 まず、*uriString* が解析されて、要求された [**Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) オブジェクトが作成されます。

そして、与えられた [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) (*file*) のプロパティが [**BackgroundUploader**](https://msdn.microsoft.com/library/windows/apps/br207140) で使われて要求ヘッダーが設定され、*SourceFile* プロパティに **StorageFile** オブジェクトが設定されます。 次に、[**SetRequestHeader**](https://msdn.microsoft.com/library/windows/apps/br207146) メソッドが呼び出され、文字列として提供されたファイル名と [**StorageFile.Name**](https://msdn.microsoft.com/library/windows/apps/br227220) プロパティが挿入されます。

最後に、[**BackgroundUploader**](https://msdn.microsoft.com/library/windows/apps/br207140) によって [**UploadOperation**](https://msdn.microsoft.com/library/windows/apps/br207224) (*upload*) が作成されます。

[!code-js[uploadFile](./code/backgroundtransfer/upload_quickstart/js/main.js#Snippetupload_quickstart_A "アップロード操作の作成と初期化")]

JavaScript の promise を使って定義した非同期メソッドの呼び出しに注意してください。 最後の例には次の行があります。

```javascript
promise = upload.startAsync().then(complete, error, progress);
```

    The async method call is followed by a then statement which indicates methods, defined by the app, that are called when a result from the async method call is returned. For more information on this programming pattern, see [Asynchronous programming in JavaScript using promises](http://msdn.microsoft.com/library/windows/apps/hh464930.aspx).

### 複数のファイルのアップロード

**アップロードするファイルと送信先の特定**

    In a scenario involving multiple files transferred with a single [**UploadOperation**](https://msdn.microsoft.com/library/windows/apps/br207224), the process begins as it usually does by first providing the required destination URI and local file information. Similar to the example in the previous section, the URI is provided as a string by the end-user and [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) can be used to provide the ability to indicate files through the user interface as well. However, in this scenario the app should instead call the [**PickMultipleFilesAsync**](https://msdn.microsoft.com/library/windows/apps/br207851) method to enable the selection of multiple files through the UI.

```javascript
function uploadFiles() {
       var filePicker = new Windows.Storage.Pickers.FileOpenPicker();
       filePicker.fileTypeFilter.replaceAll(["*"]);

       filePicker.pickMultipleFilesAsync().then(function (files) {
          if (files === 0) {
             printLog("No file selected");
                return;
          }

          var upload = new UploadOperation();
          var uriString = document.getElementById("serverAddressField").value;
          upload.startMultipart(uriString, files);

          // Persist the upload operation in the global array.
          uploadOperations.push(upload);
       });
    }
```

**指定されたパラメーターに基づくオブジェクトの作成**

    The next two examples use code contained in a single example method, **startMultipart**, which was called at the end of the last step. For the purpose of instruction the code in the method that creates an array of [**BackgroundTransferContentPart**](https://msdn.microsoft.com/library/windows/apps/hh923029) objects has been split from the code that creates the resultant [**UploadOperation**](https://msdn.microsoft.com/library/windows/apps/br207224).

    First, the URI string provided by the user is initialized as a [**Uri**](https://msdn.microsoft.com/library/windows/apps/br225998). Next, the array of [**IStorageFile**](https://msdn.microsoft.com/library/windows/apps/br227102) objects (**files**) passed to this method is iterated through, each object is used to create a new [**BackgroundTransferContentPart**](https://msdn.microsoft.com/library/windows/apps/hh923029) object which is then placed in the **contentParts** array.

```javascript
upload.startMultipart = function (uriString, files) {
        try {
            var uri = new Windows.Foundation.Uri(uriString);
            var uploader = new Windows.Networking.BackgroundTransfer.BackgroundUploader();

            var contentParts = [];
            files.forEach(function (file, index) {
                var part = new Windows.Networking.BackgroundTransfer.BackgroundTransferContentPart("File" + index, file.name);
                part.setFile(file);
                contentParts.push(part);
            });
```

**マルチパート アップロード操作の作成と初期化**

    With our contentParts array populated with all of the [**BackgroundTransferContentPart**](https://msdn.microsoft.com/library/windows/apps/hh923029) objects representing each [**IStorageFile**](https://msdn.microsoft.com/library/windows/apps/br227102) for upload, we are ready to call [**CreateUploadAsync**](https://msdn.microsoft.com/library/windows/apps/hh923973) using the [**Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) to indicate where the request will be sent.

```javascript
        // Create a new upload operation.
            uploader.createUploadAsync(uri, contentParts).then(function (uploadOperation) {

               // Start the upload and persist the promise to be able to cancel the upload.
               upload = uploadOperation;
               promise = uploadOperation.startAsync().then(complete, error, progress);
            });

         } catch (err) {
             displayError(err);
         }
     };
```

### 中断されたアップロード操作の再開

[
            **UploadOperation**](https://msdn.microsoft.com/library/windows/apps/br207224) が完了するか取り消されると、関連するシステム リソースがすべて解放されます。 ただし、これらのイベントのどちらかが発生する前にアプリが終了した場合、アクティブな操作は一時停止され、それぞれに関連付けられているリソースは占有されたままになります。 これらの操作が列挙されずに次のアプリ セッションに再び取り込まれると、それらの操作は完了せず、デバイス リソースを占有したままとなります。

1.  持続している操作を列挙する関数を定義する前に、返される [**UploadOperation**](https://msdn.microsoft.com/library/windows/apps/br207224) オブジェクトを格納する配列を作成する必要があります。

[!code-js[uploadFile](./code/backgroundtransfer/upload_quickstart/js/main.js#Snippetupload_quickstart_C "中断されたアップロード操作の再開")]

2.  次に、持続している操作を列挙してそれらを配列に格納する関数を定義します。 [
            **UploadOperation**](https://msdn.microsoft.com/library/windows/apps/br207224) に対するコールバックを再び割り当てるために呼び出される **load** メソッドは、アプリの終了後も持続する場合、このセクションでこの後定義する UploadOp クラス内にあることに注意してください。

[!code-js[uploadFile](./code/backgroundtransfer/upload_quickstart/js/main.js#Snippetupload_quickstart_D "持続している操作を列挙する")]

## ファイルのダウンロード

バックグラウンド転送を使う場合、各ダウンロードは [**DownloadOperation**](https://msdn.microsoft.com/library/windows/apps/br207154) として存在し、操作の一時停止、再開、再起動、取り消しに使われる多くの制御メソッドを公開します。 アプリのイベント (一時停止、終了など) や接続の変更は、**DownloadOperation** を通じてシステムによって自動的に処理されます。ダウンロードは、アプリの一時停止中も続行し、アプリの終了以降は一時停止して保持されます。 モバイル ネットワーク シナリオの場合、[**CostPolicy**](https://msdn.microsoft.com/library/windows/apps/hh701018) プロパティを設定することで、従量制課金接続がインターネット接続のために使われている間もアプリがダウンロードを開始または続行するかどうかを指定します。

すぐに完了する可能性がある小さいリソースをダウンロードする場合は、バックグラウンド転送ではなく [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) API を使ってください。

以下に、基本的なダウンロードを作成および初期化する例と、前のアプリ セッションから続いている操作を列挙および再び取り込む例を示します。

### バックグラウンド転送によるファイルのダウンロードを構成して開始する

URI とファイル名を表す文字列を使って、[**Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) オブジェクトと要求されたファイルを格納する [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) とを作成する方法を次の例で示します。 この例では、新しいファイルが定義済みの場所に自動的に配置されます。 または、[**FileSavePicker**](https://msdn.microsoft.com/library/windows/apps/br207871) を使ってユーザーがファイルを保存するデバイスの場所を指定できるようになります。 [
            **DownloadOperation**](https://msdn.microsoft.com/library/windows/apps/br207154) に対するコールバックを再び割り当てるために呼び出される **load** メソッドは、アプリの終了以降も持続する場合、このセクションでこの後定義する DownloadOp クラス内にあることに注意してください。

[!code-js[uploadFile](./code/backgroundtransfer/download_quickstart/js/main.js#Snippetdownload_quickstart_A)]

JavaScript の promise を使って定義した非同期メソッドの呼び出しに注意してください。 前のコード例の 17 行目には次のコードがあります。

```javascript
promise = download.startAsync().then(complete, error, progress);
```

非同期メソッドの後に then ステートメントが続いています。このステートメントでは、非同期メソッドの呼び出しの結果が返されたときに呼び出される、アプリで定義されたメソッドを指定しています。 このプログラミング パターンについて詳しくは、「[プロミスを使った JavaScript での非同期プログラミング](http://msdn.microsoft.com/library/windows/apps/hh464930.aspx)」をご覧ください。

### その他の操作制御メソッドの追加

追加の [**DownloadOperation**](https://msdn.microsoft.com/library/windows/apps/br207154) メソッドを実装することによって、制御のレベルを高めることができます。 上の例に次のコードを追加すると、ダウンロードをキャンセルすることができるようになります。

[!code-js[uploadFile](./code/backgroundtransfer/download_quickstart/js/main.js#Snippetdownload_quickstart_B)]

### 持続している操作の起動時の列挙

[
            **DownloadOperation**](https://msdn.microsoft.com/library/windows/apps/br207154) が完了するか取り消されると、関連するシステム リソースがすべて解放されます。 ただし、これらのイベントのどちらかが発生する前にアプリが終了した場合、ダウンロードは一時停止され、バックグラウンドで保持されます。 以下の例は、持続しているダウンロードを新しいアプリ セッションに再び取り込む方法を示しています。

1.  持続している操作を列挙する関数を定義する前に、返される [**DownloadOperation**](https://msdn.microsoft.com/library/windows/apps/br207154) オブジェクトを格納する配列を作成する必要があります。

[!code-js[uploadFile](./code/backgroundtransfer/download_quickstart/js/main.js#Snippetdownload_quickstart_D)]

2.  次に、持続している操作を列挙してそれらを配列に格納する関数を定義します。 持続している [**DownloadOperation**](https://msdn.microsoft.com/library/windows/apps/br207154) に対するコールバックを再び割り当てるために呼び出される **load** メソッドは、このセクションでこの後定義する DownloadOp の例に含まれていることに注意してください。

[!code-js[uploadFile](./code/backgroundtransfer/download_quickstart/js/main.js#Snippetdownload_quickstart_E)]

3.  これで、返された値の一覧を使って、保留中の操作を再開できます。

## 後処理

Windows 10 の新機能は、アプリが実行されていない場合でも、バックグラウンド転送の完了時にアプリケーション コードを実行できる機能です。 たとえば、アプリが開始されるたびに新しいムービーをスキャンするのではなく、ムービーのダウンロードが完了した後で利用可能な映画の一覧を更新できます。 または、アプリでファイル転送が失敗した場合に、別のサーバーまたはポートを使ってもう一度転送し直すことができます。 後処理は成功した転送と失敗した転送の両方で呼び出されるため、これを使って、カスタム エラー処理と再試行ロジックを実装できます。

後処理では、既存のバックグラウンド タスク インフラストラクチャを使います。 転送を開始する前に、バックグラウンド タスクを作成して転送に関連付けます。 転送はバックグラウンドで実行され、完了時にバックグラウンド タスクが呼び出されて後処理が実行されます。

後処理では、[**BackgroundTransferCompletionGroup**](https://msdn.microsoft.com/library/windows/apps/dn804209) という新しいクラスを使います。 このクラスは、バックグラウンド タスクをグループ化できるという点で既存の [**BackgroundTransferGroup**](https://msdn.microsoft.com/library/windows/apps/dn279030) に似ていますが、**BackgroundTransferCompletionGroup** には、転送の完了時に実行するバックグラウンド タスクを指定できる機能が追加されています。

後処理があるバックグラウンド転送は、次のように開始します。

1.  [
            **BackgroundTransferCompletionGroup**](https://msdn.microsoft.com/library/windows/apps/dn804209) オブジェクトを作成します。 続けて、[**BackgroundTaskBuilder**](https://msdn.microsoft.com/library/windows/apps/br224768) オブジェクトを作成します。 ビルダー オブジェクトの **Trigger** プロパティを完了グループ オブジェクトに設定し、ビルダーの **TaskEngtyPoint** プロパティを、転送完了時に実行する必要があるバックグラウンド タスクのエントリ ポイントに設定します。 最後に、[**BackgroundTaskBuilder.Register**](https://msdn.microsoft.com/library/windows/apps/br224772) メソッドを呼び出してバックグラウンド タスクを登録します。 複数の完了グループで 1 つのバックグラウンド タスクのエントリ ポイントを共有できますが、バックグラウンド タスクの登録では 1 つの完了グループのみ指定できることに注意してください。

   ```csharp
    var completionGroup = new BackgroundTransferCompletionGroup();
    BackgroundTaskBuilder builder = new BackgroundTaskBuilder();

    builder.Name = "MyDownloadProcessingTask";
    builder.SetTrigger(completionGroup.Trigger);
    builder.TaskEntryPoint = "Tasks.BackgroundDownloadProcessingTask";

    BackgroundTaskRegistration downloadProcessingTask = builder.Register();
    ```

2.  Next you associate background transfers with the completion group. Once all transfers are created, enable the completion group.

   ```csharp
    BackgroundDownloader downloader = new BackgroundDownloader(completionGroup);
    DownloadOperation download = downloader.CreateDownload(uri, file);
    Task<DownloadOperation> startTask = download.StartAsync().AsTask();

    // App still sees the normal completion path
    startTask.ContinueWith(ForegroundCompletionHandler);

    // Do not enable the CompletionGroup until after all downloads are created.
    downloader.CompletinGroup.Enable();
    ```

3.  The code in the background task extracts the list of operations from the trigger details, and your code can then inspect the details for each operation and perform appropriate post-processing for each operation.

   ```csharp
    public class BackgroundDownloadProcessingTask : IBackgroundTask
    {
      public async void Run(IBackgroundTaskInstance taskInstance)
      {
        var details = (BackgroundTransferCompletionGroupTriggerDetails)taskInstance.TriggerDetails;
        IReadOnlyList<DownloadOperation> downloads = details.Downloads;

        // Do post-processing on each finished operation in the list of downloads
      }
    }
    ```

The post-processing task is a regular background task. It is part of the pool of all background tasks, and it is subject to the same resource management policy as all background tasks.

Also, note that post-processing does not replace foreground completion handlers. If your app defines a foreground completion handler, and your app is running when the file transfer completes, then both your foreground completion handler and your background completion handler will be called. The order in which foreground and background tasks are called is not guaranteed. If you define both, you should ensure that the two tasks will work properly and not interfere with each other if they are running concurrently.

## Request timeouts

There are two primary connection timeout scenarios to take into consideration:

-   When establishing a new connection for a transfer, the connection request is aborted if it is not established within five minutes.

-   After a connection has been established, an HTTP request message that has not received a response within two minutes is aborted.

> **Note**  In either scenario, assuming there is Internet connectivity, Background Transfer will retry a request up to three times automatically. In the event Internet connectivity is not detected, additional requests will wait until it is.

## Debugging guidance

Stopping a debugging session in Microsoft Visual Studio is comparable to closing your app; PUT uploads are paused and POST uploads are terminated. Even while debugging, your app should enumerate and then restart or cancel any persisted uploads. For example, you can have your app cancel enumerated persisted upload operations at app startup if there is no interest in previous operations for that debug session.

While enumerating downloads/uploads on app startup during a debug session, you can have your app cancel them if there is no interest in previous operations for that debug session. Note that if there are Visual Studio project updates, like changes to the app manifest, and the app is uninstalled and re-deployed, [**GetCurrentUploadsAsync**](https://msdn.microsoft.com/library/windows/apps/hh701149) cannot enumerate operations created using the previous app deployment.

When using Background Transfer during development, you may get into a situation where the internal caches of active and completed transfer operations can get out of sync. This may result in the inability to start new transfer operations or interact with existing operations and [**BackgroundTransferGroup**](https://msdn.microsoft.com/library/windows/apps/dn279030) objects. In some cases, attempting to interact with existing operations may trigger a crash. This result can occur if the [**TransferBehavior**](https://msdn.microsoft.com/library/windows/apps/dn279033) property is set to **Parallel**. This issue occurs only in certain scenarios during development and is not applicable to end users of your app.

Four scenarios using Visual Studio can cause this issue.

-   You create a new project with the same app name as an existing project, but a different language (from C++ to C#, for example).
-   You change the target architecture (from x86 to x64, for example) in an existing project.
-   You change the culture (from neutral to en-US, for example) in an existing project.
-   You add or remove a capability in the package manifest (adding **Enterprise Authentication**, for example) in an existing project.

Regular app servicing, including manifest updates which add or remove capabilities, do not trigger this issue on end user deployments of your app.
To work around this issue, completely uninstall all versions of the app and re-deploy with the new language, architecture, culture, or capability. This can be done via the **Start** screen or using PowerShell and the **Remove-AppxPackage** cmdlet.

## Exceptions in Windows.Networking.BackgroundTransfer

An exception is thrown when an invalid string for a the Uniform Resource Identifier (URI) is passed to the constructor for the [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) object.

**.NET:  **The [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998) type appears as [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx) in C# and VB.

In C# and Visual Basic, this error can be avoided by using the [**System.Uri**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.aspx) class in the .NET 4.5 and one of the [**System.Uri.TryCreate**](https://msdn.microsoft.com/library/windows/apps/xaml/system.uri.trycreate.aspx) methods to test the string received from the app user before the URI is constructed.

In C++, there is no method to try and parse a string to a URI. If an app gets input from the user for the [**Windows.Foundation.Uri**](https://msdn.microsoft.com/library/windows/apps/br225998), the constructor should be in a try/catch block. If an exception is thrown, the app can notify the user and request a new hostname.

The [**Windows.Networking.backgroundTransfer**](https://msdn.microsoft.com/library/windows/apps/br207242) namespace has convenient helper methods and uses enumerations in the [**Windows.Networking.Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) namespace for handling errors. This can be useful for handling specific network exceptions differently in your app.

An error encountered on an asynchronous method in the [**Windows.Networking.backgroundTransfer**](https://msdn.microsoft.com/library/windows/apps/br207242) namespace is returned as an **HRESULT** value. The [**BackgroundTransferError.GetStatus**](https://msdn.microsoft.com/library/windows/apps/hh701093) method is used to convert a network error from a background transfer operation to a [**WebErrorStatus**](https://msdn.microsoft.com/library/windows/apps/hh747818) enumeration value. Most of the **WebErrorStatus** enumeration values correspond to an error returned by the native HTTP or FTP client operation. An app can filter on specific **WebErrorStatus** enumeration values to modify app behavior depending on the cause of the exception.

For parameter validation errors, an app can also use the **HRESULT** from the exception to learn more detailed information on the error that caused the exception. Possible **HRESULT** values are listed in the *Winerror.h* header file. For most parameter validation errors, the **HRESULT** returned is **E\_INVALIDARG**.



<!--HONumber=Mar16_HO1-->


