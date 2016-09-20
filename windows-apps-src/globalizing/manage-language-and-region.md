---
author: DelfCo
Description: "Windows で提供される言語と地域についてのさまざまな設定を使って、Windows がアプリの UI リソースをどのように選び、UI 要素のフォーマットをどのように決定するかを制御します。"
title: "言語と地域の管理"
ms.assetid: 22D3A937-736A-4121-8285-A55DED56E594
label: Manage language and region
template: detail.hbs
ms.sourcegitcommit: 59e02840c72d8bccda7e318197e4bf45ed667fa4
ms.openlocfilehash: 294f087fffeefda67ddacd09636915144bf18ff4

---

# 言語と地域の管理





**重要な API**

-   [**Windows.Globalization**](https://msdn.microsoft.com/library/windows/apps/br206813)
-   [**Windows.ApplicationModel.Resources**](https://msdn.microsoft.com/library/windows/apps/br206022)
-   [**WinJS.Resources 名前空間**](https://msdn.microsoft.com/library/windows/apps/br229779)

Windows で提供される言語と地域についてのさまざまな設定を使って、Windows がアプリの UI リソースをどのように選び、UI 要素のフォーマットをどのように決定するかを制御します。

## <span id="Introduction"></span><span id="introduction"></span><span id="INTRODUCTION"></span>はじめに


言語と地域の設定をどのように管理するかを紹介したサンプル アプリについては、「[アプリ リソースとローカライズのサンプル](http://go.microsoft.com/fwlink/p/?linkid=231501)」をご覧ください。

Windows ユーザーは、一定の言語の中から 1 つの言語だけを選ぶ必要はありません。 ユーザーは、自分の使用言語として世界のどの言語でも (Windows 自体がその言語に翻訳されていない場合でも) Windows に設定できます。 また、複数の言語を話すことができると指定することもできます。

Windows ユーザーは、自分の地域として世界中のどの場所でも指定できます。 また、自分が話す言語として、地域を問わずどの言語でも指定できます。 地域と言語が互いに制限し合うことはありません。 フランス語を話す人がフランスに住んでいるとは限りません。また、フランスに住んでいても、フランス語を使うことを好むとは限りません。

Windows ユーザーは、Windows とはまったく異なる言語でアプリを実行できます。 たとえば、Windows を英語で実行しながら、特定のアプリをスペイン語で実行できます。

Windows ストア アプリの場合、言語は [BCP-47 言語タグ](http://go.microsoft.com/fwlink/p/?linkid=227302)として表示されます。 Windows ランタイム、HTML、XAML のほとんどの API は、これらの BCP-47 言語タグの文字列表現を返すか、または受け入れることができます。 「[言語の IANA 一覧](http://go.microsoft.com/fwlink/p/?linkid=227303)」もご覧ください。

Windows ストアで明確にサポートされる言語タグのリストについては、「[サポートされている言語](https://msdn.microsoft.com/library/windows/apps/jj657969)」をご覧ください。

## <span id="Tasks"></span><span id="tasks"></span><span id="TASKS"></span>処理手順


### <span id="Users_can_set_their_language_preferences."></span><span id="users_can_set_their_language_preferences."></span><span id="USERS_CAN_SET_THEIR_LANGUAGE_PREFERENCES."></span>ユーザーは言語の優先順位を設定できます。

ユーザー言語の優先順位一覧は、ユーザーが好んでいる順にユーザーの言語を記述した、順序化された言語一覧です。

ユーザーは、この一覧を **[設定]**&gt;**[時刻と言語]**&gt;**[地域と言語]** で設定します。 また、**コントロール パネル**&gt;**[時計、言語、および地域]** を使うこともできます。

ユーザー言語の優先順位一覧には、複数の言語のほか、地域バリアントなどの特定の言語バリアントを含めることができます。 たとえば、ユーザーは fr-CA を好んで使っているものの、en-GB もわかるという場合が考えられます。

### <span id="Specify_the_supported_languages_in_the_app_s_manifest."></span><span id="specify_the_supported_languages_in_the_app_s_manifest."></span><span id="SPECIFY_THE_SUPPORTED_LANGUAGES_IN_THE_APP_S_MANIFEST."></span>アプリのマニフェストにサポートされる言語を指定します。

アプリのマニフェスト ファイル (通常 Package.appxmanifest) の [**Resources 要素**](https://msdn.microsoft.com/library/windows/apps/dn934770)に、アプリでサポートされる言語の一覧を指定します。または、Visual Studio を使い、プロジェクトで見つかった言語に基づいて言語の一覧をマニフェスト ファイルに自動的に生成します。 このマニフェストでは、サポートされる言語について適切な詳細度で正確に説明する必要があります。 マニフェストに載っている言語は、Windows ストアでユーザーに表示される言語です。

### <span id="Specify_the_default_language."></span><span id="specify_the_default_language."></span><span id="SPECIFY_THE_DEFAULT_LANGUAGE."></span>既定の言語を指定します。

Visual Studio で package.appxmanifest を開き、**[アプリケーション]** タブに移動して、既定の言語をアプリケーションの作成に使っている言語に設定します。

ユーザーが選んだ言語がどれもアプリでサポートされていない場合、そのアプリは既定の言語を使います。 Visual Studio は、既定の言語を使って、その言語で指定されているアセットにメタデータを追加します。この結果、実行時に適切なアセットが選ばれます。

アプリケーションの言語 (以下の手順「アプリケーションの言語の一覧を作ります」で説明します) を適切に設定するため、既定言語プロパティは、マニフェストにおける最初の言語として設定する必要もあります。 既定の言語で作られたリソースでも、その言語で修飾する必要があります (en-US/logo.png など)。 既定の言語によって、修飾されていないアセットの暗黙の言語が指定されることはありません。 詳しくは、「[修飾子を使ってリソースに名前を付ける方法](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324)」をご覧ください。

### <span id="Qualify_resources_with_their_language."></span><span id="qualify_resources_with_their_language."></span><span id="QUALIFY_RESOURCES_WITH_THEIR_LANGUAGE."></span>ユーザーの言語でリソースを修飾します。

対象者を慎重に検討し、ターゲットにするユーザーの言語や場所を考慮します。 ある地域に住む多くの人がその地域の第一言語をメインに使うとは限りません。 たとえば、第一言語としてスペイン語を話す家庭は米国内に数百万存在します。

言語でリソースを修飾するときは、次のようにします。

-   その言語について抑制スクリプトの値が定義されていない場合にはスクリプトを含めます。 言語タグについて詳しくは、[IANA 言語サブタグ レジストリに関するページ](http://go.microsoft.com/fwlink/p/?linkid=227303)をご覧ください。 たとえば、zh-Hant、zh-Hant-TW、または zh-Hans を使い、zh-CN と zh-TW は使わないでください。
-   すべての言語コンテンツを 1 つの言語でマークします。 既定の言語プロジェクト プロパティは、マークされていないリソースの言語 (つまりニュートラルな言語) ではなく、ユーザーと対応付けされるマーク済みの言語リソースが他にない場合に選ばれる、マーク済みの言語リソースを指定します。

コンテンツの正確な表現を使ってアセットをマークします。

-   Windows では地域バリアント間の場合 (たとえば en-US から en-GB) も含む複雑な対応付けを行うため、アプリケーションはコンテンツの正確な表現を使ってアセットを自由にマークでき、Windows で各ユーザーに適切な対応付けができます。
-   マニフェストに載っているコンテンツは、Windows ストアでアプリケーションを探しているユーザーに表示されます。
-   一部のツールやその他のコンポーネント (機械翻訳など) では、データの理解に役立つ地域言語情報など特定の言語タグを探す場合があることに注意してください。
-   複数のバリアントが利用可能な場合は特に、詳しい情報を使ってアセットをマークしてください。 たとえば、en-GB と en-US の両方がその地域に固有の場合は、両方をマークします。
-   標準語が 1 つだけの言語では、地域を追加する必要はありません。 アセットを ja-JP ではなく ja でマークするなど、汎用タグを使うほうが適切なことがあります。

一部のリソースをローカライズする必要がない場合もあります。

-   UI 文字列のようにすべての言語で出現するリソースの場合は、出現する適切な言語でマークし、そのようなリソースのすべてが既定の言語に含まれていることを確認します。 ニュートラルなリソース (言語でマークされていないリソース) を指定する必要はありません。
-   アプリケーション全体の言語セットのサブセットに含まれているリソース (部分的なローカライズ) の場合は、アセットが出現する言語セットを指定し、そのようなリソースのすべてが既定の言語に含まれていることを確認します。 Windows は、ユーザーが話すすべての言語を優先順位に従って調べて、そのユーザーに最適と考えられる言語を選びます。 たとえば、アプリの完全なリソースのセットがスペイン語で用意されている場合、アプリの UI でカタルニア語にローカライズされていないものがある可能性があります。 カタルニア語を話し、スペイン語も話すユーザーの場合、カタルニア語で利用できないリソースはスペイン語で表示されます。
-   一部の言語に固有の例外があるリソースで、その他のすべての言語は共通のリソースにマップされる場合、すべての言語に使われるリソースは非決定言語タグ 'und' でマークする必要があります。 Windows では 'und' 言語タグが '\*' と同様の方法で解釈され、最上位のアプリケーション言語と対応付けされるのはその他の固有の対応付けの後です。 たとえば、いくつかのリソース (要素の幅など) がフィンランド語では異なっていて、残りのリソースはすべての言語で同じであれば、フィンランド語のリソースはフィンランド語の言語タグでマークし、残りは 'und' でマークする必要があります。
-   言語ではなく言語スクリプトに基づくリソースの場合 (テキストのフォントや高さなど)、指定されたスクリプトと共に非決定言語タグ "und-&lt;script&gt;" を使います。 たとえば、ラテン語フォントの場合は und-Latn\\fonts.css を使い、キリル語フォントの場合は und-Cryl\\fonts.css を使います。

### <span id="Create_the_application_language_list."></span><span id="create_the_application_language_list."></span><span id="CREATE_THE_APPLICATION_LANGUAGE_LIST."></span>アプリケーションの言語の一覧を作ります。

実行時に、システムはアプリでサポートを宣言しているユーザー言語の優先順位がマニフェストに記載されているかどうかを判断し、*アプリケーションの言語の一覧*を作成します。 この一覧を使ってアプリケーションが使っている言語を判断します。 この一覧により、アプリ リソース、システム リソース、日付、時刻、数値、他のコンポーネントに使われる言語が決定されます。 たとえば、リソース管理システム ([**Windows.ApplicationModel.Resources**](https://msdn.microsoft.com/library/windows/apps/br206022)、[**Windows.ApplicationModel.Resources.Core**](https://msdn.microsoft.com/library/windows/apps/br225039)、[**WinJS.Resources Namespace**](https://msdn.microsoft.com/library/windows/apps/br229779)) は、アプリケーションの言語に応じて UI リソースを読み込みます。 
            [
              **Windows.Globalization**
            ](https://msdn.microsoft.com/library/windows/apps/br206813) も、アプリケーションの言語の一覧に基づいて形式を選びます。 アプリケーションの言語の一覧は、[**Windows.Globalization.ApplicationLanguages.Languages**](https://msdn.microsoft.com/library/windows/apps/hh972396) を使って取得できます。

言語とリソースの対応付けは容易ではありません。 対応付けは Windows で処理させることをお勧めします。言語タグには対応付けの優先順位に影響する多くのオプション コンポーネントがあり、実際にそのようなオプション コンポーネントに遭遇することがあるためです。

言語タグのオプション コンポーネントには、たとえば次のようなものがあります。

-   抑制スクリプト言語のスクリプト。 たとえば、en-Latn-US は en-US に対応付けられます。
-   地域。 たとえば、en-US は en に対応付けられます。
-   バリアント。 たとえば、de-DE-1996 は de-DE に対応付けられます。
-   -x などの拡張子。 たとえば、en-US-x-Pirate は en-US に対応付けられます。

言語タグには、xx または xx-yy という形式ではないためにまったく対応付けられないコンポーネントも多数あります。

-   zh-Hant は zh-Hans に対応付けられません。

Windows は、標準的でわかりやすい方法で言語の対応付けの優先順位を決定します。 たとえば、en-US が対応付けられる優先順位は en-US、en、en-GB のようになります。

-   Windows では地域間で対応付けを行います。 たとえば、en-US は en-US、次に en、その次に en-\* に対応付けられます。
-   Windows には、ある言語の第一地域などの、地域内でアフィニティの対応付けを行うための追加データが用意されています。 たとえば、fr-FR は fr-CA より fr-BE に強く対応付けられます。
-   Windows API を利用している場合、Windows で言語の対応付けがさらに向上された場合は無料で使うことができます。

一覧内の最初の言語の対応付けが、一覧内の 2 つ目の言語の対応付けよりも先に発生します (他の地域バリアントのものであっても同様)。 たとえば、アプリケーションの言語が en-US に指定されていると、fr-CA リソースより優先的に en-GB のリソースが選ばれます。 en という形式のリソースがない場合に限り、fr-CA のリソースが選ばれます。

アプリケーションの言語の一覧は、ユーザーの地域バリアントに設定されます。これは、アプリケーションの言語の一覧がアプリで提供された地域バリアントと異なる場合でも同様です。 たとえば、ユーザーが en-GB を話すがアプリでは en-US がサポートされるという場合、アプリケーションの言語の一覧に en-GB を含めるようにします。 この結果、日付、時刻、数値の形式はユーザーの期待 (en-GB) により近いものとなりますが、(言語の対応付けにより) UI リソースはアプリのサポート言語 (en-US) で読み込まれます。

アプリケーションの言語の一覧は、以下の項目から構成されます。

1.  
            **(オプション) 第 1 言語の上書き。**[**PrimaryLanguageOverride**](https://msdn.microsoft.com/library/windows/apps/hh972398) は、独自の独立した言語選択をユーザーに提示するアプリや、既定の言語選択を無効にしなければならない重大な理由があるアプリで利用できる、シンプルな上書き設定です。 詳しくは、[アプリ リソースとローカライズのサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=231501)をご覧ください。
2.  **アプリでサポートされるユーザーの言語。** これは、ユーザーの言語の優先順位を示した一覧です。 この一覧は、アプリのマニフェストのサポート対象言語の一覧によってフィルター処理されます。 アプリでサポートされる言語でユーザーの言語をフィルター処理することで、ソフトウェア開発キット (SDK)、クラス ライブラリ、依存性のあるフレームワーク パッケージ、そのアプリの間で一貫性が保たれます。
3.  **1 と 2 が空の場合、アプリでサポートされる既定または最初の言語。** ユーザーが、アプリでサポートされる言語のどれも使わない場合は、アプリで最優先にサポートされる言語がアプリケーションの言語として選ばれます。

サンプルについては、以下の「注釈」セクションをご覧ください。

### <span id="Set_the_HTTP_Accept_Language_header."></span><span id="set_the_http_accept_language_header."></span><span id="SET_THE_HTTP_ACCEPT_LANGUAGE_HEADER."></span>HTTP Accept-Language ヘッダーを設定します。

通常の Web 要求と XMLHttpRequest (XHR) で Windows ストア アプリとデスクトップ アプリから行われた HTTP 要求では、標準の HTTP Accept-Language ヘッダーが使われます。 既定では、HTTP ヘッダーは **[設定]**&gt;**[時刻と言語]**&gt;**[地域と言語]** に指定されたユーザーの優先順に並んで、ユーザーの言語の優先順位に設定されます。 この一覧内の各言語は、言語と重み付け (q) のニュートラルを含むようにさらに拡張されます。 たとえば、fr-FR と en-US のユーザーの言語一覧では、HTTP Accept-Language ヘッダーは "fr-FR, fr, en-US, en ("fr-FR,fr;q=0.8,en-US;q=0.5,en;q=0.3")" となります。

### <span id="Use_the_APIs_in_the_Windows.Globalization_namespace."></span><span id="use_the_apis_in_the_windows.globalization_namespace."></span><span id="USE_THE_APIS_IN_THE_WINDOWS.GLOBALIZATION_NAMESPACE."></span>Windows.Globalization 名前空間で API を使います。

通常、[**Windows.Globalization**](https://msdn.microsoft.com/library/windows/apps/br206813) 名前空間の API 要素は、アプリケーションの言語の一覧を使って言語を判断します。 どの言語にも対応する形式が存在しない場合は、ユーザー ロケールが使われます。 これはシステム クロックに使われているものと同じロケールです。 ユーザー ロケールは、**[設定]**&gt;**[時刻と言語]**&gt;**[地域と言語]**&gt;**[日付、時刻、地域の追加設定]**&gt;**[地域: 日付、時刻、または数値の形式の変更]** で確認できます。 **Windows.Globalization** API は、アプリケーションの言語の一覧の代わりに使う言語の一覧を指定するための上書きも受け付けます。


            [
              **Windows.Globalization**
            ](https://msdn.microsoft.com/library/windows/apps/br206813) には、ヘルパー オブジェクトとして提供される [**Language**](https://msdn.microsoft.com/library/windows/apps/br206804) オブジェクトもあります。 このオブジェクトを使うと、アプリは、言語のスクリプト、表示名、本来の名称などの、言語についての詳細も調べることができます。

### <span id="Use_geographic_region_when_appropriate."></span><span id="use_geographic_region_when_appropriate."></span><span id="USE_GEOGRAPHIC_REGION_WHEN_APPROPRIATE."></span>必要に応じて、地理的な地域を使います。

ユーザーに表示するコンテンツの選択方法として、言語ではなく、ユーザーの地理的な地域の設定を使うことができます。 たとえば、ニュース アプリは、既定では、ユーザーが住んでいる地域のコンテンツを表示します。この地域は、Windows がインストールされた時に設定され、前の手順で説明したように、Windows UI の **[地域: 日付、時刻、または数値の形式を変更する]** で確認できます。 住んでいる地域に関するユーザーの現在の設定は、[**Windows.System.UserProfile.GlobalizationPreferences.HomeGeographicRegion**](https://msdn.microsoft.com/library/windows/apps/br241829) を使って取得できます。


            [
              **Windows.Globalization**
            ](https://msdn.microsoft.com/library/windows/apps/br206813) には、ヘルパー オブジェクトとして提供される [**GeographicRegion**](https://msdn.microsoft.com/library/windows/apps/br206795) オブジェクトもあります。 このオブジェクトを使うと、アプリは、地域の表示名、本来の名称、使用通貨などの、特定地域についての詳細も調べることができます。

## <span id="Remarks"></span><span id="remarks"></span><span id="REMARKS"></span>注釈


次の表は、言語と地域の各設定によってアプリの UI に表示されるものの例を示しています。

<table border="1">
<colgroup>
<col width="20%" />
<col width="20%" />
<col width="20%" />
<col width="20%" />
<col width="20%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">アプリでサポートされる言語 (マニフェストで定義する)</th>
<th align="left">ユーザー言語の優先順位 (コントロール パネルで設定する)</th>
<th align="left">アプリの第 1 言語の上書き (オプション)</th>
<th align="left">アプリの言語</th>
<th align="left">アプリでユーザーに表示されるもの</th>
</tr>
</thead>
<tbody>
<tr>
<td align="left">英語 (英国) (既定)、ドイツ語 (ドイツ)</td>
<td align="left">英語 (英国)</td>
<td align="left">なし</td>
<td align="left">英語 (英国)</td>
<td align="left">UI: 英語 (英国)<br>日付/時刻/数値: 英語 (英国)</td>
</tr>
<tr>
<td align="left">ドイツ語 (ドイツ) (既定)、フランス語 (フランス)、イタリア語 (イタリア)</td>
<td align="left">フランス語 (オーストリア)</td>
<td align="left">なし</td>
<td align="left">フランス語 (オーストリア)</td>
<td align="left">UI: フランス語 (フランス) (フランス語 (オーストリア) からのフォールバック)<br>日付/時刻/数値: フランス語 (オーストリア)</td>
</tr>
<tr>
<td align="left">英語 (米国) (既定)、フランス語 (フランス)、英語 (英国)</td>
<td align="left">英語 (カナダ)、フランス語 (カナダ)</td>
<td align="left">なし</td>
<td align="left">英語 (カナダ)、フランス語 (カナダ)</td>
<td align="left">UI: 英語 (米国) (英語 (カナダ) からのフォールバック)<br>日付/時刻/数値: 英語 (カナダ)</td>
</tr>
<tr>
<td align="left">スペイン語 (スペイン) (既定)、スペイン語 (メキシコ)、スペイン語 (ラテン アメリカ)、ポルトガル語 (ブラジル)</td>
<td align="left">英語 (米国)</td>
<td align="left">なし</td>
<td align="left">スペイン語 (スペイン)</td>
<td align="left">UI: スペイン語 (スペイン) (英語に利用できるフォールバックがないため既定を使う)<br>日付/時刻/数値: スペイン語 (スペイン)</td>
</tr>
<tr>
<td align="left">カタルニア語 (既定)、スペイン語 (スペイン)、フランス語 (フランス)</td>
<td align="left">カタルニア語、フランス語 (フランス)</td>
<td align="left">なし</td>
<td align="left">カタルニア語、フランス語 (フランス)</td>
<td align="left">UI: ほとんどカタルニア語であるが、一部の文字列がカタルニア語では存在しないため、一部はフランス語 (フランス)<br>日付/時刻/数値: カタルニア語</td>
</tr>
<tr>
<td align="left">英語 (英国) (既定)、フランス語 (フランス)、ドイツ語 (ドイツ)</td>
<td align="left">ドイツ語 (ドイツ)、英語 (英国)</td>
<td align="left">英語 (英国) (アプリの UI でユーザーによって選ばれる)</td>
<td align="left">英語 (英国)、ドイツ語 (ドイツ)</td>
<td align="left">UI: 英語 (英国) (言語の上書き)<br>日付/時刻/数値: 英語 (英国)</td>
</tr>
</tbody>
</table>

 

## <span id="related_topics"></span>関連トピック


* [BCP-47 言語タグ](http://go.microsoft.com/fwlink/p/?linkid=227302)
* [言語の IANA 一覧](http://go.microsoft.com/fwlink/p/?linkid=227303)
* [アプリ リソースとローカライズのサンプル](http://go.microsoft.com/fwlink/p/?linkid=231501)
* [サポートされている言語](https://msdn.microsoft.com/library/windows/apps/jj657969)
 

 






<!--HONumber=Jun16_HO4-->


