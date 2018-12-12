---
title: ゲーム開発用の CPUSets
description: この記事では、ユニバーサル Windows プラットフォーム (UWP) の新しい CPUSets API の概要を説明し、ゲームとアプリケーションの開発に関連する主な情報を紹介します。
ms.topic: article
ms.localizationpriority: medium
ms.date: 02/08/2017
ms.openlocfilehash: 49662d476d6d022ca05d53e9358fc547fda92a32
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8945013"
---
# <a name="cpusets-for-game-development"></a>ゲーム開発用の CPUSets

## <a name="introduction"></a>はじめに

ユニバーサル Windows プラットフォーム (UWP) は、多様な家庭用電子機器の中核に位置付けられています。 そのため、ゲームや埋め込みアプリケーションからサーバーで実行されるエンタープライズ ソフトウェアまで、あらゆる種類のアプリケーションのニーズに対応する汎用 API が必要です。 この API によって提供される適切な情報を活用して、ゲームがどのようなハードウェアでも最適な状態で実行されることを保証できます。

## <a name="cpusets-api"></a>CPUSets API

CPUSets API によって、スレッドをスケジュールするためにどの CPU セットを利用できるかを制御できます。 スレッドをスケジュールする場所を制御するために、2 つの関数を利用できます。
- **SetProcessDefaultCpuSets**: この関数を使用すると、スレッドが特定の CPU セットに割り当てられていない場合に、新しいスレッドが実行される CPU セットを指定できます。
- **SetThreadSelectedCpuSets**: この関数を使用すると、特定のスレッドが実行される CPU セットを制限できます。

**SetProcessDefaultCpuSets** 関数を使わない場合は、新しく作成されたスレッドは、プロセスで使用できる任意の CPU セットでスケジュールすることができます。 このセクションでは、CPUSets API の基本事項について説明します。

### <a name="getsystemcpusetinformation"></a>GetSystemCpuSetInformation

情報を収集するために使用される最初の API は、**GetSystemCpuSetInformation** 関数です。 この関数は、タイトル コードによって提供される **SYSTEM_CPU_SET_INFORMATION** オブジェクトの配列に情報を挿入します。 実行先のメモリはゲーム コードによって割り当てられる必要があり、そのサイズは **GetSystemCpuSetInformation** 自体を呼び出すことによって決定されます。 そのためには、次の例に示されているように、**GetSystemCpuSetInformation** を 2 回呼び出す必要があります。

```
unsigned long size;
HANDLE curProc = GetCurrentProcess();
GetSystemCpuSetInformation(nullptr, 0, &size, curProc, 0);

std::unique_ptr<uint8_t[]> buffer(new uint8_t[size]);

PSYSTEM_CPU_SET_INFORMATION cpuSets = reinterpret_cast<PSYSTEM_CPU_SET_INFORMATION>(buffer.get());
  
GetSystemCpuSetInformation(cpuSets, size, &size, curProc, 0);
```

返される **SYSTEM_CPU_SET_INFORMATION** の各インスタンスには、一意の処理装置 (CPU セットとも呼ばれる) の 1 つに関する情報が格納されます。 これは、必ずしも一意の物理ハードウェアを表すとは限りません。 ハイパースレッディングを利用する CPU では、1 つの物理的な処理コア上で複数の論理コアが実行されます。 同一の物理コア上にある複数の論理コアで複数のスレッドをスケジュールする場合は、ハードウェア レベルでリソースを最適化できますが、それ以外の場合は、カーネル レベルでの追加の処理が必要になります。 2 つのスレッドが同じ物理コア上の異なる論理コアでスケジュールされている場合、CPU 時間を共有する必要がありますが、同じ論理コアでスケジュールされている場合よりも効率的に実行されます。

### <a name="systemcpusetinformation"></a>SYSTEM_CPU_SET_INFORMATION

**GetSystemCpuSetInformation** から返されるこのデータ構造体の各インスタンスには、スレッドをスケジュールできる一意の処理装置に関する情報が格納されます。 可能なターゲット デバイスの範囲を考えると、**SYSTEM_CPU_SET_INFORMATION** データ構造体の情報の多くがゲーム開発には適用されない可能性があります。 表 1 では、ゲームの開発に役立つデータ メンバーについて説明します。

 **表 1. ゲーム開発に役立つデータ メンバー**

