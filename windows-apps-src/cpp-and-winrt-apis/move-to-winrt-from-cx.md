---
description: このトピックでは、C++/CX コードを C++/WinRT の同等のコードに移植する方法について説明します。
title: C++/CX から C++/WinRT への移行
ms.date: 01/17/2019
ms.topic: article
keywords: windows 10, uwp, 標準, c++, cpp, winrt, プロジェクション, 移植, 移行, C++/CX
ms.localizationpriority: medium
ms.openlocfilehash: fe988bffbf024308fb5d43da7ed538e5330b58de
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635077"
---
# <a name="move-to-cwinrt-from-ccx"></a>C++/CX から C++/WinRT への移行

このトピックでは、コードを移植する方法、 [C +/cli CX](/cpp/cppcx/visual-c-language-reference-c-cx) 、それに対応するプロジェクト[C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt)します。

## <a name="porting-strategies"></a>移植の戦略

場合は、徐々 に移植すると、C +/cli c++/CX コード/cli WinRT、しすることができます。 C + +/CX および C++/cli WinRT コードは、XAML コンパイラ サポートと Windows ランタイム コンポーネントの例外を使用して、同じプロジェクトで共存できます。 これら 2 つの例外は、C + いずれかをターゲットする必要があります/cli/CX または C++/cli、同じプロジェクト内の WinRT します。

> [!IMPORTANT]
> XAML アプリケーションをビルドするプロジェクトの場合、に、まず c++ のいずれかを使用して Visual Studio で新しいプロジェクトを作成する、推奨される 1 つのワークフローは/cli WinRT プロジェクト テンプレート (を参照してください[Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package))。 C++ からソース コードとマークアップをコピーし、開始/cli CX プロジェクト。 新しい XAML ページを追加する**プロジェクト** \> **新しい項目の追加.**\> **Visual C** > **空白のページ (C +/cli WinRT)** します。
>
> 要素のコードから、XAML C + への Windows ランタイム コンポーネントを使用する代わりに、/cli CX プロジェクトのように移植します。 移動するか、ほど C +/cli CX コード、コンポーネントには c++ XAML プロジェクトを変更すると/cli WinRT します。 C + と XAML プロジェクトのままにそれ以外の場合、または/cli CX、作成するには新しい C +/cli WinRT コンポーネント、C + の移植を開始および/cli/CX コードを XAML プロジェクトとコンポーネントにします。 できます c++/cli CX コンポーネントのプロジェクトと共に C +/cli、同じソリューション内の WinRT コンポーネント プロジェクトがそれらの両方をアプリケーション プロジェクトから参照し、段階的に、他のいずれかからポートします。 参照してください[C + 間の相互運用/cli WinRT および C++/cli CX](interop-winrt-cx.md) 2 つの言語プロジェクションを使用して、同じプロジェクト内の詳細についてはします。

> [!NOTE]
> [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx) と Windows SDK の両方で、ルート名前空間 **Windows** で型を宣言します。 C++/WinRT に投影された Windows 型は Windows 型と同じ完全修飾名を持ちますが、 C++ **winrt** 名前空間に配置されます。 これらの異なる名前空間では、独自のペースで C++/CX から C++/WinRT へ移植できます。

