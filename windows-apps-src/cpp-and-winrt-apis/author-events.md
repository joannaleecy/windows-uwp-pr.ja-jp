---
author: stevewhims
description: このトピックでは、イベントを発生させるランタイム クラスを含む、Windows ランタイム コンポーネントを作成する方法を示します。 コンポーネントを使用してイベントを処理するアプリも示します。
title: C++/WinRT でのイベントの作成
ms.author: stwhi
ms.date: 04/23/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、作成者、イベント
ms.localizationpriority: medium
ms.openlocfilehash: b7574f1a3406dae665ced80294f7bc1cf91aeb8c
ms.sourcegitcommit: ab92c3e0dd294a36e7f65cf82522ec621699db87
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/03/2018
ms.locfileid: "1832026"
---
# <a name="author-events-in-cwinrtwindowsuwpcpp-and-winrt-apisintro-to-using-cpp-with-winrt"></a>[C++/WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) でのイベントの作成
> [!NOTE]
> **一部の情報はリリース前の製品に関する事項であり、正式版がリリースされるまでに大幅に変更される可能性があります。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。**

このトピックでは、その残高が借方に入るときにイベントを発生させる、銀行口座を表すランタイム クラスを含む Windows ランタイム コンポーネントを作成する方法を示します。 銀行口座ランタイム クラスを使用し、関数を呼び出して残高を調整して、発生するイベントを処理するコア アプリも示します。

> [!NOTE]
> 現在利用可能な C++/WinRT Visual Studio Extension (VSIX) (プロジェクト テンプレート サポートおよび C++/WinRT MSBuild プロパティとターゲットを提供) の詳細については、「[C++/WinRT の Visual Studio サポートと VSIX](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-and-the-vsix)」を参照してください。

> [!IMPORTANT]
> C++/WinRT でランタイム クラスを使用および作成する方法についての理解をサポートするために重要な概念と用語については、「[C++/WinRT での API の使用](consume-apis.md)」と「[C++/WinRT での作成者 API](author-apis.md)」を参照してください。

## <a name="windowsfoundationeventhandlerlttgt-and-typedeventhandlerlttgt"></a>Windows::Foundation::EventHandler&lt;T&gt; と TypedEventHandler&lt;T&gt;
Windows ランタイム コンポーネントに実装されているランタイム クラスからイベントを発生する場合は、イベントのデリゲート型に [**Windows::Foundation::EventHandler**](/uwp/api/windows.foundation.eventhandler) または [**TypedEventHandler**](/uwp/api/windows.foundation.eventhandler) を使用する必要があります。 型のパラメーターは、Windows ランタイム型でなければならないため、サード パーティ製のランタイム クラスとプリミティブ型が許可されています。

コンパイラは、この制約を忘れた場合に "*WinRT 型である必要があります*" エラーを使用してサポートします。

## <a name="winrtdelegatelttgt"></a>winrt::delegate&lt;...T&gt;
(同じプロジェクト内で作成および使用される) C++ 型からイベントを発生する場合、イベントのデリゲート型に C++/WinRT の **winrt::delegate&lt;...T&gt;** を使用できます。 その場合、型のパラメーターは Windows ランタイム型である必要はありません。

## <a name="create-a-windows-runtime-component-bankaccountwrc"></a>Windows ランタイム コンポーネントの作成 (BankAccountWRC)
まず、Microsoft Visual Studio で、新しいプロジェクトを作成します。 **Visual C++ Windows ランタイム コンポーネント (C++/WinRT)** プロジェクトを作成し、(「銀行口座 Windows ランタイム コンポーネント」用に) *BankAccountWRC* と名前を付けます。

新しく作成したプロジェクトには、`Class.idl` という名前のファイルが含まれています。 そのファイルの名前を `BankAccountWRC.idl` に変更して、ビルドするときにコンポーネントの Windows ランタイム メタデータ ファイルがコンポーネント自体の名前になるようにします。 `BankAccountWRC.idl` で、以下のリストに示すようにインターフェイスを定義します。

```idl
// BankAccountWRC.idl
namespace BankAccountWRC
{
    runtimeclass BankAccount
    {
        BankAccount();
        event Windows.Foundation.EventHandler<Single> AccountIsInDebit;
        void AdjustBalance(Single value);
    };
}
```

ファイルを保存し、プロジェクトをビルドします。 ビルドは、まだ成功しません。 ただし、ビルド プロセス中に、`midl.exe` ツールが実行されてコンポーネントの Windows ランタイム メタデータ ファイルが作成されます (これは `\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd` です)。 次に、`cppwinrt.exe` ツールが (`-component` オプションで) 実行され、コンポーネントの作成をサポートするソース コード ファイルが生成されます。 これらのファイルには、IDL で宣言した `BankAccount`ランタイム クラスの実装を開始するためのスタブが含まれています。 これらのスタブは `\BankAccountWRC\BankAccountWRC\Generated Files\sources\BankAccount.h` と `BankAccount.cpp` です。