| メンバー名  | データ型 | 説明 |
| ------------- | ------------- | ------------- |
| Type  | CPU_SET_INFORMATION_TYPE  | 構造体内の情報の種類です。 この値が **CpuSetInformation** ではない場合、この値は無視されます。  |
| Id  | unsigned long  | 指定した CPU セットの ID です。 これは、**SetThreadSelectedCpuSets** などの CPU セット関数で使用する必要がある ID です。  |
| Group  | unsigned short  | CPU セットの "プロセッサ グループ" を指定します。 プロセッサ グループを使用すると、PC で 64 個を超える論理コアを使用でき、システムの実行中に CPU のホット スワップが可能になります。 サーバー以外で複数のグループを持つ PC は一般的ではありません。 ほとんどのコンシューマー向け PC ではプロセッサ グループは 1 つだけであるため、大規模なサーバーやサーバー ファームで実行されるアプリケーションを作成している場合を除き、単一グループの CPU セットを使用することをお勧めします。 この構造体の他のすべての値は、グループを基準にしています。  |
| LogicalProcessorIndex  | unsigned char  | グループを基準とした CPU セットのインデックス。  |
| CoreIndex  | unsigned char  | グループを基準とした、CPU セットが配置されている物理 CPU コアのインデックス。  |
| LastLevelCacheIndex  | unsigned char  | グループを基準とした、この CPU セットに関連付けられているラスト レベル キャッシュのインデックス。 システムが NUMA ノードを利用している場合を除き、これは最も低速のキャッシュで、通常、L2 または L3 キャッシュです。  |

<br />

