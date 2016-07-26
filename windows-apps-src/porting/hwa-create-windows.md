---
author: seksenov
title: "ホストされた Web アプリ - Visual Studio を使用した Web アプリケーションから Windows アプリへの変換"
description: "Visual Studio を使用して、Web サイトを、Windows 10 用のユニバーサル Windows プラットフォーム (UWP) アプリに変換します。"
kw: Hosted Web Apps tutorial, Porting to Windows 10 with Visual Studio, How to convert website to Windows, How to add website to Windows Store, Packaging web application for Microsoft Store, Test Windows 10 native features and runtime APIs with CodePen, How to use Windows Cortana Live Tiles Built-in Camera on my Website with remote JavaScript
translationtype: Human Translation
ms.sourcegitcommit: 3de603aec1dd4d4e716acbbb3daa52a306dfa403
ms.openlocfilehash: 05e2362d23ce6d1ce70e20a5610e1a5ede464987

---

# Web アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリに変換する

Web サイトの URL のみから開始して、Windows 10 用のユニバーサル Windows プラットフォーム アプリをすばやく作成する方法について説明します。 

> [!NOTE]
> 以下の手順は、Windows の開発プラットフォームで使用される手順です。 Mac ユーザーの場合は、[Mac の開発プラットフォームを使用する手順](/hwa-create-mac.md)をご覧ください。

## Windows での開発に必要な要素

- [Visual Studio 2015。](https://www.visualstudio.com/) フル機能を備えた無料の Visual Studio Community 2015 には、Windows 10 開発ツール、ユニバーサル アプリ テンプレート、コード エディター、強力なデバッガー、Windows Mobile エミュレーター、充実した言語サポートなどが含まれており、すべて運用環境で使うことができます。
- (省略可能) [Windows Standalone SDK for Windows 10。](https://dev.windows.com/downloads/windows-10-sdk) Visual Studio 2015 以外の開発環境を使っている場合は、Windows Standalone SDK for Windows 10 インストーラーをダウンロードできます。 Visual Studio 2015 を使っている場合は、この SDK をインストールする必要はありません (既に含まれています)。

## 手順 1: Web サイトの URL の選択
単一ページ アプリとして適切に動作する既存の Web サイトを選びます。 この作業は、サイトの所有者または開発者が行うことを強くお勧めします。これにより、必要なすべての変更を行うことができます。 具体的な URL がない場合は、こちらの[Codepen の例](http://codepen.io/seksenov/pen/wBbVyb/?editors=101)を Web サイトとして使用してみてください。 このチュートリアル全体で使用する、Web サイトの URL または Codepen の URL をコピーします。 

![手順 1: Web サイトの URL の選択](images/hwa-to-uwp/windows_step1.png)

## 手順 2: 空の JavaScript アプリの作成

Visual Studio を起動します。
1. **[ファイル]** をクリックします。
2. **[新しいプロジェクト]** をクリックします。
3. **[JavaScript]** の **[Windows ユニバーサル]** で、**[空のアプリケーション (Windows ユニバーサル)]** をクリックします。

![手順 2: 空の JavaScript アプリの作成](images/hwa-to-uwp/windows_step2.png)

## 手順 3: パッケージ化されたコードの削除

これはホストされた Web アプリであり、コンテンツはリモート サーバーから提供されるため、既定で JavaScript テンプレートに付属しているローカル アプリ ファイルの多くは必要ありません。 ローカルの HTML、JavaScript、CSS リソースを削除します。 残す必要があるのは、アプリを構成するための `package.appxmanifest`ファイルと、画像リソースのみです。

![手順 3: パッケージ化されたコードの削除](images/hwa-to-uwp/windows_step3.png)

## 手順 4: スタート ページの URL の設定

1. `package.appxmanifest` ファイルを開きます。
2. **[アプリケーション]** タブで、**[スタート ページ]** テキスト フィールドを探します。
3. `default.html` を Web サイトの URL に置き換えます。

![手順 4: スタート ページの URL の設定](images/hwa-to-uwp/windows_step4.png)

## 手順 5: Web アプリの境界の定義

アプリケーション コンテンツ URI 規則 (ACUR) は、どのリモート URL からアプリやユニバーサル Windows API へのアクセスを許可するかを指定します。 少なくとも、スタート ページとそのページで使用されるすべての Web リソースの ACUR を追加する必要があります。 ACUR について詳しくは、[ここをクリック](./hwa-access-features.md#keep-your-app-secure-setting-application-content-uri-rules-acurs)してください。
1. `package.appxmanifest` ファイルを開きます。
2. **[コンテンツ URI]** タブをクリックします。
3. スタート ページに必要な URI を追加します。

たとえば、次のように指定します。
```
1. http://codepen.io/seksenov/pen/wBbVyb/?editors=101
2. http://*.codepen.io/
```
4. 追加したすべての URI について、**[WinRT アクセス]** を **[すべて]** に設定します。

![手順 5: Web アプリの境界の定義](images/hwa-to-uwp/windows_step5.png)

## 手順 6: アプリの実行

この時点で、ユニバーサル Windows API にアクセスできる、完全に機能する Windows 10 アプリが完成しました。

Codepen の例を使っている場合は、**[Toast Notification]** ボタンをクリックすると、ホストされたスクリプトから Windows API が呼び出されます。

![手順 6: アプリの実行](images/hwa-to-uwp/windows_step6.png)

## ボーナス: カメラ キャプチャの追加

次の JavaScript コードをコピーして貼り付けると、カメラ キャプチャが有効になります。 独自の Web サイトを使っている場合は、`cameraCapture()` メソッドを呼び出すボタンを作成します。 Codepen の例を使っている場合は、ボタンは既に HTML に存在しています。 このボタンをクリックすると、写真が撮影されます。

```JavaScript
function cameraCapture() {
  if(typeof Windows != 'undefined') {
   var captureUI = new Windows.Media.Capture.CameraCaptureUI();
   //Set the format of the picture that's going to be captured (.png, .jpg, ...)
   captureUI.photoSettings.format = Windows.Media.Capture.CameraCaptureUIPhotoFormat.png;
   //Pop up the camera UI to take a picture
   captureUI.captureFileAsync(Windows.Media.Capture.CameraCaptureUIMode.photo).then(function (capturedItem) {
      // Do something with the picture
   });
  }
}
```

## 関連トピック

- [ユニバーサル Windows プラットフォーム (UWP) 機能にアクセスして Web アプリを強化する](hwa-access-features.md)
- [ユニバーサル Windows プラットフォーム (UWP) アプリのガイド](http://go.microsoft.com/fwlink/p/?LinkID=397871)
- [Windows ストア アプリ設計のアセットのダウンロード](https://msdn.microsoft.com/library/windows/apps/xaml/bg125377.aspx)



<!--HONumber=Jul16_HO2-->

