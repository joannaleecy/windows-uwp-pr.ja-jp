---
author: awkoren
Description: 'このトピックでは、データ転送に関連する最も一般的なエンタープライズ データ保護 (EDP) シナリオのいくつかを実現するために必要なコード作成タスクの例を示します。'
MS-HAID: 'dev\_app\_to\_app.use\_edp\_to\_protect\_enterprise\_data\_transferred\_between\_apps'
MSHAttr: 'PreferredLib:/library/windows/apps'
Search.Product: eADQiWindows 10XVcnh
title: EDP を使ったアプリ間で転送されるエンタープライズ データの保護
---

# EDP を使ったアプリ間で転送されるエンタープライズ データの保護

__注__ Windows 10 バージョン 1511 (ビルド 10586) またはそれ以前のバージョンでは、エンタープライズ データ保護 (EDP) ポリシーを適用できません。

このトピックでは、データ転送に関連する最も一般的なエンタープライズ データ保護 (EDP) シナリオのいくつかを実現するために必要なコード作成タスクの例を示します。 EDP が、ファイル、ストリーム、クリップボード、ネットワーク、バックグラウンド タスク、ロックの背後でのデータ保護とどのように関係するかに関する開発者向けの詳しい情報については、「[エンタープライズ データ保護 (EDP)](../enterprise/edp-hub.md)」をご覧ください。

**注**  このトピックで説明されているシナリオの多くは、[エンタープライズ データ保護 (EDP) のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)にも含まれています。

## 前提条件