スタブ ファイル `BankAccount.h` と `BankAccount.cpp` を `\BankAccountWRC\BankAccountWRC\Generated Files\sources\` からプロジェクト フォルダー `\BankAccountWRC\BankAccountWRC\` にコピーします。 **ソリューション エクスプローラー**で、**[すべてのファイルを表示]** がオンであることを確認します。 コピーしたスタブ ファイルを右クリックし、**[プロジェクトに含める]** をクリックします。 また、`Class.h` と `Class.cpp` を右クリックし、**[プロジェクトから除外する]** をクリックします。

ここで、`BankAccount.h` と `BankAccount.cpp` を開いてランタイム クラスを実装してみましょう。 `BankAccount.h` で、BankAccount の実装 (ファクトリの実装*ではありません*) に 2 つのプライベート メンバーを追加します。

```cppwinrt
// BankAccount.h
...
namespace winrt::BankAccountWRC::implementation
{
    struct BankAccount : BankAccountT<BankAccount>
    {
        ...

    private:
        event<Windows::Foundation::EventHandler<float>> accountIsInDebitEvent;
        float balance{ 0.f };
    };
}
...
```

`BankAccount.cpp` では、次のように関数を実装します。

```cppwinrt
// BankAccount.cpp
...
namespace winrt::BankAccountWRC::implementation
{
    event_token BankAccount::AccountIsInDebit(Windows::Foundation::EventHandler<float> const& handler)
    {
        return accountIsInDebitEvent.add(handler);
    }

    void BankAccount::AccountIsInDebit(event_token const& token)
    {
        accountIsInDebitEvent.remove(token);
    }

    void BankAccount::AdjustBalance(float value)
    {
        balance += value;
        if (balance < 0.f) accountIsInDebitEvent(*this, balance);
    }
}
```

**AdjustBalance** 関数の実装によって、残高が負の値になった場合に **AccountIsInDebit** イベントが発生します。

任意の警告がビルドを妨げる場合は、プロジェクトのプロパティ **C/C++** > **General** > **Treat Warnings As Errors** を **No (/WX-)** に設定して、もう一度プロジェクトをビルドします。

## <a name="create-a-core-app-bankaccountcoreapp-to-test-the-windows-runtime-component"></a>コア アプリ (BankAccountCoreApp) を作成して Windows ランタイム コンポーネントをテストします。
ここで (`BankAccountWRC` ソリューション、または新しいソリューションのいずれかに) 新しいプロジェクトを作成します。 **Visual C++ コア アプリ (C++/WinRT)** プロジェクトを作成し、*BankAccountCoreApp* と名前を付けます。

参照を追加し、`\BankAccountWRC\Debug\BankAccountWRC\BankAccountWRC.winmd` へブラウズします。 **[追加]** をクリックして **[OK]** をクリックします。 ここで BankAccountCoreApp をビルドします。 ペイロード ファイル `readme.txt` が存在しないというエラーが表示される場合、Windows ランタイム コンポーネント プロジェクトからそのファイルを除外し、これを再ビルドしてから、BankAccountCoreApp を再ビルドします。

ビルド プロセス中に、`cppwinrt.exe` ツールが実行され、参照されている `.winmd` ファイルを投影型を含むソース コード ファイルに処理して、コンポーネントの使用をサポートします。 コンポーネントのランタイム クラス (`BankAccountWRC.h`という名前) の投影型のヘッダーは、フォルダー `\BankAccountCoreApp\BankAccountCoreApp\Generated Files\winrt\` 内に生成されます。

そのヘッダーを `App.cpp` に含めます。

```cppwinrt
#include <winrt/BankAccountWRC.h>
```

`App.cpp` でも、(投影型の既定のコンストラクターを使用して) BankAccount のインスタンスを作成するために次のコードを追加し、イベント ハンドラーを登録して、口座が借方に入るようにします。

```cppwinrt
struct App : implements<App, IFrameworkViewSource, IFrameworkView>
{
    BankAccountWRC::BankAccount bankAccount;
    event_token eventToken;
    ...
    
    void Initialize(CoreApplicationView const &)
    {
        eventToken = bankAccount.AccountIsInDebit([](const auto &, float balance)
        {
            assert(balance < 0.f);
        });
    }
    ...

    void Uninitialize()
    {
        bankAccount.AccountIsInDebit(eventToken);
    }
    ...

    void OnPointerPressed(IInspectable const &, PointerEventArgs const & args)
    {
        bankAccount.AdjustBalance(-1.f);
        ...
    }
    ...
};
```

ウィンドウをクリックするたびに、銀行口座の残高から 1 を減算します。 期待どおりにイベントが発生することを実証するには、ラムダ式内にブレークポイントを置き、アプリを実行して、ウィンドウ内をクリックします。

## <a name="related-topics"></a>関連トピック
* [C++/WinRT での API の作成](author-apis.md)
* [C++/WinRT での API の使用](consume-apis.md)
* [C++/WinRT でデリゲートを使用してイベントを処理する](handle-events.md)
