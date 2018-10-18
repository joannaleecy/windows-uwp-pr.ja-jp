---
author: Xansky
Description: Describes the concept of automation peers for Microsoft UI Automation, and how you can provide automation support for your own custom UI class.
ms.assetid: AA8DA53B-FE6E-40AC-9F0A-CB09637C87B4
title: カスタム オートメーション ピア
label: Custom automation peers
template: detail.hbs
ms.author: mhopkins
ms.date: 07/13/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: a2f9caf8519aa76ef9487e5318a238a6e1d53fe2
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/18/2018
ms.locfileid: "4967602"
---
# <a name="custom-automation-peers"></a>カスタム オートメーション ピア  

Microsoft UI オートメーションに対するオートメーション ピアの概念について説明します。また、独自のカスタム UI クラスに対してオートメーションのサポートを提供する方法についても説明します。

UI オートメーションにより、オートメーション クライアントが多様な UI プラットフォームやフレームワークのユーザー インターフェイスを検証、または操作するときに利用できるフレームワークが提供されます。 ユニバーサル Windows プラットフォーム (UWP) アプリを作っている場合は、UI で使うクラスによって既に UI オートメーション サポートが提供されています。 既にある非シール クラスから派生させて、新しい種類の UI コントロールやサポート クラスを定義することもできます。 これを行う手順の間に、既定の UI オートメーション サポートでは対応していないがアクセシビリティ サポートを必要とする動作が、クラスによって追加されることがあります。 この場合は、まず基本実装で使った [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) クラスを派生させ、ピアの実装に必要なサポートを追加した後、ユニバーサル Windows プラットフォーム (UWP) コントロールのインフラストラクチャに対し、新しいピアを作る必要があることを通知することにより、既存の UI オートメーション サポートを拡張する必要があります。