-   **EDP の設定を行う**

    「[EDP のためのコンピューターの設定](../enterprise/edp-hub.md#set-up-your-computer-for-EDP)」をご覧ください。

-   **エンタープライズ対応アプリの作成に取り組む**

    企業データがそれを管理する企業の制御下に置かれている状態が自律的に確保されるアプリをエンタープライズ対応アプリと呼びます。 対応アプリは非対応アプリより強力かつスマートで、柔軟性と信頼性の面でもより優れています。 アプリが対応アプリであることをシステムに知らせるには、制限された **enterpriseDataPolicy** 機能を宣言します。 ただし、アプリを対応アプリにするために必要なことは機能の設定だけではありません。 詳しくは、「[エンタープライズ対応アプリ](../enterprise/edp-hub.md#enterprise-enlightened-apps)」をご覧ください。

-   **ユニバーサル Windows プラットフォーム (UWP) アプリの非同期プログラミングについての理解**

    C\# や Visual Basic での非同期アプリの作成方法については、「[C\# または Visual Basic での非同期 API の呼び出し](https://msdn.microsoft.com/library/windows/apps/mt187337)」をご覧ください。 C++ での非同期アプリの作成方法については、「[C++ での非同期プログラミング](https://msdn.microsoft.com/library/windows/apps/mt187334)」をご覧ください。

## 単純なクリップボード ソース


このシナリオでは、アプリは、個人用ファイルと企業用ファイルの両方を処理するメモ帳タイプのアプリです。 この場合、アプリでコピーと貼り付けのロジックを一切変更する必要はありません。ユーザーがエンタープライズ ドキュメントを開いて、そのコンテンツを表示するときに、常に [**ProtectionPolicyManager.TryApplyProcessUIPolicy**](https://msdn.microsoft.com/library/windows/apps/dn705791) を呼び出すだけで済みます。 アプリの UI でコンテンツが表示されたら、ユーザーは内容をコピーして別のアプリに貼り付ける可能性があります。このため、UI ポリシーを設定することが重要になります。 これにより、オペレーティング システムは、保護されているデータに関連する貼り付け操作に対して、現在設定されているポリシーを適用できます。 また、ユーザーがもう一度個人データを自由にコピーして貼り付けることができるように、不要になった UI ポリシーをすぐにクリアすることが重要です。 **TryApplyProcessUIPolicy** は、その identity 引数がエンタープライズ ポリシーによって管理されていない場合、false を返します。

```CSharp
using Windows.Security.EnterpriseData;

...

private void OnFileLoaded(FileProtectionInfo fileProtectionInfo, string contentsOfFile)
{
    if (fileProtectionInfo.Status == FileProtectionStatus.Protected)
    {
        bool isIdentityManaged = ProtectionPolicyManager.TryApplyProcessUIPolicy
            (fileProtectionInfo.Identity);
        if (isIdentityManaged)
        {
            // UI policy is now in effect for the file's identity.
        }
        else
        {
            // Enterprise policy is not in effect, because the file's identity
            // is not managed. In this case, we have a file protected to an
            // unmanaged identity, which is not a valid situation.
            // We still have to call ClearProcessUIPolicy if we want to clear the policy.
            ProtectionPolicyManager.ClearProcessUIPolicy();
        }
    }
    else
    {
        // In case we applied the policy for the previous file, now we need to clear it.
        ProtectionPolicyManager.ClearProcessUIPolicy();
    }
    // Code goes here to display "contentsOfFile" in your UI. Ready for copy-paste...
}
```

## 単純なクリップボード ターゲット


このシナリオでは、アプリは、個人アカウントと企業アカウントの両方を処理するメール アプリです。 ユーザーは、個人のアカウントを使って、メールの返信にデータを貼り付けようとします。 この場合、アプリは、内容を取得する前に、[**DataPackage.RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706636) を呼び出すだけで済みます。 既にアクセス権がある場合、このメソッドは直ちに制御を戻します。 ただし、アクセス権がない場合、このメソッドはユーザーに同意を求めるダイアログを表示し、同意が得られた場合はデータ パッケージの "ロックを解除" します。 これにより、誤って行われた貼り付け操作を取り消す機会をユーザーに提供します。

```CSharp
using Windows.ApplicationModel.DataTransfer;

...

private async void OnPasteSimple()
{
    DataPackageView dataPackageView = Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        // In case we don't already have acccess, request consent from the user
        // for us to access the clipboard data.
        await dataPackageView.RequestAccessAsync();

        try
        {
            string contentsOfClipboard = await dataPackageView.GetTextAsync();
            // Code goes here to insert the text into the email...
        }
        catch (Exception)
        {
            // Code goes here to handle the exception retrieving text from the clipboard.
        }
    }
    else
    {
        // The value on the clipboard is not in the text format.
    }
}
```

## ニュートラルな空のドキュメントであるクリップボード ターゲット


このシナリオでは、アプリはワード プロセッシング アプリです。 新しいドキュメントを作成した後、ドキュメントが空のままである限り、アプリはこのドキュメントをニュートラル (エンタープライズと個人のどちらのドキュメントでもない) として処理します。 次に、ユーザーはこのニュートラル コンテキスト ドキュメントにエンタープライズ データを貼り付けます。 ドキュメントはニュートラル コンテキストであるため、実際には、ドキュメントをエンタープライズ コンテキストに切り替えることで、[**DataPackage.RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706636) の呼び出しを完全に回避できます (この場合、ダイアログの表示は必要ではないため)。 そのため、データが保護されている場合は、エンタープライズ コンテキストに切り替えて、データを貼り付けるだけです。

```CSharp
using Windows.ApplicationModel.DataTransfer;

...

private async void OnPasteWithApplyPolicy()
{
    DataPackageView dataPackageView = Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        // If the data has no enterprise identity, then we already have access.
        if (!string.IsNullOrEmpty(dataPackageView.Properties.EnterpriseId))
        {
            ProtectionPolicyEvaluationResult policyResult =
                await dataPackageView.RequestAccessAsync(dataPackageView.Properties.EnterpriseId);
            if (this.isNewEmptyDocument &&
                policyResult == ProtectionPolicyEvaluationResult.Allowed)
            {
                // If this is a new and empty document, and we're allowed to access
                // the data, then we can avoid popping the consent dialog.
                bool isIdentityManaged = ProtectionPolicyManager.TryApplyProcessUIPolicy(dataPackageView.Properties.EnterpriseId);
                // You can use "isIdentityManaged", but it's not necessary.
            }
            else
            {
                // In this case, we can't optimize the workflow, so we just
                // request consent from the user in this case.
                await dataPackageView.RequestAccessAsync();
            }
        }

        try
        {
            string contentsOfClipboard = await dataPackageView.GetTextAsync();
            // Code goes here to insert the text into the email...
        }
        catch (Exception)
        {
            // Code goes here to handle the exception retrieving text from the clipboard.
        }
    }
    else
    {
        // The value on the clipboard is not in the text format.
    }
}
```

## 明示的なエンタープライズ ID を含むクリップボード ソース


このシナリオでは、アプリはワード プロセッシング アプリです。 このアプリは、バック グラウンド スレッドを使って、ユーザーによるコピー操作をコミットします。 ユーザーは、エンタープライズ ファイルから一部のデータをコピーし、すぐに個人用ファイルに切り替えます。その時点で、アプリのグローバル コンテキストが個人に切り替わります。 この時点で (グローバル状態が変更され、使用が禁止されるため)、アプリのバック グラウンド スレッドはクリップボードに対して、受信データがエンタープライズであることを明示的に通知する必要があります。 この処理を実行するには、[**DataPackagePropertySet.EnterpriseId**](https://msdn.microsoft.com/library/windows/apps/dn913861) プロパティを設定します。

```CSharp
using Windows.ApplicationModel.DataTransfer;

...

private void CopyToClipboard(string stringToCopy, string identity)
{
    // Copy the string to the clipboard.
    var dataPackage = new DataPackage();
    dataPackage.SetText(stringToCopy);
    dataPackage.Properties.EnterpriseId = identity;
    Clipboard.SetContent(dataPackage);
}
```

## エンタープライズ ID を使って特定のウィンドウにタグ付け


このシナリオでは、アプリは複数のウィンドウで複数のドキュメントを処理するワード プロセッシング アプリで、ドキュメントの一部はエンタープライズ ドキュメントであり、一部は個人ドキュメントです。 アプリでは、個人ドキュメントのウィンドウに貼り付けられるデータが正しく検査され (つまり、エンタープライズ データである場合は拒否または許可され)、エンタープライズ ドキュメントのウィンドウから送信されるデータは正しくマークされていることを確認する必要があります。 この処理を実行するには、[**ProtectionPolicyManager.Identity**](https://msdn.microsoft.com/library/windows/apps/dn705785) プロパティを設定します。

```CSharp
using Windows.Security.EnterpriseData;

...

private void TagCurrentViewWithEnterpriseId(string identity)
{
    ProtectionPolicyManager.GetForCurrentView().Identity = identity;
}
```

## エンタープライズ ID を使って出力方向のドラッグ オブジェクトにタグ付け


アプリでは、個人用ウィンドウが開き、ドラッグ可能なエンタープライズ コンテンツが表示されます。 ユーザーがこのコンテンツの一部のドラッグを開始したときに、アプリはコンテンツがエンタープライズとしてマークされていることを確認する必要があります。 このシナリオでは、新しい API は使用されません。 このシナリオでは、アプリは [**DataPackagePropertySet.EnterpriseId**](https://msdn.microsoft.com/library/windows/apps/dn913861) プロパティを設定します (上記の[明示的なエンタープライズ ID を含むクリップボード ソースに関するシナリオ](#clipboard_source_explicit_id)をご覧ください)。

## 受信したドラッグ オブジェクトのエンタープライズ ID の照会


アプリで新しい空のドキュメントを開きます。このドキュメントは、空である限りニュートラルであると見なされます。ユーザーがこのドキュメントにコンテンツをドラッグ アンド ドロップします。 このとき、アプリは、オブジェクトのエンタープライズ ID に応じてドキュメントの状態を変更するために、エンタープライズ ID を特定する必要があります。 このシナリオでは、アプリは [**DataPackagePropertySet.EnterpriseId**](https://msdn.microsoft.com/library/windows/apps/dn913861) を読み取ることによって、データ パッケージから **EnterpriseId** プロパティを取得します (上記の[明示的なエンタープライズ ID を含むクリップボード ソースに関するシナリオ](#clipboard_source_explicit_id)をご覧ください)。

## 共有コントラクト ソースとしてのアプリ


アプリで共有コントラクトをサポートする場合、共有ソースをセットアップするには、このコード例に示すように、[**DataPackage**](https://msdn.microsoft.com/library/windows/apps/br205873) でエンタープライズ ID コンテキストを設定します。

**注**  このコード例では、保護ポリシー マネージャー オブジェクトで、現在のビューについて既に ID を設定していることを前提としています (「[エンタープライズ ID を使って特定のウィンドウにタグ付け](#tag_window_with_id)」をご覧ください)。それ以外の場合、[**ProtectionPolicyManager.Identity**](https://msdn.microsoft.com/library/windows/apps/dn705785) プロパティには空の文字列が格納されます。



```CSharp
using Windows.ApplicationModel.DataTransfer;
using Windows.Security.EnterpriseData;

...

private void OnShareSourceOperation(object sender, RoutedEventArgs e)
{
    // Register the current page as a share source (or you could do this earlier in your app).
    DataTransferManager.GetForCurrentView().DataRequested += OnDataRequested;
    DataTransferManager.ShowShareUI();
}

private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
{
    if (!string.IsNullOrEmpty(this.shareSourceContent))
    {
        var protectionPolicyManager = ProtectionPolicyManager.GetForCurrentView();
        DataPackage requestData = args.Request.Data;
        requestData.Properties.Title = this.shareSourceTitle;
        requestData.Properties.EnterpriseId = protectionPolicyManager.Identity;
        requestData.SetText(this.shareSourceContent);
    }
}
```

## 共有コントラクト ターゲットとしてのアプリ


次のコード例でも、作業対象のファイルが空である限り、これまでのポリシーを引き続き使用します。 これにより、受信データに合わせて自由にコンテキストを切り替えることができ、可能な限り同意 UI の表示を回避することができます。 そのため、アプリが共有コントラクトのターゲットとしてデータを受け取ったときに、既存のコンテンツがない場合は [**ProtectionPolicyManager.TryApplyProcessUIPolicy**](https://msdn.microsoft.com/library/windows/apps/dn705791) を呼び出す必要があります。それ以外の場合は [**DataPackage.RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706636) を呼び出す必要があります。 コード例でこの方法を示します。

```CSharp
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;

...

string identity = "microsoft.com";

protected override async void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
{
    ShareOperation shareOperation = args.ShareOperation;
    if (shareOperation.Data.Contains(StandardDataFormats.Text))
    {
        // If the data has no enterprise identity, then we already have access.
        if (!string.IsNullOrEmpty(shareOperation.Data.Properties.EnterpriseId))
        {
            ProtectionPolicyEvaluationResult protectionPolicyEvaluationResult =
                await ProtectionPolicyManager.RequestAccessAsync
                    (shareOperation.Data.Properties.EnterpriseId, identity);
            if (this.isNewEmptyDocument && protectionPolicyEvaluationResult ==
                ProtectionPolicyEvaluationResult.Allowed)
            {
                // If this is a new and empty document, and we're allowed to access
                // the data, then we can avoid popping the consent dialog.
                bool isIdentityManaged = ProtectionPolicyManager.TryApplyProcessUIPolicy
                    (shareOperation.Data.Properties.EnterpriseId);
                // You can use "isIdentityManaged", but it';s not necessary.
            }
            else
            {
                // In this case, we can't optimize the workflow, so we just
                // request consent from the user in this case.
                protectionPolicyEvaluationResult = await shareOperation.Data.RequestAccessAsync();
            }
        }

        try
        {
            // Get the text from the share operation...
            App.shareTargetContent = await shareOperation.Data.GetTextAsync();
        }
        catch (Exception)
        {
            // Code goes here to handle the exception retrieving text from the share operation.
        }
    }
    else
    {
        // The value in the share operation is not in the text format.
    }
}
```

## コピー/貼り付けのポリシーを受動的に照会


このシナリオでは、アプリは、クリップボードにデータがある場合にのみ貼り付けの UI を有効にします。 この機能では、[**ProtectionPolicyManager.CheckAccess**](https://msdn.microsoft.com/library/windows/apps/dn705783) メソッドを使います。これにより、ポリシーの受動的なチェックを実行できます。

**注**  このコード例では、保護ポリシー マネージャー オブジェクトで、現在のビューについて既に ID を設定していることを前提としています (「[エンタープライズ ID を使って特定のウィンドウにタグ付け](#tag_window_with_id)」をご覧ください)。それ以外の場合、[**ProtectionPolicyManager.Identity**](https://msdn.microsoft.com/library/windows/apps/dn705785) プロパティには空の文字列が格納されます。



```CSharp
using Windows.ApplicationModel.DataTransfer;
using Windows.Security.EnterpriseData;

...

private bool IsClipboardPeekAllowedAsync()
{
    ProtectionPolicyEvaluationResult protectionPolicyEvaluationResult = ProtectionPolicyEvaluationResult.Blocked;
    DataPackageView dataPackageView = Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        protectionPolicyEvaluationResult =
            ProtectionPolicyManager.CheckAccess(dataPackageView.Properties.EnterpriseId,
                ProtectionPolicyManager.GetForCurrentView().Identity);
    }

    // Since this is a convenience feature to allow a peek of clipboard content,
    // if state is Blocked or ConsentRequired, do not show peek if this helper
    // method returns false.
    return (protectionPolicyEvaluationResult == ProtectionPolicyEvaluationResult.Allowed);
}
```

## コピー/貼り付け操作のアクセス権の要求


このシナリオでは、貼り付け操作に対するアクセス権を確認する方法を示します。

**注**  このコード例では、保護ポリシー マネージャー オブジェクトで、現在のビューについて既に ID を設定していることを前提としています (「[エンタープライズ ID を使って特定のウィンドウにタグ付け](#tag_window_with_id)」をご覧ください)。それ以外の場合、[**ProtectionPolicyManager.Identity**](https://msdn.microsoft.com/library/windows/apps/dn705785) プロパティには空の文字列が格納されます。



```CSharp
using Windows.ApplicationModel.DataTransfer;
using Windows.Security.EnterpriseData;

...

private async void OnPasteWithRequestAccess()
{
    DataPackageView dataPackageView = Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        ProtectionPolicyEvaluationResult protectionPolicyEvaluationResult =
            ProtectionPolicyManager.CheckAccess(dataPackageView.Properties.EnterpriseId,
                ProtectionPolicyManager.GetForCurrentView().Identity);

        if (protectionPolicyEvaluationResult == ProtectionPolicyEvaluationResult.Allowed)
        {
            try
            {
                string contentsOfClipboard = await dataPackageView.GetTextAsync();
                // Code goes here to insert the text into the app...
                this.fileContentsTextBox.Text = contentsOfClipboard;
            }
            catch (Exception)
            {
                // Code goes here to handle the exception retrieving text from the clipboard.
            }
        }
        else
        {
            // Paste from the enterprise context is not allowed by policy.
        }
    }
    else
    {
        // The value on the clipboard is not in the text format.
    }
}
```

**注:** この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。



## 関連トピック


[エンタープライズ データ保護 (EDP) のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)

[**Windows.Security.EnterpriseData 名前空間**](https://msdn.microsoft.com/library/windows/apps/dn279153)







<!--HONumber=May16_HO2-->


