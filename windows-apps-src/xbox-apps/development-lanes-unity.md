---
title: "Unity ゲームの Xbox One への移行"
author: JordanEllis6809
ms.sourcegitcommit: 008ff2566b17a05b52dee0a8cd6c070d841b1f62
ms.openlocfilehash: cc854bc707a9c08687d3c6d92a704f5099d52d5b

---

# Unity ゲームの Xbox One への移行

このチュートリアルでは、既に Unity のゲームが存在し、ビルドおよび展開する準備ができていることを前提としています。

[このチュートリアルのビデオ バージョン。](https://www.youtube.com/watch?v=f0Ptvw7k-CE)

## 手順 0: Unity が正しくインストールされていることを確認する

Unity をインストールするときに、以下のコンポーネントを選択する必要があります。

![Unity のインストール コンポーネント](images/unity-install-components.png)

## 手順 1: UWP ソリューションを構築する

Unity ゲーム プロジェクトで、`File -> Build Settings...` から [Build Settings] ウィンドウを開き、次に示す Windows ストア オプション メニューに移動します。

![[Build Settings] ウィンドウ](images/build-settings.png)

[`SDK`] が [`Universal 10`] に設定されていることを確認します。 次に、メニューの下部にある [Build] をクリックします。これにより、保存先フォルダーを指定するためのエクスプローラー ウィンドウが表示されます。 プロジェクトの `Assets` ディレクトリに `UWP` という名前のフォルダーを作成し、ビルドの保存先フォルダーとしてこのフォルダーを選択します。

![ビルドの保存先フォルダー](images/build-destination.png)

Unity で新しい Visual Studio ソリューションを作成できたので、次の手順ではこれを使って UWP ゲームを展開します。

![UWP VS ソリューション](images/uwp-vs-solution.png)

## 手順 2: ゲームを展開する

`Assets/UWP` フォルダーにある新しく生成されたソリューションを開きます。  開いたら、ターゲット プラットフォームを X64 に変更します。

![x64 ビルド プラットフォーム](images/x64-build-platform.png)

これで、ゲームの UWP Visual Studio ソリューションの準備ができました。[こちらの手順に従うことによって](https://msdn.microsoft.com/en-us/windows/uwp/xbox-apps/getting-started)、ゲームを製品版の Xbox One に正常に展開できます。

## 開発者メモ

- バージョン管理では UWP のフォルダーを無視することをお勧めします。 プロジェクトに新しい XAML 要素を追加しようとして、UWP フォルダー内のアセットをバージョン管理する必要がある場合は、[こちらのサンプル](https://bitbucket.org/Unity-Technologies/windowsstoreappssamples/overview)をご覧ください。

- ゲームのビルドに含まれている任意のコンテンツ (スクリプト以外) を Unity で変更する場合、次回展開するときにこれらの変更を確認するには、UWP ソリューションをリビルドする必要があります。 これは、Unity のビルド ステップで、プロジェクトのすべてのアセットが 1 つのリソース ファイルにコンパイルされるためです。 UWP ソリューションでは、ゲームを展開するときに、この生成されたリソース ファイルを参照します。




<!--HONumber=Jun16_HO5-->


