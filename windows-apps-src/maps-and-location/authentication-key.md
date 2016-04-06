---
title: マップ認証キーの要求
description: MapControl や Windows.Services.Maps 名前空間のマップ サービスをユニバーサル Windows アプリで使うには、そのアプリを認証する必要があります。
ms.assetid: 13B400D7-E13F-4F07-ACC3-9C34087F0F73
---

# マップ認証キーの要求


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]


[
            **MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) や [**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間のマップ サービスを [ユニバーサル Windows アプリ](https://msdn.microsoft.com/library/windows/apps/dn894631) で使うには、そのアプリを認証する必要があります。 アプリを認証するには、マップ認証キーを指定する必要があります。 このトピックでは、[Bing Maps Developer Center](https://www.bingmapsportal.com/) にマップ認証キーを要求し、アプリに追加する方法について説明します。

**ヒント:** アプリで地図を使う方法について詳しくは、GitHub の [Windows-universal-samples リポジトリ](http://go.microsoft.com/fwlink/p/?LinkId=619979) から次のサンプルをダウンロードしてください。

-   [ユニバーサル Windows プラットフォーム (UWP) の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## キーの取得


[Bing Maps Developer Center](https://www.bingmapsportal.com/) を使って、ユニバーサル Windows アプリ用のマップ認証キーを作成し管理します。

新しいキーを作成するには

1.  ブラウザーで、Bing Maps Developer Center ([https://www.bingmapsportal.com](https://www.bingmapsportal.com/)) にアクセスします。

2.  サインインを求められた場合は、Microsoft アカウントを入力して、**[Sign in] (サインイン)** をクリックします。

3.  Bing Maps アカウントに関連付けるアカウントを選びます。 Microsoft アカウントを使う場合は、**[Yes] (はい)** をクリックします。 それ以外の場合は、**[Sign in with another account] (別のアカウントでサインイン)** をクリックします。

4.  Bing Maps アカウントを持っていない場合は、ここで新しく作成します。 **[Account Name] (アカウント名)**、**[Contact Name] (連絡先名)**、**[Company Name] (会社名)**、**[Email Address] (メール アドレス)**、**[Phone Number] (電話番号)** を入力します。 使用条件に同意してから、**[Create] (作成)** をクリックします。

5.  **[My account] (アカウント) **メニューで、**[Create or view keys] (キーを作成または表示する)** をクリックします。

6.  **新しいキーを作成**するためのリンクをクリックします。

7.  **[Create Key] (キーの作成)** フォームの入力が完了したら、**[Create] (作成)** をクリックします。

    -   **[Application name] (アプリケーション名):** アプリケーションの名前です。
    -   **[Application URL] (アプリケーション URL) (オプション):** アプリケーションの URL です。
    -   **[Key type] (キーの種類):** **[Basic] (ベーシック)** または **[Enterprise] (エンタープライズ)** を選びます。
    -   **[Application type] (アプリケーションの種類):** ユニバーサル Windows アプリで使うには、**[Universal Windows App] (ユニバーサル Windows アプリ)** を選びます。

    次に示すのは、フォームの例です。

    ![[Create key] (キーの作成) フォームの例。](images/createkeydialog.png)

8.  **[Create] (作成)** をクリックすると、新しいキーが **[Create Key] (キーの作成)** フォームの下に表示されます。 このキーを安全な場所にコピーするか、次の手順で説明するように、キーをすぐにアプリに追加します。

## アプリへのキーの追加


ユニバーサル Windows アプリで [**MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) やマップ サービス ([**Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979)) を使うには、マップ認証キーが必要になります。 必要に応じて、マップ コントロールやマップ サービスのオブジェクトにキーを追加します。

### マップ コントロールにキーを追加するには

[
            **MapControl**](https://msdn.microsoft.com/library/windows/apps/dn637004) を認証するには、[**MapServiceToken**](https://msdn.microsoft.com/library/windows/apps/dn637036) プロパティを認証キー値に設定します。 このプロパティは、必要に応じて、コードまたは XAML マークアップで設定できます。 **MapControl** の使用について詳しくは、「[2D、3D、Streetside ビューでの地図の表示](display-maps.md)」をご覧ください。

-   この例では、コードで **MapServiceToken** を認証キー値に設定しています。

    ```cs
    MapControl1.MapServiceToken = "abcdef-abcdefghijklmno";
    ```

-   この例では、XAML マークアップで **MapServiceToken** を認証キー値に設定しています。

    ```xaml
    <Maps:MapControl x:Name="MapControl1" MapServiceToken="abcdef-abcdefghijklmno"/>
    ```

### マップ サービスにキーを追加するには

[
            **Windows.Services.Maps**](https://msdn.microsoft.com/library/windows/apps/dn636979) 名前空間のサービスを使うには、[**ServiceToken**](https://msdn.microsoft.com/library/windows/apps/dn636977) プロパティを認証キー値に設定します。 マップ サービスを使用する方法について詳しくは、「[ルートとルート案内の表示](routes-and-directions.md)」と「[ジオコーディングと逆ジオコーディングの実行](geocoding.md)」をご覧ください。

-   この例では、コードで **ServiceToken** を認証キー値に設定しています。

    ```cs
    MapService.ServiceToken = "abcdef-abcdefghijklmno";
    ```

## 関連トピック

* [Bing Maps Developer Center](https://www.bingmapsportal.com/)
* [UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [地図の設計ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用](https://channel9.msdn.com/Events/Build/2015/2-757)
* [UWP の交通情報アプリのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=619982)




<!--HONumber=Mar16_HO1-->


