# SEO Analyser

SEO Analyser is a web application that performs a simple SEO analysis of the text or url.

Following is the screen shot of web application how it looks like

![seowebapplication](https://user-images.githubusercontent.com/34714293/53303444-492dac00-38a5-11e9-80a9-c232cedc1b50.PNG)

User submits a text in English or URL,the following SEO Analysis will happen 

- Filters out stop-words (e.g. ‘or’, ‘and’, ‘a’, ‘the’ etc), 
- Calculates number of occurrences of each word, 
- Number of occurrences on the page of each keyword listed in meta tags, 
- Number of external links in the text

The information will be show in each respective tab e.g, Words Count,Meta Tags and External Links.

**Technologies Used:-** 

- **Front End**: ASP.NET MVC
- **API** : ASP.NET web Api 2.0 , C# 

**Tools Used:-**

- Visual Studio 2015
- PostMan

**Library Used**

  - **Unity.WebApi** : Allows the simple Integration of the Unity IoC container with ASP.NET Web API. 
  
  - **log4net** : log4net is a tool to help the programmer output log statements to a variety of output targets. In case of problems with an application, it is helpful to enable logging so that the problem can be located. With log4net it is possible to enable logging at runtime without modifying the application binary.
  
  - **nunit.framework** : NUnit is a unit-testing framework for all .Net languages,it makes unit test easy.
  
  - **NSubstitute** : NSubstitute is a friendly substitute for .NET mocking frameworks.
  
  - **Newtonsoft.Json**: Json.NET is a popular high-performance JSON framework for .NET.
  
 - **Swashbuckle.Core**: Seamlessly adds a Swagger to WebApi projects!
  
  
 **Key Concepts used**
 
   - **Design pattern**
   - **Construct Dependency pattern**
   - **Separation of Concern**
   - **SOLID Principles**
   
 
 - **SEOAnlayser.Components** : Its Build using the factory **Design pattern**  and **Construct Dependency** which makes it easy for unit testing and following the concept of decoupled architecture.
 
 - **SEOAnalyser.ClientApp** : Its build using **Asp.Net MVC Framework**
 
 - **SEOAnalyser.API** : Its build using using **Asp.Net Web API FrameWork**
   

**Testing SEO Analyser API using Swagger**

  **localHost :http://www.seoanalyser.com:8080/swagger/ui/index#!**

  **Note** : Host Web Api on IIS and Change Host file on ur local machine  as shown in image below
   
   
![host](https://user-images.githubusercontent.com/34714293/53303903-d1628000-38aa-11e9-9014-bb7bc37ff58b.PNG)
==============================================================================================================================
![seoanalyserswaggerapi](https://user-images.githubusercontent.com/34714293/53303836-1fc34f00-38aa-11e9-8c32-9e114f671ea9.PNG)