C++ の移植で最初の手順に注意してください、上記で説明した例外を方位、/cli C + CX プロジェクト/cli WinRT は、C + を手動で追加する/cli WinRT サポート (を参照してください[Visual Studio のサポートの C +/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package))。 インストール、 [Microsoft.Windows.CppWinRT NuGet パッケージ](https://www.nuget.org/packages/Microsoft.Windows.CppWinRT/)をプロジェクトにします。 開いている Visual Studio でプロジェクトをクリックして**プロジェクト** \> **NuGet パッケージの管理.**\> **[参照]** 入力するか貼り付けて**Microsoft.Windows.CppWinRT**検索ボックスに、検索結果の項目を選択し、順にクリックします**インストール**そのプロジェクトのパッケージをインストールします。 その変更による 1 つの効果は、C++/CX のサポートがプロジェクトで無効になることです。 C + のすべての依存関係のサポートを発見 (してポート) メッセージをビルドできるように、無効のままにことをお勧め/cli CX、または再度有効にできますサポート (プロジェクトのプロパティで**C/C++** \> **[全般]**\> **Windows ランタイム拡張機能の使用** \> **はい (/ZW)**)、およびポートを徐々 にします。

そのプロジェクトのプロパティを確認します。**全般** \> **ターゲット プラットフォーム バージョン**10.0.17134.0 (Windows 10、バージョン 1803) に設定されている以上。

プリコンパイル済みヘッダー ファイル (通常は `pch.h`) で、`winrt/base.h` を含めます。

```cppwinrt
#include <winrt/base.h>
```

C++/WinRT の投影された Windows API ヘッダー (たとえば、`winrt/Windows.Foundation.h`) を含める場合は、それが自動的に含められるため、このように明示的に `winrt/base.h` を含める必要はありません。

プロジェクトで [Windows ランタイム C++ テンプレート ライブラリ (WRL)](/cpp/windows/windows-runtime-cpp-template-library-wrl) 型も使用している場合は、「[WRL から C++/WinRT への移行](move-to-winrt-from-wrl.md)」を参照してください。

## <a name="parameter-passing"></a>パラメーターの引き渡し
書き込み中に C +/cli 渡す CX ソース コードでは、C +/cli hat として関数のパラメーターとして/CX 型 (\^) 参照。

```cppcx
void LogPresenceRecord(PresenceRecord^ record);
```

C++/WinRT では、同期関数に既定で `const&` パラメーターを使用する必要があります。 これにより、コピーとインター ロック オーバーヘッドが回避されます。 ただし、コルーチンが値による呼び出しをして有効期間の問題を回避するように、値渡しを使用する必要があります (詳細については、「[C++/WinRT を使用した同時実行と非同期操作](concurrency.md)」を参照してください)。

```cppwinrt
void LogPresenceRecord(PresenceRecord const& record);
IASyncAction LogPresenceRecordAsync(PresenceRecord const record);
```

C++/WinRT オブジェクトは、基本的に Windows ランタイムのバッキング オブジェクトへのインターフェイス ポインターを保持する値です。 C++/WinRT オブジェクトをコピーすると、コンパイラはカプセル化されたインターフェイス ポインターをコピーし、その参照カウントをインクリメントします。 コピーの最終的なデストラクションには、参照カウントのデクリメントも含まれます。 そのため、必要な場合にのみ、コピーのオーバーヘッドが発生します。

## <a name="variable-and-field-references"></a>変数とフィールドの参照
書き込み中に C +/cli CX ソース コードでは、hat を使用する (\^) で Windows ランタイム オブジェクトと、矢印を参照する変数 (-&gt;) hat 変数を逆参照演算子。

```cppcx
IVectorView<User^>^ userList = User::Users;

if (userList != nullptr)
{
    for (UINT32 iUser = 0; iUser < userList->Size; ++iUser)
    ...
```

同等の C + に移植するときに/cli、WinRT コード、帽子を削除し、矢印の演算子を変更すると、的を取得できます (-&gt;)、ドット演算子 (.) にします。 C +/cli 投影 WinRT 型は値、およびポインターではありません。

```cppwinrt
IVectorView<User> userList = User::Users();

if (userList != nullptr)
{
    for (UINT32 iUser = 0; iUser < userList.Size(); ++iUser)
    ...
```

既定のコンストラクターの c++/cli CX hat ポインターを null に初期化します。 ここでは、c++/cli CX のコード例が初期化されていないか、適切な型の変数/フィールドを作成します。 つまり、それを参照しない最初に、 **TextBlock**; 以降の参照を代入する予定です。

```cppcx
TextBlock^ textBlock;

class MyClass
{
    TextBlock^ textBlock;
};
```

同等の c++/cli WinRT を参照してください[遅延初期化](consume-apis.md#delayed-initialization)します。

## <a name="properties"></a>プロパティ
C++/CX 言語拡張機能には、プロパティの概念が含まれています。 C++/CX ソース コードを記述するときに、フィールドと同様にプロパティにアクセスできます。 標準 C++ にはプロパティの概念がないため、C++/WinRT では、Get 関数と Set 関数を呼び出します。

次の例では、**XboxUserId**、**UserState**、**PresenceDeviceRecords**、**Size** はすべてプロパティです。

### <a name="retrieving-a-value-from-a-property"></a>プロパティからの値の取得
C++/CX でプロパティの値を取得する方法は次のとおりです。

```cppcx
void Sample::LogPresenceRecord(PresenceRecord^ record)
{
    auto id = record->XboxUserId;
    auto state = record->UserState;
    auto size = record->PresenceDeviceRecords->Size;
}
```

同等の C++/WinRT ソース コードは、プロパティと同じ名前を持ち、パラメーターのない関数を呼び出します。

```cppwinrt
void Sample::LogPresenceRecord(PresenceRecord const& record)
{
    auto id = record.XboxUserId();
    auto state = record.UserState();
    auto size = record.PresenceDeviceRecords().Size();
}
```

**PresenceDeviceRecords** 関数は、それ自体が **Size** 関数を持つ Windows ランタイム オブジェクトを返します。 返されたオブジェクトは C++/WinRT の投影された型でもあるため、ドット演算子を使用して逆参照し、**Size** を呼び出します。

### <a name="setting-a-property-to-a-new-value"></a>新しい値へのプロパティの設定
新しい値にプロパティを設定するには、同様のパターンに従います。 まず、C++/CX で次の操作を行います。

```cppcx
record->UserState = newValue;
```

C++/WinRT で対応する操作を行うには、プロパティと同じ名前の関数を呼び出し、引数を渡します。

```cppwinrt
record.UserState(newValue);
```

## <a name="creating-an-instance-of-a-class"></a>クラスのインスタンスの作成
使用する c++/cli CX オブジェクト、hat とよく呼ばれることを識別するハンドルを使用して (\^) 参照。 `ref new` キーワードにより新しいオブジェクトを作成します。これにより、[**RoActivateInstance**](https://msdn.microsoft.com/library/br224646) が呼び出され、ランタイム クラスの新しいインスタンスがアクティブ化されます。

```cppcx
using namespace Windows::Storage::Streams;

class Sample
{
private:
    Buffer^ m_gamerPicBuffer = ref new Buffer(MAX_IMAGE_SIZE);
};
```

C++/WinRT オブジェクトは値であるため、スタックに割り当てるか、オブジェクトのフィールドとして割り当てることができます。 C++/WinRT オブジェクトを割り当てるために、`ref new` (または `new`) は使用*しません*。 バックグラウンドで **RoActivateInstance** は引き続き呼び出されています。

```cppwinrt
using namespace winrt::Windows::Storage::Streams;

struct Sample
{
private:
    Buffer m_gamerPicBuffer{ MAX_IMAGE_SIZE };
};
```

リソースを初期化するコストが高い場合は、実際に必要になるまで初期化を遅延するのが一般的です。

```cppcx
using namespace Windows::Storage::Streams;

class Sample
{
public:
    void DelayedInit()
    {
        // Allocate the actual buffer.
        m_gamerPicBuffer = ref new Buffer(MAX_IMAGE_SIZE);
    }

private:
    Buffer^ m_gamerPicBuffer;
};
```

同じコードが C++/WinRT に移植されました。 `nullptr` コンストラクターを使っていることに注目してください。 コンストラクターの詳細については、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。

```cppwinrt
using namespace winrt::Windows::Storage::Streams;

struct Sample
{
    void DelayedInit()
    {
        // Allocate the actual buffer.
        m_gamerPicBuffer = Buffer(MAX_IMAGE_SIZE);
    }

private:
    Buffer m_gamerPicBuffer{ nullptr };
};
```

## <a name="converting-from-a-base-runtime-class-to-a-derived-one"></a>ランタイムの基本クラスから派生の 1 つに変換します。
参照を基本の派生型のオブジェクトを参照することがわかっているが一般的です。 C++/cli CX を使用する`dynamic_cast`に*キャスト*に、参照から derived へのベースの参照。 `dynamic_cast`を非表示の呼び出しにすぎません[ **QueryInterface**](https://msdn.microsoft.com/library/windows/desktop/ms682521)します。 典型的な例を次に示します&mdash;からキャストして、依存関係プロパティ変更イベントを処理している**DependencyObject**依存関係プロパティを所有する実際の型に戻します。

```cppcx
void BgLabelControl::OnLabelChanged(Windows::UI::Xaml::DependencyObject^ d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs^ e)
{
    BgLabelControl^ theControl{ dynamic_cast<BgLabelControl^>(d) };

    if (theControl != nullptr)
    {
        // succeeded ...
    }
}
```

同等の C +/cli WinRT コードで置き換えます、`dynamic_cast`を呼び出して、 [ **IUnknown::try_as** ](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknowntryas-function)関数をカプセル化する**QueryInterface**します。 また、オプションを呼び出す、ある[ **IUnknown::as**](/uwp/cpp-ref-for-winrt/windows-foundation-iunknown#iunknownas-function)例外をスローする代わりに、必要なインターフェイス (要求している型の既定のインターフェイス) のクエリが返されない場合。 ここでは、c++/cli WinRT のコード例です。

```cppwinrt
void BgLabelControl::OnLabelChanged(Windows::UI::Xaml::DependencyObject const& d, Windows::UI::Xaml::DependencyPropertyChangedEventArgs const& e)
{
    if (BgLabelControlApp::BgLabelControl theControl{ d.try_as<BgLabelControlApp::BgLabelControl>() })
    {
        // succeeded ...
    }

    try
    {
        BgLabelControlApp::BgLabelControl theControl{ d.as<BgLabelControlApp::BgLabelControl>() };
        // succeeded ...
    }
    catch (winrt::hresult_no_interface const&)
    {
        // failed ...
    }
}
```

## <a name="event-handling-with-a-delegate"></a>デリゲートを使用したイベント処理
この場合はデリゲートとしてラムダ関数を使用して、C++/CX でイベントを処理する典型的な例を次に示します。

```cppcx
auto token = myButton->Click += ref new RoutedEventHandler([=](Platform::Object^ sender, RoutedEventArgs^ args)
{
    // Handle the event.
    // Note: locals are captured by value, not reference, since this handler is delayed.
});
```

C++/WinRT で対応するコードは次のとおりです。

```cppwinrt
auto token = myButton().Click([=](IInspectable const& sender, RoutedEventArgs const& args)
{
    // Handle the event.
    // Note: locals are captured by value, not reference, since this handler is delayed.
});
```

ラムダ関数の代わりに、デリゲートを自由関数として実装するか、またはメンバー関数へのポインターとして実装するかを選択できます。 詳細については、「[C++/WinRT でのデリゲートを使用したイベントの処理](handle-events.md)」を参照してください。

イベントとデリゲートが内部的に使用される C++/CX コードベース (バイナリではなく) から移植する場合は、[**winrt::delegate**](/uwp/cpp-ref-for-winrt/delegate) を使用すると、C++/WinRT でそのパターンを複製できます。 参照してください[デリゲート、単純な信号、およびプロジェクト内でのコールバックをパラメーター化された](author-events.md#parameterized-delegates-simple-signals-and-callbacks-within-a-project)します。

## <a name="revoking-a-delegate"></a>デリゲートの取り消し
C++/CX では、`-=` 演算子を使用して前のイベント登録を取り消します。

```cppcx
myButton->Click -= token;
```

C++/WinRT で対応するコードは次のとおりです。

```cppwinrt
myButton().Click(token);
```

詳細とオプションについては、「[登録済みデリゲートの取り消し](handle-events.md#revoke-a-registered-delegate)」を参照してください。

## <a name="mapping-ccx-platform-types-to-cwinrt-types"></a>C++/WinRT 型への C++/CX **Platform** 型のマッピング
C++/CX は **Platform** 名前空間でいくつかのデータ型を提供します。 これらの型は標準 C++ ではないため、Windows ランタイム言語拡張機能を有効にしたとき (Visual Studio プロジェクトのプロパティの **[C/C++]** > **[全般]** > **[Windows ランタイム拡張機能の使用]** > **[はい (/ZW)]**) にのみ使用できます。 下の表は、**Platform** 型を C++/WinRT の同等の型に移植するときに役立ちます。 完了したら、C++/WinRT は標準 C++ であるため、`/ZW` オプションをオフにすることができます。

| C++/CX | C++/WinRT |
| ---- | ---- |
| **Platform::agile\^** | [**winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref) |
| **Platform::array\^** | 参照してください[ポート**platform::array\^**](#port-platformarray) |
| **Platform::exception\^** | [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) |
| **Platform::invalidargumentexception\^** | [**winrt::hresult_invalid_argument**](/uwp/cpp-ref-for-winrt/error-handling/hresult-invalid-argument) |
| **Platform::object\^** | **winrt::Windows::Foundation::IInspectable** |
| **Platform::string\^** | [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) |

### <a name="port-platformagile-to-winrtagileref"></a>ポート**platform::agile\^** に**winrt::agile_ref**
**Platform::agile\^** 型 c++/cli CX は任意のスレッドからアクセスできる Windows ランタイム クラスを表します。 C++/cli では WinRT 相当[ **winrt::agile_ref**](/uwp/cpp-ref-for-winrt/agile-ref)します。

C++/CX で、次の操作を行います。

```cppcx
Platform::Agile<Windows::UI::Core::CoreWindow> m_window;
```

C++/WinRT で、次の操作を行います。

```cppwinrt
winrt::agile_ref<Windows::UI::Core::CoreWindow> m_window;
```

### <a name="port-platformarray"></a>ポート**platform::array\^**
オプションには、初期化子リストを使用して、 **std::array**、または**std::vector**します。 詳細については、およびコード例は、次を参照してください。[標準的な初期化子リスト](/windows/uwp/cpp-and-winrt-apis/std-cpp-data-types#standard-initializer-lists)と[標準配列とベクター](/windows/uwp/cpp-and-winrt-apis/std-cpp-data-types#standard-arrays-and-vectors)します。

### <a name="port-platformexception-to-winrthresulterror"></a>ポート**platform::exception\^** に**winrt::hresult_error**
**Platform::exception\^**  c++ 型が生成される/cli CX、Windows ランタイム API に非 S が返されるときに\_OK HRESULT。 C++/WinRT の同等の型は [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) です。

C + に移植する/cli WinRT を使用するすべてのコードを変更**platform::exception\^** を使用する**winrt::hresult_error**します。

C++/CX で、次の操作を行います。

```cppcx
catch (Platform::Exception^ ex)
```

C++/WinRT で、次の操作を行います。

```cppwinrt
catch (winrt::hresult_error const& ex)
```

C++/WinRT には、これらの例外クラスが用意されています。

| 例外の型 | 基本クラス | HRESULT |
| ---- | ---- | ---- |
| [**winrt::hresult_error**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error) | | [  **hresult_error::to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) 呼び出し |
| [**winrt::hresult_access_denied**](/uwp/cpp-ref-for-winrt/error-handling/hresult-access-denied) | **winrt::hresult_error** | E_ACCESSDENIED |
| [**winrt::hresult_canceled**](/uwp/cpp-ref-for-winrt/error-handling/hresult-canceled) | **winrt::hresult_error** | ERROR_CANCELLED |
| [**winrt::hresult_changed_state**](/uwp/cpp-ref-for-winrt/error-handling/hresult-changed-state) | **winrt::hresult_error** | E_CHANGED_STATE |
| [**winrt::hresult_class_not_available**](/uwp/cpp-ref-for-winrt/error-handling/hresult-class-not-available) | **winrt::hresult_error** | CLASS_E_CLASSNOTAVAILABLE |
| [**winrt::hresult_illegal_delegate_assignment**](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-delegate-assignment) | **winrt::hresult_error** | E_ILLEGAL_DELEGATE_ASSIGNMENT |
| [**winrt::hresult_illegal_method_call**](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-method-call) | **winrt::hresult_error** | E_ILLEGAL_METHOD_CALL |
| [**winrt::hresult_illegal_state_change**](/uwp/cpp-ref-for-winrt/error-handling/hresult-illegal-state-change) | **winrt::hresult_error** | E_ILLEGAL_STATE_CHANGE |
| [**winrt::hresult_invalid_argument**](/uwp/cpp-ref-for-winrt/error-handling/hresult-invalid-argument) | **winrt::hresult_error** | E_INVALIDARG |
| [**winrt::hresult_no_interface**](/uwp/cpp-ref-for-winrt/error-handling/hresult-no-interface) | **winrt::hresult_error** | E_NOINTERFACE |
| [**winrt::hresult_not_implemented**](/uwp/cpp-ref-for-winrt/error-handling/hresult-not-implemented) | **winrt::hresult_error** | E_NOTIMPL |
| [**winrt::hresult_out_of_bounds**](/uwp/cpp-ref-for-winrt/error-handling/hresult-out-of-bounds) | **winrt::hresult_error** | E_BOUNDS |
| [**winrt::hresult_wrong_thread**](/uwp/cpp-ref-for-winrt/error-handling/hresult-wrong-thread) | **winrt::hresult_error** | RPC_E_WRONG_THREAD |

各クラスは (**hresult_error** 基本クラスを介して)、エラーの HRESULT を返す [**to_abi**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrortoabi-function) 関数を指定し、その HRESULT の文字列表現を返す [**message**](/uwp/cpp-ref-for-winrt/error-handling/hresult-error#hresulterrormessage-function) 関数を指定します。

C++/CX で例外をスローする例を次に示します。

```cppcx
throw ref new Platform::InvalidArgumentException(L"A valid User is required");
```

また、C++/WinRT での同等のコードは次のとおりです。

```cppwinrt
throw winrt::hresult_invalid_argument{ L"A valid User is required" };
```

### <a name="port-platformobject-to-winrtwindowsfoundationiinspectable"></a>ポート**platform::object\^** に**winrt::Windows::Foundation::IInspectable**
すべての C++/WinRT 型と同様に、**winrt::Windows::Foundation::IInspectable** は値の型です。 その型の変数を null に初期化する方法は次のとおりです。

```cppwinrt
winrt::Windows::Foundation::IInspectable var{ nullptr };
```

### <a name="port-platformstring-to-winrthstring"></a>ポート**platform::string\^** に**winrt::hstring**
**Platform::string\^** は Windows ランタイム HSTRING ABI の型に相当します。 C++/WinRT では、同等の型は [**winrt::hstring**](/uwp/cpp-ref-for-winrt/hstring) です。 ただし、C++/WinRT では、**std::wstring** などの C++ 標準ライブラリのワイド文字列型、およびワイド文字列リテラルを使用して Windows ランタイム API を呼び出すことができます。 詳細とコード例については、「[C++/WinRT での文字列の処理](strings.md)」を参照してください。

C++/cli CX にアクセスできます、 [ **Platform::String::Data** ](https://docs.microsoft.com/en-us/cpp/cppcx/platform-string-class#data) C スタイルとして文字列を取得するプロパティ**const wchar_t\***  (たとえば、通過するための配列**std::wcout**)。

```cppcx
auto var{ titleRecord->TitleName->Data() };
```

C++/WinRT で同じ操作を行うには、[**hstring::c_str**](/uwp/api/windows.foundation.uri.-ctor#Windows_Foundation_Uri__ctor_System_String_) 関数を使用して null で終了する C スタイルの文字列バージョンを取得します。これは **std::wstring** から取得する場合と同様です。

```cppwinrt
auto var{ titleRecord.TitleName().c_str() };
```

実行したり、文字列を返す Api を実装する際に通常を変更する、C +/cli/CX コードを使用する**platform::string\^** を使用する**winrt::hstring**代わりにします。

文字列を取る C++/CX API の例を次に示します。

```cppcx
void LogWrapLine(Platform::String^ str);
```

C++/WinRT では、次のようにその API を [MIDL 3.0](/uwp/midl-3) で宣言できます。

```idl
// LogType.idl
void LogWrapLine(String str);
```

次に C++/WinRT ツール チェーンは次のようなソース コードを生成します。

```cppwinrt
void LogWrapLine(winrt::hstring const& str);
```

#### <a name="tostring"></a>ToString()

C + + CX の提供、 [object::tostring](/cpp/cppcx/platform-object-class?view=vs-2017#tostring)メソッド。

```cppcx
int i{ 2 };
auto s{ i.ToString() }; // s is a Platform::String^ with value L"2".
```

C +/cli WinRT がこの機能を提供して直接いませんが、代替にすることができます。

```cppwinrt
int i{ 2 };
auto s{ std::to_wstring(i) }; // s is a std::wstring with value L"2".
```

## <a name="important-apis"></a>重要な API
* [winrt::delegate 構造体のテンプレート](/uwp/cpp-ref-for-winrt/delegate)
* [winrt::hresult_error 構造体](/uwp/cpp-ref-for-winrt/error-handling/hresult-error)
* [winrt::hstring 構造体](/uwp/cpp-ref-for-winrt/hstring)
* [winrt 名前空間](/uwp/cpp-ref-for-winrt/winrt)

## <a name="related-topics"></a>関連トピック
* [C++/CX](/cpp/cppcx/visual-c-language-reference-c-cx)
* [C + でのイベントを作成/cli WinRT](author-events.md)
* [同時実行と非同期操作を C +/cli WinRT](concurrency.md)
* [C++/WinRT で API を使用する](consume-apis.md)
* [C + でデリゲートを使用してイベントを処理/cli WinRT](handle-events.md)
* [C++/WinRT と C++/CX 間の相互運用](interop-winrt-cx.md)
* [Microsoft インターフェイス定義言語の 3.0 の参照](/uwp/midl-3)
* [WRL から C++/WinRT への移行](move-to-winrt-from-wrl.md)
* [文字列処理 c++/cli WinRT](strings.md)
