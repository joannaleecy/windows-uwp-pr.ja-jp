---
description: このトピックにある現象のトラブルシューティングおよび対処法に関する表は、新しいコードを作成しているか既存のアプリを移植しているかにはかかわらず役立つ可能性があります。
title: C++/WinRT に関する問題のトラブルシューティング
ms.date: 05/07/2018
ms.topic: article
keywords: Windows 10、uwp、標準、c++、cpp、winrt、プロジェクション、トラブルシューティング、HRESULT、エラー
ms.localizationpriority: medium
ms.openlocfilehash: 3158c257738e68d74feefda99a9171d25a63fdde
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57606327"
---
# <a name="troubleshooting-cwinrt-issues"></a>C++/WinRT に関する問題のトラブルシューティング

> [!NOTE]
> インストールと使用について、 [C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/intro-to-using-cpp-with-winrt) Visual Studio Extension (VSIX) (プロジェクト テンプレートのサポートを提供します) を参照してください[Visual Studio のサポートを c++/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)。

このトピックは、すぐに認識していただくための先行情報です。まだ必要としていない場合も同様です。 以下の症状のトラブルシューティングおよび対処法に関する表は、新しいコードを作成しているか既存のアプリを移植しているかにはかかわらず役立つ可能性があります。 移植中であり、進展させてプロジェクトのビルドおよび実行の段階に達することを急いでいる場合は、問題を引き起こしている重要でないコードにコメントアウトまたはスタブ挿入を適用して、一時的に進展させることができます。その後、元に戻ってその借りを解消することになります。

よく寄せられる質問の一覧は、[よく寄せられる質問](faq.md)を参照してください。

## <a name="tracking-down-xaml-issues"></a>XAML に関する問題の検出
XAML 解析例外は診断が難しい場合があります。特に、わかりやすいエラー メッセージが例外に含まれていない場合は、診断が難しくなります。 デバッガーが初回例外をキャッチするように構成されていることを確してください (早い段階で解析例外のキャッチを試行するため)。 デバッガーで例外変数を調べて、HRESULT やメッセージ内に役立つ情報が含まれているかどうかを確認できます。 また、XAML パーサーを使って、Visual Studio の出力ウィンドウを調べ、エラー メッセージの出力を確認することもできます。

アプリが終了し、XAML マークアップの解析中に処理不能な例外がスローされたことのみがわかっている場合、存在しないリソースへの (キーによる) 参照の結果である可能性があります。 または、UserControl、カスタム コントロール、カスタム レイアウト パネルの内部で例外がスローされたことも考えられます。 最終手段として、バイナリ分割を使うことができます。 XAML ページからマークアップのおよそ半分を削除し、アプリを再実行します。 これによって、エラーが削除した半分で発生しているか (いずれの場合でも、削除した部分はここで元に戻す必要があります)、または削除しなかった半分で発生しているかがわかります。 問題が特定されるまで、エラーを含む半分をさらに分割するプロセスを繰り返します。