UI オートメーションにより、スクリーン リーダーなどのアクセシビリティ アプリや支援技術だけでなく、品質保証 (テスト) コードも有効になります。 いずれのシナリオについても、UI オートメーション クライアントでは、ユーザー インターフェイス要素を検証し、アプリの外部の他のコードからアプリに対するユーザー操作のシミュレーションを行うことができます。 すべてのプラットフォームを対象とした UI オートメーション、およびその広範な意味については、「[UI オートメーションの概要](https://msdn.microsoft.com/library/windows/desktop/Ee684076)」をご覧ください。

UI オートメーション フレームワークは次の 2 種類のオーディエンスによって使われます。

* **UI オートメーション *クライアント*** 現在ユーザーに表示されているすべての UI に関する情報を取得するために UI オートメーション API を呼び出します。 たとえば、スクリーン リーダーなどの支援技術は UI オートメーション クライアントとして機能します。 UI は、関連するオートメーション要素のツリーとして提示されます。 UI オートメーション クライアントの関心の対象は、一度に 1 つのアプリに限定される場合もあれば、ツリー全体である場合もあります。 UI オートメーション クライアントは、UI オートメーション API を使ってツリーを操作して、オートメーション要素の情報を読み上げたり変更したりできます。
* **UI オートメーション *プロバイダー*** アプリの一部として導入された UI の要素を公開する API を実装して、UI オートメーション ツリーに情報を提供します。 新しいコントロールを作るときには、UI オートメーション プロバイダーのシナリオの参加者としての役割を果たしてください。 プロバイダーとして配慮する点は、アクセシビリティ目的とテスト目的の両方で、すべての UI オートメーション クライアントが UI オートメーション フレームワークを使ってコントロールを操作できるようにすることです。

UI オートメーション フレームワークには、通常、対応する 2 つの API があります。1 つは UI オートメーション クライアント用の API、もう 1 つは、似た名前を持つ UI オートメーション プロバイダー用の API です。 このトピックでは主に、UI オートメーション プロバイダー用の API、特にこの UI フレームワークでプロバイダーの拡張性を可能にするクラスとインターフェイスについて説明します。 全体像を示すために、UI オートメーション クライアント用の UI オートメーション API に触れる場合もあります。また、クライアントとプロバイダー API の相関関係を示す表も含まれています。 クライアント側から見た説明については、「[UI オートメーション クライアントのプログラマ ガイド](https://msdn.microsoft.com/library/windows/desktop/Ee684021)」をご覧ください。

> [!NOTE]
> UI オートメーション クライアントは通常、マネージ コードを使用せず、UWP アプリ (一般にはデスクトップ アプリ) としては実装されません。 UI オートメーションは、特定の実装またはフレームワークではなく、標準に基づいています。 スクリーン リーダーなどの支援技術製品を含め、多くの既存の UI オートメーション クライアントは、コンポーネント オブジェクト モデル (COM) インターフェイスを使って UI オートメーション、システム、子ウィンドウで実行するアプリを操作します。 COM インターフェイスの情報と COM を使った UI オートメーション クライアントの作成方法について詳しくは、「[UI オートメーションの基礎](https://msdn.microsoft.com/library/windows/desktop/Ee684007)」をご覧ください。

<span id="Determining_the_existing_state_of_UI_Automation_support_for_your_custom_UI_class"/>
<span id="determining_the_existing_state_of_ui_automation_support_for_your_custom_ui_class"/>
<span id="DETERMINING_THE_EXISTING_STATE_OF_UI_AUTOMATION_SUPPORT_FOR_YOUR_CUSTOM_UI_CLASS"/>

## <a name="determining-the-existing-state-of-ui-automation-support-for-your-custom-ui-class"></a>カスタム UI クラスに対する UI オートメーション サポートの既存状態の特定  
カスタム コントロールに対するオートメーション ピアを実装する前にまず、基底クラスとそのオートメーション ピアによって、必要なアクセシビリティやオートメーションのサポートが既に提供されているかどうかをテストする必要があります。 多くの場合、[**FrameworkElementAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242472) の実装、特定のピア、および実装するパターンを組み合わせれば、基本的だが十分なアクセシビリティ エクスペリエンスが確保されます。 これが当てはまるかどうかは、コントロールと対応する基底クラスに対するオブジェクト モデルの公開に対し、どの程度変更を加えたかによって異なります。 また、基底クラス機能に対する追加がテンプレート コントラクト中の新しい UI 要素、またはコントロールの外観のどちらに対応しているかにも依存します。 状況によっては、それらの変更により、追加的なアクセシビリティ サポートが必要になる新しい側面を伴うユーザー エクスペリエンスが導入される可能性があります。

既にある基本ピア クラスを使って基本的なアクセシビリティ サポートを確保できる場合でも、自動テストのシナリオで UI オートメーションに正確な **ClassName** 情報を報告できるように、ピアを定義することをお勧めします。 これは、第三者が使うコントロールを作る場合には特に重要になります。

<span id="Automation_peer_classes__"/>
<span id="automation_peer_classes__"/>
<span id="AUTOMATION_PEER_CLASSES__"/>

## <a name="automation-peer-classes"></a>オートメーション ピア クラス  
UWP は、Windows フォーム、Windows Presentation Foundation (WPF)、Microsoft Silverlight などの従来のマネージ コードによる UI フレームワークで使われていた既存の UI オートメーションに伴う手法と慣例に基づいて構築されています。 コントロール クラス、各関数、およびその用途の多くが、従来の UI フレームワークを起源としています。

ピア クラスの名前は、慣例に従い、コントロール クラス名から始まり、"AutomationPeer" で終わります。 たとえば、[**ButtonAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242458) は、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) コントロール クラスのピア クラスです。

> [!NOTE]
> ここでは、このトピックの目的に合わせて、アクセシビリティに関連するプロパティを、コントロール ピアを実装するときの重要な要素として扱っています。 UI オートメーション サポートのより一般的な概念と、ピアを実装する際の推奨事項については、「[UI オートメーション プロバイダーのプログラマ ガイド](https://msdn.microsoft.com/library/windows/desktop/Ee671596)」と「[UI オートメーションの基礎](https://msdn.microsoft.com/library/windows/desktop/Ee684007)」をご覧ください。 これらのトピックには、UWP フレームワークの情報を UI オートメーションに提供するために使う個々の [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) API の情報は含まれていませんが、クラスを識別したりその他の情報や対話式操作を提供したりするプロパティの情報が含まれています。

<span id="Peers__patterns_and_control_types"/>
<span id="peers__patterns_and_control_types"/>
<span id="PEERS__PATTERNS_AND_CONTROL_TYPES"/>

## <a name="peers-patterns-and-control-types"></a>ピア、パターン、コントロール型  
*コントロール パターン*は、コントロールの機能に関する特定の側面を UI オートメーション クライアントに公開するインターフェイス実装です。 UI オートメーション クライアントでは、コントロール パターンによって公開されたプロパティやメソッドを使って、コントロールの機能に関する情報を取得したり、実行時にコントロールの動作を操作したりします。

コントロール パターンは、コントロール型やコントロールの外観に関係なくコントロールの機能を分類したり公開したりするための方法を提供します。 たとえば、表形式のインターフェイスを表示するコントロールでは、**Grid** コントロール パターンを使って、表中の行と列の数を公開します。これにより UI オートメーション クライアント側では、表中の項目を取得できるようになります。 ほかにもさまざまなコントロール パターンがあります。たとえば、**Invoke** コントロール パターンは、UI オートメーション クライアントでボタンなどの起動可能なコントロールに使います。また **Scroll** コントロール パターンは、リスト ボックス、リスト ビュー、コンボ ボックスなどのスクロール バーを含むコントロールに使います。 各コントロール パターンは、それぞれ個別の機能に対応します。複数のコントロール パターンを組み合わせることにより、特定のコントロールでサポートする全体的な機能セットを記述することもできます。

コントロール パターンと UI の関係は、インターフェイスと COM オブジェクトの関係に似ています。 COM では、サポートしているインターフェイスをオブジェクトに問い合わせて、それらのインターフェイスを使って機能にアクセスできます。 UI オートメーションでは、UI オートメーション クライアントが UI オートメーション要素にどのコントロール パターンがサポートされているかを照会し、サポートされているコントロール パターンによって公開されるプロパティ、メソッド、イベント、構造体を使って、要素とそのピア対象のコントロールを操作できます。

オートメーション ピアの主な目的の 1 つは、UI 要素がそのピアを通じてどのコントロール パターンをサポートできるのかを UI オートメーション クライアントに伝えることです。 そのために、UI オートメーション プロバイダーは、[**GetPatternCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpatterncore) メソッドを上書きして [**GetPattern**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpattern) メソッドの動作を変更する新しいピアを実装しています。 UI オートメーション クライアントは、UI オートメーション プロバイダーを呼び出し元の **GetPattern** にマップする呼び出しを実行します。 UI オートメーション クライアントは、操作する個々の具体的なパターンを照会します。 ピアでパターンがサポートされる場合は、パターンへのオブジェクト参照が返されます。サポートされない場合は、**null** が返されます。 **null** 以外が返された場合、UI オートメーション クライアントでは、そのコントロール パターンとやり取りするために、クライアントとしてパターン インターフェイスの API を呼び出すことができると想定します。

*コントロール型*は、ピアによって表されるコントロールの機能を広く定義する手段です。 これはコントロール パターンとは異なる概念です。パターンでは、特定のインターフェイスを通じて取得できる情報や実行できる操作を UI オートメーションに通知しますが、コントロール型は、それよりも 1 つ上のレベルに位置するものです。 各コントロール型には、UI オートメーションの次の側面に関するガイダンスが含まれています。

* UI オートメーション コントロール パターン: コントロール型によっては、異なる分類の情報や操作を表す複数のパターンをサポートしている場合があります。 各コントロール型には、そのコントロールでサポートする必要のあるコントロール パターンのセット、省略可能なセット、コントロールでサポートしてはいけないセットがあります。
* UI オートメーション プロパティ値: 各コントロール型には、そのコントロールでサポートする必要のあるプロパティのセットがあります。 これらは、「[UI オートメーション プロパティの概要](https://msdn.microsoft.com/library/windows/desktop/Ee671594)」で説明されている全般的なプロパティであり、パターン固有のプロパティではありません。
* UI オートメーション イベント: 各コントロール型には、そのコントロールでサポートする必要のあるイベントのセットがあります。 これらも、「[UI オートメーション イベントの概要](https://msdn.microsoft.com/library/windows/desktop/Ee671221)」で説明されている全般的なイベントであり、パターン固有のものではありません。
* UI オートメーション ツリー構造: 各コントロール型は、そのコントロールが UI コントロール ツリー構造にどのように現れるかを定義します。

フレームワークのオートメーション ピアの実装方法にかかわらず、UI オートメーション クライアントの機能は、UWP に縛られるものではありません。実際、支援技術などの既にある UI オートメーション クライアントでは、COM などの他のプログラミング モデルが使われていることがよくあります。 COM では、クライアントから **QueryInterface** を呼び出すことで、必要なパターンや、プロパティ、イベント、またはツリーの検査のための一般的な UI オートメーション フレームワークを実装する COM コントロール パターン インターフェイスを取得できます。 パターンの場合は、そのインターフェイス コードが、UI オートメーション フレームワークにより、アプリの UI オートメーション プロバイダーとその関連ピアに対して実行されている UWP コードにマーシャリングされます。

C\# または Microsoft Visual Basic を使った UWP アプリなど、マネージ コードのフレームワークに対するコントロール パターンを実装すると、COM インターフェイスの表現ではなく、.NET Framework インターフェイスを使って、各パターンを表すことができます。 たとえば、**Invoke** というパターンの Microsoft .NET プロバイダーによる実装に対応した UI オートメーション パターン インターフェイスは、[**IInvokeProvider**](https://msdn.microsoft.com/library/windows/apps/BR242582) となります。

コントロール パターン、プロバイダー インターフェイス、それらの目的の一覧については、「[コントロール パターンとインターフェイス](control-patterns-and-interfaces.md)」をご覧ください。 コントロール型の一覧については、「[UI オートメーション コントロール型の概要](https://msdn.microsoft.com/library/windows/desktop/Ee671197)」を参照してください。

<span id="Guidance_for_how_to_implement_control_patterns"/>
<span id="guidance_for_how_to_implement_control_patterns"/>
<span id="GUIDANCE_FOR_HOW_TO_IMPLEMENT_CONTROL_PATTERNS"/>

### <a name="guidance-for-how-to-implement-control-patterns"></a>コントロール パターンの実装方法に関するガイダンス  
コントロール パターンとその用途は、より広範囲にわたる UI オートメーション フレームワークの定義の一部であり、UWP アプリのアクセシビリティ サポートに適用されるだけにとどまりません。 コントロール パターンを実装するときは、MSDN に説明されているガイダンスに従っていることを確かめる必要があります。このガイダンスは UI オートメーション仕様にも含まれています。 通常、ガイダンスが必要な場合は MSDN のトピックを使うことができ、仕様を参照する必要はありません。 各パターンのガイダンスは、「[UI オートメーション コントロール パターンの実装](https://msdn.microsoft.com/library/windows/desktop/Ee671292)」で説明されています。 この分野の各トピックには、「実装のガイドラインと規則」と「必須メンバー」というセクションが含まれています。 ガイダンスは、通常、「[プロバイダー向けコントロール パターン インターフェイス](https://msdn.microsoft.com/library/windows/desktop/Ee671201)」リファレンスにある関連するコントロール パターン インターフェイスの特定の API を参照しています。 これらのインターフェイスはネイティブ/COM インターフェイスです (API では COM 形式の構文が使われます)。 ただし、いずれも [**Windows.UI.Xaml.Automation.Provider**](https://msdn.microsoft.com/library/windows/apps/BR209225) 名前空間に同等のものが用意されています。

既定のオートメーション ピアを使ってその動作を拡張している場合、それらのピアは、既に UI オートメーション ガイドラインに準拠するように記述されています。 それらのピアがコントロール パターンをサポートしている場合は、そのパターン サポートを使えば、「[UI オートメーション コントロール パターンの実装](https://msdn.microsoft.com/library/windows/desktop/Ee671292)」のガイダンスに従うことができます。 コントロール ピアが自身を UI オートメーションで定義されるコントロール型の表現として報告する場合、そのピアは「[UI オートメーション コントロール型](https://msdn.microsoft.com/library/windows/desktop/Ee671633)」のガイダンスに従っていることになります。

ただし、UI オートメーションの推奨事項に従ってピアを実装するためには、コントロール パターンやコントロール型に関する追加のガイダンスが必要になることもあります。 これは特に、まだ UWP コントロールに既定の実装として含まれていないパターンやコントロール型のサポートを実装する場合に当てはまります。 たとえば、既定の XAML コントロールには、いずれも注釈のパターンは実装されていません。 しかし、注釈を広く利用するアプリを作っている場合は、この機能を表面に押し出してアクセスしやすくすると便利です。 このようなシナリオでは、ピアで [**IAnnotationProvider**](https://msdn.microsoft.com/library/windows/apps/Hh738493) を実装し、適切なプロパティを持つ **Document** コントロール型として自身を報告して、ドキュメントが注釈をサポートしていることを示します。

「[UI オートメーション コントロール パターンの実装](https://msdn.microsoft.com/library/windows/desktop/Ee671292)」で説明されているパターンに関するガイダンス、または「[UI オートメーション コントロール型のサポート](https://msdn.microsoft.com/library/windows/desktop/Ee671633)」で説明されているコントロール型に関するガイダンスを、方向性を示す全般的なガイダンスとして使うことをお勧めします。 各 API の目的に関する説明や注意事項については、その API のリンク先をご覧ください。 ただし、UWP アプリのプログラミングに必要な構文について詳しくは、[**Windows.UI.Xaml.Automation.Provider**](https://msdn.microsoft.com/library/windows/apps/BR209225) 名前空間にある同等の API を検索して、そのリファレンス ページをご覧ください。

<span id="Built-in_automation_peer_classes"/>
<span id="built-in_automation_peer_classes"/>
<span id="BUILT-IN_AUTOMATION_PEER_CLASSES"/>

## <a name="built-in-automation-peer-classes"></a>ビルトイン オートメーション ピア クラス  
通常、UI 要素でユーザーからの UI アクティビティを受け入れる場合や、アプリの対話型の UI や意味のある UI を表す支援技術のユーザーが必要とする情報が要素の中に存在する場合は、要素によってオートメーション ピア クラスを実装します。 UWP のすべてのビジュアル要素にオートメーション ピアがあるわけではありません。 オートメーション ピアを実装するクラスの例として、[**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) や [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) があります。 一方、オートメーション ピアを実装しないクラスの例として、[**Border**](https://msdn.microsoft.com/library/windows/apps/BR209250) のほか、[**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) や [**Canvas**](https://msdn.microsoft.com/library/windows/apps/BR209267) など [**Panel**](https://msdn.microsoft.com/library/windows/apps/BR227511) ベースのクラスがあります。 **Panel** にはピアはありません。これは、ビジュアル専用のレイアウト動作が提供され、 ユーザーが **Panel** とやり取りするためのアクセシビリティに関連する方法がないためです。 代わりに、**Panel** に含まれる子要素はいずれも UI オートメーション ツリーに対し、ピアまたは要素の表現が存在するツリー中で次に利用できる親の子要素として報告されます。

<span id="UI_Automation_and_UWP_process_boundaries"/>
<span id="ui_automation_and_uwp_process_boundaries"/>
<span id="UI_AUTOMATION_AND_UWP_PROCESS_BOUNDARIES"/>

## <a name="ui-automation-and-uwp-process-boundaries"></a>UI オートメーションと UWP のプロセス境界  
UWP アプリにアクセスする UI オートメーション クライアントのコードは、通常はアウトプロセスで実行されます。 UI オートメーション フレームワークのインフラストラクチャを使うと、プロセス境界を越えて情報をやり取りできます。 この概念について詳しくは、「[UI オートメーションの基礎](https://msdn.microsoft.com/library/windows/desktop/Ee684007)」をご覧ください。

<span id="OnCreateAutomationPeer"/>
<span id="oncreateautomationpeer"/>
<span id="ONCREATEAUTOMATIONPEER"/>

## <a name="oncreateautomationpeer"></a>OnCreateAutomationPeer  
[**UIElement**](https://msdn.microsoft.com/library/windows/apps/BR208911) から派生されたクラスにはいずれも、保護された仮想メソッド [**OnCreateAutomationPeer**](https://msdn.microsoft.com/ibrary/windows/apps/windows.ui.xaml.uielement.oncreateautomationpeer) が含まれます。 オートメーション ピアに対するオブジェクト初期化シーケンスでは、**OnCreateAutomationPeer** を呼び出すことにより、個々のコントロールに対するオートメーション ピア オブジェクトを取得します。これにより、UI オートメーション ツリーを構築して実行時に使うことができるようにします。 UI オートメーション コードでは、ピアを使ってコントロールの特性と機能に関する情報を取得し、そのコントロール パターンに基づいて対話型の使用方法をシミュレートできます。 オートメーションをサポートするカスタム コントロールでは、**OnCreateAutomationPeer** を上書きし、[**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) から派生するクラスのインスタンスを返す必要があります。 たとえば、あるカスタム コントロールを [**ButtonBase**](https://msdn.microsoft.com/library/windows/apps/BR227736) クラスから派生させる場合、**OnCreateAutomationPeer** が返すオブジェクトは、[**ButtonBaseAutomationPeer**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.automation.peers.buttonbaseautomationpeer) から派生させる必要があります。

カスタム コントロール クラスを作成し、新しいオートメーション ピアも指定する場合には、ピアの新しいインスタンスが返されるようにするために、カスタム コントロールに関して [**OnCreateAutomationPeer**](https://msdn.microsoft.com/ibrary/windows/apps/windows.ui.xaml.uielement.oncreateautomationpeer) メソッドをオーバーライドする必要があります。 ピア クラスは [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) から直接的または間接的に派生していることが必要です。

たとえば、次のコードでは、カスタム コントロール `NumericUpDown` により UI オートメーション用としてピア `NumericUpDownPeer` を使うことを宣言しています。

```csharp
using Windows.UI.Xaml.Automation.Peers;
...
public class NumericUpDown : RangeBase {
    public NumericUpDown() {
    // other initialization; DefaultStyleKey etc.
    }
    ...
    protected override AutomationPeer OnCreateAutomationPeer()
    {
        return new NumericUpDownAutomationPeer(this);
    }
}
```

```vb
Public Class NumericUpDown
    Inherits RangeBase
    ' other initialization; DefaultStyleKey etc.
       Public Sub New()
       End Sub
       Protected Overrides Function OnCreateAutomationPeer() As AutomationPeer
              Return New NumericUpDownAutomationPeer(Me)
       End Function
End Class
```

```cppwinrt
// NumericUpDown.idl
namespace MyNamespace
{
    runtimeclass NumericUpDown : Windows.UI.Xaml.Controls.Primitives.RangeBase
    {
        NumericUpDown();
        Int32 MyProperty;
    }
}

// NumericUpDown.h
...
struct NumericUpDown : NumericUpDownT<NumericUpDown>
{
    ...
    Windows::UI::Xaml::Automation::Peers::AutomationPeer OnCreateAutomationPeer()
    {
        return winrt::make<MyNamespace::implementation::NumericUpDownAutomationPeer>(*this);
    }
};
```

```cpp
//.h
public ref class NumericUpDown sealed : Windows::UI::Xaml::Controls::Primitives::RangeBase
{
// other initialization not shown
protected:
    virtual AutomationPeer^ OnCreateAutomationPeer() override
    {
         return ref new NumericUpDownAutomationPeer(this);
    }
};
```

> [!NOTE]
> [**OnCreateAutomationPeer**](https://msdn.microsoft.com/ibrary/windows/apps/windows.ui.xaml.uielement.oncreateautomationpeer) の実装では、カスタム オートメーション ピアの新しいインスタンスを初期化して呼び出し元のコントロールを所有者として渡し、そのインスタンスを返すだけにします。 このメソッドで追加のロジックを実行しないでください。 特に、[**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) のデストラクションにつながる可能性のあるロジックが同じ呼び出し内にあると、ランタイムで予期しない動作が発生する場合があります。

[**OnCreateAutomationPeer**](https://msdn.microsoft.com/ibrary/windows/apps/windows.ui.xaml.uielement.oncreateautomationpeer) の典型的な実装の場合、メソッドの上書きは、残りのコントロール クラス定義と同じスコープで行われるため、*owner* は、**this** または **Me** として指定されます。

実際のピア クラスは、コントロールと同じコード ファイル、または別個のコード ファイルで定義できます。 ピア定義はいずれも、ピアを提供するコントロールとは別の [**Windows.UI.Xaml.Automation.Peers**](https://msdn.microsoft.com/library/windows/apps/BR242563) という名前空間に存在します。 独自のピアも、[**OnCreateAutomationPeer**](https://msdn.microsoft.com/ibrary/windows/apps/windows.ui.xaml.uielement.oncreateautomationpeer) メソッドの呼び出しに必要な名前空間を参照している限り、別個の名前空間に宣言できます。

<span id="Choosing_the_correct_peer_base_class"/>
<span id="choosing_the_correct_peer_base_class"/>
<span id="CHOOSING_THE_CORRECT_PEER_BASE_CLASS"/>

### <a name="choosing-the-correct-peer-base-class"></a>正しいピアの基底クラスの選択  
派生元となるコントロール クラスの既存のピア ロジックに合致する基底クラスから [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) を派生させる必要があります。 前の例の場合、[**RangeBase**](https://msdn.microsoft.com/library/windows/apps/BR227863) から `NumericUpDown` が派生されるため、ピアのベースにする必要がある [**RangeBaseAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242506) クラスが使用できます。 コントロール自体の派生方法に最も合致するピア クラスを使うことにより、[**IRangeValueProvider**](https://msdn.microsoft.com/library/windows/apps/BR242590) は既に基本ピア クラスで実装されているため、少なくともその機能の一部は上書きせずに済みます。

基底クラス [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) には、対応するピア クラスがありません。 **Control** から派生させたカスタム コントロールにピア クラスを対応させる場合は、[**FrameworkElementAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242472) からカスタム ピア クラスを派生させます。

[**ContentControl**](https://msdn.microsoft.com/library/windows/apps/BR209365) からクラスを直接派生させる場合、そのクラスには、ピア クラスを参照する [**OnCreateAutomationPeer**](https://msdn.microsoft.com/ibrary/windows/apps/windows.ui.xaml.uielement.oncreateautomationpeer) の実装がないため、既定のオートメーション ピア動作は伴いません。 したがって、**OnCreateAutomationPeer** を実装して独自のピアを使うか、[**FrameworkElementAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242472) をピアとして使います (コントロールにとってこのレベルのアクセシビリティ サポートで十分である場合)。

> [!NOTE]
> 通常、[**FrameworkElementAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242472) ではなく [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) からは派生しません。 **AutomationPeer** から直接派生する場合、それ以外の場合に **FrameworkElementAutomationPeer** から得られる多くの基本的なアクセシビリティ サポートを複製する必要があります。

<span id="Initialization_of_a_custom_peer_class"/>
<span id="initialization_of_a_custom_peer_class"/>
<span id="INITIALIZATION_OF_A_CUSTOM_PEER_CLASS"/>

## <a name="initialization-of-a-custom-peer-class"></a>カスタム ピア クラスの初期化  
オートメーション ピアでは、基底クラスの初期化に所有者コントロールのインスタンスを使うタイプ セーフなコンストラクターを定義する必要があります。 次の例では、実装により *owner* の値が基本 [**RangeBaseAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242506) に渡されます。最終的に *owner* を使って [**FrameworkElementAutomationPeer.Owner**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.frameworkelementautomationpeer.owner) を設定するのは [**FrameworkElementAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242472) です。

```csharp
public NumericUpDownAutomationPeer(NumericUpDown owner): base(owner)
{}
```

```vb
Public Sub New(owner As NumericUpDown)
    MyBase.New(owner)
End Sub
```

```cppwinrt
// NumericUpDownAutomationPeer.idl
import "NumericUpDown.idl";
namespace MyNamespace
{
    runtimeclass NumericUpDownAutomationPeer : Windows.UI.Xaml.Automation.Peers.AutomationPeer
    {
        NumericUpDownAutomationPeer(NumericUpDown owner);
        Int32 MyProperty;
    }
}

// NumericUpDownAutomationPeer.h
...
struct NumericUpDownAutomationPeer : NumericUpDownAutomationPeerT<NumericUpDownAutomationPeer>
{
    ...
    NumericUpDownAutomationPeer(MyNamespace::NumericUpDown const& owner);
};
```

```cpp
//.h
public ref class NumericUpDownAutomationPeer sealed :  Windows::UI::Xaml::Automation::Peers::RangeBaseAutomationPeer
//.cpp
public:    NumericUpDownAutomationPeer(NumericUpDown^ owner);
```

<span id="Core_methods_of_AutomationPeer"/>
<span id="core_methods_of_automationpeer"/>
<span id="CORE_METHODS_OF_AUTOMATIONPEER"/>

## <a name="core-methods-of-automationpeer"></a>AutomationPeer の Core メソッド  
UWP のインフラストラクチャ上の理由から、オートメーション ピアの上書き可能メソッドは、次の 2 つのメソッドのペアで構成されます。UI オートメーション プロバイダーが UI オートメーション クライアントの転送ポイントとして使用するパブリック アクセス メソッドと、UWP クラスが動作に影響を与えるために上書きできる保護された "Core" カスタマイズ メソッドの 2 つです。 既定では、メソッドのペアは互いに結合されており、アクセス メソッドが呼び出されるたびに、対応するプロバイダーの実装を含む "Core" メソッドが (または、フォールバックとして基底クラスの既定の実装が) 呼び出されます。

カスタム コントロールのピアを実装するときは、そのカスタム コントロールに固有の動作を公開するオートメーション ピア基底クラスから、すべての "Core" メソッドを上書きします。 UI オートメーション コードは、ピア クラスのパブリック メソッドを呼び出すことにより、コントロールに関する情報を取得します。 コントロールに関する情報を提供するにあたり、コントロールの実装と設計によって作るアクセシビリティまたはその他の UI オートメーションのシナリオが、オートメーション ピアの基底クラスによってサポートされているものとは異なる場合は、名前の末尾が "Core" というメソッドをすべて上書きする必要があります。

少なくとも、新規のピア クラスを定義するときは必ず、次の例に示すように、[**GetClassNameCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getclassnamecore) メソッドを実装します。

```csharp
protected override string GetClassNameCore()
{
    return "NumericUpDown";
}
```

> [!NOTE]
> 文字列をメソッドの本文に直接格納する代わりに、定数として格納することもできます。 [**GetClassNameCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getclassnamecore) では、この文字列をローカライズする必要はありません。 UI オートメーション クライアントで、**ClassName** ではなくローカライズした文字列が必要とされる場合はいつも **LocalizedControlType** プロパティが使用されます。

### <span id="GetAutomationControlType"/>
<span id="getautomationcontroltype"/>
<span id="GETAUTOMATIONCONTROLTYPE"/>GetAutomationControlType

一部の支援技術では、UI オートメーション ツリー中の項目に関する特性を報告するときに、UI オートメーションの **Name** 以外の追加情報として、[**GetAutomationControlType**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getautomationcontroltype) の値を直接使っている場合があります。 派生元のコントロールと大幅に異なるコントロールで、基本ピア クラスで報告されるものとは異なるコントロール型を報告する場合は、ピアを実装して [**GetAutomationControlTypeCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getautomationcontroltypecore) をオーバーライドする必要があります。 [**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/BR242803)、[**ContentControl**](https://msdn.microsoft.com/library/windows/apps/BR209365) などの汎用の基底クラスを派生元として使う場合は、コントロール型に関する正確な情報が基本ピアから提供されないため、このことが特に重要になります。

[**GetAutomationControlTypeCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getautomationcontroltypecore) の実装で、[**AutomationControlType**](https://msdn.microsoft.com/library/windows/apps/BR209182) 値を返すことにより、コントロールを記述します。 **AutomationControlType.Custom** を返すこともできますが、コントロールのメイン シナリオを正確に記述している場合は、より具体的なコントロール タイプのいずれかを返す必要があります。 次に例を示します。

```csharp
protected override AutomationControlType GetAutomationControlTypeCore()
{
    return AutomationControlType.Spinner;
}
```

> [!NOTE]
> [**AutomationControlType.Custom**](https://msdn.microsoft.com/library/windows/apps/BR209182) を指定する場合以外は、[**GetLocalizedControlTypeCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getlocalizedcontroltypecore) を実装して **LocalizedControlType** プロパティ値をクライアントに提供する必要はありません。 **AutomationControlType.Custom** 以外のすべての **AutomationControlType** 値では、UI オートメーションの共通インフラストラクチャによって翻訳済みの文字列が提供されます。

<span id="GetPattern_and_GetPatternCore"/>
<span id="getpattern_and_getpatterncore"/>
<span id="GETPATTERN_AND_GETPATTERNCORE"/>

### <a name="getpattern-and-getpatterncore"></a>GetPattern と GetPatternCore  
[**GetPatternCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpatterncore) をピアで実装することにより、入力パラメーターで要求したパターンをサポートするオブジェクトが返されます。 具体的には、UI オートメーション クライアントで、プロバイダーの [**GetPattern**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpattern) メソッドに転送されるメソッドを呼び出して、要求されたパターンを示す [**PatternInterface**](https://msdn.microsoft.com/library/windows/apps/BR242496) 列挙値を指定します。 **GetPatternCore** を上書きすると、指定されたパターンを実装するオブジェクトが返されます。 ピアは、パターンのサポートを報告する対象である、対応するパターン インターフェイスを実装している必要があるため、そのオブジェクトはピア自身です。 ピアにパターンのカスタム実装が含まれていないが、ピアの基本型にそのパターンが実装されていることがわかっている場合は、基本型の **GetPatternCore** の実装を **GetPatternCore** から呼び出すことができます。 ピアでパターンがサポートされていない場合は、ピアの **GetPatternCore** で **null** を返す必要があります。 ただし、通常は、独自の実装から直接 **null** を返すのではなく、基本実装の呼び出しを利用して **null** を返すようにします。

パターンがサポートされている場合、[**GetPatternCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpatterncore) 実装では **this** または **Me** を返すことができます。 ここでは、[**GetPattern**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpattern) の戻り値が **null** 以外の場合は UI オートメーション クライアントが戻り値を要求されたパターン インターフェイスにキャストすることが前提とされています。

あるピア クラスが別のピアから継承された場合、必要なサポートとパターン報告がすべて基底クラスによって既に処理されていれば、[**GetPatternCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpatterncore) の実装は必要ありません。 たとえば、[**RangeBase**](https://msdn.microsoft.com/library/windows/apps/BR227863) から派生させた範囲コントロールを実装する場合、ピアが [**RangeBaseAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242506) から派生されていれば、このピアは、[**PatternInterface.RangeValue**](https://msdn.microsoft.com/library/windows/apps/BR242496) に対して自身を返し、パターンをサポートする [**IRangeValueProvider**](https://msdn.microsoft.com/library/windows/apps/BR242590) インターフェイスの現行の実装を使います。

次の例は、実際のコードそのものではありませんが、[**RangeBaseAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242506) 中に既に存在している [**GetPatternCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpatterncore) の実装の概要を示しています。


```csharp
protected override object GetPatternCore(PatternInterface patternInterface)
{
    if (patternInterface == PatternInterface.RangeValue)
    {
        return this;
    }
    return base.GetPattern(patternInterface);
}
```

ピアの実装時に、必要なすべてのサポートが基本ピア クラスから得られない場合、またはピアがサポートできる基本継承パターンのセットに変更や追加が必要な場合は、[**GetPatternCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpatterncore) を上書きして、UI オートメーション クライアントがパターンを使うことができるようにする必要があります。

UI オートメーションに対応した UWP 実装で利用可能なプロバイダー パターンの一覧については、「[**Windows.UI.Xaml.Automation.Provider**](https://msdn.microsoft.com/library/windows/apps/BR209225)」をご覧ください。 このような個々のパターンにはそれぞれ、[**PatternInterface**](https://msdn.microsoft.com/library/windows/apps/BR242496) 列挙に対応する値があります。この値により、UI オートメーション クライアントが [**GetPattern**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpattern) の呼び出しでパターンを要求します。

ピアでは、複数のパターンをサポートしていることを伝えることができます。 この場合、上書きのときに、サポートされる個々の [**PatternInterface**](https://msdn.microsoft.com/library/windows/apps/BR242496) 値に対するリターン パス ロジックを指定して、一致するケースごとにペアが返されるようにする必要があります。 このとき、呼び出し元では 1 回に 1 個ずつインターフェイスを要求すること、さらに予期されるインターフェイスへのキャストは呼び出し元が行うことが前提となります。

次にカスタム ピアに対する [**GetPatternCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpatterncore) の上書きの例を示します。 [**IRangeValueProvider**](https://msdn.microsoft.com/library/windows/apps/BR242590) と [**IToggleProvider**](https://msdn.microsoft.com/library/windows/apps/BR242653) の 2 つのパターンに対するサポートが報告されます。 このコントロールは、全画面表示として表示できるメディア表示コントロール (トグル モード) です。進行状況バーの表示位置は変更可能 (範囲コントロール) です。 このコードは、[XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570)の抜粋です。


```csharp
protected override object GetPatternCore(PatternInterface patternInterface)
{
    if (patternInterface == PatternInterface.RangeValue)
    {
        return this;
    }
    else if (patternInterface == PatternInterface.Toggle)
    {
        return this;
    }
    return null;
}
```

<span id="Forwarding_patterns_from_sub-elements"/>
<span id="forwarding_patterns_from_sub-elements"/>
<span id="FORWARDING_PATTERNS_FROM_sub-elementS"/>

### <a name="forwarding-patterns-from-sub-elements"></a>子要素からのパターンの転送  
[**GetPatternCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpatterncore) メソッドの実装では、ホストのパターン プロバイダーとして子要素や一部分を指定できます。 この例は、[**ItemsControl**](https://msdn.microsoft.com/library/windows/apps/BR242803) が内部の [**ScrollViewer**](https://msdn.microsoft.com/library/windows/apps/BR209527) コントロールのピアに向けてスクロール パターン処理を転送する方法を模したものです。 パターン処理の子要素を指定するために、このコードではまず子要素オブジェクトを取得して、[**FrameworkElementAutomationPeer.CreatePeerForElement**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.frameworkelementautomationpeer.createpeerforelement) メソッドにより子要素のピアを作り、新しいピアを返します。


```csharp
protected override object GetPatternCore(PatternInterface patternInterface)
{
    if (patternInterface == PatternInterface.Scroll)
    {
        ItemsControl owner = (ItemsControl) base.Owner;
        UIElement itemsHost = owner.ItemsHost;
        ScrollViewer element = null;
        while (itemsHost != owner)
        {
            itemsHost = VisualTreeHelper.GetParent(itemsHost) as UIElement;
            element = itemsHost as ScrollViewer;
            if (element != null)
            {
                break;
            }
        }
        if (element != null)
        {
            AutomationPeer peer = FrameworkElementAutomationPeer.CreatePeerForElement(element);
            if ((peer != null) && (peer is IScrollProvider))
            {
                return (IScrollProvider) peer;
            }
        }
    }
    return base.GetPatternCore(patternInterface);
}
```

<span id="Other_Core_methods"/>
<span id="other_core_methods"/>
<span id="OTHER_CORE_METHODS"/>

### <a name="other-core-methods"></a>その他の Core メソッド  
コントロールで、主要なシナリオに対してキーボードの同等機能のサポートが必要になる場合があります。これが必要になる理由について詳しくは、「[キーボードのアクセシビリティ](keyboard-accessibility.md)」をご覧ください。 キー サポートの実装は、コントロールのロジックの一部であるため、ピア コードではなくコントロール コードの一部になりますが、ピア クラスでは、[**GetAcceleratorKeyCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getacceleratorkeycore) と [**GetAccessKeyCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getaccesskeycore) のメソッドを上書きすることにより、現在どのキーが使われているかを UI オートメーション クライアントに報告する必要があります。 キーの情報を報告する文字列はローカライズされる可能性があるため、リソースから取得し、ハードコードした文字列は使いません。

コレクションをサポートするクラスのピアを提供する場合は、同じ種類のコレクション サポートが既に存在する機能クラスとピア クラスの両方から派生させるのが最もよい方法です。 これができない場合は、子コレクションを維持しているコントロールのピアでコレクションに関連するピア メソッド、[**GetChildrenCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getchildrencore) を上書きして、UI オートメーション ツリーに親子の関係を正しく報告する必要があります。

[**IsContentElementCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.iscontentelementcore) メソッドと [**IsControlElementCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.iscontrolelementcore) メソッドを実装して、コントロールにデータ コンテンツが含まれているのか、またはユーザー インターフェイスで対話型の役割を果たすのか (あるいはその両方なのか) を指示します。 既定では、両方のメソッドで **true** が返されます。 これらの設定により、各メソッドを使ってオートメーション ツリーをフィルターするスクリーン リーダーなどの支援技術の操作性が改善されます。 [**GetPatternCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpatterncore) メソッドで、子要素ピアにパターン処理を転送すると、子要素ピアの **IsControlElementCore** メソッドが、子要素ピアをオートメーション ツリーから隠すために、**false** を返すことがあります。

コントロールの中には、テキスト ラベルの部分がテキスト以外の部分の情報を提供したり、コントロールと UI の別のコントロールとの間にラベル付けの関係が確立されたりする、ラベル付けのシナリオをサポートするものもあります。 クラス ベースの有用な動作を提供できる場合は、[**GetLabeledByCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getlabeledbycore) をオーバーライドしてこの動作を提供できます。

[**GetBoundingRectangleCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getboundingrectanglecore) と [**GetClickablePointCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getclickablepointcore) は、主に自動テストのシナリオに使われます。 コントロールの自動テストをサポートする場合は、これらのメソッドを上書きする必要があることがあります。 範囲型のコントロールでは、座標空間でユーザーがクリックした場所によって範囲への効果が異なり、1 つのポイントのみを提案できないため、これが必要な場合があります。 たとえば、既定の [**ScrollBar**](https://msdn.microsoft.com/library/windows/apps/BR209745) オートメーション ピアは **GetClickablePointCore** を上書きして、"数字ではない" [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) 値を返します。

[**GetLiveSettingCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getlivesettingcore) は、UI オートメーションの **LiveSetting** 値のコントロール既定値に影響します。 これをオーバーライドして、コントロールが [**AutomationLiveSetting.Off**](https://msdn.microsoft.com/library/windows/apps/JJ191519) 以外の値を返すようにすることができます。 **LiveSetting** が何を表すかについて詳しくは、「[**AutomationProperties.LiveSetting**](https://msdn.microsoft.com/library/windows/apps/JJ191516)」をご覧ください。

コントロールが、[**GetOrientationCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getorientationcore) にマップできる設定可能な向きのプロパティを持っている場合は、[**AutomationOrientation**](https://msdn.microsoft.com/library/windows/apps/BR209184) を上書きできます。 [**ScrollBarAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242522) クラスと [**SliderAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242546) クラスがこれを行います。

<span id="Base_implementation_in_FrameworkElementAutomationPeer"/>
<span id="base_implementation_in_frameworkelementautomationpeer"/>
<span id="BASE_IMPLEMENTATION_IN_FRAMEWORKELEMENTAUTOMATIONPEER"/>

### <a name="base-implementation-in-frameworkelementautomationpeer"></a>FrameworkElementAutomationPeer の基本実装  
[**FrameworkElementAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242472) の基本実装は、フレームワーク レベルで定義されるレイアウトや動作のさまざまなプロパティから解釈できる UI オートメーションの情報を提供します。

* [**GetBoundingRectangleCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getboundingrectanglecore): 既知のレイアウト特性に基づいて [**Rect**](https://msdn.microsoft.com/library/windows/apps/BR225994) 構造体を返します。 [**IsOffscreen**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.isoffscreen) が **true** の場合は、値が 0 の **Rect** を返します。
* [**GetClickablePointCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getclickablepointcore): 既知のレイアウト特性に基づいて [**Point**](https://msdn.microsoft.com/library/windows/apps/BR225870) 構造体を返します (値が 0 でない **BoundingRectangle** がある場合)。
* [**GetNameCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getnamecore): このメソッドの動作は多岐にわたるため、ここでは紹介しきれません。詳しくは、「[**GetNameCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getnamecore)」をご覧ください。 基本的には、[**ContentControl**](https://msdn.microsoft.com/library/windows/apps/BR209365) やコンテンツを持つ関連クラスの既知のコンテンツの文字列変換を試行します。 また、[**LabeledBy**](https://msdn.microsoft.com/library/windows/apps/Hh759769) の値がある場合は、その項目の **Name** の値が **Name** として使われます。
* [**HasKeyboardFocusCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.haskeyboardfocuscore): 所有者の [**FocusState**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.focusstate) プロパティと [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.isenabled) プロパティに基づいて評価されます。 コントロールではない要素は常に **false** を返します。
* [**IsEnabledCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.isenabledcore): 所有者の [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.isenabled) プロパティに基づいて評価されます (所有者が [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) の場合)。 コントロールではない要素は常に **true** を返します。 これは、従来の対話式操作の意味で所有者が有効であることを示すのではなく、所有者に **IsEnabled** プロパティがなくてもピアは有効であることを示します。
* [**IsKeyboardFocusableCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.iskeyboardfocusablecore): 所有者が [**Control**](https://msdn.microsoft.com/library/windows/apps/BR209390) の場合は **true**、それ以外の場合は **false** を返します。
* [**IsOffscreenCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.isoffscreencore): 所有者要素またはそのいずれかの親の [**Visibility**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.uielement.visibility) が [**Collapsed**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.visibility) の場合に [**IsOffscreen**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.isoffscreen) の値が **true** になります。 [**Popup**](https://msdn.microsoft.com/library/windows/apps/BR227842) オブジェクトは例外で、所有者の親が表示されていなくても表示される可能性があります。
* [**SetFocusCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.setfocuscore): [**Focus**](https://msdn.microsoft.com/library/windows/apps/hh702161) を呼び出します。
* [**GetParent**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getparent): 所有者から [**FrameworkElement.Parent**](https://msdn.microsoft.com/library/windows/apps/BR208739) を呼び出して適切なピアを検索します。 これは、"Core" メソッドを含む上書きペアではないため、この動作を変更することはできません。

> [!NOTE]
> UWP の既定のピアは、UWP を実装する内部のネイティブ コードを使って動作を実装します。実際の UWP コードが使われるとは限りません。 共通言語ランタイム (CLR) のリフレクションやその他の手法を使って実装のコードやロジックを見ることはできません。 また、基本ピアの動作のサブクラス固有のオーバーライドに対応する個別のリファレンス ページはありません。 たとえば、[**TextBoxAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242550) の [**GetNameCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getnamecore) には、**AutomationPeer.GetNameCore** のリファレンス ページでは説明されていない追加の動作がある可能性がありますが、**TextBoxAutomationPeer.GetNameCore** にはリファレンス ページがありません。 そもそも、**TextBoxAutomationPeer.GetNameCore** のリファレンス ページは存在しません。 代わりに、最も近いピア クラスのリファレンス トピックを参照して、「注釈」セクションで実装の注釈を探してください。

<span id="Peers_and_AutomationProperties"/>
<span id="peers_and_automationproperties"/>
<span id="PEERS_AND_AUTOMATIONPROPERTIES"/>

## <a name="peers-and-automationproperties"></a>ピアと AutomationProperties  
オートメーション ピアでは、コントロールのアクセシビリティに関連する情報に対して適切な既定値を提供する必要があります。 コントロールを使うアプリ コードでは、添付プロパティ [**AutomationProperties**](https://msdn.microsoft.com/library/windows/apps/BR209081) の値をコントロール インスタンスに取り込むことにより、その動作の一部をオーバーライドできます。 呼び出し元では、既定コントロールまたはカスタム コントロールのいずれにも、この操作を行うことができます。 たとえば、次の XAML では、カスタマイズした 2 つの UI オートメーション プロパティを使うボタンを作ります。 `<Button AutomationProperties.Name="Special"      AutomationProperties.HelpText="This is a special button."/>`

[**AutomationProperties**](https://msdn.microsoft.com/library/windows/apps/BR209081) 添付プロパティについて詳しくは、「[基本的なアクセシビリティ情報](basic-accessibility-information.md)」をご覧ください。

[**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185) メソッドの一部は、UI オートメーション プロバイダーがどのように情報を報告するかを定める一般的なコントラクトのために存在しています。ただし、通常これらのメソッドはコントロール ピアでは実装されません。 理由は、この情報が、特定の UI にあるコントロールを使ったアプリ コードに適用する [**AutomationProperties**](https://msdn.microsoft.com/library/windows/apps/BR209081) 値から提供されることを前提としているためです。 たとえば、大半のアプリでは、[**AutomationProperties.LabeledBy**](https://msdn.microsoft.com/library/windows/apps/Hh759769) 値を適用することにより、UI 内の異なる 2 つのコントロール間でラベル付けの関係を定義します。 ただし、コントロール中のデータや項目の関係を表す特定のピアでは [**LabeledByCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getlabeledbycore) が実装されています。たとえば、ヘッダー部分を使ってデータ フィールドの部分にラベルを付けたり、項目にコンテナーのラベルを付けたりする場合です。

<span id="Implementing_patterns"/>
<span id="implementing_patterns"/>
<span id="IMPLEMENTING_PATTERNS"/>

## <a name="implementing-patterns"></a>パターンの実装  
展開/折りたたみのコントロール パターン インターフェイスを実装することによって展開/折りたたみの動作を実装するコントロールに対するピアを作る方法を見てみます。 ピアでは、[**PatternInterface.ExpandCollapse**](https://msdn.microsoft.com/library/windows/apps/BR242496) の値で [**GetPattern**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getpattern) が呼び出されたら必ず自身を返して、展開/折りたたみの動作のアクセシビリティを有効にする必要があります。 次に、そのパターンに対するプロバイダー インターフェイスを継承 ([**IExpandCollapseProvider**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.iexpandcollapseprovider)) して、そのプロバイダー インターフェイスの各メンバーに対し実装を提供する必要があります。 この例の場合、インターフェイスで次の 3 つのメンバーを上書きします。[**Expand**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.iexpandcollapseprovider.expand)、[**Collapse**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.iexpandcollapseprovider.collapse)、[**ExpandCollapseState**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.iexpandcollapseprovider.expandcollapsestate)。

クラスの API 設計自体にアクセシビリティについて事前に考慮しておくと効果的です。 UI を使って作業をするユーザーとの典型的な対話式操作、またはオートメーション プロバイダー パターンのどちらかを介して要求する動作が想定される場合は必ず、UI の応答、またはオートメーション パターンのどちらからでも呼び出し可能な単一のメソッドを用意しておきます。 たとえば、コントロールに、展開/折りたたみ可能なイベント ハンドラーを結合したボタン部分と、各操作に対応するキーボードの同等機能を持たせる場合は、ピア中で使う [**IExpandCollapseProvider**](https://msdn.microsoft.com/library/windows/desktop/Ee671242) の [**Expand**](https://msdn.microsoft.com/library/windows/apps/BR242570) または [**Collapse**](https://msdn.microsoft.com/library/windows/apps/BR242569) の実装本体から呼び出すのと同じメソッドを、個々のイベント ハンドラーから呼び出す必要があります。 共通のロジック メソッドを使うことにより、コントロールの表示状態が更新されるため、動作の起動方法に依存することなく、ロジックの状態が一貫した方法で表示されるようになります。

典型的な実装として、まずプロバイダー API から実行時にコントロール インスタンスにアクセスするために [**Owner**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.frameworkelementautomationpeer.owner) を呼び出し、 次にこのオブジェクトに対して必要な動作メソッドを呼び出すという方法が考えられます。


```csharp
public class IndexCardAutomationPeer : FrameworkElementAutomationPeer, IExpandCollapseProvider {
    private IndexCard ownerIndexCard;
    public IndexCardAutomationPeer(IndexCard owner) : base(owner)
    {
         ownerIndexCard = owner;
    }
}
```

別の実装は、コントロール自体がピアを参照する方法です。 [**RaiseAutomationEvent**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.raiseautomationevent) メソッドがピア メソッドであるため、これはコントロールからオートメーション イベントを生成する場合の一般的なパターンです。

<span id="UI_Automation_events"/>
<span id="ui_automation_events"/>
<span id="UI_AUTOMATION_EVENTS"/>

## <a name="ui-automation-events"></a>UI オートメーションのイベント  

UI オートメーションのイベントは、次のカテゴリに分類されます。

| イベント | 説明 |
|-------|-------------|
| プロパティの変更 | UI オートメーション要素またはコントロール パターンのプロパティが変更されたときに発生します。 たとえば、クライアントでアプリのチェック ボックス コントロールを監視する必要がある場合は、[**ToggleState**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.provider.itoggleprovider.togglestate) プロパティのプロパティ変更イベントをリッスンするように登録します。 チェック ボックス コントロールがオンまたはオフになると、プロバイダーがこのイベントを発生させるため、クライアントで必要に応じて対処できます。 |
| 要素の操作 | ユーザーまたはプログラムによる操作の結果として UI が変更された場合に発生します (ボタンがクリックされた場合、**Invoke** パターンによって呼び出された場合など)。 |
| 構造の変更 | UI オートメーション ツリーの構造が変更された場合に発生します。 構造は、新しい UI 項目が表示された場合、非表示になった場合、またはデスクトップから削除された場合に変更されます。 |
| グローバルな変更 | クライアントのグローバルな関心の対象となる操作が行われた場合に発生します (要素のフォーカスが別の要素に移動した場合、子ウィンドウが閉じられた場合など)。 一部のイベントは、必ずしも UI の状態の変化を表すとは限りません。 たとえば、ユーザーが Tab キーを押してテキスト入力フィールドに移動し、ボタンをクリックしてフィールドを更新した場合、[**TextChanged**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textbox.textchanged) イベントが発生しますが、実際にはテキストは変更されていません。 クライアント アプリでイベントを処理するときには、処理を開始する前に、実際に何か変更されているかどうかを確認する必要があります。 |

<span id="AutomationEvents_identifiers"/>
<span id="automationevents_identifiers"/>
<span id="AUTOMATIONEVENTS_IDENTIFIERS"/>

### <a name="automationevents-identifiers"></a>AutomationEvents の識別子  
UI オートメーションのイベントは、[**AutomationEvents**](https://msdn.microsoft.com/library/windows/apps/BR209183) の値によって識別されます。 この列挙体の値は、イベントの種類を一意に識別します。

<span id="Raising_events"/>
<span id="raising_events"/>
<span id="RAISING_EVENTS"/>

### <a name="raising-events"></a>イベントの発生  
UI オートメーション クライアントでは、オートメーション イベントを受信登録することができます。 オートメーション ピア モデルの場合、カスタム コントロールのピアでは [**RaiseAutomationEvent**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.raiseautomationevent) メソッドを呼び出すことによって、アクセシビリティに関連するコントロール状態に生じた変化を報告しなければなりません。 同様に、キー UI オートメーション プロパティ値に変更があった場合は、カスタム コントロール ピアから、[**RaisePropertyChangedEvent**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.raisepropertychangedevent) メソッドを呼び出す必要があります。

次のコード例は、コントロール定義コードの内部からピア オブジェクトを取得し、そのピアからイベントを発生させるメソッドを呼び出す方法を示しています。 最適化のために、コードではこのイベント タイプのリスナーがいるかどうかを確認します。 リスナーがいるときにのみイベントを発生させてピア オブジェクトを作ることにより、不要なオーバーヘッドがなくなり、コントロールが応答性を維持できるようになります。


```csharp
if (AutomationPeer.ListenerExists(AutomationEvents.PropertyChanged))
{
    NumericUpDownAutomationPeer peer =
        FrameworkElementAutomationPeer.FromElement(nudCtrl) as NumericUpDownAutomationPeer;
    if (peer != null)
    {
        peer.RaisePropertyChangedEvent(
            RangeValuePatternIdentifiers.ValueProperty,
            (double)oldValue,
            (double)newValue);
    }
}
```

<span id="Peer_navigation"/>
<span id="peer_navigation"/>
<span id="PEER_NAVIGATION"/>

## <a name="peer-navigation"></a>ピアのナビゲーション  
オートメーション ピアが特定された後、UI オートメーション クライアントではピア オブジェクトの [**GetChildren**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getchildren) メソッドと [**GetParent**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getparent) メソッドを呼び出すことにより、アプリのピア構造をナビゲートすることができます。 コントロール内部での UI 要素間のナビゲーションは、[**GetChildrenCore**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.peers.automationpeer.getchildrencore) メソッドをピアで実装することにより、サポートされます。 UI オートメーション システムでは、このメソッドを呼び出して、コントロールに含まれる子要素 (たとえば、リスト ボックス中のリスト項目) のツリーを構築します。 [**FrameworkElementAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242472) に含まれる既定の **GetChildrenCore** メソッドでは、要素のビジュアル ツリーを走査してオートメーション ピアのツリーを構築します。 カスタム コントロールでは、このメソッドを上書きして、子要素を表す別の表示をオートメーション クライアントに公開することにより、情報の伝達やユーザー操作の許可を行う各要素のオートメーション ピアを返すことができます。

<span id="Native_automation_support_for_text_patterns"/>
<span id="native_automation_support_for_text_patterns"/>
<span id="NATIVE_AUTOMATION_SUPPORT_FOR_TEXT_PATTERNS"/>

## <a name="native-automation-support-for-text-patterns"></a>テキスト パターンのネイティブ オートメーション サポート  
既定の UWP アプリのオートメーション ピアの一部は、テキスト パターンに対するコントロール パターンのサポートを提供します ([**PatternInterface.Text**](https://msdn.microsoft.com/library/windows/apps/BR242496))。 ただし、このサポートはネイティブな方法で提供され、関係するピアは (管理された) 継承の [**ITextProvider**](https://msdn.microsoft.com/library/windows/apps/BR242627) インターフェイスに注目しません。 それでも、管理されている、または管理されていない UI オートメーション クライアントがピアでパターンを照会すると、テキスト パターンに対するサポートが報告され、クライアント API が呼び出されたときにパターンの一部の動作が提供されます。

UWP アプリのテキスト コントロールの 1 つから派生させ、テキスト関連ピアの 1 つから派生するカスタム ピアを作る場合は、ピアの「注釈」セクションをご覧になることで、パターンのネイティブ レベル サポートについて詳しく知ることができます。 管理されているプロバイダー インターフェイスの実装から基本実装を呼び出すと、カスタム ピアのネイティブ ベースの動作にアクセスできますが、ピアのネイティブ インターフェイスとその所有者のコントロールは両方とも公開されるため、基本実装で行われる動作を変更するのは困難です。 一般的に、基本実装をそのまま使うか (基本実装のみを呼び出す)、基本実装を呼び出さないで機能を独自のマネージ コードで完全に置き換えます。 後者は高度なシナリオであり、コントロールでテキスト サービス フレームワークを使う場合は、アクセシビリティ要件をサポートするためにフレームワークに関する詳しい知識が必要となります。

<span id="AutomationProperties.AccessibilityView"/>
<span id="automationproperties.accessibilityview"/>
<span id="AUTOMATIONPROPERTIES.ACCESSIBILITYVIEW"/>

## <a name="automationpropertiesaccessibilityview"></a>AutomationProperties.AccessibilityView  
カスタム ピアの提供に加えて、XAML で [**AutomationProperties.AccessibilityView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.automation.automationproperties.accessibilityview) を設定することにより、コントロール インスタンスのツリー ビュー表現を調整することもできます。 これはピア クラスの一部としては実装されませんが、カスタム コントロールまたはカスタマイズしたテンプレートでの全体的なアクセシビリティのサポートに密接な関係があるため、ここで触れておきます。

**AutomationProperties.AccessibilityView** を使う主なシナリオでは、コントロール全体のアクセシビリティ ビューに対して有意に貢献しないので、UI オートメーション ビューから意図的にテンプレート内の特定のコントロールを省略します。 これを避けるために、**AutomationProperties.AccessibilityView** を "Raw" に設定します。

<span id="Throwing_exceptions_from_automation_peers"/>
<span id="throwing_exceptions_from_automation_peers"/>
<span id="THROWING_EXCEPTIONS_FROM_AUTOMATION_PEERS"/>

## <a name="throwing-exceptions-from-automation-peers"></a>オートメーション ピアからの例外のスロー  
オートメーション ピア サポートのために実装する API では、例外をスローすることが許されています。 リッスンしている UI オートメーション クライアントはいずれも堅牢に作られていると想定され、例外がスローされても、ほとんどの場合は続行できることが求められています。 リスナーが対象としているのは自分自身だけでなく他のアプリを含めたオートメーション ツリー全体であり、クライアントが API を呼び出したときにツリーの一部でピア ベースの例外がスローされたからといって、クライアント全体が停止するような設計は望ましくありません。

ピアに渡されたパラメーターについて入力を検証することは許容されます。たとえば、**null** が渡された場合、それを有効な値として扱わない実装では [**ArgumentNullException**](https://msdn.microsoft.com/library/windows/apps/system.argumentnullexception) をスローすることができます。 ただし、ピアで実行される後続の操作がある場合、ホストしているコントロールとピアとのやり取りには非同期的な性質があることに注意が必要です。 ピアで実行した操作によって、必ずしもコントロールの UI スレッドがブロックされるとは限りません (そのような動作になることはほとんどありません)。 したがって、ピアの作成時やオートメーション ピア メソッドの初回の呼び出し時に、あるオブジェクトが使用可能であったり、特定のプロパティが設定されていたりしても、処理を行っている間にコントロールの状態が変わる可能性があります。 このような場合にスローできる専用の例外が 2 つあります。

* 自身の API に渡された元の情報に基づいてピアの所有者または関連するピア要素にアクセスできない場合は、[**ElementNotAvailableException**](https://msdn.microsoft.com/library/system.windows.automation.elementnotavailableexception) をスローします。 たとえば、ピアでメソッドを実行しようとしているときに、モーダル ダイアログが閉じられたなどの理由で、UI から所有者が削除された場合が当てはまります。 .NET 以外のクライアントでは、これは [**UIA\_E\_ELEMENTNOTAVAILABLE**](https://msdn.microsoft.com/library/windows/desktop/Ee671218) にマップされます。
* 所有者はまだ存在するものの、その所有者が [**IsEnabled**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.isenabled)`=`**false** などのモードになっていて、ピアで実行しようとしている特定の変更をプログラムで実現することができない場合は、[**ElementNotEnabledException**](https://msdn.microsoft.com/library/system.windows.automation.elementnotenabledexception) をスローします。 .NET 以外のクライアントでは、これは [**UIA\_E\_ELEMENTNOTENABLED**](https://msdn.microsoft.com/library/windows/desktop/Ee671218) にマップされます。

他にも、ピア サポートからの例外のスローに関して、ピアでは比較的保守的な対応をとる必要があります。 ほとんどのクライアントでは、ピアからの例外を処理することができないため、発生した例外は、ユーザーに選択を求める対話操作に変換されます。 このため、ピアでの操作が失敗するたびに例外をスローするよりは、ピアの実装内で例外をキャッチし、再スローもせずに何もしない戦略の方が適している場合があります。 また、多くの UI オートメーション クライアントはマネージ コードで作られているわけではない点にも考慮する必要があります。 ほとんどは COM で記述されているため、ピアにアクセスする UI オートメーション クライアント メソッドを呼び出すときは、**HRESULT** が **S\_OK** かどうかをチェックするだけになります。

<span id="related_topics"/>

## <a name="related-topics"></a>関連トピック  
* [アクセシビリティ](accessibility.md)
* [XAML アクセシビリティ サンプル](http://go.microsoft.com/fwlink/p/?linkid=238570)
* [**FrameworkElementAutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR242472)
* [**AutomationPeer**](https://msdn.microsoft.com/library/windows/apps/BR209185)
* [**OnCreateAutomationPeer**](https://msdn.microsoft.com/ibrary/windows/apps/windows.ui.xaml.uielement.oncreateautomationpeer)
* [コントロール パターンとインターフェイス](control-patterns-and-interfaces.md)
