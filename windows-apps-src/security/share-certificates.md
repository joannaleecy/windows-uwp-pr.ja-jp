---
title: アプリ間での証明書の共有
description: ユーザー ID とパスワードの組み合わせよりも安全な認証を必要とするユニバーサル Windows プラットフォーム (UWP) アプリでは、証明書を認証に使うことができます。
ms.assetid: 159BA284-9FD4-441A-BB45-A00E36A386F9
author: PatrickFarley
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、セキュリティ
ms.localizationpriority: medium
ms.openlocfilehash: 863658438ce53f2c74faddb845a7d17c6ec3130c
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2831546"
---
# <a name="share-certificates-between-apps"></a>アプリ間での証明書の共有




ユーザー ID とパスワードの組み合わせよりも安全な認証を必要とするユニバーサル Windows プラットフォーム (UWP) アプリでは、証明書を認証に使うことができます。 証明書認証は、ユーザーの認証時に高レベルの信頼性を提供します。 場合によっては、複数のアプリから複数のサービスのグループに対してユーザーを認証することがあります。 この記事では、1 つの証明書を使って複数のアプリを認証する方法と、セキュリティで保護された Web サービスにアクセスするための証明書をユーザーがインポートできる便利なコードを記述する方法について説明します。

アプリでは、証明書を使って Web サービスから認証を受けることができます。さらに、複数のアプリで証明書ストアにある 1 つの証明書を使って同じユーザーを認証できます。 証明書がストアに存在しない場合は、PFX ファイルから証明書をインポートするコードをアプリに追加できます。

## <a name="enable-microsoft-internet-information-services-iis-and-client-certificate-mapping"></a>Microsoft インターネット インフォメーション サービス (IIS) とクライアント証明書のマッピングの有効化


この記事では、例を示すために Microsoft インターネット インフォメーション サービス (IIS) を使用します。 IIS は、既定では有効になっていません。 IIS はコントロール パネルから有効にできます。

1.  コントロール パネルを開き、**[プログラム]** を選びます。
2.  **[Windows の機能の有効化または無効化]** を選びます。
3.  **[インターネット インフォメーション サービス]** を展開して、**[World Wide Web サービス]** を展開します。 **[アプリケーション開発機能]** を展開して、**[ASP.NET 3.5]** と **[ASP.NET 4.5]** を選びます。 これらを選ぶと、自動的に **[インターネット インフォメーション サービス]** が有効になります。
4.  **[OK]** をクリックして変更を適用します。

## <a name="create-and-publish-a-secured-web-service"></a>セキュリティで保護された Web サービスの作成と発行


