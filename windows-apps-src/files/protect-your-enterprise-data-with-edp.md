---
author: TylerMSFT
Description: "このトピックでは、ファイルに関連する最も一般的なエンタープライズ データ保護 (EDP) シナリオのいくつかを実現するために必要なコード作成タスクの例を示します。"
MS-HAID: dev\_files.protect\_your\_enterprise\_data\_with\_edp
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: "企業のデータ保護 (EDP) を使ったファイルの保護"
translationtype: Human Translation
ms.sourcegitcommit: 36bc5dcbefa6b288bf39aea3df42f1031f0b43df
ms.openlocfilehash: 2d9b1ec4e39e5c8a100030184ee9287a0d97ea24

---

# 企業のデータ保護 (EDP) を使ったファイルの保護

__注__ Windows 10 バージョン 1511 (ビルド 10586) またはそれ以前のバージョンでは、エンタープライズ データ保護 (EDP) ポリシーを適用できません。

このトピックでは、ファイルに関連する最も一般的なエンタープライズ データ保護 (EDP) シナリオのいくつかを実現するために必要なコード作成タスクの例を示します。 EDP とファイル、ストリーム、クリップボード、ネットワーク、バックグラウンド タスク、ロックの背後でのデータ保護との関係についての開発者向けの詳しい情報については、「[エンタープライズ データ保護 (EDP)](../enterprise/edp-hub.md)」をご覧ください。

**注**  このトピックで説明されているシナリオの多くは、[エンタープライズ データ保護 (EDP) のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)にも含まれています。

## 前提条件

