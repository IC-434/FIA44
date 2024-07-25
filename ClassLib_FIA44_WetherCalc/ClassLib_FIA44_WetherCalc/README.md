# Weather Calculation Library

## Introduction

A static class library with four methods that returns weather data:

- DewPoint

~~~csharp

	double DewPoint(double temperature, double humidity)

~~~

- HeatIndex
```csharp

	double HeatIndexInDegree(double temperature, double humidity)

```

- WindChill
```csharp
	double WindChillInDegree(double temperature, double windSpeed)

```

- CloudBase
```csharp
	double CloudBase(double temperature, double dewPoint)

```