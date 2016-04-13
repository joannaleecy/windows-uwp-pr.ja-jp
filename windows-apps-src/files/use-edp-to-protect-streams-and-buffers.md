---
Description: 'このトピックでは、ストリームとバッファーに関連する最も一般的なエンタープライズ データ保護 (EDP) シナリオのいくつかを実現するために必要なコード作成タスクの例を示します。'
MS-HAID: 'dev\_files.use\_edp\_to\_protect\_streams\_and\_buffers'
MSHAttr: 'PreferredLib:/library/windows/apps'
Search.Product: eADQiWindows 10XVcnh
title: 'エンタープライズ データ保護 (EDP) を使ったストリームとバッファーの保護'
---

# エンタープライズ データ保護 (EDP) を使ったストリームとバッファーの保護

__注__ Windows 10 バージョン 1511 (ビルド 10586) またはそれ以前のバージョンでは、エンタープライズ データ保護 (EDP) ポリシーを適用できません。

このトピックでは、ストリームとバッファーに関連する最も一般的なエンタープライズ データ保護 (EDP) シナリオのいくつかを実現するために必要なコード作成タスクの例を示します。 EDP が、ファイル、ストリーム、クリップボード、ネットワーク、バックグラウンド タスク、ロックの背後でのデータ保護とどのように関係するかに関する開発者向けの詳しい情報については、「[エンタープライズ データ保護 (EDP)](../enterprise/edp-hub.md)」をご覧ください。

**注**  このトピックで説明されているシナリオの多くは、[エンタープライズ データ保護 (EDP) のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)にも含まれています。

## 前提条件