-   **EDP の設定を行う**

    「[EDP のためのコンピューターの設定](../enterprise/edp-hub.md#set-up-your-computer-for-EDP)」をご覧ください。

-   **エンタープライズ対応アプリの作成に取り組む**

    企業データがそれを管理する企業の制御下に置かれている状態が自律的に確保されるアプリをエンタープライズ対応アプリと呼びます。 対応アプリは非対応アプリより強力かつスマートで、柔軟性と信頼性の面でもより優れています。 アプリが対応アプリであることをシステムに知らせるには、制限された **enterpriseDataPolicy** 機能を宣言します。 ただし、アプリを対応アプリにするために必要なことは機能の設定だけではありません。 詳しくは、「[エンタープライズ対応アプリ](../enterprise/edp-hub.md#enterprise-enlightened-apps)」をご覧ください。

-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C\# や Visual Basic での非同期アプリの作成方法については、「[C\# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

## ローカル フォルダーのパスとエクスプローラーでの保護されたファイルの表示


このトピックのコード例をホストするアプリを作成してコード例を試してみることができます。 これらのコード例は、そのアプリのローカル フォルダーにファイルを書き込みます。そのフォルダーのディスク上の正確な場所はアプリごとに固有です。 アプリのローカル フォルダーの場所を特定するには、次のコードを追加します。

```CSharp
// Put a breakpoint on the line after the line of code below. Use the value of localFolderPath
// in File Explorer to find the output file that the later code examples create.
string localFolderPath = ApplicationData.Current.LocalFolder.Path;
```

このパスがわかると、アプリによって作成されるファイルをエクスプローラーで簡単に見つけられるようになります。 これにより、それらが保護されているかどうか、適切な ID に対して保護されているかどうかを確認できます。

エクスプローラーで、**[フォルダーと検索のオプションの変更]** を選択し、**[表示]** タブで **[Show encrypted files in color]** をオンにします。 また、エクスプローラーの **[表示]** &gt; **[列の追加]** コマンドを使って **[暗号化の所有者]** 列を追加して、ファイルが保護される対象の企業 ID を確認できるようにします。

## 新しいファイルで企業データを保護する (対話型アプリの場合)


企業データはさまざまな方法でアプリに入力されます (特定のネットワーク エンドポイントから、ファイルから、クリップボードから、共有コントラクトからなど)。 アプリで新しい企業データが作成される場合もあります。 企業データが入力された方法に関係なく、対応アプリでそのデータを新しいファイルに保存する際には、管理されている企業 ID に対してそのデータを保護するように注意する必要があります。

基本的な手順では、標準の Storage API を使ってファイルを作成し、EDP API を使ってファイルを企業 ID に対して保護し、(再び標準の Storage API を使って) そのファイルへの書き込みを行います。 書き込みの前にファイルを保護することに注意してください (次の例をご覧ください)。 ファイルを保護するには [**FileProtectionManager.ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/dn705157) メソッドを使います。 また、通常どおり、ID に対する保護が意味をなすのはその ID が管理されている場合だけです。 その理由と、アプリが実行されている企業の ID を特定する方法については、「[ID が管理されていることの確認](../enterprise/edp-hub.md#confirming_an_identity_is_managed)」をご覧ください。

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;

...

private async void SaveEnterpriseDataToFile(string enterpriseData, string identity)
{
    // You should only protect to an identity that is managed.
    if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;

    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
    StorageFile storageFile = storageFolder.CreateFileAsync("sample.txt",
        CreationCollisionOption.ReplaceExisting);

    // It's important to protect a file *before* writing enterprise data to it.
    FileProtectionInfo fileProtectionInfo =
        await FileProtectionManager.ProtectAsync(storageFile, identity);

    // If the file is now protected, to the intended identity, then we can write to it.
    if (fileProtectionInfo.Identity == identity &&
        fileProtectionInfo.Status == FileProtectionStatus.Protected)
        await Windows.Storage.FileIO.WriteTextAsync(storageFile, enterpriseData);
}
```

## 新しいファイルで企業データを保護する (バックグラウンド タスクの場合)


前のセクションで使った [**FileProtectionManager.ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/dn705157) API が適切なのは対話型アプリに対してのみです。 バックグラウンド タスクの場合は、ロック画面の下でコードを実行できます。 また、"ロックの背後でのデータ保護" (DPL) の安全なポリシーが組織で管理されていて、デバイスがロックされているときは、保護されたリソースへのアクセスに必要な暗号化キーが一時的にデバイスのメモリから削除されます。 これにより、デバイスを紛失した場合のデータ漏えいを防ぐことができます。 この機能によって、保護されたファイルのハンドルを閉じたときに、ファイルに関連付けられているキーも削除されます。 ただし、ロック期間 (デバイスがロックされてからロック解除されるまでの時間) 中に保護された新しいファイルを作成し、そのファイル ハンドルを開いている間、それらにアクセスできる場合があります。 **StorageFolder.CreateFileAsync** は、ファイルが作成されるとハンドルを閉じるため、このアルゴリズムは使用できません。

1.  **StorageFolder.CreateFileAsync** を使って新しいファイルを作成します。
2.  **FileProtectionManager.ProtectAsync** を使って暗号化します。
3.  ファイルを開いて、ファイルに書き込みます。

手順 1. でファイル ハンドルを閉じるため (手順 1. でハンドルを閉じない場合でも、手順 2. で閉じられる)、ファイルにアクセスするための暗号化キーは使用できず、手順 3. を実行できません。

このシナリオに対応するには、[**FileProtectionManager.CreateProtectedAndOpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn705153) を使って保護されたファイルを作成し、ファイルへの **IRandomAccessStream** を返します。 これにより、アプリは、ファイル ハンドルを開いたままにしている間、ファイルに複数の書き込みを実行できます。

このコード例では、新しいメールを受信したときに新しいファイルを書き出す単純化されたメール アプリを示します。 メール アプリは、デバイスがロックされているときにメールを同期する必要があります。 このアプリは新しいメールを受信すると、[**CreateProtectedAndOpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn705153) を使って新しいファイルを作成します。次に、出力ストリームを取得し、メール本文を書き込みます。

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;
using Windows.Storage.Streams;

...

private async void SaveEnterpriseDataToFile(string enterpriseData, string identity)
{
    // You should only protect to an identity that is managed.
    if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;

    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

    ProtectedFileCreateResult protectedFileCreateResult =
        await FileProtectionManager.CreateProtectedAndOpenAsync(storageFolder,
            "sample.txt", identity, CreationCollisionOption.ReplaceExisting);

    // It's important to successfully protect a file *before* writing enterprise data to it.
    if (protectedFileCreateResult.ProtectionInfo.Identity == identity &&
        protectedFileCreateResult.ProtectionInfo.Status == FileProtectionStatus.Protected)
    {
        using (IOutputStream outputStream =
            protectedFileCreateResult.Stream.GetOutputStreamAt(0))
        {
            using (DataWriter writer = new DataWriter(outputStream))
            {
                writer.WriteString(enterpriseData);
                await writer.StoreAsync();
                await writer.FlushAsync();
            }
        }
    }
    else if (protectedFileCreateResult.ProtectionInfo.Status == FileProtectionStatus.AccessSuspended)
    {
        // Perform any special processing for the access suspended case.
    }
}
```

## 企業データの格納を目的とするフォルダーを保護する


フォルダー内のすべての項目を保護することもできます。 [
            **FileProtectionManager.ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/dn705157) を使って空のフォルダーを保護します。 これにより、その後にそのフォルダー内に作成されたファイルやフォルダーもすべて保護されるようになります。 既にあるフォルダーを保護することも、新しいフォルダーを作成して保護することもできます (次の例では新しいフォルダーを作成しています)。 ただし、いずれの場合も、保護が適切に行われるためにはフォルダーがその時点で空になっている必要があります。 なっていない場合は、[**FileProtectionInfo.Status**](https://msdn.microsoft.com/library/windows/apps/dn705150) の値が [**FileProtectionStatus.NotProtectable**](https://msdn.microsoft.com/library/windows/apps/dn279147) になります。

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;

...

private async void CreateANewFolderAndProtectItAsync(string folderName, string identity)
{
    if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;

    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
    StorageFolder newStorageFolder =
        await storageFolder.CreateFolderAsync(folderName);

    FileProtectionInfo fileProtectionInfo =
        await FileProtectionManager.ProtectAsync(newStorageFolder, identity);

    if (fileProtectionInfo.Identity != identity ||
        fileProtectionInfo.Status != FileProtectionStatus.Protected)
    {
        // Protection failed.
    }
}
```

## 保護をファイル間でコピーする


このシナリオでは、適切な企業 ID に対して保護されていることがわかっているファイルが既に存在しています。 この場合、その保護を別のファイルに簡単に複製することができます。 ID を把握している必要もありません。適切な ID であることがわかっていればかまいません。

保護されたファイルを単純にコピーするには、[**StorageFile.CopyAsync**](https://msdn.microsoft.com/library/windows/apps/br227190) を呼び出します。 結果のコピーには、オリジナルと同じ保護が適用されます。

既にある保護されていないファイルを、企業データを書き込む前に保護するには、[**FileProtectionManager.ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/dn705157) を呼び出す方法 (前のシナリオで説明したこの方法では、管理されている ID を渡す必要があります) のほかに、次のコード例のように [**FileProtectionManager.CopyProtectionAsync**](https://msdn.microsoft.com/library/windows/apps/dn705152) を呼び出す方法もあります。

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;

...

private async void CopyProtectionFromOneFileToAnother
    (StorageFile sourceStorageFile, StorageFile targetStorageFile)
{
    bool copyResult = await
        FileProtectionManager.CopyProtectionAsync(sourceStorageFile, targetStorageFile);

    if (!copyResult)
    {
        // Copying failed. To diagnose, you could check the file's status.
        // (call FileProtectionManager.GetProtectionInfoAsync and
        // check FileProtectionInfo.Status).
    }
}
```

## 保護したファイルのアクセス拒否を処理する


このシナリオでは、アプリがファイル (以前にアプリで保護したファイル) にアクセスしようとするとアクセスを拒否されます。 この場合は、ファイルの状態を確認して、何が問題かを調べる必要があります。 次のコード例では、アプリで [**FileProtectionManager.GetProtectionInfoAsync**](https://msdn.microsoft.com/library/windows/apps/dn705154) API を呼び出して状態を照会し、リモート管理によってファイルへのアクセスが取り消されたことが原因かどうかを確認しています。

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;

...

private async System.Threading.Tasks.Task<bool> IsFileProtectionStatusRevoked
    (StorageFile storageFile)
{
    FileProtectionInfo fileProtectionInfo =
        await FileProtectionManager.GetProtectionInfoAsync(storageFile);

    if (fileProtectionInfo.Status == FileProtectionStatus.Revoked)
    {
        // Inform the user that their data has been revoked.
    }
    return fileProtectionInfo.Status == FileProtectionStatus.Revoked;
}
```

## ファイルの保護された ID に基づいて UI ポリシーの適用を有効にする


アプリがその UI で保護されたファイル (PDF など) の内容を表示しようとした場合、ファイルが保護されている ID に基づく UI ポリシーの適用を有効にする必要があります。 ファイルの保護の情報を照会して、取得した ID からシステムの UI ポリシーの適用を有効にする必要があります。

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;

...

private async void EnableUIPolicyFromFile(StorageFile storageFile)
{
    FileProtectionInfo fileProtectionInfo = 
        await FileProtectionManager.GetProtectionInfoAsync(storageFile);

    if (fileProtectionInfo.Status != FileProtectionStatus.Protected)
    {
        // No policy enforcement required, unless the file is inaccessible
        // (Revoked, ProtectedToOtherIdentity) in which case that should
        // be handled in an app-specific way.
        return;
    }

    ProtectionPolicyManager.TryApplyProcessUIPolicy(fileProtectionInfo.Identity);
}
```

**注:** この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

 

## 関連トピック


[エンタープライズ データ保護 (EDP) のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)

[**Windows.Security.EnterpriseData 名前空間**](https://msdn.microsoft.com/library/windows/apps/dn279153)

 

 






<!--HONumber=Jun16_HO4-->


