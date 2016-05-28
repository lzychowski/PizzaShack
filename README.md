# PizzaShack - A Visual Studio technology demo
PizzaShack is a Visual Studio 2015 solution composed out of an MVC project and a unit test project.  It is meant to display various ways of implementing most basic web app functionality.

## Contents

* PizzaShack MVC project with a bit of everything (forms, AJAX, DI, data access etc.)
* PizzaShackTests project with unit/integration tests 

## Technologies
* ASP.NET MVC 5 http://www.asp.net/mvc
* Entity Framework (data access) https://msdn.microsoft.com/en-us/data/ef.aspx
* Attribute Routing http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
* Unity.Mvc5 (dependency injection) https://github.com/devtrends/Unity.Mvc5
* MOQ (mocking library for testing) https://github.com/moq/moq4
* Form POST
* AJAX POST
* ADO.NET Data Model created from Database https://msdn.microsoft.com/en-us/data/jj206878.aspx
* Custom Repository Pattern https://msdn.microsoft.com/en-us/library/ff649690.aspx
* ASP.NET Razor basic templates https://en.wikipedia.org/wiki/ASP.NET_Razor
* Publish script for Azure App Service
* Datasource for Azure SQL Database

By no means this is to be treated as the best way to code.  The goal of this project was to demonstrate how certain things can be accomplished.

## Setup

1. Pull solution.
2. Open in Visual Studio 2013/2015.
3. Edit PizzaShack.pubxml file (Solution > PizzaShack > Properties > PublishProfiles) and update the following:

  1. `<MSDeployServiceURL>{AZURE_URL}</MSDeployServiceURL>`
  
  2. ` <Destination Path="Data Source={SERVER};Initial Catalog={SERVER_DATABASE};Persist Security Info=True;User ID={USER_NAME};Password={PASSWORD};Application Name=EntityFramework" Name="Data Source={SERVER};Initial Catalog={SERVER_DATABASE};Persist Security Info=True;User ID={USER_NAME};Password={PASSWORD};MultipleActiveResultSets=True;Application Name=EntityFramework" />`
  
  3. `<ParameterValue>metadata=res://*/Models.Pizza.csdl|res://*/Models.Pizza.ssdl|res://*/Models.Pizza.msl;provider=System.Data.SqlClient;provider connection string="Data Source={SERVER};Initial Catalog={SERVER_DATABASE};Persist Security Info=True;User ID={USER_NAME};Password={PASSWORD};MultipleActiveResultSets=True;Application Name=EntityFramework"</ParameterValue>`
  
3. Edit Web.config file (Solution > PizzaShack) and update the following:

  1. `<add name="Entities" connectionString="metadata=res://*/Models.Pizza.csdl|res://*/Models.Pizza.ssdl|res://*/Models.Pizza.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source={SERVER};initial catalog={SERVER_DATABASE};persist security info=True;user id={USER_NAME};password={PASSWORD};MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" /></connectionStrings>`
  
5. Once your data source and publish credentials are set, you can run the SQL statements located in Solution > PizzaShack > SQL > tables.sql file.

6. You should be ready to go.  Run the project.

