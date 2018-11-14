---
author: stevewhims
description: Visual Studio の操作方法
title: Visual Studio の操作方法
ms.assetid: 7FBB50A2-6D22-4082-B333-5153DADDDE9A
ms.author: stwhi
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 8219f1600297dfa60345fe8130e8954558b8ac61
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6651608"
---
# <a name="getting-started-getting-around-in-visual-studio"></a>はじめに: Visual Studio の操作方法


## <a name="getting-around-in-microsoft-visual-studio"></a>Microsoft Visual Studio の操作方法

ここでは、前の手順で作ったプロジェクトに戻り、Microsoft Visual Studio 統合開発環境 (IDE) の操作方法について示します。

Xcode 開発者であれば、左側のウィンドウにソース ファイル、中央のウィンドウにエディター (UI またはソース コード)、コントロールとそのプロパティが右側のウィンドウにそれぞれ表示された、以下の既定のビューを見慣れていることと思われます。

![Xcode の開発環境](images/ios-to-uwp/xcode-ide.png)

Microsoft Visual Studio もこれによく似ています。ただし、既定のビューでは、左側の**ツールボックス**にコントロールが表示されます。 ソース ファイルは右側の**ソリューション エクスプローラー**に表示され、プロパティは次のように、**[ソリューション エクスプローラー]** ウィンドウの **[プロパティ]** に表示されます。

![Visual Studio の開発環境](images/ios-to-uwp/vs-ide.png)

これに少し違和感を感じる場合、Visual Studio ではウィンドウを並べ替えて、ソース ファイルを画面の左側に、ツールボックスを右側に配置することができます。 実際に、任意のウィンドウのタイトル バーをクリックしてドラッグすることによって位置変更ができ、リリースするとドッキングされる位置を示すボックスが影付きで表示されます。 多くのウィンドウのタイトル バーにも小さな描画ピン アイコンがあります。 これにより、パネルをそのまま固定して、その場所にロックできます。 ウィンドウのピン留めを外して、領域を節約するために折りたたむことができます。これは、モニターが幅の狭い側にある場合に便利です。 失敗した場合 (ご安心ください。すべて対応できます) は、**[ウィンドウ]** メニューの **[ウィンドウ レイアウトのリセット]** をクリックして順序を復元します。

## <a name="adding-controls-setting-their-properties-and-responding-to-events"></a>コントロールの追加、プロパティの設定、イベントへの応答

次は、プロジェクトにコントロールをいくつか追加しましょう。 ここでは、コントロールのプロパティをいくつか変更した後、コントロールのイベントの 1 つに応答するコードを記述します。

Xcode でコントロールを追加するには、目的の .xib ファイルまたはストーリーボードを開いた後、次に示すように、コントロールをドラッグ アンド ドロップします (**[Round Rect Button]** (角丸四角形ボタン) または **[Label]** (ラベル))。

![Xcode での UI の設計](images/ios-to-uwp/xcode-add-button-label.png)

次に、Visual Studio で同じような操作を行ってみましょう。 **ツールボックス**の **Button** コントロールをドラッグし、MainPage.xaml ファイルのデザイン サーフェスにドロップします。

**TextBlock** コントロールについても同じ操作を行うと、次のように表示されます。

![Visual Studio での UI の設計](images/ios-to-uwp/vs-add-button-label.png)