## <a name="symptoms-and-remedies"></a>現象と対処法
| 現象 | 対処法 |
|---------|--------|
| 実行時に REGDB_E_CLASSNOTREGISTERED の HRESULT 値で例外がスローされます。 | このエラーの原因の 1 つは、Windows ランタイム コンポーネントを読み込むことができないことです。 コンポーネントの Windows ランタイム メタデータ ファイル (`.winmd`) の名前がコンポーネント バイナリ (`.dll`) の名前と同じであることを確認してください。この名前は、プロジェクトの名前、およびルート名前空間の名前でもあります。 また、Windows ランタイム メタデータとバイナリが、ビルド プロセスによって使用中のアプリの `Appx` フォルダに正しくコピーされていることを確認してください。 さらに、使用中のアプリの `AppxManifest.xml` (および `Appx` フォルダ内) に、アクティブ化可能なクラスとバイナリ名を正しく宣言している **&lt;InProcessServer&gt;** 要素が含まれていることを確認してください。 このエラーは、ローカルに実装されたランタイム クラスが、プロジェクションされた型の既定のコンストラクターによって誤ってインスタンス化された場合にも発生する可能性があります。 その場合にプロジェクションされた型を正しく使用する方法の詳細については、「[XAML コントロール、C++/WinRT プロパティへのバインド](binding-property.md)」を参照してください。 |
| C++ コンパイラーは、"*'implements_type': は、'&lt;プロジェクションされた型&gt;'* の直接的または間接的な基底クラスのメンバーではありません" というエラーを生成します。 | これは、実装型 (たとえば **MyRuntimeClass**) の未修飾名前空間名を使用して、その型のヘッダーを含めずに **make** を呼び出すと発生する可能性があります。 コンパイラーは、**MyRuntimeClass** をプロジェクションされた型として解釈します。 解決策は、実装型のヘッダーを含めることです (たとえば `MyRuntimeClass.h`)。 |
| C++ コンパイラーが、"*削除された関数を参照しようとしています*" というエラーを生成します。 | これは、**make** を呼び出し、テンプレート パラメーターとして渡す実装型の既定のコンストラクターが `= delete` である場合に発生する可能性があります。 実装型のヘッダー ファイルを編集し、`= delete` を `= default` に変更してください。 ランタイム クラスの IDL にコンストラクターを追加することもできます。 |
| [  **INotifyPropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged) を実装しましたが、XAML バインドが更新されません (そのため、UI が [**PropertyChanged**](/uwp/api/windows.ui.xaml.data.inotifypropertychanged.PropertyChanged) にサブスクライブしません)。 | XAML マークアップのバインド式で必ず `Mode=OneWay` (または TwoWay) を設定してください。 「[XAML コントロール: C++/WinRT プロパティへのバインド](binding-property.md)」を参照してください。 |
| XAML アイテム コントロールを監視可能なコレクションにバインドしていますが、実行時に "パラメーターが正しくありません" というメッセージで例外がスローされます。 | IDL および実装で、監視可能なコレクションを型 **Windows.Foundation.Collections.IVector<IInspectable>** として宣言します。 ただし、**Windows.Foundation.Collections.IObservableVector<T>** を実装するオブジェクトを返します。T は要素型です。 「[XAML アイテム コントロール: C++/WinRT コレクションへのバインド](binding-collection.md)」を参照してください。  |
| C++ コンパイラーが、"*'MyImplementationType_base&lt;MyImplementationType&gt;': 使用可能な適切な既定コンストラクターがありません*" という形式のエラーを生成します。|これは、非自明なコンストラクターを持つ型から派生させた場合に発生する可能性があります。 派生型のコンストラクターは、基本型のコンストラクターが必要とするパラメーターを渡す必要があります。 実証済みの例については、「[非自明なコンストラクタを持つ型からの派生](author-apis.md#deriving-from-a-type-that-has-a-non-default-constructor)」を参照してください。|
| C++ コンパイラーが、"*'const std::vector&lt;std::wstring,std::allocator&lt;_Ty&gt;&gt;' から 'const winrt::param::async_iterable&lt;winrt::hstring&gt; &'* に変換できません" というエラーを生成します。|これは、コレクションを予期している Windows ランタイム API に std::wstring の std::vector を渡すときに発生する可能性があります。 詳細については、「[標準的な C++ のデータ型と C++/WinRT](std-cpp-data-types.md)」を参照してください。|
| C++ コンパイラーが、"*'const std::vector&lt;winrt::hstring,std::allocator&lt;_Ty&gt;&gt;' から 'const winrt::param::async_iterable&lt;winrt::hstring&gt; &'* に変換できません" というエラーを生成します。|これは、コレクションを予期している非同期 Windows ランタイム API に winrt::hstring の std::vector を渡すときに、非同期呼び出し先へのベクトルのコピーも移動も行っていない場合に発生する可能性があります。 詳細については、「[標準的な C++ のデータ型と C++/WinRT](std-cpp-data-types.md)」を参照してください。|
| プロジェクトを開くときに、Visual Studio が "*プロジェクトのアプリケーションはインストールされていません*" というエラーを生成します。|まだ行っていない場合は、Visual Studio の **[新しいプロジェクト]** ダイアログから **C++ での開発用の Windows ユニバーサル ツール**をインストールする必要があります。 問題が解決されないかどうかは、c++ に依存プロジェクト/cli WinRT Visual Studio Extension (VSIX) (を参照してください[Visual Studio のサポートの C +/cli WinRT](intro-to-using-cpp-with-winrt.md#visual-studio-support-for-cwinrt-xaml-the-vsix-extension-and-the-nuget-package)します。|
| Windows アプリ認定キット テストは、いずれかのランタイム クラスのエラーを生成"*Windows の基本クラスから派生していません。すべての構成可能なクラスは、最終的に Windows 名前空間内の型から派生する必要があります*"。|呼ばれます (つまり、アプリケーション内で宣言した) ランタイムのクラスで、基底クラスから派生した、*コンポーザブル*クラス。 コンポーザブルなクラスの基本クラスは、Windows.* 名前空間で生成された型である必要があります。たとえば、 [ **Windows.UI.Xaml.DependencyObject**](/uwp/api/windows.ui.xaml.dependencyobject)します。 参照してください[XAML コントロール; バインド C +/cli WinRT プロパティ](binding-property.md)の詳細。|
| C++ コンパイラーが、EventHandler または TypedEventHandler のデリゲート特殊化に関して "*WinRT 型である必要があります*" というエラーを生成します。|代わりに **winrt::delegate&lt;...T&gt;** を使用することを考慮してください。 「[C++/WinRT でのイベントの作成](author-events.md)」を参照してください。|
| C++ コンパイラーが、Windows ランタイムの非同期操作の特殊化に関して "*WinRT 型である必要があります*" というエラーを生成します。|代わりに並列パターン ライブラリ (PPL) の [**task**](https://msdn.microsoft.com/library/hh750113) を返すことを考慮してください。 「[同時実行操作と非同期操作](concurrency.md)」を参照してください。|
| C++ コンパイラーが、"*エラー C2220: 警告がエラーとして扱われました - 'オブジェクト' ファイルは生成されませんでした*" を生成します。|警告を修正するか、設定**C/C++** > **全般** > **警告をエラーとして扱う**に**いいえ (/WX-)** します。|
| オブジェクトが破棄された後で C++/WinRT オブジェクトのイベント ハンドラーが呼び出されるため、アプリがクラッシュします。|参照してください[安全にアクセスする、*この*イベント処理デリゲートを使用してポインター](weak-references.md#safely-accessing-the-this-pointer-with-an-event-handling-delegate)します。|
| C++ コンパイラは"*エラー C2338:これは、弱い参照のサポートにのみ*"。|**テンプレート引数として winrt::no_weak_ref** マーカー構造体を基底クラスに渡した型の、弱参照を要求しています。 参照してください[弱い参照のサポートを無効にする](weak-references.md#opting-out-of-weak-reference-support)します。|
| C++ リンカーの生成"*エラー lnk2019 が発生します。未解決の外部シンボル*"|参照してください[理由は、リンカーを与えてくれた、"LNK2019:未解決の外部シンボル"エラーでしょうか](faq.md#why-is-the-linker-giving-me-a-lnk2019-unresolved-external-symbol-error).|
| LLVM と Clang ツール チェーン C + を使用すると、エラーが発生する/cli WinRT します。|C++ LLVM と Clang ツール チェーンはサポートされていません/cli の使用方法、内部的には、エミュレートする場合に、WinRT して試して実験で説明されているものなど[C + を使用してコンパイルする LLVM/Clang を使用できます/cli WinRT?](faq.md#can-i-use-llvmclang-to-compile-with-cwinrt)します。|
| C++ コンパイラが生成されます"*いない利用可能な適切な既定コンス トラクター*"射影された型。 | ランタイム クラスのオブジェクトの初期化を遅延またはを使用し、同じプロジェクト内のランタイム クラスを実装しているかどうかを呼び出す必要があります、`nullptr_t`コンス トラクター。 詳細については、「[C++/WinRT での API の使用](consume-apis.md)」を参照してください。 |
| C++ コンパイラは"*エラー C3861: 'from_abi': 識別子が見つかりません*"、およびその他のエラーから発信される*base.h*します。 Visual Studio 2017 を使用している場合は、このエラーを表示可能性があります (バージョン 15.8.0 またはそれ以降)、Windows SDK バージョン 10.0.17134.0 (Windows 10、バージョン 1803) を対象とするとします。 | いずれかのターゲット以降 (詳細について準拠) のバージョンの Windows SDK、またはプロジェクトのプロパティを設定**C/C++** > **言語** > **準拠モード。いいえ**(また場合、 **/permissive -** プロジェクト プロパティに表示されます**C/C++** > **言語** > **コマンドライン** **追加オプション**から削除します)。 |
| C++ コンパイラは"*エラー C2039:'IUnknown': のメンバーではない '\`グローバル名前空間'*"。 | 参照してください[方法の再ターゲットすると、C +/cli WinRT プロジェクトは、以降のバージョンの Windows SDK を](news.md#how-to-retarget-your-cwinrt-project-to-a-later-version-of-the-windows-sdk)します。 |
| C++ リンカーの生成"*エラー LNK2019: 未解決の外部シンボル_WINRT_CanUnloadNow@0関数で参照されている_VSDesignerCanUnloadNow@0* " | 参照してください[方法の再ターゲットすると、C +/cli WinRT プロジェクトは、以降のバージョンの Windows SDK を](news.md#how-to-retarget-your-cwinrt-project-to-a-later-version-of-the-windows-sdk)します。 |
| ビルド プロセスには、エラー メッセージが生成される*C+/cli WinRT VSIX プロジェクトのビルドのサポートは提供されなくなりました。Microsoft.Windows.CppWinRT Nuget パッケージへの参照をプロジェクトに追加してください*します。 | インストール、 **Microsoft.Windows.CppWinRT**をプロジェクトに NuGet パッケージ。 詳細については、[VSIX 拡張機能の以前のバージョン](intro-to-using-cpp-with-winrt.md#earlier-versions-of-the-vsix-extension)を参照してください。 |

> [!NOTE]
> このトピックでは、質問に答えしていないかどうかを参照してくださいヘルプを見つけることがあります、[開発者コミュニティの Visual Studio C](https://developercommunity.visualstudio.com/spaces/62/index.html)、またはを使用して、 [ `c++-winrt` Stack Overflow でタグ付け](https://stackoverflow.com/questions/tagged/c%2b%2b-winrt)します。
