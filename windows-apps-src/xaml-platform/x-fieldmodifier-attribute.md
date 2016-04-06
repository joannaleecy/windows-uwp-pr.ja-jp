---
description: Modifies XAML compilation behavior, such that fields for named object references are defined with public access rather than the private default behavior.
title: xFieldModifier attribute
ms.assetid: 6FBCC00B-848D-4454-8B1F-287CA8406DDF
---

# x:FieldModifier attribute

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Modifies XAML compilation behavior, such that fields for named object references are defined with **public** access rather than the **private** default behavior.

## XAML attribute usage

``` syntax
<object x:FieldModifier="public".../>
```

## Dependencies

[x:Name attribute](x-name-attribute.md) must also be provided on the same element.

## Remarks

The value for the **x:FieldModifier** attribute will vary by programming language. The string to use will depend on how each language implements its **CodeDomProvider** and the type converters it returns to define the meanings for **TypeAttributes.Public** and **TypeAttributes.NotPublic**. For C#, Microsoft Visual Basic or Visual C++ component extensions (C++/CX), you can give the string value "public" or "Public"; the parser doesn't enforce case on this attribute value.

You can also specify **NonPublic** (**internal** in C# or C++/CX, **Friend** in Visual Basic) but this is uncommon. Internal access doesn't have any application to the Windows Runtime XAML code generation model. Private access is the default.

**x:FieldModifier** is only relevant for elements with an [x:Name attribute](x-name-attribute.md), because that name is used to reference the field once it is public.

**Note**  Windows Runtime XAML doesn't support **x:ClassModifier** or **x:Subclass**.



<!--HONumber=Mar16_HO1-->


