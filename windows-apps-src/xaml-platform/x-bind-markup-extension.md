---
description: The xBind markup extension is an alternative to Binding. xBind lacks some of the features of Binding, but it runs in less time and less memory than Binding and supports better debugging.
title: xBind markup extension
ms.assetid: 529FBEB5-E589-486F-A204-B310ACDC5C06
---

# {x:Bind} markup extension

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

**Note**  For general info about using data binding in your app with **{x:Bind}** (and for an all-up comparison between **{x:Bind}** and **{Binding}**), see [Data binding in depth](https://msdn.microsoft.com/library/windows/apps/mt210946).

The **{x:Bind}** markup extension—new for Windows 10—is an alternative to **{Binding}**. **{x:Bind}** lacks some of the features of **{Binding}**, but it runs in less time and less memory than **{Binding}** and supports better debugging.

At XAML load time, **{x:Bind}** is converted into what you can think of as a binding object, and this object gets a value from a property on a data source. The binding object can optionally be configured to observe changes in the value of the data source property and refresh itself based on those changes. It can also optionally be configured to push changes in its own value back to the source property. The binding objects created by **{x:Bind}** and **{Binding}** are largely functionally equivalent. But **{x:Bind}** executes special-purpose code, which it generates at compile-time, and **{Binding}** uses general-purpose runtime object inspection. Consequently, **{x:Bind}** bindings (often referred-to as compiled bindings) have great performance, provide compile-time validation of your binding expressions, and support debugging by enabling you to set breakpoints in the code files that are generated as the partial class for your page. These files can be found in your `obj` folder, with names like (for C#) `<view name>.g.cs`.

**Sample apps that demonstrate {x:Bind}**

-   [{x:Bind} sample](http://go.microsoft.com/fwlink/p/?linkid=619989)
-   [QuizGame](https://github.com/Microsoft/Windows-appsample-quizgame)
-   [XAML UI Basics sample](http://go.microsoft.com/fwlink/p/?linkid=619992)

## XAML attribute usage

``` syntax
<object property="{x:Bind}" .../>
-or-
<object property="{x:Bind propertyPath}" .../>
-or-
<object property="{x:Bind bindingProperties}" .../>
-or-
<object property="{x:Bind propertyPath, bindingProperties}" .../>
```

| Term | Description |
|------|-------------|
| _propertyPath_ | A string that specifies the property path for the binding. More info is in the [Property path](#property-path) section below. |
| _bindingProperties_ |
| _propName_=_value_\[, _propName_=_value_\]* | One or more binding properties that are specified using a name/value pair syntax. |
| _propName_ | The string name of the property to set on the binding object. For example, "Converter". | 
| _value_ | The value to set the property to. The syntax of the argument depends on the property being set. Here's an example of a _propName_=_value_ usage where the value is itself a markup extension: `Converter={StaticResource myConverterClass}`. For more info, see [Properties that you can set with {x:Bind}](#properties-you-can-set) section below. | 

## Property path

*PropertyPath* sets the **Path** for an **{x:Bind}** expression. **Path** is a property path specifying the value of the property, sub-property, field, or method that you're binding to (the source). You can mention the name of the **Path** property explicitly: `{Binding Path=...}`. Or you can omit it: `{Binding ...}`.

**{x:Bind}** does not use the **DataContext** as a default source—instead, it uses the page or user control itself. So it will look in the code-behind of your page or user control for properties, fields, and methods. To expose your view model to **{x:Bind}**, you will typically want to add new fields or properties to the code behind for your page or user control. Steps in a property path are delimited by dots (.), and you can include multiple delimiters to traverse successive sub-properties. Use the dot delimiter regardless of the programming language used to implement the object being bound to.

For example: in a page, **Text="{x:Bind Employee.FirstName}"** will look for an **Employee** member on the page and then a **FirstName** member on the object returned by **Employee**. If you are binding an items control to a property that contains an employee's dependents, your property path might be "Employee.Dependents", and the item template of the items control would take care of displaying the items in "Dependents".

For C++/CX, **{x:Bind}** cannot bind to private fields and properties in the page or data model – you will need to have a public property for it to be bindable. The surface area for binding needs to be exposed as CX classes/interfaces so that we can get the relevant metadata. The **\[Bindable\]** attribute should not be needed.

If the data source is a collection, then a property path can specify items in the collection by their position or index. For example, "Teams\[0\].Players", where the literal "\[\]" encloses the "0" that requests the first item in a zero-indexed collection.

To use an indexer, the model needs to implement **IList&lt;T&gt;** or **IVector&lt;T&gt;** on the type of the property that is going to be indexed. If the type of the indexed property supports **INotifyCollectionChanged** or **IObservableVector** and the binding is OneWay or TwoWay, then it will register and listen for change notifications on those interfaces. The change detection logic will update based on all collection changes, even if that doesn’t affect the specific indexed value. This is because the listening logic is common across all instances of the collection.

To bind to attached properties, you need to put the class and property name into parentheses after the dot. For example **Text="{x:Bind Button22.(Grid.Row)}"**. If the property is not declared in a Xaml namespace, then you will need to prefix it with a xml namespace, which you should map to a code namespace at the head of the document.

Compiled bindings are strongly typed, and will resolve the type of each step in a path. If the type returned doesn’t have the member, it will fail at compile time. You can specify a cast to tell binding the real type of the object. In the following case, **obj** is a property of type object, but contains a text box, so we can use **Text="{x:Bind obj.(TextBox.Text)}"**.

The **groups3** field in **Text="{x:Bind groups3\[0\].(data:SampleDataGroup.Title)}"** is a dictionary of objects, so you must cast it to **data:SampleDataGroup**. Note the use of the **data:** namespace prefix for mapping the object type to a namespace that isn't part of the default XAML namespace.

With **x:Bind**, you do not need to use **ElementName=xxx** as part of the binding expression. With **x:Bind**, you can use the name of the element as the first part of the path for the binding because named elements become fields within the page or user control that represents the root binding source.

Event binding is a new feature for compiled binding. It enables you to specify the handler for an event using a binding, rather than it having to be a method on the code behind. For example: **Click="{x:Bind rootFrame.GoForward}"**.

For events, the target method must not be overloaded and must also:

-   Match the signature of the event.
-   OR have no parameters.
-   OR have the same number of parameters of types that are assignable from the types of the event parameters.

In generated code-behind, compiled binding handles the event and routes it to the method on the model, evaluating the path of the binding expression when the event occurs. This means that, unlike property bindings, it doesn’t track changes to the model.

For more info about the string syntax for a property path, see [Property-path syntax](property-path-syntax.md), keeping in mind the differences described here for **{x:Bind}**.

##  Properties that you can set with {x:Bind}


**{x:Bind}** is illustrated with the *bindingProperties* placeholder syntax because there are multiple read/write properties that can be set in the markup extension. The properties can be set in any order with comma-separated *propName*=*value* pairs. Note that you cannot include line breaks in the binding expression. Some of the properties require types that don't have a type conversion, so these require markup extensions of their own nested within the **{x:Bind}**.

These properties work in much the same way as the properties of the [**Binding**](https://msdn.microsoft.com/library/windows/apps/br209820) class.

| Property | Description |
|----------|-------------|
| **Path** | See the [Property path](#property-path) section above. |
| **Converter** | Specifies the converter object that is called by the binding engine. The converter can be set in XAML, but only if you refer to an object instance that you've assigned in a [{StaticResource} markup extension](staticresource-markup-extension.md) reference to that object in the resource dictionary. |
| **ConverterLanguage** | Specifies the culture to be used by the converter. (If you're setting **ConverterLanguage** you should also be setting **Converter**.) The culture is set as a standards-based identifier. For more info, see [**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/hh701880). |
| **ConverterParameter** | Specifies the converter parameter that can be used in converter logic. (If you're setting **ConverterParameter** you should also be setting **Converter**.) Most converters use simple logic that get all the info they need from the passed value to convert, and don't need a **ConverterParameter** value. The **ConverterParameter** parameter is for moderately advanced converter implementations that have more than one logic that keys off what's passed in **ConverterParameter**. You can write a converter that uses values other than strings but this is uncommon, see Remarks in [**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/br209827) for more info. |
| **FallbackValue** | Specifies a value to display when the source or path cannot be resolved. |
| **Mode** | Specifies the binding mode, as one of these strings: "OneTime", "OneWay", or "TwoWay". The default is "OneTime". Note that this differs from the default for **{Binding}**, which is "OneWay" in most cases. |
| **TargetNullValue** | Specifies a value to display when the source value resolves but is explicitly **null**. | 

**Note**  If you're converting markup from **{Binding}** to **{x:Bind}**, then be aware of the differences in default values for the **Mode** property.
 
## Remarks

Because **{x:Bind}** uses generated code to achieve its benefits, it requires type information at compile time. This means that you cannot bind to properties where you do not know the type ahead of time. Because of this, you cannot use **{x:Bind}** with the **DataContext** property, which is of type **Object**, and is also subject to change at run time.

When using **{x:Bind}** with data templates, you must indicate the type being bound to by setting an **x:DataType** value, as shown in the example below. You can also set the type to an interface or base class type, and then use casts if necessary to formulate a full expression.

Compiled bindings depend on code generation. So if you use **{x:Bind}** in a resource dictionary then the resource dictionary needs to have a code-behind class. See [Resource dictionaries with {x:Bind}](../data-binding/data-binding-in-depth.md#resource-dictionaries-with-x-bind) for a code example.

**Important**   If you set a local value for a property that previously had a **{x:Bind}** markup extension to provide a local value, the binding is completely removed.

**Tip**   If you need to specify a single curly brace for a value, such as in [**Path**](https://msdn.microsoft.com/library/windows/apps/br209830) or [**ConverterParameter**](https://msdn.microsoft.com/library/windows/apps/br209827), precede it with a backslash: `\{`. Alternatively, enclose the entire string that contains the braces that need escaping in a secondary quotation set, for example `ConverterParameter='{Mix}'`.

[**Converter**](https://msdn.microsoft.com/library/windows/apps/br209826), [**ConverterLanguage**](https://msdn.microsoft.com/library/windows/apps/hh701880) and **ConverterLanguage** are all related to the scenario of converting a value or type from the binding source into a type or value that is compatible with the binding target property. For more info and examples, see the "Data conversions" section of [Data binding in depth](https://msdn.microsoft.com/library/windows/apps/mt210946).

**{x:Bind}** is a markup extension only, with no way to create or manipulate such bindings programmatically. For more info about markup extensions, see [XAML overview](xaml-overview.md).

## Examples

```XAML
<Page x:Class="QuizGame.View.HostView" ... >
    <Button Content="{x:Bind Path=ViewModel.NextButtonText, Mode=OneWay}" ... />
</Page>
```

This example XAML uses **{x:Bind}** with a **ListView.ItemTemplate** property. Note the declaration of an **x:DataType** value.

```XAML
  <DataTemplate x:Key="SimpleItemTemplate" x:DataType="data:SampleDataGroup">
    <StackPanel Orientation="Vertical" Height="50">
      <TextBlock Text="{x:Bind Title}"/>
      <TextBlock Text="{x:Bind Description}"/>
    </StackPanel>
  </DataTemplate>
```



<!--HONumber=Mar16_HO1-->