その他のデータ メンバーが提供する情報は、コンシューマー向け PC やコンシューマー向けデバイスの CPU との関連性が低く、有用ではない傾向があります。 返されるデータによって提供される情報は、さまざまな方法でスレッドを編成するために使用できます。 このホワイト ペーパーの「[ゲーム開発に関する考慮事項](#considerations-for-game-development)」では、このデータを活用してスレッドの割り当てを最適化する方法について詳しく説明しています。

次に、さまざまな種類のハードウェアで実行される UWP アプリケーションから収集される情報の種類について、例をいくつか示します。

**表 2. Microsoft Lumia 950 で実行されている UWP アプリから返された情報。 これは、複数のラスト レベル キャッシュを持つシステムの例です。 Lumia 950 は、デュアル コア ARM Cortex A57 CPU とクアッド コア ARM Cortex A53 CPU を内蔵した Qualcomm 808 Snapdragon プロセッサを搭載しています。**

  ![表 2](images/cpusets-table2.png)

**表 3. 一般的な PC で実行されている UWP アプリから返された情報。 これは、ハイパースレッディングを使用しているシステムの例です。各物理コアには、スレッドをスケジュールできる論理コアが 2 つあります。 この例では、システムに Intel Xenon CPU E5-2620 が搭載されています。**

  ![表 3](images/cpusets-table3.png)

**表 4. クアッド コア Microsoft Surface Pro 4 で実行されている UWP アプリから返された情報。 このシステムには、Intel Core i5-6300 CPU が搭載されています。**

  ![表 4](images/cpusets-table4.png)

### <a name="setthreadselectedcpusets"></a>SetThreadSelectedCpuSets

これで CPU セットに関する情報が利用できるようになりました。この情報を使ってスレッドを編成できます。 **CreateThread** で作成されたスレッドのハンドルは、スレッドをスケジュールできる対象の CPU セットの ID の配列と共に、この関数に渡されます。 その使用例の 1 つを、次のコードに示します。

```
HANDLE audioHandle = CreateThread(nullptr, 0, AudioThread, nullptr, 0, nullptr);
unsigned long cores [] = { cpuSets[0].CpuSet.Id, cpuSets[1].CpuSet.Id };
SetThreadSelectedCpuSets(audioHandle, cores, 2);
```
この例では、スレッドは **AudioThread** として宣言されている関数に基づいて作成されます。 このスレッドは、2 つの CPU セットのいずれかにスケジュールすることができます。 スレッドによる CPU セットの所有権は排他的ではありません。 特定の CPU セットにロックされずに作成されたスレッドが、**AudioThread** の時間を奪う可能性があります。 同様に、作成された他のスレッドが、後でこれらの CPU セットの一方または両方にロックされる可能性もあります。

### <a name="setprocessdefaultcpusets"></a>SetProcessDefaultCpuSets

**SetThreadSelectedCpuSets** の逆が **SetProcessDefaultCpuSets** です。 スレッドは、作成されるときに、特定の CPU セットにロックされる必要はありません。 これらのスレッドを特定の CPU セット (たとえば、レンダリング スレッドまたはオーディオのスレッドで使われるもの) で実行する必要がない場合は、この関数を使用して、スレッドをスケジュールできる対象のコアを指定できます。

## <a name="considerations-for-game-development"></a>ゲーム開発に関する考慮事項

既に説明したように、CPUSets API は、スレッドのスケジュールに関して多くの情報と柔軟性を提供します。 ボトムアップのアプローチでこのデータの用途を探すよりも、トップダウンのアプローチで、一般的なシナリオに対応するためにこのデータをどのように利用できるかを考える方が効果的です。

### <a name="working-with-time-critical-threads-and-hyperthreading"></a>タイム クリティカルなスレッドとハイパースレッディングの使用

この方法は、ゲームで複数のスレッドをリアルタイムで実行する必要があり、他のワーカー スレッドが必要とする CPU 時間が比較的少ない場合に有効です。 最適なゲーム エクスペリエンスを提供するために、継続的 BGM など、いくつかのタスクは中断することなく実行される必要があります。 オーディオ スレッドでは、1 つのフレームのスタベーションによってポップ ノイズやグリッチ ノイズが発生する可能性があるため、各フレームで必要な量の CPU 時間が提供されることが重要です。

**SetThreadSelectedCpuSets** を **SetProcessDefaultCpuSets** と組み合わせて使用することにより、大量のスレッドでもワーカー スレッドによって中断されることなく継続できます。 **SetThreadSelectedCpuSets** を使用して、大量のスレッドを特定の CPU セットに割り当てることができます。 次に、**SetProcessDefaultCpuSets** を使用して、作成済みで割り当てられていないスレッドを、他の CPU セットに割り当てることができます。 ハイパースレッディングを利用する CPU の場合は、論理コアが同一物理コア上にあることも重要です。 リアルタイムの応答性を必要とするスレッドと同じ物理コアを共有する論理コアで、ワーカー スレッドを実行しないでください。 次のコードは、PC でハイパースレッディングを使用しているかどうかを判断する方法を示しています。

```
unsigned long retsize = 0;
(void)GetSystemCpuSetInformation( nullptr, 0, &retsize,
    GetCurrentProcess(), 0);
 
std::unique_ptr<uint8_t[]> data( new uint8_t[retsize] );
if ( !GetSystemCpuSetInformation(
    reinterpret_cast<PSYSTEM_CPU_SET_INFORMATION>( data.get() ),
    retsize, &retsize, GetCurrentProcess(), 0) )
{
    // Error!
}
 
std::set<DWORD> cores;
std::vector<DWORD> processors;
uint8_t const * ptr = data.get();
for( DWORD size = 0; size < retsize; ) {
    auto info = reinterpret_cast<const SYSTEM_CPU_SET_INFORMATION*>( ptr );
    if ( info->Type == CpuSetInformation ) {
         processors.push_back( info->CpuSet.Id );
         cores.insert( info->CpuSet.CoreIndex );
    }
    ptr += info->Size;
    size += info->Size;
}
 
bool hyperthreaded = processors.size() != cores.size();
```

システムでハイパースレッディングを利用している場合、既定の CPU セットに、リアルタイム スレッドと同じ物理コア上にある論理コアが含まれていないことが重要です。 システムがハイパースレッディングを利用していない場合は、既定の CPU セットに、オーディオ スレッドを実行する CPU セットと同じコアが含まれていないことを確認するだけで済みます。

物理コアに基づいてスレッドを編成する例については、「[その他の情報](#additional-resources)」セクションに示されている GitHub リポジトリで入手できる CPUSets のサンプルをご覧ください。

### <a name="reducing-the-cost-of-cache-coherence-with-last-level-cache"></a>ラスト レベル キャッシュによるキャッシュの一貫性のコスト削減

キャッシュの一貫性とは、同じデータを操作する複数のハードウェア リソースの間でメモリにキャッシュされた内容が同じであるという概念です。 別のコアでスケジュールされている複数のスレッドが同じデータを操作する場合、異なるキャッシュにある同じデータの別のコピーを操作している可能性があります。 正しい結果を得るには、これらのキャッシュが相互に一貫している必要があります。 複数のキャッシュ間で一貫性を維持することは、割高になりますが、マルチコア システムを運用するために必要なことです。 さらに、キャッシュの一貫性は完全にクライアント コードの制御の範囲外です。基になるシステムが、独立してコア間の共有メモリ リソースにアクセスすることによって、キャッシュを最新の状態に保ちます。

ゲームに特に大量のデータを共有する複数のスレッドがある場合、ラスト レベル キャッシュを共有する CPU セットでスレッドをスケジュールすることによって、キャッシュの一貫性のコストを最小限に抑えることができます。 ラスト レベル キャッシュは、NUMA ノードを使用しないシステムのコアで使用可能な最も低速のキャッシュです。 ゲーム PC で NUMA ノードが使用されていることは非常にまれです。 コアがラスト レベル キャッシュを共有していない場合、一貫性を維持するには、より高いレベルの (したがって低速の) メモリ リソースにアクセスする必要があります。 キャッシュと物理コアを共有する個別の CPU セットに 2 つのスレッドをロックすると、特定のフレームで 50% 以上の時間を必要としない場合、個別の物理コアでスレッドをスケジュールするよりもパフォーマンスが高くなります。 

次のコード例では、頻繁に通信するスレッドがラスト レベル キャッシュを共有できるかどうかを判断する方法を示します。

```
unsigned long retsize = 0;
(void)GetSystemCpuSetInformation(nullptr, 0, &retsize,
    GetCurrentProcess(), 0);
 
std::unique_ptr<uint8_t[]> data(new uint8_t[retsize]);
if (!GetSystemCpuSetInformation(
    reinterpret_cast<PSYSTEM_CPU_SET_INFORMATION>(data.get()),
    retsize, &retsize, GetCurrentProcess(), 0))
{
    // Error!
}
 
unsigned long count = retsize / sizeof(SYSTEM_CPU_SET_INFORMATION);
bool sharedcache = false;
 
std::map<unsigned char, std::vector<SYSTEM_CPU_SET_INFORMATION>> cachemap;
for (size_t i = 0; i < count; ++i)
{
    auto cpuset = reinterpret_cast<PSYSTEM_CPU_SET_INFORMATION>(data.get())[i];
    if (cpuset.Type == CPU_SET_INFORMATION_TYPE::CpuSetInformation)
    {
        if (cachemap.find(cpuset.CpuSet.LastLevelCacheIndex) == cachemap.end())
        {
            std::pair<unsigned char, std::vector<SYSTEM_CPU_SET_INFORMATION>> newvalue;
            newvalue.first = cpuset.CpuSet.LastLevelCacheIndex;
            newvalue.second.push_back(cpuset);
            cachemap.insert(newvalue);
        }
        else
        {
            sharedcache = true;
            cachemap[cpuset.CpuSet.LastLevelCacheIndex].push_back(cpuset);
        }
    }
}
```

図 1 に示すキャッシュ レイアウトは、システムに見られるレイアウトの例です。 次の図は、Microsoft Lumia 950 のキャッシュを図示したものです。 CPU 256 と CPU 260 の間でスレッド間通信が発生する場合、システムが L2 キャッシュの一貫性を維持する必要があるため、大きなオーバーヘッドが発生します。

**図 1. Microsoft Lumia 950 デバイスのキャッシュ アーキテクチャ。**

![Lumia 950 のキャッシュ](images/cpusets-lumia950cache.png)

## <a name="summary"></a>まとめ

UWP 開発で使用できる CPUSets API によって、相当な量の情報が提供され、マルチスレッド オプションを制御できます。 Windows 開発用の以前のマルチスレッド API と比較して、複雑な部分が増えているため学習に時間が必要ですが、柔軟性が向上しているため、最終的にはさまざまなコンシューマー向け PC やその他のハードウェア ターゲットでパフォーマンスが向上します。

## <a name="additional-resources"></a>その他の資料
- [CPU セット (MSDN)](https://msdn.microsoft.com/library/windows/desktop/mt186420(v=vs.85).aspx)
- [ATG によって提供される CPUSets のサンプル](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/CPUSets)
- [Xbox One の UWP](index.md)

