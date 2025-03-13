when you bind a value to an Input component, Razor generates 3 properties:

- TValue Value to set the current property value
- EventCallback<TValue> ValueChanged to be notified when the html input value changed (<input onchange="">), so you can update the model value
- Expression<Func<TValue>> ValueExpression to compute the field name for the validation context

generic form: \
https://www.meziantou.net/automatically-generate-a-form-from-an-object-in-blazor.htm

localization: \
https://www.telerik.com/blogs/blazor-basics-localization-using-resource-files

todo: 
- add .gitignore
- add to github
- make out with sqlite
- create components for standard label + input field
- create component for standard generic form