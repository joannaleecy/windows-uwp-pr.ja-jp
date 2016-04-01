# <a name='report-top'></a> Localization Handoff Report

## Summary
 Total Files | 3

## File List
 Source File | Status | Details 
 ----------- | ------ | ------- 
 [windows-apps-src\debug-test-perf\device-portal-api-core.md](https://github.com/Microsoft/windows-apps/blob/0189cf2891134aa2915f163bb8f769b845753c23/windows-apps-src/debug-test-perf/device-portal-api-core.md) | HandedOffFailed | [Details](#f3dbd46f0c5ef656a76065845704d5c5e36971041858)
 [windows-apps-src\TOC.md](https://github.com/Microsoft/windows-apps/blob/0189cf2891134aa2915f163bb8f769b845753c23/windows-apps-src/TOC.md) | OutofSyncHandedBackSuccess | [Details](#45051cc1731c1b1b2a48be53f4df7c7a2b38772f3603)
 [windows-apps-src\xbox-apps\known-issues.md](https://github.com/Microsoft/windows-apps/blob/0189cf2891134aa2915f163bb8f769b845753c23/windows-apps-src/xbox-apps/known-issues.md) | HandedOffSuccess | [Details](#2dd21ced402c1e0c10425fc10d67a700b241376f3699)

## Item Details
##### <a name='f3dbd46f0c5ef656a76065845704d5c5e36971041858'></a> Source: [windows-apps-src\debug-test-perf\device-portal-api-core.md](https://github.com/Microsoft/windows-apps/blob/0189cf2891134aa2915f163bb8f769b845753c23/windows-apps-src/debug-test-perf/device-portal-api-core.md)
* Status: HandedOffFailed
* Target File: 
* Handoff File: 
* Handoff Datetime: 0001-01-01 00:00:00
* Handoff Reason: Ignored
* Handoff Error: [handoff_transform_failed](#f3dbd46f0c5ef656a76065845704d5c5e36971041858handoff_transform_failed)
* Archive File: 
* Archive Datetime: 0001-01-01 00:00:00
* Handback File: 
* Handback Datetime: 0001-01-01 00:00:00
* [Back to Top](#report-top)

##### <a name='45051cc1731c1b1b2a48be53f4df7c7a2b38772f3603'></a> Source: [windows-apps-src\TOC.md](https://github.com/Microsoft/windows-apps/blob/0189cf2891134aa2915f163bb8f769b845753c23/windows-apps-src/TOC.md)
* Status: OutofSyncHandedBackSuccess
* Target File: 
* Handoff File: [TOC.350f1fabd525c277c15320fda16caad6a319dd0a.ja-jp.xlf](https://github.com/Microsoft/WDG.handoff/blob/71a3179255f97912d2201382a37462010ef89c33/ol-handoff/Microsoft/windows-apps.ja-jp/master/TOC.350f1fabd525c277c15320fda16caad6a319dd0a.ja-jp.xlf)
* Handoff Datetime: 2016-04-01 21:49:26
* Handoff Reason: Include
* Archive File: 
* Archive Datetime: 0001-01-01 00:00:00
* Handback File: 
* Handback Datetime: 0001-01-01 00:00:00
* Current Target File: [windows-apps-src\TOC.md](https://github.com/Microsoft/windows-apps.ja-jp/blob/07be5122e91ac7362ec48ba24a5713a40e1deabe/windows-apps-src/TOC.md)
* Current Handback File: [TOC.350f1fabd525c277c15320fda16caad6a319dd0a.ja-jp.xlf](https://github.com/Microsoft/WDG.handback/blob/8be93990f1a1d8c5e0e1a536c9e58b19172208bc/ol-handback/Microsoft/windows-apps.ja-jp/master/TOC.350f1fabd525c277c15320fda16caad6a319dd0a.ja-jp.xlf)
* Current Handback Datetime: 2016-03-30 09:09:02
* [Back to Top](#report-top)

##### <a name='2dd21ced402c1e0c10425fc10d67a700b241376f3699'></a> Source: [windows-apps-src\xbox-apps\known-issues.md](https://github.com/Microsoft/windows-apps/blob/0189cf2891134aa2915f163bb8f769b845753c23/windows-apps-src/xbox-apps/known-issues.md)
* Status: HandedOffSuccess
* Target File: 
* Handoff File: [known-issues.83c75815621268c5c51534a658527cef71ffe8bd.ja-jp.xlf](https://github.com/Microsoft/WDG.handoff/blob/71a3179255f97912d2201382a37462010ef89c33/ol-handoff/Microsoft/windows-apps.ja-jp/master/known-issues.83c75815621268c5c51534a658527cef71ffe8bd.ja-jp.xlf)
* Handoff Datetime: 2016-04-01 21:49:26
* Handoff Reason: Include
* Archive File: 
* Archive Datetime: 0001-01-01 00:00:00
* Handback File: 
* Handback Datetime: 0001-01-01 00:00:00
* [Back to Top](#report-top)


## Error Details
##### <a name='f3dbd46f0c5ef656a76065845704d5c5e36971041858handoff_transform_failed'></a> Source: [windows-apps-src\debug-test-perf\device-portal-api-core.md](#f3dbd46f0c5ef656a76065845704d5c5e36971041858)
* Error Code: handoff_transform_failed
* Error Message: Handoff source file: windows-apps-src\debug-test-perf\device-portal-api-core.md transformed failed.
* Retriable: False
* Error Details: {"internal_error_code":"handoff_transform_failed","internal_error_message":"Handoff source file: windows-apps-src\\debug-test-perf\\device-portal-api-core.md transformed failed.","internal_error_retriable":false,"exception_message":"One or more errors occurred.","exception_type":"System.AggregateException","stack_trace":"   at System.Threading.Tasks.Task`1.GetResultCore(Boolean waitCompletionNotification)\r\n   at Microsoft.OpenLocalization.Transformer.MarkdownJavascriptTransformer.MarkdownToXliffCore(Stream sourceStream, Stream xliffStream, Stream skeletonStream, String contentClass, String locale)\r\n   at Microsoft.OpenLocalization.Transformer.XliffTransformerExtensions.MarkdownToXliff(IMarkdownTransformer markdownTransformer, Stream sourceStream, Stream xliffStream, Stream skeletonStream, String contentClass, String locale, String xliffVersion)\r\n   at Microsoft.OpenLocalization.Transformer.XliffTransformerExtensions.MarkdownToXliff(IMarkdownTransformer markdownTransformer, String markdownFile, String xliffFile, String skeletonFile, String locale, String xliffVersion)\r\n   at Microsoft.OpenLocalization.Helper.XliffTransformUtil.MarkdownToXliff(String mdfile, String xliffFile, String skeletonFile, String targetLocale, String xliffVersion, Boolean useJavascriptTransformer) in C:\\code\\deploy\\src\\OpenLocalization\\Helper\\XliffTransformUtil.cs:line 27\r\n   at Microsoft.OpenLocalization.Localization.LocalizationCore.<>c__DisplayClass10_1.<GetHandoffFiles>b__1(Tuple`3 handoff) in C:\\code\\deploy\\src\\OpenLocalization\\Localization\\HandoffCore.cs:line 388","extended_information":null}


Generated by OpenLocalization.