-   **EDP の設定を行う**

    「[EDP のためのコンピューターの設定](../enterprise/edp-hub.md#set-up-your-computer-for-EDP)」をご覧ください。

-   **エンタープライズ対応アプリの作成に取り組む**

    企業データがそれを管理する企業の制御下に置かれている状態が自律的に確保されるアプリをエンタープライズ対応アプリと呼びます。 対応アプリは非対応アプリより強力かつスマートで、柔軟性と信頼性の面でもより優れています。 アプリが対応アプリであることをシステムに知らせるには、制限された **enterpriseDataPolicy** 機能を宣言します。 ただし、アプリを対応アプリにするために必要なことは機能の設定だけではありません。 詳しくは、「[エンタープライズ対応アプリ](../enterprise/edp-hub.md#enterprise-enlightened-apps)」をご覧ください。

-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C\# や Visual Basic での非同期アプリの作成方法については、「[C\# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

## 企業の ID に対するデータ ストリームの保護


**注**  ストリームやバッファーを保護する場合は常に、[**ProtectionPolicyManager.PolicyChanged**](https://msdn.microsoft.com/library/windows/apps/mt608411) イベントを受信登録し、EDP がデバイスで無効になった場合に、アプリで検出できるようにしておくことを強くお勧めします。 この場合、すべてのストリームとバッファーの保護を解除する必要があります。 保護されたままにしたストリームやバッファーは、ユーザーがモバイル デバイス管理 (MDM) からデバイスの登録を解除した場合、失効の対象となります。 また、リソースの作成時に EDP が無効であった場合、その失効は適切ではありません。 EDP が無効であるときはリソースの保護を解除することで、これを防止できます。



このシナリオでは、アプリは、企業のデータが含まれている保護されていないストリームにアクセスできます。 内部と外部デバイスに転送するときに、このストリームが保護されるようにするには、アプリで、データが属している企業の ID へのデータを保護します。 これにより、必要に応じて、企業はデータを消去できます。 後でストリームに対して "Unprotect" メソッドを呼び出すかどうかを判断するには、アプリでストリームが保護されていたかどうかを示す状態を保持する必要があります。このコード例の関数がこの状態を返しているのは、このような理由からです。 渡された ID が管理されていない場合、またはその ID でアプリが許可されていない場合は、ストリームは保護されず、[**DataProtectionManager.ProtectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/dn706021) の呼び出しから "Unprotected" の状態が返されます。

```CSharp
using Windows.Storage.Streams;
using Windows.Security.EnterpriseData;

private async System.Threading.Tasks.Task<bool> ProtectAStream
    (InMemoryRandomAccessStream unprotectedInMemoryRandomAccessStream, string identity,
    InMemoryRandomAccessStream protectedInMemoryRandomAccessStream)
{
    IInputStream unprotectedStream = unprotectedInMemoryRandomAccessStream.GetInputStreamAt(0);
    IOutputStream protectedStream = protectedInMemoryRandomAccessStream.GetOutputStreamAt(0);

    // Protect "inputStream".
    DataProtectionInfo info = 
        await DataProtectionManager.ProtectStreamAsync(unprotectedStream, identity, protectedStream);

    // Indicate to the caller whether the stream was protected successfully. It will only be protected if
    // the identity is managed AND this app is allowed for this identity. Similar to buffers, this status
    // must be stored by the app. UnprotectStreamAsync must only be called if the stream was protected
    // successfully earlier.

    return (info.Status == DataProtectionStatus.Protected);
}
```

前のコード例のメソッドと同様のメソッドを使う方法を示すために、ここでは、メソッドを使って文字列を保護されていないストリームに変換し、そのストリームを保護するヘルパー メソッドを示します。

```CSharp
using Windows.Storage.Streams;

private async System.Threading.Tasks.Task<bool> ProtectStringAsStreamAsync
    (string unprotectedEnterpriseData, string identity, 
    InMemoryRandomAccessStream protectedInMemoryRandomAccessStream)
{
    using (var unprotectedInMemoryRandomAccessStream = new InMemoryRandomAccessStream())
    {
        using (var dataWriter = new DataWriter(unprotectedInMemoryRandomAccessStream))
        {
            dataWriter.WriteString(unprotectedEnterpriseData);
            await dataWriter.StoreAsync();
            await dataWriter.FlushAsync();
            return await this.ProtectAStream(unprotectedInMemoryRandomAccessStream,
                identity, protectedInMemoryRandomAccessStream);
        }
    }
}
```

## ストリームの状態の取得


このシナリオでは、アプリが以前にストリームを保護しており、そのストリームへの未承認のアクセスを禁止している必要があります。 必要なときに、ストリームの内容を取得するために、アプリでストリームの状態を確認できます。

ストリームの状態は、[**DataProtectionManager.UnprotectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/dn706023) からも返されることに注意してください。 この API は、入力ソースが保護されていることを必要とするため、"Unprotected" の状態を返すことはありません (リソースが保護されていないことを、信頼性の高い方法で確認することはできません)。 結果を "Unprotected" と比較するコードがある場合、設計上の欠陥が存在することを示している可能性があるため注意してください。 これは、コードでストリームが保護されているかどうかを追跡できなくなったことを意味しています。

```CSharp
using Windows.Storage.Streams;
using Windows.Security.EnterpriseData;

private async void CheckProtectedStreamStatus(IInputStream protectedStream)
{
    DataProtectionInfo dataProtectionInfo = 
        await DataProtectionManager.GetStreamProtectionInfoAsync(protectedStream);

    if (dataProtectionInfo.Status == DataProtectionStatus.Revoked)
    {
        // Code goes here to handle this situation. Perhaps, show UI
        // saying that the user's data has been revoked.
    }
    else if (dataProtectionInfo.Status != DataProtectionStatus.Protected)
    {
        // Code goes here to handle the unexpected protection status.
    }
}
```

## データ ストリームの保護の解除


このシナリオでは、アプリで以前に保護していたストリームの保護を解除しようとしています。 次のコード例は、保護されたストリーム (このプロセスが機能するには、ストリームが保護されている必要があります) を受け取り、[**DataProtectionManager.UnprotectStreamAsync**](https://msdn.microsoft.com/library/windows/apps/dn706023) を呼び出してその保護を解除します。 次に、ストリームからの文字列を読み取って、その文字列を返します。

```CSharp
using Windows.Storage.Streams;

private async System.Threading.Tasks.Task<string> UnprotectStreamIntoStringAsync
    (InMemoryRandomAccessStream protectedInMemoryRandomAccessStream)
{
    using (var unprotectedInMemoryRandomAccessStream = new InMemoryRandomAccessStream())
    {
        DataProtectionInfo dataProtectionInfo = 
            await DataProtectionManager.UnprotectStreamAsync(protectedInMemoryRandomAccessStream, 
            unprotectedInMemoryRandomAccessStream);

        using (var inputStream = unprotectedInMemoryRandomAccessStream.GetInputStreamAt(0))
        {
            using (var dataReader = new DataReader(inputStream))
            {
                await dataReader.LoadAsync((uint)unprotectedInMemoryRandomAccessStream.Size);
                return dataReader.ReadString((uint)unprotectedInMemoryRandomAccessStream.Size);
            }
        }
    }
}
```

これまでに示したヘルパー メソッドの使い方を示すために、ここではイベント ハンドラーを使って、テキスト ボックスから文字列を受け取る、文字列をストリームに書き込む、ストリームを保護する、ストリームの保護を解除する (ストリームが正常に保護されていた場合)、そして最後に、保護が解除されたストリームから文字列を読み取って UI に表示するという処理を行います。

```CSharp
using Windows.Storage.Streams;

private async void ProtectAndThenUnprotectStream_Click(object sender, RoutedEventArgs e)
{
    var protectedInMemoryRandomAccessStream = new InMemoryRandomAccessStream();
    bool isStreamProtected = await this.ProtectStringAsStreamAsync
        (this.enterpriseDataTextBox.Text, MainPage.IDENTITY, protectedInMemoryRandomAccessStream);

    // Only unprotect the stream if we're sure that the stream actually was protected.
    if (isStreamProtected)
    {
        this.resultDataTextBlock.Text = 
            await this.UnprotectStreamIntoStringAsync(protectedInMemoryRandomAccessStream);
    }
}
```

## 静的データ バッファーの状態の取得


このシナリオでは、アプリが以前にバッファーを保護しており、そのバッファーへの未承認のアクセスを禁止している必要があります。 必要なときに、バッファーの内容を取得するために、アプリでバッファーの状態を確認できます。

バッファーの状態は、[**DataProtectionManager.UnprotectAsync**](https://msdn.microsoft.com/library/windows/apps/dn706022) からも返されることに注意してください。 この API は、入力ソースが保護されていることを必要とするため、"Unprotected" の状態を返すことはありません。

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage.Streams;

private async void CheckProtectedBufferStatus(IBuffer protectedData)
{
    DataProtectionInfo dataProtectionInfo = 
        await DataProtectionManager.GetProtectionInfoAsync(protectedData);

    if (dataProtectionInfo.Status == DataProtectionStatus.Revoked)
    {
        // Code goes here to handle this situation, perhaps show UI
        // saying that the user's data has been revoked.
    }
    else if (dataProtectionInfo.Status != DataProtectionStatus.Protected)
    {
        // Code goes here to handle the unexpected protection status.
    }
}
```

## エンタープライズ リソースから取得した静的なデータの保護


このシナリオは、データのバッファーを処理する点を除き、ストリームのコード例と基本的に同じです。 ここでも、バッファーが保護されていたかどうかを示す状態を維持する必要があります。 渡された ID が管理されていない場合、またはその ID でアプリが許可されていない場合は、バッファーは保護されず、[**DataProtectionManager.ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/dn706020) の呼び出しから "Unprotected" の状態が返されます。

```CSharp
using Windows.Security.Cryptography;
using Windows.Security.EnterpriseData;
using Windows.Storage.Streams;

...

private IBuffer data = null;
private bool isProtected = false;

void StoreBuffer(IBuffer data, bool isProtected)
{
    this.data = data;
    this.isProtected = isProtected;
}

IBuffer GetStoredBuffer(out bool isProtected)
{
    isProtected = this.isProtected;
    return this.data;
}

private string identity = "contoso.com";

private async void ProtectAndThenUnprotectBuffer_Click(object sender, RoutedEventArgs e)
{
    BinaryStringEncoding encoding = BinaryStringEncoding.Utf8;
    IBuffer inputData = CryptographicBuffer.ConvertStringToBinary
        (this.enterpriseDataTextBox.Text, encoding);
    BufferProtectUnprotectResult result =
        await DataProtectionManager.ProtectAsync(inputData, this.identity);

    // Record whether the buffer was protected successfully. It will only be protected if
    // the identity is managed AND this app is allowed for this identity. This status
    // must be stored by the app. UnprotectAsync must only be called if the buffer was
    // protected successfully earlier.
    bool isBufferProtected = 
        (result.ProtectionInfo.Status == DataProtectionStatus.Protected);
    IBuffer outputData = result.Buffer;

    // Store the data away...
    this.StoreBuffer(outputData, isBufferProtected);

    // ...and then later retrieve it.
    outputData = this.GetStoredBuffer(out isBufferProtected);

    string storedString = string.Empty;

    if (isBufferProtected)
    {
        result = await DataProtectionManager.UnprotectAsync(outputData);

        if (result.ProtectionInfo.Status != DataProtectionStatus.Unprotected)
        {
            // Code goes here to handle the situation where the buffer
            // is no longer accessible.
            return;
        }
        outputData = result.Buffer;
    }
    this.resultDataTextBlock.Text = CryptographicBuffer.ConvertBinaryToString(encoding, outputData);
}
```

## ストリームやバッファーの保護された ID に基づいて UI ポリシーの適用を有効にする


アプリがその UI で保護されたストリームやバッファーの内容を表示しようとした場合、リソースが保護されている ID に基づいて UI ポリシーの適用を有効にする必要があります。 リソースの保護の情報を照会して、取得した ID からシステムの UI ポリシーの適用を有効にする必要があります。

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage.Streams;

...

private async void EnableUIPolicyFromProtectedBuffer(IBuffer buffer)
{
    DataProtectionInfo protectionInfo = 
        await DataProtectionManager.GetProtectionInfoAsync(buffer);

    if (protectionInfo.Status != DataProtectionStatus.Protected)
    {
        // In this case, the app has lost access to the buffer
        // (ProtectedToOtherIdentity, Revoked). This must be handled.
        // &#39;Unprotected&#39; is never returned for GetProtectionInfoAsync().
        return;
    }

    ProtectionPolicyManager.TryApplyProcessUIPolicy(protectionInfo.Identity);
}

```

**注**  この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

 

## 関連トピック


[エンタープライズ データ保護 (EDP) のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)

[**Windows.Security.EnterpriseData 名前空間**](https://msdn.microsoft.com/library/windows/apps/dn279153)

 

 





<!--HONumber=Mar16_HO5-->