レイアウトとバインド情報が .xib ファイルまたはストーリーボード ファイル内に格納される Xcode とは異なり、Visual Studio では、これらの詳細を格納するために使用される XAML ファイルを、そのリッチで編集可能な宣言型の XML のような言語で編集することをお勧めします。 Extensible Application Markup Language (XAML) について詳しくは、「[XAML の概要](https://msdn.microsoft.com/library/windows/apps/mt185595)」をご覧ください。 ここでは、**[デザイン]** ウィンドウに表示されているものはすべて **[XAML]** ウィンドウに定義されていることを覚えておいてください。 **[XAML]** ウィンドウでは必要に応じて細かな調整を行うことができるため、慣れるにつれてユーザー インターフェイス コードを手動ですばやく開発できるようになります。 ただし、ここでは、**[デザイン]** ウィンドウと **[プロパティ]** ウィンドウにのみ注目します。

次に、ボタンの詳細を変更します。 おわかりのように、Xcode でボタンの名前を変更するには、ボタンのプロパティ パネルの **Title** フィールドの値を変更します。

Visual Studio を使う場合、同じような操作を行ってみましょう。 **[デザイン]** ウィンドウで、このボタンをタップしてフォーカスを設定します。 **[プロパティ]** ウィンドウで、**[コンテンツ]** の値を "Button" から "Press Me" に変更します。 次に、ボタン コントロールの名前を更新するために、ここで示すように、**[名前]** の値を "&lt;名前なし&gt;" から "myButton" に変更します。

![Visual Studio の [ボタンのプロパティ] ウィンドウ](images/ios-to-uwp/vs-button-properties.png)

次に、ユーザーによってボタンがタップされたときに **TextBlock** コントロールの内容を "Hello, World!" に変更する コードを記述します。

Xcode では、次に示すように、コードを記述した後でコントロールに関連付けることによって (多くの場合、そのボタンをソース コードにコントロールドラッグすることによって)、イベントをコントロールに関連付けます。

![Xcode でのボタンとイベントの関連付け](images/ios-to-uwp/xcode-add-button-event.png)

```swift
// Swift implementation.

@IBAction func buttonPressed(sender: UIButton) {
    
}
```

Visual Studio の操作も似ています。 **[プロパティ]** の右上隅には、稲妻ボタンがあります。 このボタンを使うと、次のように、選んだコントロールに関連付けられている可能なイベントの一覧が表示されます。

![Visual Studio でのボタンのイベントの一覧](images/ios-to-uwp/vs-button-event.png)

ボタンのクリック イベントにコードを追加するには、**[デザイン]** ウィンドウで、まずそのボタンを選択します。 次に、稲妻ボタンをクリックし、**[Click]** という名前の横の空のボックスをダブルクリックします。 その後、Visual Studio によってイベント "myButton\_Click" が **[Click]** ボックスに追加されます。さらに、次のように、対応するイベント ハンドラーが MainPage.xaml.cs ファイルに追加され、表示されます。

```csharp
private void myButton_Click(object sender, RoutedEventArgs e)
{

}
```

次に、**TextBlock** コントロールをフックします。 Xcode では、このように、ボタンをソース コード ファイルにコントロールドラッグし、コントロールをその定義に関連付けます。

![Xcode でのラベルと定義の関連付け](images/ios-to-uwp/xcode-add-button-reference.png)

```swift
// Swift implentation.

@IBOutlet weak var myLabel : UILabel
```

Visual Studio では、これは常に実行されるため、コントロールの関連付けの必要はありません。 プロパティをいくつかを変更してみましょう。

1.  MainPage.xaml ファイルのタブをタップします。
2.  **[デザイン]** ウィンドウで、**TextBlock** コントロールをタップします。
3.  **[プロパティ]** ウィンドウで、レンチ ボタンをタップしてプロパティを表示します。
4.  **[名前]** ボックスで、"&lt;No Name&gt;" を "myLabel" に変更します。

![Visual Studio の [ラベルのプロパティ] ウィンドウ](images/ios-to-uwp/vs-label-properties.png)

次に、ボタンのクリック イベントにコードを追加してみましょう。 このためには、MainPage.xaml.cs ファイルをタップし、次のコードを myButton\_Click イベント ハンドラーに追加します。

```csharp
private void myButton_Click(object sender, RoutedEventArgs e)
{
    // Add the following line of code.    
    myLabel.Text = "Hello, World!";
}
```

これは Swift で記述した場合に似ています。

```swift
@IBAction func buttonPressed(sender: UIButton) {
    myLabel.text = "Hello, World!"
}
```

最後に、アプリを実行します。**[デバッグ]** メニュー、**[デバッグの開始]** の順に選択します (または、単に F5 キーを押します)。 アプリが起動されたら、[Press Me] ボタンをクリックして、次の図に示すように、ラベルの内容が "TextBlock" から "Hello, World!" に変わることを確かめます。

![最初のチュートリアルを実行した結果: Hello, World!](images/ios-to-uwp/vs-hello-world.png)

アプリを中止するには、Visual Studio に戻り、**[デバッグ]** メニュー、**[デバッグの停止]** の順にタップします (または、単に Shift キーを押しながら F5 キーを押します)。 Visual Studio では、多数の異なるデバイスでアプリを試して、各デバイスでの動作を確認してみてください。

## <a name="next-step"></a>次のステップ

[はじめに: コモン コントロール](getting-started-common-controls.md)

