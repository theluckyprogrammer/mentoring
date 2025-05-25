using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;
using static System.Console;

namespace Csharp11
{
    internal class GenericAttribute : Demo
    {
        public override void Run()
        {
            Example initIntAndStringWithDefault = new Example();
            
            var myStringProp = initIntAndStringWithDefault.GetType().GetProperty("MyString");
            var myStringAttrib = (DefaultValueAttribute<string>)Attribute.GetCustomAttribute(myStringProp, typeof(DefaultValueAttribute<string>));

            var myIntProp = initIntAndStringWithDefault.GetType().GetProperty("MyInt");
            var myIntAttrib = (DefaultValueAttribute<int>)Attribute.GetCustomAttribute(myIntProp, typeof(DefaultValueAttribute<int>));

            WriteLine(myIntAttrib?.Value);
            WriteLine(myStringAttrib?.Value);
        }


        
    }

    // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/file
    file class Example
    {
        [DefaultValue<int>(-17)]
        public int MyInt { get; set; }

        [DefaultValue<string>("Hello")]
        public string MyString { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultValueAttribute<T> : Attribute
    {
        public T Value { get; }
        public DefaultValueAttribute(T value) => Value = value;
    }

    /*  
        Reasons:
        Why use the [DefaultValue] attribute if it does not set a value?
        This is an excellent question! The [DefaultValue] attribute has its uses, although it is not used to set property values automatically.
        Here is what it is helpful for:
        
        1. documentation and developer intent
        [DefaultValue] communicates to other developers what the intended default value of a property is.        
        It helps maintain code readability, especially when the default value is not explicitly assigned.
        
        2. Support for tools and frameworks
        Designers in Visual Studio (e.g., WinForms form editors, WPF) can use this attribute to know the default value and, 
        for example, not write it to a file if the property has a default value.        
        Serializers (e.g., JSON.NET, XML serializer) can skip serializing a property if it has a default value, thus reducing the data size.        
        Configuration frameworks can use this attribute to generate defaults.
        
        3. Automatic code generation and reflection tools
        You can write custom code that sets default values based on the [DefaultValue] attribute (e.g., in a constructor or object factory).        
        This makes it easier to automate and standardize the initialization of objects.  
    
        Limitations:
        - using reflection's .GetCustomAttribute to obtain the Custom Attribute, we need to use the expected type in method parameter like:
            typeof(DefaultValueAttribute<string>)
     */


}
