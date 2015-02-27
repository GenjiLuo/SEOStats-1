# SEOStats
Checking of Google PageRank, Alexa rank and etc. for your site.

[![NuGet Version](http://img.shields.io/nuget/v/TAlex.SEOStats.svg?style=flat)](https://www.nuget.org/packages/TAlex.SEOStats/) [![NuGet Downloads](http://img.shields.io/nuget/dt/TAlex.SEOStats.svg?style=flat)](https://www.nuget.org/packages/TAlex.SEOStats/)
[![Build status](https://ci.appveyor.com/api/projects/status/1wk2nok59wyc1gu6?svg=true)](https://ci.appveyor.com/project/T-Alex/seostats)

## Example of usage

Get Google PageRank for ```google.com```
```C#
var statistics = new GoogleStats().GetStats("http://google.com");
Console.WriteLine(statistics.PageRank);
```

Get Alexa rank for ```google.com```
```C#
var statistics = new AlexaStats().GetStats("http://google.com");
Console.WriteLine(statistics.TrafficRank);
```

## Get it on NuGet!

    Install-Package TAlex.SEOStats

## License
TAlex.SEOStats is under the [MIT license](https://github.com/T-Alex/SEOStats/blob/master/LICENSE.md).
