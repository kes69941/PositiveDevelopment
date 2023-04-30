# PositiveDevelopment

Welcome to the Positive Development Client Portal App! Where you can create clients and search for clients. 

## How to Get Started

It is recommended to just pull down the project, open it in visual studio and run. Publishing across platforms requires thought and planning.

## About the Technologies

This Application was written in C# with the .Net CORE framework using Razor pages. It includes a local sqlite database for peristent storage.
The storage is code-first storage using Entity Framework and LINQ as the tool for querying entries. To create the DBContext and supporting classes,
the databases were declared via SQL in SQL Managemennt Studio with a SQL Server backend. An Entity Framework command tool was then used
for generating the boiler place code in C#. This saved a lot of typing. 

## Why C# and .NET Core? 

The template, scaffolding and documentation are thorough and C# IDE (Visual Studio) is easy to work with. Auto-completion, imports and setting
up break points comes out-of-the box. I chose this for the speed and efficiency of my development as well as my familiarity with Entity Framework. 

## What would I change? 

0. I would have chosen a lighter framework such as RubyOnRails for faster development and publishing. 
1. Layer inbetween dbcontext and controllers. 
2. Dependency injection
3. Use of async calls to improve performance. 
4. Unit tests and integration tests to ensure data persisted across views, button clicks, etc...
5. A deployment pipeline. 
6. Model constraints and validation to prevent bad view input.
7. Security concerns (for example, locking database access and file (since it's local) or encryption at rest). 

If this was a WebAPI or needed to persist data to a remote server, then concerns such as canaries (that ping the API and monitor for metrics)
and encryption in transit, security tokens, identity and access management, cross-site scripting attacks and much more would need to be considered. 
In addition, it would warrant an infrastructure pipeline and not just a application pipeline. 

## What other technologies were considered? 

* C# Lambda vending an API through API Gateway with an AWS RDS backend. I chose not to do this because AWS Lambda only supportes .NET Core 3.5
and C# tools (such as entity framework) are too abstract and asynchrously run to work well in a lambda. Also, the setup for this would easily take
days. 

* Building a simple WinForms app with a SQLite database to be deployed similarly as woudl be to an IOT edge device. Unfortunately, WinForms is 
still supported but on a deprecation path. It is no longer a template in the current Visual Studio setup and I didn't want to run into an issue
with tool versioning or have to build the scaffolding from scratch. 

* RubyOnRails: Though I have extensive ruby experience at this point, I do not have RAILS experience or any UI experience with Ruby vended websites. 
This made me think twice about choosing it as the desired alloted time was no more than 3 hours. 

* Finally, I considered just hosting an RDS database in the AWS cloud and connecting to it (instead of SQLite). However, the db instance would have
to be open to the wide world as Security Groups that are attached to a VPC / Subnets / Subnet Groups in the cloud do not accept IP traffic
from most private computer IP addresses (ie, CIDR blocks that begin with 165). The networking alone would have taken me a while to figure out. 

## Lessons Learned

My development environment was not set up. I did not have Visual Studio, SQL Management Studio or SQLite installed. Getting the right versions
and choosing the framework I wanted to use ate up a lot of time. In retrospect, I would have been better off choosing something a bit more
lightweight than C#. Though the development tools (such as drilling, breakpoints, watch variables, CPU & Memory metrics, etc...) are very 
handy, they drastically slow development time. The test-> iteration time to debug an issue was easily 10 minutes at its worst. As a result, 
the actual development took longer than the requested time (unfortunately). I would have been better off choosing a light weight framework such 
as Ruby on Rails with a quick testing turnaround time. 