1.  管理者として Microsoft Visual Studio を実行し、スタート ページで **[新しいプロジェクト]** を選びます。 Web サービスを IIS サーバーに発行するには、管理者のアクセス権が必要です。 [新しいプロジェクト] ダイアログで、フレームワークを **[.NET Framework 3.5]** に変更します。 **[Visual C#]** -&gt; **[Web]** -&gt; **[Visual Studio]** -&gt; **[ASP.NET Web サービス アプリケーション]** の順に選びます。 アプリケーションに "FirstContosoBank" という名前を付けます。 **[OK]** をクリックしてプロジェクトを作ります。
2.  **Service1.asmx.cs** ファイルで、既定の **HelloWorld** Web メソッドを次の "Login" メソッドに置き換えます。
    ```cs
            [WebMethod]
            public string Login()
            {
                // Verify certificate with CA
                var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(
                    this.Context.Request.ClientCertificate.Certificate);
                bool test = cert.Verify();
                return test.ToString();
            }
    ```

3.  **Service1.asmx.cs** ファイルを保存します。
4.  **ソリューション エクスプローラー**で、"FirstContosoBank" アプリを右クリックし、**[発行]** をクリックします。
5.  **[Web の発行]** ダイアログで、新しいプロファイルを作って "ContosoProfile" という名前を付けます。 **[次へ]** をクリックします。
6.  次のページで、IIS サーバーのサーバー名を入力し、"Default Web Site/FirstContosoBank" のサイト名を指定します。 **[発行]** をクリックして Web サービスを発行します。

## <a name="configure-your-web-service-to-use-client-certificate-authentication"></a>クライアント証明書認証を使うための Web サービスの構成


1.  **インターネット インフォメーション サービス (IIS) マネージャー**を実行します。
2.  IIS サーバーのサイトを展開します。 **[Default Web Site]** で、新しい "FirstContosoBank" Web サービスを選びます。 **[操作]** セクションで、**[詳細設定]** を選びます。
3.  **[アプリケーション プール]** を **[.NET v2.0]** に設定し、**[OK]** をクリックします。
4.  **インターネット インフォメーション サービス (IIS) マネージャー**で、IIS サーバーを選んで **[サーバー証明書]** をダブルクリックします。 **[操作]** セクションで、**[自己署名入り証明書の作成...]** を選びます。証明書のフレンドリ名として "ContosoBank" と入力し、**[OK]** をクリックします。 これにより、IIS サーバーで使われる新しい証明書が "&lt;サーバー名&gt;.&lt;ドメイン名&gt;" の形式で作成されます。
5.  **インターネット インフォメーション サービス (IIS) マネージャー**で、既定の Web サイトを選びます。 **[操作]** セクションで **[バインド]** を選び、**[追加]** をクリックします。種類として "https" を選び、ポートを "443" に設定して、IIS サーバーの完全なホスト名 ("&lt;サーバー名&gt;.&lt;ドメイン名&gt;") を入力します。 SSL 証明書を "ContosoBank" に設定します。 **[OK]** をクリックします。 **[サイト バインド]** ウィンドウの **[閉じる]** をクリックします。
6.  **インターネット インフォメーション サービス (IIS) マネージャー**で、"FirstContosoBank" Web サービスを選びます。 **[SSL 設定]** をダブルクリックします。 **[SSL が必要]** をオンにします。 **[クライアント証明書]** で **[必要]** を選びます。 **[操作]** セクションで、**[適用]** をクリックします。
7.  Web サービスが正しく構成されたことを確認するには、Web ブラウザーを開き、Web アドレスとして「https://&lt;サーバー名&gt;.&lt;ドメイン名&gt;/FirstContosoBank/Service1.asmx」を入力します。 たとえば、"https://myserver.example.com/FirstContosoBank/Service1.asmx" などです。 Web サービスが正しく構成されていれば、Web サービスにアクセスするためのクライアント証明書を選ぶように求められます。

前の手順を繰り返すことで、同じクライアント証明書を使ってアクセスできる複数の Web サービスを作成できます。

## <a name="create-a-uwp-app-that-uses-certificate-authentication"></a>証明書認証を使う UWP アプリの作成


これでセキュリティで保護された Web サービスが 1 つ以上できたので、証明書を使ってこれらの Web サービスから認証を受けるアプリを作成できます。 [**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) オブジェクトを使って認証 Web サービスへの要求を作成する場合、最初の要求にはクライアント証明書が含まれません。 認証 Web サービスは、応答としてクライアント認証を要求します。 この応答を受け取ると、Windows クライアントは自動的に証明書ストアを照会して、使用できるクライアント証明書を取得します。 ユーザーは、これらの証明書の中から Web サービスへの認証に使うものを選ぶことができます。 証明書によってはパスワードで保護されていることがあるので、証明書のパスワードを入力するための手段をユーザーに提供する必要があります。

使用できるクライアント証明書がない場合は、ユーザーが証明書ストアに証明書を追加する必要があります。 そこで、クライアント証明書の PFX ファイルをユーザーに選んでもらい、その証明書をクライアント証明書ストアにインポートするコードをアプリに含めることができます。

**ヒント** makecert.exe を使うと、このクイック スタートで使うことのできる PFX ファイルを作成できます。 makecert.exe の使い方の詳細については、「[MakeCert](https://msdn.microsoft.com/library/windows/desktop/aa386968)」を参照してください。

 

1.  Visual Studio を開き、スタート ページで新しいプロジェクトを作成します。 新しいプロジェクトに "FirstContosoBankApp" という名前を付けます。 **[OK]** をクリックして新しいプロジェクトを作成します。
2.  MainPage.xaml ファイルで、次の XAML を既定の **Grid** 要素に追加します。 この XAML には、インポートする PFX ファイルを参照するボタン、PFX ファイルがパスワードで保護されている場合にパスワードを入力するテキスト ボックス、選んだ PFX ファイルをインポートするボタン、セキュリティで保護された Web サービスにログインするボタン、現在の操作の状態を表示するテキスト ブロックが含まれています。
    ```xml
    <Button x:Name="Import" Content="Import Certificate (PFX file)" HorizontalAlignment="Left" Margin="352,305,0,0" VerticalAlignment="Top" Height="77" Width="260" Click="Import_Click" FontSize="16"/>
    <Button x:Name="Login" Content="Login" HorizontalAlignment="Left" Margin="611,305,0,0" VerticalAlignment="Top" Height="75" Width="240" Click="Login_Click" FontSize="16"/>
    <TextBlock x:Name="Result" HorizontalAlignment="Left" Margin="355,398,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Height="153" Width="560"/>
    <PasswordBox x:Name="PfxPassword" HorizontalAlignment="Left" Margin="483,271,0,0" VerticalAlignment="Top" Width="229"/>
    <TextBlock HorizontalAlignment="Left" Margin="355,271,0,0" TextWrapping="Wrap" Text="PFX password" VerticalAlignment="Top" FontSize="18" Height="32" Width="123"/>
    <Button x:Name="Browse" Content="Browse for PFX file" HorizontalAlignment="Left" Margin="352,189,0,0" VerticalAlignment="Top" Click="Browse_Click" Width="499" Height="68" FontSize="16"/>
    <TextBlock HorizontalAlignment="Left" Margin="717,271,0,0" TextWrapping="Wrap" Text="(Optional)" VerticalAlignment="Top" Height="32" Width="83" FontSize="16"/>
    ```
    
3.  MainPage.xaml ファイルを保存します。
4.  MainPage.xaml.cs ファイルに、次の using ステートメントを追加します。
    ```cs
    using Windows.Web.Http;
    using System.Text;
    using Windows.Security.Cryptography.Certificates;
    using Windows.Storage.Pickers;
    using Windows.Storage;
    using Windows.Storage.Streams;
    ```

5.  MainPage.xaml.cs ファイルで、次の変数を **MainPage** クラスに追加します。 ここでは、"FirstContosoBank" Web サービスのセキュリティで保護された "Login" メソッドのアドレスと、証明書ストアにインポートする PFX 証明書を保持するグローバル変数を指定しています。 &lt;サーバー名&gt; は Microsoft Internet Information (IIS) サーバーの完全修飾名に更新してください。
    ```cs
    private Uri requestUri = new Uri("https://<server-name>/FirstContosoBank/Service1.asmx?op=Login");
    private string pfxCert = null;
    ```

6.  MainPage.xaml.cs ファイルで、次に示すように、ログイン ボタンのクリック ハンドラーと、セキュリティで保護された Web サービスにアクセスするためのメソッドを追加します。
    ```cs
    private void Login_Click(object sender, RoutedEventArgs e)
    {
        MakeHttpsCall();
    }

    private async void MakeHttpsCall()
    {

        StringBuilder result = new StringBuilder("Login ");
        HttpResponseMessage response;
        try
        {
            Windows.Web.Http.HttpClient httpClient = new Windows.Web.Http.HttpClient();
            response = await httpClient.GetAsync(requestUri);
            if (response.StatusCode == HttpStatusCode.Ok)
            {
                result.Append("successful");
            }
            else
            {
                result = result.Append("failed with ");
                result = result.Append(response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            result = result.Append("failed with ");
            result = result.Append(ex.Message);
        }

        Result.Text = result.ToString();
    }
    ```

7.  MainPage.xaml.cs ファイルで、次に示すように、PFX ファイルを参照するボタンのクリック ハンドラーと、選ばれた PFX ファイルを証明書ストアにインポートするボタンのクリック ハンドラーを追加します。
    ```cs
    private async void Import_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Result.Text = "Importing selected certificate into user certificate store....";
            await CertificateEnrollmentManager.UserCertificateEnrollmentManager.ImportPfxDataAsync(
                pfxCert,
                PfxPassword.Password,
                ExportOption.Exportable,
                KeyProtectionLevel.NoConsent,
                InstallOptions.DeleteExpired,
                "Import Pfx");

            Result.Text = "Certificate import succeded";
        }
        catch (Exception ex)
        {
            Result.Text = "Certificate import failed with " + ex.Message;
        }
    }

    private async void Browse_Click(object sender, RoutedEventArgs e)
    {

        StringBuilder result = new StringBuilder("Pfx file selection ");
        FileOpenPicker pfxFilePicker = new FileOpenPicker();
        pfxFilePicker.FileTypeFilter.Add(".pfx");
        pfxFilePicker.CommitButtonText = "Open";
        try
        {
            StorageFile pfxFile = await pfxFilePicker.PickSingleFileAsync();
            if (pfxFile != null)
            {
                IBuffer buffer = await FileIO.ReadBufferAsync(pfxFile);
                using (DataReader dataReader = DataReader.FromBuffer(buffer))
                {
                    byte[] bytes = new byte[buffer.Length];
                    dataReader.ReadBytes(bytes);
                    pfxCert = System.Convert.ToBase64String(bytes);
                    PfxPassword.Password = string.Empty;
                    result.Append("succeeded");
                }
            }
            else
            {
                result.Append("failed");
            }
        }
        catch (Exception ex)
        {
            result.Append("failed with ");
            result.Append(ex.Message); ;
        }

        Result.Text = result.ToString();
    }
    ```

8.  アプリを実行し、セキュリティで保護された Web サービスにログインして、PFX ファイルをローカル証明書ストアにインポートします。

これらの手順を繰り返すことで、同じユーザー証明書を使ってセキュリティで保護された同じ Web サービスや別の Web サービスにアクセスする複数のアプリを作成できます。